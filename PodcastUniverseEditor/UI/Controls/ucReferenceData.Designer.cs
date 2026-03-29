namespace PodcastUniverseEditor.UI.Controls;

partial class ucReferenceData
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
        split = new SplitContainer();
        lstReferenceTypes = new ListBox();
        pnlRight = new Panel();
        gridReferenceItems = new DataGridView();
        pnlButtons = new Panel();
        btnReferenceDelete = new Button();
        btnReferenceAdd = new Button();
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlRight.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridReferenceItems).BeginInit();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        // 
        // split
        // 
        split.Dock = DockStyle.Fill;
        split.Location = new Point(0, 0);
        split.Name = "split";
        // 
        // split.Panel1
        // 
        split.Panel1.Controls.Add(lstReferenceTypes);
        split.Panel1MinSize = 150;
        // 
        // split.Panel2
        // 
        split.Panel2.Controls.Add(pnlRight);
        split.Size = new Size(900, 600);
        split.SplitterDistance = 220;
        split.TabIndex = 0;
        // 
        // lstReferenceTypes
        // 
        lstReferenceTypes.Dock = DockStyle.Fill;
        lstReferenceTypes.IntegralHeight = false;
        lstReferenceTypes.ItemHeight = 25;
        lstReferenceTypes.Location = new Point(0, 0);
        lstReferenceTypes.Name = "lstReferenceTypes";
        lstReferenceTypes.Size = new Size(220, 600);
        lstReferenceTypes.TabIndex = 0;
        // 
        // pnlRight
        // 
        pnlRight.Controls.Add(gridReferenceItems);
        pnlRight.Controls.Add(pnlButtons);
        pnlRight.Dock = DockStyle.Fill;
        pnlRight.Location = new Point(0, 0);
        pnlRight.Name = "pnlRight";
        pnlRight.Size = new Size(676, 600);
        pnlRight.TabIndex = 0;
        // 
        // gridReferenceItems
        // 
        gridReferenceItems.AllowUserToAddRows = false;
        gridReferenceItems.BackgroundColor = SystemColors.ActiveCaption;
        gridReferenceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridReferenceItems.Dock = DockStyle.Fill;
        gridReferenceItems.Location = new Point(0, 0);
        gridReferenceItems.MultiSelect = false;
        gridReferenceItems.Name = "gridReferenceItems";
        gridReferenceItems.RowHeadersWidth = 62;
        gridReferenceItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridReferenceItems.Size = new Size(676, 564);
        gridReferenceItems.TabIndex = 0;
        // 
        // pnlButtons
        // 
        pnlButtons.Controls.Add(btnReferenceDelete);
        pnlButtons.Controls.Add(btnReferenceAdd);
        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Location = new Point(0, 564);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Padding = new Padding(4);
        pnlButtons.Size = new Size(676, 36);
        pnlButtons.TabIndex = 1;
        // 
        // btnReferenceDelete
        // 
        btnReferenceDelete.Dock = DockStyle.Left;
        btnReferenceDelete.Location = new Point(74, 4);
        btnReferenceDelete.Name = "btnReferenceDelete";
        btnReferenceDelete.Size = new Size(70, 28);
        btnReferenceDelete.TabIndex = 0;
        btnReferenceDelete.Text = "Delete";
        btnReferenceDelete.UseVisualStyleBackColor = true;
        // 
        // btnReferenceAdd
        // 
        btnReferenceAdd.Dock = DockStyle.Left;
        btnReferenceAdd.Location = new Point(4, 4);
        btnReferenceAdd.Name = "btnReferenceAdd";
        btnReferenceAdd.Size = new Size(70, 28);
        btnReferenceAdd.TabIndex = 1;
        btnReferenceAdd.Text = "Add";
        btnReferenceAdd.UseVisualStyleBackColor = true;
        // 
        // ucReferenceData
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(split);
        Name = "ucReferenceData";
        Size = new Size(900, 600);
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.ResumeLayout(false);
        pnlRight.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridReferenceItems).EndInit();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private SplitContainer  split              = null!;
    private ListBox         lstReferenceTypes  = null!;
    private Panel           pnlRight           = null!;
    private DataGridView    gridReferenceItems = null!;
    private Panel           pnlButtons         = null!;
    private Button          btnReferenceAdd    = null!;
    private Button          btnReferenceDelete = null!;
}
