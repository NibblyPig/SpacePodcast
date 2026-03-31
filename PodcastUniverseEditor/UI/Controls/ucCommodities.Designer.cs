namespace PodcastUniverseEditor.UI.Controls;

partial class ucCommodities
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
        pnlCommodities       = new Panel();
        lblCommodities       = new Label();
        pnlCommoditiesButtons = new Panel();
        btnCommodityAdd      = new Button();
        btnCommodityDelete   = new Button();
        gridCommodities      = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        pnlCommodities.SuspendLayout();
        pnlCommoditiesButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridCommodities).BeginInit();
        SuspendLayout();

        // ── pnlCommodities ────────────────────────────────────────────────────────────────────
        // Fill added before Bottom so docking resolves correctly; Top label last
        pnlCommodities.Controls.Add(gridCommodities);
        pnlCommodities.Controls.Add(pnlCommoditiesButtons);
        pnlCommodities.Controls.Add(lblCommodities);
        pnlCommodities.Dock     = DockStyle.Fill;
        pnlCommodities.Location = new Point(0, 0);
        pnlCommodities.Name     = "pnlCommodities";
        pnlCommodities.Size     = new Size(858, 600);
        pnlCommodities.TabIndex = 0;

        // ── lblCommodities ────────────────────────────────────────────────────────────────────
        lblCommodities.Dock     = DockStyle.Top;
        lblCommodities.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblCommodities.Height   = 20;
        lblCommodities.Location = new Point(0, 0);
        lblCommodities.Name     = "lblCommodities";
        lblCommodities.Size     = new Size(858, 20);
        lblCommodities.TabIndex = 0;
        lblCommodities.Text     = "Commodities";

        // ── pnlCommoditiesButtons ─────────────────────────────────────────────────────────────
        pnlCommoditiesButtons.Controls.Add(btnCommodityDelete);
        pnlCommoditiesButtons.Controls.Add(btnCommodityAdd);
        pnlCommoditiesButtons.Dock     = DockStyle.Bottom;
        pnlCommoditiesButtons.Name     = "pnlCommoditiesButtons";
        pnlCommoditiesButtons.Padding  = new Padding(2);
        pnlCommoditiesButtons.Size     = new Size(858, 32);
        pnlCommoditiesButtons.TabIndex = 1;

        // ── btnCommodityAdd ───────────────────────────────────────────────────────────────────
        btnCommodityAdd.Dock                   = DockStyle.Left;
        btnCommodityAdd.Location               = new Point(2, 2);
        btnCommodityAdd.Name                   = "btnCommodityAdd";
        btnCommodityAdd.Size                   = new Size(80, 28);
        btnCommodityAdd.TabIndex               = 1;
        btnCommodityAdd.Text                   = "Add";
        btnCommodityAdd.UseVisualStyleBackColor = true;

        // ── btnCommodityDelete ────────────────────────────────────────────────────────────────
        btnCommodityDelete.Dock                   = DockStyle.Left;
        btnCommodityDelete.Location               = new Point(82, 2);
        btnCommodityDelete.Name                   = "btnCommodityDelete";
        btnCommodityDelete.Size                   = new Size(80, 28);
        btnCommodityDelete.TabIndex               = 0;
        btnCommodityDelete.Text                   = "Delete";
        btnCommodityDelete.UseVisualStyleBackColor = true;

        // ── gridCommodities ───────────────────────────────────────────────────────────────────
        gridCommodities.AllowUserToAddRows          = false;
        gridCommodities.AutoGenerateColumns         = true;
        gridCommodities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridCommodities.Dock                        = DockStyle.Fill;
        gridCommodities.Location                    = new Point(0, 20);
        gridCommodities.MultiSelect                 = false;
        gridCommodities.Name                        = "gridCommodities";
        gridCommodities.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridCommodities.Size                        = new Size(858, 548);
        gridCommodities.TabIndex                    = 2;

        // ── ucCommodities ─────────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(pnlCommodities);
        Name = "ucCommodities";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        pnlCommodities.ResumeLayout(false);
        pnlCommoditiesButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridCommodities).EndInit();
        ResumeLayout(false);
    }

    private Panel        pnlCommodities        = null!;
    private Label        lblCommodities        = null!;
    private Panel        pnlCommoditiesButtons = null!;
    private Button       btnCommodityAdd       = null!;
    private Button       btnCommodityDelete    = null!;
    private DataGridView gridCommodities       = null!;
}
