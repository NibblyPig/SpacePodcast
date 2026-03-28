using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A named berth, bay, ring, or docking position at a station.
/// SpokenLabel is the short form for headers; SpokenIdentifier is the full spoken name.
/// </summary>
public class DockRecord : AuditableEntityBase
{
    /// <summary>References StationRecord.Id</summary>
    public string StationId { get; set; } = string.Empty;

    /// <summary>Short spoken form used in header. e.g. "Bay Fourteen"</summary>
    public string SpokenLabel { get; set; } = string.Empty;

    /// <summary>Full spoken identifier if different. e.g. "Docking Ring Fourteen, Sector B"</summary>
    public string SpokenIdentifier { get; set; } = string.Empty;

    /// <summary>Restricted docks should trigger a validation warning if used without a directive.</summary>
    public bool IsRestricted { get; set; } = false;

    /// <summary>Suspended docks should not receive active traffic. Validation will flag conflicts.</summary>
    public bool IsSuspended { get; set; } = false;
}
