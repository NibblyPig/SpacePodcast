namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A broad category of commodity (industrial, agricultural, fuel, restricted, etc.).
/// Used to group commodities for generation weighting and vessel class matching.
/// </summary>
public class CommodityCategoryDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}
