using PodcastUniverseEditor.Models;
using PodcastUniverseEditor.Models.Common;
using PodcastUniverseEditor.Models.Threads;
using PodcastUniverseEditor.UI;

namespace PodcastUniverseEditor.Services.Lookup;

/// <summary>
/// Lightweight lookup helpers for the current project.
/// Resolves IDs to display names and builds LookupItem lists for ComboBoxes.
/// Recreated by the main form whenever a new project is loaded.
/// </summary>
public class ProjectLookupService
{
    private readonly PodcastProject _project;
    private const string NotFound = "(unknown)";
    private const string NoneLabel = "(none)";

    public ProjectLookupService(PodcastProject project)
    {
        _project = project;
    }

    // ── Name resolution ──────────────────────────────────────────────────────

    public string StationName(string? id)             => Resolve(_project.Stations, id);
    public string DockName(string? id)                => Resolve(_project.Docks, id);
    public string VesselName(string? id)              => Resolve(_project.Vessels, id);
    public string VesselClassName(string? id)         => Resolve(_project.VesselClasses, id);
    public string OperationTypeName(string? id)       => Resolve(_project.OperationTypes, id);
    public string NoticeTypeName(string? id)          => Resolve(_project.NoticeTypes, id);
    public string PurposeName(string? id)             => Resolve(_project.Purposes, id);
    public string ManifestStatusName(string? id)      => Resolve(_project.ManifestStatuses, id);
    public string InspectionStatusName(string? id)    => Resolve(_project.InspectionStatuses, id);
    public string ClearanceStatusName(string? id)     => Resolve(_project.ClearanceStatuses, id);
    public string EnvironmentalConditionName(string? id) => Resolve(_project.EnvironmentalConditions, id);
    public string DirectiveName(string? id)           => Resolve(_project.Directives, id);
    public string PhraseTemplateName(string? id)      => Resolve(_project.PhraseTemplates, id);
    public string StoryThreadName(string? id)         => Resolve(_project.StoryThreads, id);

    /// <summary>
    /// Searches all threads' beats and returns a label for the beat, or "(none)" if not found.
    /// </summary>
    public string StoryBeatLabel(string? beatId)
    {
        if (string.IsNullOrEmpty(beatId)) return NoneLabel;
        var beat = _project.StoryThreads
            .SelectMany(t => t.Beats)
            .FirstOrDefault(b => b.Id == beatId);
        return beat != null ? $"Stage {beat.StageIndex}: {beat.Name}" : NotFound;
    }

    // ── ComboBox list builders ────────────────────────────────────────────────

    public List<LookupItem> StationsAsLookup()              => ToLookup(_project.Stations);
    public List<LookupItem> DocksAsLookup()                 => ToLookup(_project.Docks);
    public List<LookupItem> VesselsAsLookup()               => ToLookup(_project.Vessels);
    public List<LookupItem> VesselClassesAsLookup()         => ToLookup(_project.VesselClasses);
    public List<LookupItem> OperationTypesAsLookup()        => ToLookup(_project.OperationTypes);
    public List<LookupItem> NoticeTypesAsLookup()           => ToLookup(_project.NoticeTypes);
    public List<LookupItem> PurposesAsLookup()              => ToLookup(_project.Purposes);
    public List<LookupItem> ManifestStatusesAsLookup()      => ToLookup(_project.ManifestStatuses);
    public List<LookupItem> InspectionStatusesAsLookup()    => ToLookup(_project.InspectionStatuses);
    public List<LookupItem> ClearanceStatusesAsLookup()     => ToLookup(_project.ClearanceStatuses);
    public List<LookupItem> EnvironmentalConditionsAsLookup() => ToLookup(_project.EnvironmentalConditions);
    public List<LookupItem> DirectivesAsLookup()            => ToLookup(_project.Directives);
    public List<LookupItem> StoryThreadsAsLookup()          => ToLookup(_project.StoryThreads);
    public List<LookupItem> CommoditiesAsLookup()           => ToLookup(_project.Commodities);
    public List<LookupItem> PassengerCategoriesAsLookup()   => ToLookup(_project.PassengerCategories);
    public List<LookupItem> OrganisationsAsLookup()          => ToLookup(_project.Organisations);
    public List<LookupItem> SeriesAsLookup()                => ToLookup(_project.Series);
    public List<LookupItem> StationTypesAsLookup()           => ToLookup(_project.StationTypes);
    public List<LookupItem> StarSystemsAsLookup()            => ToLookup(_project.StarSystems);
    public List<LookupItem> BodyTypesAsLookup()             => ToLookup(_project.BodyTypes);
    public List<LookupItem> BodiesAsLookup()                => ToLookup(_project.CelestialBodies);

    /// <summary>Returns phrase templates, optionally filtered by TemplateGroup.</summary>
    public List<LookupItem> PhraseTemplatesAsLookup(string? group = null)
    {
        var items = _project.PhraseTemplates.AsEnumerable();
        if (!string.IsNullOrEmpty(group))
            items = items.Where(t => t.TemplateGroup == group);
        return new List<LookupItem> { LookupItem.None }
            .Concat(items.Select(t => new LookupItem(t.Id, $"[{t.TemplateGroup}] {t.Name}")))
            .ToList();
    }

    /// <summary>Returns beats for the specified thread, or an empty list if thread is null.</summary>
    public List<LookupItem> BeatsAsLookup(StoryThreadRecord? thread)
    {
        var list = new List<LookupItem> { LookupItem.None };
        if (thread != null)
            list.AddRange(thread.Beats.Select(b => new LookupItem(b.Id, $"Stage {b.StageIndex}: {b.Name}")));
        return list;
    }

    /// <summary>Returns a LookupItem list for the nullable SeverityLevel enum.</summary>
    public List<LookupItem> SeverityLevelsAsLookup()
    {
        var list = new List<LookupItem> { LookupItem.None };
        list.AddRange(Enum.GetValues<SeverityLevel>().Select(s => new LookupItem(s.ToString(), s.ToString())));
        return list;
    }

    // ── Object lookups ───────────────────────────────────────────────────────

    /// <summary>Returns the StoryThreadRecord for the given id, or null if not found.</summary>
    public StoryThreadRecord? Thread(string? id)
    {
        if (string.IsNullOrEmpty(id)) return null;
        return _project.StoryThreads.FirstOrDefault(t => t.Id == id);
    }

    /// <summary>Returns the StoryBeatRecord for the given beat id within any thread, or null.</summary>
    public StoryBeatRecord? Beat(string? beatId)
    {
        if (string.IsNullOrEmpty(beatId)) return null;
        return _project.StoryThreads
            .SelectMany(t => t.Beats)
            .FirstOrDefault(b => b.Id == beatId);
    }

    /// <summary>Returns the StoryBeatRecord for the given beat id within the specified thread, or null.</summary>
    public StoryBeatRecord? Beat(string? threadId, string? beatId)
    {
        if (string.IsNullOrEmpty(threadId) || string.IsNullOrEmpty(beatId)) return null;
        var thread = _project.StoryThreads.FirstOrDefault(t => t.Id == threadId);
        return thread?.Beats.FirstOrDefault(b => b.Id == beatId);
    }

    // ── Private helpers ───────────────────────────────────────────────────────

    private static string Resolve<T>(IEnumerable<T> collection, string? id) where T : EntityBase
    {
        if (string.IsNullOrEmpty(id)) return NoneLabel;
        var item = collection.FirstOrDefault(x => x.Id == id);
        return item?.Name ?? NotFound;
    }

    private static List<LookupItem> ToLookup<T>(IEnumerable<T> items) where T : EntityBase
    {
        return new List<LookupItem> { LookupItem.None }
            .Concat(items.Select(i => new LookupItem(i.Id, i.Name)))
            .ToList();
    }
}
