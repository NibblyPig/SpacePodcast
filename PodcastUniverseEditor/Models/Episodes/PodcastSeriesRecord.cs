using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A named podcast series. Groups episodes and associates them with a broadcast station.
/// </summary>
public class PodcastSeriesRecord : AuditableEntityBase
{
    /// <summary>References StationRecord.Id — the station this series broadcasts from.</summary>
    public string? BroadcastStationId { get; set; }

    /// <summary>Ordered list of EpisodeRecord.Id values in this series.</summary>
    public List<string> EpisodeIds { get; set; } = new();
}
