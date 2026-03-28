namespace PodcastUniverseEditor.Services.Export;

/// <summary>
/// Structured representation of an exported episode, designed for downstream tooling.
/// All fields are resolved to human-readable names at export time.
/// Hidden-truth fields are only populated when JsonExportOptions.IncludeHiddenTruth is true.
/// </summary>
public sealed class ExportedEpisode
{
    public string   EpisodeId         { get; init; } = string.Empty;
    public string   EpisodeName       { get; init; } = string.Empty;
    public string?  InUniverseDate    { get; init; }
    public bool     IsCanonicalLocked { get; init; }
    public string   ExportedAtUtc     { get; init; } = string.Empty;
    public int      EntryCount        { get; init; }
    public List<ExportedEpisodeEntry> Entries { get; init; } = new();
}

/// <summary>
/// Structured representation of a single exported episode entry.
/// Reference data IDs are resolved to display names at export time.
/// </summary>
public sealed class ExportedEpisodeEntry
{
    // ── Identity ──────────────────────────────────────────────────────────────

    public string EntryId    { get; init; } = string.Empty;
    public int    SortOrder  { get; init; }
    public string EntryKind  { get; init; } = string.Empty;
    public string SourceType { get; init; } = string.Empty;
    public bool   IsCanon    { get; init; }
    public bool   IsLocked   { get; init; }

    // ── Rendered output ───────────────────────────────────────────────────────

    /// <summary>Rendered public broadcast text for this entry. Null if IncludeRenderedText is false.</summary>
    public string? RenderedPublicText { get; init; }

    // ── Public structured fields (resolved to names) ──────────────────────────

    public string? Vessel                { get; init; }
    public string? Station               { get; init; }
    public string? Dock                  { get; init; }
    public string? OriginStation         { get; init; }
    public string? DestinationStation    { get; init; }
    public string? OperationType         { get; init; }
    public string? DeclaredPurpose       { get; init; }
    public string? ManifestStatus        { get; init; }
    public string? InspectionStatus      { get; init; }
    public string? ClearanceStatus       { get; init; }
    public string? EnvironmentalCondition{ get; init; }
    public string? StoryThread           { get; init; }
    public string? AppliedBeat           { get; init; }
    public string? AnomalySeverity       { get; init; }

    // ── Hidden truth (null unless JsonExportOptions.IncludeHiddenTruth = true) ─

    public string? HiddenTruthNotes { get; init; }
    public string? ActualPurpose    { get; init; }

    // ── Generation metadata (null unless JsonExportOptions.IncludeGenerationMetadata = true) ─

    public int? RandomSeed { get; init; }
}
