namespace PodcastUniverseEditor.Services.Export;

/// <summary>
/// Controls how an episode is formatted for TTS (text-to-speech) export.
/// TTS exports strip broadcast-specific visual markers and produce clean prose
/// suitable for copy-paste into external voice tools.
/// No hidden-truth fields are ever included — this export is always public-layer only.
/// </summary>
public sealed class TtsExportOptions
{
    /// <summary>Prepend the episode name (and in-universe date if set) before the entries.</summary>
    public bool IncludeEpisodeHeader { get; init; } = true;

    /// <summary>Insert a blank line between each entry block.</summary>
    public bool BlankLineBetweenEntries { get; init; } = true;

    /// <summary>
    /// Remove pure visual separator lines such as "===" headers and "---" dividers
    /// that appear in the broadcast script but have no spoken value.
    /// </summary>
    public bool StripVisualSeparators { get; init; } = true;

    /// <summary>
    /// Join all lines of a single entry into one prose paragraph.
    /// Recommended for TTS pipelines that expect a single block of text per cue.
    /// </summary>
    public bool OneEntryPerParagraph { get; init; } = true;

    /// <summary>Prefix each entry paragraph with a numeric marker such as "[Entry 1]".</summary>
    public bool IncludeEntryMarkers { get; init; } = false;

    /// <summary>
    /// Placeholder — reserved for future phonetic hint injection.
    /// Has no effect in this version.
    /// </summary>
    public bool IncludePronunciationHints { get; init; } = false;

    /// <summary>
    /// Expand common broadcast abbreviations to full spoken forms where possible.
    /// Placeholder — reserved for future expansion logic.
    /// Has no effect in this version.
    /// </summary>
    public bool ExpandAbbreviationsWherePossible { get; init; } = false;

    /// <summary>Sensible defaults for most TTS pipelines.</summary>
    public static readonly TtsExportOptions Default = new();
}
