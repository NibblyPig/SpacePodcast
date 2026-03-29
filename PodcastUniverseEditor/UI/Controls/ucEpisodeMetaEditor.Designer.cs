namespace PodcastUniverseEditor.UI.Controls;

partial class ucEpisodeMetaEditor
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    /// <summary>
    /// This InitializeComponent() contains only the UserControl shell settings.
    /// All controls are created in BuildLayout() (ucEpisodeMetaEditor.cs),
    /// called from the constructor — the Designer never touches constructor bodies,
    /// so BuildLayout() is permanently safe from Designer regeneration.
    /// </summary>
    private void InitializeComponent()
    {
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoScroll = true;
        Name = "ucEpisodeMetaEditor";
        Size = new System.Drawing.Size(300, 340);
        ResumeLayout(false);
    }
}
