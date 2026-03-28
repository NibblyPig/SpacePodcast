using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A star system in the fiction. Acts as the top-level geographic grouping for bodies and stations.
/// </summary>
public class StarSystemRecord : AuditableEntityBase
{
    /// <summary>
    /// Broad region name, e.g. "Inner Reach", "Outer Belt". Optional flavour.
    /// </summary>
    public string RegionName { get; set; } = string.Empty;
}
