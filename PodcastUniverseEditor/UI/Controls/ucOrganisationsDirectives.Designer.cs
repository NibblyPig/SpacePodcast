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
        split                    = new SplitContainer();
        pnlOrgs                  = new Panel();
        lblOrganisations         = new Label();
        pnlOrgsButtons           = new Panel();
        btnOrganisationsAdd      = new Button();
        btnOrganisationsDelete   = new Button();
        gridOrganisations        = new DataGridView();
        pnlDirectives            = new Panel();
        lblDirectives            = new Label();
        pnlDirectivesButtons     = new Panel();
        btnDirectivesAdd         = new Button();
        btnDirectivesDelete      = new Button();
        gridDirectives           = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlOrgs.SuspendLayout();
        pnlOrgsButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridOrganisations).BeginInit();
        pnlDirectives.SuspendLayout();
        pnlDirectivesButtons.SuspendLayout();
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
        // Controls added Fill-first so Top items stack at the top
        pnlOrgs.Controls.Add(gridOrganisations);
        pnlOrgs.Controls.Add(pnlOrgsButtons);
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

        // ── pnlOrgsButtons ────────────────────────────────────────────────────────────────────
        pnlOrgsButtons.Controls.Add(btnOrganisationsDelete);
        pnlOrgsButtons.Controls.Add(btnOrganisationsAdd);
        pnlOrgsButtons.Dock     = DockStyle.Bottom;
        pnlOrgsButtons.Location = new Point(0, 20);
        pnlOrgsButtons.Name     = "pnlOrgsButtons";
        pnlOrgsButtons.Padding  = new Padding(2);
        pnlOrgsButtons.Size     = new Size(858, 32);
        pnlOrgsButtons.TabIndex = 1;

        // ── btnOrganisationsAdd ───────────────────────────────────────────────────────────────
        btnOrganisationsAdd.Dock                  = DockStyle.Left;
        btnOrganisationsAdd.Location              = new Point(2, 2);
        btnOrganisationsAdd.Name                  = "btnOrganisationsAdd";
        btnOrganisationsAdd.Size                  = new Size(80, 28);
        btnOrganisationsAdd.TabIndex              = 1;
        btnOrganisationsAdd.Text                  = "Add";
        btnOrganisationsAdd.UseVisualStyleBackColor = true;

        // ── btnOrganisationsDelete ────────────────────────────────────────────────────────────
        btnOrganisationsDelete.Dock                  = DockStyle.Left;
        btnOrganisationsDelete.Location              = new Point(82, 2);
        btnOrganisationsDelete.Name                  = "btnOrganisationsDelete";
        btnOrganisationsDelete.Size                  = new Size(80, 28);
        btnOrganisationsDelete.TabIndex              = 0;
        btnOrganisationsDelete.Text                  = "Delete";
        btnOrganisationsDelete.UseVisualStyleBackColor = true;

        // ── gridOrganisations ─────────────────────────────────────────────────────────────────
        gridOrganisations.AllowUserToAddRows          = false;
        gridOrganisations.AutoGenerateColumns         = true;
        gridOrganisations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridOrganisations.Dock                        = DockStyle.Fill;
        gridOrganisations.Location                    = new Point(0, 52);
        gridOrganisations.MultiSelect                 = false;
        gridOrganisations.Name                        = "gridOrganisations";
        gridOrganisations.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridOrganisations.Size                        = new Size(858, 245);
        gridOrganisations.TabIndex                    = 2;

        // ── pnlDirectives ─────────────────────────────────────────────────────────────────────
        // Controls added Fill-first so Top items stack at the top
        pnlDirectives.Controls.Add(gridDirectives);
        pnlDirectives.Controls.Add(pnlDirectivesButtons);
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

        // ── pnlDirectivesButtons ──────────────────────────────────────────────────────────────
        pnlDirectivesButtons.Controls.Add(btnDirectivesDelete);
        pnlDirectivesButtons.Controls.Add(btnDirectivesAdd);
        pnlDirectivesButtons.Dock     = DockStyle.Bottom;
        pnlDirectivesButtons.Location = new Point(0, 20);
        pnlDirectivesButtons.Name     = "pnlDirectivesButtons";
        pnlDirectivesButtons.Padding  = new Padding(2);
        pnlDirectivesButtons.Size     = new Size(858, 32);
        pnlDirectivesButtons.TabIndex = 1;

        // ── btnDirectivesAdd ──────────────────────────────────────────────────────────────────
        btnDirectivesAdd.Dock                  = DockStyle.Left;
        btnDirectivesAdd.Location              = new Point(2, 2);
        btnDirectivesAdd.Name                  = "btnDirectivesAdd";
        btnDirectivesAdd.Size                  = new Size(80, 28);
        btnDirectivesAdd.TabIndex              = 1;
        btnDirectivesAdd.Text                  = "Add";
        btnDirectivesAdd.UseVisualStyleBackColor = true;

        // ── btnDirectivesDelete ───────────────────────────────────────────────────────────────
        btnDirectivesDelete.Dock                  = DockStyle.Left;
        btnDirectivesDelete.Location              = new Point(82, 2);
        btnDirectivesDelete.Name                  = "btnDirectivesDelete";
        btnDirectivesDelete.Size                  = new Size(80, 28);
        btnDirectivesDelete.TabIndex              = 0;
        btnDirectivesDelete.Text                  = "Delete";
        btnDirectivesDelete.UseVisualStyleBackColor = true;

        // ── gridDirectives ────────────────────────────────────────────────────────────────────
        gridDirectives.AllowUserToAddRows          = false;
        gridDirectives.AutoGenerateColumns         = true;
        gridDirectives.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridDirectives.Dock                        = DockStyle.Fill;
        gridDirectives.Location                    = new Point(0, 52);
        gridDirectives.MultiSelect                 = false;
        gridDirectives.Name                        = "gridDirectives";
        gridDirectives.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridDirectives.Size                        = new Size(858, 245);
        gridDirectives.TabIndex                    = 2;

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
        pnlOrgsButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridOrganisations).EndInit();
        pnlDirectives.ResumeLayout(false);
        pnlDirectivesButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDirectives).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split                  = null!;
    private Panel           pnlOrgs                = null!;
    private Label           lblOrganisations        = null!;
    private Panel           pnlOrgsButtons          = null!;
    private Button          btnOrganisationsAdd     = null!;
    private Button          btnOrganisationsDelete  = null!;
    private DataGridView    gridOrganisations       = null!;
    private Panel           pnlDirectives           = null!;
    private Label           lblDirectives           = null!;
    private Panel           pnlDirectivesButtons    = null!;
    private Button          btnDirectivesAdd        = null!;
    private Button          btnDirectivesDelete     = null!;
    private DataGridView    gridDirectives          = null!;
}
