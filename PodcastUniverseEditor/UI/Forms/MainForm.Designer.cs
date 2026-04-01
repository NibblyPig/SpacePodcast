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
        menuMain = new MenuStrip();
        mnuFile = new ToolStripMenuItem();
        mnuFileNew = new ToolStripMenuItem();
        mnuFileOpen = new ToolStripMenuItem();
        mnuFileSave = new ToolStripMenuItem();
        mnuFileSaveAs = new ToolStripMenuItem();
        mnuFileExit = new ToolStripMenuItem();
        toolMain = new ToolStrip();
        btnNewProject = new ToolStripButton();
        btnOpenProject = new ToolStripButton();
        btnSaveProject = new ToolStripButton();
        statusMain = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        lblCurrentFile = new ToolStripStatusLabel();
        tabMain = new TabControl();
        tabOverview = new TabPage();
        tabReferenceData = new TabPage();
        tabSystemsBodies = new TabPage();
        tabStationsDocks = new TabPage();
        tabRoutes = new TabPage();
        tabCommodities = new TabPage();
        tabOrganisationsDirectives = new TabPage();
        tabVessels = new TabPage();
        tabThreads = new TabPage();
        tabEpisodes = new TabPage();
        tabOutputPreview = new TabPage();
        tabValidation = new TabPage();
        menuMain.SuspendLayout();
        toolMain.SuspendLayout();
        statusMain.SuspendLayout();
        tabMain.SuspendLayout();
        SuspendLayout();
        // 
        // menuMain
        // 
        menuMain.ImageScalingSize = new Size(24, 24);
        menuMain.Items.AddRange(new ToolStripItem[] { mnuFile });
        menuMain.Location = new Point(0, 0);
        menuMain.Name = "menuMain";
        menuMain.Size = new Size(1280, 33);
        menuMain.TabIndex = 2;
        // 
        // mnuFile
        // 
        mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileNew, mnuFileOpen, mnuFileSave, mnuFileSaveAs, mnuFileExit });
        mnuFile.Name = "mnuFile";
        mnuFile.Size = new Size(54, 29);
        mnuFile.Text = "&File";
        // 
        // mnuFileNew
        // 
        mnuFileNew.Name = "mnuFileNew";
        mnuFileNew.ShortcutKeys = Keys.Control | Keys.N;
        mnuFileNew.Size = new Size(324, 34);
        mnuFileNew.Text = "&New Project\tCtrl+N";
        mnuFileNew.Click += mnuFileNew_Click;
        // 
        // mnuFileOpen
        // 
        mnuFileOpen.Name = "mnuFileOpen";
        mnuFileOpen.ShortcutKeys = Keys.Control | Keys.O;
        mnuFileOpen.Size = new Size(324, 34);
        mnuFileOpen.Text = "&Open...\tCtrl+O";
        mnuFileOpen.Click += mnuFileOpen_Click;
        // 
        // mnuFileSave
        // 
        mnuFileSave.Name = "mnuFileSave";
        mnuFileSave.ShortcutKeys = Keys.Control | Keys.S;
        mnuFileSave.Size = new Size(324, 34);
        mnuFileSave.Text = "&Save\tCtrl+S";
        mnuFileSave.Click += mnuFileSave_Click;
        // 
        // mnuFileSaveAs
        // 
        mnuFileSaveAs.Name = "mnuFileSaveAs";
        mnuFileSaveAs.Size = new Size(324, 34);
        mnuFileSaveAs.Text = "Save &As...";
        mnuFileSaveAs.Click += mnuFileSaveAs_Click;
        // 
        // mnuFileExit
        // 
        mnuFileExit.Name = "mnuFileExit";
        mnuFileExit.Size = new Size(324, 34);
        mnuFileExit.Text = "E&xit";
        mnuFileExit.Click += mnuFileExit_Click;
        // 
        // toolMain
        // 
        toolMain.ImageScalingSize = new Size(24, 24);
        toolMain.Items.AddRange(new ToolStripItem[] { btnNewProject, btnOpenProject, btnSaveProject });
        toolMain.Location = new Point(0, 33);
        toolMain.Name = "toolMain";
        toolMain.Size = new Size(1280, 34);
        toolMain.TabIndex = 1;
        // 
        // btnNewProject
        // 
        btnNewProject.Name = "btnNewProject";
        btnNewProject.Size = new Size(51, 29);
        btnNewProject.Text = "New";
        btnNewProject.ToolTipText = "New Project";
        btnNewProject.Click += btnNewProject_Click;
        // 
        // btnOpenProject
        // 
        btnOpenProject.Name = "btnOpenProject";
        btnOpenProject.Size = new Size(60, 29);
        btnOpenProject.Text = "Open";
        btnOpenProject.ToolTipText = "Open Project";
        btnOpenProject.Click += btnOpenProject_Click;
        // 
        // btnSaveProject
        // 
        btnSaveProject.Name = "btnSaveProject";
        btnSaveProject.Size = new Size(53, 29);
        btnSaveProject.Text = "Save";
        btnSaveProject.ToolTipText = "Save Project";
        btnSaveProject.Click += btnSaveProject_Click;
        // 
        // statusMain
        // 
        statusMain.ImageScalingSize = new Size(24, 24);
        statusMain.Items.AddRange(new ToolStripItem[] { lblStatus, lblCurrentFile });
        statusMain.Location = new Point(0, 768);
        statusMain.Name = "statusMain";
        statusMain.Size = new Size(1280, 32);
        statusMain.TabIndex = 3;
        // 
        // lblStatus
        // 
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(60, 25);
        lblStatus.Text = "Ready";
        // 
        // lblCurrentFile
        // 
        lblCurrentFile.Name = "lblCurrentFile";
        lblCurrentFile.Size = new Size(1205, 25);
        lblCurrentFile.Spring = true;
        lblCurrentFile.TextAlign = ContentAlignment.MiddleRight;
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabOverview);
        tabMain.Controls.Add(tabReferenceData);
        tabMain.Controls.Add(tabSystemsBodies);
        tabMain.Controls.Add(tabStationsDocks);
        tabMain.Controls.Add(tabRoutes);
        tabMain.Controls.Add(tabCommodities);
        tabMain.Controls.Add(tabOrganisationsDirectives);
        tabMain.Controls.Add(tabVessels);
        tabMain.Controls.Add(tabThreads);
        tabMain.Controls.Add(tabEpisodes);
        tabMain.Controls.Add(tabOutputPreview);
        tabMain.Controls.Add(tabValidation);
        tabMain.Dock = DockStyle.Fill;
        tabMain.Location = new Point(0, 67);
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(1280, 701);
        tabMain.TabIndex = 0;
        // 
        // tabOverview
        // 
        tabOverview.Location = new Point(4, 34);
        tabOverview.Name = "tabOverview";
        tabOverview.Size = new Size(1272, 663);
        tabOverview.TabIndex = 0;
        tabOverview.Text = "Overview";
        // 
        // tabReferenceData
        // 
        tabReferenceData.Location = new Point(4, 34);
        tabReferenceData.Name = "tabReferenceData";
        tabReferenceData.Size = new Size(192, 62);
        tabReferenceData.TabIndex = 1;
        tabReferenceData.Text = "Reference Data";
        // 
        // tabSystemsBodies
        // 
        tabSystemsBodies.Location = new Point(4, 34);
        tabSystemsBodies.Name = "tabSystemsBodies";
        tabSystemsBodies.Size = new Size(192, 62);
        tabSystemsBodies.TabIndex = 2;
        tabSystemsBodies.Text = "Systems & Bodies";
        // 
        // tabStationsDocks
        // 
        tabStationsDocks.Location = new Point(4, 34);
        tabStationsDocks.Name = "tabStationsDocks";
        tabStationsDocks.Size = new Size(192, 62);
        tabStationsDocks.TabIndex = 3;
        tabStationsDocks.Text = "Stations & Docks";
        // 
        // tabRoutes
        // 
        tabRoutes.Location = new Point(4, 34);
        tabRoutes.Name = "tabRoutes";
        tabRoutes.Size = new Size(192, 62);
        tabRoutes.TabIndex = 4;
        tabRoutes.Text = "Routes";
        // 
        // tabCommodities
        // 
        tabCommodities.Location = new Point(4, 34);
        tabCommodities.Name = "tabCommodities";
        tabCommodities.Size = new Size(192, 62);
        tabCommodities.TabIndex = 5;
        tabCommodities.Text = "Commodities";
        // 
        // tabOrganisationsDirectives
        // 
        tabOrganisationsDirectives.Location = new Point(4, 34);
        tabOrganisationsDirectives.Name = "tabOrganisationsDirectives";
        tabOrganisationsDirectives.Size = new Size(192, 62);
        tabOrganisationsDirectives.TabIndex = 6;
        tabOrganisationsDirectives.Text = "Organisations";
        // 
        // tabVessels
        // 
        tabVessels.Location = new Point(4, 34);
        tabVessels.Name = "tabVessels";
        tabVessels.Size = new Size(192, 62);
        tabVessels.TabIndex = 7;
        tabVessels.Text = "Vessels";
        // 
        // tabThreads
        // 
        tabThreads.Location = new Point(4, 34);
        tabThreads.Name = "tabThreads";
        tabThreads.Size = new Size(192, 62);
        tabThreads.TabIndex = 8;
        tabThreads.Text = "Threads";
        // 
        // tabEpisodes
        // 
        tabEpisodes.Location = new Point(4, 34);
        tabEpisodes.Name = "tabEpisodes";
        tabEpisodes.Size = new Size(192, 62);
        tabEpisodes.TabIndex = 9;
        tabEpisodes.Text = "Episodes";
        // 
        // tabOutputPreview
        // 
        tabOutputPreview.Location = new Point(4, 34);
        tabOutputPreview.Name = "tabOutputPreview";
        tabOutputPreview.Size = new Size(192, 62);
        tabOutputPreview.TabIndex = 10;
        tabOutputPreview.Text = "Output Preview";
        // 
        // tabValidation
        // 
        tabValidation.Location = new Point(4, 34);
        tabValidation.Name = "tabValidation";
        tabValidation.Size = new Size(192, 62);
        tabValidation.TabIndex = 11;
        tabValidation.Text = "Validation";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1280, 800);
        Controls.Add(tabMain);
        Controls.Add(toolMain);
        Controls.Add(menuMain);
        Controls.Add(statusMain);
        MainMenuStrip = menuMain;
        MinimumSize = new Size(900, 600);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "PodcastUniverseEditor";
        menuMain.ResumeLayout(false);
        menuMain.PerformLayout();
        toolMain.ResumeLayout(false);
        toolMain.PerformLayout();
        statusMain.ResumeLayout(false);
        statusMain.PerformLayout();
        tabMain.ResumeLayout(false);
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
        ucReferenceData = new PodcastUniverseEditor.UI.Controls.ucReferenceData { Dock = DockStyle.Fill };
        lstReferenceTypes = ucReferenceData.ListReferenceTypes;
        gridReferenceItems = ucReferenceData.GridReferenceItems;
        lstReferenceTypes.SelectedIndexChanged += lstReferenceTypes_SelectedIndexChanged;
        ucReferenceData.BtnAdd.Click += btnReferenceAdd_Click;
        ucReferenceData.BtnDelete.Click += btnReferenceDelete_Click;
        tabReferenceData.Controls.Add(ucReferenceData);
    }

    // â”€â”€ Tab: Systems & Bodies â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabSystemsBodies()
    {
        ucSystemsBodies = new PodcastUniverseEditor.UI.Controls.ucSystemsBodies { Dock = DockStyle.Fill };
        gridStarSystems = ucSystemsBodies.GridStarSystems;
        gridCelestialBodies = ucSystemsBodies.GridCelestialBodies;
        ucSystemsBodies.BtnSystemAdd.Click += btnSystemAdd_Click;
        ucSystemsBodies.BtnSystemDelete.Click += btnSystemDelete_Click;
        ucSystemsBodies.BtnBodyAdd.Click += btnBodyAdd_Click;
        ucSystemsBodies.BtnBodyDelete.Click += btnBodyDelete_Click;
        tabSystemsBodies.Controls.Add(ucSystemsBodies);
    }

    // â”€â”€ Tab: Stations & Docks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabStationsDocks()
    {
        // Tab content is owned by ucStationsDocks. Grid and button fields are assigned here
        // so that the rest of MainForm (binding, dirty-tracking, event handlers) continues to
        // work without requiring any further changes to those call sites.
        ucStationsDocks = new PodcastUniverseEditor.UI.Controls.ucStationsDocks { Dock = DockStyle.Fill };
        gridStations = ucStationsDocks.GridStations;
        gridDocks = ucStationsDocks.GridDocks;
        ucStationsDocks.BtnStationsAdd.Click += btnStationsAdd_Click;
        ucStationsDocks.BtnStationsDelete.Click += btnStationsDelete_Click;
        ucStationsDocks.BtnDocksAdd.Click += btnDocksAdd_Click;
        ucStationsDocks.BtnDocksDelete.Click += btnDocksDelete_Click;
        tabStationsDocks.Controls.Add(ucStationsDocks);
    }

    // â”€â”€ Tab: Routes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabRoutes()
    {
        ucRoutes   = new PodcastUniverseEditor.UI.Controls.ucRoutes { Dock = DockStyle.Fill };
        gridRoutes = ucRoutes.GridRoutes;
        ucRoutes.BtnRouteAdd.Click    += btnRouteAdd_Click;
        ucRoutes.BtnRouteDelete.Click += btnRouteDelete_Click;
        tabRoutes.Controls.Add(ucRoutes);
    }

    // â”€â”€ Tab: Commodities â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabCommodities()
    {
        ucCommodities   = new PodcastUniverseEditor.UI.Controls.ucCommodities { Dock = DockStyle.Fill };
        gridCommodities = ucCommodities.GridCommodities;
        ucCommodities.BtnCommodityAdd.Click    += btnCommodityAdd_Click;
        ucCommodities.BtnCommodityDelete.Click += btnCommodityDelete_Click;
        tabCommodities.Controls.Add(ucCommodities);
    }

    // â”€â”€ Tab: Organisations & Directives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabOrganisationsDirectives()
    {
        ucOrganisationsDirectives = new PodcastUniverseEditor.UI.Controls.ucOrganisationsDirectives { Dock = DockStyle.Fill };
        gridOrganisations      = ucOrganisationsDirectives.GridOrganisations;
        btnOrganisationsAdd    = ucOrganisationsDirectives.BtnOrganisationsAdd;
        btnOrganisationsDelete = ucOrganisationsDirectives.BtnOrganisationsDelete;
        ucOrganisationsDirectives.BtnOrganisationsAdd.Click    += btnOrganisationsAdd_Click;
        ucOrganisationsDirectives.BtnOrganisationsDelete.Click += btnOrganisationsDelete_Click;
        tabOrganisationsDirectives.Controls.Add(ucOrganisationsDirectives);
    }

    // â”€â”€ Tab: Vessels â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabVessels()
    {
        ucVessels   = new PodcastUniverseEditor.UI.Controls.ucVessels { Dock = DockStyle.Fill };
        gridVessels = ucVessels.GridVessels;
        ucVessels.BtnVesselAdd.Click    += btnVesselAdd_Click;
        ucVessels.BtnVesselDelete.Click += btnVesselDelete_Click;
        tabVessels.Controls.Add(ucVessels);
    }

    // â”€â”€ Tab: Threads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabThreads()
    {
        ucThreads       = new PodcastUniverseEditor.UI.Controls.ucThreads { Dock = DockStyle.Fill };
        gridThreads     = ucThreads.GridThreads;
        gridThreadBeats = ucThreads.GridThreadBeats;
        gridThreads.SelectionChanged          += gridThreads_SelectionChanged;
        ucThreads.BtnThreadAdd.Click          += btnThreadAdd_Click;
        ucThreads.BtnThreadDelete.Click       += btnThreadDelete_Click;
        ucThreads.BtnBeatAdd.Click            += btnBeatAdd_Click;
        ucThreads.BtnBeatDelete.Click         += btnBeatDelete_Click;
        tabThreads.Controls.Add(ucThreads);
    }

    // â”€â”€ Tab: Episodes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabEpisodes()
    {
        ucEpisodes = new PodcastUniverseEditor.UI.Controls.Episodes.ucEpisodes { Dock = DockStyle.Fill };

        // â”€â”€ Forward fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lstSeries = ucEpisodes.LstSeries;
        lstEpisodes = ucEpisodes.LstEpisodes;
        gridEpisodeEntries = ucEpisodes.GridEpisodeEntries;
        txtEpisodeEntryPreview = ucEpisodes.TxtEpisodeEntryPreview;
        txtEpisodeSummary = ucEpisodes.TxtEpisodeSummary;
        txtEpisodeSearch = ucEpisodes.TxtEpisodeSearch;
        pnlEntryDetail = ucEpisodes.PnlEntryDetail;
        pnlEpisodeMetaEditor = ucEpisodes.PnlEpisodeMetaEditor;
        flpValidationHints = ucEpisodes.FlpValidationHints;
        numGenerateEntryCount = ucEpisodes.NumGenerateEntryCount;
        chkClearEpisodeBeforeGenerate = ucEpisodes.ChkClearEpisodeBeforeGenerate;
        chkRegenerateWithoutAdvancingThread = ucEpisodes.ChkRegenerateWithoutAdvancingThread;
        txtGenerationSeed = ucEpisodes.TxtGenerationSeed;
        cboEntryFilterKind = ucEpisodes.CboEntryFilterKind;
        txtEntrySearch = ucEpisodes.TxtEntrySearch;
        cboEntryFilterVessel = ucEpisodes.CboEntryFilterVessel;
        cboEntryFilterStation = ucEpisodes.CboEntryFilterStation;
        chkShowLockedOnly = ucEpisodes.ChkShowLockedOnly;
        txtThreadSummary = ucEpisodes.TxtThreadSummary;
        gridDeclaredCargo = ucEpisodes.GridDeclaredCargo;
        gridActualCargo = ucEpisodes.GridActualCargo;
        gridDeclaredPassengers = ucEpisodes.GridDeclaredPassengers;
        gridActualPassengers = ucEpisodes.GridActualPassengers;
        btnDeclaredCargoAdd = ucEpisodes.BtnDeclaredCargoAdd;
        btnDeclaredCargoDelete = ucEpisodes.BtnDeclaredCargoDelete;
        btnActualCargoAdd = ucEpisodes.BtnActualCargoAdd;
        btnActualCargoDelete = ucEpisodes.BtnActualCargoDelete;
        btnDeclaredPassengerAdd = ucEpisodes.BtnDeclaredPassengerAdd;
        btnDeclaredPassengerDelete = ucEpisodes.BtnDeclaredPassengerDelete;
        btnActualPassengerAdd = ucEpisodes.BtnActualPassengerAdd;
        btnActualPassengerDelete = ucEpisodes.BtnActualPassengerDelete;
        cboEntryKind = ucEpisodes.CboEntryKind;
        cboEntrySourceType = ucEpisodes.CboEntrySourceType;
        txtEntryName = ucEpisodes.TxtEntryName;
        numEntrySortOrder = ucEpisodes.NumEntrySortOrder;
        chkEntryLocked = ucEpisodes.ChkEntryLocked;
        chkEntryCanon = ucEpisodes.ChkEntryCanon;
        numEntryRandomSeed = ucEpisodes.NumEntryRandomSeed;
        txtEntryNotes = ucEpisodes.TxtEntryNotes;
        cboEntryOperationType = ucEpisodes.CboEntryOperationType;
        cboEntryNoticeType = ucEpisodes.CboEntryNoticeType;
        cboEntryStation = ucEpisodes.CboEntryStation;
        cboEntryDock = ucEpisodes.CboEntryDock;
        cboEntryOriginStation = ucEpisodes.CboEntryOriginStation;
        cboEntryDestinationStation = ucEpisodes.CboEntryDestinationStation;
        cboEntryVessel = ucEpisodes.CboEntryVessel;
        cboEntryVesselClassOverride = ucEpisodes.CboEntryVesselClassOverride;
        txtEntryRegistryOverride = ucEpisodes.TxtEntryRegistryOverride;
        cboEntryDeclaredPurpose = ucEpisodes.CboEntryDeclaredPurpose;
        cboEntryActualPurpose = ucEpisodes.CboEntryActualPurpose;
        cboEntryManifestStatus = ucEpisodes.CboEntryManifestStatus;
        cboEntryInspectionStatus = ucEpisodes.CboEntryInspectionStatus;
        cboEntryClearanceStatus = ucEpisodes.CboEntryClearanceStatus;
        cboEntryEnvironmentalCondition = ucEpisodes.CboEntryEnvironmentalCondition;
        cboEntryDirective = ucEpisodes.CboEntryDirective;
        cboEntryIncidentPhrase = ucEpisodes.CboEntryIncidentPhrase;
        cboEntryResolutionPhrase = ucEpisodes.CboEntryResolutionPhrase;
        cboEntryRouteStatusPhrase = ucEpisodes.CboEntryRouteStatusPhrase;
        txtEntryPublicBodyOverride = ucEpisodes.TxtEntryPublicBodyOverride;
        cboEntryStoryThread = ucEpisodes.CboEntryStoryThread;
        cboEntryAppliedStoryBeat = ucEpisodes.CboEntryAppliedStoryBeat;
        cboEntryAnomalySeverity = ucEpisodes.CboEntryAnomalySeverity;
        txtEntryHiddenTruthNotes = ucEpisodes.TxtEntryHiddenTruthNotes;
        chkEntryScheduledEnabled = ucEpisodes.ChkEntryScheduledEnabled;
        dtpEntryScheduledUtc = ucEpisodes.DtpEntryScheduledUtc;
        txtEpisodeName = ucEpisodes.TxtEpisodeName;
        chkEpisodeHasInUniverseDate = ucEpisodes.ChkEpisodeHasInUniverseDate;
        dtpEpisodeInUniverseUtc = ucEpisodes.DtpEpisodeInUniverseUtc;
        cboEpisodeBroadcastStation = ucEpisodes.CboEpisodeBroadcastStation;
        cboEpisodeSeries = ucEpisodes.CboEpisodeSeries;
        chkEpisodeCanonicalLocked = ucEpisodes.ChkEpisodeCanonicalLocked;
        txtEpisodeNotes = ucEpisodes.TxtEpisodeNotes;
        txtSeriesName = ucEpisodes.TxtSeriesName;
        cboSeriesBroadcastStation = ucEpisodes.CboSeriesBroadcastStation;
        txtSeriesNotes = ucEpisodes.TxtSeriesNotes;
        btnExportEpisodeText = ucEpisodes.BtnExportEpisodeText;
        btnExportEpisodeTts = ucEpisodes.BtnExportEpisodeTts;
        btnExportEpisodeJson = ucEpisodes.BtnExportEpisodeJson;
        chkExportIncludeHeader = ucEpisodes.ChkExportIncludeHeader;
        chkExportBlankLineBetweenEntries = ucEpisodes.ChkExportBlankLineBetweenEntries;
        chkExportIncludeEntryMarkers = ucEpisodes.ChkExportIncludeEntryMarkers;
        chkExportAuthorDebugMode = ucEpisodes.ChkExportAuthorDebugMode;

        // â”€â”€ Wire events â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lstSeries.SelectedIndexChanged += lstSeries_SelectedIndexChanged;
        ucEpisodes.BtnSeriesAdd.Click += btnSeriesAdd_Click;
        ucEpisodes.BtnSeriesDelete.Click += btnSeriesDelete_Click;
        ucEpisodes.BtnSeriesDuplicate.Click += btnSeriesDuplicate_Click;

        lstEpisodes.SelectedIndexChanged += lstEpisodes_SelectedIndexChanged;
        txtEpisodeSearch.TextChanged += txtEpisodeSearch_TextChanged;
        ucEpisodes.BtnEpisodeAdd.Click += btnEpisodeAdd_Click;
        ucEpisodes.BtnEpisodeDelete.Click += btnEpisodeDelete_Click;
        ucEpisodes.BtnEpisodeDuplicate.Click += btnEpisodeDuplicate_Click;
        ucEpisodes.BtnNewEpisodeAfterSelected.Click += btnNewEpisodeAfterSelected_Click;
        ucEpisodes.BtnLockEpisodeCanon.Click += btnLockEpisodeCanon_Click;
        ucEpisodes.BtnUnlockEpisodeCanon.Click += btnUnlockEpisodeCanon_Click;
        ucEpisodes.BtnEpisodeMoveUp.Click += btnEpisodeMoveUp_Click;
        ucEpisodes.BtnEpisodeMoveDown.Click += btnEpisodeMoveDown_Click;

        gridEpisodeEntries.SelectionChanged += gridEpisodeEntries_SelectionChanged;
        ucEpisodes.BtnEntryAdd.Click += btnEntryAdd_Click;
        ucEpisodes.BtnNoticeEntryAdd.Click += btnNoticeEntryAdd_Click;
        ucEpisodes.BtnEntryDuplicate.Click += btnEntryDuplicate_Click;
        ucEpisodes.BtnEntryDelete.Click += btnEntryDelete_Click;
        ucEpisodes.BtnEntryMoveUp.Click += btnEntryMoveUp_Click;
        ucEpisodes.BtnEntryMoveDown.Click += btnEntryMoveDown_Click;

        ucEpisodes.BtnGenerateEntry.Click += btnGenerateEntry_Click;
        ucEpisodes.BtnGenerateEpisodeEntries.Click += btnGenerateEpisodeEntries_Click;
        ucEpisodes.BtnRegenerateSelectedEntry.Click += btnRegenerateSelectedEntry_Click;

        cboEntryFilterKind.SelectedIndexChanged += cboEntryFilterKind_SelectedIndexChanged;
        txtEntrySearch.TextChanged += txtEntrySearch_TextChanged;
        cboEntryFilterVessel.SelectedIndexChanged += cboEntryFilterVessel_SelectedIndexChanged;
        cboEntryFilterStation.SelectedIndexChanged += cboEntryFilterStation_SelectedIndexChanged;
        chkShowLockedOnly.CheckedChanged += chkShowLockedOnly_CheckedChanged;
        ucEpisodes.BtnClearEntryFilters.Click += btnClearEntryFilters_Click;

        ucEpisodes.BtnExportEpisodeText.Click += btnExportEpisodeText_Click;
        ucEpisodes.BtnExportEpisodeTts.Click += btnExportEpisodeTts_Click;
        ucEpisodes.BtnExportEpisodeJson.Click += btnExportEpisodeJson_Click;

        ucEpisodes.BtnDeclaredCargoAdd.Click += btnDeclaredCargoAdd_Click;
        ucEpisodes.BtnDeclaredCargoDelete.Click += btnDeclaredCargoDelete_Click;
        ucEpisodes.BtnActualCargoAdd.Click += btnActualCargoAdd_Click;
        ucEpisodes.BtnActualCargoDelete.Click += btnActualCargoDelete_Click;
        ucEpisodes.BtnDeclaredPassengerAdd.Click += btnDeclaredPassengerAdd_Click;
        ucEpisodes.BtnDeclaredPassengerDelete.Click += btnDeclaredPassengerDelete_Click;
        ucEpisodes.BtnActualPassengerAdd.Click += btnActualPassengerAdd_Click;
        ucEpisodes.BtnActualPassengerDelete.Click += btnActualPassengerDelete_Click;

        tabEpisodes.Controls.Add(ucEpisodes);
    }

    // â”€â”€ Tab: Output Preview â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabOutputPreview()
    {
        ucOutputPreview = new PodcastUniverseEditor.UI.Controls.ucOutputPreview { Dock = DockStyle.Fill };
        txtRenderedOutput = ucOutputPreview.TxtRenderedOutput;
        tabOutputPreview.Controls.Add(ucOutputPreview);
    }

    // â”€â”€ Tab: Validation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabValidation()
    {
        ucValidation = new PodcastUniverseEditor.UI.Controls.ucValidation { Dock = DockStyle.Fill };
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
    private DataGridView gridStarSystems = null!;  // assigned from ucSystemsBodies.GridStarSystems
    private DataGridView gridCelestialBodies = null!;  // assigned from ucSystemsBodies.GridCelestialBodies
    private Button btnSystemAdd = null!;  // assigned from ucSystemsBodies.BtnSystemAdd
    private Button btnSystemDelete = null!;  // assigned from ucSystemsBodies.BtnSystemDelete
    private Button btnBodyAdd = null!;  // assigned from ucSystemsBodies.BtnBodyAdd
    private Button btnBodyDelete = null!;  // assigned from ucSystemsBodies.BtnBodyDelete

    // Stations & Docks
    private PodcastUniverseEditor.UI.Controls.ucStationsDocks ucStationsDocks = null!;
    private DataGridView gridStations = null!;  // assigned from ucStationsDocks.GridStations
    private DataGridView gridDocks = null!;  // assigned from ucStationsDocks.GridDocks

    // Routes
    private PodcastUniverseEditor.UI.Controls.ucRoutes ucRoutes = null!;
    private DataGridView gridRoutes = null!;  // assigned from ucRoutes.GridRoutes

    // Commodities
    private PodcastUniverseEditor.UI.Controls.ucCommodities ucCommodities = null!;
    private DataGridView gridCommodities = null!;  // assigned from ucCommodities.GridCommodities

    // Organisations
    private PodcastUniverseEditor.UI.Controls.ucOrganisationsDirectives ucOrganisationsDirectives = null!;
    private DataGridView gridOrganisations    = null!;  // assigned from ucOrganisationsDirectives.GridOrganisations
    private Button       btnOrganisationsAdd    = null!;  // assigned from ucOrganisationsDirectives.BtnOrganisationsAdd
    private Button       btnOrganisationsDelete = null!;  // assigned from ucOrganisationsDirectives.BtnOrganisationsDelete

    // Vessels
    private PodcastUniverseEditor.UI.Controls.ucVessels ucVessels = null!;
    private DataGridView gridVessels = null!;  // assigned from ucVessels.GridVessels

    // Threads
    private PodcastUniverseEditor.UI.Controls.ucThreads ucThreads = null!;
    private DataGridView gridThreads = null!;  // assigned from ucThreads.GridThreads
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
    private TextBox txtEntrySearch = null!;
    private ComboBox cboEntryFilterKind = null!;
    private ComboBox cboEntryFilterVessel = null!;
    private ComboBox cboEntryFilterStation = null!;
    private CheckBox chkShowLockedOnly = null!;

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
    private Control pnlEpisodeMetaEditor = null!;
    private TextBox txtEpisodeName = null!;
    private CheckBox chkEpisodeHasInUniverseDate = null!;
    private DateTimePicker dtpEpisodeInUniverseUtc = null!;
    private ComboBox cboEpisodeBroadcastStation = null!;
    private ComboBox cboEpisodeSeries = null!;
    private CheckBox chkEpisodeCanonicalLocked = null!;
    private TextBox txtEpisodeNotes = null!;
    private TextBox txtSeriesName = null!;
    private ComboBox cboSeriesBroadcastStation = null!;
    private TextBox txtSeriesNotes = null!;

    // Episodes â€” export controls
    private Button btnExportEpisodeText = null!;
    private Button btnExportEpisodeTts = null!;
    private Button btnExportEpisodeJson = null!;
    private CheckBox chkExportIncludeHeader = null!;
    private CheckBox chkExportBlankLineBetweenEntries = null!;
    private CheckBox chkExportIncludeEntryMarkers = null!;
    private CheckBox chkExportAuthorDebugMode = null!;

    // Output Preview
    private PodcastUniverseEditor.UI.Controls.ucOutputPreview ucOutputPreview = null!;
    private TextBox txtRenderedOutput = null!;  // assigned from ucOutputPreview.TxtRenderedOutput

    // Validation
    private PodcastUniverseEditor.UI.Controls.ucValidation ucValidation = null!;
    private DataGridView gridValidationMessages = null!;  // assigned from ucValidation.GridValidationMessages
}