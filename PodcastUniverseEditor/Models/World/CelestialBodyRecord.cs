using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A planet, moon, asteroid belt, or other body within a star system.
/// Supports a simple parent hierarchy (e.g. moon of a planet).
/// </summary>
public class CelestialBodyRecord : AuditableEntityBase
{
    /// <summary>References StarSystemRecord.Id</summary>
    public string StarSystemId { get; set; } = string.Empty;

    /// <summary>
    /// Optional parent body. References CelestialBodyRecord.Id.
    /// Null if this body orbits the star directly.
    /// </summary>
    public string? ParentBodyId { get; set; }

    /// <summary>References BodyTypeDefinition.Id</summary>
    public string BodyTypeId { get; set; } = string.Empty;
}
