namespace PodcastUniverseEditor.Services.Export;

/// <summary>
/// Controls what is included in a structured JSON export of an episode.
/// By default all exports are public-layer only.
/// Hidden truth and generation metadata are opt-in and should only be
/// enabled for author/debug workflows — never for public-facing pipelines.
/// </summary>
public sealed class JsonExportOptions
{
    /// <summary>
    /// When true, include hidden-truth fields: HiddenTruthNotes and ActualPurpose.
    /// Default OFF — safe for public/downstream use.
    /// Enable only for author/debug exports.
    /// </summary>
    public bool IncludeHiddenTruth { get; init; } = false;

    /// <summary>Include the rendered public broadcast text for each entry.</summary>
    public bool IncludeRenderedText { get; init; } = true;

    /// <summary>
    /// When true, include generation metadata: RandomSeed.
    /// Useful for reproducing or auditing generated entries.
    /// Default OFF.
    /// </summary>
    public bool IncludeGenerationMetadata { get; init; } = false;

    /// <summary>Public-safe export: no hidden truth, rendered text included, no metadata.</summary>
    public static readonly JsonExportOptions Public = new();

    /// <summary>
    /// Author/debug export: includes hidden truth, rendered text, and generation metadata.
    /// Do not use this preset for downstream public pipelines.
    /// </summary>
    public static readonly JsonExportOptions AuthorDebug = new()
    {
        IncludeHiddenTruth        = true,
        IncludeRenderedText       = true,
        IncludeGenerationMetadata = true
    };
}
