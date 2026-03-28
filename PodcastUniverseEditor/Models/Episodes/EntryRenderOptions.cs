namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// Per-entry flags that control which optional blocks appear in rendered output.
/// Allows individual entries to suppress sections without deleting the underlying data.
/// </summary>
public class EntryRenderOptions
{
    public bool IncludePurpose { get; set; } = true;
    public bool IncludeCargo { get; set; } = true;
    public bool IncludePassengers { get; set; } = true;
    public bool IncludeManifestStatus { get; set; } = true;
    public bool IncludeInspectionStatus { get; set; } = true;
    public bool IncludeEnvironmentalStatus { get; set; } = true;
    public bool IncludeResolution { get; set; } = true;
}
