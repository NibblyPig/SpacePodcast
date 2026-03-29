namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Validation tab.
/// Hosts a top button bar and a read-only validation messages grid with explicit columns.
/// Public properties expose key controls so MainForm can own behaviour without this control
/// needing any project or service references.
/// </summary>
public partial class ucValidation : UserControl
{
    public ucValidation()
    {
        InitializeComponent();
    }

    // ── Grid ──────────────────────────────────────────────────────────────────

    public DataGridView GridValidationMessages => gridValidationMessages;

    // ── Buttons ───────────────────────────────────────────────────────────────

    public Button BtnRunValidation => btnRunValidation;
}
