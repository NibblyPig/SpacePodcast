namespace PodcastUniverseEditor.Utilities;

/// <summary>
/// Centralises new-record ID generation. NewId() returns a lowercase GUID string.
/// Seeded records in ProjectSeedFactory use short, readable fixed IDs instead.
/// Keeping generation here makes it easy to change the format for new records later.
/// </summary>
public static class IdHelper
{
    public static string NewId() => Guid.NewGuid().ToString("D").ToLowerInvariant();
}
