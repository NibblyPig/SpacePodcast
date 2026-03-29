namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl that hosts the scrollable entry-detail editing panel.
/// All controls are built in BuildLayout(), called from the constructor.
/// Because the VS Designer only regenerates InitializeComponent() — never
/// constructor bodies — BuildLayout() and all its controls survive any
/// Designer round-trip permanently.
/// </summary>
public partial class ucEpisodeEntryDetail : UserControl
{
    public ucEpisodeEntryDetail()
    {
        InitializeComponent();
        BuildLayout();
    }

    private void BuildLayout()
    {
        var tbl = new TableLayoutPanel
        {
            Name        = "tblEntryDetail",
            Dock        = DockStyle.Top,
            AutoSize    = true,
            ColumnCount = 2,
            Padding     = new Padding(4, 4, 4, 8)
        };
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        int row = 0;

        void AddRow(string labelText, Control ctrl, int height = 30)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            var lbl = new Label { Text = labelText, Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true, Padding = new Padding(0, 6, 0, 0) };
            tbl.Controls.Add(lbl, 0, row);
            ctrl.Dock = DockStyle.Fill;
            tbl.Controls.Add(ctrl, 1, row);
            tbl.RowCount = ++row;
        }

        void AddSection(string title)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            var lbl = new Label
            {
                Text      = title,
                Dock      = DockStyle.Fill,
                Font      = new Font(SystemFonts.DefaultFont, FontStyle.Bold),
                ForeColor = SystemColors.ControlDarkDark,
                Padding   = new Padding(0, 8, 0, 0)
            };
            tbl.Controls.Add(lbl, 0, row);
            tbl.SetColumnSpan(lbl, 2);
            tbl.RowCount = ++row;
        }

        // ── Entry ──────────────────────────────────────────────────────────────

        AddSection("Entry");

        cboEntryKind = new ComboBox { Name = "cboEntryKind", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Kind:", cboEntryKind);

        cboEntrySourceType = new ComboBox { Name = "cboEntrySourceType", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Source Type:", cboEntrySourceType);

        txtEntryName = new TextBox { Name = "txtEntryName" };
        AddRow("Name:", txtEntryName);

        numEntrySortOrder = new NumericUpDown { Name = "numEntrySortOrder", Minimum = 0, Maximum = 9999 };
        AddRow("Sort Order:", numEntrySortOrder);

        var flagsPanel = new Panel();
        chkEntryLocked = new CheckBox { Name = "chkEntryLocked", Text = "Locked", AutoSize = true, Location = new Point(0, 4) };
        chkEntryCanon  = new CheckBox { Name = "chkEntryCanon",  Text = "Canon",  AutoSize = true, Location = new Point(80, 4) };
        flagsPanel.Controls.AddRange(new Control[] { chkEntryLocked, chkEntryCanon });
        AddRow("Flags:", flagsPanel);

        numEntryRandomSeed = new NumericUpDown { Name = "numEntryRandomSeed", Minimum = int.MinValue, Maximum = int.MaxValue };
        AddRow("Random Seed:", numEntryRandomSeed);

        txtEntryNotes = new TextBox { Name = "txtEntryNotes", Multiline = true, ScrollBars = ScrollBars.Vertical };
        AddRow("Notes:", txtEntryNotes, 72);

        // ── Operation / Notice ─────────────────────────────────────────────────

        AddSection("Operation / Notice");

        cboEntryOperationType = new ComboBox { Name = "cboEntryOperationType", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Operation Type:", cboEntryOperationType);

        cboEntryNoticeType = new ComboBox { Name = "cboEntryNoticeType", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Notice Type:", cboEntryNoticeType);

        // ── Location ──────────────────────────────────────────────────────────

        AddSection("Location");

        cboEntryStation = new ComboBox { Name = "cboEntryStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Station:", cboEntryStation);

        cboEntryDock = new ComboBox { Name = "cboEntryDock", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Dock:", cboEntryDock);

        cboEntryOriginStation = new ComboBox { Name = "cboEntryOriginStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Origin Station:", cboEntryOriginStation);

        cboEntryDestinationStation = new ComboBox { Name = "cboEntryDestinationStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Destination Station:", cboEntryDestinationStation);

        // ── Vessel ────────────────────────────────────────────────────────────

        AddSection("Vessel");

        cboEntryVessel = new ComboBox { Name = "cboEntryVessel", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Vessel:", cboEntryVessel);

        cboEntryVesselClassOverride = new ComboBox { Name = "cboEntryVesselClassOverride", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Class Override:", cboEntryVesselClassOverride);

        txtEntryRegistryOverride = new TextBox { Name = "txtEntryRegistryOverride" };
        AddRow("Registry Override:", txtEntryRegistryOverride);

        // ── Purpose ───────────────────────────────────────────────────────────

        AddSection("Purpose");

        cboEntryDeclaredPurpose = new ComboBox { Name = "cboEntryDeclaredPurpose", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Declared Purpose:", cboEntryDeclaredPurpose);

        cboEntryActualPurpose = new ComboBox { Name = "cboEntryActualPurpose", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Actual Purpose:", cboEntryActualPurpose);

        // ── Statuses ──────────────────────────────────────────────────────────

        AddSection("Statuses");

        cboEntryManifestStatus = new ComboBox { Name = "cboEntryManifestStatus", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Manifest Status:", cboEntryManifestStatus);

        cboEntryInspectionStatus = new ComboBox { Name = "cboEntryInspectionStatus", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Inspection Status:", cboEntryInspectionStatus);

        cboEntryClearanceStatus = new ComboBox { Name = "cboEntryClearanceStatus", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Clearance Status:", cboEntryClearanceStatus);

        cboEntryEnvironmentalCondition = new ComboBox { Name = "cboEntryEnvironmentalCondition", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Environment:", cboEntryEnvironmentalCondition);

        // ── Narrative ─────────────────────────────────────────────────────────

        AddSection("Narrative");

        cboEntryDirective = new ComboBox { Name = "cboEntryDirective", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Directive:", cboEntryDirective);

        cboEntryIncidentPhrase = new ComboBox { Name = "cboEntryIncidentPhrase", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Incident Phrase:", cboEntryIncidentPhrase);

        cboEntryResolutionPhrase = new ComboBox { Name = "cboEntryResolutionPhrase", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Resolution Phrase:", cboEntryResolutionPhrase);

        cboEntryRouteStatusPhrase = new ComboBox { Name = "cboEntryRouteStatusPhrase", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Route Status Phrase:", cboEntryRouteStatusPhrase);

        txtEntryPublicBodyOverride = new TextBox { Name = "txtEntryPublicBodyOverride", Multiline = true, ScrollBars = ScrollBars.Vertical };
        AddRow("Public Body Override:", txtEntryPublicBodyOverride, 72);

        // ── Story Thread ──────────────────────────────────────────────────────

        AddSection("Story Thread");

        cboEntryStoryThread = new ComboBox { Name = "cboEntryStoryThread", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Story Thread:", cboEntryStoryThread);

        cboEntryAppliedStoryBeat = new ComboBox { Name = "cboEntryAppliedStoryBeat", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Story Beat:", cboEntryAppliedStoryBeat);

        cboEntryAnomalySeverity = new ComboBox { Name = "cboEntryAnomalySeverity", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Anomaly Severity:", cboEntryAnomalySeverity);

        // ── Hidden Truth ──────────────────────────────────────────────────────

        AddSection("Hidden Truth");

        txtEntryHiddenTruthNotes = new TextBox { Name = "txtEntryHiddenTruthNotes", Multiline = true, ScrollBars = ScrollBars.Vertical };
        AddRow("Hidden Truth Notes:", txtEntryHiddenTruthNotes, 72);

        // ── Schedule ──────────────────────────────────────────────────────────

        AddSection("Schedule");

        var schedPanel = new Panel();
        chkEntryScheduledEnabled = new CheckBox      { Name = "chkEntryScheduledEnabled", Width = 22, Location = new Point(0, 5) };
        dtpEntryScheduledUtc     = new DateTimePicker { Name = "dtpEntryScheduledUtc", Enabled = false, Location = new Point(26, 2), Width = 200, Format = DateTimePickerFormat.Short };
        schedPanel.Controls.AddRange(new Control[] { chkEntryScheduledEnabled, dtpEntryScheduledUtc });
        AddRow("Scheduled (UTC):", schedPanel);

        // ── Manifest grids ────────────────────────────────────────────────────

        void AddFullRow(DataGridView grid, Button btnAdd, Button btnDel, int gridHeight)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, gridHeight + 32));
            var container = new Panel();
            btnAdd.Text = "Add";    btnAdd.Width = 60; btnAdd.Dock = DockStyle.Left;
            btnDel.Text = "Delete"; btnDel.Width = 60; btnDel.Dock = DockStyle.Left;
            var btnPanel = new Panel { Dock = DockStyle.Bottom, Height = 28, Padding = new Padding(2) };
            btnPanel.Controls.AddRange(new Control[] { btnAdd, btnDel });
            grid.Dock                = DockStyle.Fill;
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows  = false;
            grid.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect         = false;
            grid.DataError          += (s, e) => e.Cancel = true;
            container.Controls.Add(grid);
            container.Controls.Add(btnPanel);
            container.Dock = DockStyle.Fill;
            tbl.Controls.Add(container, 0, row);
            tbl.SetColumnSpan(container, 2);
            tbl.RowCount = ++row;
        }

        AddSection("Declared Cargo");
        gridDeclaredCargo      = new DataGridView { Name = "gridDeclaredCargo" };
        btnDeclaredCargoAdd    = new Button       { Name = "btnDeclaredCargoAdd" };
        btnDeclaredCargoDelete = new Button       { Name = "btnDeclaredCargoDelete" };
        AddFullRow(gridDeclaredCargo, btnDeclaredCargoAdd, btnDeclaredCargoDelete, 150);

        AddSection("Actual Cargo");
        gridActualCargo      = new DataGridView { Name = "gridActualCargo" };
        btnActualCargoAdd    = new Button       { Name = "btnActualCargoAdd" };
        btnActualCargoDelete = new Button       { Name = "btnActualCargoDelete" };
        AddFullRow(gridActualCargo, btnActualCargoAdd, btnActualCargoDelete, 150);

        AddSection("Declared Passengers");
        gridDeclaredPassengers     = new DataGridView { Name = "gridDeclaredPassengers" };
        btnDeclaredPassengerAdd    = new Button       { Name = "btnDeclaredPassengerAdd" };
        btnDeclaredPassengerDelete = new Button       { Name = "btnDeclaredPassengerDelete" };
        AddFullRow(gridDeclaredPassengers, btnDeclaredPassengerAdd, btnDeclaredPassengerDelete, 130);

        AddSection("Actual Passengers");
        gridActualPassengers      = new DataGridView { Name = "gridActualPassengers" };
        btnActualPassengerAdd     = new Button       { Name = "btnActualPassengerAdd" };
        btnActualPassengerDelete  = new Button       { Name = "btnActualPassengerDelete" };
        AddFullRow(gridActualPassengers, btnActualPassengerAdd, btnActualPassengerDelete, 130);

        flpValidationHints = new FlowLayoutPanel
        {
            Name          = "flpValidationHints",
            Dock          = DockStyle.Top,
            AutoSize      = true,
            FlowDirection = FlowDirection.TopDown,
            WrapContents  = false,
            Visible       = false,
            BackColor     = Color.FromArgb(255, 252, 220),
            Padding       = new Padding(6, 4, 6, 4)
        };

        Controls.Add(tbl);
        Controls.Add(flpValidationHints);
    }

    // ── Public properties ─────────────────────────────────────────────────────

    public FlowLayoutPanel FlpValidationHints => flpValidationHints;

    // Entry: structural
    public ComboBox      CboEntryKind       => cboEntryKind;
    public ComboBox      CboEntrySourceType => cboEntrySourceType;
    public TextBox       TxtEntryName       => txtEntryName;
    public NumericUpDown NumEntrySortOrder  => numEntrySortOrder;
    public CheckBox      ChkEntryLocked     => chkEntryLocked;
    public CheckBox      ChkEntryCanon      => chkEntryCanon;
    public NumericUpDown NumEntryRandomSeed => numEntryRandomSeed;
    public TextBox       TxtEntryNotes      => txtEntryNotes;

    // Entry: operation / notice
    public ComboBox CboEntryOperationType => cboEntryOperationType;
    public ComboBox CboEntryNoticeType    => cboEntryNoticeType;

    // Entry: location
    public ComboBox CboEntryStation            => cboEntryStation;
    public ComboBox CboEntryDock               => cboEntryDock;
    public ComboBox CboEntryOriginStation      => cboEntryOriginStation;
    public ComboBox CboEntryDestinationStation => cboEntryDestinationStation;

    // Entry: vessel
    public ComboBox CboEntryVessel              => cboEntryVessel;
    public ComboBox CboEntryVesselClassOverride => cboEntryVesselClassOverride;
    public TextBox  TxtEntryRegistryOverride    => txtEntryRegistryOverride;

    // Entry: purpose
    public ComboBox CboEntryDeclaredPurpose => cboEntryDeclaredPurpose;
    public ComboBox CboEntryActualPurpose   => cboEntryActualPurpose;

    // Entry: statuses
    public ComboBox CboEntryManifestStatus         => cboEntryManifestStatus;
    public ComboBox CboEntryInspectionStatus       => cboEntryInspectionStatus;
    public ComboBox CboEntryClearanceStatus        => cboEntryClearanceStatus;
    public ComboBox CboEntryEnvironmentalCondition => cboEntryEnvironmentalCondition;

    // Entry: narrative
    public ComboBox CboEntryDirective          => cboEntryDirective;
    public ComboBox CboEntryIncidentPhrase     => cboEntryIncidentPhrase;
    public ComboBox CboEntryResolutionPhrase   => cboEntryResolutionPhrase;
    public ComboBox CboEntryRouteStatusPhrase  => cboEntryRouteStatusPhrase;
    public TextBox  TxtEntryPublicBodyOverride => txtEntryPublicBodyOverride;

    // Entry: story thread
    public ComboBox CboEntryStoryThread      => cboEntryStoryThread;
    public ComboBox CboEntryAppliedStoryBeat => cboEntryAppliedStoryBeat;
    public ComboBox CboEntryAnomalySeverity  => cboEntryAnomalySeverity;

    // Entry: hidden truth
    public TextBox TxtEntryHiddenTruthNotes => txtEntryHiddenTruthNotes;

    // Entry: schedule
    public CheckBox       ChkEntryScheduledEnabled => chkEntryScheduledEnabled;
    public DateTimePicker DtpEntryScheduledUtc     => dtpEntryScheduledUtc;

    // Manifest grids
    public DataGridView GridDeclaredCargo      => gridDeclaredCargo;
    public DataGridView GridActualCargo        => gridActualCargo;
    public DataGridView GridDeclaredPassengers => gridDeclaredPassengers;
    public DataGridView GridActualPassengers   => gridActualPassengers;

    // Manifest buttons
    public Button BtnDeclaredCargoAdd        => btnDeclaredCargoAdd;
    public Button BtnDeclaredCargoDelete     => btnDeclaredCargoDelete;
    public Button BtnActualCargoAdd          => btnActualCargoAdd;
    public Button BtnActualCargoDelete       => btnActualCargoDelete;
    public Button BtnDeclaredPassengerAdd    => btnDeclaredPassengerAdd;
    public Button BtnDeclaredPassengerDelete => btnDeclaredPassengerDelete;
    public Button BtnActualPassengerAdd      => btnActualPassengerAdd;
    public Button BtnActualPassengerDelete   => btnActualPassengerDelete;

    // ── Fields ────────────────────────────────────────────────────────────────

    private FlowLayoutPanel flpValidationHints = null!;

    // Entry: structural
    private ComboBox      cboEntryKind       = null!;
    private ComboBox      cboEntrySourceType = null!;
    private TextBox       txtEntryName       = null!;
    private NumericUpDown numEntrySortOrder  = null!;
    private CheckBox      chkEntryLocked     = null!;
    private CheckBox      chkEntryCanon      = null!;
    private NumericUpDown numEntryRandomSeed = null!;
    private TextBox       txtEntryNotes      = null!;

    // Entry: operation / notice
    private ComboBox cboEntryOperationType = null!;
    private ComboBox cboEntryNoticeType    = null!;

    // Entry: location
    private ComboBox cboEntryStation            = null!;
    private ComboBox cboEntryDock               = null!;
    private ComboBox cboEntryOriginStation      = null!;
    private ComboBox cboEntryDestinationStation = null!;

    // Entry: vessel
    private ComboBox cboEntryVessel              = null!;
    private ComboBox cboEntryVesselClassOverride = null!;
    private TextBox  txtEntryRegistryOverride    = null!;

    // Entry: purpose
    private ComboBox cboEntryDeclaredPurpose = null!;
    private ComboBox cboEntryActualPurpose   = null!;

    // Entry: statuses
    private ComboBox cboEntryManifestStatus         = null!;
    private ComboBox cboEntryInspectionStatus       = null!;
    private ComboBox cboEntryClearanceStatus        = null!;
    private ComboBox cboEntryEnvironmentalCondition = null!;

    // Entry: narrative
    private ComboBox cboEntryDirective          = null!;
    private ComboBox cboEntryIncidentPhrase     = null!;
    private ComboBox cboEntryResolutionPhrase   = null!;
    private ComboBox cboEntryRouteStatusPhrase  = null!;
    private TextBox  txtEntryPublicBodyOverride = null!;

    // Entry: story thread
    private ComboBox cboEntryStoryThread      = null!;
    private ComboBox cboEntryAppliedStoryBeat = null!;
    private ComboBox cboEntryAnomalySeverity  = null!;

    // Entry: hidden truth
    private TextBox txtEntryHiddenTruthNotes = null!;

    // Entry: schedule
    private CheckBox       chkEntryScheduledEnabled = null!;
    private DateTimePicker dtpEntryScheduledUtc     = null!;

    // Manifest grids
    private DataGridView gridDeclaredCargo      = null!;
    private DataGridView gridActualCargo        = null!;
    private DataGridView gridDeclaredPassengers = null!;
    private DataGridView gridActualPassengers   = null!;

    // Manifest buttons
    private Button btnDeclaredCargoAdd       = null!;
    private Button btnDeclaredCargoDelete    = null!;
    private Button btnActualCargoAdd         = null!;
    private Button btnActualCargoDelete      = null!;
    private Button btnDeclaredPassengerAdd   = null!;
    private Button btnDeclaredPassengerDelete = null!;
    private Button btnActualPassengerAdd     = null!;
    private Button btnActualPassengerDelete  = null!;
}
