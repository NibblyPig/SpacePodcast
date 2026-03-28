namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// An environmental condition that may be noted at the end of a traffic entry.
/// e.g. "Solar flare activity remains low.--"
/// Scope is freeform text describing where the condition applies (corridor, system, sector).
/// </summary>
public class EnvironmentalConditionDefinition : ReferenceItemBase
{
    /// <summary>
    /// The full spoken phrase. e.g. "Radiation levels elevated.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// Freeform scope description, e.g. "Outer belt", "Corridor 7", "System-wide".
    /// </summary>
    public string Scope { get; set; } = string.Empty;
}
