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
        pnlOrgs              = new Panel();
        lblOrganisations     = new Label();
        pnlOrgsButtons       = new Panel();
        btnOrganisationsAdd  = new Button();
        btnOrganisationsDelete = new Button();
        gridOrganisations    = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        pnlOrgs.SuspendLayout();
        pnlOrgsButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridOrganisations).BeginInit();
        SuspendLayout();

        // ── pnlOrgs ───────────────────────────────────────────────────────────────────────────
        // Controls added Fill-first so Top/Bottom items dock correctly
        pnlOrgs.Controls.Add(gridOrganisations);
        pnlOrgs.Controls.Add(pnlOrgsButtons);
        pnlOrgs.Controls.Add(lblOrganisations);
        pnlOrgs.Dock     = DockStyle.Fill;
        pnlOrgs.Location = new Point(0, 0);
        pnlOrgs.Name     = "pnlOrgs";
        pnlOrgs.Size     = new Size(858, 600);
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
        pnlOrgsButtons.Location = new Point(0, 568);
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
        gridOrganisations.Location                    = new Point(0, 20);
        gridOrganisations.MultiSelect                 = false;
        gridOrganisations.Name                        = "gridOrganisations";
        gridOrganisations.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridOrganisations.Size                        = new Size(858, 548);
        gridOrganisations.TabIndex                    = 2;

        // ── ucOrganisationsDirectives ─────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(pnlOrgs);
        Name = "ucOrganisationsDirectives";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        pnlOrgs.ResumeLayout(false);
        pnlOrgsButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridOrganisations).EndInit();
        ResumeLayout(false);
    }

    private Panel        pnlOrgs              = null!;
    private Label        lblOrganisations     = null!;
    private Panel        pnlOrgsButtons       = null!;
    private Button       btnOrganisationsAdd  = null!;
    private Button       btnOrganisationsDelete = null!;
    private DataGridView gridOrganisations    = null!;
}
