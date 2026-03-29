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
        gridRoutes = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)gridRoutes).BeginInit();
        SuspendLayout();

        // ── gridRoutes ────────────────────────────────────────────────────────────────────────
        gridRoutes.AllowUserToAddRows          = false;
        gridRoutes.AutoGenerateColumns         = true;
        gridRoutes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridRoutes.Dock                        = DockStyle.Fill;
        gridRoutes.Location                    = new Point(0, 0);
        gridRoutes.MultiSelect                 = false;
        gridRoutes.Name                        = "gridRoutes";
        gridRoutes.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridRoutes.Size                        = new Size(858, 600);
        gridRoutes.TabIndex                    = 0;

        // ── ucRoutes ──────────────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(gridRoutes);
        Name = "ucRoutes";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)gridRoutes).EndInit();
        ResumeLayout(false);
    }

    private DataGridView gridRoutes = null!;
}
