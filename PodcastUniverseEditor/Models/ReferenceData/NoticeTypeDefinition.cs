namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A category of broadcast notice (Operations Notice, Security Notice, etc.).
/// DefaultBodyFormat is a template for the body text when generating notices.
/// </summary>
public class NoticeTypeDefinition : ReferenceItemBase
{
    /// <summary>
    /// The header phrase spoken at the start of the notice. e.g. "Operations Notice.--"
    /// </summary>
    public string HeaderText { get; set; } = string.Empty;

    /// <summary>
    /// Optional default body phrase template for generated notices.
    /// May contain {Detail} token for insertion.
    /// </summary>
    public string DefaultBodyFormat { get; set; } = string.Empty;
}
