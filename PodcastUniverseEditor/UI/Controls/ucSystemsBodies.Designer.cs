namespace PodcastUniverseEditor.UI.Controls;

partial class ucSystemsBodies
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
        split               = new SplitContainer();
        pnlSystems          = new Panel();
        lblStarSystems      = new Label();
        gridStarSystems     = new DataGridView();
        pnlBodies           = new Panel();
        lblCelestialBodies  = new Label();
        gridCelestialBodies = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlSystems.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridStarSystems).BeginInit();
        pnlBodies.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridCelestialBodies).BeginInit();
        SuspendLayout();

        // ── split ─────────────────────────────────────────────────────────────────────────────
        split.Dock        = DockStyle.Fill;
        split.Location    = new Point(0, 0);
        split.Name        = "split";
        split.Orientation = Orientation.Horizontal;
        split.Size        = new Size(858, 600);
        split.TabIndex    = 0;

        // ── pnlSystems ────────────────────────────────────────────────────────────────────────
        // Add Fill first, then Top — last added (Top) is processed first and appears at top
        pnlSystems.Controls.Add(gridStarSystems);
        pnlSystems.Controls.Add(lblStarSystems);
        pnlSystems.Dock     = DockStyle.Fill;
        pnlSystems.Location = new Point(0, 0);
        pnlSystems.Name     = "pnlSystems";
        pnlSystems.Size     = new Size(858, 297);
        pnlSystems.TabIndex = 0;

        // ── lblStarSystems ────────────────────────────────────────────────────────────────────
        lblStarSystems.Dock     = DockStyle.Top;
        lblStarSystems.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblStarSystems.Height   = 20;
        lblStarSystems.Location = new Point(0, 0);
        lblStarSystems.Name     = "lblStarSystems";
        lblStarSystems.Size     = new Size(858, 20);
        lblStarSystems.TabIndex = 0;
        lblStarSystems.Text     = "Star Systems";

        // ── gridStarSystems ───────────────────────────────────────────────────────────────────
        gridStarSystems.AllowUserToAddRows          = false;
        gridStarSystems.AutoGenerateColumns         = true;
        gridStarSystems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridStarSystems.Dock                        = DockStyle.Fill;
        gridStarSystems.Location                    = new Point(0, 20);
        gridStarSystems.MultiSelect                 = false;
        gridStarSystems.Name                        = "gridStarSystems";
        gridStarSystems.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridStarSystems.Size                        = new Size(858, 277);
        gridStarSystems.TabIndex                    = 1;

        // ── pnlBodies ─────────────────────────────────────────────────────────────────────────
        // Same stacking rule: grid first (Fill), label last (Top) → label appears at top
        pnlBodies.Controls.Add(gridCelestialBodies);
        pnlBodies.Controls.Add(lblCelestialBodies);
        pnlBodies.Dock     = DockStyle.Fill;
        pnlBodies.Location = new Point(0, 0);
        pnlBodies.Name     = "pnlBodies";
        pnlBodies.Size     = new Size(858, 297);
        pnlBodies.TabIndex = 0;

        // ── lblCelestialBodies ────────────────────────────────────────────────────────────────
        lblCelestialBodies.Dock     = DockStyle.Top;
        lblCelestialBodies.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblCelestialBodies.Height   = 20;
        lblCelestialBodies.Location = new Point(0, 0);
        lblCelestialBodies.Name     = "lblCelestialBodies";
        lblCelestialBodies.Size     = new Size(858, 20);
        lblCelestialBodies.TabIndex = 0;
        lblCelestialBodies.Text     = "Celestial Bodies";

        // ── gridCelestialBodies ───────────────────────────────────────────────────────────────
        gridCelestialBodies.AllowUserToAddRows          = false;
        gridCelestialBodies.AutoGenerateColumns         = true;
        gridCelestialBodies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridCelestialBodies.Dock                        = DockStyle.Fill;
        gridCelestialBodies.Location                    = new Point(0, 20);
        gridCelestialBodies.MultiSelect                 = false;
        gridCelestialBodies.Name                        = "gridCelestialBodies";
        gridCelestialBodies.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridCelestialBodies.Size                        = new Size(858, 277);
        gridCelestialBodies.TabIndex                    = 1;

        // ── split.Panel1 — Star Systems ───────────────────────────────────────────────────────
        split.Panel1.Controls.Add(pnlSystems);

        // ── split.Panel2 — Celestial Bodies ──────────────────────────────────────────────────
        split.Panel2.Controls.Add(pnlBodies);

        // ── ucSystemsBodies ───────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(split);
        Name = "ucSystemsBodies";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        split.ResumeLayout(false);
        pnlSystems.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridStarSystems).EndInit();
        pnlBodies.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridCelestialBodies).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split               = null!;
    private Panel           pnlSystems          = null!;
    private Label           lblStarSystems      = null!;
    private DataGridView    gridStarSystems     = null!;
    private Panel           pnlBodies           = null!;
    private Label           lblCelestialBodies  = null!;
    private DataGridView    gridCelestialBodies = null!;
}
