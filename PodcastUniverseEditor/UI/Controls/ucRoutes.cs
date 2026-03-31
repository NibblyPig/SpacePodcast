namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Routes tab.
/// Hosts a label, a full-tab DataGridView, and Add/Delete buttons below the grid.
/// Public properties expose the grid and buttons so MainForm can bind data and wire
/// events without this control needing any project or service references.
/// </summary>
public partial class ucRoutes : UserControl
{
    public ucRoutes()
    {
        InitializeComponent();
    }

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridRoutes => gridRoutes;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnRouteAdd    => btnRouteAdd;
    public Button BtnRouteDelete => btnRouteDelete;
}
