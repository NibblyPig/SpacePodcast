namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Vessels tab.
/// Hosts a label, a full-tab DataGridView, and Add/Delete buttons below the grid.
/// Public properties expose the grid and buttons so MainForm can bind data and wire
/// events without this control needing any project or service references.
/// </summary>
public partial class ucVessels : UserControl
{
    public ucVessels()
    {
        InitializeComponent();
    }

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridVessels => gridVessels;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnVesselAdd    => btnVesselAdd;
    public Button BtnVesselDelete => btnVesselDelete;
}
