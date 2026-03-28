namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A declared operational purpose for a movement (Ore Transfer, Crew Rotation, etc.).
/// Drives generation weighting for cargo, vessel class, and route selection.
/// </summary>
public class PurposeDefinition : ReferenceItemBase
{
    /// <summary>
    /// The spoken phrase used in rendered output. e.g. "industrial resupply".
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// Specific commodity IDs commonly associated with this purpose.
    /// </summary>
    public List<string> TypicalCommodityIds { get; set; } = new();

    /// <summary>
    /// Commodity category IDs commonly associated with this purpose.
    /// </summary>
    public List<string> TypicalCommodityCategoryIds { get; set; } = new();

    /// <summary>
    /// Vessel class IDs suited to this purpose.
    /// </summary>
    public List<string> TypicalVesselClassIds { get; set; } = new();
}
