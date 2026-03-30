namespace PodcastUniverseEditor.UI.Controls;

partial class ucSystemsBodies
{
    private System.ComponentModel.IContainer components = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        splitSystemsBodies = new SplitContainer();

        pnlStarSystemsSection = new Panel();
        lblStarSystems = new Label();
        pnlStarSystemsActions = new Panel();
        btnSystemDelete = new Button();
        btnSystemAdd = new Button();
        gridStarSystems = new DataGridView();

        pnlCelestialBodiesSection = new Panel();
        lblCelestialBodies = new Label();
        pnlCelestialBodiesActions = new Panel();
        btnBodyDelete = new Button();
        btnBodyAdd = new Button();
        gridCelestialBodies = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)splitSystemsBodies).BeginInit();
        splitSystemsBodies.Panel1.SuspendLayout();
        splitSystemsBodies.Panel2.SuspendLayout();
        splitSystemsBodies.SuspendLayout();

        pnlStarSystemsSection.SuspendLayout();
        pnlStarSystemsActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridStarSystems).BeginInit();

        pnlCelestialBodiesSection.SuspendLayout();
        pnlCelestialBodiesActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridCelestialBodies).BeginInit();

        SuspendLayout();

        // splitSystemsBodies
        splitSystemsBodies.Dock = DockStyle.Fill;
        splitSystemsBodies.Location = new Point(0, 0);
        splitSystemsBodies.Name = "splitSystemsBodies";
        splitSystemsBodies.Orientation = Orientation.Horizontal;
        splitSystemsBodies.Size = new Size(858, 600);
        splitSystemsBodies.SplitterDistance = 297;
        splitSystemsBodies.TabIndex = 0;

        // splitSystemsBodies.Panel1
        splitSystemsBodies.Panel1.Controls.Add(pnlStarSystemsSection);

        // splitSystemsBodies.Panel2
        splitSystemsBodies.Panel2.Controls.Add(pnlCelestialBodiesSection);

        // pnlStarSystemsSection
        pnlStarSystemsSection.Controls.Add(gridStarSystems);
        pnlStarSystemsSection.Controls.Add(pnlStarSystemsActions);
        pnlStarSystemsSection.Controls.Add(lblStarSystems);
        pnlStarSystemsSection.Dock = DockStyle.Fill;
        pnlStarSystemsSection.Location = new Point(0, 0);
        pnlStarSystemsSection.Name = "pnlStarSystemsSection";
        pnlStarSystemsSection.Size = new Size(858, 297);
        pnlStarSystemsSection.TabIndex = 0;

        // lblStarSystems
        lblStarSystems.Dock = DockStyle.Top;
        lblStarSystems.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblStarSystems.Location = new Point(0, 0);
        lblStarSystems.Name = "lblStarSystems";
        lblStarSystems.Padding = new Padding(6, 6, 0, 0);
        lblStarSystems.Size = new Size(858, 28);
        lblStarSystems.TabIndex = 0;
        lblStarSystems.Text = "Star Systems";

        // pnlStarSystemsActions
        pnlStarSystemsActions.Controls.Add(btnSystemDelete);
        pnlStarSystemsActions.Controls.Add(btnSystemAdd);
        pnlStarSystemsActions.Dock = DockStyle.Bottom;
        pnlStarSystemsActions.Location = new Point(0, 261);
        pnlStarSystemsActions.Name = "pnlStarSystemsActions";
        pnlStarSystemsActions.Padding = new Padding(6, 4, 6, 6);
        pnlStarSystemsActions.Size = new Size(858, 36);
        pnlStarSystemsActions.TabIndex = 2;

        // btnSystemAdd
        btnSystemAdd.Location = new Point(6, 6);
        btnSystemAdd.Name = "btnSystemAdd";
        btnSystemAdd.Size = new Size(75, 24);
        btnSystemAdd.TabIndex = 0;
        btnSystemAdd.Text = "Add";
        btnSystemAdd.UseVisualStyleBackColor = true;

        // btnSystemDelete
        btnSystemDelete.Location = new Point(87, 6);
        btnSystemDelete.Name = "btnSystemDelete";
        btnSystemDelete.Size = new Size(75, 24);
        btnSystemDelete.TabIndex = 1;
        btnSystemDelete.Text = "Delete";
        btnSystemDelete.UseVisualStyleBackColor = true;

        // gridStarSystems
        gridStarSystems.AllowUserToAddRows = false;
        gridStarSystems.AutoGenerateColumns = true;
        gridStarSystems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridStarSystems.Dock = DockStyle.Fill;
        gridStarSystems.Location = new Point(0, 28);
        gridStarSystems.MultiSelect = false;
        gridStarSystems.Name = "gridStarSystems";
        gridStarSystems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridStarSystems.Size = new Size(858, 233);
        gridStarSystems.TabIndex = 1;

        // pnlCelestialBodiesSection
        pnlCelestialBodiesSection.Controls.Add(gridCelestialBodies);
        pnlCelestialBodiesSection.Controls.Add(pnlCelestialBodiesActions);
        pnlCelestialBodiesSection.Controls.Add(lblCelestialBodies);
        pnlCelestialBodiesSection.Dock = DockStyle.Fill;
        pnlCelestialBodiesSection.Location = new Point(0, 0);
        pnlCelestialBodiesSection.Name = "pnlCelestialBodiesSection";
        pnlCelestialBodiesSection.Size = new Size(858, 299);
        pnlCelestialBodiesSection.TabIndex = 0;

        // lblCelestialBodies
        lblCelestialBodies.Dock = DockStyle.Top;
        lblCelestialBodies.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCelestialBodies.Location = new Point(0, 0);
        lblCelestialBodies.Name = "lblCelestialBodies";
        lblCelestialBodies.Padding = new Padding(6, 6, 0, 0);
        lblCelestialBodies.Size = new Size(858, 28);
        lblCelestialBodies.TabIndex = 0;
        lblCelestialBodies.Text = "Celestial Bodies";

        // pnlCelestialBodiesActions
        pnlCelestialBodiesActions.Controls.Add(btnBodyDelete);
        pnlCelestialBodiesActions.Controls.Add(btnBodyAdd);
        pnlCelestialBodiesActions.Dock = DockStyle.Bottom;
        pnlCelestialBodiesActions.Location = new Point(0, 263);
        pnlCelestialBodiesActions.Name = "pnlCelestialBodiesActions";
        pnlCelestialBodiesActions.Padding = new Padding(6, 4, 6, 6);
        pnlCelestialBodiesActions.Size = new Size(858, 36);
        pnlCelestialBodiesActions.TabIndex = 2;

        // btnBodyAdd
        btnBodyAdd.Location = new Point(6, 6);
        btnBodyAdd.Name = "btnBodyAdd";
        btnBodyAdd.Size = new Size(75, 24);
        btnBodyAdd.TabIndex = 0;
        btnBodyAdd.Text = "Add";
        btnBodyAdd.UseVisualStyleBackColor = true;

        // btnBodyDelete
        btnBodyDelete.Location = new Point(87, 6);
        btnBodyDelete.Name = "btnBodyDelete";
        btnBodyDelete.Size = new Size(75, 24);
        btnBodyDelete.TabIndex = 1;
        btnBodyDelete.Text = "Delete";
        btnBodyDelete.UseVisualStyleBackColor = true;

        // gridCelestialBodies
        gridCelestialBodies.AllowUserToAddRows = false;
        gridCelestialBodies.AutoGenerateColumns = true;
        gridCelestialBodies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridCelestialBodies.Dock = DockStyle.Fill;
        gridCelestialBodies.Location = new Point(0, 28);
        gridCelestialBodies.MultiSelect = false;
        gridCelestialBodies.Name = "gridCelestialBodies";
        gridCelestialBodies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridCelestialBodies.Size = new Size(858, 235);
        gridCelestialBodies.TabIndex = 1;

        // ucSystemsBodies
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(splitSystemsBodies);
        Name = "ucSystemsBodies";
        Size = new Size(858, 600);

        splitSystemsBodies.Panel1.ResumeLayout(false);
        splitSystemsBodies.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitSystemsBodies).EndInit();
        splitSystemsBodies.ResumeLayout(false);

        pnlStarSystemsSection.ResumeLayout(false);
        pnlStarSystemsActions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridStarSystems).EndInit();

        pnlCelestialBodiesSection.ResumeLayout(false);
        pnlCelestialBodiesActions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridCelestialBodies).EndInit();

        ResumeLayout(false);
    }

    private SplitContainer splitSystemsBodies = null!;

    private Panel pnlStarSystemsSection = null!;
    private Label lblStarSystems = null!;
    private Panel pnlStarSystemsActions = null!;
    private Button btnSystemAdd = null!;
    private Button btnSystemDelete = null!;
    private DataGridView gridStarSystems = null!;

    private Panel pnlCelestialBodiesSection = null!;
    private Label lblCelestialBodies = null!;
    private Panel pnlCelestialBodiesActions = null!;
    private Button btnBodyAdd = null!;
    private Button btnBodyDelete = null!;
    private DataGridView gridCelestialBodies = null!;
}