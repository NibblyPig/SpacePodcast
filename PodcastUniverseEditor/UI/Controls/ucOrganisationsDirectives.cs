namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Organisations &amp; Directives tab.
/// Hosts a horizontal SplitContainer: Organisations grid (top), Directives grid (bottom).
/// Public properties expose the grids so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucOrganisationsDirectives : UserControl
{
    public ucOrganisationsDirectives()
    {
        InitializeComponent();
    }

    // ── Grids ─────────────────────────────────────────────────────────────────

    public DataGridView GridOrganisations => gridOrganisations;
    public DataGridView GridDirectives    => gridDirectives;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnOrganisationsAdd    => btnOrganisationsAdd;
    public Button BtnOrganisationsDelete => btnOrganisationsDelete;
    public Button BtnDirectivesAdd       => btnDirectivesAdd;
    public Button BtnDirectivesDelete    => btnDirectivesDelete;
}
