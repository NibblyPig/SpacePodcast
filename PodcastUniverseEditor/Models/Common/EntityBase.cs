namespace PodcastUniverseEditor.Models.Common;

/// <summary>
/// Minimal base for all domain records. Provides a stable string ID, display name,
/// freeform notes, tag list, and extensible metadata dictionary.
/// IDs are string values — the seed factory uses short readable IDs; new records use GUIDs.
/// </summary>
public abstract class EntityBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();

    /// <summary>
    /// Arbitrary key/value pairs for future extensibility without schema changes.
    /// </summary>
    public Dictionary<string, string> Metadata { get; set; } = new();

    public bool IsArchived { get; set; } = false;
}
