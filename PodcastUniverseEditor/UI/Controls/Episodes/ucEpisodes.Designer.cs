namespace PodcastUniverseEditor.UI.Controls.Episodes;

partial class ucEpisodes
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        splitEpisodesMain = new SplitContainer();
        splitSeriesEpisodes = new SplitContainer();
        seriesPanel = new Panel();
        lstSeries = new ListBox();
        lblSeries = new Label();
        seriesButtonsPanel = new Panel();
        btnSeriesDuplicate = new Button();
        btnSeriesDelete = new Button();
        btnSeriesAdd = new Button();
        leftPanel = new Panel();
        lstEpisodes = new ListBox();
        lblEpisodes = new Label();
        txtEpisodeSearch = new TextBox();
        txtEpisodeSummary = new TextBox();
        ucMetaEditor = new ucEpisodeMetaEditor();
        episodeActionsPanel = new Panel();
        btnEpisodeMoveDown = new Button();
        btnEpisodeMoveUp = new Button();
        btnEpisodeDuplicate = new Button();
        btnNewEpisodeAfterSelected = new Button();
        btnLockEpisodeCanon = new Button();
        btnUnlockEpisodeCanon = new Button();
        leftButtons = new Panel();
        btnEpisodeDelete = new Button();
        btnEpisodeAdd = new Button();
        splitEpisodesRight = new SplitContainer();
        gridPanel = new Panel();
        gridEpisodeEntries = new DataGridView();
        lblEntries = new Label();
        entryFilterPanel = new Panel();
        filterRow2 = new Panel();
        cboEntryFilterStation = new ComboBox();
        chkShowLockedOnly = new CheckBox();
        btnClearEntryFilters = new Button();
        cboEntryFilterVessel = new ComboBox();
        filterRow1 = new Panel();
        lblEntryKind = new Label();
        cboEntryFilterKind = new ComboBox();
        lblEntrySearch = new Label();
        txtEntrySearch = new TextBox();
        entryButtonsPanel = new Panel();
        entryRow1 = new Panel();
        btnEntryMoveDown = new Button();
        btnEntryMoveUp = new Button();
        btnEntryDelete = new Button();
        btnEntryDuplicate = new Button();
        btnNoticeEntryAdd = new Button();
        btnEntryAdd = new Button();
        entryRow3 = new Panel();
        btnExportEpisodeText = new Button();
        btnExportEpisodeTts = new Button();
        btnExportEpisodeJson = new Button();
        chkExportIncludeHeader = new CheckBox();
        chkExportBlankLineBetweenEntries = new CheckBox();
        chkExportIncludeEntryMarkers = new CheckBox();
        chkExportAuthorDebugMode = new CheckBox();
        entryRow2 = new Panel();
        btnGenerateEntry = new Button();
        btnGenerateEpisodeEntries = new Button();
        btnRegenerateSelectedEntry = new Button();
        numGenerateEntryCount = new NumericUpDown();
        chkClearEpisodeBeforeGenerate = new CheckBox();
        lblSeed = new Label();
        txtGenerationSeed = new TextBox();
        chkRegenerateWithoutAdvancingThread = new CheckBox();
        detailArea = new Panel();
        ucEntryDetail = new ucEpisodeEntryDetail();
        txtThreadSummary = new TextBox();
        txtEpisodeEntryPreview = new TextBox();
        ((System.ComponentModel.ISupportInitialize)splitEpisodesMain).BeginInit();
        splitEpisodesMain.Panel1.SuspendLayout();
        splitEpisodesMain.Panel2.SuspendLayout();
        splitEpisodesMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitSeriesEpisodes).BeginInit();
        splitSeriesEpisodes.Panel1.SuspendLayout();
        splitSeriesEpisodes.Panel2.SuspendLayout();
        splitSeriesEpisodes.SuspendLayout();
        seriesPanel.SuspendLayout();
        seriesButtonsPanel.SuspendLayout();
        leftPanel.SuspendLayout();
        episodeActionsPanel.SuspendLayout();
        leftButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitEpisodesRight).BeginInit();
        splitEpisodesRight.Panel1.SuspendLayout();
        splitEpisodesRight.Panel2.SuspendLayout();
        splitEpisodesRight.SuspendLayout();
        gridPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridEpisodeEntries).BeginInit();
        entryFilterPanel.SuspendLayout();
        filterRow2.SuspendLayout();
        filterRow1.SuspendLayout();
        entryButtonsPanel.SuspendLayout();
        entryRow1.SuspendLayout();
        entryRow3.SuspendLayout();
        entryRow2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numGenerateEntryCount).BeginInit();
        detailArea.SuspendLayout();
        SuspendLayout();
        // 
        // splitEpisodesMain
        // 
        splitEpisodesMain.Dock = DockStyle.Fill;
        splitEpisodesMain.Location = new Point(0, 0);
        splitEpisodesMain.Name = "splitEpisodesMain";
        // 
        // splitEpisodesMain.Panel1
        // 
        splitEpisodesMain.Panel1.Controls.Add(splitSeriesEpisodes);
        splitEpisodesMain.Panel1MinSize = 220;
        // 
        // splitEpisodesMain.Panel2
        // 
        splitEpisodesMain.Panel2.Controls.Add(splitEpisodesRight);
        splitEpisodesMain.Size = new Size(1040, 760);
        splitEpisodesMain.SplitterDistance = 838;
        splitEpisodesMain.TabIndex = 0;
        // 
        // splitSeriesEpisodes
        // 
        splitSeriesEpisodes.Dock = DockStyle.Fill;
        splitSeriesEpisodes.Location = new Point(0, 0);
        splitSeriesEpisodes.Name = "splitSeriesEpisodes";
        splitSeriesEpisodes.Orientation = Orientation.Horizontal;
        // 
        // splitSeriesEpisodes.Panel1
        // 
        splitSeriesEpisodes.Panel1.Controls.Add(seriesPanel);
        splitSeriesEpisodes.Panel1MinSize = 100;
        // 
        // splitSeriesEpisodes.Panel2
        // 
        splitSeriesEpisodes.Panel2.Controls.Add(leftPanel);
        splitSeriesEpisodes.Size = new Size(838, 760);
        splitSeriesEpisodes.SplitterDistance = 539;
        splitSeriesEpisodes.TabIndex = 0;
        // 
        // seriesPanel
        // 
        seriesPanel.Controls.Add(lstSeries);
        seriesPanel.Controls.Add(lblSeries);
        seriesPanel.Controls.Add(seriesButtonsPanel);
        seriesPanel.Location = new Point(0, 0);
        seriesPanel.Name = "seriesPanel";
        seriesPanel.Size = new Size(200, 100);
        seriesPanel.TabIndex = 0;
        // 
        // lstSeries
        // 
        lstSeries.Dock = DockStyle.Fill;
        lstSeries.IntegralHeight = false;
        lstSeries.ItemHeight = 25;
        lstSeries.Location = new Point(0, 0);
        lstSeries.Name = "lstSeries";
        lstSeries.Size = new Size(200, 100);
        lstSeries.TabIndex = 0;
        // 
        // lblSeries
        // 
        lblSeries.Location = new Point(0, 0);
        lblSeries.Name = "lblSeries";
        lblSeries.Size = new Size(100, 23);
        lblSeries.TabIndex = 1;
        // 
        // seriesButtonsPanel
        // 
        seriesButtonsPanel.Controls.Add(btnSeriesDuplicate);
        seriesButtonsPanel.Controls.Add(btnSeriesDelete);
        seriesButtonsPanel.Controls.Add(btnSeriesAdd);
        seriesButtonsPanel.Location = new Point(0, 0);
        seriesButtonsPanel.Name = "seriesButtonsPanel";
        seriesButtonsPanel.Size = new Size(200, 100);
        seriesButtonsPanel.TabIndex = 2;
        // 
        // btnSeriesDuplicate
        // 
        btnSeriesDuplicate.Dock = DockStyle.Left;
        btnSeriesDuplicate.Location = new Point(152, 0);
        btnSeriesDuplicate.Name = "btnSeriesDuplicate";
        btnSeriesDuplicate.Size = new Size(52, 100);
        btnSeriesDuplicate.TabIndex = 0;
        btnSeriesDuplicate.Text = "Dup";
        // 
        // btnSeriesDelete
        // 
        btnSeriesDelete.Dock = DockStyle.Left;
        btnSeriesDelete.Location = new Point(76, 0);
        btnSeriesDelete.Name = "btnSeriesDelete";
        btnSeriesDelete.Size = new Size(76, 100);
        btnSeriesDelete.TabIndex = 1;
        btnSeriesDelete.Text = "Delete";
        // 
        // btnSeriesAdd
        // 
        btnSeriesAdd.Dock = DockStyle.Left;
        btnSeriesAdd.Location = new Point(0, 0);
        btnSeriesAdd.Name = "btnSeriesAdd";
        btnSeriesAdd.Size = new Size(76, 100);
        btnSeriesAdd.TabIndex = 2;
        btnSeriesAdd.Text = "Add";
        // 
        // leftPanel
        // 
        leftPanel.Controls.Add(lstEpisodes);
        leftPanel.Controls.Add(lblEpisodes);
        leftPanel.Controls.Add(txtEpisodeSearch);
        leftPanel.Controls.Add(txtEpisodeSummary);
        leftPanel.Controls.Add(ucMetaEditor);
        leftPanel.Controls.Add(episodeActionsPanel);
        leftPanel.Controls.Add(leftButtons);
        leftPanel.Location = new Point(0, 0);
        leftPanel.Name = "leftPanel";
        leftPanel.Size = new Size(200, 100);
        leftPanel.TabIndex = 0;
        // 
        // lstEpisodes
        // 
        lstEpisodes.Dock = DockStyle.Fill;
        lstEpisodes.IntegralHeight = false;
        lstEpisodes.ItemHeight = 25;
        lstEpisodes.Location = new Point(0, 31);
        lstEpisodes.Name = "lstEpisodes";
        lstEpisodes.Size = new Size(200, 9);
        lstEpisodes.TabIndex = 0;
        // 
        // lblEpisodes
        // 
        lblEpisodes.Location = new Point(0, 0);
        lblEpisodes.Name = "lblEpisodes";
        lblEpisodes.Size = new Size(100, 23);
        lblEpisodes.TabIndex = 1;
        // 
        // txtEpisodeSearch
        // 
        txtEpisodeSearch.Dock = DockStyle.Top;
        txtEpisodeSearch.Location = new Point(0, 0);
        txtEpisodeSearch.Name = "txtEpisodeSearch";
        txtEpisodeSearch.PlaceholderText = "Search episodes...";
        txtEpisodeSearch.Size = new Size(200, 31);
        txtEpisodeSearch.TabIndex = 2;
        // 
        // txtEpisodeSummary
        // 
        txtEpisodeSummary.BackColor = SystemColors.ControlLight;
        txtEpisodeSummary.Dock = DockStyle.Bottom;
        txtEpisodeSummary.Location = new Point(0, 40);
        txtEpisodeSummary.Multiline = true;
        txtEpisodeSummary.Name = "txtEpisodeSummary";
        txtEpisodeSummary.ReadOnly = true;
        txtEpisodeSummary.ScrollBars = ScrollBars.Vertical;
        txtEpisodeSummary.Size = new Size(200, 60);
        txtEpisodeSummary.TabIndex = 3;
        // 
        // ucMetaEditor
        // 
        ucMetaEditor.AutoScroll = true;
        ucMetaEditor.Location = new Point(0, 0);
        ucMetaEditor.Margin = new Padding(4, 5, 4, 5);
        ucMetaEditor.Name = "ucMetaEditor";
        ucMetaEditor.Size = new Size(300, 340);
        ucMetaEditor.TabIndex = 4;
        // 
        // episodeActionsPanel
        // 
        episodeActionsPanel.Controls.Add(btnEpisodeMoveDown);
        episodeActionsPanel.Controls.Add(btnEpisodeMoveUp);
        episodeActionsPanel.Controls.Add(btnEpisodeDuplicate);
        episodeActionsPanel.Controls.Add(btnNewEpisodeAfterSelected);
        episodeActionsPanel.Controls.Add(btnLockEpisodeCanon);
        episodeActionsPanel.Controls.Add(btnUnlockEpisodeCanon);
        episodeActionsPanel.Location = new Point(0, 0);
        episodeActionsPanel.Name = "episodeActionsPanel";
        episodeActionsPanel.Size = new Size(200, 100);
        episodeActionsPanel.TabIndex = 4;
        // 
        // btnEpisodeMoveDown
        // 
        btnEpisodeMoveDown.Dock = DockStyle.Left;
        btnEpisodeMoveDown.Location = new Point(242, 0);
        btnEpisodeMoveDown.Name = "btnEpisodeMoveDown";
        btnEpisodeMoveDown.Size = new Size(36, 100);
        btnEpisodeMoveDown.TabIndex = 0;
        btnEpisodeMoveDown.Text = "â–¼";
        // 
        // btnEpisodeMoveUp
        // 
        btnEpisodeMoveUp.Dock = DockStyle.Left;
        btnEpisodeMoveUp.Location = new Point(206, 0);
        btnEpisodeMoveUp.Name = "btnEpisodeMoveUp";
        btnEpisodeMoveUp.Size = new Size(36, 100);
        btnEpisodeMoveUp.TabIndex = 1;
        btnEpisodeMoveUp.Text = "â–²";
        // 
        // btnEpisodeDuplicate
        // 
        btnEpisodeDuplicate.Dock = DockStyle.Left;
        btnEpisodeDuplicate.Location = new Point(156, 0);
        btnEpisodeDuplicate.Name = "btnEpisodeDuplicate";
        btnEpisodeDuplicate.Size = new Size(50, 100);
        btnEpisodeDuplicate.TabIndex = 2;
        btnEpisodeDuplicate.Text = "Dup";
        // 
        // btnNewEpisodeAfterSelected
        // 
        btnNewEpisodeAfterSelected.Dock = DockStyle.Left;
        btnNewEpisodeAfterSelected.Location = new Point(112, 0);
        btnNewEpisodeAfterSelected.Name = "btnNewEpisodeAfterSelected";
        btnNewEpisodeAfterSelected.Size = new Size(44, 100);
        btnNewEpisodeAfterSelected.TabIndex = 3;
        btnNewEpisodeAfterSelected.Text = "Ins";
        // 
        // btnLockEpisodeCanon
        // 
        btnLockEpisodeCanon.Dock = DockStyle.Left;
        btnLockEpisodeCanon.Location = new Point(60, 0);
        btnLockEpisodeCanon.Name = "btnLockEpisodeCanon";
        btnLockEpisodeCanon.Size = new Size(52, 100);
        btnLockEpisodeCanon.TabIndex = 4;
        btnLockEpisodeCanon.Text = "Lock";
        // 
        // btnUnlockEpisodeCanon
        // 
        btnUnlockEpisodeCanon.Dock = DockStyle.Left;
        btnUnlockEpisodeCanon.Location = new Point(0, 0);
        btnUnlockEpisodeCanon.Name = "btnUnlockEpisodeCanon";
        btnUnlockEpisodeCanon.Size = new Size(60, 100);
        btnUnlockEpisodeCanon.TabIndex = 5;
        btnUnlockEpisodeCanon.Text = "Unlock";
        // 
        // leftButtons
        // 
        leftButtons.Controls.Add(btnEpisodeDelete);
        leftButtons.Controls.Add(btnEpisodeAdd);
        leftButtons.Location = new Point(0, 0);
        leftButtons.Name = "leftButtons";
        leftButtons.Size = new Size(200, 100);
        leftButtons.TabIndex = 5;
        // 
        // btnEpisodeDelete
        // 
        btnEpisodeDelete.Dock = DockStyle.Left;
        btnEpisodeDelete.Location = new Point(76, 0);
        btnEpisodeDelete.Name = "btnEpisodeDelete";
        btnEpisodeDelete.Size = new Size(76, 100);
        btnEpisodeDelete.TabIndex = 0;
        btnEpisodeDelete.Text = "Delete";
        // 
        // btnEpisodeAdd
        // 
        btnEpisodeAdd.Dock = DockStyle.Left;
        btnEpisodeAdd.Location = new Point(0, 0);
        btnEpisodeAdd.Name = "btnEpisodeAdd";
        btnEpisodeAdd.Size = new Size(76, 100);
        btnEpisodeAdd.TabIndex = 1;
        btnEpisodeAdd.Text = "Add";
        // 
        // splitEpisodesRight
        // 
        splitEpisodesRight.Dock = DockStyle.Fill;
        splitEpisodesRight.Location = new Point(0, 0);
        splitEpisodesRight.Name = "splitEpisodesRight";
        splitEpisodesRight.Orientation = Orientation.Horizontal;
        // 
        // splitEpisodesRight.Panel1
        // 
        splitEpisodesRight.Panel1.Controls.Add(gridPanel);
        // 
        // splitEpisodesRight.Panel2
        // 
        splitEpisodesRight.Panel2.Controls.Add(detailArea);
        splitEpisodesRight.Panel2MinSize = 240;
        splitEpisodesRight.Size = new Size(198, 760);
        splitEpisodesRight.SplitterDistance = 202;
        splitEpisodesRight.TabIndex = 0;
        // 
        // gridPanel
        // 
        gridPanel.Controls.Add(gridEpisodeEntries);
        gridPanel.Controls.Add(lblEntries);
        gridPanel.Controls.Add(entryFilterPanel);
        gridPanel.Controls.Add(entryButtonsPanel);
        gridPanel.Location = new Point(0, 0);
        gridPanel.Name = "gridPanel";
        gridPanel.Size = new Size(200, 100);
        gridPanel.TabIndex = 0;
        // 
        // gridEpisodeEntries
        // 
        gridEpisodeEntries.AllowUserToAddRows = false;
        gridEpisodeEntries.ColumnHeadersHeight = 34;
        gridEpisodeEntries.Dock = DockStyle.Fill;
        gridEpisodeEntries.Location = new Point(0, 0);
        gridEpisodeEntries.MultiSelect = false;
        gridEpisodeEntries.Name = "gridEpisodeEntries";
        gridEpisodeEntries.RowHeadersWidth = 62;
        gridEpisodeEntries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridEpisodeEntries.Size = new Size(200, 100);
        gridEpisodeEntries.TabIndex = 0;
        // 
        // lblEntries
        // 
        lblEntries.Location = new Point(0, 0);
        lblEntries.Name = "lblEntries";
        lblEntries.Size = new Size(100, 23);
        lblEntries.TabIndex = 1;
        // 
        // entryFilterPanel
        // 
        entryFilterPanel.Controls.Add(filterRow2);
        entryFilterPanel.Controls.Add(filterRow1);
        entryFilterPanel.Location = new Point(0, 0);
        entryFilterPanel.Name = "entryFilterPanel";
        entryFilterPanel.Size = new Size(200, 100);
        entryFilterPanel.TabIndex = 2;
        // 
        // filterRow2
        // 
        filterRow2.Controls.Add(cboEntryFilterStation);
        filterRow2.Controls.Add(chkShowLockedOnly);
        filterRow2.Controls.Add(btnClearEntryFilters);
        filterRow2.Controls.Add(cboEntryFilterVessel);
        filterRow2.Location = new Point(0, 0);
        filterRow2.Name = "filterRow2";
        filterRow2.Size = new Size(200, 100);
        filterRow2.TabIndex = 0;
        // 
        // cboEntryFilterStation
        // 
        cboEntryFilterStation.Dock = DockStyle.Right;
        cboEntryFilterStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterStation.Location = new Point(-42, 0);
        cboEntryFilterStation.Name = "cboEntryFilterStation";
        cboEntryFilterStation.Size = new Size(130, 33);
        cboEntryFilterStation.TabIndex = 0;
        // 
        // chkShowLockedOnly
        // 
        chkShowLockedOnly.Dock = DockStyle.Right;
        chkShowLockedOnly.Location = new Point(88, 0);
        chkShowLockedOnly.Name = "chkShowLockedOnly";
        chkShowLockedOnly.Size = new Size(60, 100);
        chkShowLockedOnly.TabIndex = 1;
        chkShowLockedOnly.Text = "Locked";
        // 
        // btnClearEntryFilters
        // 
        btnClearEntryFilters.Dock = DockStyle.Right;
        btnClearEntryFilters.Location = new Point(148, 0);
        btnClearEntryFilters.Name = "btnClearEntryFilters";
        btnClearEntryFilters.Size = new Size(52, 100);
        btnClearEntryFilters.TabIndex = 2;
        btnClearEntryFilters.Text = "Clear";
        // 
        // cboEntryFilterVessel
        // 
        cboEntryFilterVessel.Dock = DockStyle.Fill;
        cboEntryFilterVessel.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterVessel.Location = new Point(0, 0);
        cboEntryFilterVessel.Name = "cboEntryFilterVessel";
        cboEntryFilterVessel.Size = new Size(200, 33);
        cboEntryFilterVessel.TabIndex = 3;
        // 
        // filterRow1
        // 
        filterRow1.Controls.Add(lblEntryKind);
        filterRow1.Controls.Add(cboEntryFilterKind);
        filterRow1.Controls.Add(lblEntrySearch);
        filterRow1.Controls.Add(txtEntrySearch);
        filterRow1.Location = new Point(0, 0);
        filterRow1.Name = "filterRow1";
        filterRow1.Size = new Size(200, 100);
        filterRow1.TabIndex = 1;
        // 
        // lblEntryKind
        // 
        lblEntryKind.Location = new Point(0, 0);
        lblEntryKind.Name = "lblEntryKind";
        lblEntryKind.Size = new Size(100, 23);
        lblEntryKind.TabIndex = 0;
        // 
        // cboEntryFilterKind
        // 
        cboEntryFilterKind.Dock = DockStyle.Right;
        cboEntryFilterKind.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterKind.Location = new Point(90, 0);
        cboEntryFilterKind.Name = "cboEntryFilterKind";
        cboEntryFilterKind.Size = new Size(110, 33);
        cboEntryFilterKind.TabIndex = 1;
        // 
        // lblEntrySearch
        // 
        lblEntrySearch.Location = new Point(0, 0);
        lblEntrySearch.Name = "lblEntrySearch";
        lblEntrySearch.Size = new Size(100, 23);
        lblEntrySearch.TabIndex = 2;
        // 
        // txtEntrySearch
        // 
        txtEntrySearch.Dock = DockStyle.Fill;
        txtEntrySearch.Location = new Point(0, 0);
        txtEntrySearch.Name = "txtEntrySearch";
        txtEntrySearch.Size = new Size(200, 31);
        txtEntrySearch.TabIndex = 3;
        // 
        // entryButtonsPanel
        // 
        entryButtonsPanel.Controls.Add(entryRow1);
        entryButtonsPanel.Controls.Add(entryRow3);
        entryButtonsPanel.Controls.Add(entryRow2);
        entryButtonsPanel.Location = new Point(0, 0);
        entryButtonsPanel.Name = "entryButtonsPanel";
        entryButtonsPanel.Size = new Size(200, 100);
        entryButtonsPanel.TabIndex = 3;
        // 
        // entryRow1
        // 
        entryRow1.Controls.Add(btnEntryMoveDown);
        entryRow1.Controls.Add(btnEntryMoveUp);
        entryRow1.Controls.Add(btnEntryDelete);
        entryRow1.Controls.Add(btnEntryDuplicate);
        entryRow1.Controls.Add(btnNoticeEntryAdd);
        entryRow1.Controls.Add(btnEntryAdd);
        entryRow1.Location = new Point(0, 0);
        entryRow1.Name = "entryRow1";
        entryRow1.Size = new Size(200, 100);
        entryRow1.TabIndex = 0;
        // 
        // btnEntryMoveDown
        // 
        btnEntryMoveDown.Dock = DockStyle.Left;
        btnEntryMoveDown.Location = new Point(388, 0);
        btnEntryMoveDown.Name = "btnEntryMoveDown";
        btnEntryMoveDown.Size = new Size(38, 100);
        btnEntryMoveDown.TabIndex = 0;
        btnEntryMoveDown.Text = "â–¼";
        // 
        // btnEntryMoveUp
        // 
        btnEntryMoveUp.Dock = DockStyle.Left;
        btnEntryMoveUp.Location = new Point(350, 0);
        btnEntryMoveUp.Name = "btnEntryMoveUp";
        btnEntryMoveUp.Size = new Size(38, 100);
        btnEntryMoveUp.TabIndex = 1;
        btnEntryMoveUp.Text = "â–²";
        // 
        // btnEntryDelete
        // 
        btnEntryDelete.Dock = DockStyle.Left;
        btnEntryDelete.Location = new Point(274, 0);
        btnEntryDelete.Name = "btnEntryDelete";
        btnEntryDelete.Size = new Size(76, 100);
        btnEntryDelete.TabIndex = 2;
        btnEntryDelete.Text = "Delete";
        // 
        // btnEntryDuplicate
        // 
        btnEntryDuplicate.Dock = DockStyle.Left;
        btnEntryDuplicate.Location = new Point(192, 0);
        btnEntryDuplicate.Name = "btnEntryDuplicate";
        btnEntryDuplicate.Size = new Size(82, 100);
        btnEntryDuplicate.TabIndex = 3;
        btnEntryDuplicate.Text = "Duplicate";
        // 
        // btnNoticeEntryAdd
        // 
        btnNoticeEntryAdd.Dock = DockStyle.Left;
        btnNoticeEntryAdd.Location = new Point(96, 0);
        btnNoticeEntryAdd.Name = "btnNoticeEntryAdd";
        btnNoticeEntryAdd.Size = new Size(96, 100);
        btnNoticeEntryAdd.TabIndex = 4;
        btnNoticeEntryAdd.Text = "Add Notice";
        // 
        // btnEntryAdd
        // 
        btnEntryAdd.Dock = DockStyle.Left;
        btnEntryAdd.Location = new Point(0, 0);
        btnEntryAdd.Name = "btnEntryAdd";
        btnEntryAdd.Size = new Size(96, 100);
        btnEntryAdd.TabIndex = 5;
        btnEntryAdd.Text = "Add Traffic";
        // 
        // entryRow3
        // 
        entryRow3.Controls.Add(btnExportEpisodeText);
        entryRow3.Controls.Add(btnExportEpisodeTts);
        entryRow3.Controls.Add(btnExportEpisodeJson);
        entryRow3.Controls.Add(chkExportIncludeHeader);
        entryRow3.Controls.Add(chkExportBlankLineBetweenEntries);
        entryRow3.Controls.Add(chkExportIncludeEntryMarkers);
        entryRow3.Controls.Add(chkExportAuthorDebugMode);
        entryRow3.Location = new Point(0, 0);
        entryRow3.Name = "entryRow3";
        entryRow3.Size = new Size(200, 100);
        entryRow3.TabIndex = 1;
        // 
        // btnExportEpisodeText
        // 
        btnExportEpisodeText.Dock = DockStyle.Left;
        btnExportEpisodeText.Location = new Point(356, 0);
        btnExportEpisodeText.Name = "btnExportEpisodeText";
        btnExportEpisodeText.Size = new Size(84, 100);
        btnExportEpisodeText.TabIndex = 0;
        btnExportEpisodeText.Text = "Broadcast";
        // 
        // btnExportEpisodeTts
        // 
        btnExportEpisodeTts.Dock = DockStyle.Left;
        btnExportEpisodeTts.Location = new Point(304, 0);
        btnExportEpisodeTts.Name = "btnExportEpisodeTts";
        btnExportEpisodeTts.Size = new Size(52, 100);
        btnExportEpisodeTts.TabIndex = 1;
        btnExportEpisodeTts.Text = "TTS";
        // 
        // btnExportEpisodeJson
        // 
        btnExportEpisodeJson.Dock = DockStyle.Left;
        btnExportEpisodeJson.Location = new Point(246, 0);
        btnExportEpisodeJson.Name = "btnExportEpisodeJson";
        btnExportEpisodeJson.Size = new Size(58, 100);
        btnExportEpisodeJson.TabIndex = 2;
        btnExportEpisodeJson.Text = "JSON";
        // 
        // chkExportIncludeHeader
        // 
        chkExportIncludeHeader.Checked = true;
        chkExportIncludeHeader.CheckState = CheckState.Checked;
        chkExportIncludeHeader.Dock = DockStyle.Left;
        chkExportIncludeHeader.Location = new Point(182, 0);
        chkExportIncludeHeader.Name = "chkExportIncludeHeader";
        chkExportIncludeHeader.Size = new Size(64, 100);
        chkExportIncludeHeader.TabIndex = 3;
        chkExportIncludeHeader.Text = "Header";
        // 
        // chkExportBlankLineBetweenEntries
        // 
        chkExportBlankLineBetweenEntries.Checked = true;
        chkExportBlankLineBetweenEntries.CheckState = CheckState.Checked;
        chkExportBlankLineBetweenEntries.Dock = DockStyle.Left;
        chkExportBlankLineBetweenEntries.Location = new Point(124, 0);
        chkExportBlankLineBetweenEntries.Name = "chkExportBlankLineBetweenEntries";
        chkExportBlankLineBetweenEntries.Size = new Size(58, 100);
        chkExportBlankLineBetweenEntries.TabIndex = 4;
        chkExportBlankLineBetweenEntries.Text = "Blanks";
        // 
        // chkExportIncludeEntryMarkers
        // 
        chkExportIncludeEntryMarkers.Dock = DockStyle.Left;
        chkExportIncludeEntryMarkers.Location = new Point(58, 0);
        chkExportIncludeEntryMarkers.Name = "chkExportIncludeEntryMarkers";
        chkExportIncludeEntryMarkers.Size = new Size(66, 100);
        chkExportIncludeEntryMarkers.TabIndex = 5;
        chkExportIncludeEntryMarkers.Text = "Markers";
        // 
        // chkExportAuthorDebugMode
        // 
        chkExportAuthorDebugMode.Dock = DockStyle.Left;
        chkExportAuthorDebugMode.Location = new Point(0, 0);
        chkExportAuthorDebugMode.Name = "chkExportAuthorDebugMode";
        chkExportAuthorDebugMode.Size = new Size(58, 100);
        chkExportAuthorDebugMode.TabIndex = 6;
        chkExportAuthorDebugMode.Text = "Debug";
        // 
        // entryRow2
        // 
        entryRow2.Controls.Add(btnGenerateEntry);
        entryRow2.Controls.Add(btnGenerateEpisodeEntries);
        entryRow2.Controls.Add(btnRegenerateSelectedEntry);
        entryRow2.Controls.Add(numGenerateEntryCount);
        entryRow2.Controls.Add(chkClearEpisodeBeforeGenerate);
        entryRow2.Controls.Add(lblSeed);
        entryRow2.Controls.Add(txtGenerationSeed);
        entryRow2.Controls.Add(chkRegenerateWithoutAdvancingThread);
        entryRow2.Location = new Point(0, 0);
        entryRow2.Name = "entryRow2";
        entryRow2.Size = new Size(200, 100);
        entryRow2.TabIndex = 2;
        // 
        // btnGenerateEntry
        // 
        btnGenerateEntry.Dock = DockStyle.Left;
        btnGenerateEntry.Location = new Point(416, 0);
        btnGenerateEntry.Name = "btnGenerateEntry";
        btnGenerateEntry.Size = new Size(88, 100);
        btnGenerateEntry.TabIndex = 0;
        btnGenerateEntry.Text = "Gen Entry";
        // 
        // btnGenerateEpisodeEntries
        // 
        btnGenerateEpisodeEntries.Dock = DockStyle.Left;
        btnGenerateEpisodeEntries.Location = new Point(320, 0);
        btnGenerateEpisodeEntries.Name = "btnGenerateEpisodeEntries";
        btnGenerateEpisodeEntries.Size = new Size(96, 100);
        btnGenerateEpisodeEntries.TabIndex = 1;
        btnGenerateEpisodeEntries.Text = "Fill Episode";
        // 
        // btnRegenerateSelectedEntry
        // 
        btnRegenerateSelectedEntry.Dock = DockStyle.Left;
        btnRegenerateSelectedEntry.Location = new Point(258, 0);
        btnRegenerateSelectedEntry.Name = "btnRegenerateSelectedEntry";
        btnRegenerateSelectedEntry.Size = new Size(62, 100);
        btnRegenerateSelectedEntry.TabIndex = 2;
        btnRegenerateSelectedEntry.Text = "Regen";
        // 
        // numGenerateEntryCount
        // 
        numGenerateEntryCount.Dock = DockStyle.Left;
        numGenerateEntryCount.Location = new Point(206, 0);
        numGenerateEntryCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numGenerateEntryCount.Name = "numGenerateEntryCount";
        numGenerateEntryCount.Size = new Size(52, 31);
        numGenerateEntryCount.TabIndex = 3;
        numGenerateEntryCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // chkClearEpisodeBeforeGenerate
        // 
        chkClearEpisodeBeforeGenerate.Dock = DockStyle.Left;
        chkClearEpisodeBeforeGenerate.Location = new Point(150, 0);
        chkClearEpisodeBeforeGenerate.Name = "chkClearEpisodeBeforeGenerate";
        chkClearEpisodeBeforeGenerate.Size = new Size(56, 100);
        chkClearEpisodeBeforeGenerate.TabIndex = 4;
        chkClearEpisodeBeforeGenerate.Text = "Clear";
        // 
        // lblSeed
        // 
        lblSeed.Location = new Point(0, 0);
        lblSeed.Name = "lblSeed";
        lblSeed.Size = new Size(100, 23);
        lblSeed.TabIndex = 5;
        // 
        // txtGenerationSeed
        // 
        txtGenerationSeed.Dock = DockStyle.Left;
        txtGenerationSeed.Location = new Point(82, 0);
        txtGenerationSeed.Name = "txtGenerationSeed";
        txtGenerationSeed.Size = new Size(68, 31);
        txtGenerationSeed.TabIndex = 6;
        // 
        // chkRegenerateWithoutAdvancingThread
        // 
        chkRegenerateWithoutAdvancingThread.Checked = true;
        chkRegenerateWithoutAdvancingThread.CheckState = CheckState.Checked;
        chkRegenerateWithoutAdvancingThread.Dock = DockStyle.Left;
        chkRegenerateWithoutAdvancingThread.Location = new Point(0, 0);
        chkRegenerateWithoutAdvancingThread.Name = "chkRegenerateWithoutAdvancingThread";
        chkRegenerateWithoutAdvancingThread.Size = new Size(82, 100);
        chkRegenerateWithoutAdvancingThread.TabIndex = 7;
        chkRegenerateWithoutAdvancingThread.Text = "Edit mode";
        // 
        // detailArea
        // 
        detailArea.Controls.Add(ucEntryDetail);
        detailArea.Controls.Add(txtThreadSummary);
        detailArea.Controls.Add(txtEpisodeEntryPreview);
        detailArea.Location = new Point(0, 0);
        detailArea.Name = "detailArea";
        detailArea.Size = new Size(200, 100);
        detailArea.TabIndex = 0;
        // 
        // ucEntryDetail
        // 
        ucEntryDetail.AutoScroll = true;
        ucEntryDetail.Location = new Point(0, 0);
        ucEntryDetail.Margin = new Padding(4, 5, 4, 5);
        ucEntryDetail.Name = "ucEntryDetail";
        ucEntryDetail.Size = new Size(400, 600);
        ucEntryDetail.TabIndex = 0;
        // 
        // txtThreadSummary
        // 
        txtThreadSummary.BackColor = SystemColors.Info;
        txtThreadSummary.Dock = DockStyle.Bottom;
        txtThreadSummary.Location = new Point(0, -58);
        txtThreadSummary.Multiline = true;
        txtThreadSummary.Name = "txtThreadSummary";
        txtThreadSummary.ReadOnly = true;
        txtThreadSummary.ScrollBars = ScrollBars.Vertical;
        txtThreadSummary.Size = new Size(200, 68);
        txtThreadSummary.TabIndex = 0;
        // 
        // txtEpisodeEntryPreview
        // 
        txtEpisodeEntryPreview.BackColor = SystemColors.ControlLight;
        txtEpisodeEntryPreview.Dock = DockStyle.Bottom;
        txtEpisodeEntryPreview.Location = new Point(0, 10);
        txtEpisodeEntryPreview.Multiline = true;
        txtEpisodeEntryPreview.Name = "txtEpisodeEntryPreview";
        txtEpisodeEntryPreview.ReadOnly = true;
        txtEpisodeEntryPreview.ScrollBars = ScrollBars.Vertical;
        txtEpisodeEntryPreview.Size = new Size(200, 90);
        txtEpisodeEntryPreview.TabIndex = 1;
        // 
        // ucEpisodes
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(splitEpisodesMain);
        Name = "ucEpisodes";
        Size = new Size(1040, 760);
        splitEpisodesMain.Panel1.ResumeLayout(false);
        splitEpisodesMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitEpisodesMain).EndInit();
        splitEpisodesMain.ResumeLayout(false);
        splitSeriesEpisodes.Panel1.ResumeLayout(false);
        splitSeriesEpisodes.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitSeriesEpisodes).EndInit();
        splitSeriesEpisodes.ResumeLayout(false);
        seriesPanel.ResumeLayout(false);
        seriesButtonsPanel.ResumeLayout(false);
        leftPanel.ResumeLayout(false);
        leftPanel.PerformLayout();
        episodeActionsPanel.ResumeLayout(false);
        leftButtons.ResumeLayout(false);
        splitEpisodesRight.Panel1.ResumeLayout(false);
        splitEpisodesRight.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitEpisodesRight).EndInit();
        splitEpisodesRight.ResumeLayout(false);
        gridPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridEpisodeEntries).EndInit();
        entryFilterPanel.ResumeLayout(false);
        filterRow2.ResumeLayout(false);
        filterRow1.ResumeLayout(false);
        filterRow1.PerformLayout();
        entryButtonsPanel.ResumeLayout(false);
        entryRow1.ResumeLayout(false);
        entryRow3.ResumeLayout(false);
        entryRow2.ResumeLayout(false);
        entryRow2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numGenerateEntryCount).EndInit();
        detailArea.ResumeLayout(false);
        detailArea.PerformLayout();
        ResumeLayout(false);
    }

    // â”€â”€ Control fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    // Structural splits (not exposed â€” MainForm.cs does not reference these)
    private SplitContainer splitEpisodesMain   = null!;
    private SplitContainer splitSeriesEpisodes = null!;
    private SplitContainer splitEpisodesRight  = null!;

    // Series
    private ListBox lstSeries          = null!;
    private Button  btnSeriesAdd       = null!;
    private Button  btnSeriesDelete    = null!;
    private Button  btnSeriesDuplicate = null!;

    // Episode list
    private ListBox lstEpisodes              = null!;
    private TextBox txtEpisodeSearch         = null!;
    private TextBox txtEpisodeSummary        = null!;
    private Button  btnEpisodeAdd            = null!;
    private Button  btnEpisodeDelete         = null!;
    private Button  btnEpisodeDuplicate      = null!;
    private Button  btnNewEpisodeAfterSelected = null!;
    private Button  btnLockEpisodeCanon      = null!;
    private Button  btnUnlockEpisodeCanon    = null!;
    private Button  btnEpisodeMoveUp         = null!;
    private Button  btnEpisodeMoveDown       = null!;

    // Entry grid + filter
    private DataGridView gridEpisodeEntries   = null!;
    private TextBox      txtEntrySearch       = null!;
    private ComboBox     cboEntryFilterKind   = null!;
    private ComboBox     cboEntryFilterVessel  = null!;
    private ComboBox     cboEntryFilterStation = null!;
    private CheckBox     chkShowLockedOnly     = null!;
    private Button       btnClearEntryFilters  = null!;

    // Entry management buttons
    private Button btnEntryAdd       = null!;
    private Button btnNoticeEntryAdd = null!;
    private Button btnEntryDuplicate = null!;
    private Button btnEntryDelete    = null!;
    private Button btnEntryMoveUp    = null!;
    private Button btnEntryMoveDown  = null!;

    // Generation
    private Button         btnGenerateEntry                    = null!;
    private Button         btnGenerateEpisodeEntries           = null!;
    private Button         btnRegenerateSelectedEntry          = null!;
    private NumericUpDown  numGenerateEntryCount               = null!;
    private CheckBox       chkClearEpisodeBeforeGenerate       = null!;
    private CheckBox       chkRegenerateWithoutAdvancingThread = null!;
    private TextBox        txtGenerationSeed                   = null!;

    // Export
    private Button   btnExportEpisodeText             = null!;
    private Button   btnExportEpisodeTts              = null!;
    private Button   btnExportEpisodeJson             = null!;
    private CheckBox chkExportIncludeHeader           = null!;
    private CheckBox chkExportBlankLineBetweenEntries = null!;
    private CheckBox chkExportIncludeEntryMarkers     = null!;
    private CheckBox chkExportAuthorDebugMode         = null!;

    // Preview / thread summary
    private TextBox txtEpisodeEntryPreview = null!;
    private TextBox txtThreadSummary       = null!;

    // Child UserControls (entry detail + episode meta)
    private ucEpisodeEntryDetail ucEntryDetail = null!;
    private ucEpisodeMetaEditor  ucMetaEditor  = null!;
    private Panel seriesPanel;
    private Label lblSeries;
    private Panel seriesButtonsPanel;
    private Panel leftPanel;
    private Label lblEpisodes;
    private Panel episodeActionsPanel;
    private Panel leftButtons;
    private Panel gridPanel;
    private Label lblEntries;
    private Panel entryFilterPanel;
    private Panel filterRow2;
    private Panel filterRow1;
    private Label lblEntryKind;
    private Label lblEntrySearch;
    private Panel entryButtonsPanel;
    private Panel entryRow1;
    private Panel entryRow3;
    private Panel entryRow2;
    private Label lblSeed;
    private Panel detailArea;
}
