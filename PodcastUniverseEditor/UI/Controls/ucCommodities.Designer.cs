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
        gridCommodities = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)gridCommodities).BeginInit();
        SuspendLayout();

        // ── gridCommodities ───────────────────────────────────────────────────────────────────
        gridCommodities.AllowUserToAddRows          = false;
        gridCommodities.AutoGenerateColumns         = true;
        gridCommodities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridCommodities.Dock                        = DockStyle.Fill;
        gridCommodities.Location                    = new Point(0, 0);
        gridCommodities.MultiSelect                 = false;
        gridCommodities.Name                        = "gridCommodities";
        gridCommodities.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridCommodities.Size                        = new Size(858, 600);
        gridCommodities.TabIndex                    = 0;

        // ── ucCommodities ─────────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(gridCommodities);
        Name = "ucCommodities";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)gridCommodities).EndInit();
        ResumeLayout(false);
    }

    private DataGridView gridCommodities = null!;
}
