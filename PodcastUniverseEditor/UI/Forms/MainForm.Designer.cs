namespace PodcastUniverseEditor.UI.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    /// <summary>
    /// Designer-managed shell.
    /// Declares and configures: MenuStrip, ToolStrip, StatusStrip, TabControl, TabPages.
    /// Tab content is intentionally absent here â€” it is populated by InitializeTabContent(),
    /// which is called from the MainForm constructor after this method completes.
    /// Keeping this method flat (no helper calls) ensures the WinForms Designer can parse it.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        // â”€â”€ Declare all shell controls (all new() calls first â€” WinForms Designer convention)

        menuMain       = new MenuStrip();
        mnuFile        = new ToolStripMenuItem();
        mnuFileNew     = new ToolStripMenuItem();
        mnuFileOpen    = new ToolStripMenuItem();
        mnuFileSave    = new ToolStripMenuItem();
        mnuFileSaveAs  = new ToolStripMenuItem();
        mnuFileExit    = new ToolStripMenuItem();

        toolMain       = new ToolStrip();
        btnNewProject  = new ToolStripButton();
        btnOpenProject = new ToolStripButton();
        btnSaveProject = new ToolStripButton();

        statusMain     = new StatusStrip();
        lblStatus      = new ToolStripStatusLabel();
        lblCurrentFile = new ToolStripStatusLabel();

        tabMain                    = new TabControl();
        tabOverview                = new TabPage();
        tabReferenceData           = new TabPage();
        tabSystemsBodies           = new TabPage();
        tabStationsDocks           = new TabPage();
        tabRoutes                  = new TabPage();
        tabCommodities             = new TabPage();
        tabOrganisationsDirectives = new TabPage();
        tabVessels                 = new TabPage();
        tabThreads                 = new TabPage();
        tabEpisodes                = new TabPage();
        tabOutputPreview           = new TabPage();
        tabValidation              = new TabPage();

        SuspendLayout();

        // â”€â”€ MenuStrip â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        menuMain.Name = "menuMain";

        mnuFile.Name = "mnuFile";
        mnuFile.Text = "&File";

        mnuFileNew.Name         = "mnuFileNew";
        mnuFileNew.Text         = "&New Project\tCtrl+N";
        mnuFileNew.ShortcutKeys = Keys.Control | Keys.N;
        mnuFileNew.Click        += mnuFileNew_Click;

        mnuFileOpen.Name         = "mnuFileOpen";
        mnuFileOpen.Text         = "&Open...\tCtrl+O";
        mnuFileOpen.ShortcutKeys = Keys.Control | Keys.O;
        mnuFileOpen.Click        += mnuFileOpen_Click;

        mnuFileSave.Name         = "mnuFileSave";
        mnuFileSave.Text         = "&Save\tCtrl+S";
        mnuFileSave.ShortcutKeys = Keys.Control | Keys.S;
        mnuFileSave.Click        += mnuFileSave_Click;

        mnuFileSaveAs.Name  = "mnuFileSaveAs";
        mnuFileSaveAs.Text  = "Save &As...";
        mnuFileSaveAs.Click += mnuFileSaveAs_Click;

        mnuFileExit.Name  = "mnuFileExit";
        mnuFileExit.Text  = "E&xit";
        mnuFileExit.Click += mnuFileExit_Click;

        mnuFile.DropDownItems.AddRange(new ToolStripItem[]
        {
            mnuFileNew, mnuFileOpen,
            new ToolStripSeparator(),
            mnuFileSave, mnuFileSaveAs,
            new ToolStripSeparator(),
            mnuFileExit
        });
        menuMain.Items.Add(mnuFile);

        // â”€â”€ ToolStrip â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        toolMain.Name = "toolMain";

        btnNewProject.Name        = "btnNewProject";
        btnNewProject.Text        = "New";
        btnNewProject.ToolTipText = "New Project";
        btnNewProject.Click       += btnNewProject_Click;

        btnOpenProject.Name        = "btnOpenProject";
        btnOpenProject.Text        = "Open";
        btnOpenProject.ToolTipText = "Open Project";
        btnOpenProject.Click       += btnOpenProject_Click;

        btnSaveProject.Name        = "btnSaveProject";
        btnSaveProject.Text        = "Save";
        btnSaveProject.ToolTipText = "Save Project";
        btnSaveProject.Click       += btnSaveProject_Click;

        toolMain.Items.AddRange(new ToolStripItem[]
        {
            btnNewProject,
            btnOpenProject,
            new ToolStripSeparator(),
            btnSaveProject
        });

        // â”€â”€ StatusStrip â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        statusMain.Name = "statusMain";

        lblStatus.Name   = "lblStatus";
        lblStatus.Text   = "Ready";
        lblStatus.Spring = false;

        lblCurrentFile.Name      = "lblCurrentFile";
        lblCurrentFile.Text      = string.Empty;
        lblCurrentFile.Spring    = true;
        lblCurrentFile.TextAlign = ContentAlignment.MiddleRight;

        statusMain.Items.AddRange(new ToolStripItem[] { lblStatus, lblCurrentFile });

        // â”€â”€ TabControl and TabPages â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        tabMain.Name = "tabMain";
        tabMain.Dock = DockStyle.Fill;

        tabOverview.Name                = "tabOverview";
        tabOverview.Text                = "Overview";
        tabReferenceData.Name           = "tabReferenceData";
        tabReferenceData.Text           = "Reference Data";
        tabSystemsBodies.Name           = "tabSystemsBodies";
        tabSystemsBodies.Text           = "Systems & Bodies";
        tabStationsDocks.Name           = "tabStationsDocks";
        tabStationsDocks.Text           = "Stations & Docks";
        tabRoutes.Name                  = "tabRoutes";
        tabRoutes.Text                  = "Routes";
        tabCommodities.Name             = "tabCommodities";
        tabCommodities.Text             = "Commodities";
        tabOrganisationsDirectives.Name = "tabOrganisationsDirectives";
        tabOrganisationsDirectives.Text = "Orgs & Directives";
        tabVessels.Name                 = "tabVessels";
        tabVessels.Text                 = "Vessels";
        tabThreads.Name                 = "tabThreads";
        tabThreads.Text                 = "Threads";
        tabEpisodes.Name                = "tabEpisodes";
        tabEpisodes.Text                = "Episodes";
        tabOutputPreview.Name           = "tabOutputPreview";
        tabOutputPreview.Text           = "Output Preview";
        tabValidation.Name              = "tabValidation";
        tabValidation.Text              = "Validation";

        tabMain.TabPages.AddRange(new TabPage[]
        {
            tabOverview, tabReferenceData, tabSystemsBodies, tabStationsDocks,
            tabRoutes, tabCommodities, tabOrganisationsDirectives, tabVessels,
            tabThreads, tabEpisodes, tabOutputPreview, tabValidation
        });

        // â”€â”€ Form â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize    = new Size(1280, 800);
        MinimumSize   = new Size(900, 600);
        Text          = "PodcastUniverseEditor";
        Controls.Add(tabMain);
        Controls.Add(toolMain);
        Controls.Add(menuMain);
        Controls.Add(statusMain);
        MainMenuStrip = menuMain;

        ResumeLayout(false);
        PerformLayout();
    }

    // â”€â”€ Tab content initialisation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Populates each TabPage with its content controls.
    /// Called from the MainForm constructor after InitializeComponent() completes.
    /// Separated so InitializeComponent() remains flat and WinForms Designer-compatible.
    /// Extracted tabs (e.g. ucStationsDocks) create and host their UserControl here.
    /// </summary>
    private void InitializeTabContent()
    {
        InitializeTabOverview();
        InitializeTabReferenceData();
        InitializeTabSystemsBodies();
        InitializeTabStationsDocks();
        InitializeTabRoutes();
        InitializeTabCommodities();
        InitializeTabOrganisationsDirectives();
        InitializeTabVessels();
        InitializeTabThreads();
        InitializeTabEpisodes();
        InitializeTabOutputPreview();
        InitializeTabValidation();
    }

    // â”€â”€ Tab: Overview â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabOverview()
    {
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(12),
            ColumnCount = 2,
            RowCount = 5,
            AutoSize = false
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        layout.Controls.Add(new Label { Text = "Project Name:", Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true }, 0, 0);
        txtProjectName = new TextBox { Name = "txtProjectName", Dock = DockStyle.Fill };
        layout.Controls.Add(txtProjectName, 1, 0);

        layout.Controls.Add(new Label { Text = "Schema Version:", Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true }, 0, 1);
        txtSchemaVersion = new TextBox { Name = "txtSchemaVersion", Dock = DockStyle.Fill, ReadOnly = true };
        layout.Controls.Add(txtSchemaVersion, 1, 1);

        layout.Controls.Add(new Label { Text = "Description:", Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true }, 0, 2);
        txtProjectDescription = new TextBox { Name = "txtProjectDescription", Dock = DockStyle.Fill, Multiline = true };
        layout.Controls.Add(txtProjectDescription, 1, 2);

        btnLoadSampleProject = new Button { Name = "btnLoadSampleProject", Text = "Load Sample Project", AutoSize = true };
        btnLoadSampleProject.Click += btnLoadSampleProject_Click;
        layout.Controls.Add(btnLoadSampleProject, 1, 3);

        tabOverview.Controls.Add(layout);
    }

    // â”€â”€ Tab: Reference Data â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabReferenceData()
    {
        ucReferenceData    = new PodcastUniverseEditor.UI.Controls.ucReferenceData { Dock = DockStyle.Fill };
        lstReferenceTypes  = ucReferenceData.ListReferenceTypes;
        gridReferenceItems = ucReferenceData.GridReferenceItems;
        lstReferenceTypes.SelectedIndexChanged   += lstReferenceTypes_SelectedIndexChanged;
        ucReferenceData.BtnAdd.Click    += btnReferenceAdd_Click;
        ucReferenceData.BtnDelete.Click += btnReferenceDelete_Click;
        tabReferenceData.Controls.Add(ucReferenceData);
    }

    // â”€â”€ Tab: Systems & Bodies â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabSystemsBodies()
    {
        ucSystemsBodies    = new PodcastUniverseEditor.UI.Controls.ucSystemsBodies { Dock = DockStyle.Fill };
        gridStarSystems    = ucSystemsBodies.GridStarSystems;
        gridCelestialBodies = ucSystemsBodies.GridCelestialBodies;
        tabSystemsBodies.Controls.Add(ucSystemsBodies);
    }

    // â”€â”€ Tab: Stations & Docks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabStationsDocks()
    {
        // Tab content is owned by ucStationsDocks. Grid and button fields are assigned here
        // so that the rest of MainForm (binding, dirty-tracking, event handlers) continues to
        // work without requiring any further changes to those call sites.
        ucStationsDocks = new PodcastUniverseEditor.UI.Controls.ucStationsDocks { Dock = DockStyle.Fill };
        gridStations    = ucStationsDocks.GridStations;
        gridDocks       = ucStationsDocks.GridDocks;
        ucStationsDocks.BtnStationsAdd.Click    += btnStationsAdd_Click;
        ucStationsDocks.BtnStationsDelete.Click += btnStationsDelete_Click;
        ucStationsDocks.BtnDocksAdd.Click       += btnDocksAdd_Click;
        ucStationsDocks.BtnDocksDelete.Click    += btnDocksDelete_Click;
        tabStationsDocks.Controls.Add(ucStationsDocks);
    }

    // â”€â”€ Tab: Routes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabRoutes()
    {
        ucRoutes   = new PodcastUniverseEditor.UI.Controls.ucRoutes { Dock = DockStyle.Fill };
        gridRoutes = ucRoutes.GridRoutes;
        tabRoutes.Controls.Add(ucRoutes);
    }

    // â”€â”€ Tab: Commodities â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabCommodities()
    {
        ucCommodities   = new PodcastUniverseEditor.UI.Controls.ucCommodities { Dock = DockStyle.Fill };
        gridCommodities = ucCommodities.GridCommodities;
        tabCommodities.Controls.Add(ucCommodities);
    }

    // â”€â”€ Tab: Organisations & Directives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabOrganisationsDirectives()
    {
        ucOrganisationsDirectives = new PodcastUniverseEditor.UI.Controls.ucOrganisationsDirectives { Dock = DockStyle.Fill };
        gridOrganisations         = ucOrganisationsDirectives.GridOrganisations;
        gridDirectives            = ucOrganisationsDirectives.GridDirectives;
        tabOrganisationsDirectives.Controls.Add(ucOrganisationsDirectives);
    }

    // â”€â”€ Tab: Vessels â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabVessels()
    {
        ucVessels   = new PodcastUniverseEditor.UI.Controls.ucVessels { Dock = DockStyle.Fill };
        gridVessels = ucVessels.GridVessels;
        tabVessels.Controls.Add(ucVessels);
    }

    // â”€â”€ Tab: Threads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabThreads()
    {
        ucThreads       = new PodcastUniverseEditor.UI.Controls.ucThreads { Dock = DockStyle.Fill };
        gridThreads     = ucThreads.GridThreads;
        gridThreadBeats = ucThreads.GridThreadBeats;
        gridThreads.SelectionChanged += gridThreads_SelectionChanged;
        tabThreads.Controls.Add(ucThreads);
    }

    // â”€â”€ Tab: Episodes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabEpisodes()
    {
        ucEpisodes = new PodcastUniverseEditor.UI.Controls.Episodes.ucEpisodes { Dock = DockStyle.Fill };

        // â”€â”€ Forward fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lstSeries              = ucEpisodes.LstSeries;
        lstEpisodes            = ucEpisodes.LstEpisodes;
        gridEpisodeEntries     = ucEpisodes.GridEpisodeEntries;
        txtEpisodeEntryPreview = ucEpisodes.TxtEpisodeEntryPreview;
        txtEpisodeSummary      = ucEpisodes.TxtEpisodeSummary;
        txtEpisodeSearch       = ucEpisodes.TxtEpisodeSearch;
        pnlEntryDetail         = ucEpisodes.PnlEntryDetail;
        pnlEpisodeMetaEditor   = ucEpisodes.PnlEpisodeMetaEditor;
        flpValidationHints     = ucEpisodes.FlpValidationHints;
        numGenerateEntryCount               = ucEpisodes.NumGenerateEntryCount;
        chkClearEpisodeBeforeGenerate       = ucEpisodes.ChkClearEpisodeBeforeGenerate;
        chkRegenerateWithoutAdvancingThread = ucEpisodes.ChkRegenerateWithoutAdvancingThread;
        txtGenerationSeed      = ucEpisodes.TxtGenerationSeed;
        cboEntryFilterKind     = ucEpisodes.CboEntryFilterKind;
        txtEntrySearch         = ucEpisodes.TxtEntrySearch;
        cboEntryFilterVessel   = ucEpisodes.CboEntryFilterVessel;
        cboEntryFilterStation  = ucEpisodes.CboEntryFilterStation;
        chkShowLockedOnly      = ucEpisodes.ChkShowLockedOnly;
        txtThreadSummary       = ucEpisodes.TxtThreadSummary;
        gridDeclaredCargo      = ucEpisodes.GridDeclaredCargo;
        gridActualCargo        = ucEpisodes.GridActualCargo;
        gridDeclaredPassengers = ucEpisodes.GridDeclaredPassengers;
        gridActualPassengers   = ucEpisodes.GridActualPassengers;
        cboEntryKind           = ucEpisodes.CboEntryKind;
        cboEntrySourceType     = ucEpisodes.CboEntrySourceType;
        txtEntryName           = ucEpisodes.TxtEntryName;
        numEntrySortOrder      = ucEpisodes.NumEntrySortOrder;
        chkEntryLocked         = ucEpisodes.ChkEntryLocked;
        chkEntryCanon          = ucEpisodes.ChkEntryCanon;
        numEntryRandomSeed     = ucEpisodes.NumEntryRandomSeed;
        txtEntryNotes          = ucEpisodes.TxtEntryNotes;
        cboEntryOperationType  = ucEpisodes.CboEntryOperationType;
        cboEntryNoticeType     = ucEpisodes.CboEntryNoticeType;
        cboEntryStation            = ucEpisodes.CboEntryStation;
        cboEntryDock               = ucEpisodes.CboEntryDock;
        cboEntryOriginStation      = ucEpisodes.CboEntryOriginStation;
        cboEntryDestinationStation = ucEpisodes.CboEntryDestinationStation;
        cboEntryVessel             = ucEpisodes.CboEntryVessel;
        cboEntryVesselClassOverride = ucEpisodes.CboEntryVesselClassOverride;
        txtEntryRegistryOverride   = ucEpisodes.TxtEntryRegistryOverride;
        cboEntryDeclaredPurpose    = ucEpisodes.CboEntryDeclaredPurpose;
        cboEntryActualPurpose      = ucEpisodes.CboEntryActualPurpose;
        cboEntryManifestStatus         = ucEpisodes.CboEntryManifestStatus;
        cboEntryInspectionStatus       = ucEpisodes.CboEntryInspectionStatus;
        cboEntryClearanceStatus        = ucEpisodes.CboEntryClearanceStatus;
        cboEntryEnvironmentalCondition = ucEpisodes.CboEntryEnvironmentalCondition;
        cboEntryDirective          = ucEpisodes.CboEntryDirective;
        cboEntryIncidentPhrase     = ucEpisodes.CboEntryIncidentPhrase;
        cboEntryResolutionPhrase   = ucEpisodes.CboEntryResolutionPhrase;
        cboEntryRouteStatusPhrase  = ucEpisodes.CboEntryRouteStatusPhrase;
        txtEntryPublicBodyOverride = ucEpisodes.TxtEntryPublicBodyOverride;
        cboEntryStoryThread        = ucEpisodes.CboEntryStoryThread;
        cboEntryAppliedStoryBeat   = ucEpisodes.CboEntryAppliedStoryBeat;
        cboEntryAnomalySeverity    = ucEpisodes.CboEntryAnomalySeverity;
        txtEntryHiddenTruthNotes   = ucEpisodes.TxtEntryHiddenTruthNotes;
        chkEntryScheduledEnabled   = ucEpisodes.ChkEntryScheduledEnabled;
        dtpEntryScheduledUtc       = ucEpisodes.DtpEntryScheduledUtc;
        txtEpisodeName              = ucEpisodes.TxtEpisodeName;
        chkEpisodeHasInUniverseDate = ucEpisodes.ChkEpisodeHasInUniverseDate;
        dtpEpisodeInUniverseUtc     = ucEpisodes.DtpEpisodeInUniverseUtc;
        cboEpisodeBroadcastStation  = ucEpisodes.CboEpisodeBroadcastStation;
        cboEpisodeSeries            = ucEpisodes.CboEpisodeSeries;
        chkEpisodeCanonicalLocked   = ucEpisodes.ChkEpisodeCanonicalLocked;
        txtEpisodeNotes             = ucEpisodes.TxtEpisodeNotes;
        txtSeriesName               = ucEpisodes.TxtSeriesName;
        cboSeriesBroadcastStation   = ucEpisodes.CboSeriesBroadcastStation;
        txtSeriesNotes              = ucEpisodes.TxtSeriesNotes;
        btnExportEpisodeText             = ucEpisodes.BtnExportEpisodeText;
        btnExportEpisodeTts              = ucEpisodes.BtnExportEpisodeTts;
        btnExportEpisodeJson             = ucEpisodes.BtnExportEpisodeJson;
        chkExportIncludeHeader           = ucEpisodes.ChkExportIncludeHeader;
        chkExportBlankLineBetweenEntries = ucEpisodes.ChkExportBlankLineBetweenEntries;
        chkExportIncludeEntryMarkers     = ucEpisodes.ChkExportIncludeEntryMarkers;
        chkExportAuthorDebugMode         = ucEpisodes.ChkExportAuthorDebugMode;

        // â”€â”€ Wire events â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lstSeries.SelectedIndexChanged        += lstSeries_SelectedIndexChanged;
        ucEpisodes.BtnSeriesAdd.Click         += btnSeriesAdd_Click;
        ucEpisodes.BtnSeriesDelete.Click      += btnSeriesDelete_Click;
        ucEpisodes.BtnSeriesDuplicate.Click   += btnSeriesDuplicate_Click;

        lstEpisodes.SelectedIndexChanged              += lstEpisodes_SelectedIndexChanged;
        txtEpisodeSearch.TextChanged                  += txtEpisodeSearch_TextChanged;
        ucEpisodes.BtnEpisodeAdd.Click                += btnEpisodeAdd_Click;
        ucEpisodes.BtnEpisodeDelete.Click             += btnEpisodeDelete_Click;
        ucEpisodes.BtnEpisodeDuplicate.Click          += btnEpisodeDuplicate_Click;
        ucEpisodes.BtnNewEpisodeAfterSelected.Click   += btnNewEpisodeAfterSelected_Click;
        ucEpisodes.BtnLockEpisodeCanon.Click          += btnLockEpisodeCanon_Click;
        ucEpisodes.BtnUnlockEpisodeCanon.Click        += btnUnlockEpisodeCanon_Click;
        ucEpisodes.BtnEpisodeMoveUp.Click             += btnEpisodeMoveUp_Click;
        ucEpisodes.BtnEpisodeMoveDown.Click           += btnEpisodeMoveDown_Click;

        gridEpisodeEntries.SelectionChanged   += gridEpisodeEntries_SelectionChanged;
        ucEpisodes.BtnEntryAdd.Click          += btnEntryAdd_Click;
        ucEpisodes.BtnNoticeEntryAdd.Click    += btnNoticeEntryAdd_Click;
        ucEpisodes.BtnEntryDuplicate.Click    += btnEntryDuplicate_Click;
        ucEpisodes.BtnEntryDelete.Click       += btnEntryDelete_Click;
        ucEpisodes.BtnEntryMoveUp.Click       += btnEntryMoveUp_Click;
        ucEpisodes.BtnEntryMoveDown.Click     += btnEntryMoveDown_Click;

        ucEpisodes.BtnGenerateEntry.Click           += btnGenerateEntry_Click;
        ucEpisodes.BtnGenerateEpisodeEntries.Click  += btnGenerateEpisodeEntries_Click;
        ucEpisodes.BtnRegenerateSelectedEntry.Click += btnRegenerateSelectedEntry_Click;

        cboEntryFilterKind.SelectedIndexChanged    += cboEntryFilterKind_SelectedIndexChanged;
        txtEntrySearch.TextChanged                 += txtEntrySearch_TextChanged;
        cboEntryFilterVessel.SelectedIndexChanged  += cboEntryFilterVessel_SelectedIndexChanged;
        cboEntryFilterStation.SelectedIndexChanged += cboEntryFilterStation_SelectedIndexChanged;
        chkShowLockedOnly.CheckedChanged           += chkShowLockedOnly_CheckedChanged;
        ucEpisodes.BtnClearEntryFilters.Click      += btnClearEntryFilters_Click;

        ucEpisodes.BtnExportEpisodeText.Click  += btnExportEpisodeText_Click;
        ucEpisodes.BtnExportEpisodeTts.Click   += btnExportEpisodeTts_Click;
        ucEpisodes.BtnExportEpisodeJson.Click  += btnExportEpisodeJson_Click;

        ucEpisodes.BtnDeclaredCargoAdd.Click      += btnDeclaredCargoAdd_Click;
        ucEpisodes.BtnDeclaredCargoDelete.Click   += btnDeclaredCargoDelete_Click;
        ucEpisodes.BtnActualCargoAdd.Click        += btnActualCargoAdd_Click;
        ucEpisodes.BtnActualCargoDelete.Click     += btnActualCargoDelete_Click;
        ucEpisodes.BtnDeclaredPassengerAdd.Click    += btnDeclaredPassengerAdd_Click;
        ucEpisodes.BtnDeclaredPassengerDelete.Click += btnDeclaredPassengerDelete_Click;
        ucEpisodes.BtnActualPassengerAdd.Click      += btnActualPassengerAdd_Click;
        ucEpisodes.BtnActualPassengerDelete.Click   += btnActualPassengerDelete_Click;

        tabEpisodes.Controls.Add(ucEpisodes);
    }

    // â”€â”€ Tab: Output Preview â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabOutputPreview()
    {
        ucOutputPreview   = new PodcastUniverseEditor.UI.Controls.ucOutputPreview { Dock = DockStyle.Fill };
        txtRenderedOutput = ucOutputPreview.TxtRenderedOutput;
        tabOutputPreview.Controls.Add(ucOutputPreview);
    }

    // â”€â”€ Tab: Validation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabValidation()
    {
        ucValidation           = new PodcastUniverseEditor.UI.Controls.ucValidation { Dock = DockStyle.Fill };
        gridValidationMessages = ucValidation.GridValidationMessages;
        ucValidation.BtnRunValidation.Click += btnRunValidation_Click;
        tabValidation.Controls.Add(ucValidation);
    }

    // â”€â”€ Layout helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Creates a Panel with a bold label header at top and a DataGridView filling the rest.
    /// </summary>
    private static Panel BuildLabelledGridPanel(string label, out DataGridView grid, string gridName)
    {
        var panel = new Panel { Dock = DockStyle.Fill };
        var lbl = new Label { Text = label, Dock = DockStyle.Top, Height = 20, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };
        grid = new DataGridView
        {
            Name = gridName,
            Dock = DockStyle.Fill,
            AutoGenerateColumns = true,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false
        };
        panel.Controls.Add(grid);
        panel.Controls.Add(lbl);
        return panel;
    }

    /// <summary>Creates a full-tab DataGridView with standard settings.</summary>
    private static DataGridView BuildStandaloneGrid(string name) => new DataGridView
    {
        Name = name,
        Dock = DockStyle.Fill,
        AutoGenerateColumns = true,
        AllowUserToAddRows = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        MultiSelect = false
    };

    // â”€â”€ Control fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    // Menu
    private MenuStrip menuMain = null!;
    private ToolStripMenuItem mnuFile = null!;
    private ToolStripMenuItem mnuFileNew = null!;
    private ToolStripMenuItem mnuFileOpen = null!;
    private ToolStripMenuItem mnuFileSave = null!;
    private ToolStripMenuItem mnuFileSaveAs = null!;
    private ToolStripMenuItem mnuFileExit = null!;

    // Toolbar
    private ToolStrip toolMain = null!;
    private ToolStripButton btnNewProject = null!;
    private ToolStripButton btnOpenProject = null!;
    private ToolStripButton btnSaveProject = null!;

    // Status strip
    private StatusStrip statusMain = null!;
    private ToolStripStatusLabel lblStatus = null!;
    private ToolStripStatusLabel lblCurrentFile = null!;

    // Tabs
    private TabControl tabMain = null!;
    private TabPage tabOverview = null!;
    private TabPage tabReferenceData = null!;
    private TabPage tabSystemsBodies = null!;
    private TabPage tabStationsDocks = null!;
    private TabPage tabRoutes = null!;
    private TabPage tabCommodities = null!;
    private TabPage tabOrganisationsDirectives = null!;
    private TabPage tabVessels = null!;
    private TabPage tabThreads = null!;
    private TabPage tabEpisodes = null!;
    private TabPage tabOutputPreview = null!;
    private TabPage tabValidation = null!;

    // Overview
    private TextBox txtProjectName = null!;
    private TextBox txtProjectDescription = null!;
    private TextBox txtSchemaVersion = null!;
    private Button btnLoadSampleProject = null!;

    // Reference data
    private PodcastUniverseEditor.UI.Controls.ucReferenceData ucReferenceData = null!;
    private ListBox lstReferenceTypes = null!;        // assigned from ucReferenceData.ListReferenceTypes
    private DataGridView gridReferenceItems = null!;  // assigned from ucReferenceData.GridReferenceItems

    // Systems & Bodies
    private PodcastUniverseEditor.UI.Controls.ucSystemsBodies ucSystemsBodies = null!;
    private DataGridView gridStarSystems     = null!;  // assigned from ucSystemsBodies.GridStarSystems
    private DataGridView gridCelestialBodies = null!;  // assigned from ucSystemsBodies.GridCelestialBodies

    // Stations & Docks
    private PodcastUniverseEditor.UI.Controls.ucStationsDocks ucStationsDocks = null!;
    private DataGridView gridStations = null!;  // assigned from ucStationsDocks.GridStations
    private DataGridView gridDocks    = null!;  // assigned from ucStationsDocks.GridDocks

    // Routes
    private PodcastUniverseEditor.UI.Controls.ucRoutes ucRoutes = null!;
    private DataGridView gridRoutes = null!;  // assigned from ucRoutes.GridRoutes

    // Commodities
    private PodcastUniverseEditor.UI.Controls.ucCommodities ucCommodities = null!;
    private DataGridView gridCommodities = null!;  // assigned from ucCommodities.GridCommodities

    // Organisations & Directives
    private PodcastUniverseEditor.UI.Controls.ucOrganisationsDirectives ucOrganisationsDirectives = null!;
    private DataGridView gridOrganisations = null!;  // assigned from ucOrganisationsDirectives.GridOrganisations
    private DataGridView gridDirectives    = null!;  // assigned from ucOrganisationsDirectives.GridDirectives

    // Vessels
    private PodcastUniverseEditor.UI.Controls.ucVessels ucVessels = null!;
    private DataGridView gridVessels = null!;  // assigned from ucVessels.GridVessels

    // Threads
    private PodcastUniverseEditor.UI.Controls.ucThreads ucThreads = null!;
    private DataGridView gridThreads     = null!;  // assigned from ucThreads.GridThreads
    private DataGridView gridThreadBeats = null!;  // assigned from ucThreads.GridThreadBeats

    // Episodes
    private PodcastUniverseEditor.UI.Controls.Episodes.ucEpisodes ucEpisodes = null!;

    // Episodes â€” list + grid (forwarded from ucEpisodes)
    private ListBox lstSeries = null!;
    private ListBox lstEpisodes = null!;
    private DataGridView gridEpisodeEntries = null!;
    private TextBox txtEpisodeEntryPreview = null!;
    private TextBox txtEpisodeSummary = null!;
    private TextBox txtEpisodeSearch = null!;
    private NumericUpDown numGenerateEntryCount = null!;
    private CheckBox chkClearEpisodeBeforeGenerate = null!;
    private CheckBox chkRegenerateWithoutAdvancingThread = null!;
    private TextBox txtGenerationSeed = null!;
    private TextBox  txtEntrySearch        = null!;
    private ComboBox cboEntryFilterKind    = null!;
    private ComboBox cboEntryFilterVessel  = null!;
    private ComboBox cboEntryFilterStation = null!;
    private CheckBox chkShowLockedOnly     = null!;

    // Episodes â€” entry detail panel (ucEpisodeEntryDetail child UC)
    private Control pnlEntryDetail = null!;

    // Entry: structural
    private ComboBox cboEntryKind = null!;
    private ComboBox cboEntrySourceType = null!;
    private TextBox txtEntryName = null!;
    private NumericUpDown numEntrySortOrder = null!;
    private CheckBox chkEntryLocked = null!;
    private CheckBox chkEntryCanon = null!;
    private NumericUpDown numEntryRandomSeed = null!;
    private TextBox txtEntryNotes = null!;

    // Entry: operation / notice
    private ComboBox cboEntryOperationType = null!;
    private ComboBox cboEntryNoticeType = null!;

    // Entry: location
    private ComboBox cboEntryStation = null!;
    private ComboBox cboEntryDock = null!;
    private ComboBox cboEntryOriginStation = null!;
    private ComboBox cboEntryDestinationStation = null!;

    // Entry: vessel
    private ComboBox cboEntryVessel = null!;
    private ComboBox cboEntryVesselClassOverride = null!;
    private TextBox txtEntryRegistryOverride = null!;

    // Entry: purpose
    private ComboBox cboEntryDeclaredPurpose = null!;
    private ComboBox cboEntryActualPurpose = null!;

    // Entry: statuses
    private ComboBox cboEntryManifestStatus = null!;
    private ComboBox cboEntryInspectionStatus = null!;
    private ComboBox cboEntryClearanceStatus = null!;
    private ComboBox cboEntryEnvironmentalCondition = null!;

    // Entry: narrative
    private ComboBox cboEntryDirective = null!;
    private ComboBox cboEntryIncidentPhrase = null!;
    private ComboBox cboEntryResolutionPhrase = null!;
    private ComboBox cboEntryRouteStatusPhrase = null!;
    private TextBox txtEntryPublicBodyOverride = null!;

    // Entry: story thread
    private ComboBox cboEntryStoryThread = null!;
    private ComboBox cboEntryAppliedStoryBeat = null!;
    private ComboBox cboEntryAnomalySeverity = null!;

    // Entry: hidden truth
    private TextBox txtEntryHiddenTruthNotes = null!;

    // Entry: schedule
    private CheckBox chkEntryScheduledEnabled = null!;
    private DateTimePicker dtpEntryScheduledUtc = null!;

    // Entry: thread summary
    private TextBox txtThreadSummary = null!;

    // Entry: validation hints panel
    private FlowLayoutPanel flpValidationHints = null!;

    // Entry: manifest grids
    private DataGridView gridDeclaredCargo = null!;
    private DataGridView gridActualCargo = null!;
    private DataGridView gridDeclaredPassengers = null!;
    private DataGridView gridActualPassengers = null!;
    private Button btnDeclaredCargoAdd = null!;
    private Button btnDeclaredCargoDelete = null!;
    private Button btnActualCargoAdd = null!;
    private Button btnActualCargoDelete = null!;
    private Button btnDeclaredPassengerAdd = null!;
    private Button btnDeclaredPassengerDelete = null!;
    private Button btnActualPassengerAdd = null!;
    private Button btnActualPassengerDelete = null!;

    // Episodes â€” metadata editor (ucEpisodeMetaEditor child UC)
    private Control      pnlEpisodeMetaEditor          = null!;
    private TextBox      txtEpisodeName                = null!;
    private CheckBox     chkEpisodeHasInUniverseDate   = null!;
    private DateTimePicker dtpEpisodeInUniverseUtc     = null!;
    private ComboBox     cboEpisodeBroadcastStation    = null!;
    private ComboBox     cboEpisodeSeries              = null!;
    private CheckBox     chkEpisodeCanonicalLocked     = null!;
    private TextBox      txtEpisodeNotes               = null!;
    private TextBox      txtSeriesName                 = null!;
    private ComboBox     cboSeriesBroadcastStation     = null!;
    private TextBox      txtSeriesNotes                = null!;

    // Episodes â€” export controls
    private Button   btnExportEpisodeText             = null!;
    private Button   btnExportEpisodeTts              = null!;
    private Button   btnExportEpisodeJson             = null!;
    private CheckBox chkExportIncludeHeader           = null!;
    private CheckBox chkExportBlankLineBetweenEntries = null!;
    private CheckBox chkExportIncludeEntryMarkers     = null!;
    private CheckBox chkExportAuthorDebugMode         = null!;

    // Output Preview
    private PodcastUniverseEditor.UI.Controls.ucOutputPreview ucOutputPreview = null!;
    private TextBox txtRenderedOutput = null!;  // assigned from ucOutputPreview.TxtRenderedOutput

    // Validation
    private PodcastUniverseEditor.UI.Controls.ucValidation ucValidation = null!;
    private DataGridView gridValidationMessages = null!;  // assigned from ucValidation.GridValidationMessages
}
