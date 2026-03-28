namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A reusable spoken phrase snippet used in entry rendering.
/// Templates are grouped so the generator can select from the right pool
/// (incident phrases, resolution phrases, route status phrases, notice bodies).
/// </summary>
public class PhraseTemplate : ReferenceItemBase
{
    /// <summary>
    /// The spoken text. May contain simple tokens like {Station}, {Corridor} for
    /// substitution at render time.
    /// </summary>
    public string TemplateText { get; set; } = string.Empty;

    /// <summary>
    /// Logical group name for filtering in the generator and editor UI.
    /// e.g. "incident", "resolution", "route_status", "notice_body"
    /// </summary>
    public string TemplateGroup { get; set; } = string.Empty;
}
