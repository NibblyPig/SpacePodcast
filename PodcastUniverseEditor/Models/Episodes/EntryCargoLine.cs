namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A single cargo line in an entry manifest.
/// IsDeclared / IsHiddenTruthOnly determine which layer this appears in.
/// A declared cargo line appears in spoken output; a hidden-truth-only line does not.
/// </summary>
public class EntryCargoLine
{
    /// <summary>References CommodityRecord.Id</summary>
    public string CommodityId { get; set; } = string.Empty;

    /// <summary>
    /// Optional override for the spoken commodity name. If null, the commodity's Name is used.
    /// Used when the declared manifest uses a vaguer term than the actual commodity.
    /// </summary>
    public string? SpokenCommodityNameOverride { get; set; }

    public decimal Quantity { get; set; } = 0;

    /// <summary>Optional override for the unit label used in rendered output.</summary>
    public string? UnitLabelOverride { get; set; }

    /// <summary>True if this line is part of the declared (public) manifest.</summary>
    public bool IsDeclared { get; set; } = true;

    /// <summary>True if this line exists only in the hidden truth and must not appear in rendered output.</summary>
    public bool IsHiddenTruthOnly { get; set; } = false;
}
