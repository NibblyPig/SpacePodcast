namespace PodcastUniverseEditor.UI.Controls;

partial class ucOrganisationsDirectives
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
        pnlOrgs            = new Panel();
        lblOrganisations   = new Label();
        gridOrganisations  = new DataGridView();
        pnlDirectives      = new Panel();
        lblDirectives      = new Label();
        gridDirectives     = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlOrgs.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridOrganisations).BeginInit();
        pnlDirectives.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDirectives).BeginInit();
        SuspendLayout();

        // ── split ─────────────────────────────────────────────────────────────────────────────
        split.Dock        = DockStyle.Fill;
        split.Location    = new Point(0, 0);
        split.Name        = "split";
        split.Orientation = Orientation.Horizontal;
        split.Size        = new Size(858, 600);
        split.TabIndex    = 0;

        // ── pnlOrgs ───────────────────────────────────────────────────────────────────────────
        // Add Fill first, then Top — last added (Top) is processed first and appears at top
        pnlOrgs.Controls.Add(gridOrganisations);
        pnlOrgs.Controls.Add(lblOrganisations);
        pnlOrgs.Dock     = DockStyle.Fill;
        pnlOrgs.Location = new Point(0, 0);
        pnlOrgs.Name     = "pnlOrgs";
        pnlOrgs.Size     = new Size(858, 297);
        pnlOrgs.TabIndex = 0;

        // ── lblOrganisations ──────────────────────────────────────────────────────────────────
        lblOrganisations.Dock     = DockStyle.Top;
        lblOrganisations.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblOrganisations.Height   = 20;
        lblOrganisations.Location = new Point(0, 0);
        lblOrganisations.Name     = "lblOrganisations";
        lblOrganisations.Size     = new Size(858, 20);
        lblOrganisations.TabIndex = 0;
        lblOrganisations.Text     = "Organisations";

        // ── gridOrganisations ─────────────────────────────────────────────────────────────────
        gridOrganisations.AllowUserToAddRows          = false;
        gridOrganisations.AutoGenerateColumns         = true;
        gridOrganisations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridOrganisations.Dock                        = DockStyle.Fill;
        gridOrganisations.Location                    = new Point(0, 20);
        gridOrganisations.MultiSelect                 = false;
        gridOrganisations.Name                        = "gridOrganisations";
        gridOrganisations.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridOrganisations.Size                        = new Size(858, 277);
        gridOrganisations.TabIndex                    = 1;

        // ── pnlDirectives ─────────────────────────────────────────────────────────────────────
        // Same stacking rule: grid first (Fill), label last (Top) → label appears at top
        pnlDirectives.Controls.Add(gridDirectives);
        pnlDirectives.Controls.Add(lblDirectives);
        pnlDirectives.Dock     = DockStyle.Fill;
        pnlDirectives.Location = new Point(0, 0);
        pnlDirectives.Name     = "pnlDirectives";
        pnlDirectives.Size     = new Size(858, 297);
        pnlDirectives.TabIndex = 0;

        // ── lblDirectives ─────────────────────────────────────────────────────────────────────
        lblDirectives.Dock     = DockStyle.Top;
        lblDirectives.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblDirectives.Height   = 20;
        lblDirectives.Location = new Point(0, 0);
        lblDirectives.Name     = "lblDirectives";
        lblDirectives.Size     = new Size(858, 20);
        lblDirectives.TabIndex = 0;
        lblDirectives.Text     = "Directives";

        // ── gridDirectives ────────────────────────────────────────────────────────────────────
        gridDirectives.AllowUserToAddRows          = false;
        gridDirectives.AutoGenerateColumns         = true;
        gridDirectives.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridDirectives.Dock                        = DockStyle.Fill;
        gridDirectives.Location                    = new Point(0, 20);
        gridDirectives.MultiSelect                 = false;
        gridDirectives.Name                        = "gridDirectives";
        gridDirectives.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridDirectives.Size                        = new Size(858, 277);
        gridDirectives.TabIndex                    = 1;

        // ── split.Panel1 — Organisations ──────────────────────────────────────────────────────
        split.Panel1.Controls.Add(pnlOrgs);

        // ── split.Panel2 — Directives ─────────────────────────────────────────────────────────
        split.Panel2.Controls.Add(pnlDirectives);

        // ── ucOrganisationsDirectives ─────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(split);
        Name = "ucOrganisationsDirectives";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        split.ResumeLayout(false);
        pnlOrgs.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridOrganisations).EndInit();
        pnlDirectives.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDirectives).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split             = null!;
    private Panel           pnlOrgs           = null!;
    private Label           lblOrganisations  = null!;
    private DataGridView    gridOrganisations = null!;
    private Panel           pnlDirectives     = null!;
    private Label           lblDirectives     = null!;
    private DataGridView    gridDirectives    = null!;
}
