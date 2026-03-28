using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// Base for all user-editable vocabulary items. Each reference list entry has a short
/// code, an enabled flag, a sort order, and optional tag filters that constrain where it
/// may appear in generation.
/// </summary>
public abstract class ReferenceItemBase : AuditableEntityBase
{
    public string Code { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;
    public int SortOrder { get; set; } = 0;

    /// <summary>
    /// Tag values that must be present on a candidate entity for this item to be eligible.
    /// Empty list means no filter — item is universally eligible.
    /// </summary>
    public List<string> AllowedTagFilters { get; set; } = new();
}
