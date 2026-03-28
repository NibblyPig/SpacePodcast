using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.Validation;

/// <summary>
/// Aggregates all validation findings from a single validation run.
/// </summary>
public class ValidationResult
{
    public List<ValidationMessage> Messages { get; set; } = new();

    public bool HasErrors => Messages.Any(m => m.Severity == ValidationSeverity.Error);
    public bool HasWarnings => Messages.Any(m => m.Severity == ValidationSeverity.Warning);
}
