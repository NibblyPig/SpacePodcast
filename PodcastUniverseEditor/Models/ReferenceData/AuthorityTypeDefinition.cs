namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A type of authority organisation (Port Authority, Customs, Military, etc.).
/// </summary>
public class AuthorityTypeDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}
