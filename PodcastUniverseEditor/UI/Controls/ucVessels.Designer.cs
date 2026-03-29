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
        gridVessels = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)gridVessels).BeginInit();
        SuspendLayout();

        // ── gridVessels ───────────────────────────────────────────────────────────────────────
        gridVessels.AllowUserToAddRows          = false;
        gridVessels.AutoGenerateColumns         = true;
        gridVessels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridVessels.Dock                        = DockStyle.Fill;
        gridVessels.Location                    = new Point(0, 0);
        gridVessels.MultiSelect                 = false;
        gridVessels.Name                        = "gridVessels";
        gridVessels.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridVessels.Size                        = new Size(858, 600);
        gridVessels.TabIndex                    = 0;

        // ── ucVessels ─────────────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(gridVessels);
        Name = "ucVessels";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)gridVessels).EndInit();
        ResumeLayout(false);
    }

    private DataGridView gridVessels = null!;
}
