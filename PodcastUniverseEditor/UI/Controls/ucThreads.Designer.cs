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
        split             = new SplitContainer();
        pnlThreads        = new Panel();
        lblThreads        = new Label();
        pnlThreadsButtons = new Panel();
        btnThreadAdd      = new Button();
        btnThreadDelete   = new Button();
        gridThreads       = new DataGridView();
        pnlBeats          = new Panel();
        lblBeats          = new Label();
        pnlBeatsButtons   = new Panel();
        btnBeatAdd        = new Button();
        btnBeatDelete     = new Button();
        gridThreadBeats   = new DataGridView();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlThreads.SuspendLayout();
        pnlThreadsButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridThreads).BeginInit();
        pnlBeats.SuspendLayout();
        pnlBeatsButtons.SuspendLayout();
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
        // Fill added before Bottom so docking resolves correctly; Top label last
        pnlThreads.Controls.Add(gridThreads);
        pnlThreads.Controls.Add(pnlThreadsButtons);
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

        // ── pnlThreadsButtons ─────────────────────────────────────────────────────────────────
        pnlThreadsButtons.Controls.Add(btnThreadDelete);
        pnlThreadsButtons.Controls.Add(btnThreadAdd);
        pnlThreadsButtons.Dock     = DockStyle.Bottom;
        pnlThreadsButtons.Name     = "pnlThreadsButtons";
        pnlThreadsButtons.Padding  = new Padding(2);
        pnlThreadsButtons.Size     = new Size(858, 32);
        pnlThreadsButtons.TabIndex = 1;

        // ── btnThreadAdd ──────────────────────────────────────────────────────────────────────
        btnThreadAdd.Dock                   = DockStyle.Left;
        btnThreadAdd.Location               = new Point(2, 2);
        btnThreadAdd.Name                   = "btnThreadAdd";
        btnThreadAdd.Size                   = new Size(80, 28);
        btnThreadAdd.TabIndex               = 1;
        btnThreadAdd.Text                   = "Add";
        btnThreadAdd.UseVisualStyleBackColor = true;

        // ── btnThreadDelete ───────────────────────────────────────────────────────────────────
        btnThreadDelete.Dock                   = DockStyle.Left;
        btnThreadDelete.Location               = new Point(82, 2);
        btnThreadDelete.Name                   = "btnThreadDelete";
        btnThreadDelete.Size                   = new Size(80, 28);
        btnThreadDelete.TabIndex               = 0;
        btnThreadDelete.Text                   = "Delete";
        btnThreadDelete.UseVisualStyleBackColor = true;

        // ── gridThreads ───────────────────────────────────────────────────────────────────────
        gridThreads.AllowUserToAddRows          = false;
        gridThreads.AutoGenerateColumns         = true;
        gridThreads.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridThreads.Dock                        = DockStyle.Fill;
        gridThreads.Location                    = new Point(0, 20);
        gridThreads.MultiSelect                 = false;
        gridThreads.Name                        = "gridThreads";
        gridThreads.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridThreads.Size                        = new Size(858, 245);
        gridThreads.TabIndex                    = 1;

        // ── pnlBeats ──────────────────────────────────────────────────────────────────────────
        // Fill added before Bottom so docking resolves correctly; Top label last
        pnlBeats.Controls.Add(gridThreadBeats);
        pnlBeats.Controls.Add(pnlBeatsButtons);
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

        // ── pnlBeatsButtons ───────────────────────────────────────────────────────────────────
        pnlBeatsButtons.Controls.Add(btnBeatDelete);
        pnlBeatsButtons.Controls.Add(btnBeatAdd);
        pnlBeatsButtons.Dock     = DockStyle.Bottom;
        pnlBeatsButtons.Name     = "pnlBeatsButtons";
        pnlBeatsButtons.Padding  = new Padding(2);
        pnlBeatsButtons.Size     = new Size(858, 32);
        pnlBeatsButtons.TabIndex = 1;

        // ── btnBeatAdd ────────────────────────────────────────────────────────────────────────
        btnBeatAdd.Dock                   = DockStyle.Left;
        btnBeatAdd.Location               = new Point(2, 2);
        btnBeatAdd.Name                   = "btnBeatAdd";
        btnBeatAdd.Size                   = new Size(80, 28);
        btnBeatAdd.TabIndex               = 1;
        btnBeatAdd.Text                   = "Add";
        btnBeatAdd.UseVisualStyleBackColor = true;

        // ── btnBeatDelete ─────────────────────────────────────────────────────────────────────
        btnBeatDelete.Dock                   = DockStyle.Left;
        btnBeatDelete.Location               = new Point(82, 2);
        btnBeatDelete.Name                   = "btnBeatDelete";
        btnBeatDelete.Size                   = new Size(80, 28);
        btnBeatDelete.TabIndex               = 0;
        btnBeatDelete.Text                   = "Delete";
        btnBeatDelete.UseVisualStyleBackColor = true;

        // ── gridThreadBeats ───────────────────────────────────────────────────────────────────
        gridThreadBeats.AllowUserToAddRows          = false;
        gridThreadBeats.AutoGenerateColumns         = true;
        gridThreadBeats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridThreadBeats.Dock                        = DockStyle.Fill;
        gridThreadBeats.Location                    = new Point(0, 20);
        gridThreadBeats.MultiSelect                 = false;
        gridThreadBeats.Name                        = "gridThreadBeats";
        gridThreadBeats.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridThreadBeats.Size                        = new Size(858, 245);
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
        pnlThreadsButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridThreads).EndInit();
        pnlBeats.ResumeLayout(false);
        pnlBeatsButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridThreadBeats).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split             = null!;
    private Panel           pnlThreads        = null!;
    private Label           lblThreads        = null!;
    private Panel           pnlThreadsButtons = null!;
    private Button          btnThreadAdd      = null!;
    private Button          btnThreadDelete   = null!;
    private DataGridView    gridThreads       = null!;
    private Panel           pnlBeats          = null!;
    private Label           lblBeats          = null!;
    private Panel           pnlBeatsButtons   = null!;
    private Button          btnBeatAdd        = null!;
    private Button          btnBeatDelete     = null!;
    private DataGridView    gridThreadBeats   = null!;
}
