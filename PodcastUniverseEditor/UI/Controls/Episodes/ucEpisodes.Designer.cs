namespace PodcastUniverseEditor.UI.Controls.Episodes;

partial class ucEpisodes
{
    private System.ComponentModel.IContainer components = null!;

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
        pnlSeriesSection = new Panel();
        lstSeries = new ListBox();
        pnlSeriesActions = new Panel();
        btnSeriesDuplicate = new Button();
        btnSeriesDelete = new Button();
        btnSeriesAdd = new Button();
        lblSeries = new Label();
        pnlEpisodeSection = new Panel();
        lstEpisodes = new ListBox();
        pnlEpisodeActions = new Panel();
        btnEpisodeMoveDown = new Button();
        btnEpisodeMoveUp = new Button();
        btnEpisodeDuplicate = new Button();
        btnNewEpisodeAfterSelected = new Button();
        btnLockEpisodeCanon = new Button();
        btnUnlockEpisodeCanon = new Button();
        btnEpisodeDelete = new Button();
        btnEpisodeAdd = new Button();
        txtEpisodeSummary = new TextBox();
        ucMetaEditor = new ucEpisodeMetaEditor();
        txtEpisodeSearch = new TextBox();
        lblEpisodes = new Label();
        splitEpisodeWorkspace = new SplitContainer();
        pnlEntryListSection = new Panel();
        gridEpisodeEntries = new DataGridView();
        pnlEntryToolRows = new Panel();
        pnlEntryExportTools = new Panel();
        btnExportEpisodeText = new Button();
        btnExportEpisodeTts = new Button();
        btnExportEpisodeJson = new Button();
        chkExportIncludeHeader = new CheckBox();
        chkExportBlankLineBetweenEntries = new CheckBox();
        chkExportIncludeEntryMarkers = new CheckBox();
        chkExportAuthorDebugMode = new CheckBox();
        pnlEntryGenerationTools = new Panel();
        btnGenerateEntry = new Button();
        btnGenerateEpisodeEntries = new Button();
        btnRegenerateSelectedEntry = new Button();
        numGenerateEntryCount = new NumericUpDown();
        chkClearEpisodeBeforeGenerate = new CheckBox();
        lblGenerationSeed = new Label();
        txtGenerationSeed = new TextBox();
        chkRegenerateWithoutAdvancingThread = new CheckBox();
        pnlEntryListActions = new Panel();
        btnEntryMoveDown = new Button();
        btnEntryMoveUp = new Button();
        btnEntryDelete = new Button();
        btnEntryDuplicate = new Button();
        btnNoticeEntryAdd = new Button();
        btnEntryAdd = new Button();
        pnlEntryFilters = new Panel();
        pnlEntryFilterSecondaryRow = new Panel();
        cboEntryFilterVessel = new ComboBox();
        cboEntryFilterStation = new ComboBox();
        chkShowLockedOnly = new CheckBox();
        btnClearEntryFilters = new Button();
        pnlEntryFilterPrimaryRow = new Panel();
        txtEntrySearch = new TextBox();
        lblEntrySearch = new Label();
        cboEntryFilterKind = new ComboBox();
        lblEntryKind = new Label();
        lblEntries = new Label();
        pnlSelectedEntrySection = new Panel();
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
        pnlSeriesSection.SuspendLayout();
        pnlSeriesActions.SuspendLayout();
        pnlEpisodeSection.SuspendLayout();
        pnlEpisodeActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitEpisodeWorkspace).BeginInit();
        splitEpisodeWorkspace.Panel1.SuspendLayout();
        splitEpisodeWorkspace.Panel2.SuspendLayout();
        splitEpisodeWorkspace.SuspendLayout();
        pnlEntryListSection.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridEpisodeEntries).BeginInit();
        pnlEntryToolRows.SuspendLayout();
        pnlEntryExportTools.SuspendLayout();
        pnlEntryGenerationTools.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numGenerateEntryCount).BeginInit();
        pnlEntryListActions.SuspendLayout();
        pnlEntryFilters.SuspendLayout();
        pnlEntryFilterSecondaryRow.SuspendLayout();
        pnlEntryFilterPrimaryRow.SuspendLayout();
        pnlSelectedEntrySection.SuspendLayout();
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
        splitEpisodesMain.Panel1MinSize = 260;
        // 
        // splitEpisodesMain.Panel2
        // 
        splitEpisodesMain.Panel2.Controls.Add(splitEpisodeWorkspace);
        splitEpisodesMain.Size = new Size(1040, 760);
        splitEpisodesMain.SplitterDistance = 381;
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
        splitSeriesEpisodes.Panel1.Controls.Add(pnlSeriesSection);
        splitSeriesEpisodes.Panel1MinSize = 100;
        // 
        // splitSeriesEpisodes.Panel2
        // 
        splitSeriesEpisodes.Panel2.Controls.Add(pnlEpisodeSection);
        splitSeriesEpisodes.Size = new Size(381, 760);
        splitSeriesEpisodes.SplitterDistance = 150;
        splitSeriesEpisodes.TabIndex = 0;
        // 
        // pnlSeriesSection
        // 
        pnlSeriesSection.Controls.Add(lstSeries);
        pnlSeriesSection.Controls.Add(pnlSeriesActions);
        pnlSeriesSection.Controls.Add(lblSeries);
        pnlSeriesSection.Dock = DockStyle.Fill;
        pnlSeriesSection.Location = new Point(0, 0);
        pnlSeriesSection.Name = "pnlSeriesSection";
        pnlSeriesSection.Size = new Size(381, 150);
        pnlSeriesSection.TabIndex = 0;
        // 
        // lstSeries
        // 
        lstSeries.Dock = DockStyle.Fill;
        lstSeries.IntegralHeight = false;
        lstSeries.ItemHeight = 25;
        lstSeries.Location = new Point(0, 22);
        lstSeries.Name = "lstSeries";
        lstSeries.Size = new Size(381, 92);
        lstSeries.TabIndex = 2;
        // 
        // pnlSeriesActions
        // 
        pnlSeriesActions.Controls.Add(btnSeriesDuplicate);
        pnlSeriesActions.Controls.Add(btnSeriesDelete);
        pnlSeriesActions.Controls.Add(btnSeriesAdd);
        pnlSeriesActions.Dock = DockStyle.Bottom;
        pnlSeriesActions.Location = new Point(0, 114);
        pnlSeriesActions.Name = "pnlSeriesActions";
        pnlSeriesActions.Size = new Size(381, 36);
        pnlSeriesActions.TabIndex = 1;
        // 
        // btnSeriesDuplicate
        // 
        btnSeriesDuplicate.Dock = DockStyle.Left;
        btnSeriesDuplicate.Location = new Point(152, 0);
        btnSeriesDuplicate.Name = "btnSeriesDuplicate";
        btnSeriesDuplicate.Size = new Size(72, 36);
        btnSeriesDuplicate.TabIndex = 0;
        btnSeriesDuplicate.Text = "Dup";
        btnSeriesDuplicate.UseVisualStyleBackColor = true;
        // 
        // btnSeriesDelete
        // 
        btnSeriesDelete.Dock = DockStyle.Left;
        btnSeriesDelete.Location = new Point(76, 0);
        btnSeriesDelete.Name = "btnSeriesDelete";
        btnSeriesDelete.Size = new Size(76, 36);
        btnSeriesDelete.TabIndex = 1;
        btnSeriesDelete.Text = "Delete";
        btnSeriesDelete.UseVisualStyleBackColor = true;
        // 
        // btnSeriesAdd
        // 
        btnSeriesAdd.Dock = DockStyle.Left;
        btnSeriesAdd.Location = new Point(0, 0);
        btnSeriesAdd.Name = "btnSeriesAdd";
        btnSeriesAdd.Size = new Size(76, 36);
        btnSeriesAdd.TabIndex = 2;
        btnSeriesAdd.Text = "Add";
        btnSeriesAdd.UseVisualStyleBackColor = true;
        // 
        // lblSeries
        // 
        lblSeries.Dock = DockStyle.Top;
        lblSeries.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSeries.Location = new Point(0, 0);
        lblSeries.Name = "lblSeries";
        lblSeries.Size = new Size(381, 22);
        lblSeries.TabIndex = 0;
        lblSeries.Text = "Series";
        // 
        // pnlEpisodeSection
        // 
        pnlEpisodeSection.Controls.Add(lstEpisodes);
        pnlEpisodeSection.Controls.Add(pnlEpisodeActions);
        pnlEpisodeSection.Controls.Add(txtEpisodeSummary);
        pnlEpisodeSection.Controls.Add(ucMetaEditor);
        pnlEpisodeSection.Controls.Add(txtEpisodeSearch);
        pnlEpisodeSection.Controls.Add(lblEpisodes);
        pnlEpisodeSection.Dock = DockStyle.Fill;
        pnlEpisodeSection.Location = new Point(0, 0);
        pnlEpisodeSection.Name = "pnlEpisodeSection";
        pnlEpisodeSection.Size = new Size(381, 606);
        pnlEpisodeSection.TabIndex = 0;
        // 
        // lstEpisodes
        // 
        lstEpisodes.Dock = DockStyle.Fill;
        lstEpisodes.IntegralHeight = false;
        lstEpisodes.ItemHeight = 25;
        lstEpisodes.Location = new Point(0, 53);
        lstEpisodes.Name = "lstEpisodes";
        lstEpisodes.Size = new Size(381, 117);
        lstEpisodes.TabIndex = 2;
        // 
        // pnlEpisodeActions
        // 
        pnlEpisodeActions.Controls.Add(btnEpisodeMoveDown);
        pnlEpisodeActions.Controls.Add(btnEpisodeMoveUp);
        pnlEpisodeActions.Controls.Add(btnEpisodeDuplicate);
        pnlEpisodeActions.Controls.Add(btnNewEpisodeAfterSelected);
        pnlEpisodeActions.Controls.Add(btnLockEpisodeCanon);
        pnlEpisodeActions.Controls.Add(btnUnlockEpisodeCanon);
        pnlEpisodeActions.Controls.Add(btnEpisodeDelete);
        pnlEpisodeActions.Controls.Add(btnEpisodeAdd);
        pnlEpisodeActions.Dock = DockStyle.Bottom;
        pnlEpisodeActions.Location = new Point(0, 170);
        pnlEpisodeActions.Name = "pnlEpisodeActions";
        pnlEpisodeActions.Size = new Size(381, 36);
        pnlEpisodeActions.TabIndex = 3;
        // 
        // btnEpisodeMoveDown
        // 
        btnEpisodeMoveDown.Dock = DockStyle.Left;
        btnEpisodeMoveDown.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEpisodeMoveDown.Location = new Point(342, 0);
        btnEpisodeMoveDown.Name = "btnEpisodeMoveDown";
        btnEpisodeMoveDown.Size = new Size(34, 36);
        btnEpisodeMoveDown.TabIndex = 0;
        btnEpisodeMoveDown.Text = "▼";
        btnEpisodeMoveDown.UseVisualStyleBackColor = true;
        // 
        // btnEpisodeMoveUp
        // 
        btnEpisodeMoveUp.Dock = DockStyle.Left;
        btnEpisodeMoveUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEpisodeMoveUp.Location = new Point(308, 0);
        btnEpisodeMoveUp.Name = "btnEpisodeMoveUp";
        btnEpisodeMoveUp.Size = new Size(34, 36);
        btnEpisodeMoveUp.TabIndex = 1;
        btnEpisodeMoveUp.Text = "▲";
        btnEpisodeMoveUp.UseVisualStyleBackColor = true;
        // 
        // btnEpisodeDuplicate
        // 
        btnEpisodeDuplicate.Dock = DockStyle.Left;
        btnEpisodeDuplicate.Location = new Point(258, 0);
        btnEpisodeDuplicate.Name = "btnEpisodeDuplicate";
        btnEpisodeDuplicate.Size = new Size(50, 36);
        btnEpisodeDuplicate.TabIndex = 2;
        btnEpisodeDuplicate.Text = "Dup";
        btnEpisodeDuplicate.UseVisualStyleBackColor = true;
        // 
        // btnNewEpisodeAfterSelected
        // 
        btnNewEpisodeAfterSelected.Dock = DockStyle.Left;
        btnNewEpisodeAfterSelected.Location = new Point(208, 0);
        btnNewEpisodeAfterSelected.Name = "btnNewEpisodeAfterSelected";
        btnNewEpisodeAfterSelected.Size = new Size(50, 36);
        btnNewEpisodeAfterSelected.TabIndex = 3;
        btnNewEpisodeAfterSelected.Text = "Ins";
        btnNewEpisodeAfterSelected.UseVisualStyleBackColor = true;
        // 
        // btnLockEpisodeCanon
        // 
        btnLockEpisodeCanon.Dock = DockStyle.Left;
        btnLockEpisodeCanon.Location = new Point(158, 0);
        btnLockEpisodeCanon.Name = "btnLockEpisodeCanon";
        btnLockEpisodeCanon.Size = new Size(50, 36);
        btnLockEpisodeCanon.TabIndex = 4;
        btnLockEpisodeCanon.Text = "Lock";
        btnLockEpisodeCanon.UseVisualStyleBackColor = true;
        // 
        // btnUnlockEpisodeCanon
        // 
        btnUnlockEpisodeCanon.Dock = DockStyle.Left;
        btnUnlockEpisodeCanon.Location = new Point(100, 0);
        btnUnlockEpisodeCanon.Name = "btnUnlockEpisodeCanon";
        btnUnlockEpisodeCanon.Size = new Size(58, 36);
        btnUnlockEpisodeCanon.TabIndex = 5;
        btnUnlockEpisodeCanon.Text = "Unlock";
        btnUnlockEpisodeCanon.UseVisualStyleBackColor = true;
        // 
        // btnEpisodeDelete
        // 
        btnEpisodeDelete.Dock = DockStyle.Left;
        btnEpisodeDelete.Location = new Point(50, 0);
        btnEpisodeDelete.Name = "btnEpisodeDelete";
        btnEpisodeDelete.Size = new Size(50, 36);
        btnEpisodeDelete.TabIndex = 6;
        btnEpisodeDelete.Text = "Del";
        btnEpisodeDelete.UseVisualStyleBackColor = true;
        // 
        // btnEpisodeAdd
        // 
        btnEpisodeAdd.Dock = DockStyle.Left;
        btnEpisodeAdd.Location = new Point(0, 0);
        btnEpisodeAdd.Name = "btnEpisodeAdd";
        btnEpisodeAdd.Size = new Size(50, 36);
        btnEpisodeAdd.TabIndex = 7;
        btnEpisodeAdd.Text = "Add";
        btnEpisodeAdd.UseVisualStyleBackColor = true;
        // 
        // txtEpisodeSummary
        // 
        txtEpisodeSummary.BackColor = SystemColors.ControlLight;
        txtEpisodeSummary.Dock = DockStyle.Bottom;
        txtEpisodeSummary.Location = new Point(0, 206);
        txtEpisodeSummary.Multiline = true;
        txtEpisodeSummary.Name = "txtEpisodeSummary";
        txtEpisodeSummary.ReadOnly = true;
        txtEpisodeSummary.ScrollBars = ScrollBars.Vertical;
        txtEpisodeSummary.Size = new Size(381, 60);
        txtEpisodeSummary.TabIndex = 4;
        // 
        // ucMetaEditor
        // 
        ucMetaEditor.AutoScroll = true;
        ucMetaEditor.Dock = DockStyle.Bottom;
        ucMetaEditor.Enabled = false;
        ucMetaEditor.Location = new Point(0, 266);
        ucMetaEditor.Margin = new Padding(4, 5, 4, 5);
        ucMetaEditor.Name = "ucMetaEditor";
        ucMetaEditor.Size = new Size(381, 340);
        ucMetaEditor.TabIndex = 5;
        // 
        // txtEpisodeSearch
        // 
        txtEpisodeSearch.Dock = DockStyle.Top;
        txtEpisodeSearch.Location = new Point(0, 22);
        txtEpisodeSearch.Name = "txtEpisodeSearch";
        txtEpisodeSearch.PlaceholderText = "Search episodes...";
        txtEpisodeSearch.Size = new Size(381, 31);
        txtEpisodeSearch.TabIndex = 1;
        // 
        // lblEpisodes
        // 
        lblEpisodes.Dock = DockStyle.Top;
        lblEpisodes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblEpisodes.Location = new Point(0, 0);
        lblEpisodes.Name = "lblEpisodes";
        lblEpisodes.Size = new Size(381, 22);
        lblEpisodes.TabIndex = 0;
        lblEpisodes.Text = "Episodes";
        // 
        // splitEpisodeWorkspace
        // 
        splitEpisodeWorkspace.Dock = DockStyle.Fill;
        splitEpisodeWorkspace.Location = new Point(0, 0);
        splitEpisodeWorkspace.Name = "splitEpisodeWorkspace";
        splitEpisodeWorkspace.Orientation = Orientation.Horizontal;
        // 
        // splitEpisodeWorkspace.Panel1
        // 
        splitEpisodeWorkspace.Panel1.Controls.Add(pnlEntryListSection);
        splitEpisodeWorkspace.Panel1MinSize = 240;
        // 
        // splitEpisodeWorkspace.Panel2
        // 
        splitEpisodeWorkspace.Panel2.Controls.Add(pnlSelectedEntrySection);
        splitEpisodeWorkspace.Panel2MinSize = 240;
        splitEpisodeWorkspace.Size = new Size(655, 760);
        splitEpisodeWorkspace.SplitterDistance = 300;
        splitEpisodeWorkspace.TabIndex = 0;
        // 
        // pnlEntryListSection
        // 
        pnlEntryListSection.Controls.Add(gridEpisodeEntries);
        pnlEntryListSection.Controls.Add(pnlEntryToolRows);
        pnlEntryListSection.Controls.Add(pnlEntryFilters);
        pnlEntryListSection.Controls.Add(lblEntries);
        pnlEntryListSection.Dock = DockStyle.Fill;
        pnlEntryListSection.Location = new Point(0, 0);
        pnlEntryListSection.Name = "pnlEntryListSection";
        pnlEntryListSection.Size = new Size(655, 300);
        pnlEntryListSection.TabIndex = 0;
        // 
        // gridEpisodeEntries
        // 
        gridEpisodeEntries.AllowUserToAddRows = false;
        gridEpisodeEntries.ColumnHeadersHeight = 34;
        gridEpisodeEntries.Dock = DockStyle.Fill;
        gridEpisodeEntries.Location = new Point(0, 84);
        gridEpisodeEntries.MultiSelect = false;
        gridEpisodeEntries.Name = "gridEpisodeEntries";
        gridEpisodeEntries.RowHeadersWidth = 62;
        gridEpisodeEntries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridEpisodeEntries.Size = new Size(655, 108);
        gridEpisodeEntries.TabIndex = 2;
        // 
        // pnlEntryToolRows
        // 
        pnlEntryToolRows.Controls.Add(pnlEntryExportTools);
        pnlEntryToolRows.Controls.Add(pnlEntryGenerationTools);
        pnlEntryToolRows.Controls.Add(pnlEntryListActions);
        pnlEntryToolRows.Dock = DockStyle.Bottom;
        pnlEntryToolRows.Location = new Point(0, 192);
        pnlEntryToolRows.Name = "pnlEntryToolRows";
        pnlEntryToolRows.Size = new Size(655, 108);
        pnlEntryToolRows.TabIndex = 3;
        // 
        // pnlEntryExportTools
        // 
        pnlEntryExportTools.Controls.Add(btnExportEpisodeText);
        pnlEntryExportTools.Controls.Add(btnExportEpisodeTts);
        pnlEntryExportTools.Controls.Add(btnExportEpisodeJson);
        pnlEntryExportTools.Controls.Add(chkExportIncludeHeader);
        pnlEntryExportTools.Controls.Add(chkExportBlankLineBetweenEntries);
        pnlEntryExportTools.Controls.Add(chkExportIncludeEntryMarkers);
        pnlEntryExportTools.Controls.Add(chkExportAuthorDebugMode);
        pnlEntryExportTools.Dock = DockStyle.Top;
        pnlEntryExportTools.Location = new Point(0, 72);
        pnlEntryExportTools.Name = "pnlEntryExportTools";
        pnlEntryExportTools.Size = new Size(655, 36);
        pnlEntryExportTools.TabIndex = 2;
        // 
        // btnExportEpisodeText
        // 
        btnExportEpisodeText.Dock = DockStyle.Left;
        btnExportEpisodeText.Location = new Point(382, 0);
        btnExportEpisodeText.Name = "btnExportEpisodeText";
        btnExportEpisodeText.Size = new Size(84, 36);
        btnExportEpisodeText.TabIndex = 0;
        btnExportEpisodeText.Text = "Broadcast";
        btnExportEpisodeText.UseVisualStyleBackColor = true;
        // 
        // btnExportEpisodeTts
        // 
        btnExportEpisodeTts.Dock = DockStyle.Left;
        btnExportEpisodeTts.Location = new Point(330, 0);
        btnExportEpisodeTts.Name = "btnExportEpisodeTts";
        btnExportEpisodeTts.Size = new Size(52, 36);
        btnExportEpisodeTts.TabIndex = 1;
        btnExportEpisodeTts.Text = "TTS";
        btnExportEpisodeTts.UseVisualStyleBackColor = true;
        // 
        // btnExportEpisodeJson
        // 
        btnExportEpisodeJson.Dock = DockStyle.Left;
        btnExportEpisodeJson.Location = new Point(272, 0);
        btnExportEpisodeJson.Name = "btnExportEpisodeJson";
        btnExportEpisodeJson.Size = new Size(58, 36);
        btnExportEpisodeJson.TabIndex = 2;
        btnExportEpisodeJson.Text = "JSON";
        btnExportEpisodeJson.UseVisualStyleBackColor = true;
        // 
        // chkExportIncludeHeader
        // 
        chkExportIncludeHeader.Checked = true;
        chkExportIncludeHeader.CheckState = CheckState.Checked;
        chkExportIncludeHeader.Dock = DockStyle.Left;
        chkExportIncludeHeader.Location = new Point(202, 0);
        chkExportIncludeHeader.Name = "chkExportIncludeHeader";
        chkExportIncludeHeader.Size = new Size(70, 36);
        chkExportIncludeHeader.TabIndex = 3;
        chkExportIncludeHeader.Text = "Header";
        chkExportIncludeHeader.UseVisualStyleBackColor = true;
        // 
        // chkExportBlankLineBetweenEntries
        // 
        chkExportBlankLineBetweenEntries.Checked = true;
        chkExportBlankLineBetweenEntries.CheckState = CheckState.Checked;
        chkExportBlankLineBetweenEntries.Dock = DockStyle.Left;
        chkExportBlankLineBetweenEntries.Location = new Point(136, 0);
        chkExportBlankLineBetweenEntries.Name = "chkExportBlankLineBetweenEntries";
        chkExportBlankLineBetweenEntries.Size = new Size(66, 36);
        chkExportBlankLineBetweenEntries.TabIndex = 4;
        chkExportBlankLineBetweenEntries.Text = "Blanks";
        chkExportBlankLineBetweenEntries.UseVisualStyleBackColor = true;
        // 
        // chkExportIncludeEntryMarkers
        // 
        chkExportIncludeEntryMarkers.Dock = DockStyle.Left;
        chkExportIncludeEntryMarkers.Location = new Point(64, 0);
        chkExportIncludeEntryMarkers.Name = "chkExportIncludeEntryMarkers";
        chkExportIncludeEntryMarkers.Size = new Size(72, 36);
        chkExportIncludeEntryMarkers.TabIndex = 5;
        chkExportIncludeEntryMarkers.Text = "Markers";
        chkExportIncludeEntryMarkers.UseVisualStyleBackColor = true;
        // 
        // chkExportAuthorDebugMode
        // 
        chkExportAuthorDebugMode.Dock = DockStyle.Left;
        chkExportAuthorDebugMode.Location = new Point(0, 0);
        chkExportAuthorDebugMode.Name = "chkExportAuthorDebugMode";
        chkExportAuthorDebugMode.Size = new Size(64, 36);
        chkExportAuthorDebugMode.TabIndex = 6;
        chkExportAuthorDebugMode.Text = "Debug";
        chkExportAuthorDebugMode.UseVisualStyleBackColor = true;
        // 
        // pnlEntryGenerationTools
        // 
        pnlEntryGenerationTools.Controls.Add(btnGenerateEntry);
        pnlEntryGenerationTools.Controls.Add(btnGenerateEpisodeEntries);
        pnlEntryGenerationTools.Controls.Add(btnRegenerateSelectedEntry);
        pnlEntryGenerationTools.Controls.Add(numGenerateEntryCount);
        pnlEntryGenerationTools.Controls.Add(chkClearEpisodeBeforeGenerate);
        pnlEntryGenerationTools.Controls.Add(lblGenerationSeed);
        pnlEntryGenerationTools.Controls.Add(txtGenerationSeed);
        pnlEntryGenerationTools.Controls.Add(chkRegenerateWithoutAdvancingThread);
        pnlEntryGenerationTools.Dock = DockStyle.Top;
        pnlEntryGenerationTools.Location = new Point(0, 36);
        pnlEntryGenerationTools.Name = "pnlEntryGenerationTools";
        pnlEntryGenerationTools.Size = new Size(655, 36);
        pnlEntryGenerationTools.TabIndex = 1;
        // 
        // btnGenerateEntry
        // 
        btnGenerateEntry.Dock = DockStyle.Left;
        btnGenerateEntry.Location = new Point(482, 0);
        btnGenerateEntry.Name = "btnGenerateEntry";
        btnGenerateEntry.Size = new Size(88, 36);
        btnGenerateEntry.TabIndex = 0;
        btnGenerateEntry.Text = "Gen Entry";
        btnGenerateEntry.UseVisualStyleBackColor = true;
        // 
        // btnGenerateEpisodeEntries
        // 
        btnGenerateEpisodeEntries.Dock = DockStyle.Left;
        btnGenerateEpisodeEntries.Location = new Point(386, 0);
        btnGenerateEpisodeEntries.Name = "btnGenerateEpisodeEntries";
        btnGenerateEpisodeEntries.Size = new Size(96, 36);
        btnGenerateEpisodeEntries.TabIndex = 1;
        btnGenerateEpisodeEntries.Text = "Fill Episode";
        btnGenerateEpisodeEntries.UseVisualStyleBackColor = true;
        // 
        // btnRegenerateSelectedEntry
        // 
        btnRegenerateSelectedEntry.Dock = DockStyle.Left;
        btnRegenerateSelectedEntry.Location = new Point(314, 0);
        btnRegenerateSelectedEntry.Name = "btnRegenerateSelectedEntry";
        btnRegenerateSelectedEntry.Size = new Size(72, 36);
        btnRegenerateSelectedEntry.TabIndex = 2;
        btnRegenerateSelectedEntry.Text = "Regen";
        btnRegenerateSelectedEntry.UseVisualStyleBackColor = true;
        // 
        // numGenerateEntryCount
        // 
        numGenerateEntryCount.Dock = DockStyle.Left;
        numGenerateEntryCount.Location = new Point(262, 0);
        numGenerateEntryCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numGenerateEntryCount.Name = "numGenerateEntryCount";
        numGenerateEntryCount.Size = new Size(52, 31);
        numGenerateEntryCount.TabIndex = 3;
        numGenerateEntryCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // chkClearEpisodeBeforeGenerate
        // 
        chkClearEpisodeBeforeGenerate.Dock = DockStyle.Left;
        chkClearEpisodeBeforeGenerate.Location = new Point(204, 0);
        chkClearEpisodeBeforeGenerate.Name = "chkClearEpisodeBeforeGenerate";
        chkClearEpisodeBeforeGenerate.Size = new Size(58, 36);
        chkClearEpisodeBeforeGenerate.TabIndex = 4;
        chkClearEpisodeBeforeGenerate.Text = "Clear";
        chkClearEpisodeBeforeGenerate.UseVisualStyleBackColor = true;
        // 
        // lblGenerationSeed
        // 
        lblGenerationSeed.Dock = DockStyle.Left;
        lblGenerationSeed.Location = new Point(162, 0);
        lblGenerationSeed.Name = "lblGenerationSeed";
        lblGenerationSeed.Size = new Size(42, 36);
        lblGenerationSeed.TabIndex = 5;
        lblGenerationSeed.Text = "Seed:";
        lblGenerationSeed.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtGenerationSeed
        // 
        txtGenerationSeed.Dock = DockStyle.Left;
        txtGenerationSeed.Location = new Point(90, 0);
        txtGenerationSeed.Name = "txtGenerationSeed";
        txtGenerationSeed.Size = new Size(72, 31);
        txtGenerationSeed.TabIndex = 6;
        // 
        // chkRegenerateWithoutAdvancingThread
        // 
        chkRegenerateWithoutAdvancingThread.Checked = true;
        chkRegenerateWithoutAdvancingThread.CheckState = CheckState.Checked;
        chkRegenerateWithoutAdvancingThread.Dock = DockStyle.Left;
        chkRegenerateWithoutAdvancingThread.Location = new Point(0, 0);
        chkRegenerateWithoutAdvancingThread.Name = "chkRegenerateWithoutAdvancingThread";
        chkRegenerateWithoutAdvancingThread.Size = new Size(90, 36);
        chkRegenerateWithoutAdvancingThread.TabIndex = 7;
        chkRegenerateWithoutAdvancingThread.Text = "Edit mode";
        chkRegenerateWithoutAdvancingThread.UseVisualStyleBackColor = true;
        // 
        // pnlEntryListActions
        // 
        pnlEntryListActions.Controls.Add(btnEntryMoveDown);
        pnlEntryListActions.Controls.Add(btnEntryMoveUp);
        pnlEntryListActions.Controls.Add(btnEntryDelete);
        pnlEntryListActions.Controls.Add(btnEntryDuplicate);
        pnlEntryListActions.Controls.Add(btnNoticeEntryAdd);
        pnlEntryListActions.Controls.Add(btnEntryAdd);
        pnlEntryListActions.Dock = DockStyle.Top;
        pnlEntryListActions.Location = new Point(0, 0);
        pnlEntryListActions.Name = "pnlEntryListActions";
        pnlEntryListActions.Size = new Size(655, 36);
        pnlEntryListActions.TabIndex = 0;
        // 
        // btnEntryMoveDown
        // 
        btnEntryMoveDown.Dock = DockStyle.Left;
        btnEntryMoveDown.Location = new Point(406, 0);
        btnEntryMoveDown.Name = "btnEntryMoveDown";
        btnEntryMoveDown.Size = new Size(34, 36);
        btnEntryMoveDown.TabIndex = 0;
        btnEntryMoveDown.Text = "▼";
        btnEntryMoveDown.UseVisualStyleBackColor = true;
        // 
        // btnEntryMoveUp
        // 
        btnEntryMoveUp.Dock = DockStyle.Left;
        btnEntryMoveUp.Location = new Point(372, 0);
        btnEntryMoveUp.Name = "btnEntryMoveUp";
        btnEntryMoveUp.Size = new Size(34, 36);
        btnEntryMoveUp.TabIndex = 1;
        btnEntryMoveUp.Text = "▲";
        btnEntryMoveUp.UseVisualStyleBackColor = true;
        // 
        // btnEntryDelete
        // 
        btnEntryDelete.Dock = DockStyle.Left;
        btnEntryDelete.Location = new Point(302, 0);
        btnEntryDelete.Name = "btnEntryDelete";
        btnEntryDelete.Size = new Size(70, 36);
        btnEntryDelete.TabIndex = 2;
        btnEntryDelete.Text = "Delete";
        btnEntryDelete.UseVisualStyleBackColor = true;
        // 
        // btnEntryDuplicate
        // 
        btnEntryDuplicate.Dock = DockStyle.Left;
        btnEntryDuplicate.Location = new Point(226, 0);
        btnEntryDuplicate.Name = "btnEntryDuplicate";
        btnEntryDuplicate.Size = new Size(76, 36);
        btnEntryDuplicate.TabIndex = 3;
        btnEntryDuplicate.Text = "Duplicate";
        btnEntryDuplicate.UseVisualStyleBackColor = true;
        // 
        // btnNoticeEntryAdd
        // 
        btnNoticeEntryAdd.Dock = DockStyle.Left;
        btnNoticeEntryAdd.Location = new Point(116, 0);
        btnNoticeEntryAdd.Name = "btnNoticeEntryAdd";
        btnNoticeEntryAdd.Size = new Size(110, 36);
        btnNoticeEntryAdd.TabIndex = 4;
        btnNoticeEntryAdd.Text = "Add Notice";
        btnNoticeEntryAdd.UseVisualStyleBackColor = true;
        // 
        // btnEntryAdd
        // 
        btnEntryAdd.Dock = DockStyle.Left;
        btnEntryAdd.Location = new Point(0, 0);
        btnEntryAdd.Name = "btnEntryAdd";
        btnEntryAdd.Size = new Size(116, 36);
        btnEntryAdd.TabIndex = 5;
        btnEntryAdd.Text = "Add Traffic";
        btnEntryAdd.UseVisualStyleBackColor = true;
        // 
        // pnlEntryFilters
        // 
        pnlEntryFilters.Controls.Add(pnlEntryFilterSecondaryRow);
        pnlEntryFilters.Controls.Add(pnlEntryFilterPrimaryRow);
        pnlEntryFilters.Dock = DockStyle.Top;
        pnlEntryFilters.Location = new Point(0, 22);
        pnlEntryFilters.Name = "pnlEntryFilters";
        pnlEntryFilters.Size = new Size(655, 62);
        pnlEntryFilters.TabIndex = 1;
        // 
        // pnlEntryFilterSecondaryRow
        // 
        pnlEntryFilterSecondaryRow.Controls.Add(cboEntryFilterVessel);
        pnlEntryFilterSecondaryRow.Controls.Add(cboEntryFilterStation);
        pnlEntryFilterSecondaryRow.Controls.Add(chkShowLockedOnly);
        pnlEntryFilterSecondaryRow.Controls.Add(btnClearEntryFilters);
        pnlEntryFilterSecondaryRow.Dock = DockStyle.Top;
        pnlEntryFilterSecondaryRow.Location = new Point(0, 31);
        pnlEntryFilterSecondaryRow.Name = "pnlEntryFilterSecondaryRow";
        pnlEntryFilterSecondaryRow.Size = new Size(655, 31);
        pnlEntryFilterSecondaryRow.TabIndex = 1;
        // 
        // cboEntryFilterVessel
        // 
        cboEntryFilterVessel.Dock = DockStyle.Fill;
        cboEntryFilterVessel.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterVessel.Location = new Point(0, 0);
        cboEntryFilterVessel.Name = "cboEntryFilterVessel";
        cboEntryFilterVessel.Size = new Size(413, 33);
        cboEntryFilterVessel.TabIndex = 0;
        // 
        // cboEntryFilterStation
        // 
        cboEntryFilterStation.Dock = DockStyle.Right;
        cboEntryFilterStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterStation.Location = new Point(413, 0);
        cboEntryFilterStation.Name = "cboEntryFilterStation";
        cboEntryFilterStation.Size = new Size(130, 33);
        cboEntryFilterStation.TabIndex = 1;
        // 
        // chkShowLockedOnly
        // 
        chkShowLockedOnly.Dock = DockStyle.Right;
        chkShowLockedOnly.Location = new Point(543, 0);
        chkShowLockedOnly.Name = "chkShowLockedOnly";
        chkShowLockedOnly.Size = new Size(60, 31);
        chkShowLockedOnly.TabIndex = 2;
        chkShowLockedOnly.Text = "Locked";
        chkShowLockedOnly.UseVisualStyleBackColor = true;
        // 
        // btnClearEntryFilters
        // 
        btnClearEntryFilters.Dock = DockStyle.Right;
        btnClearEntryFilters.Location = new Point(603, 0);
        btnClearEntryFilters.Name = "btnClearEntryFilters";
        btnClearEntryFilters.Size = new Size(52, 31);
        btnClearEntryFilters.TabIndex = 3;
        btnClearEntryFilters.Text = "Clear";
        btnClearEntryFilters.UseVisualStyleBackColor = true;
        // 
        // pnlEntryFilterPrimaryRow
        // 
        pnlEntryFilterPrimaryRow.Controls.Add(txtEntrySearch);
        pnlEntryFilterPrimaryRow.Controls.Add(lblEntrySearch);
        pnlEntryFilterPrimaryRow.Controls.Add(cboEntryFilterKind);
        pnlEntryFilterPrimaryRow.Controls.Add(lblEntryKind);
        pnlEntryFilterPrimaryRow.Dock = DockStyle.Top;
        pnlEntryFilterPrimaryRow.Location = new Point(0, 0);
        pnlEntryFilterPrimaryRow.Name = "pnlEntryFilterPrimaryRow";
        pnlEntryFilterPrimaryRow.Size = new Size(655, 31);
        pnlEntryFilterPrimaryRow.TabIndex = 0;
        // 
        // txtEntrySearch
        // 
        txtEntrySearch.Dock = DockStyle.Fill;
        txtEntrySearch.Location = new Point(77, 0);
        txtEntrySearch.Name = "txtEntrySearch";
        txtEntrySearch.Size = new Size(432, 31);
        txtEntrySearch.TabIndex = 1;
        // 
        // lblEntrySearch
        // 
        lblEntrySearch.Dock = DockStyle.Left;
        lblEntrySearch.Location = new Point(0, 0);
        lblEntrySearch.Name = "lblEntrySearch";
        lblEntrySearch.Size = new Size(77, 31);
        lblEntrySearch.TabIndex = 0;
        lblEntrySearch.Text = "Search:";
        lblEntrySearch.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cboEntryFilterKind
        // 
        cboEntryFilterKind.Dock = DockStyle.Right;
        cboEntryFilterKind.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterKind.Location = new Point(509, 0);
        cboEntryFilterKind.Name = "cboEntryFilterKind";
        cboEntryFilterKind.Size = new Size(110, 33);
        cboEntryFilterKind.TabIndex = 3;
        // 
        // lblEntryKind
        // 
        lblEntryKind.Dock = DockStyle.Right;
        lblEntryKind.Location = new Point(619, 0);
        lblEntryKind.Name = "lblEntryKind";
        lblEntryKind.Size = new Size(36, 31);
        lblEntryKind.TabIndex = 2;
        lblEntryKind.Text = "Kind:";
        lblEntryKind.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblEntries
        // 
        lblEntries.Dock = DockStyle.Top;
        lblEntries.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblEntries.Location = new Point(0, 0);
        lblEntries.Name = "lblEntries";
        lblEntries.Size = new Size(655, 22);
        lblEntries.TabIndex = 0;
        lblEntries.Text = "Entries";
        // 
        // pnlSelectedEntrySection
        // 
        pnlSelectedEntrySection.Controls.Add(ucEntryDetail);
        pnlSelectedEntrySection.Controls.Add(txtThreadSummary);
        pnlSelectedEntrySection.Controls.Add(txtEpisodeEntryPreview);
        pnlSelectedEntrySection.Dock = DockStyle.Fill;
        pnlSelectedEntrySection.Location = new Point(0, 0);
        pnlSelectedEntrySection.Name = "pnlSelectedEntrySection";
        pnlSelectedEntrySection.Size = new Size(655, 456);
        pnlSelectedEntrySection.TabIndex = 0;
        // 
        // ucEntryDetail
        // 
        ucEntryDetail.AutoScroll = true;
        ucEntryDetail.Dock = DockStyle.Fill;
        ucEntryDetail.Enabled = false;
        ucEntryDetail.Location = new Point(0, 0);
        ucEntryDetail.Margin = new Padding(4, 5, 4, 5);
        ucEntryDetail.Name = "ucEntryDetail";
        ucEntryDetail.Size = new Size(655, 298);
        ucEntryDetail.TabIndex = 0;
        // 
        // txtThreadSummary
        // 
        txtThreadSummary.BackColor = SystemColors.Info;
        txtThreadSummary.Dock = DockStyle.Bottom;
        txtThreadSummary.Location = new Point(0, 298);
        txtThreadSummary.Multiline = true;
        txtThreadSummary.Name = "txtThreadSummary";
        txtThreadSummary.ReadOnly = true;
        txtThreadSummary.ScrollBars = ScrollBars.Vertical;
        txtThreadSummary.Size = new Size(655, 68);
        txtThreadSummary.TabIndex = 1;
        // 
        // txtEpisodeEntryPreview
        // 
        txtEpisodeEntryPreview.BackColor = SystemColors.ControlLight;
        txtEpisodeEntryPreview.Dock = DockStyle.Bottom;
        txtEpisodeEntryPreview.Location = new Point(0, 366);
        txtEpisodeEntryPreview.Multiline = true;
        txtEpisodeEntryPreview.Name = "txtEpisodeEntryPreview";
        txtEpisodeEntryPreview.ReadOnly = true;
        txtEpisodeEntryPreview.ScrollBars = ScrollBars.Vertical;
        txtEpisodeEntryPreview.Size = new Size(655, 90);
        txtEpisodeEntryPreview.TabIndex = 2;
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
        pnlSeriesSection.ResumeLayout(false);
        pnlSeriesActions.ResumeLayout(false);
        pnlEpisodeSection.ResumeLayout(false);
        pnlEpisodeSection.PerformLayout();
        pnlEpisodeActions.ResumeLayout(false);
        splitEpisodeWorkspace.Panel1.ResumeLayout(false);
        splitEpisodeWorkspace.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitEpisodeWorkspace).EndInit();
        splitEpisodeWorkspace.ResumeLayout(false);
        pnlEntryListSection.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridEpisodeEntries).EndInit();
        pnlEntryToolRows.ResumeLayout(false);
        pnlEntryExportTools.ResumeLayout(false);
        pnlEntryGenerationTools.ResumeLayout(false);
        pnlEntryGenerationTools.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numGenerateEntryCount).EndInit();
        pnlEntryListActions.ResumeLayout(false);
        pnlEntryFilters.ResumeLayout(false);
        pnlEntryFilterSecondaryRow.ResumeLayout(false);
        pnlEntryFilterPrimaryRow.ResumeLayout(false);
        pnlEntryFilterPrimaryRow.PerformLayout();
        pnlSelectedEntrySection.ResumeLayout(false);
        pnlSelectedEntrySection.PerformLayout();
        ResumeLayout(false);
    }

    // ── Control fields ─────────────────────────────────────────────────────────

    private SplitContainer splitEpisodesMain = null!;
    private SplitContainer splitSeriesEpisodes = null!;
    private SplitContainer splitEpisodeWorkspace = null!;

    private Panel pnlSeriesSection = null!;
    private Label lblSeries = null!;
    private ListBox lstSeries = null!;
    private Panel pnlSeriesActions = null!;
    private Button btnSeriesAdd = null!;
    private Button btnSeriesDelete = null!;
    private Button btnSeriesDuplicate = null!;

    private Panel pnlEpisodeSection = null!;
    private Label lblEpisodes = null!;
    private TextBox txtEpisodeSearch = null!;
    private ListBox lstEpisodes = null!;
    private TextBox txtEpisodeSummary = null!;
    private ucEpisodeMetaEditor ucMetaEditor = null!;
    private Panel pnlEpisodeActions = null!;
    private Button btnEpisodeAdd = null!;
    private Button btnEpisodeDelete = null!;
    private Button btnEpisodeDuplicate = null!;
    private Button btnNewEpisodeAfterSelected = null!;
    private Button btnLockEpisodeCanon = null!;
    private Button btnUnlockEpisodeCanon = null!;
    private Button btnEpisodeMoveUp = null!;
    private Button btnEpisodeMoveDown = null!;

    private Panel pnlEntryListSection = null!;
    private Label lblEntries = null!;
    private Panel pnlEntryFilters = null!;
    private Panel pnlEntryFilterPrimaryRow = null!;
    private Panel pnlEntryFilterSecondaryRow = null!;
    private Label lblEntrySearch = null!;
    private Label lblEntryKind = null!;
    private TextBox txtEntrySearch = null!;
    private ComboBox cboEntryFilterKind = null!;
    private ComboBox cboEntryFilterVessel = null!;
    private ComboBox cboEntryFilterStation = null!;
    private CheckBox chkShowLockedOnly = null!;
    private Button btnClearEntryFilters = null!;

    private DataGridView gridEpisodeEntries = null!;

    private Panel pnlEntryToolRows = null!;
    private Panel pnlEntryListActions = null!;
    private Panel pnlEntryGenerationTools = null!;
    private Panel pnlEntryExportTools = null!;

    private Button btnEntryAdd = null!;
    private Button btnNoticeEntryAdd = null!;
    private Button btnEntryDuplicate = null!;
    private Button btnEntryDelete = null!;
    private Button btnEntryMoveUp = null!;
    private Button btnEntryMoveDown = null!;

    private Button btnGenerateEntry = null!;
    private Button btnGenerateEpisodeEntries = null!;
    private Button btnRegenerateSelectedEntry = null!;
    private NumericUpDown numGenerateEntryCount = null!;
    private CheckBox chkClearEpisodeBeforeGenerate = null!;
    private Label lblGenerationSeed = null!;
    private TextBox txtGenerationSeed = null!;
    private CheckBox chkRegenerateWithoutAdvancingThread = null!;

    private Button btnExportEpisodeText = null!;
    private Button btnExportEpisodeTts = null!;
    private Button btnExportEpisodeJson = null!;
    private CheckBox chkExportIncludeHeader = null!;
    private CheckBox chkExportBlankLineBetweenEntries = null!;
    private CheckBox chkExportIncludeEntryMarkers = null!;
    private CheckBox chkExportAuthorDebugMode = null!;

    private Panel pnlSelectedEntrySection = null!;
    private ucEpisodeEntryDetail ucEntryDetail = null!;
    private TextBox txtThreadSummary = null!;
    private TextBox txtEpisodeEntryPreview = null!;
}