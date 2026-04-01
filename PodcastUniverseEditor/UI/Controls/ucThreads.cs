namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Threads tab.
/// Hosts a horizontal SplitContainer: Story Threads grid (top), Beats grid (bottom).
/// Each section has Add/Delete buttons below the grid.
/// Public properties expose grids and buttons so MainForm can bind data and wire
/// events without this control needing any project or service references.
/// </summary>
public partial class ucThreads : UserControl
{
    public ucThreads()
    {
        InitializeComponent();
    }

    // ── Grids ─────────────────────────────────────────────────────────────────

    public DataGridView GridThreads     => gridThreads;
    public DataGridView GridThreadBeats => gridThreadBeats;

    // ── Thread buttons ────────────────────────────────────────────────────────

    public Button BtnThreadAdd    => btnThreadAdd;
    public Button BtnThreadDelete => btnThreadDelete;

    // ── Beat buttons ──────────────────────────────────────────────────────────

    public Button BtnBeatAdd    => btnBeatAdd;
    public Button BtnBeatDelete => btnBeatDelete;
}
