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
        manifestHost = new Panel();
        pnlActualPassengersSection = new Panel();
        pnlActualPassengersContainer = new Panel();
        gridActualPassengers = new DataGridView();
        pnlActualPassengersActions = new Panel();
        btnActualPassengerDelete = new Button();
        btnActualPassengerAdd = new Button();
        lblActualPassengersSection = new Label();
        pnlDeclaredPassengersSection = new Panel();
        pnlDeclaredPassengersContainer = new Panel();
        gridDeclaredPassengers = new DataGridView();
        pnlDeclaredPassengersActions = new Panel();
        btnDeclaredPassengerDelete = new Button();
        btnDeclaredPassengerAdd = new Button();
        lblDeclaredPassengersSection = new Label();
        pnlActualCargoSection = new Panel();
        pnlActualCargoContainer = new Panel();
        gridActualCargo = new DataGridView();
        pnlActualCargoActions = new Panel();
        btnActualCargoDelete = new Button();
        btnActualCargoAdd = new Button();
        lblActualCargoSection = new Label();
        pnlDeclaredCargoSection = new Panel();
        pnlDeclaredCargoContainer = new Panel();
        gridDeclaredCargo = new DataGridView();
        pnlDeclaredCargoActions = new Panel();
        btnDeclaredCargoDelete = new Button();
        btnDeclaredCargoAdd = new Button();
        lblDeclaredCargoSection = new Label();
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
        flpValidationHints = new FlowLayoutPanel();
        pnlScrollHost.SuspendLayout();
        manifestHost.SuspendLayout();
        pnlActualPassengersSection.SuspendLayout();
        pnlActualPassengersContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridActualPassengers).BeginInit();
        pnlActualPassengersActions.SuspendLayout();
        pnlDeclaredPassengersSection.SuspendLayout();
        pnlDeclaredPassengersContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredPassengers).BeginInit();
        pnlDeclaredPassengersActions.SuspendLayout();
        pnlActualCargoSection.SuspendLayout();
        pnlActualCargoContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridActualCargo).BeginInit();
        pnlActualCargoActions.SuspendLayout();
        pnlDeclaredCargoSection.SuspendLayout();
        pnlDeclaredCargoContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredCargo).BeginInit();
        pnlDeclaredCargoActions.SuspendLayout();
        tblEntryDetailLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numEntrySortOrder).BeginInit();
        pnlEntryFlags.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numEntryRandomSeed).BeginInit();
        pnlEntrySchedule.SuspendLayout();
        SuspendLayout();
        // 
        // pnlScrollHost
        // 
        pnlScrollHost.AutoScroll = true;
        pnlScrollHost.Controls.Add(manifestHost);
        pnlScrollHost.Controls.Add(tblEntryDetailLayout);
        pnlScrollHost.Controls.Add(flpValidationHints);
        pnlScrollHost.Dock = DockStyle.Fill;
        pnlScrollHost.Location = new Point(0, 0);
        pnlScrollHost.Name = "pnlScrollHost";
        pnlScrollHost.Size = new Size(400, 600);
        pnlScrollHost.TabIndex = 0;
        // 
        // manifestHost
        // 
        manifestHost.AutoSize = true;
        manifestHost.Controls.Add(pnlActualPassengersSection);
        manifestHost.Controls.Add(pnlDeclaredPassengersSection);
        manifestHost.Controls.Add(pnlActualCargoSection);
        manifestHost.Controls.Add(pnlDeclaredCargoSection);
        manifestHost.Dock = DockStyle.Top;
        manifestHost.Location = new Point(0, 1412);
        manifestHost.Name = "manifestHost";
        manifestHost.Padding = new Padding(4, 0, 4, 8);
        manifestHost.Size = new Size(383, 840);
        manifestHost.TabIndex = 2;
        // 
        // pnlActualPassengersSection
        // 
        pnlActualPassengersSection.Controls.Add(pnlActualPassengersContainer);
        pnlActualPassengersSection.Controls.Add(lblActualPassengersSection);
        pnlActualPassengersSection.Dock = DockStyle.Top;
        pnlActualPassengersSection.Location = new Point(4, 618);
        pnlActualPassengersSection.Name = "pnlActualPassengersSection";
        pnlActualPassengersSection.Padding = new Padding(0, 0, 0, 12);
        pnlActualPassengersSection.Size = new Size(375, 206);
        pnlActualPassengersSection.TabIndex = 3;
        // 
        // pnlActualPassengersContainer
        // 
        pnlActualPassengersContainer.Controls.Add(gridActualPassengers);
        pnlActualPassengersContainer.Controls.Add(pnlActualPassengersActions);
        pnlActualPassengersContainer.Dock = DockStyle.Top;
        pnlActualPassengersContainer.Location = new Point(0, 28);
        pnlActualPassengersContainer.Name = "pnlActualPassengersContainer";
        pnlActualPassengersContainer.Size = new Size(375, 166);
        pnlActualPassengersContainer.TabIndex = 1;
        // 
        // gridActualPassengers
        // 
        gridActualPassengers.AllowUserToAddRows = false;
        gridActualPassengers.AutoGenerateColumns = false;
        gridActualPassengers.ColumnHeadersHeight = 34;
        gridActualPassengers.Dock = DockStyle.Fill;
        gridActualPassengers.Location = new Point(0, 0);
        gridActualPassengers.MultiSelect = false;
        gridActualPassengers.Name = "gridActualPassengers";
        gridActualPassengers.RowHeadersVisible = false;
        gridActualPassengers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridActualPassengers.Size = new Size(375, 130);
        gridActualPassengers.TabIndex = 0;
        gridActualPassengers.DataError += Grid_DataErrorCancel;
        // 
        // pnlActualPassengersActions
        // 
        pnlActualPassengersActions.Controls.Add(btnActualPassengerDelete);
        pnlActualPassengersActions.Controls.Add(btnActualPassengerAdd);
        pnlActualPassengersActions.Dock = DockStyle.Bottom;
        pnlActualPassengersActions.Location = new Point(0, 130);
        pnlActualPassengersActions.Name = "pnlActualPassengersActions";
        pnlActualPassengersActions.Padding = new Padding(2);
        pnlActualPassengersActions.Size = new Size(375, 36);
        pnlActualPassengersActions.TabIndex = 1;
        // 
        // btnActualPassengerDelete
        // 
        btnActualPassengerDelete.Dock = DockStyle.Left;
        btnActualPassengerDelete.Location = new Point(2, 2);
        btnActualPassengerDelete.Name = "btnActualPassengerDelete";
        btnActualPassengerDelete.Size = new Size(92, 32);
        btnActualPassengerDelete.TabIndex = 0;
        btnActualPassengerDelete.Text = "Delete";
        btnActualPassengerDelete.UseVisualStyleBackColor = true;
        // 
        // btnActualPassengerAdd
        // 
        btnActualPassengerAdd.Dock = DockStyle.Left;
        btnActualPassengerAdd.Location = new Point(94, 2);
        btnActualPassengerAdd.Name = "btnActualPassengerAdd";
        btnActualPassengerAdd.Size = new Size(92, 32);
        btnActualPassengerAdd.TabIndex = 1;
        btnActualPassengerAdd.Text = "Add";
        btnActualPassengerAdd.UseVisualStyleBackColor = true;
        // 
        // lblActualPassengersSection
        // 
        lblActualPassengersSection.AutoSize = true;
        lblActualPassengersSection.Dock = DockStyle.Top;
        lblActualPassengersSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblActualPassengersSection.ForeColor = SystemColors.ControlDarkDark;
        lblActualPassengersSection.Location = new Point(0, 0);
        lblActualPassengersSection.Name = "lblActualPassengersSection";
        lblActualPassengersSection.Padding = new Padding(0, 8, 0, 0);
        lblActualPassengersSection.Size = new Size(129, 28);
        lblActualPassengersSection.TabIndex = 0;
        lblActualPassengersSection.Text = "Actual Passengers";
        // 
        // pnlDeclaredPassengersSection
        // 
        pnlDeclaredPassengersSection.Controls.Add(pnlDeclaredPassengersContainer);
        pnlDeclaredPassengersSection.Controls.Add(lblDeclaredPassengersSection);
        pnlDeclaredPassengersSection.Dock = DockStyle.Top;
        pnlDeclaredPassengersSection.Location = new Point(4, 412);
        pnlDeclaredPassengersSection.Name = "pnlDeclaredPassengersSection";
        pnlDeclaredPassengersSection.Padding = new Padding(0, 0, 0, 12);
        pnlDeclaredPassengersSection.Size = new Size(375, 206);
        pnlDeclaredPassengersSection.TabIndex = 2;
        // 
        // pnlDeclaredPassengersContainer
        // 
        pnlDeclaredPassengersContainer.Controls.Add(gridDeclaredPassengers);
        pnlDeclaredPassengersContainer.Controls.Add(pnlDeclaredPassengersActions);
        pnlDeclaredPassengersContainer.Dock = DockStyle.Top;
        pnlDeclaredPassengersContainer.Location = new Point(0, 28);
        pnlDeclaredPassengersContainer.Name = "pnlDeclaredPassengersContainer";
        pnlDeclaredPassengersContainer.Size = new Size(375, 166);
        pnlDeclaredPassengersContainer.TabIndex = 1;
        // 
        // gridDeclaredPassengers
        // 
        gridDeclaredPassengers.AllowUserToAddRows = false;
        gridDeclaredPassengers.AutoGenerateColumns = false;
        gridDeclaredPassengers.ColumnHeadersHeight = 34;
        gridDeclaredPassengers.Dock = DockStyle.Fill;
        gridDeclaredPassengers.Location = new Point(0, 0);
        gridDeclaredPassengers.MultiSelect = false;
        gridDeclaredPassengers.Name = "gridDeclaredPassengers";
        gridDeclaredPassengers.RowHeadersVisible = false;
        gridDeclaredPassengers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridDeclaredPassengers.Size = new Size(375, 130);
        gridDeclaredPassengers.TabIndex = 0;
        gridDeclaredPassengers.DataError += Grid_DataErrorCancel;
        // 
        // pnlDeclaredPassengersActions
        // 
        pnlDeclaredPassengersActions.Controls.Add(btnDeclaredPassengerDelete);
        pnlDeclaredPassengersActions.Controls.Add(btnDeclaredPassengerAdd);
        pnlDeclaredPassengersActions.Dock = DockStyle.Bottom;
        pnlDeclaredPassengersActions.Location = new Point(0, 130);
        pnlDeclaredPassengersActions.Name = "pnlDeclaredPassengersActions";
        pnlDeclaredPassengersActions.Padding = new Padding(2);
        pnlDeclaredPassengersActions.Size = new Size(375, 36);
        pnlDeclaredPassengersActions.TabIndex = 1;
        // 
        // btnDeclaredPassengerDelete
        // 
        btnDeclaredPassengerDelete.Dock = DockStyle.Left;
        btnDeclaredPassengerDelete.Location = new Point(2, 2);
        btnDeclaredPassengerDelete.Name = "btnDeclaredPassengerDelete";
        btnDeclaredPassengerDelete.Size = new Size(92, 32);
        btnDeclaredPassengerDelete.TabIndex = 0;
        btnDeclaredPassengerDelete.Text = "Delete";
        btnDeclaredPassengerDelete.UseVisualStyleBackColor = true;
        // 
        // btnDeclaredPassengerAdd
        // 
        btnDeclaredPassengerAdd.Dock = DockStyle.Left;
        btnDeclaredPassengerAdd.Location = new Point(94, 2);
        btnDeclaredPassengerAdd.Name = "btnDeclaredPassengerAdd";
        btnDeclaredPassengerAdd.Size = new Size(92, 32);
        btnDeclaredPassengerAdd.TabIndex = 1;
        btnDeclaredPassengerAdd.Text = "Add";
        btnDeclaredPassengerAdd.UseVisualStyleBackColor = true;
        // 
        // lblDeclaredPassengersSection
        // 
        lblDeclaredPassengersSection.AutoSize = true;
        lblDeclaredPassengersSection.Dock = DockStyle.Top;
        lblDeclaredPassengersSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblDeclaredPassengersSection.ForeColor = SystemColors.ControlDarkDark;
        lblDeclaredPassengersSection.Location = new Point(0, 0);
        lblDeclaredPassengersSection.Name = "lblDeclaredPassengersSection";
        lblDeclaredPassengersSection.Padding = new Padding(0, 8, 0, 0);
        lblDeclaredPassengersSection.Size = new Size(149, 28);
        lblDeclaredPassengersSection.TabIndex = 0;
        lblDeclaredPassengersSection.Text = "Declared Passengers";
        // 
        // pnlActualCargoSection
        // 
        pnlActualCargoSection.Controls.Add(pnlActualCargoContainer);
        pnlActualCargoSection.Controls.Add(lblActualCargoSection);
        pnlActualCargoSection.Dock = DockStyle.Top;
        pnlActualCargoSection.Location = new Point(4, 206);
        pnlActualCargoSection.Name = "pnlActualCargoSection";
        pnlActualCargoSection.Padding = new Padding(0, 0, 0, 12);
        pnlActualCargoSection.Size = new Size(375, 206);
        pnlActualCargoSection.TabIndex = 1;
        // 
        // pnlActualCargoContainer
        // 
        pnlActualCargoContainer.Controls.Add(gridActualCargo);
        pnlActualCargoContainer.Controls.Add(pnlActualCargoActions);
        pnlActualCargoContainer.Dock = DockStyle.Top;
        pnlActualCargoContainer.Location = new Point(0, 28);
        pnlActualCargoContainer.Name = "pnlActualCargoContainer";
        pnlActualCargoContainer.Size = new Size(375, 166);
        pnlActualCargoContainer.TabIndex = 1;
        // 
        // gridActualCargo
        // 
        gridActualCargo.AllowUserToAddRows = false;
        gridActualCargo.AutoGenerateColumns = false;
        gridActualCargo.ColumnHeadersHeight = 34;
        gridActualCargo.Dock = DockStyle.Fill;
        gridActualCargo.Location = new Point(0, 0);
        gridActualCargo.MultiSelect = false;
        gridActualCargo.Name = "gridActualCargo";
        gridActualCargo.RowHeadersVisible = false;
        gridActualCargo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridActualCargo.Size = new Size(375, 130);
        gridActualCargo.TabIndex = 0;
        gridActualCargo.DataError += Grid_DataErrorCancel;
        // 
        // pnlActualCargoActions
        // 
        pnlActualCargoActions.Controls.Add(btnActualCargoDelete);
        pnlActualCargoActions.Controls.Add(btnActualCargoAdd);
        pnlActualCargoActions.Dock = DockStyle.Bottom;
        pnlActualCargoActions.Location = new Point(0, 130);
        pnlActualCargoActions.Name = "pnlActualCargoActions";
        pnlActualCargoActions.Padding = new Padding(2);
        pnlActualCargoActions.Size = new Size(375, 36);
        pnlActualCargoActions.TabIndex = 1;
        // 
        // btnActualCargoDelete
        // 
        btnActualCargoDelete.Dock = DockStyle.Left;
        btnActualCargoDelete.Location = new Point(2, 2);
        btnActualCargoDelete.Name = "btnActualCargoDelete";
        btnActualCargoDelete.Size = new Size(92, 32);
        btnActualCargoDelete.TabIndex = 0;
        btnActualCargoDelete.Text = "Delete";
        btnActualCargoDelete.UseVisualStyleBackColor = true;
        // 
        // btnActualCargoAdd
        // 
        btnActualCargoAdd.Dock = DockStyle.Left;
        btnActualCargoAdd.Location = new Point(94, 2);
        btnActualCargoAdd.Name = "btnActualCargoAdd";
        btnActualCargoAdd.Size = new Size(92, 32);
        btnActualCargoAdd.TabIndex = 1;
        btnActualCargoAdd.Text = "Add";
        btnActualCargoAdd.UseVisualStyleBackColor = true;
        // 
        // lblActualCargoSection
        // 
        lblActualCargoSection.AutoSize = true;
        lblActualCargoSection.Dock = DockStyle.Top;
        lblActualCargoSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblActualCargoSection.ForeColor = SystemColors.ControlDarkDark;
        lblActualCargoSection.Location = new Point(0, 0);
        lblActualCargoSection.Name = "lblActualCargoSection";
        lblActualCargoSection.Padding = new Padding(0, 8, 0, 0);
        lblActualCargoSection.Size = new Size(92, 28);
        lblActualCargoSection.TabIndex = 0;
        lblActualCargoSection.Text = "Actual Cargo";
        // 
        // pnlDeclaredCargoSection
        // 
        pnlDeclaredCargoSection.Controls.Add(pnlDeclaredCargoContainer);
        pnlDeclaredCargoSection.Controls.Add(lblDeclaredCargoSection);
        pnlDeclaredCargoSection.Dock = DockStyle.Top;
        pnlDeclaredCargoSection.Location = new Point(4, 0);
        pnlDeclaredCargoSection.Name = "pnlDeclaredCargoSection";
        pnlDeclaredCargoSection.Padding = new Padding(0, 0, 0, 12);
        pnlDeclaredCargoSection.Size = new Size(375, 206);
        pnlDeclaredCargoSection.TabIndex = 0;
        // 
        // pnlDeclaredCargoContainer
        // 
        pnlDeclaredCargoContainer.Controls.Add(gridDeclaredCargo);
        pnlDeclaredCargoContainer.Controls.Add(pnlDeclaredCargoActions);
        pnlDeclaredCargoContainer.Dock = DockStyle.Top;
        pnlDeclaredCargoContainer.Location = new Point(0, 28);
        pnlDeclaredCargoContainer.Name = "pnlDeclaredCargoContainer";
        pnlDeclaredCargoContainer.Size = new Size(375, 166);
        pnlDeclaredCargoContainer.TabIndex = 1;
        // 
        // gridDeclaredCargo
        // 
        gridDeclaredCargo.AllowUserToAddRows = false;
        gridDeclaredCargo.AutoGenerateColumns = false;
        gridDeclaredCargo.ColumnHeadersHeight = 34;
        gridDeclaredCargo.Dock = DockStyle.Fill;
        gridDeclaredCargo.Location = new Point(0, 0);
        gridDeclaredCargo.MultiSelect = false;
        gridDeclaredCargo.Name = "gridDeclaredCargo";
        gridDeclaredCargo.RowHeadersVisible = false;
        gridDeclaredCargo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridDeclaredCargo.Size = new Size(375, 130);
        gridDeclaredCargo.TabIndex = 0;
        gridDeclaredCargo.DataError += Grid_DataErrorCancel;
        // 
        // pnlDeclaredCargoActions
        // 
        pnlDeclaredCargoActions.Controls.Add(btnDeclaredCargoDelete);
        pnlDeclaredCargoActions.Controls.Add(btnDeclaredCargoAdd);
        pnlDeclaredCargoActions.Dock = DockStyle.Bottom;
        pnlDeclaredCargoActions.Location = new Point(0, 130);
        pnlDeclaredCargoActions.Name = "pnlDeclaredCargoActions";
        pnlDeclaredCargoActions.Padding = new Padding(2);
        pnlDeclaredCargoActions.Size = new Size(375, 36);
        pnlDeclaredCargoActions.TabIndex = 1;
        // 
        // btnDeclaredCargoDelete
        // 
        btnDeclaredCargoDelete.Dock = DockStyle.Left;
        btnDeclaredCargoDelete.Location = new Point(2, 2);
        btnDeclaredCargoDelete.Name = "btnDeclaredCargoDelete";
        btnDeclaredCargoDelete.Size = new Size(92, 32);
        btnDeclaredCargoDelete.TabIndex = 0;
        btnDeclaredCargoDelete.Text = "Delete";
        btnDeclaredCargoDelete.UseVisualStyleBackColor = true;
        // 
        // btnDeclaredCargoAdd
        // 
        btnDeclaredCargoAdd.Dock = DockStyle.Left;
        btnDeclaredCargoAdd.Location = new Point(94, 2);
        btnDeclaredCargoAdd.Name = "btnDeclaredCargoAdd";
        btnDeclaredCargoAdd.Size = new Size(92, 32);
        btnDeclaredCargoAdd.TabIndex = 1;
        btnDeclaredCargoAdd.Text = "Add";
        btnDeclaredCargoAdd.UseVisualStyleBackColor = true;
        // 
        // lblDeclaredCargoSection
        // 
        lblDeclaredCargoSection.AutoSize = true;
        lblDeclaredCargoSection.Dock = DockStyle.Top;
        lblDeclaredCargoSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblDeclaredCargoSection.ForeColor = SystemColors.ControlDarkDark;
        lblDeclaredCargoSection.Location = new Point(0, 0);
        lblDeclaredCargoSection.Name = "lblDeclaredCargoSection";
        lblDeclaredCargoSection.Padding = new Padding(0, 8, 0, 0);
        lblDeclaredCargoSection.Size = new Size(108, 28);
        lblDeclaredCargoSection.TabIndex = 0;
        lblDeclaredCargoSection.Text = "Declared Cargo";
        // 
        // tblEntryDetailLayout
        // 
        tblEntryDetailLayout.AutoSize = true;
        tblEntryDetailLayout.ColumnCount = 2;
        tblEntryDetailLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
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
        tblEntryDetailLayout.Dock = DockStyle.Top;
        tblEntryDetailLayout.Location = new Point(0, 8);
        tblEntryDetailLayout.Name = "tblEntryDetailLayout";
        tblEntryDetailLayout.Padding = new Padding(4, 4, 4, 8);
        tblEntryDetailLayout.RowCount = 42;
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        tblEntryDetailLayout.Size = new Size(383, 1404);
        tblEntryDetailLayout.TabIndex = 1;
        // 
        // lblEntrySection
        // 
        ConfigureSectionLabel(lblEntrySection, "Entry");
        ConfigureSectionLabel(lblOperationNoticeSection, "Operation / Notice");
        ConfigureSectionLabel(lblLocationSection, "Location");
        ConfigureSectionLabel(lblVesselSection, "Vessel");
        ConfigureSectionLabel(lblPurposeSection, "Purpose");
        ConfigureSectionLabel(lblStatusesSection, "Statuses");
        ConfigureSectionLabel(lblNarrativeSection, "Narrative");
        ConfigureSectionLabel(lblStoryThreadSection, "Story Thread");
        ConfigureSectionLabel(lblHiddenTruthSection, "Hidden Truth");
        ConfigureSectionLabel(lblScheduleSection, "Schedule");
        tblEntryDetailLayout.SetColumnSpan(lblEntrySection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblOperationNoticeSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblLocationSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblVesselSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblPurposeSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblStatusesSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblNarrativeSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblStoryThreadSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblHiddenTruthSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblScheduleSection, 2);
        ConfigureFieldLabel(lblEntryKind, "Kind:");
        ConfigureFieldLabel(lblEntrySourceType, "Source Type:");
        ConfigureFieldLabel(lblEntryName, "Name:");
        ConfigureFieldLabel(lblEntrySortOrder, "Sort Order:");
        ConfigureFieldLabel(lblEntryFlags, "Flags:");
        ConfigureFieldLabel(lblEntryRandomSeed, "Random Seed:");
        ConfigureFieldLabel(lblEntryNotes, "Notes:");
        ConfigureFieldLabel(lblEntryOperationType, "Operation Type:");
        ConfigureFieldLabel(lblEntryNoticeType, "Notice Type:");
        ConfigureFieldLabel(lblEntryStation, "Station:");
        ConfigureFieldLabel(lblEntryDock, "Dock:");
        ConfigureFieldLabel(lblEntryOriginStation, "Origin Station:");
        ConfigureFieldLabel(lblEntryDestinationStation, "Destination Station:");
        ConfigureFieldLabel(lblEntryVessel, "Vessel:");
        ConfigureFieldLabel(lblEntryVesselClassOverride, "Class Override:");
        ConfigureFieldLabel(lblEntryRegistryOverride, "Registry Override:");
        ConfigureFieldLabel(lblEntryDeclaredPurpose, "Declared Purpose:");
        ConfigureFieldLabel(lblEntryActualPurpose, "Actual Purpose:");
        ConfigureFieldLabel(lblEntryManifestStatus, "Manifest Status:");
        ConfigureFieldLabel(lblEntryInspectionStatus, "Inspection Status:");
        ConfigureFieldLabel(lblEntryClearanceStatus, "Clearance Status:");
        ConfigureFieldLabel(lblEntryEnvironmentalCondition, "Environment:");
        ConfigureFieldLabel(lblEntryDirective, "Directive:");
        ConfigureFieldLabel(lblEntryIncidentPhrase, "Incident Phrase:");
        ConfigureFieldLabel(lblEntryResolutionPhrase, "Resolution Phrase:");
        ConfigureFieldLabel(lblEntryRouteStatusPhrase, "Route Status Phrase:");
        ConfigureFieldLabel(lblEntryPublicBodyOverride, "Public Body Override:");
        ConfigureFieldLabel(lblEntryStoryThread, "Story Thread:");
        ConfigureFieldLabel(lblEntryAppliedStoryBeat, "Story Beat:");
        ConfigureFieldLabel(lblEntryAnomalySeverity, "Anomaly Severity:");
        ConfigureFieldLabel(lblEntryHiddenTruthNotes, "Notes:");
        ConfigureFieldLabel(lblEntryScheduledUtc, "Scheduled (UTC):");
        ConfigureFillControl(cboEntryKind);
        ConfigureFillControl(cboEntrySourceType);
        ConfigureFillControl(txtEntryName);
        ConfigureFillControl(numEntrySortOrder);
        ConfigureFillControl(numEntryRandomSeed);
        ConfigureFillControl(txtEntryNotes);
        ConfigureFillControl(cboEntryOperationType);
        ConfigureFillControl(cboEntryNoticeType);
        ConfigureFillControl(cboEntryStation);
        ConfigureFillControl(cboEntryDock);
        ConfigureFillControl(cboEntryOriginStation);
        ConfigureFillControl(cboEntryDestinationStation);
        ConfigureFillControl(cboEntryVessel);
        ConfigureFillControl(cboEntryVesselClassOverride);
        ConfigureFillControl(txtEntryRegistryOverride);
        ConfigureFillControl(cboEntryDeclaredPurpose);
        ConfigureFillControl(cboEntryActualPurpose);
        ConfigureFillControl(cboEntryManifestStatus);
        ConfigureFillControl(cboEntryInspectionStatus);
        ConfigureFillControl(cboEntryClearanceStatus);
        ConfigureFillControl(cboEntryEnvironmentalCondition);
        ConfigureFillControl(cboEntryDirective);
        ConfigureFillControl(cboEntryIncidentPhrase);
        ConfigureFillControl(cboEntryResolutionPhrase);
        ConfigureFillControl(cboEntryRouteStatusPhrase);
        ConfigureFillControl(txtEntryPublicBodyOverride);
        ConfigureFillControl(cboEntryStoryThread);
        ConfigureFillControl(cboEntryAppliedStoryBeat);
        ConfigureFillControl(cboEntryAnomalySeverity);
        ConfigureFillControl(txtEntryHiddenTruthNotes);
        cboEntryKind.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntrySourceType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryOperationType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryNoticeType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDock.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryOriginStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDestinationStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryVessel.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryVesselClassOverride.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDeclaredPurpose.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryActualPurpose.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryManifestStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryInspectionStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryClearanceStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryEnvironmentalCondition.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDirective.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryIncidentPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryResolutionPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryRouteStatusPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryStoryThread.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryAppliedStoryBeat.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryAnomalySeverity.DropDownStyle = ComboBoxStyle.DropDownList;
        numEntrySortOrder.Maximum = 9999;
        numEntryRandomSeed.Minimum = int.MinValue;
        numEntryRandomSeed.Maximum = int.MaxValue;
        txtEntryNotes.Multiline = true;
        txtEntryNotes.ScrollBars = ScrollBars.Vertical;
        txtEntryPublicBodyOverride.Multiline = true;
        txtEntryPublicBodyOverride.ScrollBars = ScrollBars.Vertical;
        txtEntryHiddenTruthNotes.Multiline = true;
        txtEntryHiddenTruthNotes.ScrollBars = ScrollBars.Vertical;
        // 
        // pnlEntryFlags
        // 
        pnlEntryFlags.Controls.Add(chkEntryCanon);
        pnlEntryFlags.Controls.Add(chkEntryLocked);
        pnlEntryFlags.Dock = DockStyle.Fill;
        pnlEntryFlags.Location = new Point(187, 160);
        pnlEntryFlags.Name = "pnlEntryFlags";
        pnlEntryFlags.Size = new Size(189, 24);
        pnlEntryFlags.TabIndex = 12;
        // 
        // chkEntryCanon
        // 
        chkEntryCanon.AutoSize = true;
        chkEntryCanon.Location = new Point(90, 1);
        chkEntryCanon.Name = "chkEntryCanon";
        chkEntryCanon.Size = new Size(72, 24);
        chkEntryCanon.TabIndex = 1;
        chkEntryCanon.Text = "Canon";
        chkEntryCanon.UseVisualStyleBackColor = true;
        // 
        // chkEntryLocked
        // 
        chkEntryLocked.AutoSize = true;
        chkEntryLocked.Location = new Point(0, 1);
        chkEntryLocked.Name = "chkEntryLocked";
        chkEntryLocked.Size = new Size(77, 24);
        chkEntryLocked.TabIndex = 0;
        chkEntryLocked.Text = "Locked";
        chkEntryLocked.UseVisualStyleBackColor = true;
        // 
        // pnlEntrySchedule
        // 
        pnlEntrySchedule.Controls.Add(dtpEntryScheduledUtc);
        pnlEntrySchedule.Controls.Add(chkEntryScheduledEnabled);
        pnlEntrySchedule.Dock = DockStyle.Fill;
        pnlEntrySchedule.Location = new Point(187, 1378);
        pnlEntrySchedule.Name = "pnlEntrySchedule";
        pnlEntrySchedule.Size = new Size(189, 30);
        pnlEntrySchedule.TabIndex = 82;
        // 
        // dtpEntryScheduledUtc
        // 
        dtpEntryScheduledUtc.Enabled = false;
        dtpEntryScheduledUtc.Format = DateTimePickerFormat.Short;
        dtpEntryScheduledUtc.Location = new Point(26, 0);
        dtpEntryScheduledUtc.Name = "dtpEntryScheduledUtc";
        dtpEntryScheduledUtc.Size = new Size(157, 27);
        dtpEntryScheduledUtc.TabIndex = 1;
        // 
        // chkEntryScheduledEnabled
        // 
        chkEntryScheduledEnabled.AutoSize = false;
        chkEntryScheduledEnabled.Location = new Point(0, 3);
        chkEntryScheduledEnabled.Name = "chkEntryScheduledEnabled";
        chkEntryScheduledEnabled.Size = new Size(20, 20);
        chkEntryScheduledEnabled.TabIndex = 0;
        chkEntryScheduledEnabled.UseVisualStyleBackColor = true;
        // 
        // flpValidationHints
        // 
        flpValidationHints.AutoSize = true;
        flpValidationHints.BackColor = Color.FromArgb(255, 252, 220);
        flpValidationHints.Dock = DockStyle.Top;
        flpValidationHints.FlowDirection = FlowDirection.TopDown;
        flpValidationHints.Location = new Point(0, 0);
        flpValidationHints.Name = "flpValidationHints";
        flpValidationHints.Padding = new Padding(6, 4, 6, 4);
        flpValidationHints.Size = new Size(400, 8);
        flpValidationHints.TabIndex = 0;
        flpValidationHints.Visible = false;
        flpValidationHints.WrapContents = false;
        // 
        // ucEpisodeEntryDetail
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        Controls.Add(pnlScrollHost);
        Name = "ucEpisodeEntryDetail";
        Size = new Size(400, 600);
        pnlScrollHost.ResumeLayout(false);
        pnlScrollHost.PerformLayout();
        manifestHost.ResumeLayout(false);
        pnlActualPassengersSection.ResumeLayout(false);
        pnlActualPassengersSection.PerformLayout();
        pnlActualPassengersContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridActualPassengers).EndInit();
        pnlActualPassengersActions.ResumeLayout(false);
        pnlDeclaredPassengersSection.ResumeLayout(false);
        pnlDeclaredPassengersSection.PerformLayout();
        pnlDeclaredPassengersContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDeclaredPassengers).EndInit();
        pnlDeclaredPassengersActions.ResumeLayout(false);
        pnlActualCargoSection.ResumeLayout(false);
        pnlActualCargoSection.PerformLayout();
        pnlActualCargoContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridActualCargo).EndInit();
        pnlActualCargoActions.ResumeLayout(false);
        pnlDeclaredCargoSection.ResumeLayout(false);
        pnlDeclaredCargoSection.PerformLayout();
        pnlDeclaredCargoContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDeclaredCargo).EndInit();
        pnlDeclaredCargoActions.ResumeLayout(false);
        tblEntryDetailLayout.ResumeLayout(false);
        tblEntryDetailLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numEntrySortOrder).EndInit();
        pnlEntryFlags.ResumeLayout(false);
        pnlEntryFlags.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numEntryRandomSeed).EndInit();
        pnlEntrySchedule.ResumeLayout(false);
        ResumeLayout(false);
    }

    private void ConfigureSectionLabel(Label label, string text)
    {
        label.AutoSize = true;
        label.Dock = DockStyle.Fill;
        label.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label.ForeColor = SystemColors.ControlDarkDark;
        label.Name = text.Replace(" ", string.Empty).Replace("/", string.Empty) + "SectionLabel";
        label.Padding = new Padding(0, 8, 0, 0);
        label.Text = text;
    }

    private void ConfigureFieldLabel(Label label, string text)
    {
        label.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        label.AutoSize = true;
        label.Padding = new Padding(0, 6, 0, 0);
        label.Text = text;
    }

    private void ConfigureFillControl(Control control)
    {
        control.Dock = DockStyle.Fill;
        control.Margin = new Padding(3);
    }

    private void Grid_DataErrorCancel(object? sender, DataGridViewDataErrorEventArgs e)
    {
        e.Cancel = true;
    }

    private Panel pnlScrollHost = null!;
    private FlowLayoutPanel flpValidationHints = null!;
    private TableLayoutPanel tblEntryDetailLayout = null!;
    private Panel manifestHost = null!;
    private Panel pnlDeclaredCargoSection = null!;
    private Panel pnlActualCargoSection = null!;
    private Panel pnlDeclaredPassengersSection = null!;
    private Panel pnlActualPassengersSection = null!;

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