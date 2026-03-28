namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// The clearance outcome for a movement (Cleared for departure, Held for inspection, etc.).
/// </summary>
public class ClearanceStatusDefinition : ReferenceItemBase
{
    /// <summary>
    /// The full spoken phrase. e.g. "Cleared for departure.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// True if this status represents a final resolved state — no further
    /// action is expected in this entry.
    /// </summary>
    public bool IsTerminalState { get; set; } = true;
}
