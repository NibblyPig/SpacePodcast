namespace PodcastUniverseEditor.UI.Controls.Episodes;

partial class ucEpisodeMetaEditor
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
        tblMetadataLayout = new TableLayoutPanel();
        lblEpisodeSection = new Label();
        lblEpisodeName = new Label();
        txtEpisodeName = new TextBox();
        lblEpisodeDate = new Label();
        pnlEpisodeDate = new Panel();
        dtpEpisodeInUniverseUtc = new DateTimePicker();
        chkEpisodeHasInUniverseDate = new CheckBox();
        lblEpisodeStation = new Label();
        cboEpisodeBroadcastStation = new ComboBox();
        lblEpisodeSeries = new Label();
        cboEpisodeSeries = new ComboBox();
        lblEpisodeCanonLock = new Label();
        chkEpisodeCanonicalLocked = new CheckBox();
        lblEpisodeNotes = new Label();
        txtEpisodeNotes = new TextBox();
        lblSeriesSection = new Label();
        lblSeriesName = new Label();
        txtSeriesName = new TextBox();
        lblSeriesStation = new Label();
        cboSeriesBroadcastStation = new ComboBox();
        lblSeriesNotes = new Label();
        txtSeriesNotes = new TextBox();
        tblMetadataLayout.SuspendLayout();
        pnlEpisodeDate.SuspendLayout();
        SuspendLayout();
        // 
        // tblMetadataLayout
        // 
        tblMetadataLayout.AutoSize = true;
        tblMetadataLayout.ColumnCount = 2;
        tblMetadataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
        tblMetadataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblMetadataLayout.Controls.Add(lblEpisodeSection, 0, 0);
        tblMetadataLayout.Controls.Add(lblEpisodeName, 0, 1);
        tblMetadataLayout.Controls.Add(txtEpisodeName, 1, 1);
        tblMetadataLayout.Controls.Add(lblEpisodeDate, 0, 2);
        tblMetadataLayout.Controls.Add(pnlEpisodeDate, 1, 2);
        tblMetadataLayout.Controls.Add(lblEpisodeStation, 0, 3);
        tblMetadataLayout.Controls.Add(cboEpisodeBroadcastStation, 1, 3);
        tblMetadataLayout.Controls.Add(lblEpisodeSeries, 0, 4);
        tblMetadataLayout.Controls.Add(cboEpisodeSeries, 1, 4);
        tblMetadataLayout.Controls.Add(lblEpisodeCanonLock, 0, 5);
        tblMetadataLayout.Controls.Add(chkEpisodeCanonicalLocked, 1, 5);
        tblMetadataLayout.Controls.Add(lblEpisodeNotes, 0, 6);
        tblMetadataLayout.Controls.Add(txtEpisodeNotes, 1, 6);
        tblMetadataLayout.Controls.Add(lblSeriesSection, 0, 7);
        tblMetadataLayout.Controls.Add(lblSeriesName, 0, 8);
        tblMetadataLayout.Controls.Add(txtSeriesName, 1, 8);
        tblMetadataLayout.Controls.Add(lblSeriesStation, 0, 9);
        tblMetadataLayout.Controls.Add(cboSeriesBroadcastStation, 1, 9);
        tblMetadataLayout.Controls.Add(lblSeriesNotes, 0, 10);
        tblMetadataLayout.Controls.Add(txtSeriesNotes, 1, 10);
        tblMetadataLayout.Dock = DockStyle.Fill;
        tblMetadataLayout.Location = new Point(0, 0);
        tblMetadataLayout.Margin = new Padding(4, 5, 4, 5);
        tblMetadataLayout.Name = "tblMetadataLayout";
        tblMetadataLayout.Padding = new Padding(6, 7, 6, 10);
        tblMetadataLayout.RowCount = 11;
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
        tblMetadataLayout.Size = new Size(429, 595);
        tblMetadataLayout.TabIndex = 0;
        // 
        // lblEpisodeSection
        // 
        lblEpisodeSection.AutoSize = true;
        tblMetadataLayout.SetColumnSpan(lblEpisodeSection, 2);
        lblEpisodeSection.Dock = DockStyle.Fill;
        lblEpisodeSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblEpisodeSection.ForeColor = SystemColors.ControlDarkDark;
        lblEpisodeSection.Location = new Point(10, 7);
        lblEpisodeSection.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeSection.Name = "lblEpisodeSection";
        lblEpisodeSection.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeSection.Size = new Size(409, 40);
        lblEpisodeSection.TabIndex = 0;
        lblEpisodeSection.Text = "Episode";
        // 
        // lblEpisodeName
        // 
        lblEpisodeName.AutoSize = true;
        lblEpisodeName.Location = new Point(10, 47);
        lblEpisodeName.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeName.Name = "lblEpisodeName";
        lblEpisodeName.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeName.Size = new Size(63, 33);
        lblEpisodeName.TabIndex = 1;
        lblEpisodeName.Text = "Name:";
        // 
        // txtEpisodeName
        // 
        txtEpisodeName.Dock = DockStyle.Fill;
        txtEpisodeName.Location = new Point(147, 52);
        txtEpisodeName.Margin = new Padding(4, 5, 4, 5);
        txtEpisodeName.Name = "txtEpisodeName";
        txtEpisodeName.Size = new Size(272, 31);
        txtEpisodeName.TabIndex = 2;
        // 
        // lblEpisodeDate
        // 
        lblEpisodeDate.AutoSize = true;
        lblEpisodeDate.Location = new Point(10, 94);
        lblEpisodeDate.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeDate.Name = "lblEpisodeDate";
        lblEpisodeDate.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeDate.Size = new Size(99, 33);
        lblEpisodeDate.TabIndex = 3;
        lblEpisodeDate.Text = "Date (UTC):";
        // 
        // pnlEpisodeDate
        // 
        pnlEpisodeDate.Controls.Add(dtpEpisodeInUniverseUtc);
        pnlEpisodeDate.Controls.Add(chkEpisodeHasInUniverseDate);
        pnlEpisodeDate.Dock = DockStyle.Fill;
        pnlEpisodeDate.Location = new Point(147, 99);
        pnlEpisodeDate.Margin = new Padding(4, 5, 4, 5);
        pnlEpisodeDate.Name = "pnlEpisodeDate";
        pnlEpisodeDate.Size = new Size(272, 37);
        pnlEpisodeDate.TabIndex = 4;
        // 
        // dtpEpisodeInUniverseUtc
        // 
        dtpEpisodeInUniverseUtc.Enabled = false;
        dtpEpisodeInUniverseUtc.Format = DateTimePickerFormat.Short;
        dtpEpisodeInUniverseUtc.Location = new Point(34, 0);
        dtpEpisodeInUniverseUtc.Margin = new Padding(4, 5, 4, 5);
        dtpEpisodeInUniverseUtc.Name = "dtpEpisodeInUniverseUtc";
        dtpEpisodeInUniverseUtc.Size = new Size(184, 31);
        dtpEpisodeInUniverseUtc.TabIndex = 1;
        // 
        // chkEpisodeHasInUniverseDate
        // 
        chkEpisodeHasInUniverseDate.Location = new Point(0, 3);
        chkEpisodeHasInUniverseDate.Margin = new Padding(4, 5, 4, 5);
        chkEpisodeHasInUniverseDate.Name = "chkEpisodeHasInUniverseDate";
        chkEpisodeHasInUniverseDate.Size = new Size(29, 33);
        chkEpisodeHasInUniverseDate.TabIndex = 0;
        chkEpisodeHasInUniverseDate.UseVisualStyleBackColor = true;
        // 
        // lblEpisodeStation
        // 
        lblEpisodeStation.AutoSize = true;
        lblEpisodeStation.Location = new Point(10, 141);
        lblEpisodeStation.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeStation.Name = "lblEpisodeStation";
        lblEpisodeStation.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeStation.Size = new Size(71, 33);
        lblEpisodeStation.TabIndex = 5;
        lblEpisodeStation.Text = "Station:";
        // 
        // cboEpisodeBroadcastStation
        // 
        cboEpisodeBroadcastStation.Dock = DockStyle.Fill;
        cboEpisodeBroadcastStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEpisodeBroadcastStation.FormattingEnabled = true;
        cboEpisodeBroadcastStation.Location = new Point(147, 146);
        cboEpisodeBroadcastStation.Margin = new Padding(4, 5, 4, 5);
        cboEpisodeBroadcastStation.Name = "cboEpisodeBroadcastStation";
        cboEpisodeBroadcastStation.Size = new Size(272, 33);
        cboEpisodeBroadcastStation.TabIndex = 6;
        // 
        // lblEpisodeSeries
        // 
        lblEpisodeSeries.AutoSize = true;
        lblEpisodeSeries.Location = new Point(10, 188);
        lblEpisodeSeries.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeSeries.Name = "lblEpisodeSeries";
        lblEpisodeSeries.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeSeries.Size = new Size(62, 33);
        lblEpisodeSeries.TabIndex = 7;
        lblEpisodeSeries.Text = "Series:";
        // 
        // cboEpisodeSeries
        // 
        cboEpisodeSeries.Dock = DockStyle.Fill;
        cboEpisodeSeries.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEpisodeSeries.FormattingEnabled = true;
        cboEpisodeSeries.Location = new Point(147, 193);
        cboEpisodeSeries.Margin = new Padding(4, 5, 4, 5);
        cboEpisodeSeries.Name = "cboEpisodeSeries";
        cboEpisodeSeries.Size = new Size(272, 33);
        cboEpisodeSeries.TabIndex = 8;
        // 
        // lblEpisodeCanonLock
        // 
        lblEpisodeCanonLock.AutoSize = true;
        lblEpisodeCanonLock.Location = new Point(10, 235);
        lblEpisodeCanonLock.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeCanonLock.Name = "lblEpisodeCanonLock";
        lblEpisodeCanonLock.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeCanonLock.Size = new Size(0, 33);
        lblEpisodeCanonLock.TabIndex = 9;
        // 
        // chkEpisodeCanonicalLocked
        // 
        chkEpisodeCanonicalLocked.AutoCheck = false;
        chkEpisodeCanonicalLocked.Location = new Point(147, 240);
        chkEpisodeCanonicalLocked.Margin = new Padding(4, 5, 4, 5);
        chkEpisodeCanonicalLocked.Name = "chkEpisodeCanonicalLocked";
        chkEpisodeCanonicalLocked.Size = new Size(271, 55);
        chkEpisodeCanonicalLocked.TabIndex = 10;
        chkEpisodeCanonicalLocked.Text = "Canon Locked (use Lock/Unlock buttons)";
        chkEpisodeCanonicalLocked.UseVisualStyleBackColor = true;
        // 
        // lblEpisodeNotes
        // 
        lblEpisodeNotes.AutoSize = true;
        lblEpisodeNotes.Location = new Point(10, 300);
        lblEpisodeNotes.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeNotes.Name = "lblEpisodeNotes";
        lblEpisodeNotes.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeNotes.Size = new Size(63, 33);
        lblEpisodeNotes.TabIndex = 11;
        lblEpisodeNotes.Text = "Notes:";
        // 
        // txtEpisodeNotes
        // 
        txtEpisodeNotes.Dock = DockStyle.Fill;
        txtEpisodeNotes.Location = new Point(147, 305);
        txtEpisodeNotes.Margin = new Padding(4, 5, 4, 5);
        txtEpisodeNotes.Multiline = true;
        txtEpisodeNotes.Name = "txtEpisodeNotes";
        txtEpisodeNotes.ScrollBars = ScrollBars.Vertical;
        txtEpisodeNotes.Size = new Size(272, 59);
        txtEpisodeNotes.TabIndex = 12;
        // 
        // lblSeriesSection
        // 
        lblSeriesSection.AutoSize = true;
        tblMetadataLayout.SetColumnSpan(lblSeriesSection, 2);
        lblSeriesSection.Dock = DockStyle.Fill;
        lblSeriesSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSeriesSection.ForeColor = SystemColors.ControlDarkDark;
        lblSeriesSection.Location = new Point(10, 369);
        lblSeriesSection.Margin = new Padding(4, 0, 4, 0);
        lblSeriesSection.Name = "lblSeriesSection";
        lblSeriesSection.Padding = new Padding(0, 8, 0, 0);
        lblSeriesSection.Size = new Size(409, 40);
        lblSeriesSection.TabIndex = 13;
        lblSeriesSection.Text = "Series";
        // 
        // lblSeriesName
        // 
        lblSeriesName.AutoSize = true;
        lblSeriesName.Location = new Point(10, 409);
        lblSeriesName.Margin = new Padding(4, 0, 4, 0);
        lblSeriesName.Name = "lblSeriesName";
        lblSeriesName.Padding = new Padding(0, 8, 0, 0);
        lblSeriesName.Size = new Size(63, 33);
        lblSeriesName.TabIndex = 14;
        lblSeriesName.Text = "Name:";
        // 
        // txtSeriesName
        // 
        txtSeriesName.Dock = DockStyle.Fill;
        txtSeriesName.Location = new Point(147, 414);
        txtSeriesName.Margin = new Padding(4, 5, 4, 5);
        txtSeriesName.Name = "txtSeriesName";
        txtSeriesName.Size = new Size(272, 31);
        txtSeriesName.TabIndex = 15;
        // 
        // lblSeriesStation
        // 
        lblSeriesStation.AutoSize = true;
        lblSeriesStation.Location = new Point(10, 456);
        lblSeriesStation.Margin = new Padding(4, 0, 4, 0);
        lblSeriesStation.Name = "lblSeriesStation";
        lblSeriesStation.Padding = new Padding(0, 8, 0, 0);
        lblSeriesStation.Size = new Size(71, 33);
        lblSeriesStation.TabIndex = 16;
        lblSeriesStation.Text = "Station:";
        // 
        // cboSeriesBroadcastStation
        // 
        cboSeriesBroadcastStation.Dock = DockStyle.Fill;
        cboSeriesBroadcastStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSeriesBroadcastStation.FormattingEnabled = true;
        cboSeriesBroadcastStation.Location = new Point(147, 461);
        cboSeriesBroadcastStation.Margin = new Padding(4, 5, 4, 5);
        cboSeriesBroadcastStation.Name = "cboSeriesBroadcastStation";
        cboSeriesBroadcastStation.Size = new Size(272, 33);
        cboSeriesBroadcastStation.TabIndex = 17;
        // 
        // lblSeriesNotes
        // 
        lblSeriesNotes.AutoSize = true;
        lblSeriesNotes.Location = new Point(10, 503);
        lblSeriesNotes.Margin = new Padding(4, 0, 4, 0);
        lblSeriesNotes.Name = "lblSeriesNotes";
        lblSeriesNotes.Padding = new Padding(0, 8, 0, 0);
        lblSeriesNotes.Size = new Size(63, 33);
        lblSeriesNotes.TabIndex = 18;
        lblSeriesNotes.Text = "Notes:";
        // 
        // txtSeriesNotes
        // 
        txtSeriesNotes.Dock = DockStyle.Fill;
        txtSeriesNotes.Location = new Point(147, 508);
        txtSeriesNotes.Margin = new Padding(4, 5, 4, 5);
        txtSeriesNotes.Multiline = true;
        txtSeriesNotes.Name = "txtSeriesNotes";
        txtSeriesNotes.ScrollBars = ScrollBars.Vertical;
        txtSeriesNotes.Size = new Size(272, 77);
        txtSeriesNotes.TabIndex = 19;
        // 
        // ucEpisodeMetaEditor
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        Controls.Add(tblMetadataLayout);
        Margin = new Padding(4, 5, 4, 5);
        Name = "ucEpisodeMetaEditor";
        Size = new Size(429, 595);
        tblMetadataLayout.ResumeLayout(false);
        tblMetadataLayout.PerformLayout();
        pnlEpisodeDate.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private TableLayoutPanel tblMetadataLayout = null!;
    private Label lblEpisodeSection = null!;
    private Label lblSeriesSection = null!;

    private Label lblEpisodeName = null!;
    private Label lblEpisodeDate = null!;
    private Label lblEpisodeStation = null!;
    private Label lblEpisodeSeries = null!;
    private Label lblEpisodeCanonLock = null!;
    private Label lblEpisodeNotes = null!;

    private Label lblSeriesName = null!;
    private Label lblSeriesStation = null!;
    private Label lblSeriesNotes = null!;

    private Panel pnlEpisodeDate = null!;

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
}