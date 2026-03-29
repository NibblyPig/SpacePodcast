namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Reference Data tab.
/// Hosts a vertical SplitContainer: reference type list (left), items grid + buttons (right).
/// Public properties expose the key controls so MainForm can bind data and hook events
/// without this control needing any project or service references.
/// </summary>
public partial class ucReferenceData : UserControl
{
    public ucReferenceData()
    {
        InitializeComponent();
    }

    // ── Selectors ─────────────────────────────────────────────────────────────

    public ListBox ListReferenceTypes => lstReferenceTypes;

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridReferenceItems => gridReferenceItems;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnAdd    => btnReferenceAdd;
    public Button BtnDelete => btnReferenceDelete;
}
