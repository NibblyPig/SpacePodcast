namespace PodcastUniverseEditor.UI.Controls;

partial class ucThreads
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
        split          = new SplitContainer();
        pnlThreads     = new Panel();
        lblThreads     = new Label();
        gridThreads    = new DataGridView();
        pnlBeats       = new Panel();
        lblBeats       = new Label();
        gridThreadBeats = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlThreads.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridThreads).BeginInit();
        pnlBeats.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridThreadBeats).BeginInit();
        SuspendLayout();

        // ── split ─────────────────────────────────────────────────────────────────────────────
        split.Dock        = DockStyle.Fill;
        split.Location    = new Point(0, 0);
        split.Name        = "split";
        split.Orientation = Orientation.Horizontal;
        split.Size        = new Size(858, 600);
        split.TabIndex    = 0;

        // ── pnlThreads ────────────────────────────────────────────────────────────────────────
        // Add Fill first, then Top — last added (Top) is processed first and appears at top
        pnlThreads.Controls.Add(gridThreads);
        pnlThreads.Controls.Add(lblThreads);
        pnlThreads.Dock     = DockStyle.Fill;
        pnlThreads.Location = new Point(0, 0);
        pnlThreads.Name     = "pnlThreads";
        pnlThreads.Size     = new Size(858, 297);
        pnlThreads.TabIndex = 0;

        // ── lblThreads ────────────────────────────────────────────────────────────────────────
        lblThreads.Dock     = DockStyle.Top;
        lblThreads.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblThreads.Height   = 20;
        lblThreads.Location = new Point(0, 0);
        lblThreads.Name     = "lblThreads";
        lblThreads.Size     = new Size(858, 20);
        lblThreads.TabIndex = 0;
        lblThreads.Text     = "Story Threads";

        // ── gridThreads ───────────────────────────────────────────────────────────────────────
        gridThreads.AllowUserToAddRows          = false;
        gridThreads.AutoGenerateColumns         = true;
        gridThreads.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridThreads.Dock                        = DockStyle.Fill;
        gridThreads.Location                    = new Point(0, 20);
        gridThreads.MultiSelect                 = false;
        gridThreads.Name                        = "gridThreads";
        gridThreads.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridThreads.Size                        = new Size(858, 277);
        gridThreads.TabIndex                    = 1;

        // ── pnlBeats ──────────────────────────────────────────────────────────────────────────
        // Same stacking rule: grid first (Fill), label last (Top) → label appears at top
        pnlBeats.Controls.Add(gridThreadBeats);
        pnlBeats.Controls.Add(lblBeats);
        pnlBeats.Dock     = DockStyle.Fill;
        pnlBeats.Location = new Point(0, 0);
        pnlBeats.Name     = "pnlBeats";
        pnlBeats.Size     = new Size(858, 297);
        pnlBeats.TabIndex = 0;

        // ── lblBeats ──────────────────────────────────────────────────────────────────────────
        lblBeats.Dock     = DockStyle.Top;
        lblBeats.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblBeats.Height   = 20;
        lblBeats.Location = new Point(0, 0);
        lblBeats.Name     = "lblBeats";
        lblBeats.Size     = new Size(858, 20);
        lblBeats.TabIndex = 0;
        lblBeats.Text     = "Beats";

        // ── gridThreadBeats ───────────────────────────────────────────────────────────────────
        gridThreadBeats.AllowUserToAddRows          = false;
        gridThreadBeats.AutoGenerateColumns         = true;
        gridThreadBeats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridThreadBeats.Dock                        = DockStyle.Fill;
        gridThreadBeats.Location                    = new Point(0, 20);
        gridThreadBeats.MultiSelect                 = false;
        gridThreadBeats.Name                        = "gridThreadBeats";
        gridThreadBeats.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridThreadBeats.Size                        = new Size(858, 277);
        gridThreadBeats.TabIndex                    = 1;

        // ── split.Panel1 — Story Threads ──────────────────────────────────────────────────────
        split.Panel1.Controls.Add(pnlThreads);

        // ── split.Panel2 — Beats ─────────────────────────────────────────────────────────────
        split.Panel2.Controls.Add(pnlBeats);

        // ── ucThreads ─────────────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(split);
        Name = "ucThreads";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        split.ResumeLayout(false);
        pnlThreads.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridThreads).EndInit();
        pnlBeats.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridThreadBeats).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split           = null!;
    private Panel           pnlThreads      = null!;
    private Label           lblThreads      = null!;
    private DataGridView    gridThreads     = null!;
    private Panel           pnlBeats        = null!;
    private Label           lblBeats        = null!;
    private DataGridView    gridThreadBeats = null!;
}
