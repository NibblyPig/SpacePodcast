namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A functional type of station (Outpost, Orbital Station, Shipyard, Mining Platform, etc.).
/// </summary>
public class StationTypeDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}
