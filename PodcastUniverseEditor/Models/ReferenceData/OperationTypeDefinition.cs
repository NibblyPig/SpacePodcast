namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// Defines a kind of port operation (Arrival, Departure, Transfer, etc.).
/// HeaderFormat is a phrase template for the spoken header line, e.g. "Arrival at {Dock}.--"
/// </summary>
public class OperationTypeDefinition : ReferenceItemBase
{
    /// <summary>
    /// Spoken header phrase. Supports {Dock} and {Station} tokens.
    /// Example: "Departure from {Dock}.--"
    /// </summary>
    public string HeaderFormat { get; set; } = string.Empty;

    public bool RequiresOrigin { get; set; } = false;
    public bool RequiresDestination { get; set; } = false;

    /// <summary>
    /// True for port-movement operations; false for holding patterns or admin ops.
    /// </summary>
    public bool IsTrafficOperation { get; set; } = true;
}
