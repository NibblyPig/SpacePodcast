namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Commodities tab.
/// Hosts a label, a full-tab DataGridView, and Add/Delete buttons below the grid.
/// Public properties expose the grid and buttons so MainForm can bind data and wire
/// events without this control needing any project or service references.
/// </summary>
public partial class ucCommodities : UserControl
{
    public ucCommodities()
    {
        InitializeComponent();
    }

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridCommodities => gridCommodities;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnCommodityAdd    => btnCommodityAdd;
    public Button BtnCommodityDelete => btnCommodityDelete;
}
