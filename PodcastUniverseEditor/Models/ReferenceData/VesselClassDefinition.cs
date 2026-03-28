namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// Describes a class of vessel (Bulk Carrier, Courier, Tanker, etc.) and its
/// typical operational profile for generation and validation purposes.
/// </summary>
public class VesselClassDefinition : ReferenceItemBase
{
    /// <summary>
    /// The spoken noun used in rendered output. e.g. "bulk carrier", "courier vessel".
    /// </summary>
    public string SpokenNoun { get; set; } = string.Empty;

    public bool CanCarryCargo { get; set; } = true;
    public bool CanCarryPassengers { get; set; } = false;

    /// <summary>
    /// IDs of CommodityCategoryDefinition entries typically associated with this class.
    /// Used to weight generation and flag implausible cargo.
    /// </summary>
    public List<string> TypicalCommodityCategoryIds { get; set; } = new();

    public int TypicalPassengerMin { get; set; } = 0;
    public int TypicalPassengerMax { get; set; } = 0;
}
