namespace PodcastUniverseEditor.UI.Controls.Episodes;

/// <summary>
/// UserControl that hosts the scrollable entry-detail editing panel.
/// Layout is defined in the Designer file; this class only exposes the controls
/// needed by the parent editor.
/// </summary>
public partial class ucEpisodeEntryDetail : UserControl
{
    public ucEpisodeEntryDetail()
    {
        InitializeComponent();
    }

    public FlowLayoutPanel FlpValidationHints => flpValidationHints;

    // Entry: structural
    public ComboBox CboEntryKind => cboEntryKind;
    public ComboBox CboEntrySourceType => cboEntrySourceType;
    public TextBox TxtEntryName => txtEntryName;
    public NumericUpDown NumEntrySortOrder => numEntrySortOrder;
    public CheckBox ChkEntryLocked => chkEntryLocked;
    public CheckBox ChkEntryCanon => chkEntryCanon;
    public NumericUpDown NumEntryRandomSeed => numEntryRandomSeed;
    public TextBox TxtEntryNotes => txtEntryNotes;

    // Entry: operation / notice
    public ComboBox CboEntryOperationType => cboEntryOperationType;
    public ComboBox CboEntryNoticeType => cboEntryNoticeType;

    // Entry: location
    public ComboBox CboEntryStation => cboEntryStation;
    public ComboBox CboEntryDock => cboEntryDock;
    public ComboBox CboEntryOriginStation => cboEntryOriginStation;
    public ComboBox CboEntryDestinationStation => cboEntryDestinationStation;

    // Entry: vessel
    public ComboBox CboEntryVessel => cboEntryVessel;
    public ComboBox CboEntryVesselClassOverride => cboEntryVesselClassOverride;
    public TextBox TxtEntryRegistryOverride => txtEntryRegistryOverride;

    // Entry: purpose
    public ComboBox CboEntryDeclaredPurpose => cboEntryDeclaredPurpose;
    public ComboBox CboEntryActualPurpose => cboEntryActualPurpose;

    // Entry: statuses
    public ComboBox CboEntryManifestStatus => cboEntryManifestStatus;
    public ComboBox CboEntryInspectionStatus => cboEntryInspectionStatus;
    public ComboBox CboEntryClearanceStatus => cboEntryClearanceStatus;
    public ComboBox CboEntryEnvironmentalCondition => cboEntryEnvironmentalCondition;

    // Entry: narrative
    public ComboBox CboEntryDirective => cboEntryDirective;
    public ComboBox CboEntryIncidentPhrase => cboEntryIncidentPhrase;
    public ComboBox CboEntryResolutionPhrase => cboEntryResolutionPhrase;
    public ComboBox CboEntryRouteStatusPhrase => cboEntryRouteStatusPhrase;
    public TextBox TxtEntryPublicBodyOverride => txtEntryPublicBodyOverride;

    // Entry: story thread
    public ComboBox CboEntryStoryThread => cboEntryStoryThread;
    public ComboBox CboEntryAppliedStoryBeat => cboEntryAppliedStoryBeat;
    public ComboBox CboEntryAnomalySeverity => cboEntryAnomalySeverity;

    // Entry: hidden truth
    public TextBox TxtEntryHiddenTruthNotes => txtEntryHiddenTruthNotes;

    // Entry: schedule
    public CheckBox ChkEntryScheduledEnabled => chkEntryScheduledEnabled;
    public DateTimePicker DtpEntryScheduledUtc => dtpEntryScheduledUtc;

    // Manifest grids
    public DataGridView GridDeclaredCargo => gridDeclaredCargo;
    public DataGridView GridActualCargo => gridActualCargo;
    public DataGridView GridDeclaredPassengers => gridDeclaredPassengers;
    public DataGridView GridActualPassengers => gridActualPassengers;

    // Manifest buttons
    public Button BtnDeclaredCargoAdd => btnDeclaredCargoAdd;
    public Button BtnDeclaredCargoDelete => btnDeclaredCargoDelete;
    public Button BtnActualCargoAdd => btnActualCargoAdd;
    public Button BtnActualCargoDelete => btnActualCargoDelete;
    public Button BtnDeclaredPassengerAdd => btnDeclaredPassengerAdd;
    public Button BtnDeclaredPassengerDelete => btnDeclaredPassengerDelete;
    public Button BtnActualPassengerAdd => btnActualPassengerAdd;
    public Button BtnActualPassengerDelete => btnActualPassengerDelete;
}