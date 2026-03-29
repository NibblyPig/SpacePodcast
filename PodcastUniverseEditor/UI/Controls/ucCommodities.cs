namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Commodities tab.
/// Hosts a single full-tab DataGridView.
/// Public property exposes the grid so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucCommodities : UserControl
{
    public ucCommodities()
    {
        InitializeComponent();
    }

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridCommodities => gridCommodities;
}
