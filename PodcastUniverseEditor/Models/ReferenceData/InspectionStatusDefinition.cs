namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// Describes the inspection outcome or state for a movement entry.
/// </summary>
public class InspectionStatusDefinition : ReferenceItemBase
{
    /// <summary>
    /// The full spoken phrase. e.g. "No inspection required.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// True if this status implies an inspection actually took place.
    /// </summary>
    public bool ImpliesInspection { get; set; } = false;

    /// <summary>
    /// True if this status implies concern or irregularity was found.
    /// </summary>
    public bool ImpliesConcern { get; set; } = false;
}
