namespace PodcastUniverseEditor.UI.Controls;

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
        // Build helper panels first — they instantiate all named entry/meta controls into fields
        pnlEntryDetail       = BuildEntryDetailPanel();
        pnlEpisodeMetaEditor = BuildEpisodeMetaPanel();

        // ── Declare structural controls (all new() calls here — WinForms Designer convention) ──
        splitEpisodesMain             = new SplitContainer();
        splitSeriesEpisodes           = new SplitContainer();
        splitEpisodesRight            = new SplitContainer();
        lstSeries                     = new ListBox();
        btnSeriesAdd                  = new Button();
        btnSeriesDelete               = new Button();
        btnSeriesDuplicate            = new Button();
        lstEpisodes                   = new ListBox();
        txtEpisodeSearch              = new TextBox();
        txtEpisodeSummary             = new TextBox();
        btnEpisodeAdd                 = new Button();
        btnEpisodeDelete              = new Button();
        btnEpisodeDuplicate           = new Button();
        btnNewEpisodeAfterSelected    = new Button();
        btnLockEpisodeCanon           = new Button();
        btnUnlockEpisodeCanon         = new Button();
        btnEpisodeMoveUp              = new Button();
        btnEpisodeMoveDown            = new Button();
        gridEpisodeEntries            = new DataGridView();
        btnEntryAdd                   = new Button();
        btnNoticeEntryAdd             = new Button();
        btnEntryDuplicate             = new Button();
        btnEntryDelete                = new Button();
        btnEntryMoveUp                = new Button();
        btnEntryMoveDown              = new Button();
        btnGenerateEntry              = new Button();
        btnGenerateEpisodeEntries     = new Button();
        btnRegenerateSelectedEntry    = new Button();
        numGenerateEntryCount               = new NumericUpDown();
        chkClearEpisodeBeforeGenerate       = new CheckBox();
        chkRegenerateWithoutAdvancingThread = new CheckBox();
        txtGenerationSeed                   = new TextBox();
        btnExportEpisodeText             = new Button();
        btnExportEpisodeTts              = new Button();
        btnExportEpisodeJson             = new Button();
        chkExportIncludeHeader           = new CheckBox();
        chkExportBlankLineBetweenEntries = new CheckBox();
        chkExportIncludeEntryMarkers     = new CheckBox();
        chkExportAuthorDebugMode         = new CheckBox();
        txtEntrySearch        = new TextBox();
        cboEntryFilterKind    = new ComboBox();
        cboEntryFilterVessel  = new ComboBox();
        cboEntryFilterStation = new ComboBox();
        chkShowLockedOnly     = new CheckBox();
        btnClearEntryFilters  = new Button();
        txtEpisodeEntryPreview = new TextBox();
        txtThreadSummary       = new TextBox();

        ((System.ComponentModel.ISupportInitialize)gridEpisodeEntries).BeginInit();
        SuspendLayout();

        // ── splitEpisodesMain ─────────────────────────────────────────────────
        splitEpisodesMain.Name             = "splitEpisodesMain";
        splitEpisodesMain.Dock             = DockStyle.Fill;
        splitEpisodesMain.Orientation      = Orientation.Vertical;
        splitEpisodesMain.SplitterDistance = 240;
        splitEpisodesMain.Panel1MinSize    = 160;

        // ── splitSeriesEpisodes ───────────────────────────────────────────────
        splitSeriesEpisodes.Name             = "splitSeriesEpisodes";
        splitSeriesEpisodes.Dock             = DockStyle.Fill;
        splitSeriesEpisodes.Orientation      = Orientation.Horizontal;
        splitSeriesEpisodes.SplitterDistance = 140;
        splitSeriesEpisodes.Panel1MinSize    = 80;

        // ── Series section (top of left) ──────────────────────────────────────
        var seriesPanel        = new Panel { Dock = DockStyle.Fill };
        var lblSeries          = new Label  { Text = "Series", Dock = DockStyle.Top, Height = 20, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };
        var seriesButtonsPanel = new Panel  { Dock = DockStyle.Bottom, Height = 30, Padding = new Padding(4) };

        btnSeriesAdd.Name       = "btnSeriesAdd";
        btnSeriesAdd.Text       = "Add";
        btnSeriesAdd.Width      = 70;
        btnSeriesAdd.Dock       = DockStyle.Left;

        btnSeriesDelete.Name    = "btnSeriesDelete";
        btnSeriesDelete.Text    = "Delete";
        btnSeriesDelete.Width   = 70;
        btnSeriesDelete.Dock    = DockStyle.Left;

        btnSeriesDuplicate.Name = "btnSeriesDuplicate";
        btnSeriesDuplicate.Text = "Dup";
        btnSeriesDuplicate.Width = 46;
        btnSeriesDuplicate.Dock  = DockStyle.Left;

        // DockStyle.Left: last-added = leftmost. Visual order: [Add][Delete][Dup]
        seriesButtonsPanel.Controls.AddRange(new Control[] { btnSeriesDuplicate, btnSeriesDelete, btnSeriesAdd });

        lstSeries.Name           = "lstSeries";
        lstSeries.Dock           = DockStyle.Fill;
        lstSeries.IntegralHeight = false;

        seriesPanel.Controls.Add(lstSeries);
        seriesPanel.Controls.Add(lblSeries);
        seriesPanel.Controls.Add(seriesButtonsPanel);
        splitSeriesEpisodes.Panel1.Controls.Add(seriesPanel);

        // ── Episode section (bottom of left) ──────────────────────────────────
        var leftPanel   = new Panel { Dock = DockStyle.Fill };
        var leftButtons = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(4) };

        btnEpisodeAdd.Name   = "btnEpisodeAdd";
        btnEpisodeAdd.Text   = "Add";
        btnEpisodeAdd.Width  = 70;
        btnEpisodeAdd.Dock   = DockStyle.Left;

        btnEpisodeDelete.Name  = "btnEpisodeDelete";
        btnEpisodeDelete.Text  = "Delete";
        btnEpisodeDelete.Width = 70;
        btnEpisodeDelete.Dock  = DockStyle.Left;

        leftButtons.Controls.AddRange(new Control[] { btnEpisodeDelete, btnEpisodeAdd });

        var episodeActionsPanel = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(4) };

        btnEpisodeDuplicate.Name        = "btnEpisodeDuplicate";
        btnEpisodeDuplicate.Text        = "Dup";
        btnEpisodeDuplicate.Width       = 46;
        btnEpisodeDuplicate.Dock        = DockStyle.Left;

        btnNewEpisodeAfterSelected.Name  = "btnNewEpisodeAfterSelected";
        btnNewEpisodeAfterSelected.Text  = "Ins";
        btnNewEpisodeAfterSelected.Width = 40;
        btnNewEpisodeAfterSelected.Dock  = DockStyle.Left;

        btnLockEpisodeCanon.Name    = "btnLockEpisodeCanon";
        btnLockEpisodeCanon.Text    = "Lock";
        btnLockEpisodeCanon.Width   = 48;
        btnLockEpisodeCanon.Dock    = DockStyle.Left;

        btnUnlockEpisodeCanon.Name  = "btnUnlockEpisodeCanon";
        btnUnlockEpisodeCanon.Text  = "Unlock";
        btnUnlockEpisodeCanon.Width = 56;
        btnUnlockEpisodeCanon.Dock  = DockStyle.Left;

        btnEpisodeMoveUp.Name   = "btnEpisodeMoveUp";
        btnEpisodeMoveUp.Text   = "▲";
        btnEpisodeMoveUp.Width  = 34;
        btnEpisodeMoveUp.Dock   = DockStyle.Left;

        btnEpisodeMoveDown.Name  = "btnEpisodeMoveDown";
        btnEpisodeMoveDown.Text  = "▼";
        btnEpisodeMoveDown.Width = 34;
        btnEpisodeMoveDown.Dock  = DockStyle.Left;

        // DockStyle.Left: last-added = leftmost. Visual order: [Unlock][Lock][Ins][Dup][▲][▼]
        episodeActionsPanel.Controls.AddRange(new Control[] { btnEpisodeMoveDown, btnEpisodeMoveUp, btnEpisodeDuplicate, btnNewEpisodeAfterSelected, btnLockEpisodeCanon, btnUnlockEpisodeCanon });

        txtEpisodeSummary.Name       = "txtEpisodeSummary";
        txtEpisodeSummary.Dock       = DockStyle.Bottom;
        txtEpisodeSummary.Height     = 70;
        txtEpisodeSummary.Multiline  = true;
        txtEpisodeSummary.ReadOnly   = true;
        txtEpisodeSummary.ScrollBars = ScrollBars.Vertical;
        txtEpisodeSummary.BackColor  = SystemColors.ControlLight;

        lstEpisodes.Name           = "lstEpisodes";
        lstEpisodes.Dock           = DockStyle.Fill;
        lstEpisodes.IntegralHeight = false;

        txtEpisodeSearch.Name            = "txtEpisodeSearch";
        txtEpisodeSearch.Dock            = DockStyle.Top;
        txtEpisodeSearch.PlaceholderText = "Search episodes...";

        var lblEpisodes = new Label { Text = "Episodes", Dock = DockStyle.Top, Height = 20, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };

        // Add Fill first, then Top (last Top added = topmost), then Bottom (last Bottom added = bottommost)
        leftPanel.Controls.Add(lstEpisodes);
        leftPanel.Controls.Add(lblEpisodes);
        leftPanel.Controls.Add(txtEpisodeSearch);
        leftPanel.Controls.Add(txtEpisodeSummary);
        leftPanel.Controls.Add(pnlEpisodeMetaEditor);
        leftPanel.Controls.Add(episodeActionsPanel);
        leftPanel.Controls.Add(leftButtons);

        splitSeriesEpisodes.Panel2.Controls.Add(leftPanel);
        splitEpisodesMain.Panel1.Controls.Add(splitSeriesEpisodes);

        // ── splitEpisodesRight ────────────────────────────────────────────────
        splitEpisodesRight.Name             = "splitEpisodesRight";
        splitEpisodesRight.Dock             = DockStyle.Fill;
        splitEpisodesRight.Orientation      = Orientation.Horizontal;
        splitEpisodesRight.SplitterDistance = 200;
        splitEpisodesRight.Panel2MinSize    = 120;

        // ── Top of right: entry grid + label + filter + buttons ───────────────
        var gridPanel         = new Panel { Dock = DockStyle.Fill };
        var entryButtonsPanel = new Panel { Dock = DockStyle.Bottom, Height = 108 };

        // Row 1 (top) — manual entry management
        var entryRow1 = new Panel { Dock = DockStyle.Top, Height = 32, Padding = new Padding(2) };

        btnEntryAdd.Name       = "btnEntryAdd";
        btnEntryAdd.Text       = "Add Traffic";
        btnEntryAdd.Width      = 90;
        btnEntryAdd.Dock       = DockStyle.Left;

        btnNoticeEntryAdd.Name  = "btnNoticeEntryAdd";
        btnNoticeEntryAdd.Text  = "Add Notice";
        btnNoticeEntryAdd.Width = 90;
        btnNoticeEntryAdd.Dock  = DockStyle.Left;

        btnEntryDuplicate.Name  = "btnEntryDuplicate";
        btnEntryDuplicate.Text  = "Duplicate";
        btnEntryDuplicate.Width = 76;
        btnEntryDuplicate.Dock  = DockStyle.Left;

        btnEntryDelete.Name  = "btnEntryDelete";
        btnEntryDelete.Text  = "Delete";
        btnEntryDelete.Width = 70;
        btnEntryDelete.Dock  = DockStyle.Left;

        btnEntryMoveUp.Name  = "btnEntryMoveUp";
        btnEntryMoveUp.Text  = "▲";
        btnEntryMoveUp.Width = 34;
        btnEntryMoveUp.Dock  = DockStyle.Left;

        btnEntryMoveDown.Name  = "btnEntryMoveDown";
        btnEntryMoveDown.Text  = "▼";
        btnEntryMoveDown.Width = 34;
        btnEntryMoveDown.Dock  = DockStyle.Left;

        // Reversed: visual order is [Add Traffic][Add Notice][Duplicate][Delete][▲][▼]
        entryRow1.Controls.AddRange(new Control[] { btnEntryMoveDown, btnEntryMoveUp, btnEntryDelete, btnEntryDuplicate, btnNoticeEntryAdd, btnEntryAdd });

        // Row 2 (generation) — DockStyle.Bottom; added before row3 so row3 stacks below it
        var entryRow2 = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(2) };

        btnGenerateEntry.Name   = "btnGenerateEntry";
        btnGenerateEntry.Text   = "Gen Entry";
        btnGenerateEntry.Width  = 80;
        btnGenerateEntry.Dock   = DockStyle.Left;

        btnGenerateEpisodeEntries.Name   = "btnGenerateEpisodeEntries";
        btnGenerateEpisodeEntries.Text   = "Fill Episode";
        btnGenerateEpisodeEntries.Width  = 88;
        btnGenerateEpisodeEntries.Dock   = DockStyle.Left;

        btnRegenerateSelectedEntry.Name  = "btnRegenerateSelectedEntry";
        btnRegenerateSelectedEntry.Text  = "Regen";
        btnRegenerateSelectedEntry.Width = 56;
        btnRegenerateSelectedEntry.Dock  = DockStyle.Left;

        numGenerateEntryCount.Name    = "numGenerateEntryCount";
        numGenerateEntryCount.Width   = 50;
        numGenerateEntryCount.Dock    = DockStyle.Left;
        numGenerateEntryCount.Minimum = 1;
        numGenerateEntryCount.Maximum = 100;
        numGenerateEntryCount.Value   = 5;

        chkClearEpisodeBeforeGenerate.Name      = "chkClearEpisodeBeforeGenerate";
        chkClearEpisodeBeforeGenerate.Text      = "Clear";
        chkClearEpisodeBeforeGenerate.Width     = 52;
        chkClearEpisodeBeforeGenerate.Dock      = DockStyle.Left;
        chkClearEpisodeBeforeGenerate.Checked   = false;
        chkClearEpisodeBeforeGenerate.TextAlign = ContentAlignment.MiddleLeft;

        var lblSeed = new Label { Text = "Seed:", Width = 36, Dock = DockStyle.Left, TextAlign = ContentAlignment.MiddleLeft };

        txtGenerationSeed.Name  = "txtGenerationSeed";
        txtGenerationSeed.Width = 64;
        txtGenerationSeed.Dock  = DockStyle.Left;

        chkRegenerateWithoutAdvancingThread.Name      = "chkRegenerateWithoutAdvancingThread";
        chkRegenerateWithoutAdvancingThread.Text      = "Edit mode";
        chkRegenerateWithoutAdvancingThread.Width     = 76;
        chkRegenerateWithoutAdvancingThread.Dock      = DockStyle.Left;
        chkRegenerateWithoutAdvancingThread.Checked   = true;
        chkRegenerateWithoutAdvancingThread.TextAlign = ContentAlignment.MiddleLeft;

        entryRow2.Controls.AddRange(new Control[]
        {
            btnGenerateEntry, btnGenerateEpisodeEntries, btnRegenerateSelectedEntry,
            numGenerateEntryCount, chkClearEpisodeBeforeGenerate, lblSeed, txtGenerationSeed,
            chkRegenerateWithoutAdvancingThread
        });

        // Row 3 (export) — added before row2 so row2 stacks above it (both DockStyle.Bottom)
        var entryRow3 = new Panel { Dock = DockStyle.Bottom, Height = 36, Padding = new Padding(2) };

        btnExportEpisodeText.Name  = "btnExportEpisodeText";
        btnExportEpisodeText.Text  = "Broadcast";
        btnExportEpisodeText.Width = 76;
        btnExportEpisodeText.Dock  = DockStyle.Left;

        btnExportEpisodeTts.Name  = "btnExportEpisodeTts";
        btnExportEpisodeTts.Text  = "TTS";
        btnExportEpisodeTts.Width = 48;
        btnExportEpisodeTts.Dock  = DockStyle.Left;

        btnExportEpisodeJson.Name  = "btnExportEpisodeJson";
        btnExportEpisodeJson.Text  = "JSON";
        btnExportEpisodeJson.Width = 52;
        btnExportEpisodeJson.Dock  = DockStyle.Left;

        chkExportIncludeHeader.Name      = "chkExportIncludeHeader";
        chkExportIncludeHeader.Text      = "Header";
        chkExportIncludeHeader.Width     = 58;
        chkExportIncludeHeader.Dock      = DockStyle.Left;
        chkExportIncludeHeader.Checked   = true;
        chkExportIncludeHeader.TextAlign = ContentAlignment.MiddleLeft;

        chkExportBlankLineBetweenEntries.Name      = "chkExportBlankLineBetweenEntries";
        chkExportBlankLineBetweenEntries.Text      = "Blanks";
        chkExportBlankLineBetweenEntries.Width     = 52;
        chkExportBlankLineBetweenEntries.Dock      = DockStyle.Left;
        chkExportBlankLineBetweenEntries.Checked   = true;
        chkExportBlankLineBetweenEntries.TextAlign = ContentAlignment.MiddleLeft;

        chkExportIncludeEntryMarkers.Name      = "chkExportIncludeEntryMarkers";
        chkExportIncludeEntryMarkers.Text      = "Markers";
        chkExportIncludeEntryMarkers.Width     = 60;
        chkExportIncludeEntryMarkers.Dock      = DockStyle.Left;
        chkExportIncludeEntryMarkers.Checked   = false;
        chkExportIncludeEntryMarkers.TextAlign = ContentAlignment.MiddleLeft;

        chkExportAuthorDebugMode.Name      = "chkExportAuthorDebugMode";
        chkExportAuthorDebugMode.Text      = "Debug";
        chkExportAuthorDebugMode.Width     = 52;
        chkExportAuthorDebugMode.Dock      = DockStyle.Left;
        chkExportAuthorDebugMode.Checked   = false;
        chkExportAuthorDebugMode.TextAlign = ContentAlignment.MiddleLeft;

        entryRow3.Controls.AddRange(new Control[]
        {
            btnExportEpisodeText, btnExportEpisodeTts, btnExportEpisodeJson,
            chkExportIncludeHeader, chkExportBlankLineBetweenEntries,
            chkExportIncludeEntryMarkers, chkExportAuthorDebugMode
        });

        entryButtonsPanel.Controls.Add(entryRow1);
        entryButtonsPanel.Controls.Add(entryRow3);   // added before row2: row3=bottommost, row2=above
        entryButtonsPanel.Controls.Add(entryRow2);

        var lblEntries = new Label { Text = "Entries", Dock = DockStyle.Top, Height = 20, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };

        var entryFilterPanel = new Panel { Dock = DockStyle.Top, Height = 58, Padding = new Padding(1) };

        // Filter Row 1: free-text search + kind filter
        var filterRow1     = new Panel { Dock = DockStyle.Top, Height = 27 };
        var lblEntrySearch = new Label { Text = "Search:", Width = 50, Dock = DockStyle.Left,  TextAlign = ContentAlignment.MiddleLeft };
        var lblEntryKind   = new Label { Text = "Kind:",   Width = 36, Dock = DockStyle.Right, TextAlign = ContentAlignment.MiddleRight };

        cboEntryFilterKind.Name          = "cboEntryFilterKind";
        cboEntryFilterKind.Dock          = DockStyle.Right;
        cboEntryFilterKind.Width         = 110;
        cboEntryFilterKind.DropDownStyle = ComboBoxStyle.DropDownList;

        txtEntrySearch.Name = "txtEntrySearch";
        txtEntrySearch.Dock = DockStyle.Fill;

        filterRow1.Controls.Add(lblEntryKind);       // Right, first → left of kind combo
        filterRow1.Controls.Add(cboEntryFilterKind); // Right, last  → rightmost
        filterRow1.Controls.Add(lblEntrySearch);      // Left         → leftmost
        filterRow1.Controls.Add(txtEntrySearch);      // Fill         → remaining space

        // Filter Row 2: vessel filter, station filter, locked-only checkbox, clear button
        var filterRow2 = new Panel { Dock = DockStyle.Top, Height = 27 };

        cboEntryFilterVessel.Name          = "cboEntryFilterVessel";
        cboEntryFilterVessel.Dock          = DockStyle.Fill;
        cboEntryFilterVessel.DropDownStyle = ComboBoxStyle.DropDownList;

        cboEntryFilterStation.Name          = "cboEntryFilterStation";
        cboEntryFilterStation.Dock          = DockStyle.Right;
        cboEntryFilterStation.Width         = 130;
        cboEntryFilterStation.DropDownStyle = ComboBoxStyle.DropDownList;

        chkShowLockedOnly.Name      = "chkShowLockedOnly";
        chkShowLockedOnly.Text      = "Locked";
        chkShowLockedOnly.Dock      = DockStyle.Right;
        chkShowLockedOnly.Width     = 60;
        chkShowLockedOnly.TextAlign = ContentAlignment.MiddleLeft;

        btnClearEntryFilters.Name  = "btnClearEntryFilters";
        btnClearEntryFilters.Dock  = DockStyle.Right;
        btnClearEntryFilters.Width = 52;
        btnClearEntryFilters.Text  = "Clear";

        filterRow2.Controls.Add(cboEntryFilterStation); // Right, first → leftmost of right group
        filterRow2.Controls.Add(chkShowLockedOnly);      // Right, second
        filterRow2.Controls.Add(btnClearEntryFilters);   // Right, last  → rightmost
        filterRow2.Controls.Add(cboEntryFilterVessel);   // Fill         → left side

        // DockStyle.Top: last added = topmost. Add row2 first so row1 lands on top.
        entryFilterPanel.Controls.Add(filterRow2);
        entryFilterPanel.Controls.Add(filterRow1);

        gridEpisodeEntries.Name               = "gridEpisodeEntries";
        gridEpisodeEntries.Dock               = DockStyle.Fill;
        gridEpisodeEntries.AutoGenerateColumns = false;
        gridEpisodeEntries.AllowUserToAddRows  = false;
        gridEpisodeEntries.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
        gridEpisodeEntries.MultiSelect         = false;

        gridPanel.Controls.Add(gridEpisodeEntries);
        gridPanel.Controls.Add(lblEntries);
        gridPanel.Controls.Add(entryFilterPanel);
        gridPanel.Controls.Add(entryButtonsPanel);

        // ── Bottom of right: detail panel + thread summary + preview ──────────
        var detailArea = new Panel { Dock = DockStyle.Fill };

        txtEpisodeEntryPreview.Name       = "txtEpisodeEntryPreview";
        txtEpisodeEntryPreview.Dock       = DockStyle.Bottom;
        txtEpisodeEntryPreview.Height     = 100;
        txtEpisodeEntryPreview.Multiline  = true;
        txtEpisodeEntryPreview.ReadOnly   = true;
        txtEpisodeEntryPreview.ScrollBars = ScrollBars.Vertical;
        txtEpisodeEntryPreview.BackColor  = SystemColors.ControlLight;

        txtThreadSummary.Name       = "txtThreadSummary";
        txtThreadSummary.Dock       = DockStyle.Bottom;
        txtThreadSummary.Height     = 80;
        txtThreadSummary.Multiline  = true;
        txtThreadSummary.ReadOnly   = true;
        txtThreadSummary.ScrollBars = ScrollBars.Vertical;
        txtThreadSummary.BackColor  = SystemColors.Info;

        detailArea.Controls.Add(pnlEntryDetail);
        detailArea.Controls.Add(txtThreadSummary);
        detailArea.Controls.Add(txtEpisodeEntryPreview);

        splitEpisodesRight.Panel1.Controls.Add(gridPanel);
        splitEpisodesRight.Panel2.Controls.Add(detailArea);

        splitEpisodesMain.Panel2.Controls.Add(splitEpisodesRight);

        // ── ucEpisodes ────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(splitEpisodesMain);
        Name = "ucEpisodes";
        Size = new Size(1040, 760);

        ((System.ComponentModel.ISupportInitialize)gridEpisodeEntries).EndInit();
        ResumeLayout(false);
    }

    // ── Entry detail panel builder ────────────────────────────────────────────

    /// <summary>
    /// Builds the scrollable entry-detail panel containing all named entry editor controls.
    /// All named controls (cboEntryKind, txtEntryName, etc.) are assigned to their fields here.
    /// Returns the scroll Panel — caller assigns it to pnlEntryDetail.
    /// </summary>
    private Panel BuildEntryDetailPanel()
    {
        var scroll = new Panel
        {
            Name       = "pnlEntryDetail",
            Dock       = DockStyle.Fill,
            AutoScroll = true,
            Enabled    = false
        };

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
                Text      = title,
                Dock      = DockStyle.Fill,
                Font      = new Font(SystemFonts.DefaultFont, FontStyle.Bold),
                ForeColor = SystemColors.ControlDarkDark,
                Padding   = new Padding(0, 6, 0, 0)
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
        AddRow("Notes:", txtEntryNotes, 64);

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
        AddRow("Public Body Override:", txtEntryPublicBodyOverride, 64);

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
        AddRow("Hidden Truth Notes:", txtEntryHiddenTruthNotes, 64);

        // ── Schedule ──────────────────────────────────────────────────────────

        AddSection("Schedule");

        var schedPanel = new Panel();
        chkEntryScheduledEnabled = new CheckBox     { Name = "chkEntryScheduledEnabled", Width = 22, Location = new Point(0, 5) };
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
            grid.Dock               = DockStyle.Fill;
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
        AddFullRow(gridDeclaredCargo, btnDeclaredCargoAdd, btnDeclaredCargoDelete, 130);

        AddSection("Actual Cargo");
        gridActualCargo      = new DataGridView { Name = "gridActualCargo" };
        btnActualCargoAdd    = new Button       { Name = "btnActualCargoAdd" };
        btnActualCargoDelete = new Button       { Name = "btnActualCargoDelete" };
        AddFullRow(gridActualCargo, btnActualCargoAdd, btnActualCargoDelete, 130);

        AddSection("Declared Passengers");
        gridDeclaredPassengers      = new DataGridView { Name = "gridDeclaredPassengers" };
        btnDeclaredPassengerAdd     = new Button       { Name = "btnDeclaredPassengerAdd" };
        btnDeclaredPassengerDelete  = new Button       { Name = "btnDeclaredPassengerDelete" };
        AddFullRow(gridDeclaredPassengers, btnDeclaredPassengerAdd, btnDeclaredPassengerDelete, 110);

        AddSection("Actual Passengers");
        gridActualPassengers      = new DataGridView { Name = "gridActualPassengers" };
        btnActualPassengerAdd     = new Button       { Name = "btnActualPassengerAdd" };
        btnActualPassengerDelete  = new Button       { Name = "btnActualPassengerDelete" };
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

    // ── Episode metadata panel builder ────────────────────────────────────────

    /// <summary>
    /// Builds the scrollable episode/series metadata editing panel shown in the left panel.
    /// Assigns all episode/series editor controls to their fields.
    /// Returns pnlEpisodeMetaEditor.
    /// </summary>
    private Panel BuildEpisodeMetaPanel()
    {
        pnlEpisodeMetaEditor = new Panel
        {
            Name       = "pnlEpisodeMetaEditor",
            Dock       = DockStyle.Bottom,
            Height     = 260,
            AutoScroll = true,
            Enabled    = false
        };

        var tbl = new TableLayoutPanel
        {
            Name        = "tblEpisodeMeta",
            Dock        = DockStyle.Top,
            AutoSize    = true,
            ColumnCount = 2,
            Padding     = new Padding(2, 2, 2, 4)
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
                Text      = title,
                Dock      = DockStyle.Fill,
                Font      = new Font(SystemFonts.DefaultFont, FontStyle.Bold),
                ForeColor = SystemColors.ControlDarkDark,
                Padding   = new Padding(0, 4, 0, 0)
            };
            tbl.Controls.Add(lbl, 0, mRow);
            tbl.SetColumnSpan(lbl, 2);
            tbl.RowCount = ++mRow;
        }

        // ── Episode section ────────────────────────────────────────────────────

        AddMetaSection("Episode");

        txtEpisodeName = new TextBox { Name = "txtEpisodeName" };
        AddMetaRow("Name:", txtEpisodeName);

        var datePanel = new Panel();
        chkEpisodeHasInUniverseDate = new CheckBox { Name = "chkEpisodeHasInUniverseDate", Width = 20, Location = new Point(0, 5) };
        dtpEpisodeInUniverseUtc     = new DateTimePicker
        {
            Name     = "dtpEpisodeInUniverseUtc",
            Enabled  = false,
            Location = new Point(22, 2),
            Width    = 120,
            Format   = DateTimePickerFormat.Short,
            Anchor   = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
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

        // ── Series section ─────────────────────────────────────────────────────

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

    // ── Control fields ────────────────────────────────────────────────────────

    // Structural splits (not exposed — MainForm.cs does not reference these)
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

    // Entry detail panel
    private Panel          pnlEntryDetail     = null!;
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
    private Button btnDeclaredCargoAdd       = null!;
    private Button btnDeclaredCargoDelete    = null!;
    private Button btnActualCargoAdd         = null!;
    private Button btnActualCargoDelete      = null!;
    private Button btnDeclaredPassengerAdd    = null!;
    private Button btnDeclaredPassengerDelete = null!;
    private Button btnActualPassengerAdd      = null!;
    private Button btnActualPassengerDelete   = null!;

    // Episode metadata editor
    private Panel         pnlEpisodeMetaEditor        = null!;
    private TextBox       txtEpisodeName              = null!;
    private CheckBox      chkEpisodeHasInUniverseDate = null!;
    private DateTimePicker dtpEpisodeInUniverseUtc    = null!;
    private ComboBox      cboEpisodeBroadcastStation  = null!;
    private ComboBox      cboEpisodeSeries            = null!;
    private CheckBox      chkEpisodeCanonicalLocked   = null!;
    private TextBox       txtEpisodeNotes             = null!;
    private TextBox       txtSeriesName               = null!;
    private ComboBox      cboSeriesBroadcastStation   = null!;
    private TextBox       txtSeriesNotes              = null!;
}
