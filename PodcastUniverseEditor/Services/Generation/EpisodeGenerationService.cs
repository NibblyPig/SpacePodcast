using PodcastUniverseEditor.Models;
using PodcastUniverseEditor.Models.Common;
using PodcastUniverseEditor.Models.Episodes;
using PodcastUniverseEditor.Models.ReferenceData;
using PodcastUniverseEditor.Models.Threads;
using PodcastUniverseEditor.Models.World;

namespace PodcastUniverseEditor.Services.Generation;

/// <summary>
/// Generates EpisodeEntryRecord instances from a PodcastProject's reference data,
/// routes, vessels, and story threads. All methods are deterministic given a seed.
/// Canon and locked entries are never modified or cleared.
///
/// Cooldown contract: FillEpisode ticks cooldowns at the START of the call (before
/// building entries), representing the passage of one episode since the last call.
/// GenerateEntry / GenerateEntries do not tick — they are single-entry operations.
/// </summary>
public class EpisodeGenerationService
{
    private readonly WeightedRandomService         _weighted    = new();
    private readonly StoryThreadProgressionService _progression = new();

    // ── Public API ────────────────────────────────────────────────────────────

    /// <summary>
    /// Generates a single traffic entry in Editing mode (no story mutation).
    /// Set <paramref name="advanceStory"/> to true only when generating in simulation context.
    /// </summary>
    public EpisodeEntryRecord GenerateEntry(PodcastProject project, int? seed = null, bool advanceStory = false)
    {
        var options = advanceStory ? GenerationOptions.Simulation : GenerationOptions.Editing;
        var rng     = WeightedRandomService.CreateRandom(seed);
        return BuildEntry(project, rng, seed, sortOrder: 1, options);
    }

    /// <summary>
    /// Generates <paramref name="count"/> entries in Editing mode (no story mutation).
    /// Each entry records its per-entry seed offset for reproducibility.
    /// </summary>
    public List<EpisodeEntryRecord> GenerateEntries(PodcastProject project, int count, int? seed = null)
    {
        var rng     = WeightedRandomService.CreateRandom(seed);
        var results = new List<EpisodeEntryRecord>(count);
        for (int i = 0; i < count; i++)
        {
            int? entrySeed = seed.HasValue ? seed.Value + i : null;
            results.Add(BuildEntry(project, rng, entrySeed, sortOrder: i + 1, GenerationOptions.Editing));
        }
        return results;
    }

    /// <summary>
    /// Appends (or replaces) entries in the episode in Simulation mode.
    /// Ticks cooldowns at the START of the call (representing passage of one episode).
    /// When <paramref name="clearExisting"/> is true, all non-locked and non-canon entries
    /// are removed before generation. Locked and canon entries are never touched.
    /// </summary>
    public void FillEpisode(
        PodcastProject project,
        EpisodeRecord   episode,
        int             count,
        bool            clearExisting,
        int?            seed = null)
    {
        // Simulation mode only — tick first so threads advanced in a previous FillEpisode
        // call have their cooldowns decremented before new beats are applied in this pass.
        _progression.TickCooldowns(project);

        if (clearExisting)
            episode.Entries.RemoveAll(e => !e.IsLocked && !e.IsCanon);

        int nextSort = episode.Entries.Count > 0
            ? episode.Entries.Max(e => e.SortOrder) + 1
            : 1;

        var rng = WeightedRandomService.CreateRandom(seed);
        for (int i = 0; i < count; i++)
        {
            int? entrySeed = seed.HasValue ? seed.Value + i : null;
            var entry = BuildEntry(project, rng, entrySeed, sortOrder: nextSort + i, GenerationOptions.Simulation);
            episode.Entries.Add(entry);
        }
    }

    // ── Core builder ──────────────────────────────────────────────────────────

    private EpisodeEntryRecord BuildEntry(PodcastProject project, Random rng, int? seed, int sortOrder, GenerationOptions options)
    {
        var entry = new EpisodeEntryRecord
        {
            Id         = Guid.NewGuid().ToString(),
            EntryKind  = EntryKind.Traffic,
            SourceType = EntrySourceType.Generated,
            SortOrder  = sortOrder,
            RandomSeed = seed
        };

        // ── Hub station ───────────────────────────────────────────────────────

        var hub = FindHubStation(project);

        // ── Thread selection ──────────────────────────────────────────────────
        // Thread is selected before route so route can be biased toward the thread's
        // target vessel's preferred routes.

        StoryThreadRecord? thread = null;
        StoryBeatRecord?   beat   = null;

        var eligible = _progression.EligibleThreads(project);
        if (eligible.Count > 0 && _weighted.Chance(0.4, rng))
        {
            thread = _weighted.ChooseUniform(eligible, rng);
            if (thread != null)
                beat = _progression.PeekNextBeat(thread);
        }

        // ── Route selection ───────────────────────────────────────────────────

        var route = SelectRoute(project, rng, hub, thread);

        // ── Operation type ────────────────────────────────────────────────────

        var trafficOps = project.OperationTypes
            .Where(o => o.IsEnabled && o.IsTrafficOperation)
            .ToList();
        var opType = _weighted.ChooseUniform(trafficOps, rng);

        // ── Vessel ────────────────────────────────────────────────────────────

        var vessel     = SelectVessel(project, rng, route, thread);
        var vesselClass = vessel != null
            ? project.VesselClasses.FirstOrDefault(vc => vc.Id == vessel.VesselClassId)
            : null;

        // ── Dock — filtered to hub station ────────────────────────────────────

        var dockCandidates = DocksForStation(project, hub?.Id);
        var dock = _weighted.ChooseUniform(dockCandidates, rng);

        // ── Purpose ───────────────────────────────────────────────────────────

        string? purposeId  = SelectPurpose(project, rng, route, hub);
        var     purposeDef = purposeId != null
            ? project.Purposes.FirstOrDefault(p => p.Id == purposeId)
            : null;

        // ── Populate structural / location fields ─────────────────────────────

        entry.StationId       = hub?.Id;
        entry.DockId          = dock?.Id;
        entry.VesselId        = vessel?.Id;
        entry.OperationTypeId = opType?.Id;
        entry.DeclaredPurposeId = purposeId;

        // Route endpoints based on op type direction
        if (route != null)
        {
            bool requiresOrigin      = opType?.RequiresOrigin      == true;
            bool requiresDestination = opType?.RequiresDestination == true;

            string farStation = route.FromStationId == hub?.Id
                ? route.ToStationId
                : route.FromStationId;

            if (requiresOrigin && !requiresDestination)
            {
                entry.OriginStationId = farStation;
            }
            else if (requiresDestination && !requiresOrigin)
            {
                entry.DestinationStationId = farStation;
            }
            else if (requiresOrigin && requiresDestination)
            {
                entry.OriginStationId      = route.FromStationId;
                entry.DestinationStationId = route.ToStationId;
            }

            if (!string.IsNullOrEmpty(route.RouteConditionTemplateId))
                entry.RouteStatusPhraseTemplateId = route.RouteConditionTemplateId;
        }

        // ── Ordinary status fields ────────────────────────────────────────────

        entry.ManifestStatusId          = SelectManifestStatus(project, rng);
        entry.InspectionStatusId        = SelectInspectionStatus(project, rng);
        entry.ClearanceStatusId         = SelectClearanceStatus(project, rng);
        entry.EnvironmentalConditionId  = SelectEnvironmentalCondition(project, rng);

        // ── Cargo and passengers ──────────────────────────────────────────────

        entry.DeclaredCargo      = SelectCargo(project, rng, vesselClass, route, purposeDef);
        entry.DeclaredPassengers = SelectPassengers(project, rng, vesselClass);

        // ── Apply story beat (overrides relevant ordinary fields) ─────────────

        if (thread != null && beat != null)
        {
            entry.StoryThreadId              = thread.Id;
            entry.AppliedStoryBeatId         = beat.Id;
            entry.AnomalySeverity            = beat.Severity;

            // Beat stamps override ordinarily generated statuses/phrases.
            // Null values from the beat are intentional (e.g. stage 6 silent arrival).
            entry.ManifestStatusId           = beat.PublicManifestStatusId;
            entry.InspectionStatusId         = beat.PublicInspectionStatusId;
            entry.DirectiveId                = beat.PublicDirectiveId;
            entry.IncidentPhraseTemplateId   = beat.IncidentPhraseTemplateId;
            entry.ResolutionPhraseTemplateId = beat.ResolutionPhraseTemplateId;

            // Only advance thread state in simulation mode
            if (options.AdvanceStory)
                _progression.AdvanceThread(thread, beat);
        }

        return entry;
    }

    // ── Status selection ──────────────────────────────────────────────────────

    /// <summary>
    /// Always returns a manifest status ID. 85% chance of a non-irregular status.
    /// </summary>
    private string? SelectManifestStatus(PodcastProject project, Random rng)
    {
        var all = project.ManifestStatuses.Where(s => s.IsEnabled).ToList();
        if (all.Count == 0) return null;

        if (_weighted.Chance(0.85, rng))
        {
            var ordinary = all.Where(s => !s.ImpliesIrregularity).ToList();
            if (ordinary.Count > 0)
                return _weighted.ChooseUniform(ordinary, rng)?.Id;
        }

        return _weighted.ChooseUniform(all, rng)?.Id;
    }

    /// <summary>
    /// 60% chance of returning an inspection status. Prefers non-concern statuses.
    /// </summary>
    private string? SelectInspectionStatus(PodcastProject project, Random rng)
    {
        if (!_weighted.Chance(0.6, rng)) return null;

        var all = project.InspectionStatuses.Where(s => s.IsEnabled).ToList();
        if (all.Count == 0) return null;

        var ordinary = all.Where(s => !s.ImpliesConcern).ToList();
        return ordinary.Count > 0
            ? _weighted.ChooseUniform(ordinary, rng)?.Id
            : _weighted.ChooseUniform(all, rng)?.Id;
    }

    /// <summary>
    /// Always returns a clearance status ID. Prefers terminal-state statuses.
    /// </summary>
    private string? SelectClearanceStatus(PodcastProject project, Random rng)
    {
        var all = project.ClearanceStatuses.Where(s => s.IsEnabled).ToList();
        if (all.Count == 0) return null;

        var terminal = all.Where(s => s.IsTerminalState).ToList();
        return terminal.Count > 0
            ? _weighted.ChooseUniform(terminal, rng)?.Id
            : _weighted.ChooseUniform(all, rng)?.Id;
    }

    /// <summary>
    /// 20% chance of returning an environmental condition ID.
    /// </summary>
    private string? SelectEnvironmentalCondition(PodcastProject project, Random rng)
    {
        if (!_weighted.Chance(0.2, rng)) return null;

        var all = project.EnvironmentalConditions.Where(c => c.IsEnabled).ToList();
        return all.Count > 0 ? _weighted.ChooseUniform(all, rng)?.Id : null;
    }

    // ── Cargo and passenger selection ─────────────────────────────────────────

    /// <summary>
    /// Returns one declared cargo line if the vessel class can carry cargo.
    /// Commodity is chosen via purpose → route → vessel class category → any.
    /// Returns an empty list if no cargo is appropriate.
    /// </summary>
    private List<EntryCargoLine> SelectCargo(
        PodcastProject        project,
        Random                rng,
        VesselClassDefinition? vesselClass,
        RouteRecord?           route,
        PurposeDefinition?     purpose)
    {
        if (vesselClass == null || !vesselClass.CanCarryCargo)
            return new List<EntryCargoLine>();

        // 75% chance to include cargo even when vessel can carry it
        if (!_weighted.Chance(0.75, rng))
            return new List<EntryCargoLine>();

        // Candidates: enabled, not contraband
        var candidates = project.Commodities
            .Where(c => !c.IsContraband)
            .ToList();

        if (candidates.Count == 0)
            return new List<EntryCargoLine>();

        // Filter by vessel class typical categories if specified
        if (vesselClass.TypicalCommodityCategoryIds.Count > 0)
        {
            var classFiltered = candidates
                .Where(c => vesselClass.TypicalCommodityCategoryIds.Contains(c.CommodityCategoryId))
                .ToList();
            if (classFiltered.Count > 0)
                candidates = classFiltered;
        }

        // Pick commodity: purpose typical → route typical → any filtered candidate
        CommodityRecord? commodity = null;

        if (purpose?.TypicalCommodityIds.Count > 0)
        {
            var purposeMatch = candidates
                .Where(c => purpose.TypicalCommodityIds.Contains(c.Id))
                .ToList();
            if (purposeMatch.Count > 0)
                commodity = _weighted.ChooseUniform(purposeMatch, rng);
        }

        if (commodity == null && route?.TypicalCommodityIds.Count > 0)
        {
            var routeMatch = candidates
                .Where(c => route.TypicalCommodityIds.Contains(c.Id))
                .ToList();
            if (routeMatch.Count > 0)
                commodity = _weighted.ChooseUniform(routeMatch, rng);
        }

        commodity ??= _weighted.ChooseUniform(candidates, rng);

        if (commodity == null)
            return new List<EntryCargoLine>();

        int min = commodity.TypicalMinQuantity;
        int max = commodity.TypicalMaxQuantity;
        if (max <= min) { min = 10; max = 100; }

        return new List<EntryCargoLine>
        {
            new EntryCargoLine
            {
                CommodityId      = commodity.Id,
                Quantity         = rng.Next(min, max + 1),
                IsDeclared       = true,
                IsHiddenTruthOnly = false
            }
        };
    }

    /// <summary>
    /// Returns one declared passenger line if the vessel class can carry passengers.
    /// Count is drawn from VesselClassDefinition.TypicalPassengerMin/Max.
    /// Returns an empty list if no passengers are appropriate.
    /// </summary>
    private List<EntryPassengerLine> SelectPassengers(
        PodcastProject        project,
        Random                rng,
        VesselClassDefinition? vesselClass)
    {
        if (vesselClass == null || !vesselClass.CanCarryPassengers)
            return new List<EntryPassengerLine>();

        // 70% chance to include passengers when vessel class allows it
        if (!_weighted.Chance(0.7, rng))
            return new List<EntryPassengerLine>();

        var categories = project.PassengerCategories
            .Where(c => c.IsEnabled)
            .ToList();

        if (categories.Count == 0)
            return new List<EntryPassengerLine>();

        var category = _weighted.ChooseUniform(categories, rng);
        if (category == null)
            return new List<EntryPassengerLine>();

        int min = vesselClass.TypicalPassengerMin;
        int max = vesselClass.TypicalPassengerMax;
        if (max <= min) { min = 1; max = 12; }

        return new List<EntryPassengerLine>
        {
            new EntryPassengerLine
            {
                PassengerCategoryId = category.Id,
                Count               = rng.Next(min, max + 1),
                IsDeclared          = true,
                IsHiddenTruthOnly   = false
            }
        };
    }

    // ── Selection helpers ─────────────────────────────────────────────────────

    /// <summary>
    /// Returns the station that appears most frequently as a route endpoint.
    /// Falls back to the first station if no routes exist.
    /// </summary>
    private static StationRecord? FindHubStation(PodcastProject project)
    {
        if (project.Stations.Count == 0) return null;
        if (project.Routes.Count == 0)   return project.Stations[0];

        var counts = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (var r in project.Routes)
        {
            counts.TryAdd(r.FromStationId, 0);
            counts.TryAdd(r.ToStationId,   0);
            counts[r.FromStationId]++;
            counts[r.ToStationId]++;
        }

        string hubId = counts.OrderByDescending(kv => kv.Value).First().Key;
        return project.Stations.FirstOrDefault(s => s.Id == hubId);
    }

    /// <summary>
    /// Returns docks for the given station, preferring non-suspended ones.
    /// Falls back progressively: suspended at station → non-suspended anywhere → all docks.
    /// </summary>
    private static List<DockRecord> DocksForStation(PodcastProject project, string? stationId)
    {
        if (string.IsNullOrEmpty(stationId))
        {
            var any = project.Docks.Where(d => !d.IsSuspended).ToList();
            return any.Count > 0 ? any : project.Docks.ToList();
        }

        var atStation    = project.Docks.Where(d => d.StationId == stationId).ToList();
        var notSuspended = atStation.Where(d => !d.IsSuspended).ToList();

        if (notSuspended.Count > 0) return notSuspended;
        if (atStation.Count > 0)    return atStation;

        // Station has no docks — global fallback
        var globalOk = project.Docks.Where(d => !d.IsSuspended).ToList();
        return globalOk.Count > 0 ? globalOk : project.Docks.ToList();
    }

    private RouteRecord? SelectRoute(
        PodcastProject     project,
        Random             rng,
        StationRecord?     hub,
        StoryThreadRecord? thread)
    {
        if (project.Routes.Count == 0) return null;

        var candidates = hub != null
            ? project.Routes
                .Where(r => r.FromStationId == hub.Id || r.ToStationId == hub.Id)
                .ToList()
            : project.Routes.ToList();

        if (candidates.Count == 0)
            candidates = project.Routes.ToList();

        // Bias toward preferred routes of the thread's target vessel
        if (thread?.EntityKind == ThreadEntityKind.Vessel &&
            !string.IsNullOrEmpty(thread.TargetEntityId))
        {
            var vessel = project.Vessels.FirstOrDefault(v => v.Id == thread.TargetEntityId);
            if (vessel?.PreferredRouteIds.Count > 0)
            {
                var preferred = candidates
                    .Where(r => vessel.PreferredRouteIds.Contains(r.Id))
                    .ToList();
                if (preferred.Count > 0)
                    candidates = preferred;
            }
        }

        var weighted = candidates
            .Select(r => (r, r.FrequencyWeight > 0 ? r.FrequencyWeight : 1.0))
            .ToList();

        return _weighted.Choose(weighted, rng);
    }

    private VesselRecord? SelectVessel(
        PodcastProject     project,
        Random             rng,
        RouteRecord?       route,
        StoryThreadRecord? thread)
    {
        if (project.Vessels.Count == 0) return null;

        // Thread targets a specific vessel — use it directly
        if (thread?.EntityKind == ThreadEntityKind.Vessel &&
            !string.IsNullOrEmpty(thread.TargetEntityId))
        {
            var target = project.Vessels.FirstOrDefault(v => v.Id == thread.TargetEntityId);
            if (target != null) return target;
        }

        var candidates = project.Vessels.ToList();

        // Plausibility: filter by vessel class allowed on route
        if (route?.AllowedVesselClassIds.Count > 0)
        {
            var classFiltered = candidates
                .Where(v => route.AllowedVesselClassIds.Contains(v.VesselClassId))
                .ToList();
            if (classFiltered.Count > 0)
                candidates = classFiltered;
        }

        // Prefer vessels with this route in their preferred list
        if (route != null)
        {
            var preferred = candidates
                .Where(v => v.PreferredRouteIds.Contains(route.Id))
                .ToList();
            if (preferred.Count > 0)
                return _weighted.ChooseUniform(preferred, rng);
        }

        return _weighted.ChooseUniform(candidates, rng);
    }

    /// <summary>
    /// Selects a purpose ID weighted toward the intersection of station and route typical
    /// purposes. Falls back progressively: intersection → station → route → any enabled.
    /// </summary>
    private string? SelectPurpose(
        PodcastProject project,
        Random         rng,
        RouteRecord?   route,
        StationRecord? hub)
    {
        var enabled = project.Purposes.Where(p => p.IsEnabled).ToList();
        if (enabled.Count == 0) return null;

        var stationIds = hub?.PurposeIds            ?? new List<string>();
        var routeIds   = route?.TypicalPurposeIds   ?? new List<string>();

        // Intersection of station + route purposes
        if (stationIds.Count > 0 && routeIds.Count > 0)
        {
            var intersection = enabled
                .Where(p => stationIds.Contains(p.Id) && routeIds.Contains(p.Id))
                .ToList();
            if (intersection.Count > 0)
                return _weighted.ChooseUniform(intersection, rng)?.Id;
        }

        // Station purposes alone
        if (stationIds.Count > 0)
        {
            var stationPurposes = enabled.Where(p => stationIds.Contains(p.Id)).ToList();
            if (stationPurposes.Count > 0)
                return _weighted.ChooseUniform(stationPurposes, rng)?.Id;
        }

        // Route purposes alone
        if (routeIds.Count > 0)
        {
            var routePurposes = enabled.Where(p => routeIds.Contains(p.Id)).ToList();
            if (routePurposes.Count > 0)
                return _weighted.ChooseUniform(routePurposes, rng)?.Id;
        }

        return _weighted.ChooseUniform(enabled, rng)?.Id;
    }
}
