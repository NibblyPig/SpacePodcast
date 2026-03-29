namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Episodes tab.
/// Hosts the full episodes/series/entry editing UI.
/// Public properties expose all controls referenced by MainForm so that
/// MainForm can own all behaviour without this control needing any project
/// or service references.
/// </summary>
public partial class ucEpisodes : UserControl
{
    public ucEpisodes()
    {
        InitializeComponent();
    }

    // ── Lists ──────────────────────────────────────────────────────────────────
    public ListBox LstSeries   => lstSeries;
    public ListBox LstEpisodes => lstEpisodes;

    // ── Series buttons ────────────────────────────────────────────────────────
    public Button BtnSeriesAdd       => btnSeriesAdd;
    public Button BtnSeriesDelete    => btnSeriesDelete;
    public Button BtnSeriesDuplicate => btnSeriesDuplicate;

    // ── Episode search / summary ──────────────────────────────────────────────
    public TextBox TxtEpisodeSearch  => txtEpisodeSearch;
    public TextBox TxtEpisodeSummary => txtEpisodeSummary;

    // ── Episode buttons ───────────────────────────────────────────────────────
    public Button BtnEpisodeAdd              => btnEpisodeAdd;
    public Button BtnEpisodeDelete           => btnEpisodeDelete;
    public Button BtnEpisodeDuplicate        => btnEpisodeDuplicate;
    public Button BtnNewEpisodeAfterSelected => btnNewEpisodeAfterSelected;
    public Button BtnLockEpisodeCanon        => btnLockEpisodeCanon;
    public Button BtnUnlockEpisodeCanon      => btnUnlockEpisodeCanon;
    public Button BtnEpisodeMoveUp           => btnEpisodeMoveUp;
    public Button BtnEpisodeMoveDown         => btnEpisodeMoveDown;

    // ── Entry grid ────────────────────────────────────────────────────────────
    public DataGridView GridEpisodeEntries => gridEpisodeEntries;

    // ── Entry filter controls ─────────────────────────────────────────────────
    public TextBox  TxtEntrySearch        => txtEntrySearch;
    public ComboBox CboEntryFilterKind    => cboEntryFilterKind;
    public ComboBox CboEntryFilterVessel  => cboEntryFilterVessel;
    public ComboBox CboEntryFilterStation => cboEntryFilterStation;
    public CheckBox ChkShowLockedOnly     => chkShowLockedOnly;
    public Button   BtnClearEntryFilters  => btnClearEntryFilters;

    // ── Entry management buttons ──────────────────────────────────────────────
    public Button BtnEntryAdd       => btnEntryAdd;
    public Button BtnNoticeEntryAdd => btnNoticeEntryAdd;
    public Button BtnEntryDuplicate => btnEntryDuplicate;
    public Button BtnEntryDelete    => btnEntryDelete;
    public Button BtnEntryMoveUp    => btnEntryMoveUp;
    public Button BtnEntryMoveDown  => btnEntryMoveDown;

    // ── Generation controls ───────────────────────────────────────────────────
    public Button         BtnGenerateEntry                    => btnGenerateEntry;
    public Button         BtnGenerateEpisodeEntries           => btnGenerateEpisodeEntries;
    public Button         BtnRegenerateSelectedEntry          => btnRegenerateSelectedEntry;
    public NumericUpDown  NumGenerateEntryCount               => numGenerateEntryCount;
    public CheckBox       ChkClearEpisodeBeforeGenerate       => chkClearEpisodeBeforeGenerate;
    public CheckBox       ChkRegenerateWithoutAdvancingThread => chkRegenerateWithoutAdvancingThread;
    public TextBox        TxtGenerationSeed                   => txtGenerationSeed;

    // ── Export controls ───────────────────────────────────────────────────────
    public Button   BtnExportEpisodeText             => btnExportEpisodeText;
    public Button   BtnExportEpisodeTts              => btnExportEpisodeTts;
    public Button   BtnExportEpisodeJson             => btnExportEpisodeJson;
    public CheckBox ChkExportIncludeHeader           => chkExportIncludeHeader;
    public CheckBox ChkExportBlankLineBetweenEntries => chkExportBlankLineBetweenEntries;
    public CheckBox ChkExportIncludeEntryMarkers     => chkExportIncludeEntryMarkers;
    public CheckBox ChkExportAuthorDebugMode         => chkExportAuthorDebugMode;

    // ── Preview / thread summary ──────────────────────────────────────────────
    public TextBox TxtEpisodeEntryPreview => txtEpisodeEntryPreview;
    public TextBox TxtThreadSummary       => txtThreadSummary;

    // ── Entry detail panel ────────────────────────────────────────────────────
    public Panel           PnlEntryDetail     => pnlEntryDetail;
    public FlowLayoutPanel FlpValidationHints => flpValidationHints;

    // ── Entry fields: structural ──────────────────────────────────────────────
    public ComboBox      CboEntryKind       => cboEntryKind;
    public ComboBox      CboEntrySourceType => cboEntrySourceType;
    public TextBox       TxtEntryName       => txtEntryName;
    public NumericUpDown NumEntrySortOrder  => numEntrySortOrder;
    public CheckBox      ChkEntryLocked     => chkEntryLocked;
    public CheckBox      ChkEntryCanon      => chkEntryCanon;
    public NumericUpDown NumEntryRandomSeed => numEntryRandomSeed;
    public TextBox       TxtEntryNotes      => txtEntryNotes;

    // ── Entry fields: operation / notice ─────────────────────────────────────
    public ComboBox CboEntryOperationType => cboEntryOperationType;
    public ComboBox CboEntryNoticeType    => cboEntryNoticeType;

    // ── Entry fields: location ────────────────────────────────────────────────
    public ComboBox CboEntryStation            => cboEntryStation;
    public ComboBox CboEntryDock               => cboEntryDock;
    public ComboBox CboEntryOriginStation      => cboEntryOriginStation;
    public ComboBox CboEntryDestinationStation => cboEntryDestinationStation;

    // ── Entry fields: vessel ──────────────────────────────────────────────────
    public ComboBox CboEntryVessel              => cboEntryVessel;
    public ComboBox CboEntryVesselClassOverride => cboEntryVesselClassOverride;
    public TextBox  TxtEntryRegistryOverride    => txtEntryRegistryOverride;

    // ── Entry fields: purpose ─────────────────────────────────────────────────
    public ComboBox CboEntryDeclaredPurpose => cboEntryDeclaredPurpose;
    public ComboBox CboEntryActualPurpose   => cboEntryActualPurpose;

    // ── Entry fields: statuses ────────────────────────────────────────────────
    public ComboBox CboEntryManifestStatus         => cboEntryManifestStatus;
    public ComboBox CboEntryInspectionStatus       => cboEntryInspectionStatus;
    public ComboBox CboEntryClearanceStatus        => cboEntryClearanceStatus;
    public ComboBox CboEntryEnvironmentalCondition => cboEntryEnvironmentalCondition;

    // ── Entry fields: narrative ───────────────────────────────────────────────
    public ComboBox CboEntryDirective          => cboEntryDirective;
    public ComboBox CboEntryIncidentPhrase     => cboEntryIncidentPhrase;
    public ComboBox CboEntryResolutionPhrase   => cboEntryResolutionPhrase;
    public ComboBox CboEntryRouteStatusPhrase  => cboEntryRouteStatusPhrase;
    public TextBox  TxtEntryPublicBodyOverride => txtEntryPublicBodyOverride;

    // ── Entry fields: story thread ────────────────────────────────────────────
    public ComboBox CboEntryStoryThread      => cboEntryStoryThread;
    public ComboBox CboEntryAppliedStoryBeat => cboEntryAppliedStoryBeat;
    public ComboBox CboEntryAnomalySeverity  => cboEntryAnomalySeverity;

    // ── Entry fields: hidden truth ────────────────────────────────────────────
    public TextBox TxtEntryHiddenTruthNotes => txtEntryHiddenTruthNotes;

    // ── Entry fields: schedule ────────────────────────────────────────────────
    public CheckBox       ChkEntryScheduledEnabled => chkEntryScheduledEnabled;
    public DateTimePicker DtpEntryScheduledUtc     => dtpEntryScheduledUtc;

    // ── Manifest grids ────────────────────────────────────────────────────────
    public DataGridView GridDeclaredCargo      => gridDeclaredCargo;
    public DataGridView GridActualCargo        => gridActualCargo;
    public DataGridView GridDeclaredPassengers => gridDeclaredPassengers;
    public DataGridView GridActualPassengers   => gridActualPassengers;

    // ── Manifest grid buttons ─────────────────────────────────────────────────
    public Button BtnDeclaredCargoAdd        => btnDeclaredCargoAdd;
    public Button BtnDeclaredCargoDelete     => btnDeclaredCargoDelete;
    public Button BtnActualCargoAdd          => btnActualCargoAdd;
    public Button BtnActualCargoDelete       => btnActualCargoDelete;
    public Button BtnDeclaredPassengerAdd    => btnDeclaredPassengerAdd;
    public Button BtnDeclaredPassengerDelete => btnDeclaredPassengerDelete;
    public Button BtnActualPassengerAdd      => btnActualPassengerAdd;
    public Button BtnActualPassengerDelete   => btnActualPassengerDelete;

    // ── Episode metadata editor panel ─────────────────────────────────────────
    public Panel PnlEpisodeMetaEditor => pnlEpisodeMetaEditor;

    // ── Episode fields ────────────────────────────────────────────────────────
    public TextBox        TxtEpisodeName              => txtEpisodeName;
    public CheckBox       ChkEpisodeHasInUniverseDate => chkEpisodeHasInUniverseDate;
    public DateTimePicker DtpEpisodeInUniverseUtc     => dtpEpisodeInUniverseUtc;
    public ComboBox       CboEpisodeBroadcastStation  => cboEpisodeBroadcastStation;
    public ComboBox       CboEpisodeSeries            => cboEpisodeSeries;
    public CheckBox       ChkEpisodeCanonicalLocked   => chkEpisodeCanonicalLocked;
    public TextBox        TxtEpisodeNotes             => txtEpisodeNotes;

    // ── Series fields ─────────────────────────────────────────────────────────
    public TextBox  TxtSeriesName             => txtSeriesName;
    public ComboBox CboSeriesBroadcastStation => cboSeriesBroadcastStation;
    public TextBox  TxtSeriesNotes            => txtSeriesNotes;
}
