using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PodcastUniverseEditor.Models;
using PodcastUniverseEditor.Models.Common;
using PodcastUniverseEditor.Models.Episodes;
using PodcastUniverseEditor.Services.Rendering;

namespace PodcastUniverseEditor.Services.Export;

/// <summary>
/// Exports EpisodeRecord instances to broadcast script text, TTS-friendly text,
/// or structured JSON for downstream tooling.
///
/// Export contract:
///   - All exports are public-layer only by default (no hidden truth).
///   - Hidden truth is only included when JsonExportOptions.IncludeHiddenTruth = true.
///   - TTS exports never include hidden truth regardless of options.
///   - Deterministic: same episode + same options always produces the same output.
/// </summary>
public class ProjectExportService
{
    private readonly EntryRenderingService _renderer = new();

    private static readonly JsonSerializerOptions JsonWriteOptions = new()
    {
        WriteIndented          = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters             = { new JsonStringEnumConverter() }
    };

    // ── Public API ────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns the episode rendered as a broadcast script, exactly as produced by
    /// EntryRenderingService. Includes the === episode header and --- separator.
    /// This is the same text shown in the Output Preview tab.
    /// </summary>
    public string ExportEpisodeAsBroadcastText(PodcastProject project, EpisodeRecord episode)
        => _renderer.RenderEpisode(project, episode);

    /// <summary>
    /// Returns the episode formatted for TTS consumption.
    /// Strips broadcast-specific visual markers (.-- pause cues, === headers, ---
    /// dividers) and produces clean prose blocks ready for copy-paste into a
    /// voice tool. Never includes hidden-truth fields.
    /// </summary>
    public string ExportEpisodeAsTtsText(
        PodcastProject  project,
        EpisodeRecord   episode,
        TtsExportOptions options)
    {
        var sb      = new StringBuilder();
        var entries = episode.Entries.OrderBy(e => e.SortOrder).ToList();

        if (options.IncludeEpisodeHeader)
        {
            sb.AppendLine(episode.Name);
            if (episode.InUniverseUtc.HasValue)
                sb.AppendLine(episode.InUniverseUtc.Value.ToString("yyyy-MM-dd"));

            if (options.BlankLineBetweenEntries)
                sb.AppendLine();
        }

        for (int i = 0; i < entries.Count; i++)
        {
            if (options.IncludeEntryMarkers)
                sb.AppendLine($"[Entry {i + 1}]");

            string raw       = _renderer.RenderEntry(project, entries[i]);
            string processed = ProcessForTts(raw, options);

            if (!string.IsNullOrWhiteSpace(processed))
                sb.AppendLine(processed);

            if (options.BlankLineBetweenEntries && i < entries.Count - 1)
                sb.AppendLine();
        }

        return sb.ToString().TrimEnd();
    }

    /// <summary>
    /// Returns the episode serialised as structured JSON suitable for downstream
    /// tooling and TTS pipeline automation.
    /// Hidden-truth fields are omitted unless options.IncludeHiddenTruth is true.
    /// </summary>
    public string ExportEpisodeAsJson(
        PodcastProject  project,
        EpisodeRecord   episode,
        JsonExportOptions options)
    {
        var exported = new ExportedEpisode
        {
            EpisodeId         = episode.Id,
            EpisodeName       = episode.Name,
            InUniverseDate    = episode.InUniverseUtc?.ToString("yyyy-MM-dd HH:mm UTC"),
            IsCanonicalLocked = episode.IsCanonicalLocked,
            ExportedAtUtc     = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss UTC"),
            EntryCount        = episode.Entries.Count,
            Entries           = episode.Entries
                                    .OrderBy(e => e.SortOrder)
                                    .Select(e => BuildExportedEntry(project, e, options))
                                    .ToList()
        };

        return JsonSerializer.Serialize(exported, JsonWriteOptions);
    }

    // ── Private helpers ───────────────────────────────────────────────────────

    private ExportedEpisodeEntry BuildExportedEntry(
        PodcastProject    project,
        EpisodeEntryRecord entry,
        JsonExportOptions  options)
    {
        // Local name resolver — avoids pulling in ProjectLookupService as a dependency.
        string? Resolve<T>(IEnumerable<T> col, string? id) where T : EntityBase
            => string.IsNullOrEmpty(id) ? null : col.FirstOrDefault(x => x.Id == id)?.Name;

        string? beatName = null;
        if (!string.IsNullOrEmpty(entry.AppliedStoryBeatId))
        {
            beatName = project.StoryThreads
                .SelectMany(t => t.Beats)
                .FirstOrDefault(b => b.Id == entry.AppliedStoryBeatId)
                ?.Name;
        }

        return new ExportedEpisodeEntry
        {
            EntryId              = entry.Id,
            SortOrder            = entry.SortOrder,
            EntryKind            = entry.EntryKind.ToString(),
            SourceType           = entry.SourceType.ToString(),
            IsCanon              = entry.IsCanon,
            IsLocked             = entry.IsLocked,

            RenderedPublicText   = options.IncludeRenderedText
                                    ? _renderer.RenderEntry(project, entry)
                                    : null,

            Vessel               = Resolve(project.Vessels,              entry.VesselId),
            Station              = Resolve(project.Stations,             entry.StationId),
            Dock                 = Resolve(project.Docks,                entry.DockId),
            OriginStation        = Resolve(project.Stations,             entry.OriginStationId),
            DestinationStation   = Resolve(project.Stations,             entry.DestinationStationId),
            OperationType        = Resolve(project.OperationTypes,       entry.OperationTypeId),
            DeclaredPurpose      = Resolve(project.Purposes,             entry.DeclaredPurposeId),
            ManifestStatus       = Resolve(project.ManifestStatuses,     entry.ManifestStatusId),
            InspectionStatus     = Resolve(project.InspectionStatuses,   entry.InspectionStatusId),
            ClearanceStatus      = Resolve(project.ClearanceStatuses,    entry.ClearanceStatusId),
            EnvironmentalCondition = Resolve(project.EnvironmentalConditions, entry.EnvironmentalConditionId),
            StoryThread          = Resolve(project.StoryThreads,         entry.StoryThreadId),
            AppliedBeat          = beatName,
            AnomalySeverity      = entry.AnomalySeverity?.ToString(),

            // Hidden truth — only when explicitly enabled
            HiddenTruthNotes     = options.IncludeHiddenTruth ? entry.HiddenTruthNotes          : null,
            ActualPurpose        = options.IncludeHiddenTruth
                                    ? Resolve(project.Purposes, entry.ActualPurposeId)
                                    : null,

            // Generation metadata — only when explicitly enabled
            RandomSeed           = options.IncludeGenerationMetadata ? entry.RandomSeed : null
        };
    }

    /// <summary>
    /// Post-processes a single rendered entry string for TTS use:
    ///   1. Strips visual separator lines (===, ---) when StripVisualSeparators is true.
    ///   2. Removes broadcast pause markers (.-- and --) from line ends.
    ///   3. Strips leading indentation.
    ///   4. Joins all lines into a single paragraph when OneEntryPerParagraph is true.
    /// </summary>
    private static string ProcessForTts(string rendered, TtsExportOptions options)
    {
        var lines  = rendered.Split('\n');
        var result = new List<string>(lines.Length);

        foreach (var rawLine in lines)
        {
            var line    = rawLine.TrimEnd();
            var trimmed = line.Trim();

            // Strip pure visual separator lines
            if (options.StripVisualSeparators)
            {
                if (trimmed.StartsWith("===") || trimmed == "---"
                    || (trimmed.Length > 0 && trimmed.All(c => c == '-' || c == '=')))
                    continue;
            }

            // Remove broadcast pause markers (.-- keeps the sentence-ending period; -- alone is stripped)
            if (line.EndsWith(".--"))
                line = line[..^2];          // remove "--", period remains
            else if (line.EndsWith("--"))
                line = line[..^2].TrimEnd();

            // Strip leading indentation (broadcast script uses 2-space indent)
            line = line.TrimStart();

            if (!string.IsNullOrEmpty(line))
                result.Add(line);
        }

        if (result.Count == 0)
            return string.Empty;

        if (options.OneEntryPerParagraph)
            return string.Join(" ", result);

        return string.Join(Environment.NewLine, result);
    }
}
