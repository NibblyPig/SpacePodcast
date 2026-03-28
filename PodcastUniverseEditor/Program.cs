using PodcastUniverseEditor.UI.Forms;

namespace PodcastUniverseEditor;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
