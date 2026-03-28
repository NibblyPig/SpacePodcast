namespace PodcastUniverseEditor.UI.Controls;

partial class ucStationsDocks
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
        // ── Declare all controls (all new() calls first — WinForms Designer convention) ──────
        split              = new SplitContainer();
        lblStations        = new Label();
        pnlStationsButtons = new Panel();
        btnStationsAdd     = new Button();
        btnStationsDelete  = new Button();
        gridStations       = new DataGridView();
        lblDocks           = new Label();
        pnlDocksButtons    = new Panel();
        btnDocksAdd        = new Button();
        btnDocksDelete     = new Button();
        gridDocks          = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlStationsButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridStations).BeginInit();
        pnlDocksButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDocks).BeginInit();
        SuspendLayout();

        // ── split ─────────────────────────────────────────────────────────────────────────────
        split.Dock             = DockStyle.Fill;
        split.Location         = new Point(0, 0);
        split.Name             = "split";
        split.Orientation      = Orientation.Horizontal;
        split.Size             = new Size(858, 809);
        split.SplitterDistance = 354;
        split.TabIndex         = 0;

        // ── lblStations ───────────────────────────────────────────────────────────────────────
        lblStations.Dock     = DockStyle.Top;
        lblStations.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblStations.Location = new Point(0, 0);
        lblStations.Name     = "lblStations";
        lblStations.Size     = new Size(858, 20);
        lblStations.TabIndex = 0;
        lblStations.Text     = "Stations";

        // ── pnlStationsButtons ────────────────────────────────────────────────────────────────
        pnlStationsButtons.Controls.Add(btnStationsDelete);
        pnlStationsButtons.Controls.Add(btnStationsAdd);
        pnlStationsButtons.Dock     = DockStyle.Top;
        pnlStationsButtons.Location = new Point(0, 20);
        pnlStationsButtons.Name     = "pnlStationsButtons";
        pnlStationsButtons.Padding  = new Padding(2);
        pnlStationsButtons.Size     = new Size(858, 32);
        pnlStationsButtons.TabIndex = 1;

        // ── btnStationsAdd ────────────────────────────────────────────────────────────────────
        btnStationsAdd.Dock                  = DockStyle.Left;
        btnStationsAdd.Location              = new Point(2, 2);
        btnStationsAdd.Name                  = "btnStationsAdd";
        btnStationsAdd.Size                  = new Size(80, 28);
        btnStationsAdd.TabIndex              = 1;
        btnStationsAdd.Text                  = "Add";
        btnStationsAdd.UseVisualStyleBackColor = true;

        // ── btnStationsDelete ─────────────────────────────────────────────────────────────────
        btnStationsDelete.Dock                  = DockStyle.Left;
        btnStationsDelete.Location              = new Point(82, 2);
        btnStationsDelete.Name                  = "btnStationsDelete";
        btnStationsDelete.Size                  = new Size(80, 28);
        btnStationsDelete.TabIndex              = 0;
        btnStationsDelete.Text                  = "Delete";
        btnStationsDelete.UseVisualStyleBackColor = true;

        // ── gridStations ──────────────────────────────────────────────────────────────────────
        gridStations.AllowUserToAddRows          = false;
        gridStations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridStations.Dock                        = DockStyle.Fill;
        gridStations.Location                    = new Point(0, 52);
        gridStations.MultiSelect                 = false;
        gridStations.Name                        = "gridStations";
        gridStations.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridStations.Size                        = new Size(858, 302);
        gridStations.TabIndex                    = 2;

        // ── lblDocks ──────────────────────────────────────────────────────────────────────────
        lblDocks.Dock     = DockStyle.Top;
        lblDocks.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblDocks.Location = new Point(0, 0);
        lblDocks.Name     = "lblDocks";
        lblDocks.Size     = new Size(858, 20);
        lblDocks.TabIndex = 0;
        lblDocks.Text     = "Docks";

        // ── pnlDocksButtons ───────────────────────────────────────────────────────────────────
        pnlDocksButtons.Controls.Add(btnDocksDelete);
        pnlDocksButtons.Controls.Add(btnDocksAdd);
        pnlDocksButtons.Dock     = DockStyle.Top;
        pnlDocksButtons.Location = new Point(0, 20);
        pnlDocksButtons.Name     = "pnlDocksButtons";
        pnlDocksButtons.Padding  = new Padding(2);
        pnlDocksButtons.Size     = new Size(858, 32);
        pnlDocksButtons.TabIndex = 1;

        // ── btnDocksAdd ───────────────────────────────────────────────────────────────────────
        btnDocksAdd.Dock                  = DockStyle.Left;
        btnDocksAdd.Location              = new Point(2, 2);
        btnDocksAdd.Name                  = "btnDocksAdd";
        btnDocksAdd.Size                  = new Size(80, 28);
        btnDocksAdd.TabIndex              = 1;
        btnDocksAdd.Text                  = "Add";
        btnDocksAdd.UseVisualStyleBackColor = true;

        // ── btnDocksDelete ────────────────────────────────────────────────────────────────────
        btnDocksDelete.Dock                  = DockStyle.Left;
        btnDocksDelete.Location              = new Point(82, 2);
        btnDocksDelete.Name                  = "btnDocksDelete";
        btnDocksDelete.Size                  = new Size(80, 28);
        btnDocksDelete.TabIndex              = 0;
        btnDocksDelete.Text                  = "Delete";
        btnDocksDelete.UseVisualStyleBackColor = true;

        // ── gridDocks ─────────────────────────────────────────────────────────────────────────
        gridDocks.AllowUserToAddRows          = false;
        gridDocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridDocks.Dock                        = DockStyle.Fill;
        gridDocks.Location                    = new Point(0, 52);
        gridDocks.MultiSelect                 = false;
        gridDocks.Name                        = "gridDocks";
        gridDocks.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridDocks.Size                        = new Size(858, 399);
        gridDocks.TabIndex                    = 2;

        // ── split.Panel1 — Stations ───────────────────────────────────────────────────────────
        // DockStyle.Top: last Controls.Add = topmost → lblStations last
        split.Panel1.Controls.Add(gridStations);
        split.Panel1.Controls.Add(pnlStationsButtons);
        split.Panel1.Controls.Add(lblStations);

        // ── split.Panel2 — Docks ──────────────────────────────────────────────────────────────
        // Same stacking rule: lblDocks last = topmost
        split.Panel2.Controls.Add(gridDocks);
        split.Panel2.Controls.Add(pnlDocksButtons);
        split.Panel2.Controls.Add(lblDocks);

        // ── ucStationsDocks ───────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(split);
        Name = "ucStationsDocks";
        Size = new Size(858, 809);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        split.ResumeLayout(false);
        pnlStationsButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridStations).EndInit();
        pnlDocksButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDocks).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split              = null!;
    private Label           lblStations        = null!;
    private Panel           pnlStationsButtons = null!;
    private Button          btnStationsAdd     = null!;
    private Button          btnStationsDelete  = null!;
    private DataGridView    gridStations       = null!;
    private Label           lblDocks           = null!;
    private Panel           pnlDocksButtons    = null!;
    private Button          btnDocksAdd        = null!;
    private Button          btnDocksDelete     = null!;
    private DataGridView    gridDocks          = null!;
}
