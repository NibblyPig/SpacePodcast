namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Vessels tab.
/// Hosts a single full-tab DataGridView.
/// Public property exposes the grid so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucVessels : UserControl
{
    public ucVessels()
    {
        InitializeComponent();
    }

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridVessels => gridVessels;
}
