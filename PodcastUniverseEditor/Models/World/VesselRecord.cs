using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A named vessel in the universe. IsRecurringNarrativeAsset marks vessels that
/// should appear regularly and may carry story threads.
/// </summary>
public class VesselRecord : AuditableEntityBase
{
    /// <summary>Official registry code. e.g. "XF-7742". Must be unique within the project.</summary>
    public string Registry { get; set; } = string.Empty;

    /// <summary>References VesselClassDefinition.Id</summary>
    public string VesselClassId { get; set; } = string.Empty;

    /// <summary>References OrganisationRecord.Id</summary>
    public string? OperatorOrganisationId { get; set; }

    /// <summary>References StationRecord.Id — the vessel's registered home port.</summary>
    public string? HomeStationId { get; set; }

    /// <summary>
    /// True for vessels intended to recur in the narrative with consistent identity.
    /// The generator will favour these on routes where they are plausible.
    /// </summary>
    public bool IsRecurringNarrativeAsset { get; set; } = false;

    /// <summary>RouteRecord IDs this vessel is preferred on.</summary>
    public List<string> PreferredRouteIds { get; set; } = new();

    /// <summary>StoryThreadRecord IDs associated with this vessel.</summary>
    public List<string> AssociatedThreadIds { get; set; } = new();
}
