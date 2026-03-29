namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl that hosts the scrollable episode/series metadata editing panel.
/// All controls are built in BuildLayout(), called from the constructor.
/// Because the VS Designer only regenerates InitializeComponent() — never
/// constructor bodies — BuildLayout() and all its controls survive any
/// Designer round-trip permanently.
/// </summary>
public partial class ucEpisodeMetaEditor : UserControl
{
    public ucEpisodeMetaEditor()
    {
        InitializeComponent();
        BuildLayout();
    }

    private void BuildLayout()
    {
        var tbl = new TableLayoutPanel
        {
            Name        = "tblEpisodeMeta",
            Dock        = DockStyle.Top,
            AutoSize    = true,
            ColumnCount = 2,
            Padding     = new Padding(4, 4, 4, 6)
        };
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        int mRow = 0;

        void AddMetaRow(string labelText, Control ctrl, int height = 28)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            var lbl = new Label { Text = labelText, Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true, Padding = new Padding(0, 5, 0, 0) };
            tbl.Controls.Add(lbl, 0, mRow);
            ctrl.Dock = DockStyle.Fill;
            tbl.Controls.Add(ctrl, 1, mRow);
            tbl.RowCount = ++mRow;
        }

        void AddMetaSection(string title)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
            var lbl = new Label
            {
                Text      = title,
                Dock      = DockStyle.Fill,
                Font      = new Font(SystemFonts.DefaultFont, FontStyle.Bold),
                ForeColor = SystemColors.ControlDarkDark,
                Padding   = new Padding(0, 5, 0, 0)
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
        AddMetaRow("Notes:", txtEpisodeNotes, 52);

        // ── Series section ─────────────────────────────────────────────────────

        AddMetaSection("Series");

        txtSeriesName = new TextBox { Name = "txtSeriesName" };
        AddMetaRow("Name:", txtSeriesName);

        cboSeriesBroadcastStation = new ComboBox { Name = "cboSeriesBroadcastStation", DropDownStyle = ComboBoxStyle.DropDownList };
        AddMetaRow("Station:", cboSeriesBroadcastStation);

        txtSeriesNotes = new TextBox { Name = "txtSeriesNotes", Multiline = true, ScrollBars = ScrollBars.Vertical };
        AddMetaRow("Notes:", txtSeriesNotes, 52);

        Controls.Add(tbl);
    }

    // ── Public properties ─────────────────────────────────────────────────────

    // Episode fields
    public TextBox        TxtEpisodeName              => txtEpisodeName;
    public CheckBox       ChkEpisodeHasInUniverseDate => chkEpisodeHasInUniverseDate;
    public DateTimePicker DtpEpisodeInUniverseUtc     => dtpEpisodeInUniverseUtc;
    public ComboBox       CboEpisodeBroadcastStation  => cboEpisodeBroadcastStation;
    public ComboBox       CboEpisodeSeries            => cboEpisodeSeries;
    public CheckBox       ChkEpisodeCanonicalLocked   => chkEpisodeCanonicalLocked;
    public TextBox        TxtEpisodeNotes             => txtEpisodeNotes;

    // Series fields
    public TextBox  TxtSeriesName             => txtSeriesName;
    public ComboBox CboSeriesBroadcastStation => cboSeriesBroadcastStation;
    public TextBox  TxtSeriesNotes            => txtSeriesNotes;

    // ── Fields ────────────────────────────────────────────────────────────────

    // Episode fields
    private TextBox        txtEpisodeName              = null!;
    private CheckBox       chkEpisodeHasInUniverseDate = null!;
    private DateTimePicker dtpEpisodeInUniverseUtc     = null!;
    private ComboBox       cboEpisodeBroadcastStation  = null!;
    private ComboBox       cboEpisodeSeries            = null!;
    private CheckBox       chkEpisodeCanonicalLocked   = null!;
    private TextBox        txtEpisodeNotes             = null!;

    // Series fields
    private TextBox  txtSeriesName             = null!;
    private ComboBox cboSeriesBroadcastStation = null!;
    private TextBox  txtSeriesNotes            = null!;
}
