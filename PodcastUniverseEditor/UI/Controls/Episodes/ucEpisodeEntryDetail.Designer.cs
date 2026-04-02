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
        flpValidationHints = new FlowLayoutPanel();
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
        chkEntryLocked = new CheckBox();
        chkEntryCanon = new CheckBox();
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
        chkEntryScheduledEnabled = new CheckBox();
        dtpEntryScheduledUtc = new DateTimePicker();

        lblDeclaredCargoSection = new Label();
        pnlDeclaredCargoContainer = new Panel();
        gridDeclaredCargo = new DataGridView();
        pnlDeclaredCargoActions = new Panel();
        btnDeclaredCargoDelete = new Button();
        btnDeclaredCargoAdd = new Button();

        lblActualCargoSection = new Label();
        pnlActualCargoContainer = new Panel();
        gridActualCargo = new DataGridView();
        pnlActualCargoActions = new Panel();
        btnActualCargoDelete = new Button();
        btnActualCargoAdd = new Button();

        lblDeclaredPassengersSection = new Label();
        pnlDeclaredPassengersContainer = new Panel();
        gridDeclaredPassengers = new DataGridView();
        pnlDeclaredPassengersActions = new Panel();
        btnDeclaredPassengerDelete = new Button();
        btnDeclaredPassengerAdd = new Button();

        lblActualPassengersSection = new Label();
        pnlActualPassengersContainer = new Panel();
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

        pnlDeclaredCargoContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredCargo).BeginInit();
        pnlDeclaredCargoActions.SuspendLayout();

        pnlActualCargoContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridActualCargo).BeginInit();
        pnlActualCargoActions.SuspendLayout();

        pnlDeclaredPassengersContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredPassengers).BeginInit();
        pnlDeclaredPassengersActions.SuspendLayout();

        pnlActualPassengersContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridActualPassengers).BeginInit();
        pnlActualPassengersActions.SuspendLayout();

        SuspendLayout();

        // pnlScrollHost
        pnlScrollHost.AutoScroll = true;
        pnlScrollHost.Controls.Add(tblEntryDetailLayout);
        pnlScrollHost.Controls.Add(flpValidationHints);
        pnlScrollHost.Dock = DockStyle.Fill;
        pnlScrollHost.Location = new Point(0, 0);
        pnlScrollHost.Name = "pnlScrollHost";
        pnlScrollHost.Size = new Size(400, 600);
        pnlScrollHost.TabIndex = 0;

        // flpValidationHints
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

        // tblEntryDetailLayout
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

        tblEntryDetailLayout.Controls.Add(lblDeclaredCargoSection, 0, 42);
        tblEntryDetailLayout.Controls.Add(pnlDeclaredCargoContainer, 0, 43);
        tblEntryDetailLayout.Controls.Add(lblActualCargoSection, 0, 44);
        tblEntryDetailLayout.Controls.Add(pnlActualCargoContainer, 0, 45);
        tblEntryDetailLayout.Controls.Add(lblDeclaredPassengersSection, 0, 46);
        tblEntryDetailLayout.Controls.Add(pnlDeclaredPassengersContainer, 0, 47);
        tblEntryDetailLayout.Controls.Add(lblActualPassengersSection, 0, 48);
        tblEntryDetailLayout.Controls.Add(pnlActualPassengersContainer, 0, 49);

        tblEntryDetailLayout.Dock = DockStyle.Top;
        tblEntryDetailLayout.Location = new Point(0, 8);
        tblEntryDetailLayout.Name = "tblEntryDetailLayout";
        tblEntryDetailLayout.Padding = new Padding(4, 4, 4, 8);
        tblEntryDetailLayout.RowCount = 50;
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

        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
        tblEntryDetailLayout.Size = new Size(400, 2266);
        tblEntryDetailLayout.TabIndex = 1;

        // Section labels shared styling
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
        ConfigureSectionLabel(lblDeclaredCargoSection, "Declared Cargo");
        ConfigureSectionLabel(lblActualCargoSection, "Actual Cargo");
        ConfigureSectionLabel(lblDeclaredPassengersSection, "Declared Passengers");
        ConfigureSectionLabel(lblActualPassengersSection, "Actual Passengers");

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
        tblEntryDetailLayout.SetColumnSpan(lblDeclaredCargoSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblActualCargoSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblDeclaredPassengersSection, 2);
        tblEntryDetailLayout.SetColumnSpan(lblActualPassengersSection, 2);

        // Standard field labels
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

        // Combo/text/numeric rows
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

        // pnlEntryFlags
        pnlEntryFlags.Controls.Add(chkEntryCanon);
        pnlEntryFlags.Controls.Add(chkEntryLocked);
        pnlEntryFlags.Dock = DockStyle.Fill;
        pnlEntryFlags.Location = new Point(187, 160);
        pnlEntryFlags.Name = "pnlEntryFlags";
        pnlEntryFlags.Size = new Size(205, 24);
        pnlEntryFlags.TabIndex = 12;

        chkEntryLocked.AutoSize = true;
        chkEntryLocked.Location = new Point(0, 1);
        chkEntryLocked.Name = "chkEntryLocked";
        chkEntryLocked.Size = new Size(84, 29);
        chkEntryLocked.TabIndex = 0;
        chkEntryLocked.Text = "Locked";
        chkEntryLocked.UseVisualStyleBackColor = true;

        chkEntryCanon.AutoSize = true;
        chkEntryCanon.Location = new Point(90, 1);
        chkEntryCanon.Name = "chkEntryCanon";
        chkEntryCanon.Size = new Size(79, 29);
        chkEntryCanon.TabIndex = 1;
        chkEntryCanon.Text = "Canon";
        chkEntryCanon.UseVisualStyleBackColor = true;

        // pnlEntrySchedule
        pnlEntrySchedule.Controls.Add(dtpEntryScheduledUtc);
        pnlEntrySchedule.Controls.Add(chkEntryScheduledEnabled);
        pnlEntrySchedule.Dock = DockStyle.Fill;
        pnlEntrySchedule.Location = new Point(187, 1384);
        pnlEntrySchedule.Name = "pnlEntrySchedule";
        pnlEntrySchedule.Size = new Size(205, 32);
        pnlEntrySchedule.TabIndex = 82;

        chkEntryScheduledEnabled.AutoSize = false;
        chkEntryScheduledEnabled.Location = new Point(0, 2);
        chkEntryScheduledEnabled.Name = "chkEntryScheduledEnabled";
        chkEntryScheduledEnabled.Size = new Size(20, 20);
        chkEntryScheduledEnabled.TabIndex = 0;
        chkEntryScheduledEnabled.UseVisualStyleBackColor = true;

        dtpEntryScheduledUtc.Enabled = false;
        dtpEntryScheduledUtc.Format = DateTimePickerFormat.Short;
        dtpEntryScheduledUtc.Location = new Point(26, 0);
        dtpEntryScheduledUtc.Name = "dtpEntryScheduledUtc";
        dtpEntryScheduledUtc.Size = new Size(170, 31);
        dtpEntryScheduledUtc.TabIndex = 1;

        // Manifest containers
        ConfigureManifestContainer(pnlDeclaredCargoContainer, gridDeclaredCargo, pnlDeclaredCargoActions, btnDeclaredCargoDelete, btnDeclaredCargoAdd);
        ConfigureManifestContainer(pnlActualCargoContainer, gridActualCargo, pnlActualCargoActions, btnActualCargoDelete, btnActualCargoAdd);
        ConfigureManifestContainer(pnlDeclaredPassengersContainer, gridDeclaredPassengers, pnlDeclaredPassengersActions, btnDeclaredPassengerDelete, btnDeclaredPassengerAdd);
        ConfigureManifestContainer(pnlActualPassengersContainer, gridActualPassengers, pnlActualPassengersActions, btnActualPassengerDelete, btnActualPassengerAdd);

        tblEntryDetailLayout.SetColumnSpan(pnlDeclaredCargoContainer, 2);
        tblEntryDetailLayout.SetColumnSpan(pnlActualCargoContainer, 2);
        tblEntryDetailLayout.SetColumnSpan(pnlDeclaredPassengersContainer, 2);
        tblEntryDetailLayout.SetColumnSpan(pnlActualPassengersContainer, 2);

        pnlDeclaredCargoContainer.Location = new Point(7, 1444);
        pnlDeclaredCargoContainer.Name = "pnlDeclaredCargoContainer";
        pnlDeclaredCargoContainer.Size = new Size(385, 174);
        pnlDeclaredCargoContainer.TabIndex = 85;

        pnlActualCargoContainer.Location = new Point(7, 1654);
        pnlActualCargoContainer.Name = "pnlActualCargoContainer";
        pnlActualCargoContainer.Size = new Size(385, 174);
        pnlActualCargoContainer.TabIndex = 87;

        pnlDeclaredPassengersContainer.Location = new Point(7, 1864);
        pnlDeclaredPassengersContainer.Name = "pnlDeclaredPassengersContainer";
        pnlDeclaredPassengersContainer.Size = new Size(385, 174);
        pnlDeclaredPassengersContainer.TabIndex = 89;

        pnlActualPassengersContainer.Location = new Point(7, 2054);
        pnlActualPassengersContainer.Name = "pnlActualPassengersContainer";
        pnlActualPassengersContainer.Size = new Size(385, 174);
        pnlActualPassengersContainer.TabIndex = 91;

        // ucEpisodeEntryDetail
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        Controls.Add(pnlScrollHost);
        Name = "ucEpisodeEntryDetail";
        Size = new Size(400, 600);

        pnlScrollHost.ResumeLayout(false);
        pnlScrollHost.PerformLayout();
        tblEntryDetailLayout.ResumeLayout(false);
        tblEntryDetailLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numEntrySortOrder).EndInit();
        pnlEntryFlags.ResumeLayout(false);
        pnlEntryFlags.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numEntryRandomSeed).EndInit();
        pnlEntrySchedule.ResumeLayout(false);

        pnlDeclaredCargoContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDeclaredCargo).EndInit();
        pnlDeclaredCargoActions.ResumeLayout(false);

        pnlActualCargoContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridActualCargo).EndInit();
        pnlActualCargoActions.ResumeLayout(false);

        pnlDeclaredPassengersContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDeclaredPassengers).EndInit();
        pnlDeclaredPassengersActions.ResumeLayout(false);

        pnlActualPassengersContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridActualPassengers).EndInit();
        pnlActualPassengersActions.ResumeLayout(false);

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
        label.Size = new Size(386, 28);
        label.TabIndex = 0;
        label.Text = text;
    }

    private void ConfigureFieldLabel(Label label, string text)
    {
        label.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        label.AutoSize = true;
        label.Padding = new Padding(0, 6, 0, 0);
        label.Size = new Size(50, 31);
        label.TabIndex = 0;
        label.Text = text;
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
        actionsPanel.Height = 36;
        actionsPanel.Padding = new Padding(2);

        deleteButton.Dock = DockStyle.Left;
        deleteButton.Name = deleteButton.Name;
        deleteButton.Size = new Size(92, 30);
        deleteButton.TabIndex = 0;
        deleteButton.Text = "Delete";
        deleteButton.UseVisualStyleBackColor = true;

        addButton.Dock = DockStyle.Left;
        addButton.Name = addButton.Name;
        addButton.Size = new Size(92, 30);
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
        grid.RowHeadersVisible = false;
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