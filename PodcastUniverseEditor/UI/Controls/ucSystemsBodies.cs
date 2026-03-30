namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Systems & Bodies tab.
/// Hosts a horizontal SplitContainer: Star Systems grid + buttons (top),
/// Celestial Bodies grid + buttons (bottom).
/// Public properties expose the grids and buttons so MainForm can bind data
/// and hook events without this control needing any project or service references.
/// </summary>
public partial class ucSystemsBodies : UserControl
{
    public ucSystemsBodies()
    {
        InitializeComponent();
    }

    // ── Grids ─────────────────────────────────────────────────────────────────

    public DataGridView GridStarSystems => gridStarSystems;
    public DataGridView GridCelestialBodies => gridCelestialBodies;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnSystemAdd => btnSystemAdd;
    public Button BtnSystemDelete => btnSystemDelete;
    public Button BtnBodyAdd => btnBodyAdd;
    public Button BtnBodyDelete => btnBodyDelete;
}