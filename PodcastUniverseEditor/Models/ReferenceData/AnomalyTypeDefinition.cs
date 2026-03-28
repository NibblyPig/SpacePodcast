using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A category of narrative anomaly that can be attached to a story thread
/// (Cargo Mismatch, Identity Irregularity, Scheduled Absence, etc.).
/// </summary>
public class AnomalyTypeDefinition : ReferenceItemBase
{
    /// <summary>
    /// The public-facing description of this anomaly type — intentionally vague.
    /// e.g. "Identification signal irregularity noted."
    /// </summary>
    public string PublicDescription { get; set; } = string.Empty;

    /// <summary>
    /// If true, the anomaly is meant to be barely noticeable in rendered output.
    /// </summary>
    public bool IsSubtleByDefault { get; set; } = true;

    /// <summary>
    /// IDs of OperationTypeDefinition entries where this anomaly type may appear.
    /// Empty means it can appear in any operation.
    /// </summary>
    public List<string> AllowedOperationTypeIds { get; set; } = new();

    /// <summary>
    /// Entity kinds this anomaly type applies to (Vessel, Route, Station, etc.).
    /// </summary>
    public List<ThreadEntityKind> AllowedEntityKinds { get; set; } = new();
}
