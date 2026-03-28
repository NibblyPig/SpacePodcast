using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A defined route between two stations. FrequencyWeight and RiskWeight influence
/// how often it is chosen during generation and how likely it is to carry anomalies.
/// </summary>
public class RouteRecord : AuditableEntityBase
{
    /// <summary>References StationRecord.Id</summary>
    public string FromStationId { get; set; } = string.Empty;

    /// <summary>References StationRecord.Id</summary>
    public string ToStationId { get; set; } = string.Empty;

    /// <summary>
    /// Higher values make this route more likely to be chosen during generation.
    /// Default 1.0 — typical route. Increase for busy corridors.
    /// </summary>
    public double FrequencyWeight { get; set; } = 1.0;

    /// <summary>
    /// Higher values make anomaly injection more likely on this route.
    /// Default 1.0 — normal risk.
    /// </summary>
    public double RiskWeight { get; set; } = 1.0;

    /// <summary>References PhraseTemplate.Id for a standard route status phrase.</summary>
    public string? RouteConditionTemplateId { get; set; }

    /// <summary>Vessel class IDs permitted on this route.</summary>
    public List<string> AllowedVesselClassIds { get; set; } = new();

    /// <summary>Commodity IDs typically carried on this route.</summary>
    public List<string> TypicalCommodityIds { get; set; } = new();

    /// <summary>PurposeDefinition IDs typical for this route.</summary>
    public List<string> TypicalPurposeIds { get; set; } = new();
}
