namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Systems &amp; Bodies tab.
/// Hosts a horizontal SplitContainer: Star Systems grid (top), Celestial Bodies grid (bottom).
/// Public properties expose the grids so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucSystemsBodies : UserControl
{
    public ucSystemsBodies()
    {
        InitializeComponent();
    }

    // ── Grids ─────────────────────────────────────────────────────────────────

    public DataGridView GridStarSystems     => gridStarSystems;
    public DataGridView GridCelestialBodies => gridCelestialBodies;
}
