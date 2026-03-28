using PodcastUniverseEditor.Models;
using PodcastUniverseEditor.Models.Common;
using PodcastUniverseEditor.Models.Episodes;
using PodcastUniverseEditor.Models.Validation;
using PodcastUniverseEditor.Models.World;

namespace PodcastUniverseEditor.Services.Validation;

/// <summary>
/// Runs a rule set against a PodcastProject and returns a ValidationResult.
/// Stateless — create once and call Validate as many times as needed.
/// Each private rule method appends to the shared result; rules are independent.
/// </summary>
public class ProjectValidationService
{
    // ── Public API ────────────────────────────────────────────────────────────

    public ValidationResult Validate(PodcastProject project)
    {
        var result = new ValidationResult();

        ValidateVesselRegistries(project, result);

        foreach (var episode in project.Episodes)
            foreach (var entry in episode.Entries)
                ValidateEntry(project, entry, result);

        return result;
    }

    // ── Entry-level rules ─────────────────────────────────────────────────────

    private static void ValidateEntry(PodcastProject p, EpisodeEntryRecord entry, ValidationResult result)
    {
        // Local helpers to reduce repetition
        void Add(ValidationSeverity severity, string message, string field = "") =>
            result.Messages.Add(new ValidationMessage
            {
                Severity   = severity,
                Message    = message,
                EntityType = nameof(EpisodeEntryRecord),
                EntityId   = entry.Id,
                FieldName  = field
            });

        void Warn(string message, string field = "")  => Add(ValidationSeverity.Warning, message, field);
        void Error(string message, string field = "") => Add(ValidationSeverity.Error,   message, field);

        string label = string.IsNullOrEmpty(entry.Name) ? $"entry {entry.Id[..8]}" : $"entry '{entry.Name}'";

        if (entry.EntryKind == EntryKind.Traffic)
        {
            // Traffic entries should not carry a notice type
            if (entry.NoticeTypeId != null)
                Warn($"Traffic {label} has a notice type set — notice type is for notice entries only.", "NoticeTypeId");

            // Operation type field requirements
            if (entry.OperationTypeId != null)
            {
                var opType = p.OperationTypes.FirstOrDefault(o => o.Id == entry.OperationTypeId);
                if (opType == null)
                {
                    Warn($"Traffic {label}: operation type ID references a missing record.", "OperationTypeId");
                }
                else
                {
                    if (opType.RequiresOrigin && string.IsNullOrEmpty(entry.OriginStationId))
                        Error($"Traffic {label}: operation '{opType.Name}' requires an origin station.", "OriginStationId");
                    if (opType.RequiresDestination && string.IsNullOrEmpty(entry.DestinationStationId))
                        Error($"Traffic {label}: operation '{opType.Name}' requires a destination station.", "DestinationStationId");
                }
            }

            // Declared cargo must not contain contraband
            foreach (var cargo in entry.DeclaredCargo.Where(c => !c.IsHiddenTruthOnly))
            {
                var commodity = p.Commodities.FirstOrDefault(c => c.Id == cargo.CommodityId);
                if (commodity?.IsContraband == true)
                    Error($"Traffic {label}: declared cargo contains contraband commodity '{commodity.Name}'.", "DeclaredCargo");
            }
        }
        else // Notice
        {
            // Notice entries should not carry an operation type
            if (entry.OperationTypeId != null)
                Warn($"Notice {label} has an operation type set — operation type is for traffic entries only.", "OperationTypeId");
        }

        // Story beat must belong to the selected story thread
        if (entry.AppliedStoryBeatId != null)
        {
            if (string.IsNullOrEmpty(entry.StoryThreadId))
            {
                Error($"{label.Capitalize()}: a story beat is applied but no story thread is selected.", "AppliedStoryBeatId");
            }
            else
            {
                var thread = p.StoryThreads.FirstOrDefault(t => t.Id == entry.StoryThreadId);
                if (thread == null)
                    Warn($"{label.Capitalize()}: story thread ID references a missing record.", "StoryThreadId");
                else if (!thread.Beats.Any(b => b.Id == entry.AppliedStoryBeatId))
                    Error($"{label.Capitalize()}: the applied story beat does not belong to thread '{thread.Name}'.", "AppliedStoryBeatId");
            }
        }

        // Phrase template group enforcement
        ValidatePhraseGroup(p, entry, entry.IncidentPhraseTemplateId,    "incident",    "incident phrase",    result);
        ValidatePhraseGroup(p, entry, entry.ResolutionPhraseTemplateId,  "resolution",  "resolution phrase",  result);
        ValidatePhraseGroup(p, entry, entry.RouteStatusPhraseTemplateId, "route_status","route status phrase", result);

        // Dock state checks
        if (entry.DockId != null)
        {
            var dock = p.Docks.FirstOrDefault(d => d.Id == entry.DockId);
            if (dock == null)
            {
                Warn($"{label.Capitalize()}: dock ID references a missing record.", "DockId");
            }
            else
            {
                if (dock.IsSuspended)
                    Warn($"{label.Capitalize()}: dock '{dock.Name}' is suspended and should not receive active traffic.", "DockId");
                if (dock.IsRestricted && string.IsNullOrEmpty(entry.DirectiveId))
                    Warn($"{label.Capitalize()}: dock '{dock.Name}' is restricted but no directive has been cited.", "DirectiveId");
            }
        }

        // Dangling reference checks — warn rather than error (data may be added later)
        if (entry.VesselId != null && !p.Vessels.Any(v => v.Id == entry.VesselId))
            Warn($"{label.Capitalize()}: vessel ID references a missing record.", "VesselId");
        if (entry.StationId != null && !p.Stations.Any(s => s.Id == entry.StationId))
            Warn($"{label.Capitalize()}: station ID references a missing record.", "StationId");
        if (entry.OriginStationId != null && !p.Stations.Any(s => s.Id == entry.OriginStationId))
            Warn($"{label.Capitalize()}: origin station ID references a missing record.", "OriginStationId");
        if (entry.DestinationStationId != null && !p.Stations.Any(s => s.Id == entry.DestinationStationId))
            Warn($"{label.Capitalize()}: destination station ID references a missing record.", "DestinationStationId");
        if (entry.StoryThreadId != null && !p.StoryThreads.Any(t => t.Id == entry.StoryThreadId))
            Warn($"{label.Capitalize()}: story thread ID references a missing record.", "StoryThreadId");
    }

    // ── Phrase group rule ─────────────────────────────────────────────────────

    private static void ValidatePhraseGroup(
        PodcastProject p,
        EpisodeEntryRecord entry,
        string? phraseId,
        string expectedGroup,
        string fieldLabel,
        ValidationResult result)
    {
        if (phraseId == null) return;

        var phrase = p.PhraseTemplates.FirstOrDefault(pt => pt.Id == phraseId);
        if (phrase == null)
        {
            result.Messages.Add(new ValidationMessage
            {
                Severity   = ValidationSeverity.Warning,
                Message    = $"Entry '{entry.Name}': {fieldLabel} ID references a missing phrase template.",
                EntityType = nameof(EpisodeEntryRecord),
                EntityId   = entry.Id,
                FieldName  = fieldLabel
            });
            return;
        }

        if (!string.Equals(phrase.TemplateGroup, expectedGroup, StringComparison.OrdinalIgnoreCase))
        {
            result.Messages.Add(new ValidationMessage
            {
                Severity   = ValidationSeverity.Warning,
                Message    = $"Entry '{entry.Name}': {fieldLabel} '{phrase.Name}' belongs to group '{phrase.TemplateGroup}', expected '{expectedGroup}'.",
                EntityType = nameof(EpisodeEntryRecord),
                EntityId   = entry.Id,
                FieldName  = fieldLabel
            });
        }
    }

    // ── Project-level rules ───────────────────────────────────────────────────

    private static void ValidateVesselRegistries(PodcastProject p, ValidationResult result)
    {
        // Duplicate registry codes are a world-building error
        var duplicates = p.Vessels
            .Where(v => !string.IsNullOrEmpty(v.Registry))
            .GroupBy(v => v.Registry, StringComparer.OrdinalIgnoreCase)
            .Where(g => g.Count() > 1);

        foreach (var group in duplicates)
        {
            foreach (var vessel in group)
            {
                result.Messages.Add(new ValidationMessage
                {
                    Severity   = ValidationSeverity.Warning,
                    Message    = $"Vessel '{vessel.Name}' shares registry '{vessel.Registry}' with another vessel.",
                    EntityType = nameof(VesselRecord),
                    EntityId   = vessel.Id,
                    FieldName  = "Registry"
                });
            }
        }
    }
}

// ── String helper ─────────────────────────────────────────────────────────────

file static class StringExtensions
{
    /// <summary>Capitalises the first character of a string.</summary>
    internal static string Capitalize(this string s) =>
        string.IsNullOrEmpty(s) ? s : char.ToUpper(s[0]) + s[1..];
}
