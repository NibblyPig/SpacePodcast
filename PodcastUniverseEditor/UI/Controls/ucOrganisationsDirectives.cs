namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Organisations tab.
/// Hosts a panel with the Organisations grid.
/// Public properties expose the grid so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucOrganisationsDirectives : UserControl
{
    public ucOrganisationsDirectives()
    {
        InitializeComponent();
    }

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridOrganisations => gridOrganisations;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnOrganisationsAdd    => btnOrganisationsAdd;
    public Button BtnOrganisationsDelete => btnOrganisationsDelete;
}
