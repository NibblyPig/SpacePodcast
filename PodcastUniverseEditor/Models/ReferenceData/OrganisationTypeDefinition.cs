namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A type of organisation (Shipping Company, Authority, Cooperative, etc.).
/// </summary>
public class OrganisationTypeDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}
