namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Stations &amp; Docks tab.
/// Hosts a horizontal SplitContainer: Stations grid + buttons (top), Docks grid + buttons (bottom).
/// Public properties expose the grids and buttons so MainForm can bind data and hook events
/// without this control needing any project or service references.
/// </summary>
public partial class ucStationsDocks : UserControl
{
    public ucStationsDocks()
    {
        InitializeComponent();
    }

    // ── Grids ─────────────────────────────────────────────────────────────────

    public DataGridView GridStations => gridStations;
    public DataGridView GridDocks    => gridDocks;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnStationsAdd    => btnStationsAdd;
    public Button BtnStationsDelete => btnStationsDelete;
    public Button BtnDocksAdd       => btnDocksAdd;
    public Button BtnDocksDelete    => btnDocksDelete;
}
