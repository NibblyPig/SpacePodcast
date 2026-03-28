namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A type of celestial body (Planet, Moon, Asteroid Belt, Orbital Body, etc.).
/// Stored as editable data so the user can extend the hierarchy without code changes.
/// </summary>
public class BodyTypeDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}
