using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.Validation;

/// <summary>
/// A single validation finding. EntityType and EntityId allow the UI to
/// navigate directly to the offending record.
/// </summary>
public class ValidationMessage
{
    public ValidationSeverity Severity { get; set; } = ValidationSeverity.Info;
    public string Message { get; set; } = string.Empty;

    /// <summary>Short string identifying the record type, e.g. "EpisodeEntryRecord", "VesselRecord".</summary>
    public string EntityType { get; set; } = string.Empty;

    /// <summary>The string Id of the offending entity (matches EntityBase.Id).</summary>
    public string EntityId { get; set; } = string.Empty;

    /// <summary>The property name that failed validation, if applicable.</summary>
    public string FieldName { get; set; } = string.Empty;
}
