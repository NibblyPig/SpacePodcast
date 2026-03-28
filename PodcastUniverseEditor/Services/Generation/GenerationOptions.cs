namespace PodcastUniverseEditor.Services.Generation;

/// <summary>
/// Determines whether a generation call may mutate story thread state.
/// Every public entry point in EpisodeGenerationService must explicitly choose a mode —
/// there is no implicit behaviour based on call path.
/// </summary>
/// <remarks>
/// <b>Simulation mode</b> (AdvanceStory = true): used by FillEpisode only.
/// Advances CurrentStageIndex and resets EpisodesUntilEligible on threads.
/// Represents real narrative progression — call once per episode, not per entry.
///
/// <b>Editing mode</b> (AdvanceStory = false): used by GenerateEntry, GenerateEntries,
/// and single-entry regeneration. Peeks at threads without mutating them.
/// Safe to call any number of times without changing story state.
/// Repeating the same call produces the same result.
/// </remarks>
public readonly struct GenerationOptions
{
    /// <summary>
    /// When true, beating a thread advances its CurrentStageIndex and resets its cooldown.
    /// When false, threads are peeked for preview only — no story state is modified.
    /// </summary>
    public bool AdvanceStory { get; init; }

    /// <summary>Non-mutating editing mode. Threads are peeked but never advanced.</summary>
    public static readonly GenerationOptions Editing    = new() { AdvanceStory = false };

    /// <summary>Authoritative simulation mode. Applied beats advance the thread.</summary>
    public static readonly GenerationOptions Simulation = new() { AdvanceStory = true };
}
