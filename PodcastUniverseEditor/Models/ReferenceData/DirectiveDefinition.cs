namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A named directive that can be cited to override or explain an irregular clearance.
/// e.g. "cleared under Directive 7" implies special authority was invoked.
/// </summary>
public class DirectiveDefinition : ReferenceItemBase
{
    /// <summary>
    /// The spoken phrase. e.g. "Cleared under Directive 7.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// The organisation that issued or owns this directive (optional).
    /// References OrganisationRecord.Id.
    /// </summary>
    public string? AuthorityOrganisationId { get; set; }
}
