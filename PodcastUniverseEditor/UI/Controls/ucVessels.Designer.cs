namespace PodcastUniverseEditor.UI.Controls;

partial class ucVessels
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
        pnlVessels        = new Panel();
        lblVessels        = new Label();
        pnlVesselsButtons = new Panel();
        btnVesselAdd      = new Button();
        btnVesselDelete   = new Button();
        gridVessels       = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        pnlVessels.SuspendLayout();
        pnlVesselsButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridVessels).BeginInit();
        SuspendLayout();

        // ── pnlVessels ────────────────────────────────────────────────────────────────────────
        // Fill added before Bottom so docking resolves correctly; Top label last
        pnlVessels.Controls.Add(gridVessels);
        pnlVessels.Controls.Add(pnlVesselsButtons);
        pnlVessels.Controls.Add(lblVessels);
        pnlVessels.Dock     = DockStyle.Fill;
        pnlVessels.Location = new Point(0, 0);
        pnlVessels.Name     = "pnlVessels";
        pnlVessels.Size     = new Size(858, 600);
        pnlVessels.TabIndex = 0;

        // ── lblVessels ────────────────────────────────────────────────────────────────────────
        lblVessels.Dock     = DockStyle.Top;
        lblVessels.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblVessels.Height   = 20;
        lblVessels.Location = new Point(0, 0);
        lblVessels.Name     = "lblVessels";
        lblVessels.Size     = new Size(858, 20);
        lblVessels.TabIndex = 0;
        lblVessels.Text     = "Vessels";

        // ── pnlVesselsButtons ─────────────────────────────────────────────────────────────────
        pnlVesselsButtons.Controls.Add(btnVesselDelete);
        pnlVesselsButtons.Controls.Add(btnVesselAdd);
        pnlVesselsButtons.Dock     = DockStyle.Bottom;
        pnlVesselsButtons.Name     = "pnlVesselsButtons";
        pnlVesselsButtons.Padding  = new Padding(2);
        pnlVesselsButtons.Size     = new Size(858, 32);
        pnlVesselsButtons.TabIndex = 1;

        // ── btnVesselAdd ──────────────────────────────────────────────────────────────────────
        btnVesselAdd.Dock                   = DockStyle.Left;
        btnVesselAdd.Location               = new Point(2, 2);
        btnVesselAdd.Name                   = "btnVesselAdd";
        btnVesselAdd.Size                   = new Size(80, 28);
        btnVesselAdd.TabIndex               = 1;
        btnVesselAdd.Text                   = "Add";
        btnVesselAdd.UseVisualStyleBackColor = true;

        // ── btnVesselDelete ───────────────────────────────────────────────────────────────────
        btnVesselDelete.Dock                   = DockStyle.Left;
        btnVesselDelete.Location               = new Point(82, 2);
        btnVesselDelete.Name                   = "btnVesselDelete";
        btnVesselDelete.Size                   = new Size(80, 28);
        btnVesselDelete.TabIndex               = 0;
        btnVesselDelete.Text                   = "Delete";
        btnVesselDelete.UseVisualStyleBackColor = true;

        // ── gridVessels ───────────────────────────────────────────────────────────────────────
        gridVessels.AllowUserToAddRows          = false;
        gridVessels.AutoGenerateColumns         = true;
        gridVessels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridVessels.Dock                        = DockStyle.Fill;
        gridVessels.Location                    = new Point(0, 20);
        gridVessels.MultiSelect                 = false;
        gridVessels.Name                        = "gridVessels";
        gridVessels.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridVessels.Size                        = new Size(858, 548);
        gridVessels.TabIndex                    = 2;

        // ── ucVessels ─────────────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(pnlVessels);
        Name = "ucVessels";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        pnlVessels.ResumeLayout(false);
        pnlVesselsButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridVessels).EndInit();
        ResumeLayout(false);
    }

    private Panel        pnlVessels        = null!;
    private Label        lblVessels        = null!;
    private Panel        pnlVesselsButtons = null!;
    private Button       btnVesselAdd      = null!;
    private Button       btnVesselDelete   = null!;
    private DataGridView gridVessels       = null!;
}
