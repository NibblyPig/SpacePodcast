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

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        SuspendLayout();

        InitializeMenuStrip();
        InitializeToolStrip();
        InitializeStatusStrip();
        InitializeTabControl();

        // Form properties
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1280, 800);
        MinimumSize = new Size(900, 600);
        Text = "PodcastUniverseEditor";
        Controls.Add(tabMain);
        Controls.Add(toolMain);
        Controls.Add(menuMain);
        Controls.Add(statusMain);
        MainMenuStrip = menuMain;

        ResumeLayout(false);
        PerformLayout();
    }

    // ── Menu ─────────────────────────────────────────────────────────────────

    private void InitializeMenuStrip()
    {
        menuMain = new MenuStrip { Name = "menuMain" };

        mnuFile         = new ToolStripMenuItem { Name = "mnuFile",       Text = "&File" };
        mnuFileNew      = new ToolStripMenuItem { Name = "mnuFileNew",    Text = "&New Project\tCtrl+N" };
        mnuFileOpen     = new ToolStripMenuItem { Name = "mnuFileOpen",   Text = "&Open...\tCtrl+O" };
        mnuFileSave     = new ToolStripMenuItem { Name = "mnuFileSave",   Text = "&Save\tCtrl+S" };
        mnuFileSaveAs   = new ToolStripMenuItem { Name = "mnuFileSaveAs", Text = "Save &As..." };
        mnuFileExit     = new ToolStripMenuItem { Name = "mnuFileExit",   Text = "E&xit" };

        mnuFileNew.ShortcutKeys  = Keys.Control | Keys.N;
        mnuFileOpen.ShortcutKeys = Keys.Control | Keys.O;
        mnuFileSave.ShortcutKeys = Keys.Control | Keys.S;

        mnuFileNew.Click    += mnuFileNew_Click;
        mnuFileOpen.Click   += mnuFileOpen_Click;
        mnuFileSave.Click   += mnuFileSave_Click;
        mnuFileSaveAs.Click += mnuFileSaveAs_Click;
        mnuFileExit.Click   += mnuFileExit_Click;

        mnuFile.DropDownItems.AddRange(new ToolStripItem[]
        {
            mnuFileNew, mnuFileOpen,
            new ToolStripSeparator(),
            mnuFileSave, mnuFileSaveAs,
            new ToolStripSeparator(),
            mnuFileExit
        });

        menuMain.Items.Add(mnuFile);
    }

    // ── ToolStrip ────────────────────────────────────────────────────────────

    private void InitializeToolStrip()
    {
        toolMain = new ToolStrip { Name = "toolMain" };

        btnNewProject  = new ToolStripButton { Name = "btnNewProject",  Text = "New",  ToolTipText = "New Project" };
        btnOpenProject = new ToolStripButton { Name = "btnOpenProject", Text = "Open", ToolTipText = "Open Project" };
        btnSaveProject = new ToolStripButton { Name = "btnSaveProject", Text = "Save", ToolTipText = "Save Project" };

        btnNewProject.Click  += btnNewProject_Click;
        btnOpenProject.Click += btnOpenProject_Click;
        btnSaveProject.Click += btnSaveProject_Click;

        toolMain.Items.AddRange(new ToolStripItem[]
        {
            btnNewProject,
            btnOpenProject,
            new ToolStripSeparator(),
            btnSaveProject
        });
    }

    // ── StatusStrip ──────────────────────────────────────────────────────────

    private void InitializeStatusStrip()
    {
        statusMain   = new StatusStrip { Name = "statusMain" };
        lblStatus    = new ToolStripStatusLabel { Name = "lblStatus",      Text = "Ready", Spring = false };
        lblCurrentFile = new ToolStripStatusLabel { Name = "lblCurrentFile", Text = string.Empty, Spring = true, TextAlign = ContentAlignment.MiddleRight };

        statusMain.Items.AddRange(new ToolStripItem[] { lblStatus, lblCurrentFile });
    }

    // ── TabControl ───────────────────────────────────────────────────────────

    private void InitializeTabControl()
    {
        tabMain = new TabControl { Name = "tabMain", Dock = DockStyle.Fill };

        tabOverview                 = new TabPage { Name = "tabOverview",                 Text = "Overview" };
        tabReferenceData            = new TabPage { Name = "tabReferenceData",            Text = "Reference Data" };
        tabSystemsBodies            = new TabPage { Name = "tabSystemsBodies",            Text = "Systems & Bodies" };
        tabStationsDocks            = new TabPage { Name = "tabStationsDocks",            Text = "Stations & Docks" };
        tabRoutes                   = new TabPage { Name = "tabRoutes",                   Text = "Routes" };
        tabCommodities              = new TabPage { Name = "tabCommodities",              Text = "Commodities" };
        tabOrganisationsDirectives  = new TabPage { Name = "tabOrganisationsDirectives",  Text = "Orgs & Directives" };
        tabVessels                  = new TabPage { Name = "tabVessels",                  Text = "Vessels" };
        tabThreads                  = new TabPage { Name = "tabThreads",                  Text = "Threads" };
        tabEpisodes                 = new TabPage { Name = "tabEpisodes",                 Text = "Episodes" };
        tabOutputPreview            = new TabPage { Name = "tabOutputPreview",            Text = "Output Preview" };
        tabValidation               = new TabPage { Name = "tabValidation",               Text = "Validation" };

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

        tabMain.TabPages.AddRange(new TabPage[]
        {
            tabOverview, tabReferenceData, tabSystemsBodies, tabStationsDocks,
            tabRoutes, tabCommodities, tabOrganisationsDirectives, tabVessels,
            tabThreads, tabEpisodes, tabOutputPreview, tabValidation
        });
    }

    // ── Tab: Overview ────────────────────────────────────────────────────────

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

    // ── Tab: Reference Data ──────────────────────────────────────────────────

    private void InitializeTabReferenceData()
    {
        splitReferenceData = new SplitContainer
        {
            Name = "splitReferenceData",
            Dock = DockStyle.Fill,
            Orientation = Orientation.Vertical,
            SplitterDistance = 220,
            Panel1MinSize = 150
        };

        lstReferenceTypes = new ListBox
        {
            Name = "lstReferenceTypes",
            Dock = DockStyle.Fill,
            IntegralHeight = false
        };
        lstReferenceTypes.SelectedIndexChanged += lstReferenceTypes_SelectedIndexChanged;
        splitReferenceData.Panel1.Controls.Add(lstReferenceTypes);

        var rightPanel = new Panel { Dock = DockStyle.Fill };

        var btnPanel = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(4) };
        btnReferenceAdd    = new Button { Name = "btnReferenceAdd",    Text = "Add",    Width = 70, Dock = DockStyle.Left };
        btnReferenceDelete = new Button { Name = "btnReferenceDelete", Text = "Delete", Width = 70, Dock = DockStyle.Left };
        btnReferenceAdd.Click    += btnReferenceAdd_Click;
        btnReferenceDelete.Click += btnReferenceDelete_Click;
        btnPanel.Controls.AddRange(new Control[] { btnReferenceDelete, btnReferenceAdd });

        gridReferenceItems = new DataGridView
        {
            Name = "gridReferenceItems",
            Dock = DockStyle.Fill,
            AutoGenerateColumns = true,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false
        };

        rightPanel.Controls.Add(gridReferenceItems);
        rightPanel.Controls.Add(btnPanel);
        splitReferenceData.Panel2.Controls.Add(rightPanel);
        tabReferenceData.Controls.Add(splitReferenceData);
    }

    // ── Tab: Systems & Bodies ────────────────────────────────────────────────

    private void InitializeTabSystemsBodies()
    {
        splitSystemsBodies = new SplitContainer
        {
            Name = "splitSystemsBodies",
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal
        };

        var pnlSystems = BuildLabelledGridPanel("Star Systems", out gridStarSystems, "gridStarSystems");
        var pnlBodies  = BuildLabelledGridPanel("Celestial Bodies", out gridCelestialBodies, "gridCelestialBodies");

        splitSystemsBodies.Panel1.Controls.Add(pnlSystems);
        splitSystemsBodies.Panel2.Controls.Add(pnlBodies);
        tabSystemsBodies.Controls.Add(splitSystemsBodies);
    }

    // ── Tab: Stations & Docks ────────────────────────────────────────────────

    private void InitializeTabStationsDocks()
    {
        splitStationsDocks = new SplitContainer
        {
            Name = "splitStationsDocks",
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal
        };

        var pnlStations = BuildLabelledGridPanel("Stations", out gridStations, "gridStations");
        var pnlDocks    = BuildLabelledGridPanel("Docks", out gridDocks, "gridDocks");

        splitStationsDocks.Panel1.Controls.Add(pnlStations);
        splitStationsDocks.Panel2.Controls.Add(pnlDocks);
        tabStationsDocks.Controls.Add(splitStationsDocks);
    }

    // ── Tab: Routes ──────────────────────────────────────────────────────────

    private void InitializeTabRoutes()
    {
        gridRoutes = BuildStandaloneGrid("gridRoutes");
        tabRoutes.Controls.Add(gridRoutes);
    }

    // ── Tab: Commodities ─────────────────────────────────────────────────────

    private void InitializeTabCommodities()
    {
        gridCommodities = BuildStandaloneGrid("gridCommodities");
        tabCommodities.Controls.Add(gridCommodities);
    }

    // ── Tab: Organisations & Directives ──────────────────────────────────────

    private void InitializeTabOrganisationsDirectives()
    {
        splitOrganisationsDirectives = new SplitContainer
        {
            Name = "splitOrganisationsDirectives",
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal
        };

        var pnlOrgs      = BuildLabelledGridPanel("Organisations", out gridOrganisations, "gridOrganisations");
        var pnlDirectives = BuildLabelledGridPanel("Directives",   out gridDirectives,    "gridDirectives");

        splitOrganisationsDirectives.Panel1.Controls.Add(pnlOrgs);
        splitOrganisationsDirectives.Panel2.Controls.Add(pnlDirectives);
        tabOrganisationsDirectives.Controls.Add(splitOrganisationsDirectives);
    }

    // ── Tab: Vessels ─────────────────────────────────────────────────────────

    private void InitializeTabVessels()
    {
        gridVessels = BuildStandaloneGrid("gridVessels");
        tabVessels.Controls.Add(gridVessels);
    }

    // ── Tab: Threads ─────────────────────────────────────────────────────────

    private void InitializeTabThreads()
    {
        splitThreads = new SplitContainer
        {
            Name = "splitThreads",
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal
        };

        var pnlThreads = BuildLabelledGridPanel("Story Threads", out gridThreads,      "gridThreads");
        gridThreads.SelectionChanged += gridThreads_SelectionChanged;

        var pnlBeats   = BuildLabelledGridPanel("Beats",         out gridThreadBeats,  "gridThreadBeats");

        splitThreads.Panel1.Controls.Add(pnlThreads);
        splitThreads.Panel2.Controls.Add(pnlBeats);
        tabThreads.Controls.Add(splitThreads);
    }

    // ── Tab: Episodes ────────────────────────────────────────────────────────

    private void InitializeTabEpisodes()
    {
        splitEpisodesMain = new SplitContainer
        {
            Name = "splitEpisodesMain",
            Dock = DockStyle.Fill,
            Orientation = Orientation.Vertical,
            SplitterDistance = 240,
            Panel1MinSize = 160
        };

        // Left panel — split vertically: series list (top) + episode list (bottom)
        splitSeriesEpisodes = new SplitContainer
        {
            Name = "splitSeriesEpisodes",
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal,
            SplitterDistance = 140,
            Panel1MinSize = 80
        };

        // Series section (top of left)
        var seriesPanel = new Panel { Dock = DockStyle.Fill };
        var lblSeries = new Label { Text = "Series", Dock = DockStyle.Top, Height = 20, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };
        var seriesButtonsPanel = new Panel { Dock = DockStyle.Bottom, Height = 30, Padding = new Padding(4) };
        btnSeriesAdd    = new Button { Name = "btnSeriesAdd",    Text = "Add",    Width = 70, Dock = DockStyle.Left };
        btnSeriesDelete = new Button { Name = "btnSeriesDelete", Text = "Delete", Width = 70, Dock = DockStyle.Left };
        btnSeriesAdd.Click    += btnSeriesAdd_Click;
        btnSeriesDelete.Click += btnSeriesDelete_Click;
        seriesButtonsPanel.Controls.AddRange(new Control[] { btnSeriesDelete, btnSeriesAdd });
        lstSeries = new ListBox { Name = "lstSeries", Dock = DockStyle.Fill, IntegralHeight = false };
        lstSeries.SelectedIndexChanged += lstSeries_SelectedIndexChanged;
        seriesPanel.Controls.Add(lstSeries);
        seriesPanel.Controls.Add(lblSeries);
        seriesPanel.Controls.Add(seriesButtonsPanel);
        splitSeriesEpisodes.Panel1.Controls.Add(seriesPanel);

        // Episode section (bottom of left)
        var leftPanel = new Panel { Dock = DockStyle.Fill };
        var leftButtons = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(4) };
        btnEpisodeAdd    = new Button { Name = "btnEpisodeAdd",    Text = "Add",    Width = 70, Dock = DockStyle.Left };
        btnEpisodeDelete = new Button { Name = "btnEpisodeDelete", Text = "Delete", Width = 70, Dock = DockStyle.Left };
        btnEpisodeAdd.Click    += btnEpisodeAdd_Click;
        btnEpisodeDelete.Click += btnEpisodeDelete_Click;
        leftButtons.Controls.AddRange(new Control[] { btnEpisodeDelete, btnEpisodeAdd });

        var episodeActionsPanel = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(4) };
        btnEpisodeDuplicate        = new Button { Name = "btnEpisodeDuplicate",        Text = "Dup",   Width = 46, Dock = DockStyle.Left };
        btnNewEpisodeAfterSelected = new Button { Name = "btnNewEpisodeAfterSelected", Text = "Ins",   Width = 40, Dock = DockStyle.Left };
        btnLockEpisodeCanon        = new Button { Name = "btnLockEpisodeCanon",        Text = "Lock",  Width = 48, Dock = DockStyle.Left };
        btnUnlockEpisodeCanon      = new Button { Name = "btnUnlockEpisodeCanon",      Text = "Unlock",Width = 56, Dock = DockStyle.Left };
        btnEpisodeDuplicate.Click        += btnEpisodeDuplicate_Click;
        btnNewEpisodeAfterSelected.Click += btnNewEpisodeAfterSelected_Click;
        btnLockEpisodeCanon.Click        += btnLockEpisodeCanon_Click;
        btnUnlockEpisodeCanon.Click      += btnUnlockEpisodeCanon_Click;
        episodeActionsPanel.Controls.AddRange(new Control[] { btnEpisodeDuplicate, btnNewEpisodeAfterSelected, btnLockEpisodeCanon, btnUnlockEpisodeCanon });

        txtEpisodeSummary = new TextBox
        {
            Name = "txtEpisodeSummary",
            Dock = DockStyle.Bottom,
            Height = 70,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            BackColor = SystemColors.ControlLight
        };

        lstEpisodes = new ListBox
        {
            Name = "lstEpisodes",
            Dock = DockStyle.Fill,
            IntegralHeight = false
        };
        lstEpisodes.SelectedIndexChanged += lstEpisodes_SelectedIndexChanged;

        txtEpisodeSearch = new TextBox { Name = "txtEpisodeSearch", Dock = DockStyle.Top, PlaceholderText = "Search episodes..." };
        txtEpisodeSearch.TextChanged += txtEpisodeSearch_TextChanged;

        var lblEpisodes = new Label { Text = "Episodes", Dock = DockStyle.Top, Height = 20, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };
        leftPanel.Controls.Add(lstEpisodes);
        leftPanel.Controls.Add(lblEpisodes);
        leftPanel.Controls.Add(txtEpisodeSearch);
        leftPanel.Controls.Add(txtEpisodeSummary);
        leftPanel.Controls.Add(BuildEpisodeMetaPanel());
        leftPanel.Controls.Add(episodeActionsPanel);
        leftPanel.Controls.Add(leftButtons);

        // Right panel — splitEpisodesRight splits grid (top) from detail+preview (bottom)
        splitEpisodesRight = new SplitContainer
        {
            Name = "splitEpisodesRight",
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal,
            SplitterDistance = 200,
            Panel2MinSize = 120
        };

        // Top of right: entry grid + label + buttons
        var gridPanel = new Panel { Dock = DockStyle.Fill };
        var entryButtonsPanel = new Panel { Dock = DockStyle.Bottom, Height = 108 };

        // Row 1 (top) — manual entry management
        // DockStyle.Left: last added = leftmost; AddRange order reversed to get desired visual order:
        //   [Add Traffic] [Add Notice] [Delete] [▲] [▼]  (left to right)
        var entryRow1 = new Panel { Dock = DockStyle.Top, Height = 32, Padding = new Padding(2) };
        btnEntryAdd         = new Button { Name = "btnEntryAdd",         Text = "Add Traffic", Width = 90, Dock = DockStyle.Left };
        btnNoticeEntryAdd   = new Button { Name = "btnNoticeEntryAdd",   Text = "Add Notice",  Width = 90, Dock = DockStyle.Left };
        btnEntryDuplicate   = new Button { Name = "btnEntryDuplicate",   Text = "Duplicate",   Width = 76, Dock = DockStyle.Left };
        btnEntryDelete      = new Button { Name = "btnEntryDelete",      Text = "Delete",      Width = 70, Dock = DockStyle.Left };
        btnEntryMoveUp      = new Button { Name = "btnEntryMoveUp",      Text = "▲",           Width = 34, Dock = DockStyle.Left };
        btnEntryMoveDown    = new Button { Name = "btnEntryMoveDown",    Text = "▼",           Width = 34, Dock = DockStyle.Left };
        btnEntryAdd.Click         += btnEntryAdd_Click;
        btnNoticeEntryAdd.Click   += btnNoticeEntryAdd_Click;
        btnEntryDuplicate.Click   += btnEntryDuplicate_Click;
        btnEntryDelete.Click      += btnEntryDelete_Click;
        btnEntryMoveUp.Click      += btnEntryMoveUp_Click;
        btnEntryMoveDown.Click    += btnEntryMoveDown_Click;
        // Reversed order so visual left-to-right is: Add Traffic | Add Notice | Duplicate | Delete | ▲ | ▼
        entryRow1.Controls.AddRange(new Control[] { btnEntryMoveDown, btnEntryMoveUp, btnEntryDelete, btnEntryDuplicate, btnNoticeEntryAdd, btnEntryAdd });

        // Row 2 (bottom) — generation controls
        var entryRow2 = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(2) };
        btnGenerateEntry           = new Button { Name = "btnGenerateEntry",           Text = "Gen Entry",    Width = 80, Dock = DockStyle.Left };
        btnGenerateEpisodeEntries  = new Button { Name = "btnGenerateEpisodeEntries",  Text = "Fill Episode", Width = 88, Dock = DockStyle.Left };
        btnRegenerateSelectedEntry = new Button { Name = "btnRegenerateSelectedEntry", Text = "Regen",        Width = 56, Dock = DockStyle.Left };
        numGenerateEntryCount = new NumericUpDown
        {
            Name = "numGenerateEntryCount", Width = 50, Dock = DockStyle.Left,
            Minimum = 1, Maximum = 100, Value = 5
        };
        chkClearEpisodeBeforeGenerate = new CheckBox
        {
            Name = "chkClearEpisodeBeforeGenerate", Text = "Clear", Width = 52,
            Dock = DockStyle.Left, Checked = false, TextAlign = ContentAlignment.MiddleLeft
        };
        var lblSeed = new Label { Text = "Seed:", Width = 36, Dock = DockStyle.Left, TextAlign = ContentAlignment.MiddleLeft };
        txtGenerationSeed = new TextBox { Name = "txtGenerationSeed", Width = 64, Dock = DockStyle.Left };

        btnGenerateEntry.Click           += btnGenerateEntry_Click;
        btnGenerateEpisodeEntries.Click  += btnGenerateEpisodeEntries_Click;
        btnRegenerateSelectedEntry.Click += btnRegenerateSelectedEntry_Click;

        chkRegenerateWithoutAdvancingThread = new CheckBox
        {
            Name = "chkRegenerateWithoutAdvancingThread", Text = "Edit mode", Width = 76,
            Dock = DockStyle.Left, Checked = true, TextAlign = ContentAlignment.MiddleLeft
        };

        entryRow2.Controls.AddRange(new Control[]
        {
            btnGenerateEntry, btnGenerateEpisodeEntries, btnRegenerateSelectedEntry,
            numGenerateEntryCount, chkClearEpisodeBeforeGenerate, lblSeed, txtGenerationSeed,
            chkRegenerateWithoutAdvancingThread
        });

        // Row 3 (export controls) — added before row2 so row2 stacks above it (both DockStyle.Bottom)
        var entryRow3 = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(2) };
        btnExportEpisodeText  = new Button { Name = "btnExportEpisodeText",  Text = "Broadcast", Width = 76, Dock = DockStyle.Left };
        btnExportEpisodeTts   = new Button { Name = "btnExportEpisodeTts",   Text = "TTS",       Width = 48, Dock = DockStyle.Left };
        btnExportEpisodeJson  = new Button { Name = "btnExportEpisodeJson",  Text = "JSON",      Width = 52, Dock = DockStyle.Left };
        chkExportIncludeHeader            = new CheckBox { Name = "chkExportIncludeHeader",            Text = "Header",  Width = 58, Dock = DockStyle.Left, Checked = true,  TextAlign = ContentAlignment.MiddleLeft };
        chkExportBlankLineBetweenEntries  = new CheckBox { Name = "chkExportBlankLineBetweenEntries",  Text = "Blanks",  Width = 52, Dock = DockStyle.Left, Checked = true,  TextAlign = ContentAlignment.MiddleLeft };
        chkExportIncludeEntryMarkers      = new CheckBox { Name = "chkExportIncludeEntryMarkers",      Text = "Markers", Width = 60, Dock = DockStyle.Left, Checked = false, TextAlign = ContentAlignment.MiddleLeft };
        chkExportAuthorDebugMode          = new CheckBox { Name = "chkExportAuthorDebugMode",          Text = "Debug",   Width = 52, Dock = DockStyle.Left, Checked = false, TextAlign = ContentAlignment.MiddleLeft };

        btnExportEpisodeText.Click  += btnExportEpisodeText_Click;
        btnExportEpisodeTts.Click   += btnExportEpisodeTts_Click;
        btnExportEpisodeJson.Click  += btnExportEpisodeJson_Click;

        entryRow3.Controls.AddRange(new Control[]
        {
            btnExportEpisodeText, btnExportEpisodeTts, btnExportEpisodeJson,
            chkExportIncludeHeader, chkExportBlankLineBetweenEntries,
            chkExportIncludeEntryMarkers, chkExportAuthorDebugMode
        });

        entryButtonsPanel.Controls.Add(entryRow1);
        entryButtonsPanel.Controls.Add(entryRow3);  // added before row2: DockStyle.Bottom stacks → row3=bottommost, row2=above
        entryButtonsPanel.Controls.Add(entryRow2);

        var lblEntries = new Label { Text = "Entries", Dock = DockStyle.Top, Height = 20, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };

        var entryFilterPanel = new Panel { Dock = DockStyle.Top, Height = 58, Padding = new Padding(1) };

        // Row 1: free-text search + kind filter
        var filterRow1 = new Panel { Dock = DockStyle.Top, Height = 27 };
        var lblEntrySearch = new Label { Text = "Search:", Width = 50, Dock = DockStyle.Left, TextAlign = ContentAlignment.MiddleLeft };
        var lblEntryKind   = new Label { Text = "Kind:", Width = 36, Dock = DockStyle.Right, TextAlign = ContentAlignment.MiddleRight };
        cboEntryFilterKind = new ComboBox { Name = "cboEntryFilterKind", Dock = DockStyle.Right, Width = 110, DropDownStyle = ComboBoxStyle.DropDownList };
        txtEntrySearch     = new TextBox  { Name = "txtEntrySearch", Dock = DockStyle.Fill };

        cboEntryFilterKind.SelectedIndexChanged += cboEntryFilterKind_SelectedIndexChanged;
        txtEntrySearch.TextChanged              += txtEntrySearch_TextChanged;

        filterRow1.Controls.Add(lblEntryKind);        // Right, first → left of kind combo
        filterRow1.Controls.Add(cboEntryFilterKind);  // Right, last  → rightmost
        filterRow1.Controls.Add(lblEntrySearch);       // Left         → leftmost
        filterRow1.Controls.Add(txtEntrySearch);       // Fill         → remaining space

        // Row 2: vessel filter, station filter, locked-only checkbox, clear button
        var filterRow2 = new Panel { Dock = DockStyle.Top, Height = 27 };
        cboEntryFilterVessel  = new ComboBox { Name = "cboEntryFilterVessel",  Dock = DockStyle.Fill,  DropDownStyle = ComboBoxStyle.DropDownList };
        cboEntryFilterStation = new ComboBox { Name = "cboEntryFilterStation", Dock = DockStyle.Right, Width = 130, DropDownStyle = ComboBoxStyle.DropDownList };
        chkShowLockedOnly     = new CheckBox { Name = "chkShowLockedOnly", Text = "Locked", Dock = DockStyle.Right, Width = 60, TextAlign = ContentAlignment.MiddleLeft };
        btnClearEntryFilters  = new Button   { Name = "btnClearEntryFilters",  Dock = DockStyle.Right, Width = 52, Text = "Clear" };

        cboEntryFilterVessel.SelectedIndexChanged  += cboEntryFilterVessel_SelectedIndexChanged;
        cboEntryFilterStation.SelectedIndexChanged += cboEntryFilterStation_SelectedIndexChanged;
        chkShowLockedOnly.CheckedChanged           += chkShowLockedOnly_CheckedChanged;
        btnClearEntryFilters.Click                 += btnClearEntryFilters_Click;

        filterRow2.Controls.Add(cboEntryFilterStation); // Right, first → leftmost of right group
        filterRow2.Controls.Add(chkShowLockedOnly);      // Right, second
        filterRow2.Controls.Add(btnClearEntryFilters);   // Right, last  → rightmost
        filterRow2.Controls.Add(cboEntryFilterVessel);   // Fill         → left side

        // For DockStyle.Top: last added = topmost; add row2 first so row1 lands on top
        entryFilterPanel.Controls.Add(filterRow2);
        entryFilterPanel.Controls.Add(filterRow1);

        gridEpisodeEntries = new DataGridView
        {
            Name = "gridEpisodeEntries",
            Dock = DockStyle.Fill,
            AutoGenerateColumns = false,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false
        };
        gridEpisodeEntries.SelectionChanged += gridEpisodeEntries_SelectionChanged;

        gridPanel.Controls.Add(gridEpisodeEntries);
        gridPanel.Controls.Add(lblEntries);
        gridPanel.Controls.Add(entryFilterPanel);
        gridPanel.Controls.Add(entryButtonsPanel);

        // Bottom of right: scrollable detail panel + thread summary + preview at bottom
        var detailArea = new Panel { Dock = DockStyle.Fill };

        txtEpisodeEntryPreview = new TextBox
        {
            Name = "txtEpisodeEntryPreview",
            Dock = DockStyle.Bottom,
            Height = 100,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            BackColor = SystemColors.ControlLight
        };

        txtThreadSummary = new TextBox
        {
            Name = "txtThreadSummary",
            Dock = DockStyle.Bottom,
            Height = 80,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            BackColor = SystemColors.Info
        };

        pnlEntryDetail = BuildEntryDetailPanel();

        detailArea.Controls.Add(pnlEntryDetail);
        detailArea.Controls.Add(txtThreadSummary);
        detailArea.Controls.Add(txtEpisodeEntryPreview);

        splitEpisodesRight.Panel1.Controls.Add(gridPanel);
        splitEpisodesRight.Panel2.Controls.Add(detailArea);

        splitSeriesEpisodes.Panel2.Controls.Add(leftPanel);
        splitEpisodesMain.Panel1.Controls.Add(splitSeriesEpisodes);
        splitEpisodesMain.Panel2.Controls.Add(splitEpisodesRight);
        tabEpisodes.Controls.Add(splitEpisodesMain);
    }

    /// <summary>
    /// Builds the scrollable entry-detail panel containing all named entry editor controls.
    /// All named controls (cboEntryKind, txtEntryName, etc.) are assigned to their fields here.
    /// Returns the scroll Panel — caller assigns it to pnlEntryDetail.
    /// </summary>
    private Panel BuildEntryDetailPanel()
    {
        var scroll = new Panel
        {
            Name = "pnlEntryDetail",
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Enabled = false
        };

        var tbl = new TableLayoutPanel
        {
            Name = "tblEntryDetail",
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 2,
            Padding = new Padding(4, 4, 4, 8)
        };
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        int row = 0;

        void AddRow(string labelText, Control ctrl, int height = 28)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            var lbl = new Label { Text = labelText, Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true, Padding = new Padding(0, 4, 0, 0) };
            tbl.Controls.Add(lbl, 0, row);
            ctrl.Dock = DockStyle.Fill;
            tbl.Controls.Add(ctrl, 1, row);
            tbl.RowCount = ++row;
        }

        void AddSection(string title)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
            var lbl = new Label
            {
                Text = title,
                Dock = DockStyle.Fill,
                Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold),
                ForeColor = SystemColors.ControlDarkDark,
                Padding = new Padding(0, 6, 0, 0)
            };
            tbl.Controls.Add(lbl, 0, row);
            tbl.SetColumnSpan(lbl, 2);
            tbl.RowCount = ++row;
        }

        // ── Entry ──────────────────────────────────────────────────────────

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
        AddRow("Notes:", txtEntryNotes, 64);

        // ── Operation / Notice ─────────────────────────────────────────────

        AddSection("Operation / Notice");

        cboEntryOperationType = new ComboBox { Name = "cboEntryOperationType", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Operation Type:", cboEntryOperationType);

        cboEntryNoticeType = new ComboBox { Name = "cboEntryNoticeType", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Notice Type:", cboEntryNoticeType);

        // ── Location ───────────────────────────────────────────────────────

        AddSection("Location");

        cboEntryStation = new ComboBox { Name = "cboEntryStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Station:", cboEntryStation);

        cboEntryDock = new ComboBox { Name = "cboEntryDock", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Dock:", cboEntryDock);

        cboEntryOriginStation = new ComboBox { Name = "cboEntryOriginStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Origin Station:", cboEntryOriginStation);

        cboEntryDestinationStation = new ComboBox { Name = "cboEntryDestinationStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Destination Station:", cboEntryDestinationStation);

        // ── Vessel ─────────────────────────────────────────────────────────

        AddSection("Vessel");

        cboEntryVessel = new ComboBox { Name = "cboEntryVessel", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Vessel:", cboEntryVessel);

        cboEntryVesselClassOverride = new ComboBox { Name = "cboEntryVesselClassOverride", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Class Override:", cboEntryVesselClassOverride);

        txtEntryRegistryOverride = new TextBox { Name = "txtEntryRegistryOverride" };
        AddRow("Registry Override:", txtEntryRegistryOverride);

        // ── Purpose ────────────────────────────────────────────────────────

        AddSection("Purpose");

        cboEntryDeclaredPurpose = new ComboBox { Name = "cboEntryDeclaredPurpose", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Declared Purpose:", cboEntryDeclaredPurpose);

        cboEntryActualPurpose = new ComboBox { Name = "cboEntryActualPurpose", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Actual Purpose:", cboEntryActualPurpose);

        // ── Statuses ───────────────────────────────────────────────────────

        AddSection("Statuses");

        cboEntryManifestStatus = new ComboBox { Name = "cboEntryManifestStatus", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Manifest Status:", cboEntryManifestStatus);

        cboEntryInspectionStatus = new ComboBox { Name = "cboEntryInspectionStatus", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Inspection Status:", cboEntryInspectionStatus);

        cboEntryClearanceStatus = new ComboBox { Name = "cboEntryClearanceStatus", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Clearance Status:", cboEntryClearanceStatus);

        cboEntryEnvironmentalCondition = new ComboBox { Name = "cboEntryEnvironmentalCondition", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Environment:", cboEntryEnvironmentalCondition);

        // ── Narrative ──────────────────────────────────────────────────────

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
        AddRow("Public Body Override:", txtEntryPublicBodyOverride, 64);

        // ── Story Thread ───────────────────────────────────────────────────

        AddSection("Story Thread");

        cboEntryStoryThread = new ComboBox { Name = "cboEntryStoryThread", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Story Thread:", cboEntryStoryThread);

        cboEntryAppliedStoryBeat = new ComboBox { Name = "cboEntryAppliedStoryBeat", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Story Beat:", cboEntryAppliedStoryBeat);

        cboEntryAnomalySeverity = new ComboBox { Name = "cboEntryAnomalySeverity", DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Anomaly Severity:", cboEntryAnomalySeverity);

        // ── Hidden Truth ───────────────────────────────────────────────────

        AddSection("Hidden Truth");

        txtEntryHiddenTruthNotes = new TextBox { Name = "txtEntryHiddenTruthNotes", Multiline = true, ScrollBars = ScrollBars.Vertical };
        AddRow("Hidden Truth Notes:", txtEntryHiddenTruthNotes, 64);

        // ── Schedule ───────────────────────────────────────────────────────

        AddSection("Schedule");

        var schedPanel = new Panel();
        chkEntryScheduledEnabled = new CheckBox { Name = "chkEntryScheduledEnabled", Width = 22, Location = new Point(0, 5) };
        dtpEntryScheduledUtc     = new DateTimePicker { Name = "dtpEntryScheduledUtc", Enabled = false, Location = new Point(26, 2), Width = 200, Format = DateTimePickerFormat.Short };
        schedPanel.Controls.AddRange(new Control[] { chkEntryScheduledEnabled, dtpEntryScheduledUtc });
        AddRow("Scheduled (UTC):", schedPanel);

        // ── Manifest grids ─────────────────────────────────────────────────────

        void AddFullRow(DataGridView grid, Button btnAdd, Button btnDel, int gridHeight)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, gridHeight + 32));
            var container = new Panel();
            btnAdd.Text = "Add";    btnAdd.Width = 60; btnAdd.Dock = DockStyle.Left;
            btnDel.Text = "Delete"; btnDel.Width = 60; btnDel.Dock = DockStyle.Left;
            var btnPanel = new Panel { Dock = DockStyle.Bottom, Height = 28, Padding = new Padding(2) };
            btnPanel.Controls.AddRange(new Control[] { btnAdd, btnDel });
            grid.Dock = DockStyle.Fill;
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.DataError += (s, e) => e.Cancel = true;
            container.Controls.Add(grid);
            container.Controls.Add(btnPanel);
            container.Dock = DockStyle.Fill;
            tbl.Controls.Add(container, 0, row);
            tbl.SetColumnSpan(container, 2);
            tbl.RowCount = ++row;
        }

        AddSection("Declared Cargo");
        gridDeclaredCargo      = new DataGridView { Name = "gridDeclaredCargo" };
        btnDeclaredCargoAdd    = new Button { Name = "btnDeclaredCargoAdd" };
        btnDeclaredCargoDelete = new Button { Name = "btnDeclaredCargoDelete" };
        btnDeclaredCargoAdd.Click    += btnDeclaredCargoAdd_Click;
        btnDeclaredCargoDelete.Click += btnDeclaredCargoDelete_Click;
        AddFullRow(gridDeclaredCargo, btnDeclaredCargoAdd, btnDeclaredCargoDelete, 130);

        AddSection("Actual Cargo");
        gridActualCargo      = new DataGridView { Name = "gridActualCargo" };
        btnActualCargoAdd    = new Button { Name = "btnActualCargoAdd" };
        btnActualCargoDelete = new Button { Name = "btnActualCargoDelete" };
        btnActualCargoAdd.Click    += btnActualCargoAdd_Click;
        btnActualCargoDelete.Click += btnActualCargoDelete_Click;
        AddFullRow(gridActualCargo, btnActualCargoAdd, btnActualCargoDelete, 130);

        AddSection("Declared Passengers");
        gridDeclaredPassengers      = new DataGridView { Name = "gridDeclaredPassengers" };
        btnDeclaredPassengerAdd    = new Button { Name = "btnDeclaredPassengerAdd" };
        btnDeclaredPassengerDelete = new Button { Name = "btnDeclaredPassengerDelete" };
        btnDeclaredPassengerAdd.Click    += btnDeclaredPassengerAdd_Click;
        btnDeclaredPassengerDelete.Click += btnDeclaredPassengerDelete_Click;
        AddFullRow(gridDeclaredPassengers, btnDeclaredPassengerAdd, btnDeclaredPassengerDelete, 110);

        AddSection("Actual Passengers");
        gridActualPassengers      = new DataGridView { Name = "gridActualPassengers" };
        btnActualPassengerAdd    = new Button { Name = "btnActualPassengerAdd" };
        btnActualPassengerDelete = new Button { Name = "btnActualPassengerDelete" };
        btnActualPassengerAdd.Click    += btnActualPassengerAdd_Click;
        btnActualPassengerDelete.Click += btnActualPassengerDelete_Click;
        AddFullRow(gridActualPassengers, btnActualPassengerAdd, btnActualPassengerDelete, 110);

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

        scroll.Controls.Add(tbl);
        scroll.Controls.Add(flpValidationHints);
        return scroll;
    }

    // ── Episode metadata panel ───────────────────────────────────────────────

    /// <summary>
    /// Builds the scrollable episode/series metadata editing panel shown in the left panel.
    /// Assigned to pnlEpisodeMetaEditor. Contains controls for editing the selected
    /// EpisodeRecord and its associated PodcastSeriesRecord.
    /// </summary>
    private Panel BuildEpisodeMetaPanel()
    {
        pnlEpisodeMetaEditor = new Panel
        {
            Name = "pnlEpisodeMetaEditor",
            Dock = DockStyle.Bottom,
            Height = 260,
            AutoScroll = true,
            Enabled = false
        };

        var tbl = new TableLayoutPanel
        {
            Name = "tblEpisodeMeta",
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 2,
            Padding = new Padding(2, 2, 2, 4)
        };
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        int mRow = 0;

        void AddMetaRow(string labelText, Control ctrl, int height = 26)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            var lbl = new Label { Text = labelText, Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true, Padding = new Padding(0, 4, 0, 0) };
            tbl.Controls.Add(lbl, 0, mRow);
            ctrl.Dock = DockStyle.Fill;
            tbl.Controls.Add(ctrl, 1, mRow);
            tbl.RowCount = ++mRow;
        }

        void AddMetaSection(string title)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 22));
            var lbl = new Label
            {
                Text = title,
                Dock = DockStyle.Fill,
                Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold),
                ForeColor = SystemColors.ControlDarkDark,
                Padding = new Padding(0, 4, 0, 0)
            };
            tbl.Controls.Add(lbl, 0, mRow);
            tbl.SetColumnSpan(lbl, 2);
            tbl.RowCount = ++mRow;
        }

        // ── Episode section ────────────────────────────────────────────────

        AddMetaSection("Episode");

        txtEpisodeName = new TextBox { Name = "txtEpisodeName" };
        AddMetaRow("Name:", txtEpisodeName);

        var datePanel = new Panel();
        chkEpisodeHasInUniverseDate = new CheckBox { Name = "chkEpisodeHasInUniverseDate", Width = 20, Location = new Point(0, 5) };
        dtpEpisodeInUniverseUtc     = new DateTimePicker
        {
            Name = "dtpEpisodeInUniverseUtc",
            Enabled = false,
            Location = new Point(22, 2),
            Width = 120,
            Format = DateTimePickerFormat.Short,
            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
        };
        datePanel.Controls.AddRange(new Control[] { chkEpisodeHasInUniverseDate, dtpEpisodeInUniverseUtc });
        AddMetaRow("Date (UTC):", datePanel, 28);

        cboEpisodeBroadcastStation = new ComboBox { Name = "cboEpisodeBroadcastStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddMetaRow("Station:", cboEpisodeBroadcastStation);

        cboEpisodeSeries = new ComboBox { Name = "cboEpisodeSeries", DropDownStyle = ComboBoxStyle.DropDownList };
        AddMetaRow("Series:", cboEpisodeSeries);

        // AutoCheck = false: display-only. Use Lock/Unlock buttons to change canon state.
        chkEpisodeCanonicalLocked = new CheckBox { Name = "chkEpisodeCanonicalLocked", Text = "Canon Locked (use Lock/Unlock buttons)", AutoSize = true, AutoCheck = false };
        AddMetaRow("", chkEpisodeCanonicalLocked);

        txtEpisodeNotes = new TextBox { Name = "txtEpisodeNotes", Multiline = true, ScrollBars = ScrollBars.Vertical };
        AddMetaRow("Notes:", txtEpisodeNotes, 44);

        // ── Series section ─────────────────────────────────────────────────

        AddMetaSection("Series");

        txtSeriesName = new TextBox { Name = "txtSeriesName" };
        AddMetaRow("Name:", txtSeriesName);

        cboSeriesBroadcastStation = new ComboBox { Name = "cboSeriesBroadcastStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddMetaRow("Station:", cboSeriesBroadcastStation);

        txtSeriesNotes = new TextBox { Name = "txtSeriesNotes", Multiline = true, ScrollBars = ScrollBars.Vertical };
        AddMetaRow("Notes:", txtSeriesNotes, 44);

        pnlEpisodeMetaEditor.Controls.Add(tbl);
        return pnlEpisodeMetaEditor;
    }

    // ── Tab: Output Preview ──────────────────────────────────────────────────

    private void InitializeTabOutputPreview()
    {
        txtRenderedOutput = new TextBox
        {
            Name = "txtRenderedOutput",
            Dock = DockStyle.Fill,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            Font = new Font("Consolas", 10f)
        };
        tabOutputPreview.Controls.Add(txtRenderedOutput);
    }

    // ── Tab: Validation ──────────────────────────────────────────────────────

    private void InitializeTabValidation()
    {
        var panel = new Panel { Dock = DockStyle.Fill };
        var topBar = new Panel { Dock = DockStyle.Top, Height = 36, Padding = new Padding(4) };

        btnRunValidation = new Button { Name = "btnRunValidation", Text = "Run Validation", AutoSize = true, Dock = DockStyle.Left };
        btnRunValidation.Click += btnRunValidation_Click;
        topBar.Controls.Add(btnRunValidation);

        gridValidationMessages = new DataGridView
        {
            Name = "gridValidationMessages",
            Dock = DockStyle.Fill,
            AutoGenerateColumns = false,
            AllowUserToAddRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        SetupValidationGridColumns();

        panel.Controls.Add(gridValidationMessages);
        panel.Controls.Add(topBar);
        tabValidation.Controls.Add(panel);
    }

    private void SetupValidationGridColumns()
    {
        gridValidationMessages.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { Name = "colValSeverity",    HeaderText = "Severity",    DataPropertyName = "Severity",   Width = 80  },
            new DataGridViewTextBoxColumn { Name = "colValMessage",     HeaderText = "Message",     DataPropertyName = "Message",    Width = 360, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colValEntityType",  HeaderText = "Entity Type", DataPropertyName = "EntityType", Width = 140 },
            new DataGridViewTextBoxColumn { Name = "colValEntityId",    HeaderText = "Entity ID",   DataPropertyName = "EntityId",   Width = 140 },
            new DataGridViewTextBoxColumn { Name = "colValFieldName",   HeaderText = "Field",       DataPropertyName = "FieldName",  Width = 120 },
        });
    }

    // ── Layout helpers ───────────────────────────────────────────────────────

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

    // ── Control fields ───────────────────────────────────────────────────────

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
    private SplitContainer splitReferenceData = null!;
    private ListBox lstReferenceTypes = null!;
    private DataGridView gridReferenceItems = null!;
    private Button btnReferenceAdd = null!;
    private Button btnReferenceDelete = null!;

    // Systems & Bodies
    private SplitContainer splitSystemsBodies = null!;
    private DataGridView gridStarSystems = null!;
    private DataGridView gridCelestialBodies = null!;

    // Stations & Docks
    private SplitContainer splitStationsDocks = null!;
    private DataGridView gridStations = null!;
    private DataGridView gridDocks = null!;

    // Routes
    private DataGridView gridRoutes = null!;

    // Commodities
    private DataGridView gridCommodities = null!;

    // Organisations & Directives
    private SplitContainer splitOrganisationsDirectives = null!;
    private DataGridView gridOrganisations = null!;
    private DataGridView gridDirectives = null!;

    // Vessels
    private DataGridView gridVessels = null!;

    // Threads
    private SplitContainer splitThreads = null!;
    private DataGridView gridThreads = null!;
    private DataGridView gridThreadBeats = null!;

    // Episodes — list + grid
    private SplitContainer splitEpisodesMain = null!;
    private SplitContainer splitEpisodesRight = null!;
    private SplitContainer splitSeriesEpisodes = null!;
    private ListBox lstSeries = null!;
    private Button btnSeriesAdd = null!;
    private Button btnSeriesDelete = null!;
    private ListBox lstEpisodes = null!;
    private DataGridView gridEpisodeEntries = null!;
    private TextBox txtEpisodeEntryPreview = null!;
    private TextBox txtEpisodeSummary = null!;
    private TextBox txtEpisodeSearch = null!;
    private Button btnEpisodeAdd = null!;
    private Button btnEpisodeDelete = null!;
    private Button btnEpisodeDuplicate = null!;
    private Button btnNewEpisodeAfterSelected = null!;
    private Button btnLockEpisodeCanon = null!;
    private Button btnUnlockEpisodeCanon = null!;
    private Button btnEntryAdd         = null!;
    private Button btnNoticeEntryAdd   = null!;
    private Button btnEntryDuplicate   = null!;
    private Button btnEntryDelete      = null!;
    private Button btnEntryMoveUp      = null!;
    private Button btnEntryMoveDown    = null!;
    private Button btnGenerateEntry = null!;
    private Button btnGenerateEpisodeEntries = null!;
    private Button btnRegenerateSelectedEntry = null!;
    private NumericUpDown numGenerateEntryCount = null!;
    private CheckBox chkClearEpisodeBeforeGenerate = null!;
    private CheckBox chkRegenerateWithoutAdvancingThread = null!;
    private TextBox txtGenerationSeed = null!;
    private TextBox  txtEntrySearch        = null!;
    private ComboBox cboEntryFilterKind    = null!;
    private ComboBox cboEntryFilterVessel  = null!;
    private ComboBox cboEntryFilterStation = null!;
    private Button   btnClearEntryFilters  = null!;
    private CheckBox chkShowLockedOnly     = null!;

    // Episodes — entry detail panel (scrollable)
    private Panel pnlEntryDetail = null!;

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

    // Episodes — metadata editor (episode + series fields)
    private Panel        pnlEpisodeMetaEditor          = null!;
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

    // Episodes — export controls
    private Button   btnExportEpisodeText             = null!;
    private Button   btnExportEpisodeTts              = null!;
    private Button   btnExportEpisodeJson             = null!;
    private CheckBox chkExportIncludeHeader           = null!;
    private CheckBox chkExportBlankLineBetweenEntries = null!;
    private CheckBox chkExportIncludeEntryMarkers     = null!;
    private CheckBox chkExportAuthorDebugMode         = null!;

    // Output Preview
    private TextBox txtRenderedOutput = null!;

    // Validation
    private DataGridView gridValidationMessages = null!;
    private Button btnRunValidation = null!;
}
