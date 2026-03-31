using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A company, authority, cooperative, or other organisation active in the universe.
/// </summary>
public class OrganisationRecord : AuditableEntityBase
{
    /// <summary>References OrganisationTypeDefinition.Id</summary>
    public string OrganisationTypeId { get; set; } = string.Empty;
}
