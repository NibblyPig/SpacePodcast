namespace PodcastUniverseEditor.Models.Common;

/// <summary>
/// Whether an episode entry is a traffic movement or a broadcast notice.
/// </summary>
public enum EntryKind
{
    Traffic,
    Notice
}

/// <summary>
/// Whether the entry was machine-generated or hand-authored.
/// </summary>
public enum EntrySourceType
{
    Manual,
    Generated
}

/// <summary>
/// The kind of world entity a story thread targets.
/// </summary>
public enum ThreadEntityKind
{
    Vessel,
    Route,
    Station,
    Commodity,
    Organisation
}

/// <summary>
/// Narrative severity of a story beat — how prominent the irregularity feels.
/// </summary>
public enum SeverityLevel
{
    Minor,
    Moderate,
    Major
}

/// <summary>
/// Severity of a validation message.
/// </summary>
public enum ValidationSeverity
{
    Info,
    Warning,
    Error
}
