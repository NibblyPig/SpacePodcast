namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Output Preview tab.
/// Hosts a single full-tab read-only TextBox for rendered episode output.
/// Public property exposes the TextBox so MainForm can write rendered content
/// without this control needing any project or service references.
/// </summary>
public partial class ucOutputPreview : UserControl
{
    public ucOutputPreview()
    {
        InitializeComponent();
    }

    // ── Output text ───────────────────────────────────────────────────────────

    public TextBox TxtRenderedOutput => txtRenderedOutput;
}
