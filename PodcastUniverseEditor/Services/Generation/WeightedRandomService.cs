namespace PodcastUniverseEditor.Services.Generation;

/// <summary>
/// Selects items from weighted collections using a caller-supplied Random instance.
/// All methods are deterministic given the same Random state.
/// </summary>
public class WeightedRandomService
{
    // ── Public API ────────────────────────────────────────────────────────────

    /// <summary>
    /// Selects one item from a weighted list.
    /// Each item is a (value, weight) pair; weight must be > 0.
    /// Returns the default of T if the list is empty.
    /// </summary>
    public T? Choose<T>(IReadOnlyList<(T item, double weight)> candidates, Random rng)
    {
        if (candidates.Count == 0) return default;

        double total = 0;
        foreach (var (_, w) in candidates)
            total += w;

        double roll = rng.NextDouble() * total;
        double cumulative = 0;

        foreach (var (item, weight) in candidates)
        {
            cumulative += weight;
            if (roll < cumulative)
                return item;
        }

        // Floating-point edge: return last
        return candidates[^1].item;
    }

    /// <summary>
    /// Selects one item from an unweighted list with uniform probability.
    /// Returns the default of T if the list is empty.
    /// </summary>
    public T? ChooseUniform<T>(IReadOnlyList<T> candidates, Random rng)
    {
        if (candidates.Count == 0) return default;
        return candidates[rng.Next(candidates.Count)];
    }

    /// <summary>
    /// Returns true with the given probability (0.0–1.0).
    /// </summary>
    public bool Chance(double probability, Random rng) => rng.NextDouble() < probability;

    /// <summary>
    /// Creates a Random seeded with the provided value, or uses a random seed if null.
    /// </summary>
    public static Random CreateRandom(int? seed) =>
        seed.HasValue ? new Random(seed.Value) : new Random();
}
