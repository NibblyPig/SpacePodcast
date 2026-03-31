namespace PodcastUniverseEditor.UI.Controls;

partial class ucRoutes
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
        pnlRoutes       = new Panel();
        lblRoutes       = new Label();
        pnlRoutesButtons = new Panel();
        btnRouteAdd     = new Button();
        btnRouteDelete  = new Button();
        gridRoutes      = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        pnlRoutes.SuspendLayout();
        pnlRoutesButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridRoutes).BeginInit();
        SuspendLayout();

        // ── pnlRoutes ─────────────────────────────────────────────────────────────────────────
        // Fill added before Bottom so docking resolves correctly; Top label last
        pnlRoutes.Controls.Add(gridRoutes);
        pnlRoutes.Controls.Add(pnlRoutesButtons);
        pnlRoutes.Controls.Add(lblRoutes);
        pnlRoutes.Dock     = DockStyle.Fill;
        pnlRoutes.Location = new Point(0, 0);
        pnlRoutes.Name     = "pnlRoutes";
        pnlRoutes.Size     = new Size(858, 600);
        pnlRoutes.TabIndex = 0;

        // ── lblRoutes ─────────────────────────────────────────────────────────────────────────
        lblRoutes.Dock     = DockStyle.Top;
        lblRoutes.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblRoutes.Height   = 20;
        lblRoutes.Location = new Point(0, 0);
        lblRoutes.Name     = "lblRoutes";
        lblRoutes.Size     = new Size(858, 20);
        lblRoutes.TabIndex = 0;
        lblRoutes.Text     = "Routes";

        // ── pnlRoutesButtons ──────────────────────────────────────────────────────────────────
        pnlRoutesButtons.Controls.Add(btnRouteDelete);
        pnlRoutesButtons.Controls.Add(btnRouteAdd);
        pnlRoutesButtons.Dock     = DockStyle.Bottom;
        pnlRoutesButtons.Name     = "pnlRoutesButtons";
        pnlRoutesButtons.Padding  = new Padding(2);
        pnlRoutesButtons.Size     = new Size(858, 32);
        pnlRoutesButtons.TabIndex = 1;

        // ── btnRouteAdd ───────────────────────────────────────────────────────────────────────
        btnRouteAdd.Dock                   = DockStyle.Left;
        btnRouteAdd.Location               = new Point(2, 2);
        btnRouteAdd.Name                   = "btnRouteAdd";
        btnRouteAdd.Size                   = new Size(80, 28);
        btnRouteAdd.TabIndex               = 1;
        btnRouteAdd.Text                   = "Add";
        btnRouteAdd.UseVisualStyleBackColor = true;

        // ── btnRouteDelete ────────────────────────────────────────────────────────────────────
        btnRouteDelete.Dock                   = DockStyle.Left;
        btnRouteDelete.Location               = new Point(82, 2);
        btnRouteDelete.Name                   = "btnRouteDelete";
        btnRouteDelete.Size                   = new Size(80, 28);
        btnRouteDelete.TabIndex               = 0;
        btnRouteDelete.Text                   = "Delete";
        btnRouteDelete.UseVisualStyleBackColor = true;

        // ── gridRoutes ────────────────────────────────────────────────────────────────────────
        gridRoutes.AllowUserToAddRows          = false;
        gridRoutes.AutoGenerateColumns         = true;
        gridRoutes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridRoutes.Dock                        = DockStyle.Fill;
        gridRoutes.Location                    = new Point(0, 20);
        gridRoutes.MultiSelect                 = false;
        gridRoutes.Name                        = "gridRoutes";
        gridRoutes.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridRoutes.Size                        = new Size(858, 548);
        gridRoutes.TabIndex                    = 2;

        // ── ucRoutes ──────────────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(pnlRoutes);
        Name = "ucRoutes";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        pnlRoutes.ResumeLayout(false);
        pnlRoutesButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridRoutes).EndInit();
        ResumeLayout(false);
    }

    private Panel        pnlRoutes        = null!;
    private Label        lblRoutes        = null!;
    private Panel        pnlRoutesButtons = null!;
    private Button       btnRouteAdd      = null!;
    private Button       btnRouteDelete   = null!;
    private DataGridView gridRoutes       = null!;
}
