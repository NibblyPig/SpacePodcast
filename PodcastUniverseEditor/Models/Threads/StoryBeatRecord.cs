using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.Threads;

/// <summary>
/// A single stage beat within a story thread. Describes what the entry should look
/// like at this point in the thread's progression — which statuses to apply, which
/// phrase templates to use, and the severity level.
/// </summary>
public class StoryBeatRecord : EntityBase
{
    /// <summary>
    /// Zero-based index. Beat 0 is the thread's starting state (often ordinary).
    /// Beats advance in order; the thread must not skip stages without manual override.
    /// </summary>
    public int StageIndex { get; set; } = 0;

    /// <summary>References ManifestStatusDefinition.Id — the public manifest status for this beat.</summary>
    public string? PublicManifestStatusId { get; set; }

    /// <summary>References InspectionStatusDefinition.Id</summary>
    public string? PublicInspectionStatusId { get; set; }

    /// <summary>References DirectiveDefinition.Id</summary>
    public string? PublicDirectiveId { get; set; }

    /// <summary>References PhraseTemplate.Id — incident phrase for this beat.</summary>
    public string? IncidentPhraseTemplateId { get; set; }

    /// <summary>References PhraseTemplate.Id — resolution phrase for this beat.</summary>
    public string? ResolutionPhraseTemplateId { get; set; }

    /// <summary>
    /// Private narrative summary of what is really happening at this stage.
    /// Never rendered in spoken output.
    /// </summary>
    public string HiddenTruthSummary { get; set; } = string.Empty;

    public SeverityLevel Severity { get; set; } = SeverityLevel.Minor;
}
