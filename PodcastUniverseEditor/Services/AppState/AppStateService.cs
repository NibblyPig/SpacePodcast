using PodcastUniverseEditor.Models;

namespace PodcastUniverseEditor.Services.AppState;

/// <summary>
/// Holds the currently open project and its file-system state.
/// The UI layer reads and mutates state through this service rather than
/// passing the project object directly between forms.
/// </summary>
public class AppStateService
{
    // ── State ────────────────────────────────────────────────────────────────

    /// <summary>
    /// The currently loaded project. Never null after a successful load or new-project call.
    /// Replace via SetProject — do not assign directly.
    /// </summary>
    public PodcastProject CurrentProject { get; private set; } = new();

    /// <summary>
    /// Absolute path to the file on disk, or null if the project has not been saved yet.
    /// </summary>
    public string? CurrentFilePath { get; private set; }

    /// <summary>
    /// True if the project has been modified since the last save.
    /// </summary>
    public bool IsDirty { get; private set; }

    // ── Events ───────────────────────────────────────────────────────────────

    /// <summary>
    /// Raised after SetProject completes. Subscribe in the main form to trigger a full UI reload.
    /// </summary>
    public event Action? ProjectChanged;

    /// <summary>
    /// Raised after MarkDirty, MarkClean, or SetFilePath so the title bar and status strip
    /// can update without a full UI reload.
    /// </summary>
    public event Action? DirtyStateChanged;

    // ── Methods ──────────────────────────────────────────────────────────────

    /// <summary>
    /// Replaces the current project and resets dirty state.
    /// Raises ProjectChanged (triggers full UI reload) and, if the project was previously
    /// dirty, also raises DirtyStateChanged so all listeners stay consistent.
    /// </summary>
    public void SetProject(PodcastProject project, string? filePath)
    {
        bool wasDirty = IsDirty;
        CurrentProject = project;
        CurrentFilePath = filePath;
        IsDirty = false;
        ProjectChanged?.Invoke();
        // Also fire DirtyStateChanged if we are clearing a previously dirty flag so any
        // subscriber that does not listen to ProjectChanged still gets a clean notification.
        if (wasDirty)
            DirtyStateChanged?.Invoke();
    }

    /// <summary>
    /// Updates the saved file path after a Save As operation without triggering a full
    /// UI reload. Marks the project clean and raises DirtyStateChanged.
    /// </summary>
    public void SetFilePath(string filePath)
    {
        CurrentFilePath = filePath;
        IsDirty = false;
        DirtyStateChanged?.Invoke();
    }

    /// <summary>
    /// Marks the project as having unsaved changes.
    /// </summary>
    public void MarkDirty()
    {
        if (IsDirty) return;
        IsDirty = true;
        DirtyStateChanged?.Invoke();
    }

    /// <summary>
    /// Clears the dirty flag after a successful save.
    /// </summary>
    public void MarkClean()
    {
        if (!IsDirty) return;
        IsDirty = false;
        DirtyStateChanged?.Invoke();
    }

    /// <summary>
    /// Resets to a blank project with no file path. Used for "New Project".
    /// </summary>
    public void Clear()
    {
        SetProject(new PodcastProject(), null);
    }
}
