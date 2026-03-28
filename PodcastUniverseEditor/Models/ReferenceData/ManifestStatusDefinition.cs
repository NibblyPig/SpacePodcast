namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A manifest verification status spoken during an entry.
/// ImpliesIrregularity flags statuses that should be treated as subtle anomalies.
/// </summary>
public class ManifestStatusDefinition : ReferenceItemBase
{
    /// <summary>
    /// The full spoken phrase including trailing punctuation. e.g. "Manifest verified.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// True if this status implies something is not quite right. Used by validation
    /// and thread progression to assess entry anomaly level.
    /// </summary>
    public bool ImpliesIrregularity { get; set; } = false;
}
