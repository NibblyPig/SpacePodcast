using PodcastUniverseEditor.Models.Episodes;
using PodcastUniverseEditor.Models.ReferenceData;
using PodcastUniverseEditor.Models.Threads;
using PodcastUniverseEditor.Models.World;

namespace PodcastUniverseEditor.Models;

/// <summary>
/// Root container for a saved podcast universe project.
/// Serialised as a single *.podcastworld.json file.
/// All cross-entity references use string IDs — no object graphs are stored.
/// </summary>
public class PodcastProject
{
    // ── File metadata ────────────────────────────────────────────────────────

    public int SchemaVersion { get; set; } = 1;
    public string ProjectName { get; set; } = "New Project";
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;

    // ── Reference data ───────────────────────────────────────────────────────

    public List<OperationTypeDefinition> OperationTypes { get; set; } = new();
    public List<VesselClassDefinition> VesselClasses { get; set; } = new();
    public List<PurposeDefinition> Purposes { get; set; } = new();
    public List<ManifestStatusDefinition> ManifestStatuses { get; set; } = new();
    public List<InspectionStatusDefinition> InspectionStatuses { get; set; } = new();
    public List<ClearanceStatusDefinition> ClearanceStatuses { get; set; } = new();
    public List<EnvironmentalConditionDefinition> EnvironmentalConditions { get; set; } = new();
    public List<NoticeTypeDefinition> NoticeTypes { get; set; } = new();
    public List<PassengerCategoryDefinition> PassengerCategories { get; set; } = new();
    public List<CommodityCategoryDefinition> CommodityCategories { get; set; } = new();
    public List<StationTypeDefinition> StationTypes { get; set; } = new();
    public List<AuthorityTypeDefinition> AuthorityTypes { get; set; } = new();
    public List<AnomalyTypeDefinition> AnomalyTypes { get; set; } = new();
    public List<PhraseTemplate> PhraseTemplates { get; set; } = new();
    public List<DirectiveDefinition> Directives { get; set; } = new();
    public List<BodyTypeDefinition> BodyTypes { get; set; } = new();
    public List<OrganisationTypeDefinition> OrganisationTypes { get; set; } = new();

    // ── World data ───────────────────────────────────────────────────────────

    public List<StarSystemRecord> StarSystems { get; set; } = new();
    public List<CelestialBodyRecord> CelestialBodies { get; set; } = new();
    public List<OrganisationRecord> Organisations { get; set; } = new();
    public List<StationRecord> Stations { get; set; } = new();
    public List<DockRecord> Docks { get; set; } = new();
    public List<CommodityRecord> Commodities { get; set; } = new();
    public List<RouteRecord> Routes { get; set; } = new();
    public List<VesselRecord> Vessels { get; set; } = new();

    // ── Episode data ─────────────────────────────────────────────────────────

    public List<PodcastSeriesRecord> Series { get; set; } = new();
    public List<EpisodeRecord> Episodes { get; set; } = new();

    // ── Story threads ────────────────────────────────────────────────────────

    public List<StoryThreadRecord> StoryThreads { get; set; } = new();
}
