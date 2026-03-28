namespace PodcastUniverseEditor.Models.Common;

/// <summary>
/// Extends EntityBase with creation and modification timestamps (UTC).
/// Most world and episode records use this base.
/// </summary>
public abstract class AuditableEntityBase : EntityBase
{
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;
}
