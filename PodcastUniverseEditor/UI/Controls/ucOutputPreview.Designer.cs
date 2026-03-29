namespace PodcastUniverseEditor.UI.Controls;

partial class ucOutputPreview
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
        txtRenderedOutput = new TextBox();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        SuspendLayout();

        // ── txtRenderedOutput ─────────────────────────────────────────────────────────────────
        txtRenderedOutput.Dock        = DockStyle.Fill;
        txtRenderedOutput.Font        = new Font("Consolas", 10f);
        txtRenderedOutput.Location    = new Point(0, 0);
        txtRenderedOutput.Multiline   = true;
        txtRenderedOutput.Name        = "txtRenderedOutput";
        txtRenderedOutput.ReadOnly    = true;
        txtRenderedOutput.ScrollBars  = ScrollBars.Vertical;
        txtRenderedOutput.Size        = new Size(858, 600);
        txtRenderedOutput.TabIndex    = 0;

        // ── ucOutputPreview ───────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(txtRenderedOutput);
        Name = "ucOutputPreview";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ResumeLayout(false);
        PerformLayout();
    }

    private TextBox txtRenderedOutput = null!;
}
