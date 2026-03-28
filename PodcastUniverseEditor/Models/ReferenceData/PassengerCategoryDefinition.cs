namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A category of passenger manifest entry (civilian, crew rotation, diplomatic liaison, etc.).
/// </summary>
public class PassengerCategoryDefinition : ReferenceItemBase
{
    /// <summary>
    /// The spoken label used in rendered output. e.g. "civilian passengers".
    /// </summary>
    public string SpokenLabel { get; set; } = string.Empty;
}
