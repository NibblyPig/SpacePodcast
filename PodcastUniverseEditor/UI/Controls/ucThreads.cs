namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Threads tab.
/// Hosts a horizontal SplitContainer: Story Threads grid (top), Beats grid (bottom).
/// Public properties expose the grids so MainForm can bind data and hook events
/// without this control needing any project or service references.
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
}
