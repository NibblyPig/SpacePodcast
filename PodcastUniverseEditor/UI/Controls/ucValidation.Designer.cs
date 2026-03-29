namespace PodcastUniverseEditor.UI.Controls;

partial class ucValidation
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
        pnlContent             = new Panel();
        pnlTopBar              = new Panel();
        btnRunValidation       = new Button();
        gridValidationMessages = new DataGridView();
        colValSeverity         = new DataGridViewTextBoxColumn();
        colValMessage          = new DataGridViewTextBoxColumn();
        colValEntityType       = new DataGridViewTextBoxColumn();
        colValEntityId         = new DataGridViewTextBoxColumn();
        colValFieldName        = new DataGridViewTextBoxColumn();

        // ── Begin init / suspend ──────────────────────────────────────────────────────────────
        pnlContent.SuspendLayout();
        pnlTopBar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridValidationMessages).BeginInit();
        SuspendLayout();

        // ── pnlContent ────────────────────────────────────────────────────────────────────────
        // Add Fill first, then Top — last added (Top) is processed first and appears at top
        pnlContent.Controls.Add(gridValidationMessages);
        pnlContent.Controls.Add(pnlTopBar);
        pnlContent.Dock     = DockStyle.Fill;
        pnlContent.Location = new Point(0, 0);
        pnlContent.Name     = "pnlContent";
        pnlContent.Size     = new Size(858, 600);
        pnlContent.TabIndex = 0;

        // ── pnlTopBar ─────────────────────────────────────────────────────────────────────────
        pnlTopBar.Controls.Add(btnRunValidation);
        pnlTopBar.Dock     = DockStyle.Top;
        pnlTopBar.Height   = 36;
        pnlTopBar.Location = new Point(0, 0);
        pnlTopBar.Name     = "pnlTopBar";
        pnlTopBar.Padding  = new Padding(4);
        pnlTopBar.Size     = new Size(858, 36);
        pnlTopBar.TabIndex = 0;

        // ── btnRunValidation ──────────────────────────────────────────────────────────────────
        btnRunValidation.AutoSize                  = true;
        btnRunValidation.Dock                      = DockStyle.Left;
        btnRunValidation.Location                  = new Point(4, 4);
        btnRunValidation.Name                      = "btnRunValidation";
        btnRunValidation.Size                      = new Size(119, 28);
        btnRunValidation.TabIndex                  = 0;
        btnRunValidation.Text                      = "Run Validation";
        btnRunValidation.UseVisualStyleBackColor   = true;

        // ── gridValidationMessages ────────────────────────────────────────────────────────────
        gridValidationMessages.AllowUserToAddRows          = false;
        gridValidationMessages.AutoGenerateColumns         = false;
        gridValidationMessages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridValidationMessages.Columns.AddRange(new DataGridViewColumn[]
        {
            colValSeverity,
            colValMessage,
            colValEntityType,
            colValEntityId,
            colValFieldName
        });
        gridValidationMessages.Dock          = DockStyle.Fill;
        gridValidationMessages.Location      = new Point(0, 36);
        gridValidationMessages.Name          = "gridValidationMessages";
        gridValidationMessages.ReadOnly      = true;
        gridValidationMessages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridValidationMessages.Size          = new Size(858, 564);
        gridValidationMessages.TabIndex      = 1;

        // ── colValSeverity ────────────────────────────────────────────────────────────────────
        colValSeverity.DataPropertyName = "Severity";
        colValSeverity.HeaderText       = "Severity";
        colValSeverity.Name             = "colValSeverity";
        colValSeverity.Width            = 80;

        // ── colValMessage ─────────────────────────────────────────────────────────────────────
        colValMessage.AutoSizeMode      = DataGridViewAutoSizeColumnMode.Fill;
        colValMessage.DataPropertyName  = "Message";
        colValMessage.HeaderText        = "Message";
        colValMessage.Name              = "colValMessage";
        colValMessage.Width             = 360;

        // ── colValEntityType ──────────────────────────────────────────────────────────────────
        colValEntityType.DataPropertyName = "EntityType";
        colValEntityType.HeaderText       = "Entity Type";
        colValEntityType.Name             = "colValEntityType";
        colValEntityType.Width            = 140;

        // ── colValEntityId ────────────────────────────────────────────────────────────────────
        colValEntityId.DataPropertyName = "EntityId";
        colValEntityId.HeaderText       = "Entity ID";
        colValEntityId.Name             = "colValEntityId";
        colValEntityId.Width            = 140;

        // ── colValFieldName ───────────────────────────────────────────────────────────────────
        colValFieldName.DataPropertyName = "FieldName";
        colValFieldName.HeaderText       = "Field";
        colValFieldName.Name             = "colValFieldName";
        colValFieldName.Width            = 120;

        // ── ucValidation ──────────────────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(pnlContent);
        Name = "ucValidation";
        Size = new Size(858, 600);

        // ── End init / resume ─────────────────────────────────────────────────────────────────
        ((System.ComponentModel.ISupportInitialize)gridValidationMessages).EndInit();
        pnlTopBar.ResumeLayout(false);
        pnlTopBar.PerformLayout();
        pnlContent.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel                       pnlContent             = null!;
    private Panel                       pnlTopBar              = null!;
    private Button                      btnRunValidation       = null!;
    private DataGridView                gridValidationMessages = null!;
    private DataGridViewTextBoxColumn   colValSeverity         = null!;
    private DataGridViewTextBoxColumn   colValMessage          = null!;
    private DataGridViewTextBoxColumn   colValEntityType       = null!;
    private DataGridViewTextBoxColumn   colValEntityId         = null!;
    private DataGridViewTextBoxColumn   colValFieldName        = null!;
}
