using PodcastUniverseEditor.Models;
using PodcastUniverseEditor.Models.Threads;

namespace PodcastUniverseEditor.Services.Generation;

/// <summary>
/// Decides which story thread (if any) should be applied to a generated entry,
/// and advances the thread's stage index when a beat is applied.
/// Stateless — all mutable state lives on the thread records in the project.
/// </summary>
public class StoryThreadProgressionService
{
    // ── Public API ────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns all threads that are currently eligible to be applied.
    /// Eligibility criteria:
    ///   • IsActive = true
    ///   • EpisodesUntilEligible = 0
    ///   • There is a next beat (CurrentStageIndex + 1 &lt; Beats.Count)
    /// Beats are matched by StageIndex, not list position.
    /// </summary>
    public IReadOnlyList<StoryThreadRecord> EligibleThreads(PodcastProject project)
    {
        return project.StoryThreads
            .Where(t => IsEligible(t))
            .ToList();
    }

    /// <summary>
    /// Returns the next beat for the given thread (the beat whose StageIndex = CurrentStageIndex + 1),
    /// or null if no such beat exists or the thread is not eligible.
    /// Does NOT advance the thread.
    /// </summary>
    public StoryBeatRecord? PeekNextBeat(StoryThreadRecord thread)
    {
        int nextStage = thread.CurrentStageIndex + 1;
        return thread.Beats.FirstOrDefault(b => b.StageIndex == nextStage);
    }

    /// <summary>
    /// Advances the thread's CurrentStageIndex to the applied beat's StageIndex
    /// and resets EpisodesUntilEligible to CooldownEpisodes.
    /// Call this after applying the beat to an entry.
    /// </summary>
    public void AdvanceThread(StoryThreadRecord thread, StoryBeatRecord beat)
    {
        thread.CurrentStageIndex = beat.StageIndex;
        thread.EpisodesUntilEligible = thread.CooldownEpisodes;
    }

    /// <summary>
    /// Decrements EpisodesUntilEligible for all threads by 1 (minimum 0).
    /// Call this once per episode generation cycle, after all entries for the episode
    /// have been produced, so cooldowns tick down correctly.
    /// </summary>
    public void TickCooldowns(PodcastProject project)
    {
        foreach (var thread in project.StoryThreads)
        {
            if (thread.EpisodesUntilEligible > 0)
                thread.EpisodesUntilEligible--;
        }
    }

    /// <summary>
    /// Returns the target entity ID for the thread, used by the generator to bias
    /// vessel/route selection toward the thread's target entity.
    /// </summary>
    public string? TargetEntityId(StoryThreadRecord thread) =>
        string.IsNullOrEmpty(thread.TargetEntityId) ? null : thread.TargetEntityId;

    // ── Private helpers ───────────────────────────────────────────────────────

    private static bool IsEligible(StoryThreadRecord thread)
    {
        if (!thread.IsActive) return false;
        if (thread.EpisodesUntilEligible > 0) return false;
        int nextStage = thread.CurrentStageIndex + 1;
        return thread.Beats.Any(b => b.StageIndex == nextStage);
    }
}
