using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A tradeable commodity in the universe (Liquid Oxygen, Structural Plating, etc.).
/// IsRestricted and IsContraband are distinct: restricted = regulated but legal;
/// contraband = illegal to declare openly.
/// </summary>
public class CommodityRecord : AuditableEntityBase
{
    /// <summary>References CommodityCategoryDefinition.Id</summary>
    public string CommodityCategoryId { get; set; } = string.Empty;

    /// <summary>Spoken unit for rendered output. e.g. "tons", "units", "canisters"</summary>
    public string UnitLabel { get; set; } = string.Empty;

    public int TypicalMinQuantity { get; set; } = 0;
    public int TypicalMaxQuantity { get; set; } = 1000;

    /// <summary>Regulated but declarable. Triggers validation if carried without a matching purpose.</summary>
    public bool IsRestricted { get; set; } = false;

    /// <summary>Cannot appear in declared cargo — only in actual/hidden cargo lines.</summary>
    public bool IsContraband { get; set; } = false;

    /// <summary>Station IDs where this commodity is produced.</summary>
    public List<string> ProducedAtStationIds { get; set; } = new();

    /// <summary>Station IDs where this commodity is consumed.</summary>
    public List<string> ConsumedAtStationIds { get; set; } = new();
}
