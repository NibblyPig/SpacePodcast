using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.Threads;

/// <summary>
/// A long-running narrative thread associated with a world entity (vessel, route, station, etc.).
/// The thread tracks the current stage of escalation and controls when it is eligible
/// to influence generation.
/// </summary>
public class StoryThreadRecord : AuditableEntityBase
{
    /// <summary>The kind of entity this thread targets.</summary>
    public ThreadEntityKind EntityKind { get; set; } = ThreadEntityKind.Vessel;

    /// <summary>
    /// The specific entity ID — references VesselRecord.Id, RouteRecord.Id, etc.
    /// depending on EntityKind.
    /// </summary>
    public string TargetEntityId { get; set; } = string.Empty;

    /// <summary>References AnomalyTypeDefinition.Id — the central anomaly theme of this thread.</summary>
    public string? ThemeAnomalyTypeId { get; set; }

    /// <summary>
    /// Index of the beat that has most recently been applied.
    /// Starts at -1 (no beat applied yet). Advances by 1 each time a beat is applied.
    /// </summary>
    public int CurrentStageIndex { get; set; } = -1;

    /// <summary>False to temporarily disable this thread from influencing generation.</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Minimum number of episodes that must elapse between applications of this thread.
    /// Prevents the anomaly from appearing in every episode.
    /// </summary>
    public int CooldownEpisodes { get; set; } = 2;

    /// <summary>
    /// Countdown of episodes remaining before this thread is eligible again.
    /// The generator decrements this each episode. When it reaches 0 the thread
    /// becomes eligible.
    /// </summary>
    public int EpisodesUntilEligible { get; set; } = 0;

    /// <summary>All beats defined for this thread, ordered by StageIndex.</summary>
    public List<StoryBeatRecord> Beats { get; set; } = new();
}
