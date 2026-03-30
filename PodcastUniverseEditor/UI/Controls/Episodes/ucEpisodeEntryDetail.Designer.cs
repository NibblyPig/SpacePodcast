namespace PodcastUniverseEditor.UI.Controls.Episodes;

partial class ucEpisodeEntryDetail
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
        pnlScrollHost = new Panel();
        tblEntryDetailLayout = new TableLayoutPanel();
        lblEntrySection = new Label();
        lblEntryKind = new Label();
        cboEntryKind = new ComboBox();
        lblEntrySourceType = new Label();
        cboEntrySourceType = new ComboBox();
        lblEntryName = new Label();
        txtEntryName = new TextBox();
        lblEntrySortOrder = new Label();
        numEntrySortOrder = new NumericUpDown();
        lblEntryFlags = new Label();
        pnlEntryFlags = new Panel();
        chkEntryCanon = new CheckBox();
        chkEntryLocked = new CheckBox();
        lblEntryRandomSeed = new Label();
        numEntryRandomSeed = new NumericUpDown();
        lblEntryNotes = new Label();
        txtEntryNotes = new TextBox();
        lblOperationNoticeSection = new Label();
        lblEntryOperationType = new Label();
        cboEntryOperationType = new ComboBox();
        lblEntryNoticeType = new Label();
        cboEntryNoticeType = new ComboBox();
        lblLocationSection = new Label();
        lblEntryStation = new Label();
        cboEntryStation = new ComboBox();
        lblEntryDock = new Label();
        cboEntryDock = new ComboBox();
        lblEntryOriginStation = new Label();
        cboEntryOriginStation = new ComboBox();
        lblEntryDestinationStation = new Label();
        cboEntryDestinationStation = new ComboBox();
        lblVesselSection = new Label();
        lblEntryVessel = new Label();
        cboEntryVessel = new ComboBox();
        lblEntryVesselClassOverride = new Label();
        cboEntryVesselClassOverride = new ComboBox();
        lblEntryRegistryOverride = new Label();
        txtEntryRegistryOverride = new TextBox();
        lblPurposeSection = new Label();
        lblEntryDeclaredPurpose = new Label();
        cboEntryDeclaredPurpose = new ComboBox();
        lblEntryActualPurpose = new Label();
        cboEntryActualPurpose = new ComboBox();
        lblStatusesSection = new Label();
        lblEntryManifestStatus = new Label();
        cboEntryManifestStatus = new ComboBox();
        lblEntryInspectionStatus = new Label();
        cboEntryInspectionStatus = new ComboBox();
        lblEntryClearanceStatus = new Label();
        cboEntryClearanceStatus = new ComboBox();
        lblEntryEnvironmentalCondition = new Label();
        cboEntryEnvironmentalCondition = new ComboBox();
        lblNarrativeSection = new Label();
        lblEntryDirective = new Label();
        cboEntryDirective = new ComboBox();
        lblEntryIncidentPhrase = new Label();
        cboEntryIncidentPhrase = new ComboBox();
        lblEntryResolutionPhrase = new Label();
        cboEntryResolutionPhrase = new ComboBox();
        lblEntryRouteStatusPhrase = new Label();
        cboEntryRouteStatusPhrase = new ComboBox();
        lblEntryPublicBodyOverride = new Label();
        txtEntryPublicBodyOverride = new TextBox();
        lblStoryThreadSection = new Label();
        lblEntryStoryThread = new Label();
        cboEntryStoryThread = new ComboBox();
        lblEntryAppliedStoryBeat = new Label();
        cboEntryAppliedStoryBeat = new ComboBox();
        lblEntryAnomalySeverity = new Label();
        cboEntryAnomalySeverity = new ComboBox();
        lblHiddenTruthSection = new Label();
        lblEntryHiddenTruthNotes = new Label();
        txtEntryHiddenTruthNotes = new TextBox();
        lblScheduleSection = new Label();
        lblEntryScheduledUtc = new Label();
        pnlEntrySchedule = new Panel();
        dtpEntryScheduledUtc = new DateTimePicker();
        chkEntryScheduledEnabled = new CheckBox();
        lblDeclaredCargoSection = new Label();
        pnlDeclaredCargoContainer = new Panel();
        lblActualCargoSection = new Label();
        pnlActualCargoContainer = new Panel();
        lblDeclaredPassengersSection = new Label();
        pnlDeclaredPassengersContainer = new Panel();
        lblActualPassengersSection = new Label();
        pnlActualPassengersContainer = new Panel();
        flpValidationHints = new FlowLayoutPanel();
        gridDeclaredCargo = new DataGridView();
        pnlDeclaredCargoActions = new Panel();
        btnDeclaredCargoDelete = new Button();
        btnDeclaredCargoAdd = new Button();
        gridActualCargo = new DataGridView();
        pnlActualCargoActions = new Panel();
        btnActualCargoDelete = new Button();
        btnActualCargoAdd = new Button();
        gridDeclaredPassengers = new DataGridView();
        pnlDeclaredPassengersActions = new Panel();
        btnDeclaredPassengerDelete = new Button();
        btnDeclaredPassengerAdd = new Button();
        gridActualPassengers = new DataGridView();
        pnlActualPassengersActions = new Panel();
        btnActualPassengerDelete = new Button();
        btnActualPassengerAdd = new Button();
        pnlScrollHost.SuspendLayout();
        tblEntryDetailLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numEntrySortOrder).BeginInit();
        pnlEntryFlags.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numEntryRandomSeed).BeginInit();
        pnlEntrySchedule.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredCargo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridActualCargo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredPassengers).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridActualPassengers).BeginInit();
        SuspendLayout();
        // 
        // pnlScrollHost
        // 
        pnlScrollHost.AutoScroll = true;
        pnlScrollHost.Controls.Add(tblEntryDetailLayout);
        pnlScrollHost.Controls.Add(flpValidationHints);
        pnlScrollHost.Dock = DockStyle.Fill;
        pnlScrollHost.Location = new Point(0, 0);
        pnlScrollHost.Margin = new Padding(4, 5, 4, 5);
        pnlScrollHost.Name = "pnlScrollHost";
        pnlScrollHost.Size = new Size(571, 1000);
        pnlScrollHost.TabIndex = 0;
        // 
        // tblEntryDetailLayout
        // 
        tblEntryDetailLayout.AutoSize = true;
        tblEntryDetailLayout.ColumnCount = 2;
        tblEntryDetailLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 257F));
        tblEntryDetailLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblEntryDetailLayout.Controls.Add(lblEntrySection, 0, 0);
        tblEntryDetailLayout.Controls.Add(lblEntryKind, 0, 1);
        tblEntryDetailLayout.Controls.Add(cboEntryKind, 1, 1);
        tblEntryDetailLayout.Controls.Add(lblEntrySourceType, 0, 2);
        tblEntryDetailLayout.Controls.Add(cboEntrySourceType, 1, 2);
        tblEntryDetailLayout.Controls.Add(lblEntryName, 0, 3);
        tblEntryDetailLayout.Controls.Add(txtEntryName, 1, 3);
        tblEntryDetailLayout.Controls.Add(lblEntrySortOrder, 0, 4);
        tblEntryDetailLayout.Controls.Add(numEntrySortOrder, 1, 4);
        tblEntryDetailLayout.Controls.Add(lblEntryFlags, 0, 5);
        tblEntryDetailLayout.Controls.Add(pnlEntryFlags, 1, 5);
        tblEntryDetailLayout.Controls.Add(lblEntryRandomSeed, 0, 6);
        tblEntryDetailLayout.Controls.Add(numEntryRandomSeed, 1, 6);
        tblEntryDetailLayout.Controls.Add(lblEntryNotes, 0, 7);
        tblEntryDetailLayout.Controls.Add(txtEntryNotes, 1, 7);
        tblEntryDetailLayout.Controls.Add(lblOperationNoticeSection, 0, 8);
        tblEntryDetailLayout.Controls.Add(lblEntryOperationType, 0, 9);
        tblEntryDetailLayout.Controls.Add(cboEntryOperationType, 1, 9);
        tblEntryDetailLayout.Controls.Add(lblEntryNoticeType, 0, 10);
        tblEntryDetailLayout.Controls.Add(cboEntryNoticeType, 1, 10);
        tblEntryDetailLayout.Controls.Add(lblLocationSection, 0, 11);
        tblEntryDetailLayout.Controls.Add(lblEntryStation, 0, 12);
        tblEntryDetailLayout.Controls.Add(cboEntryStation, 1, 12);
        tblEntryDetailLayout.Controls.Add(lblEntryDock, 0, 13);
        tblEntryDetailLayout.Controls.Add(cboEntryDock, 1, 13);
        tblEntryDetailLayout.Controls.Add(lblEntryOriginStation, 0, 14);
        tblEntryDetailLayout.Controls.Add(cboEntryOriginStation, 1, 14);
        tblEntryDetailLayout.Controls.Add(lblEntryDestinationStation, 0, 15);
        tblEntryDetailLayout.Controls.Add(cboEntryDestinationStation, 1, 15);
        tblEntryDetailLayout.Controls.Add(lblVesselSection, 0, 16);
        tblEntryDetailLayout.Controls.Add(lblEntryVessel, 0, 17);
        tblEntryDetailLayout.Controls.Add(cboEntryVessel, 1, 17);
        tblEntryDetailLayout.Controls.Add(lblEntryVesselClassOverride, 0, 18);
        tblEntryDetailLayout.Controls.Add(cboEntryVesselClassOverride, 1, 18);
        tblEntryDetailLayout.Controls.Add(lblEntryRegistryOverride, 0, 19);
        tblEntryDetailLayout.Controls.Add(txtEntryRegistryOverride, 1, 19);
        tblEntryDetailLayout.Controls.Add(lblPurposeSection, 0, 20);
        tblEntryDetailLayout.Controls.Add(lblEntryDeclaredPurpose, 0, 21);
        tblEntryDetailLayout.Controls.Add(cboEntryDeclaredPurpose, 1, 21);
        tblEntryDetailLayout.Controls.Add(lblEntryActualPurpose, 0, 22);
        tblEntryDetailLayout.Controls.Add(cboEntryActualPurpose, 1, 22);
        tblEntryDetailLayout.Controls.Add(lblStatusesSection, 0, 23);
        tblEntryDetailLayout.Controls.Add(lblEntryManifestStatus, 0, 24);
        tblEntryDetailLayout.Controls.Add(cboEntryManifestStatus, 1, 24);
        tblEntryDetailLayout.Controls.Add(lblEntryInspectionStatus, 0, 25);
        tblEntryDetailLayout.Controls.Add(cboEntryInspectionStatus, 1, 25);
        tblEntryDetailLayout.Controls.Add(lblEntryClearanceStatus, 0, 26);
        tblEntryDetailLayout.Controls.Add(cboEntryClearanceStatus, 1, 26);
        tblEntryDetailLayout.Controls.Add(lblEntryEnvironmentalCondition, 0, 27);
        tblEntryDetailLayout.Controls.Add(cboEntryEnvironmentalCondition, 1, 27);
        tblEntryDetailLayout.Controls.Add(lblNarrativeSection, 0, 28);
        tblEntryDetailLayout.Controls.Add(lblEntryDirective, 0, 29);
        tblEntryDetailLayout.Controls.Add(cboEntryDirective, 1, 29);
        tblEntryDetailLayout.Controls.Add(lblEntryIncidentPhrase, 0, 30);
        tblEntryDetailLayout.Controls.Add(cboEntryIncidentPhrase, 1, 30);
        tblEntryDetailLayout.Controls.Add(lblEntryResolutionPhrase, 0, 31);
        tblEntryDetailLayout.Controls.Add(cboEntryResolutionPhrase, 1, 31);
        tblEntryDetailLayout.Controls.Add(lblEntryRouteStatusPhrase, 0, 32);
        tblEntryDetailLayout.Controls.Add(cboEntryRouteStatusPhrase, 1, 32);
        tblEntryDetailLayout.Controls.Add(lblEntryPublicBodyOverride, 0, 33);
        tblEntryDetailLayout.Controls.Add(txtEntryPublicBodyOverride, 1, 33);
        tblEntryDetailLayout.Controls.Add(lblStoryThreadSection, 0, 34);
        tblEntryDetailLayout.Controls.Add(lblEntryStoryThread, 0, 35);
        tblEntryDetailLayout.Controls.Add(cboEntryStoryThread, 1, 35);
        tblEntryDetailLayout.Controls.Add(lblEntryAppliedStoryBeat, 0, 36);
        tblEntryDetailLayout.Controls.Add(cboEntryAppliedStoryBeat, 1, 36);
        tblEntryDetailLayout.Controls.Add(lblEntryAnomalySeverity, 0, 37);
        tblEntryDetailLayout.Controls.Add(cboEntryAnomalySeverity, 1, 37);
        tblEntryDetailLayout.Controls.Add(lblHiddenTruthSection, 0, 38);
        tblEntryDetailLayout.Controls.Add(lblEntryHiddenTruthNotes, 0, 39);
        tblEntryDetailLayout.Controls.Add(txtEntryHiddenTruthNotes, 1, 39);
        tblEntryDetailLayout.Controls.Add(lblScheduleSection, 0, 40);
        tblEntryDetailLayout.Controls.Add(lblEntryScheduledUtc, 0, 41);
        tblEntryDetailLayout.Controls.Add(pnlEntrySchedule, 1, 41);
        tblEntryDetailLayout.Controls.Add(lblDeclaredCargoSection, 0, 42);
        tblEntryDetailLayout.Controls.Add(pnlDeclaredCargoContainer, 0, 43);
        tblEntryDetailLayout.Controls.Add(lblActualCargoSection, 0, 44);
        tblEntryDetailLayout.Controls.Add(pnlActualCargoContainer, 0, 45);
        tblEntryDetailLayout.Controls.Add(lblDeclaredPassengersSection, 0, 46);
        tblEntryDetailLayout.Controls.Add(pnlDeclaredPassengersContainer, 0, 47);
        tblEntryDetailLayout.Controls.Add(lblActualPassengersSection, 0, 48);
        tblEntryDetailLayout.Controls.Add(pnlActualPassengersContainer, 0, 49);
        tblEntryDetailLayout.Dock = DockStyle.Top;
        tblEntryDetailLayout.Location = new Point(0, 14);
        tblEntryDetailLayout.Margin = new Padding(4, 5, 4, 5);
        tblEntryDetailLayout.Name = "tblEntryDetailLayout";
        tblEntryDetailLayout.Padding = new Padding(6, 7, 6, 13);
        tblEntryDetailLayout.RowCount = 50;
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 303F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 303F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 270F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 270F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tblEntryDetailLayout.Size = new Size(545, 3574);
        tblEntryDetailLayout.TabIndex = 1;
        // 
        // lblEntrySection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblEntrySection, 2);
        lblEntrySection.Location = new Point(10, 7);
        lblEntrySection.Margin = new Padding(4, 0, 4, 0);
        lblEntrySection.Name = "lblEntrySection";
        lblEntrySection.Size = new Size(143, 38);
        lblEntrySection.TabIndex = 0;
        lblEntrySection.Text = "Entry";
        // 
        // lblEntryKind
        // 
        lblEntryKind.Location = new Point(10, 54);
        lblEntryKind.Margin = new Padding(4, 0, 4, 0);
        lblEntryKind.Name = "lblEntryKind";
        lblEntryKind.Size = new Size(143, 38);
        lblEntryKind.TabIndex = 1;
        lblEntryKind.Text = "Kind:";
        // 
        // cboEntryKind
        // 
        cboEntryKind.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryKind.Location = new Point(267, 59);
        cboEntryKind.Margin = new Padding(4, 5, 4, 5);
        cboEntryKind.Name = "cboEntryKind";
        cboEntryKind.Size = new Size(171, 33);
        cboEntryKind.TabIndex = 2;
        // 
        // lblEntrySourceType
        // 
        lblEntrySourceType.Location = new Point(10, 104);
        lblEntrySourceType.Margin = new Padding(4, 0, 4, 0);
        lblEntrySourceType.Name = "lblEntrySourceType";
        lblEntrySourceType.Size = new Size(143, 38);
        lblEntrySourceType.TabIndex = 3;
        lblEntrySourceType.Text = "Source Type:";
        // 
        // cboEntrySourceType
        // 
        cboEntrySourceType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntrySourceType.Location = new Point(267, 109);
        cboEntrySourceType.Margin = new Padding(4, 5, 4, 5);
        cboEntrySourceType.Name = "cboEntrySourceType";
        cboEntrySourceType.Size = new Size(171, 33);
        cboEntrySourceType.TabIndex = 4;
        // 
        // lblEntryName
        // 
        lblEntryName.Location = new Point(10, 154);
        lblEntryName.Margin = new Padding(4, 0, 4, 0);
        lblEntryName.Name = "lblEntryName";
        lblEntryName.Size = new Size(143, 38);
        lblEntryName.TabIndex = 5;
        lblEntryName.Text = "Name:";
        // 
        // txtEntryName
        // 
        txtEntryName.Location = new Point(267, 159);
        txtEntryName.Margin = new Padding(4, 5, 4, 5);
        txtEntryName.Name = "txtEntryName";
        txtEntryName.Size = new Size(141, 31);
        txtEntryName.TabIndex = 6;
        // 
        // lblEntrySortOrder
        // 
        lblEntrySortOrder.Location = new Point(10, 204);
        lblEntrySortOrder.Margin = new Padding(4, 0, 4, 0);
        lblEntrySortOrder.Name = "lblEntrySortOrder";
        lblEntrySortOrder.Size = new Size(143, 38);
        lblEntrySortOrder.TabIndex = 7;
        lblEntrySortOrder.Text = "Sort Order:";
        // 
        // numEntrySortOrder
        // 
        numEntrySortOrder.Location = new Point(267, 209);
        numEntrySortOrder.Margin = new Padding(4, 5, 4, 5);
        numEntrySortOrder.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        numEntrySortOrder.Name = "numEntrySortOrder";
        numEntrySortOrder.Size = new Size(171, 31);
        numEntrySortOrder.TabIndex = 8;
        // 
        // lblEntryFlags
        // 
        lblEntryFlags.Location = new Point(10, 254);
        lblEntryFlags.Margin = new Padding(4, 0, 4, 0);
        lblEntryFlags.Name = "lblEntryFlags";
        lblEntryFlags.Size = new Size(143, 38);
        lblEntryFlags.TabIndex = 9;
        lblEntryFlags.Text = "Flags:";
        // 
        // pnlEntryFlags
        // 
        pnlEntryFlags.Controls.Add(chkEntryCanon);
        pnlEntryFlags.Controls.Add(chkEntryLocked);
        pnlEntryFlags.Dock = DockStyle.Fill;
        pnlEntryFlags.Location = new Point(267, 259);
        pnlEntryFlags.Margin = new Padding(4, 5, 4, 5);
        pnlEntryFlags.Name = "pnlEntryFlags";
        pnlEntryFlags.Size = new Size(268, 40);
        pnlEntryFlags.TabIndex = 12;
        // 
        // chkEntryCanon
        // 
        chkEntryCanon.AutoSize = true;
        chkEntryCanon.Location = new Point(129, 2);
        chkEntryCanon.Margin = new Padding(4, 5, 4, 5);
        chkEntryCanon.Name = "chkEntryCanon";
        chkEntryCanon.Size = new Size(89, 29);
        chkEntryCanon.TabIndex = 1;
        chkEntryCanon.Text = "Canon";
        chkEntryCanon.UseVisualStyleBackColor = true;
        // 
        // chkEntryLocked
        // 
        chkEntryLocked.AutoSize = true;
        chkEntryLocked.Location = new Point(0, 2);
        chkEntryLocked.Margin = new Padding(4, 5, 4, 5);
        chkEntryLocked.Name = "chkEntryLocked";
        chkEntryLocked.Size = new Size(94, 29);
        chkEntryLocked.TabIndex = 0;
        chkEntryLocked.Text = "Locked";
        chkEntryLocked.UseVisualStyleBackColor = true;
        // 
        // lblEntryRandomSeed
        // 
        lblEntryRandomSeed.Location = new Point(10, 304);
        lblEntryRandomSeed.Margin = new Padding(4, 0, 4, 0);
        lblEntryRandomSeed.Name = "lblEntryRandomSeed";
        lblEntryRandomSeed.Size = new Size(143, 38);
        lblEntryRandomSeed.TabIndex = 13;
        lblEntryRandomSeed.Text = "Random Seed:";
        // 
        // numEntryRandomSeed
        // 
        numEntryRandomSeed.Location = new Point(267, 309);
        numEntryRandomSeed.Margin = new Padding(4, 5, 4, 5);
        numEntryRandomSeed.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
        numEntryRandomSeed.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
        numEntryRandomSeed.Name = "numEntryRandomSeed";
        numEntryRandomSeed.Size = new Size(171, 31);
        numEntryRandomSeed.TabIndex = 14;
        // 
        // lblEntryNotes
        // 
        lblEntryNotes.Location = new Point(10, 354);
        lblEntryNotes.Margin = new Padding(4, 0, 4, 0);
        lblEntryNotes.Name = "lblEntryNotes";
        lblEntryNotes.Size = new Size(143, 38);
        lblEntryNotes.TabIndex = 15;
        lblEntryNotes.Text = "Notes:";
        // 
        // txtEntryNotes
        // 
        txtEntryNotes.Location = new Point(267, 359);
        txtEntryNotes.Margin = new Padding(4, 5, 4, 5);
        txtEntryNotes.Multiline = true;
        txtEntryNotes.Name = "txtEntryNotes";
        txtEntryNotes.ScrollBars = ScrollBars.Vertical;
        txtEntryNotes.Size = new Size(268, 101);
        txtEntryNotes.TabIndex = 16;
        // 
        // lblOperationNoticeSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblOperationNoticeSection, 2);
        lblOperationNoticeSection.Location = new Point(10, 474);
        lblOperationNoticeSection.Margin = new Padding(4, 0, 4, 0);
        lblOperationNoticeSection.Name = "lblOperationNoticeSection";
        lblOperationNoticeSection.Size = new Size(143, 38);
        lblOperationNoticeSection.TabIndex = 17;
        lblOperationNoticeSection.Text = "Operation / Notice";
        // 
        // lblEntryOperationType
        // 
        lblEntryOperationType.Location = new Point(10, 521);
        lblEntryOperationType.Margin = new Padding(4, 0, 4, 0);
        lblEntryOperationType.Name = "lblEntryOperationType";
        lblEntryOperationType.Size = new Size(143, 38);
        lblEntryOperationType.TabIndex = 18;
        lblEntryOperationType.Text = "Operation Type:";
        // 
        // cboEntryOperationType
        // 
        cboEntryOperationType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryOperationType.Location = new Point(267, 526);
        cboEntryOperationType.Margin = new Padding(4, 5, 4, 5);
        cboEntryOperationType.Name = "cboEntryOperationType";
        cboEntryOperationType.Size = new Size(171, 33);
        cboEntryOperationType.TabIndex = 19;
        // 
        // lblEntryNoticeType
        // 
        lblEntryNoticeType.Location = new Point(10, 571);
        lblEntryNoticeType.Margin = new Padding(4, 0, 4, 0);
        lblEntryNoticeType.Name = "lblEntryNoticeType";
        lblEntryNoticeType.Size = new Size(143, 38);
        lblEntryNoticeType.TabIndex = 20;
        lblEntryNoticeType.Text = "Notice Type:";
        // 
        // cboEntryNoticeType
        // 
        cboEntryNoticeType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryNoticeType.Location = new Point(267, 576);
        cboEntryNoticeType.Margin = new Padding(4, 5, 4, 5);
        cboEntryNoticeType.Name = "cboEntryNoticeType";
        cboEntryNoticeType.Size = new Size(171, 33);
        cboEntryNoticeType.TabIndex = 21;
        // 
        // lblLocationSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblLocationSection, 2);
        lblLocationSection.Location = new Point(10, 621);
        lblLocationSection.Margin = new Padding(4, 0, 4, 0);
        lblLocationSection.Name = "lblLocationSection";
        lblLocationSection.Size = new Size(143, 38);
        lblLocationSection.TabIndex = 22;
        lblLocationSection.Text = "Location";
        // 
        // lblEntryStation
        // 
        lblEntryStation.Location = new Point(10, 668);
        lblEntryStation.Margin = new Padding(4, 0, 4, 0);
        lblEntryStation.Name = "lblEntryStation";
        lblEntryStation.Size = new Size(143, 38);
        lblEntryStation.TabIndex = 23;
        lblEntryStation.Text = "Station:";
        // 
        // cboEntryStation
        // 
        cboEntryStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryStation.Location = new Point(267, 673);
        cboEntryStation.Margin = new Padding(4, 5, 4, 5);
        cboEntryStation.Name = "cboEntryStation";
        cboEntryStation.Size = new Size(171, 33);
        cboEntryStation.TabIndex = 24;
        // 
        // lblEntryDock
        // 
        lblEntryDock.Location = new Point(10, 718);
        lblEntryDock.Margin = new Padding(4, 0, 4, 0);
        lblEntryDock.Name = "lblEntryDock";
        lblEntryDock.Size = new Size(143, 38);
        lblEntryDock.TabIndex = 25;
        lblEntryDock.Text = "Dock:";
        // 
        // cboEntryDock
        // 
        cboEntryDock.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDock.Location = new Point(267, 723);
        cboEntryDock.Margin = new Padding(4, 5, 4, 5);
        cboEntryDock.Name = "cboEntryDock";
        cboEntryDock.Size = new Size(171, 33);
        cboEntryDock.TabIndex = 26;
        // 
        // lblEntryOriginStation
        // 
        lblEntryOriginStation.Location = new Point(10, 768);
        lblEntryOriginStation.Margin = new Padding(4, 0, 4, 0);
        lblEntryOriginStation.Name = "lblEntryOriginStation";
        lblEntryOriginStation.Size = new Size(143, 38);
        lblEntryOriginStation.TabIndex = 27;
        lblEntryOriginStation.Text = "Origin Station:";
        // 
        // cboEntryOriginStation
        // 
        cboEntryOriginStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryOriginStation.Location = new Point(267, 773);
        cboEntryOriginStation.Margin = new Padding(4, 5, 4, 5);
        cboEntryOriginStation.Name = "cboEntryOriginStation";
        cboEntryOriginStation.Size = new Size(171, 33);
        cboEntryOriginStation.TabIndex = 28;
        // 
        // lblEntryDestinationStation
        // 
        lblEntryDestinationStation.Location = new Point(10, 818);
        lblEntryDestinationStation.Margin = new Padding(4, 0, 4, 0);
        lblEntryDestinationStation.Name = "lblEntryDestinationStation";
        lblEntryDestinationStation.Size = new Size(143, 38);
        lblEntryDestinationStation.TabIndex = 29;
        lblEntryDestinationStation.Text = "Destination Station:";
        // 
        // cboEntryDestinationStation
        // 
        cboEntryDestinationStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDestinationStation.Location = new Point(267, 823);
        cboEntryDestinationStation.Margin = new Padding(4, 5, 4, 5);
        cboEntryDestinationStation.Name = "cboEntryDestinationStation";
        cboEntryDestinationStation.Size = new Size(171, 33);
        cboEntryDestinationStation.TabIndex = 30;
        // 
        // lblVesselSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblVesselSection, 2);
        lblVesselSection.Location = new Point(10, 865);
        lblVesselSection.Margin = new Padding(4, 0, 4, 0);
        lblVesselSection.Name = "lblVesselSection";
        lblVesselSection.Size = new Size(143, 38);
        lblVesselSection.TabIndex = 31;
        lblVesselSection.Text = "Vessel";
        // 
        // lblEntryVessel
        // 
        lblEntryVessel.Location = new Point(10, 915);
        lblEntryVessel.Margin = new Padding(4, 0, 4, 0);
        lblEntryVessel.Name = "lblEntryVessel";
        lblEntryVessel.Size = new Size(143, 38);
        lblEntryVessel.TabIndex = 32;
        lblEntryVessel.Text = "Vessel:";
        // 
        // cboEntryVessel
        // 
        cboEntryVessel.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryVessel.Location = new Point(267, 920);
        cboEntryVessel.Margin = new Padding(4, 5, 4, 5);
        cboEntryVessel.Name = "cboEntryVessel";
        cboEntryVessel.Size = new Size(171, 33);
        cboEntryVessel.TabIndex = 33;
        // 
        // lblEntryVesselClassOverride
        // 
        lblEntryVesselClassOverride.Location = new Point(10, 965);
        lblEntryVesselClassOverride.Margin = new Padding(4, 0, 4, 0);
        lblEntryVesselClassOverride.Name = "lblEntryVesselClassOverride";
        lblEntryVesselClassOverride.Size = new Size(143, 38);
        lblEntryVesselClassOverride.TabIndex = 34;
        lblEntryVesselClassOverride.Text = "Class Override:";
        // 
        // cboEntryVesselClassOverride
        // 
        cboEntryVesselClassOverride.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryVesselClassOverride.Location = new Point(267, 970);
        cboEntryVesselClassOverride.Margin = new Padding(4, 5, 4, 5);
        cboEntryVesselClassOverride.Name = "cboEntryVesselClassOverride";
        cboEntryVesselClassOverride.Size = new Size(171, 33);
        cboEntryVesselClassOverride.TabIndex = 35;
        // 
        // lblEntryRegistryOverride
        // 
        lblEntryRegistryOverride.Location = new Point(10, 1015);
        lblEntryRegistryOverride.Margin = new Padding(4, 0, 4, 0);
        lblEntryRegistryOverride.Name = "lblEntryRegistryOverride";
        lblEntryRegistryOverride.Size = new Size(143, 38);
        lblEntryRegistryOverride.TabIndex = 36;
        lblEntryRegistryOverride.Text = "Registry Override:";
        // 
        // txtEntryRegistryOverride
        // 
        txtEntryRegistryOverride.Location = new Point(267, 1020);
        txtEntryRegistryOverride.Margin = new Padding(4, 5, 4, 5);
        txtEntryRegistryOverride.Name = "txtEntryRegistryOverride";
        txtEntryRegistryOverride.Size = new Size(141, 31);
        txtEntryRegistryOverride.TabIndex = 37;
        // 
        // lblPurposeSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblPurposeSection, 2);
        lblPurposeSection.Location = new Point(10, 1062);
        lblPurposeSection.Margin = new Padding(4, 0, 4, 0);
        lblPurposeSection.Name = "lblPurposeSection";
        lblPurposeSection.Size = new Size(143, 38);
        lblPurposeSection.TabIndex = 38;
        lblPurposeSection.Text = "Purpose";
        // 
        // lblEntryDeclaredPurpose
        // 
        lblEntryDeclaredPurpose.Location = new Point(10, 1112);
        lblEntryDeclaredPurpose.Margin = new Padding(4, 0, 4, 0);
        lblEntryDeclaredPurpose.Name = "lblEntryDeclaredPurpose";
        lblEntryDeclaredPurpose.Size = new Size(143, 38);
        lblEntryDeclaredPurpose.TabIndex = 39;
        lblEntryDeclaredPurpose.Text = "Declared Purpose:";
        // 
        // cboEntryDeclaredPurpose
        // 
        cboEntryDeclaredPurpose.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDeclaredPurpose.Location = new Point(267, 1117);
        cboEntryDeclaredPurpose.Margin = new Padding(4, 5, 4, 5);
        cboEntryDeclaredPurpose.Name = "cboEntryDeclaredPurpose";
        cboEntryDeclaredPurpose.Size = new Size(171, 33);
        cboEntryDeclaredPurpose.TabIndex = 40;
        // 
        // lblEntryActualPurpose
        // 
        lblEntryActualPurpose.Location = new Point(10, 1162);
        lblEntryActualPurpose.Margin = new Padding(4, 0, 4, 0);
        lblEntryActualPurpose.Name = "lblEntryActualPurpose";
        lblEntryActualPurpose.Size = new Size(143, 38);
        lblEntryActualPurpose.TabIndex = 41;
        lblEntryActualPurpose.Text = "Actual Purpose:";
        // 
        // cboEntryActualPurpose
        // 
        cboEntryActualPurpose.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryActualPurpose.Location = new Point(267, 1167);
        cboEntryActualPurpose.Margin = new Padding(4, 5, 4, 5);
        cboEntryActualPurpose.Name = "cboEntryActualPurpose";
        cboEntryActualPurpose.Size = new Size(171, 33);
        cboEntryActualPurpose.TabIndex = 42;
        // 
        // lblStatusesSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblStatusesSection, 2);
        lblStatusesSection.Location = new Point(10, 1209);
        lblStatusesSection.Margin = new Padding(4, 0, 4, 0);
        lblStatusesSection.Name = "lblStatusesSection";
        lblStatusesSection.Size = new Size(143, 38);
        lblStatusesSection.TabIndex = 43;
        lblStatusesSection.Text = "Statuses";
        // 
        // lblEntryManifestStatus
        // 
        lblEntryManifestStatus.Location = new Point(10, 1259);
        lblEntryManifestStatus.Margin = new Padding(4, 0, 4, 0);
        lblEntryManifestStatus.Name = "lblEntryManifestStatus";
        lblEntryManifestStatus.Size = new Size(143, 38);
        lblEntryManifestStatus.TabIndex = 44;
        lblEntryManifestStatus.Text = "Manifest Status:";
        // 
        // cboEntryManifestStatus
        // 
        cboEntryManifestStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryManifestStatus.Location = new Point(267, 1264);
        cboEntryManifestStatus.Margin = new Padding(4, 5, 4, 5);
        cboEntryManifestStatus.Name = "cboEntryManifestStatus";
        cboEntryManifestStatus.Size = new Size(171, 33);
        cboEntryManifestStatus.TabIndex = 45;
        // 
        // lblEntryInspectionStatus
        // 
        lblEntryInspectionStatus.Location = new Point(10, 1309);
        lblEntryInspectionStatus.Margin = new Padding(4, 0, 4, 0);
        lblEntryInspectionStatus.Name = "lblEntryInspectionStatus";
        lblEntryInspectionStatus.Size = new Size(143, 38);
        lblEntryInspectionStatus.TabIndex = 46;
        lblEntryInspectionStatus.Text = "Inspection Status:";
        // 
        // cboEntryInspectionStatus
        // 
        cboEntryInspectionStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryInspectionStatus.Location = new Point(267, 1314);
        cboEntryInspectionStatus.Margin = new Padding(4, 5, 4, 5);
        cboEntryInspectionStatus.Name = "cboEntryInspectionStatus";
        cboEntryInspectionStatus.Size = new Size(171, 33);
        cboEntryInspectionStatus.TabIndex = 47;
        // 
        // lblEntryClearanceStatus
        // 
        lblEntryClearanceStatus.Location = new Point(10, 1359);
        lblEntryClearanceStatus.Margin = new Padding(4, 0, 4, 0);
        lblEntryClearanceStatus.Name = "lblEntryClearanceStatus";
        lblEntryClearanceStatus.Size = new Size(143, 38);
        lblEntryClearanceStatus.TabIndex = 48;
        lblEntryClearanceStatus.Text = "Clearance Status:";
        // 
        // cboEntryClearanceStatus
        // 
        cboEntryClearanceStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryClearanceStatus.Location = new Point(267, 1364);
        cboEntryClearanceStatus.Margin = new Padding(4, 5, 4, 5);
        cboEntryClearanceStatus.Name = "cboEntryClearanceStatus";
        cboEntryClearanceStatus.Size = new Size(171, 33);
        cboEntryClearanceStatus.TabIndex = 49;
        // 
        // lblEntryEnvironmentalCondition
        // 
        lblEntryEnvironmentalCondition.Location = new Point(10, 1409);
        lblEntryEnvironmentalCondition.Margin = new Padding(4, 0, 4, 0);
        lblEntryEnvironmentalCondition.Name = "lblEntryEnvironmentalCondition";
        lblEntryEnvironmentalCondition.Size = new Size(143, 38);
        lblEntryEnvironmentalCondition.TabIndex = 50;
        lblEntryEnvironmentalCondition.Text = "Environment:";
        // 
        // cboEntryEnvironmentalCondition
        // 
        cboEntryEnvironmentalCondition.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryEnvironmentalCondition.Location = new Point(267, 1414);
        cboEntryEnvironmentalCondition.Margin = new Padding(4, 5, 4, 5);
        cboEntryEnvironmentalCondition.Name = "cboEntryEnvironmentalCondition";
        cboEntryEnvironmentalCondition.Size = new Size(171, 33);
        cboEntryEnvironmentalCondition.TabIndex = 51;
        // 
        // lblNarrativeSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblNarrativeSection, 2);
        lblNarrativeSection.Location = new Point(10, 1456);
        lblNarrativeSection.Margin = new Padding(4, 0, 4, 0);
        lblNarrativeSection.Name = "lblNarrativeSection";
        lblNarrativeSection.Size = new Size(143, 38);
        lblNarrativeSection.TabIndex = 52;
        lblNarrativeSection.Text = "Narrative";
        // 
        // lblEntryDirective
        // 
        lblEntryDirective.Location = new Point(10, 1506);
        lblEntryDirective.Margin = new Padding(4, 0, 4, 0);
        lblEntryDirective.Name = "lblEntryDirective";
        lblEntryDirective.Size = new Size(143, 38);
        lblEntryDirective.TabIndex = 53;
        lblEntryDirective.Text = "Directive:";
        // 
        // cboEntryDirective
        // 
        cboEntryDirective.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDirective.Location = new Point(267, 1511);
        cboEntryDirective.Margin = new Padding(4, 5, 4, 5);
        cboEntryDirective.Name = "cboEntryDirective";
        cboEntryDirective.Size = new Size(171, 33);
        cboEntryDirective.TabIndex = 54;
        // 
        // lblEntryIncidentPhrase
        // 
        lblEntryIncidentPhrase.Location = new Point(10, 1556);
        lblEntryIncidentPhrase.Margin = new Padding(4, 0, 4, 0);
        lblEntryIncidentPhrase.Name = "lblEntryIncidentPhrase";
        lblEntryIncidentPhrase.Size = new Size(143, 38);
        lblEntryIncidentPhrase.TabIndex = 55;
        lblEntryIncidentPhrase.Text = "Incident Phrase:";
        // 
        // cboEntryIncidentPhrase
        // 
        cboEntryIncidentPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryIncidentPhrase.Location = new Point(267, 1561);
        cboEntryIncidentPhrase.Margin = new Padding(4, 5, 4, 5);
        cboEntryIncidentPhrase.Name = "cboEntryIncidentPhrase";
        cboEntryIncidentPhrase.Size = new Size(171, 33);
        cboEntryIncidentPhrase.TabIndex = 56;
        // 
        // lblEntryResolutionPhrase
        // 
        lblEntryResolutionPhrase.Location = new Point(10, 1606);
        lblEntryResolutionPhrase.Margin = new Padding(4, 0, 4, 0);
        lblEntryResolutionPhrase.Name = "lblEntryResolutionPhrase";
        lblEntryResolutionPhrase.Size = new Size(143, 38);
        lblEntryResolutionPhrase.TabIndex = 57;
        lblEntryResolutionPhrase.Text = "Resolution Phrase:";
        // 
        // cboEntryResolutionPhrase
        // 
        cboEntryResolutionPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryResolutionPhrase.Location = new Point(267, 1611);
        cboEntryResolutionPhrase.Margin = new Padding(4, 5, 4, 5);
        cboEntryResolutionPhrase.Name = "cboEntryResolutionPhrase";
        cboEntryResolutionPhrase.Size = new Size(171, 33);
        cboEntryResolutionPhrase.TabIndex = 58;
        // 
        // lblEntryRouteStatusPhrase
        // 
        lblEntryRouteStatusPhrase.Location = new Point(10, 1726);
        lblEntryRouteStatusPhrase.Margin = new Padding(4, 0, 4, 0);
        lblEntryRouteStatusPhrase.Name = "lblEntryRouteStatusPhrase";
        lblEntryRouteStatusPhrase.Size = new Size(143, 38);
        lblEntryRouteStatusPhrase.TabIndex = 59;
        lblEntryRouteStatusPhrase.Text = "Route Status Phrase:";
        // 
        // cboEntryRouteStatusPhrase
        // 
        cboEntryRouteStatusPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryRouteStatusPhrase.Location = new Point(267, 1731);
        cboEntryRouteStatusPhrase.Margin = new Padding(4, 5, 4, 5);
        cboEntryRouteStatusPhrase.Name = "cboEntryRouteStatusPhrase";
        cboEntryRouteStatusPhrase.Size = new Size(171, 33);
        cboEntryRouteStatusPhrase.TabIndex = 60;
        // 
        // lblEntryPublicBodyOverride
        // 
        lblEntryPublicBodyOverride.Location = new Point(10, 1773);
        lblEntryPublicBodyOverride.Margin = new Padding(4, 0, 4, 0);
        lblEntryPublicBodyOverride.Name = "lblEntryPublicBodyOverride";
        lblEntryPublicBodyOverride.Size = new Size(143, 38);
        lblEntryPublicBodyOverride.TabIndex = 61;
        lblEntryPublicBodyOverride.Text = "Public Body Override:";
        // 
        // txtEntryPublicBodyOverride
        // 
        txtEntryPublicBodyOverride.Location = new Point(267, 1778);
        txtEntryPublicBodyOverride.Margin = new Padding(4, 5, 4, 5);
        txtEntryPublicBodyOverride.Multiline = true;
        txtEntryPublicBodyOverride.Name = "txtEntryPublicBodyOverride";
        txtEntryPublicBodyOverride.ScrollBars = ScrollBars.Vertical;
        txtEntryPublicBodyOverride.Size = new Size(141, 37);
        txtEntryPublicBodyOverride.TabIndex = 62;
        // 
        // lblStoryThreadSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblStoryThreadSection, 2);
        lblStoryThreadSection.Location = new Point(10, 1823);
        lblStoryThreadSection.Margin = new Padding(4, 0, 4, 0);
        lblStoryThreadSection.Name = "lblStoryThreadSection";
        lblStoryThreadSection.Size = new Size(143, 38);
        lblStoryThreadSection.TabIndex = 63;
        lblStoryThreadSection.Text = "Story Thread";
        // 
        // lblEntryStoryThread
        // 
        lblEntryStoryThread.Location = new Point(10, 1873);
        lblEntryStoryThread.Margin = new Padding(4, 0, 4, 0);
        lblEntryStoryThread.Name = "lblEntryStoryThread";
        lblEntryStoryThread.Size = new Size(143, 38);
        lblEntryStoryThread.TabIndex = 64;
        lblEntryStoryThread.Text = "Story Thread:";
        // 
        // cboEntryStoryThread
        // 
        cboEntryStoryThread.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryStoryThread.Location = new Point(267, 1878);
        cboEntryStoryThread.Margin = new Padding(4, 5, 4, 5);
        cboEntryStoryThread.Name = "cboEntryStoryThread";
        cboEntryStoryThread.Size = new Size(171, 33);
        cboEntryStoryThread.TabIndex = 65;
        // 
        // lblEntryAppliedStoryBeat
        // 
        lblEntryAppliedStoryBeat.Location = new Point(10, 1923);
        lblEntryAppliedStoryBeat.Margin = new Padding(4, 0, 4, 0);
        lblEntryAppliedStoryBeat.Name = "lblEntryAppliedStoryBeat";
        lblEntryAppliedStoryBeat.Size = new Size(143, 38);
        lblEntryAppliedStoryBeat.TabIndex = 66;
        lblEntryAppliedStoryBeat.Text = "Story Beat:";
        // 
        // cboEntryAppliedStoryBeat
        // 
        cboEntryAppliedStoryBeat.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryAppliedStoryBeat.Location = new Point(267, 1928);
        cboEntryAppliedStoryBeat.Margin = new Padding(4, 5, 4, 5);
        cboEntryAppliedStoryBeat.Name = "cboEntryAppliedStoryBeat";
        cboEntryAppliedStoryBeat.Size = new Size(171, 33);
        cboEntryAppliedStoryBeat.TabIndex = 67;
        // 
        // lblEntryAnomalySeverity
        // 
        lblEntryAnomalySeverity.Location = new Point(10, 1970);
        lblEntryAnomalySeverity.Margin = new Padding(4, 0, 4, 0);
        lblEntryAnomalySeverity.Name = "lblEntryAnomalySeverity";
        lblEntryAnomalySeverity.Size = new Size(143, 38);
        lblEntryAnomalySeverity.TabIndex = 68;
        lblEntryAnomalySeverity.Text = "Anomaly Severity:";
        // 
        // cboEntryAnomalySeverity
        // 
        cboEntryAnomalySeverity.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryAnomalySeverity.Location = new Point(267, 1975);
        cboEntryAnomalySeverity.Margin = new Padding(4, 5, 4, 5);
        cboEntryAnomalySeverity.Name = "cboEntryAnomalySeverity";
        cboEntryAnomalySeverity.Size = new Size(171, 33);
        cboEntryAnomalySeverity.TabIndex = 69;
        // 
        // lblHiddenTruthSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblHiddenTruthSection, 2);
        lblHiddenTruthSection.Location = new Point(10, 2090);
        lblHiddenTruthSection.Margin = new Padding(4, 0, 4, 0);
        lblHiddenTruthSection.Name = "lblHiddenTruthSection";
        lblHiddenTruthSection.Size = new Size(143, 38);
        lblHiddenTruthSection.TabIndex = 70;
        lblHiddenTruthSection.Text = "Hidden Truth";
        // 
        // lblEntryHiddenTruthNotes
        // 
        lblEntryHiddenTruthNotes.Location = new Point(10, 2137);
        lblEntryHiddenTruthNotes.Margin = new Padding(4, 0, 4, 0);
        lblEntryHiddenTruthNotes.Name = "lblEntryHiddenTruthNotes";
        lblEntryHiddenTruthNotes.Size = new Size(143, 38);
        lblEntryHiddenTruthNotes.TabIndex = 71;
        lblEntryHiddenTruthNotes.Text = "Hidden Truth Notes:";
        // 
        // txtEntryHiddenTruthNotes
        // 
        txtEntryHiddenTruthNotes.Location = new Point(267, 2142);
        txtEntryHiddenTruthNotes.Margin = new Padding(4, 5, 4, 5);
        txtEntryHiddenTruthNotes.Multiline = true;
        txtEntryHiddenTruthNotes.Name = "txtEntryHiddenTruthNotes";
        txtEntryHiddenTruthNotes.ScrollBars = ScrollBars.Vertical;
        txtEntryHiddenTruthNotes.Size = new Size(141, 37);
        txtEntryHiddenTruthNotes.TabIndex = 72;
        // 
        // lblScheduleSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblScheduleSection, 2);
        lblScheduleSection.Location = new Point(10, 2187);
        lblScheduleSection.Margin = new Padding(4, 0, 4, 0);
        lblScheduleSection.Name = "lblScheduleSection";
        lblScheduleSection.Size = new Size(143, 38);
        lblScheduleSection.TabIndex = 73;
        lblScheduleSection.Text = "Schedule";
        // 
        // lblEntryScheduledUtc
        // 
        lblEntryScheduledUtc.Location = new Point(10, 2234);
        lblEntryScheduledUtc.Margin = new Padding(4, 0, 4, 0);
        lblEntryScheduledUtc.Name = "lblEntryScheduledUtc";
        lblEntryScheduledUtc.Size = new Size(143, 38);
        lblEntryScheduledUtc.TabIndex = 74;
        lblEntryScheduledUtc.Text = "Scheduled (UTC):";
        // 
        // pnlEntrySchedule
        // 
        pnlEntrySchedule.Controls.Add(dtpEntryScheduledUtc);
        pnlEntrySchedule.Controls.Add(chkEntryScheduledEnabled);
        pnlEntrySchedule.Dock = DockStyle.Fill;
        pnlEntrySchedule.Location = new Point(267, 2239);
        pnlEntrySchedule.Margin = new Padding(4, 5, 4, 5);
        pnlEntrySchedule.Name = "pnlEntrySchedule";
        pnlEntrySchedule.Size = new Size(268, 293);
        pnlEntrySchedule.TabIndex = 82;
        // 
        // dtpEntryScheduledUtc
        // 
        dtpEntryScheduledUtc.Enabled = false;
        dtpEntryScheduledUtc.Format = DateTimePickerFormat.Short;
        dtpEntryScheduledUtc.Location = new Point(37, 0);
        dtpEntryScheduledUtc.Margin = new Padding(4, 5, 4, 5);
        dtpEntryScheduledUtc.Name = "dtpEntryScheduledUtc";
        dtpEntryScheduledUtc.Size = new Size(241, 31);
        dtpEntryScheduledUtc.TabIndex = 1;
        // 
        // chkEntryScheduledEnabled
        // 
        chkEntryScheduledEnabled.Location = new Point(0, 3);
        chkEntryScheduledEnabled.Margin = new Padding(4, 5, 4, 5);
        chkEntryScheduledEnabled.Name = "chkEntryScheduledEnabled";
        chkEntryScheduledEnabled.Size = new Size(29, 33);
        chkEntryScheduledEnabled.TabIndex = 0;
        chkEntryScheduledEnabled.UseVisualStyleBackColor = true;
        // 
        // lblDeclaredCargoSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblDeclaredCargoSection, 2);
        lblDeclaredCargoSection.Location = new Point(10, 2537);
        lblDeclaredCargoSection.Margin = new Padding(4, 0, 4, 0);
        lblDeclaredCargoSection.Name = "lblDeclaredCargoSection";
        lblDeclaredCargoSection.Size = new Size(143, 38);
        lblDeclaredCargoSection.TabIndex = 83;
        lblDeclaredCargoSection.Text = "Declared Cargo";
        // 
        // pnlDeclaredCargoContainer
        // 
        tblEntryDetailLayout.SetColumnSpan(pnlDeclaredCargoContainer, 2);
        pnlDeclaredCargoContainer.Location = new Point(10, 2589);
        pnlDeclaredCargoContainer.Margin = new Padding(4, 5, 4, 5);
        pnlDeclaredCargoContainer.Name = "pnlDeclaredCargoContainer";
        pnlDeclaredCargoContainer.Size = new Size(525, 293);
        pnlDeclaredCargoContainer.TabIndex = 85;
        // 
        // lblActualCargoSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblActualCargoSection, 2);
        lblActualCargoSection.Location = new Point(10, 2887);
        lblActualCargoSection.Margin = new Padding(4, 0, 4, 0);
        lblActualCargoSection.Name = "lblActualCargoSection";
        lblActualCargoSection.Size = new Size(143, 38);
        lblActualCargoSection.TabIndex = 86;
        lblActualCargoSection.Text = "Actual Cargo";
        // 
        // pnlActualCargoContainer
        // 
        tblEntryDetailLayout.SetColumnSpan(pnlActualCargoContainer, 2);
        pnlActualCargoContainer.Location = new Point(10, 2939);
        pnlActualCargoContainer.Margin = new Padding(4, 5, 4, 5);
        pnlActualCargoContainer.Name = "pnlActualCargoContainer";
        pnlActualCargoContainer.Size = new Size(525, 260);
        pnlActualCargoContainer.TabIndex = 87;
        // 
        // lblDeclaredPassengersSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblDeclaredPassengersSection, 2);
        lblDeclaredPassengersSection.Location = new Point(10, 3204);
        lblDeclaredPassengersSection.Margin = new Padding(4, 0, 4, 0);
        lblDeclaredPassengersSection.Name = "lblDeclaredPassengersSection";
        lblDeclaredPassengersSection.Size = new Size(143, 38);
        lblDeclaredPassengersSection.TabIndex = 88;
        lblDeclaredPassengersSection.Text = "Declared Passengers";
        // 
        // pnlDeclaredPassengersContainer
        // 
        tblEntryDetailLayout.SetColumnSpan(pnlDeclaredPassengersContainer, 2);
        pnlDeclaredPassengersContainer.Location = new Point(10, 3256);
        pnlDeclaredPassengersContainer.Margin = new Padding(4, 5, 4, 5);
        pnlDeclaredPassengersContainer.Name = "pnlDeclaredPassengersContainer";
        pnlDeclaredPassengersContainer.Size = new Size(525, 260);
        pnlDeclaredPassengersContainer.TabIndex = 89;
        // 
        // lblActualPassengersSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblActualPassengersSection, 2);
        lblActualPassengersSection.Location = new Point(10, 3521);
        lblActualPassengersSection.Margin = new Padding(4, 0, 4, 0);
        lblActualPassengersSection.Name = "lblActualPassengersSection";
        lblActualPassengersSection.Size = new Size(143, 20);
        lblActualPassengersSection.TabIndex = 90;
        lblActualPassengersSection.Text = "Actual Passengers";
        // 
        // pnlActualPassengersContainer
        // 
        tblEntryDetailLayout.SetColumnSpan(pnlActualPassengersContainer, 2);
        pnlActualPassengersContainer.Location = new Point(10, 3546);
        pnlActualPassengersContainer.Margin = new Padding(4, 5, 4, 5);
        pnlActualPassengersContainer.Name = "pnlActualPassengersContainer";
        pnlActualPassengersContainer.Size = new Size(525, 10);
        pnlActualPassengersContainer.TabIndex = 91;
        // 
        // flpValidationHints
        // 
        flpValidationHints.AutoSize = true;
        flpValidationHints.BackColor = Color.FromArgb(255, 252, 220);
        flpValidationHints.Dock = DockStyle.Top;
        flpValidationHints.FlowDirection = FlowDirection.TopDown;
        flpValidationHints.Location = new Point(0, 0);
        flpValidationHints.Margin = new Padding(4, 5, 4, 5);
        flpValidationHints.Name = "flpValidationHints";
        flpValidationHints.Padding = new Padding(9, 7, 9, 7);
        flpValidationHints.Size = new Size(545, 14);
        flpValidationHints.TabIndex = 0;
        flpValidationHints.Visible = false;
        flpValidationHints.WrapContents = false;
        // 
        // gridDeclaredCargo
        // 
        gridDeclaredCargo.ColumnHeadersHeight = 34;
        gridDeclaredCargo.Location = new Point(0, 0);
        gridDeclaredCargo.Name = "gridDeclaredCargo";
        gridDeclaredCargo.RowHeadersWidth = 62;
        gridDeclaredCargo.Size = new Size(240, 150);
        gridDeclaredCargo.TabIndex = 0;
        // 
        // pnlDeclaredCargoActions
        // 
        pnlDeclaredCargoActions.Location = new Point(0, 0);
        pnlDeclaredCargoActions.Name = "pnlDeclaredCargoActions";
        pnlDeclaredCargoActions.Size = new Size(200, 100);
        pnlDeclaredCargoActions.TabIndex = 0;
        // 
        // btnDeclaredCargoDelete
        // 
        btnDeclaredCargoDelete.Location = new Point(0, 0);
        btnDeclaredCargoDelete.Name = "btnDeclaredCargoDelete";
        btnDeclaredCargoDelete.Size = new Size(75, 23);
        btnDeclaredCargoDelete.TabIndex = 0;
        // 
        // btnDeclaredCargoAdd
        // 
        btnDeclaredCargoAdd.Location = new Point(0, 0);
        btnDeclaredCargoAdd.Name = "btnDeclaredCargoAdd";
        btnDeclaredCargoAdd.Size = new Size(75, 23);
        btnDeclaredCargoAdd.TabIndex = 0;
        // 
        // gridActualCargo
        // 
        gridActualCargo.ColumnHeadersHeight = 34;
        gridActualCargo.Location = new Point(0, 0);
        gridActualCargo.Name = "gridActualCargo";
        gridActualCargo.RowHeadersWidth = 62;
        gridActualCargo.Size = new Size(240, 150);
        gridActualCargo.TabIndex = 0;
        // 
        // pnlActualCargoActions
        // 
        pnlActualCargoActions.Location = new Point(0, 0);
        pnlActualCargoActions.Name = "pnlActualCargoActions";
        pnlActualCargoActions.Size = new Size(200, 100);
        pnlActualCargoActions.TabIndex = 0;
        // 
        // btnActualCargoDelete
        // 
        btnActualCargoDelete.Location = new Point(0, 0);
        btnActualCargoDelete.Name = "btnActualCargoDelete";
        btnActualCargoDelete.Size = new Size(75, 23);
        btnActualCargoDelete.TabIndex = 0;
        // 
        // btnActualCargoAdd
        // 
        btnActualCargoAdd.Location = new Point(0, 0);
        btnActualCargoAdd.Name = "btnActualCargoAdd";
        btnActualCargoAdd.Size = new Size(75, 23);
        btnActualCargoAdd.TabIndex = 0;
        // 
        // gridDeclaredPassengers
        // 
        gridDeclaredPassengers.ColumnHeadersHeight = 34;
        gridDeclaredPassengers.Location = new Point(0, 0);
        gridDeclaredPassengers.Name = "gridDeclaredPassengers";
        gridDeclaredPassengers.RowHeadersWidth = 62;
        gridDeclaredPassengers.Size = new Size(240, 150);
        gridDeclaredPassengers.TabIndex = 0;
        // 
        // pnlDeclaredPassengersActions
        // 
        pnlDeclaredPassengersActions.Location = new Point(0, 0);
        pnlDeclaredPassengersActions.Name = "pnlDeclaredPassengersActions";
        pnlDeclaredPassengersActions.Size = new Size(200, 100);
        pnlDeclaredPassengersActions.TabIndex = 0;
        // 
        // btnDeclaredPassengerDelete
        // 
        btnDeclaredPassengerDelete.Location = new Point(0, 0);
        btnDeclaredPassengerDelete.Name = "btnDeclaredPassengerDelete";
        btnDeclaredPassengerDelete.Size = new Size(75, 23);
        btnDeclaredPassengerDelete.TabIndex = 0;
        // 
        // btnDeclaredPassengerAdd
        // 
        btnDeclaredPassengerAdd.Location = new Point(0, 0);
        btnDeclaredPassengerAdd.Name = "btnDeclaredPassengerAdd";
        btnDeclaredPassengerAdd.Size = new Size(75, 23);
        btnDeclaredPassengerAdd.TabIndex = 0;
        // 
        // gridActualPassengers
        // 
        gridActualPassengers.ColumnHeadersHeight = 34;
        gridActualPassengers.Location = new Point(0, 0);
        gridActualPassengers.Name = "gridActualPassengers";
        gridActualPassengers.RowHeadersWidth = 62;
        gridActualPassengers.Size = new Size(240, 150);
        gridActualPassengers.TabIndex = 0;
        // 
        // pnlActualPassengersActions
        // 
        pnlActualPassengersActions.Location = new Point(0, 0);
        pnlActualPassengersActions.Name = "pnlActualPassengersActions";
        pnlActualPassengersActions.Size = new Size(200, 100);
        pnlActualPassengersActions.TabIndex = 0;
        // 
        // btnActualPassengerDelete
        // 
        btnActualPassengerDelete.Location = new Point(0, 0);
        btnActualPassengerDelete.Name = "btnActualPassengerDelete";
        btnActualPassengerDelete.Size = new Size(75, 23);
        btnActualPassengerDelete.TabIndex = 0;
        // 
        // btnActualPassengerAdd
        // 
        btnActualPassengerAdd.Location = new Point(0, 0);
        btnActualPassengerAdd.Name = "btnActualPassengerAdd";
        btnActualPassengerAdd.Size = new Size(75, 23);
        btnActualPassengerAdd.TabIndex = 0;
        // 
        // ucEpisodeEntryDetail
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        Controls.Add(pnlScrollHost);
        Margin = new Padding(4, 5, 4, 5);
        Name = "ucEpisodeEntryDetail";
        Size = new Size(571, 1000);
        pnlScrollHost.ResumeLayout(false);
        pnlScrollHost.PerformLayout();
        tblEntryDetailLayout.ResumeLayout(false);
        tblEntryDetailLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numEntrySortOrder).EndInit();
        pnlEntryFlags.ResumeLayout(false);
        pnlEntryFlags.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numEntryRandomSeed).EndInit();
        pnlEntrySchedule.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDeclaredCargo).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridActualCargo).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredPassengers).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridActualPassengers).EndInit();
        ResumeLayout(false);
    }

    private void ConfigureSectionLabel(Label label)
    {
        label.AutoSize = true;
        label.Dock = DockStyle.Fill;
        label.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label.ForeColor = SystemColors.ControlDarkDark;
        label.Padding = new Padding(0, 8, 0, 0);
        label.Size = new Size(386, 28);
        label.TabIndex = 0;
    }

    private void ConfigureFieldLabel(Label label)
    {
        label.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        label.AutoSize = true;
        label.Padding = new Padding(0, 6, 0, 0);
        label.Size = new Size(50, 31);
        label.TabIndex = 0;
    }

    private void ConfigureFillControl(Control control)
    {
        control.Dock = DockStyle.Fill;
        control.Margin = new Padding(3);
    }

    private void ConfigureManifestContainer(
        Panel container,
        DataGridView grid,
        Panel actionsPanel,
        Button deleteButton,
        Button addButton)
    {
        container.Controls.Add(grid);
        container.Controls.Add(actionsPanel);
        container.Dock = DockStyle.Fill;

        actionsPanel.Controls.Add(deleteButton);
        actionsPanel.Controls.Add(addButton);
        actionsPanel.Dock = DockStyle.Bottom;
        actionsPanel.Height = 28;
        actionsPanel.Padding = new Padding(2);

        deleteButton.Dock = DockStyle.Left;
        deleteButton.Size = new Size(60, 24);
        deleteButton.TabIndex = 0;
        deleteButton.Text = "Delete";
        deleteButton.UseVisualStyleBackColor = true;

        addButton.Dock = DockStyle.Left;
        addButton.Size = new Size(60, 24);
        addButton.TabIndex = 1;
        addButton.Text = "Add";
        addButton.UseVisualStyleBackColor = true;
        addButton.BringToFront();

        grid.AllowUserToAddRows = false;
        grid.AutoGenerateColumns = false;
        grid.ColumnHeadersHeight = 34;
        grid.Dock = DockStyle.Fill;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.DataError += (s, e) => e.Cancel = true;
    }

    private Panel pnlScrollHost = null!;
    private FlowLayoutPanel flpValidationHints = null!;
    private TableLayoutPanel tblEntryDetailLayout = null!;

    private Label lblEntrySection = null!;
    private Label lblEntryKind = null!;
    private Label lblEntrySourceType = null!;
    private Label lblEntryName = null!;
    private Label lblEntrySortOrder = null!;
    private Label lblEntryFlags = null!;
    private Label lblEntryRandomSeed = null!;
    private Label lblEntryNotes = null!;

    private Label lblOperationNoticeSection = null!;
    private Label lblEntryOperationType = null!;
    private Label lblEntryNoticeType = null!;

    private Label lblLocationSection = null!;
    private Label lblEntryStation = null!;
    private Label lblEntryDock = null!;
    private Label lblEntryOriginStation = null!;
    private Label lblEntryDestinationStation = null!;

    private Label lblVesselSection = null!;
    private Label lblEntryVessel = null!;
    private Label lblEntryVesselClassOverride = null!;
    private Label lblEntryRegistryOverride = null!;

    private Label lblPurposeSection = null!;
    private Label lblEntryDeclaredPurpose = null!;
    private Label lblEntryActualPurpose = null!;

    private Label lblStatusesSection = null!;
    private Label lblEntryManifestStatus = null!;
    private Label lblEntryInspectionStatus = null!;
    private Label lblEntryClearanceStatus = null!;
    private Label lblEntryEnvironmentalCondition = null!;

    private Label lblNarrativeSection = null!;
    private Label lblEntryDirective = null!;
    private Label lblEntryIncidentPhrase = null!;
    private Label lblEntryResolutionPhrase = null!;
    private Label lblEntryRouteStatusPhrase = null!;
    private Label lblEntryPublicBodyOverride = null!;

    private Label lblStoryThreadSection = null!;
    private Label lblEntryStoryThread = null!;
    private Label lblEntryAppliedStoryBeat = null!;
    private Label lblEntryAnomalySeverity = null!;

    private Label lblHiddenTruthSection = null!;
    private Label lblEntryHiddenTruthNotes = null!;

    private Label lblScheduleSection = null!;
    private Label lblEntryScheduledUtc = null!;

    private Label lblDeclaredCargoSection = null!;
    private Label lblActualCargoSection = null!;
    private Label lblDeclaredPassengersSection = null!;
    private Label lblActualPassengersSection = null!;

    private ComboBox cboEntryKind = null!;
    private ComboBox cboEntrySourceType = null!;
    private TextBox txtEntryName = null!;
    private NumericUpDown numEntrySortOrder = null!;
    private Panel pnlEntryFlags = null!;
    private CheckBox chkEntryLocked = null!;
    private CheckBox chkEntryCanon = null!;
    private NumericUpDown numEntryRandomSeed = null!;
    private TextBox txtEntryNotes = null!;

    private ComboBox cboEntryOperationType = null!;
    private ComboBox cboEntryNoticeType = null!;

    private ComboBox cboEntryStation = null!;
    private ComboBox cboEntryDock = null!;
    private ComboBox cboEntryOriginStation = null!;
    private ComboBox cboEntryDestinationStation = null!;

    private ComboBox cboEntryVessel = null!;
    private ComboBox cboEntryVesselClassOverride = null!;
    private TextBox txtEntryRegistryOverride = null!;

    private ComboBox cboEntryDeclaredPurpose = null!;
    private ComboBox cboEntryActualPurpose = null!;

    private ComboBox cboEntryManifestStatus = null!;
    private ComboBox cboEntryInspectionStatus = null!;
    private ComboBox cboEntryClearanceStatus = null!;
    private ComboBox cboEntryEnvironmentalCondition = null!;

    private ComboBox cboEntryDirective = null!;
    private ComboBox cboEntryIncidentPhrase = null!;
    private ComboBox cboEntryResolutionPhrase = null!;
    private ComboBox cboEntryRouteStatusPhrase = null!;
    private TextBox txtEntryPublicBodyOverride = null!;

    private ComboBox cboEntryStoryThread = null!;
    private ComboBox cboEntryAppliedStoryBeat = null!;
    private ComboBox cboEntryAnomalySeverity = null!;

    private TextBox txtEntryHiddenTruthNotes = null!;

    private Panel pnlEntrySchedule = null!;
    private CheckBox chkEntryScheduledEnabled = null!;
    private DateTimePicker dtpEntryScheduledUtc = null!;

    private Panel pnlDeclaredCargoContainer = null!;
    private DataGridView gridDeclaredCargo = null!;
    private Panel pnlDeclaredCargoActions = null!;
    private Button btnDeclaredCargoDelete = null!;
    private Button btnDeclaredCargoAdd = null!;

    private Panel pnlActualCargoContainer = null!;
    private DataGridView gridActualCargo = null!;
    private Panel pnlActualCargoActions = null!;
    private Button btnActualCargoDelete = null!;
    private Button btnActualCargoAdd = null!;

    private Panel pnlDeclaredPassengersContainer = null!;
    private DataGridView gridDeclaredPassengers = null!;
    private Panel pnlDeclaredPassengersActions = null!;
    private Button btnDeclaredPassengerDelete = null!;
    private Button btnDeclaredPassengerAdd = null!;

    private Panel pnlActualPassengersContainer = null!;
    private DataGridView gridActualPassengers = null!;
    private Panel pnlActualPassengersActions = null!;
    private Button btnActualPassengerDelete = null!;
    private Button btnActualPassengerAdd = null!;
}