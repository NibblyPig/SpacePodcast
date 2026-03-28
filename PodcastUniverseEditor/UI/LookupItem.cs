namespace PodcastUniverseEditor.UI;

/// <summary>
/// Thin wrapper used as DataSource for ComboBoxes.
/// Id is a string — empty string represents "no selection" (maps to null on the model).
/// Display is the human-readable label shown in the drop-down.
/// </summary>
public sealed class LookupItem
{
    public LookupItem(string id, string display)
    {
        Id      = id;
        Display = display;
    }

    public string Id      { get; }
    public string Display { get; }

    /// <summary>Sentinel item placed at index 0 to represent "no selection".</summary>
    public static LookupItem None => new(string.Empty, "(none)");

    public override string ToString() => Display;
}
