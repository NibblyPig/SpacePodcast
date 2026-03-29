namespace PodcastUniverseEditor.UI.Controls.Episodes;

/// <summary>
/// UserControl for the Episodes tab.
/// Hosts the full episodes/series/entry editing UI.
/// Public properties expose all controls referenced by MainForm so that
/// MainForm can own all behaviour without this control needing any project
/// or service references.
/// Entry-detail controls are forwarded through ucEntryDetail (ucEpisodeEntryDetail).
/// Episode/series meta controls are forwarded through ucMetaEditor (ucEpisodeMetaEditor).
/// </summary>
public partial class ucEpisodes : UserControl
{
    public ucEpisodes()
    {
        InitializeComponent();
    }

    // ── Lists ──────────────────────────────────────────────────────────────────
    public ListBox LstSeries => lstSeries;
    public ListBox LstEpisodes => lstEpisodes;

    // ── Series buttons ─────────────────────────────────────────────────────────
    public Button BtnSeriesAdd => btnSeriesAdd;
    public Button BtnSeriesDelete => btnSeriesDelete;
    public Button BtnSeriesDuplicate => btnSeriesDuplicate;

    // ── Episode search / summary ───────────────────────────────────────────────
    public TextBox TxtEpisodeSearch => txtEpisodeSearch;
    public TextBox TxtEpisodeSummary => txtEpisodeSummary;

    // ── Episode buttons ────────────────────────────────────────────────────────
    public Button BtnEpisodeAdd => btnEpisodeAdd;
    public Button BtnEpisodeDelete => btnEpisodeDelete;
    public Button BtnEpisodeDuplicate => btnEpisodeDuplicate;
    public Button BtnNewEpisodeAfterSelected => btnNewEpisodeAfterSelected;
    public Button BtnLockEpisodeCanon => btnLockEpisodeCanon;
    public Button BtnUnlockEpisodeCanon => btnUnlockEpisodeCanon;
    public Button BtnEpisodeMoveUp => btnEpisodeMoveUp;
    public Button BtnEpisodeMoveDown => btnEpisodeMoveDown;

    // ── Entry grid ─────────────────────────────────────────────────────────────
    public DataGridView GridEpisodeEntries => gridEpisodeEntries;

    // ── Entry filter controls ──────────────────────────────────────────────────
    public TextBox TxtEntrySearch => txtEntrySearch;
    public ComboBox CboEntryFilterKind => cboEntryFilterKind;
    public ComboBox CboEntryFilterVessel => cboEntryFilterVessel;
    public ComboBox CboEntryFilterStation => cboEntryFilterStation;
    public CheckBox ChkShowLockedOnly => chkShowLockedOnly;
    public Button BtnClearEntryFilters => btnClearEntryFilters;

    // ── Entry management buttons ───────────────────────────────────────────────
    public Button BtnEntryAdd => btnEntryAdd;
    public Button BtnNoticeEntryAdd => btnNoticeEntryAdd;
    public Button BtnEntryDuplicate => btnEntryDuplicate;
    public Button BtnEntryDelete => btnEntryDelete;
    public Button BtnEntryMoveUp => btnEntryMoveUp;
    public Button BtnEntryMoveDown => btnEntryMoveDown;

    // ── Generation controls ────────────────────────────────────────────────────
    public Button BtnGenerateEntry => btnGenerateEntry;
    public Button BtnGenerateEpisodeEntries => btnGenerateEpisodeEntries;
    public Button BtnRegenerateSelectedEntry => btnRegenerateSelectedEntry;
    public NumericUpDown NumGenerateEntryCount => numGenerateEntryCount;
    public CheckBox ChkClearEpisodeBeforeGenerate => chkClearEpisodeBeforeGenerate;
    public CheckBox ChkRegenerateWithoutAdvancingThread => chkRegenerateWithoutAdvancingThread;
    public TextBox TxtGenerationSeed => txtGenerationSeed;

    // ── Export controls ────────────────────────────────────────────────────────
    public Button BtnExportEpisodeText => btnExportEpisodeText;
    public Button BtnExportEpisodeTts => btnExportEpisodeTts;
    public Button BtnExportEpisodeJson => btnExportEpisodeJson;
    public CheckBox ChkExportIncludeHeader => chkExportIncludeHeader;
    public CheckBox ChkExportBlankLineBetweenEntries => chkExportBlankLineBetweenEntries;
    public CheckBox ChkExportIncludeEntryMarkers => chkExportIncludeEntryMarkers;
    public CheckBox ChkExportAuthorDebugMode => chkExportAuthorDebugMode;

    // ── Preview / thread summary ───────────────────────────────────────────────
    public TextBox TxtEpisodeEntryPreview => txtEpisodeEntryPreview;
    public TextBox TxtThreadSummary => txtThreadSummary;

    // ── Entry detail panel (child UC) ──────────────────────────────────────────
    public Control PnlEntryDetail => ucEntryDetail;
    public FlowLayoutPanel FlpValidationHints => ucEntryDetail.FlpValidationHints;

    // ── Entry fields: structural ───────────────────────────────────────────────
    public ComboBox CboEntryKind => ucEntryDetail.CboEntryKind;
    public ComboBox CboEntrySourceType => ucEntryDetail.CboEntrySourceType;
    public TextBox TxtEntryName => ucEntryDetail.TxtEntryName;
    public NumericUpDown NumEntrySortOrder => ucEntryDetail.NumEntrySortOrder;
    public CheckBox ChkEntryLocked => ucEntryDetail.ChkEntryLocked;
    public CheckBox ChkEntryCanon => ucEntryDetail.ChkEntryCanon;
    public NumericUpDown NumEntryRandomSeed => ucEntryDetail.NumEntryRandomSeed;
    public TextBox TxtEntryNotes => ucEntryDetail.TxtEntryNotes;

    // ── Entry fields: operation / notice ──────────────────────────────────────
    public ComboBox CboEntryOperationType => ucEntryDetail.CboEntryOperationType;
    public ComboBox CboEntryNoticeType => ucEntryDetail.CboEntryNoticeType;

    // ── Entry fields: location ─────────────────────────────────────────────────
    public ComboBox CboEntryStation => ucEntryDetail.CboEntryStation;
    public ComboBox CboEntryDock => ucEntryDetail.CboEntryDock;
    public ComboBox CboEntryOriginStation => ucEntryDetail.CboEntryOriginStation;
    public ComboBox CboEntryDestinationStation => ucEntryDetail.CboEntryDestinationStation;

    // ── Entry fields: vessel ───────────────────────────────────────────────────
    public ComboBox CboEntryVessel => ucEntryDetail.CboEntryVessel;
    public ComboBox CboEntryVesselClassOverride => ucEntryDetail.CboEntryVesselClassOverride;
    public TextBox TxtEntryRegistryOverride => ucEntryDetail.TxtEntryRegistryOverride;

    // ── Entry fields: purpose ──────────────────────────────────────────────────
    public ComboBox CboEntryDeclaredPurpose => ucEntryDetail.CboEntryDeclaredPurpose;
    public ComboBox CboEntryActualPurpose => ucEntryDetail.CboEntryActualPurpose;

    // ── Entry fields: statuses ─────────────────────────────────────────────────
    public ComboBox CboEntryManifestStatus => ucEntryDetail.CboEntryManifestStatus;
    public ComboBox CboEntryInspectionStatus => ucEntryDetail.CboEntryInspectionStatus;
    public ComboBox CboEntryClearanceStatus => ucEntryDetail.CboEntryClearanceStatus;
    public ComboBox CboEntryEnvironmentalCondition => ucEntryDetail.CboEntryEnvironmentalCondition;

    // ── Entry fields: narrative ────────────────────────────────────────────────
    public ComboBox CboEntryDirective => ucEntryDetail.CboEntryDirective;
    public ComboBox CboEntryIncidentPhrase => ucEntryDetail.CboEntryIncidentPhrase;
    public ComboBox CboEntryResolutionPhrase => ucEntryDetail.CboEntryResolutionPhrase;
    public ComboBox CboEntryRouteStatusPhrase => ucEntryDetail.CboEntryRouteStatusPhrase;
    public TextBox TxtEntryPublicBodyOverride => ucEntryDetail.TxtEntryPublicBodyOverride;

    // ── Entry fields: story thread ─────────────────────────────────────────────
    public ComboBox CboEntryStoryThread => ucEntryDetail.CboEntryStoryThread;
    public ComboBox CboEntryAppliedStoryBeat => ucEntryDetail.CboEntryAppliedStoryBeat;
    public ComboBox CboEntryAnomalySeverity => ucEntryDetail.CboEntryAnomalySeverity;

    // ── Entry fields: hidden truth ─────────────────────────────────────────────
    public TextBox TxtEntryHiddenTruthNotes => ucEntryDetail.TxtEntryHiddenTruthNotes;

    // ── Entry fields: schedule ─────────────────────────────────────────────────
    public CheckBox ChkEntryScheduledEnabled => ucEntryDetail.ChkEntryScheduledEnabled;
    public DateTimePicker DtpEntryScheduledUtc => ucEntryDetail.DtpEntryScheduledUtc;

    // ── Manifest grids ─────────────────────────────────────────────────────────
    public DataGridView GridDeclaredCargo => ucEntryDetail.GridDeclaredCargo;
    public DataGridView GridActualCargo => ucEntryDetail.GridActualCargo;
    public DataGridView GridDeclaredPassengers => ucEntryDetail.GridDeclaredPassengers;
    public DataGridView GridActualPassengers => ucEntryDetail.GridActualPassengers;

    // ── Manifest grid buttons ──────────────────────────────────────────────────
    public Button BtnDeclaredCargoAdd => ucEntryDetail.BtnDeclaredCargoAdd;
    public Button BtnDeclaredCargoDelete => ucEntryDetail.BtnDeclaredCargoDelete;
    public Button BtnActualCargoAdd => ucEntryDetail.BtnActualCargoAdd;
    public Button BtnActualCargoDelete => ucEntryDetail.BtnActualCargoDelete;
    public Button BtnDeclaredPassengerAdd => ucEntryDetail.BtnDeclaredPassengerAdd;
    public Button BtnDeclaredPassengerDelete => ucEntryDetail.BtnDeclaredPassengerDelete;
    public Button BtnActualPassengerAdd => ucEntryDetail.BtnActualPassengerAdd;
    public Button BtnActualPassengerDelete => ucEntryDetail.BtnActualPassengerDelete;

    // ── Episode metadata editor panel (child UC) ───────────────────────────────
    public Control PnlEpisodeMetaEditor => ucMetaEditor;

    // ── Episode fields ─────────────────────────────────────────────────────────
    public TextBox TxtEpisodeName => ucMetaEditor.TxtEpisodeName;
    public CheckBox ChkEpisodeHasInUniverseDate => ucMetaEditor.ChkEpisodeHasInUniverseDate;
    public DateTimePicker DtpEpisodeInUniverseUtc => ucMetaEditor.DtpEpisodeInUniverseUtc;
    public ComboBox CboEpisodeBroadcastStation => ucMetaEditor.CboEpisodeBroadcastStation;
    public ComboBox CboEpisodeSeries => ucMetaEditor.CboEpisodeSeries;
    public CheckBox ChkEpisodeCanonicalLocked => ucMetaEditor.ChkEpisodeCanonicalLocked;
    public TextBox TxtEpisodeNotes => ucMetaEditor.TxtEpisodeNotes;

    // ── Series fields ──────────────────────────────────────────────────────────
    public TextBox TxtSeriesName => ucMetaEditor.TxtSeriesName;
    public ComboBox CboSeriesBroadcastStation => ucMetaEditor.CboSeriesBroadcastStation;
    public TextBox TxtSeriesNotes => ucMetaEditor.TxtSeriesNotes;
}