namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A single passenger category line in an entry manifest.
/// Mirrors the public/hidden split of EntryCargoLine.
/// </summary>
public class EntryPassengerLine
{
    /// <summary>References PassengerCategoryDefinition.Id</summary>
    public string PassengerCategoryId { get; set; } = string.Empty;

    public int Count { get; set; } = 0;

    /// <summary>True if this line appears in the declared (spoken) passenger manifest.</summary>
    public bool IsDeclared { get; set; } = true;

    /// <summary>True if this line exists only in the hidden truth.</summary>
    public bool IsHiddenTruthOnly { get; set; } = false;
}
