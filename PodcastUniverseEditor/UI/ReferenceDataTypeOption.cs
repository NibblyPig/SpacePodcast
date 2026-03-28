namespace PodcastUniverseEditor.UI;

/// <summary>
/// Represents a single entry in the reference-data type selector list.
/// Key maps to the corresponding collection property name on PodcastProject
/// so the binding helper can locate the right list via a switch.
/// </summary>
public class ReferenceDataTypeOption
{
    public ReferenceDataTypeOption(string key, string displayName)
    {
        Key = key;
        DisplayName = displayName;
    }

    public string Key { get; set; }
    public string DisplayName { get; set; }

    public override string ToString() => DisplayName;
}
