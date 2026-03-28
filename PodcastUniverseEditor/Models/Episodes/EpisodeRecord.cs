using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A single podcast episode. Holds an ordered list of entries.
/// When IsCanonicalLocked is set, all entries are marked IsCanon and
/// the episode is treated as immutable history by the generator and validator.
/// </summary>
public class EpisodeRecord : AuditableEntityBase
{
    /// <summary>References PodcastSeriesRecord.Id</summary>
    public string SeriesId { get; set; } = string.Empty;

    /// <summary>In-universe broadcast date/time.</summary>
    public DateTime? InUniverseUtc { get; set; }

    /// <summary>
    /// Override the broadcast station for this specific episode.
    /// If null, falls back to the series' BroadcastStationId.
    /// References StationRecord.Id.
    /// </summary>
    public string? BroadcastStationId { get; set; }

    /// <summary>All entries in this episode, in SortOrder sequence.</summary>
    public List<EpisodeEntryRecord> Entries { get; set; } = new();

    /// <summary>
    /// When true, this episode is locked canon. No entries may be regenerated
    /// and the generator will not contradict any of them.
    /// </summary>
    public bool IsCanonicalLocked { get; set; } = false;
}
