namespace PodcastUniverseEditor.UI.Controls.Episodes;

/// <summary>
/// UserControl that hosts the scrollable episode/series metadata editing panel.
/// Layout is defined in the Designer file; this class only exposes the controls
/// needed by the parent editor.
/// </summary>
public partial class ucEpisodeMetaEditor : UserControl
{
    public ucEpisodeMetaEditor()
    {
        InitializeComponent();
    }

    // Episode fields
    public TextBox TxtEpisodeName => txtEpisodeName;
    public CheckBox ChkEpisodeHasInUniverseDate => chkEpisodeHasInUniverseDate;
    public DateTimePicker DtpEpisodeInUniverseUtc => dtpEpisodeInUniverseUtc;
    public ComboBox CboEpisodeBroadcastStation => cboEpisodeBroadcastStation;
    public ComboBox CboEpisodeSeries => cboEpisodeSeries;
    public CheckBox ChkEpisodeCanonicalLocked => chkEpisodeCanonicalLocked;
    public TextBox TxtEpisodeNotes => txtEpisodeNotes;

    // Series fields
    public TextBox TxtSeriesName => txtSeriesName;
    public ComboBox CboSeriesBroadcastStation => cboSeriesBroadcastStation;
    public TextBox TxtSeriesNotes => txtSeriesNotes;
}