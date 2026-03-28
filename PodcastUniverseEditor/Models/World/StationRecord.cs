using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A space station — the primary setting for port traffic entries.
/// </summary>
public class StationRecord : AuditableEntityBase
{
    /// <summary>References StationTypeDefinition.Id</summary>
    public string StationTypeId { get; set; } = string.Empty;

    /// <summary>References StarSystemRecord.Id</summary>
    public string StarSystemId { get; set; } = string.Empty;

    /// <summary>References CelestialBodyRecord.Id — the body this station orbits or sits on.</summary>
    public string? CelestialBodyId { get; set; }

    /// <summary>References OrganisationRecord.Id</summary>
    public string? OperatorOrganisationId { get; set; }

    /// <summary>Commodity IDs this station typically imports. Used in generation weighting.</summary>
    public List<string> ImportCommodityIds { get; set; } = new();

    /// <summary>Commodity IDs this station typically exports.</summary>
    public List<string> ExportCommodityIds { get; set; } = new();

    /// <summary>PurposeDefinition IDs that make sense for traffic at this station.</summary>
    public List<string> PurposeIds { get; set; } = new();
}
