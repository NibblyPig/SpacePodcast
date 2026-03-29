namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Routes tab.
/// Hosts a single full-tab DataGridView.
/// Public property exposes the grid so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucRoutes : UserControl
{
    public ucRoutes()
    {
        InitializeComponent();
    }

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridRoutes => gridRoutes;
}
