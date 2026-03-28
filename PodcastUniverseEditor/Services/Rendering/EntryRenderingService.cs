using System.Text;
using PodcastUniverseEditor.Models;
using PodcastUniverseEditor.Models.Common;
using PodcastUniverseEditor.Models.Episodes;
using PodcastUniverseEditor.Models.ReferenceData;
using PodcastUniverseEditor.Models.World;

namespace PodcastUniverseEditor.Services.Rendering;

/// <summary>
/// Renders EpisodeEntryRecord and EpisodeRecord instances to broadcast script text.
/// Deterministic and stateless — always pass the full project for reference data resolution.
/// Never exposes hidden truth fields (ActualCargo, ActualPassengers, ActualPurposeId,
/// HiddenTruthNotes). Uses only the public (declared) layer.
/// </summary>
public class EntryRenderingService
{
    // ── Public API ────────────────────────────────────────────────────────────

    /// <summary>
    /// Renders a single entry to broadcast text.
    /// Returns a formatted multi-line string without a trailing newline.
    /// </summary>
    public string RenderEntry(PodcastProject project, EpisodeEntryRecord entry)
    {
        return entry.EntryKind == EntryKind.Traffic
            ? RenderTrafficEntry(project, entry)
            : RenderNoticeEntry(project, entry);
    }

    /// <summary>
    /// Renders all entries in an episode to a single script string, sorted by SortOrder.
    /// Includes an episode header line.
    /// </summary>
    public string RenderEpisode(PodcastProject project, EpisodeRecord episode)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"=== {episode.Name} ===");
        if (episode.InUniverseUtc.HasValue)
            sb.AppendLine(episode.InUniverseUtc.Value.ToString("yyyy-MM-dd HH:mm UTC"));

        var entries = episode.Entries.OrderBy(e => e.SortOrder).ToList();
        if (entries.Count == 0)
        {
            sb.Append("(no entries)");
            return sb.ToString();
        }

        sb.AppendLine("---");

        bool first = true;
        foreach (var entry in entries)
        {
            if (!first) sb.AppendLine();
            first = false;
            sb.AppendLine(RenderEntry(project, entry));
        }

        return sb.ToString().TrimEnd();
    }

    // ── Traffic entry ─────────────────────────────────────────────────────────

    private string RenderTrafficEntry(PodcastProject p, EpisodeEntryRecord e)
    {
        var sb = new StringBuilder();
        var opts = e.RenderOptions;

        var station  = Find(p.Stations, e.StationId);
        var dock     = Find(p.Docks, e.DockId);
        var opType   = Find(p.OperationTypes, e.OperationTypeId);

        string stationName = station?.Name ?? string.Empty;
        string dockLabel   = dock != null
            ? (string.IsNullOrEmpty(dock.SpokenLabel) ? dock.Name : dock.SpokenLabel)
            : string.Empty;

        // ── Header ────────────────────────────────────────────────────────────

        if (opType != null && !string.IsNullOrEmpty(opType.HeaderFormat))
        {
            sb.AppendLine(SubstituteTokens(opType.HeaderFormat, stationName, dockLabel));
        }
        else
        {
            string fallback = string.IsNullOrEmpty(e.Name) ? "Traffic entry.--" : $"{e.Name}.--";
            sb.AppendLine(fallback);
        }

        // ── Vessel ────────────────────────────────────────────────────────────

        var vessel = Find(p.Vessels, e.VesselId);
        if (vessel != null)
        {
            string registry = !string.IsNullOrEmpty(e.RegistryOverride)
                ? e.RegistryOverride
                : vessel.Registry;

            string vesselClassId = !string.IsNullOrEmpty(e.VesselClassOverrideId)
                ? e.VesselClassOverrideId
                : vessel.VesselClassId;
            var vesselClass = Find(p.VesselClasses, vesselClassId);
            string classNoun = vesselClass != null && !string.IsNullOrEmpty(vesselClass.SpokenNoun)
                ? vesselClass.SpokenNoun
                : vesselClass?.Name ?? string.Empty;

            var parts = new List<string> { $"Vessel {vessel.Name}" };
            if (!string.IsNullOrEmpty(registry))   parts.Add($"registry {registry}");
            if (!string.IsNullOrEmpty(classNoun))  parts.Add(classNoun);
            sb.AppendLine($"  {string.Join(", ", parts)}.--");
        }

        // ── Route ─────────────────────────────────────────────────────────────

        var origin      = Find(p.Stations, e.OriginStationId);
        var destination = Find(p.Stations, e.DestinationStationId);

        if (origin != null)
            sb.AppendLine($"  Inbound from {origin.Name}.--");
        if (destination != null)
            sb.AppendLine($"  Outbound to {destination.Name}.--");

        // ── Purpose ───────────────────────────────────────────────────────────

        if (opts.IncludePurpose && e.DeclaredPurposeId != null)
        {
            var purpose = Find(p.Purposes, e.DeclaredPurposeId);
            if (purpose != null)
            {
                string purposeText = !string.IsNullOrEmpty(purpose.SpokenPhrase)
                    ? purpose.SpokenPhrase
                    : purpose.Name.ToLowerInvariant();
                sb.AppendLine($"  Declared purpose: {purposeText}.--");
            }
        }

        // ── Cargo ─────────────────────────────────────────────────────────────

        if (opts.IncludeCargo)
        {
            var cargoLines = e.DeclaredCargo.Where(c => !c.IsHiddenTruthOnly).ToList();
            if (cargoLines.Count > 0)
            {
                var parts = cargoLines.Select(c =>
                {
                    var commodity = Find(p.Commodities, c.CommodityId);
                    string name = !string.IsNullOrEmpty(c.SpokenCommodityNameOverride)
                        ? c.SpokenCommodityNameOverride
                        : (commodity?.Name ?? "unknown commodity");
                    string unit = !string.IsNullOrEmpty(c.UnitLabelOverride)
                        ? c.UnitLabelOverride
                        : (commodity?.UnitLabel ?? "units");
                    return $"{c.Quantity} {unit} {name}";
                }).ToList();
                sb.AppendLine($"  Cargo: {string.Join(", ", parts)}.--");
            }
        }

        // ── Passengers ────────────────────────────────────────────────────────

        if (opts.IncludePassengers)
        {
            var paxLines = e.DeclaredPassengers.Where(px => !px.IsHiddenTruthOnly).ToList();
            if (paxLines.Count > 0)
            {
                var parts = paxLines.Select(px =>
                {
                    var cat = Find(p.PassengerCategories, px.PassengerCategoryId);
                    string catName = (cat != null && !string.IsNullOrEmpty(cat.SpokenLabel))
                        ? cat.SpokenLabel
                        : (cat?.Name ?? "passenger");
                    return $"{px.Count} {catName.ToLowerInvariant()}";
                }).ToList();
                sb.AppendLine($"  Passengers: {string.Join(", ", parts)}.--");
            }
        }

        // ── Status phrases (grouped onto one line) ────────────────────────────

        var statusPhrases = new List<string>();

        if (opts.IncludeManifestStatus && e.ManifestStatusId != null)
        {
            var ms = Find(p.ManifestStatuses, e.ManifestStatusId);
            if (ms != null && !string.IsNullOrEmpty(ms.SpokenPhrase))
                statusPhrases.Add(ms.SpokenPhrase);
        }

        if (opts.IncludeInspectionStatus && e.InspectionStatusId != null)
        {
            var ins = Find(p.InspectionStatuses, e.InspectionStatusId);
            if (ins != null && !string.IsNullOrEmpty(ins.SpokenPhrase))
                statusPhrases.Add(ins.SpokenPhrase);
        }

        if (e.ClearanceStatusId != null)
        {
            var cs = Find(p.ClearanceStatuses, e.ClearanceStatusId);
            if (cs != null && !string.IsNullOrEmpty(cs.SpokenPhrase))
                statusPhrases.Add(cs.SpokenPhrase);
        }

        if (statusPhrases.Count > 0)
            sb.AppendLine("  " + string.Join(" ", statusPhrases));

        // ── Environmental condition ───────────────────────────────────────────

        if (opts.IncludeEnvironmentalStatus && e.EnvironmentalConditionId != null)
        {
            var env = Find(p.EnvironmentalConditions, e.EnvironmentalConditionId);
            if (env != null && !string.IsNullOrEmpty(env.SpokenPhrase))
                sb.AppendLine($"  {env.SpokenPhrase}");
        }

        // ── Directive ─────────────────────────────────────────────────────────

        if (e.DirectiveId != null)
        {
            var dir = Find(p.Directives, e.DirectiveId);
            if (dir != null && !string.IsNullOrEmpty(dir.SpokenPhrase))
                sb.AppendLine($"  {dir.SpokenPhrase}");
        }

        // ── Phrase overlays ───────────────────────────────────────────────────

        if (e.IncidentPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.IncidentPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {SubstituteTokens(pt.TemplateText, stationName, dockLabel)}");
        }

        if (e.RouteStatusPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.RouteStatusPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {SubstituteTokens(pt.TemplateText, stationName, dockLabel)}");
        }

        if (opts.IncludeResolution && e.ResolutionPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.ResolutionPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {SubstituteTokens(pt.TemplateText, stationName, dockLabel)}");
        }

        return sb.ToString().TrimEnd();
    }

    // ── Notice entry ──────────────────────────────────────────────────────────

    private string RenderNoticeEntry(PodcastProject p, EpisodeEntryRecord e)
    {
        var sb = new StringBuilder();
        var opts = e.RenderOptions;

        var noticeType = Find(p.NoticeTypes, e.NoticeTypeId);

        // ── Header ────────────────────────────────────────────────────────────

        if (noticeType != null && !string.IsNullOrEmpty(noticeType.HeaderText))
            sb.AppendLine(noticeType.HeaderText);
        else
            sb.AppendLine(string.IsNullOrEmpty(e.Name) ? "Notice.--" : $"{e.Name}.--");

        // ── Body ──────────────────────────────────────────────────────────────

        if (!string.IsNullOrEmpty(e.PublicBodyOverride))
        {
            // Author-provided body overrides everything
            sb.AppendLine($"  {e.PublicBodyOverride}");
        }
        else if (noticeType != null && !string.IsNullOrEmpty(noticeType.DefaultBodyFormat))
        {
            string body = noticeType.DefaultBodyFormat.Replace("{Detail}", e.Name);
            sb.AppendLine($"  {body}");
        }
        else if (!string.IsNullOrEmpty(e.Name))
        {
            sb.AppendLine($"  {e.Name}");
        }

        // ── Phrase overlays ───────────────────────────────────────────────────

        if (e.IncidentPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.IncidentPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {pt.TemplateText}");
        }

        if (opts.IncludeResolution && e.ResolutionPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.ResolutionPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {pt.TemplateText}");
        }

        return sb.ToString().TrimEnd();
    }

    // ── Private helpers ───────────────────────────────────────────────────────

    /// <summary>
    /// Substitutes {Station} and {Dock} tokens with the resolved names.
    /// Unknown tokens are left as-is for future phases.
    /// </summary>
    private static string SubstituteTokens(string template, string stationName, string dockLabel)
        => template
            .Replace("{Station}", stationName)
            .Replace("{Dock}",    dockLabel);

    private static T? Find<T>(IEnumerable<T> collection, string? id) where T : EntityBase
    {
        if (string.IsNullOrEmpty(id)) return null;
        return collection.FirstOrDefault(x => x.Id == id);
    }
}
