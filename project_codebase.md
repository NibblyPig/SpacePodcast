# Project Codebase Summary

## Global Using Directives

- using PodcastUniverseEditor.Models.Common;

- using PodcastUniverseEditor.Models.Episodes;

- using PodcastUniverseEditor.Models.ReferenceData;

- using PodcastUniverseEditor.Models.Threads;

- using PodcastUniverseEditor.Models.Validation;

- using PodcastUniverseEditor.Models.World;

- using PodcastUniverseEditor.Models;

- using PodcastUniverseEditor.Services.AppState;

- using PodcastUniverseEditor.Services.Export;

- using PodcastUniverseEditor.Services.Generation;

- using PodcastUniverseEditor.Services.Lookup;

- using PodcastUniverseEditor.Services.Persistence;

- using PodcastUniverseEditor.Services.Rendering;

- using PodcastUniverseEditor.Services.Seeds;

- using PodcastUniverseEditor.Services.Validation;

- using PodcastUniverseEditor.UI.Forms;

- using PodcastUniverseEditor.UI;

- using PodcastUniverseEditor.Utilities;

- using System.ComponentModel;

- using System.Reflection;

- using System.Text.Json.Serialization;

- using System.Text.Json;

- using System.Text;

- using System;


## Code Files

Below is the concatenated code from .cs files in the following folders only:
PodcastUniverseEditor

Designer-generated files are excluded. File-local usings are removed.



### File: PodcastUniverseEditor\Program.cs
```csharp


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

```n---


### File: PodcastUniverseEditor\Models\PodcastProject.cs
```csharp


namespace PodcastUniverseEditor.Models;

/// <summary>
/// Root container for a saved podcast universe project.
/// Serialised as a single *.podcastworld.json file.
/// All cross-entity references use string IDs â€” no object graphs are stored.
/// </summary>
public class PodcastProject
{
    // â”€â”€ File metadata â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public int SchemaVersion { get; set; } = 1;
    public string ProjectName { get; set; } = "New Project";
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;

    // â”€â”€ Reference data â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

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

    // â”€â”€ World data â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public List<StarSystemRecord> StarSystems { get; set; } = new();
    public List<CelestialBodyRecord> CelestialBodies { get; set; } = new();
    public List<OrganisationRecord> Organisations { get; set; } = new();
    public List<StationRecord> Stations { get; set; } = new();
    public List<DockRecord> Docks { get; set; } = new();
    public List<CommodityRecord> Commodities { get; set; } = new();
    public List<RouteRecord> Routes { get; set; } = new();
    public List<VesselRecord> Vessels { get; set; } = new();

    // â”€â”€ Episode data â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public List<PodcastSeriesRecord> Series { get; set; } = new();
    public List<EpisodeRecord> Episodes { get; set; } = new();

    // â”€â”€ Story threads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public List<StoryThreadRecord> StoryThreads { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\Common\AuditableEntityBase.cs
```csharp

namespace PodcastUniverseEditor.Models.Common;

/// <summary>
/// Extends EntityBase with creation and modification timestamps (UTC).
/// Most world and episode records use this base.
/// </summary>
public abstract class AuditableEntityBase : EntityBase
{
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;
}

```n---


### File: PodcastUniverseEditor\Models\Common\EntityBase.cs
```csharp

namespace PodcastUniverseEditor.Models.Common;

/// <summary>
/// Minimal base for all domain records. Provides a stable string ID, display name,
/// freeform notes, tag list, and extensible metadata dictionary.
/// IDs are string values â€” the seed factory uses short readable IDs; new records use GUIDs.
/// </summary>
public abstract class EntityBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();

    /// <summary>
    /// Arbitrary key/value pairs for future extensibility without schema changes.
    /// </summary>
    public Dictionary<string, string> Metadata { get; set; } = new();

    public bool IsArchived { get; set; } = false;
}

```n---


### File: PodcastUniverseEditor\Models\Common\Enums.cs
```csharp

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
/// Narrative severity of a story beat â€” how prominent the irregularity feels.
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

```n---


### File: PodcastUniverseEditor\Models\Episodes\EntryCargoLine.cs
```csharp

namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A single cargo line in an entry manifest.
/// IsDeclared / IsHiddenTruthOnly determine which layer this appears in.
/// A declared cargo line appears in spoken output; a hidden-truth-only line does not.
/// </summary>
public class EntryCargoLine
{
    /// <summary>References CommodityRecord.Id</summary>
    public string CommodityId { get; set; } = string.Empty;

    /// <summary>
    /// Optional override for the spoken commodity name. If null, the commodity's Name is used.
    /// Used when the declared manifest uses a vaguer term than the actual commodity.
    /// </summary>
    public string? SpokenCommodityNameOverride { get; set; }

    public decimal Quantity { get; set; } = 0;

    /// <summary>Optional override for the unit label used in rendered output.</summary>
    public string? UnitLabelOverride { get; set; }

    /// <summary>True if this line is part of the declared (public) manifest.</summary>
    public bool IsDeclared { get; set; } = true;

    /// <summary>True if this line exists only in the hidden truth and must not appear in rendered output.</summary>
    public bool IsHiddenTruthOnly { get; set; } = false;
}

```n---


### File: PodcastUniverseEditor\Models\Episodes\EntryPassengerLine.cs
```csharp

namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A single passenger category line in an entry manifest.
/// Mirrors the public/hidden split of EntryCargoLine.
/// </summary>
public class EntryPassengerLine
{
    /// <summary>References PassengerCategoryDefinition.Id</summary>
    public string PassengerCategoryId { get; set; } = string.Empty;

    public int Count { get; set; } = 0;

    /// <summary>True if this line appears in the declared (spoken) passenger manifest.</summary>
    public bool IsDeclared { get; set; } = true;

    /// <summary>True if this line exists only in the hidden truth.</summary>
    public bool IsHiddenTruthOnly { get; set; } = false;
}

```n---


### File: PodcastUniverseEditor\Models\Episodes\EntryRenderOptions.cs
```csharp

namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// Per-entry flags that control which optional blocks appear in rendered output.
/// Allows individual entries to suppress sections without deleting the underlying data.
/// </summary>
public class EntryRenderOptions
{
    public bool IncludePurpose { get; set; } = true;
    public bool IncludeCargo { get; set; } = true;
    public bool IncludePassengers { get; set; } = true;
    public bool IncludeManifestStatus { get; set; } = true;
    public bool IncludeInspectionStatus { get; set; } = true;
    public bool IncludeEnvironmentalStatus { get; set; } = true;
    public bool IncludeResolution { get; set; } = true;
}

```n---


### File: PodcastUniverseEditor\Models\Episodes\EpisodeEntryRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A single entry in a podcast episode â€” either a traffic movement or a broadcast notice.
/// The public layer (Declared*, ManifestStatusId, etc.) drives rendered output.
/// The hidden layer (Actual*, HiddenTruthNotes) is the narrator's private truth.
/// </summary>
public class EpisodeEntryRecord : AuditableEntityBase
{
    // â”€â”€ Structural â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public EntryKind EntryKind { get; set; } = EntryKind.Traffic;
    public EntrySourceType SourceType { get; set; } = EntrySourceType.Manual;
    public int SortOrder { get; set; } = 0;

    // â”€â”€ Operation / Notice type â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>References OperationTypeDefinition.Id. Null for notices.</summary>
    public string? OperationTypeId { get; set; }

    /// <summary>References NoticeTypeDefinition.Id. Null for traffic entries.</summary>
    public string? NoticeTypeId { get; set; }

    // â”€â”€ Location â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>References StationRecord.Id â€” the station where this event is logged.</summary>
    public string? StationId { get; set; }

    /// <summary>References DockRecord.Id</summary>
    public string? DockId { get; set; }

    // â”€â”€ Vessel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>References VesselRecord.Id</summary>
    public string? VesselId { get; set; }

    /// <summary>
    /// Optional override for the vessel class spoken in this entry.
    /// References VesselClassDefinition.Id.
    /// </summary>
    public string? VesselClassOverrideId { get; set; }

    /// <summary>
    /// Optional override for the registry displayed in spoken output.
    /// Useful when a vessel is travelling under a false registry (hidden truth scenario).
    /// </summary>
    public string? RegistryOverride { get; set; }

    // â”€â”€ Route â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>References StationRecord.Id</summary>
    public string? OriginStationId { get; set; }

    /// <summary>References StationRecord.Id</summary>
    public string? DestinationStationId { get; set; }

    // â”€â”€ Purpose (public / hidden split) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>References PurposeDefinition.Id â€” what is declared to port authority.</summary>
    public string? DeclaredPurposeId { get; set; }

    /// <summary>References PurposeDefinition.Id â€” what the vessel is actually doing.</summary>
    public string? ActualPurposeId { get; set; }

    // â”€â”€ Cargo (public / hidden split) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>Cargo lines as declared in the manifest. These appear in rendered output.</summary>
    public List<EntryCargoLine> DeclaredCargo { get; set; } = new();

    /// <summary>
    /// The actual cargo, which may differ from declared.
    /// Lines with IsHiddenTruthOnly = true do not appear in rendering.
    /// </summary>
    public List<EntryCargoLine> ActualCargo { get; set; } = new();

    // â”€â”€ Passengers (public / hidden split) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public List<EntryPassengerLine> DeclaredPassengers { get; set; } = new();
    public List<EntryPassengerLine> ActualPassengers { get; set; } = new();

    // â”€â”€ Statuses â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>References ManifestStatusDefinition.Id</summary>
    public string? ManifestStatusId { get; set; }

    /// <summary>References InspectionStatusDefinition.Id</summary>
    public string? InspectionStatusId { get; set; }

    /// <summary>References ClearanceStatusDefinition.Id</summary>
    public string? ClearanceStatusId { get; set; }

    /// <summary>References EnvironmentalConditionDefinition.Id</summary>
    public string? EnvironmentalConditionId { get; set; }

    // â”€â”€ Narrative overlays â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>References DirectiveDefinition.Id â€” authority invoked for irregular clearance.</summary>
    public string? DirectiveId { get; set; }

    /// <summary>References PhraseTemplate.Id â€” incident phrase appended after statuses.</summary>
    public string? IncidentPhraseTemplateId { get; set; }

    /// <summary>References PhraseTemplate.Id â€” resolution phrase appended after incident.</summary>
    public string? ResolutionPhraseTemplateId { get; set; }

    /// <summary>References PhraseTemplate.Id â€” route/trajectory status phrase.</summary>
    public string? RouteStatusPhraseTemplateId { get; set; }

    /// <summary>
    /// Allows the author to write a completely custom spoken body for a notice entry,
    /// bypassing template rendering. Not used for traffic entries.
    /// </summary>
    public string? PublicBodyOverride { get; set; }

    // â”€â”€ Hidden truth â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Private notes about what is really happening. Never rendered in spoken output.
    /// </summary>
    public string? HiddenTruthNotes { get; set; }

    // â”€â”€ Story thread â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>References StoryThreadRecord.Id</summary>
    public string? StoryThreadId { get; set; }

    /// <summary>References StoryBeatRecord.Id within the thread.</summary>
    public string? AppliedStoryBeatId { get; set; }

    /// <summary>The narrative severity of the anomaly applied to this entry, if any.</summary>
    public SeverityLevel? AnomalySeverity { get; set; }

    // â”€â”€ State â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Locked entries may not be regenerated without explicit user action.
    /// </summary>
    public bool IsLocked { get; set; } = false;

    /// <summary>
    /// Canon entries are part of the official timeline. Future generation must
    /// not contradict them. Set automatically when the parent episode is locked.
    /// </summary>
    public bool IsCanon { get; set; } = false;

    // â”€â”€ Generation metadata â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>The random seed used when this entry was generated. Enables reproducible regeneration.</summary>
    public int? RandomSeed { get; set; }

    // â”€â”€ Render options â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public EntryRenderOptions RenderOptions { get; set; } = new();

    /// <summary>Optional in-universe date/time this entry is scheduled for.</summary>
    public DateTime? ScheduledUtc { get; set; }
}

```n---


### File: PodcastUniverseEditor\Models\Episodes\EpisodeRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A single podcast episode. Holds an ordered list of entries.
/// When IsCanonicalLocked is set, all entries are marked IsCanon and
/// the episode is treated as immutable history by the generator and validator.
/// </summary>
public class EpisodeRecord : AuditableEntityBase
{
    /// <summary>References PodcastSeriesRecord.Id</summary>
    public string SeriesId { get; set; } = string.Empty;

    /// <summary>In-universe broadcast date/time.</summary>
    public DateTime? InUniverseUtc { get; set; }

    /// <summary>
    /// Override the broadcast station for this specific episode.
    /// If null, falls back to the series' BroadcastStationId.
    /// References StationRecord.Id.
    /// </summary>
    public string? BroadcastStationId { get; set; }

    /// <summary>All entries in this episode, in SortOrder sequence.</summary>
    public List<EpisodeEntryRecord> Entries { get; set; } = new();

    /// <summary>
    /// When true, this episode is locked canon. No entries may be regenerated
    /// and the generator will not contradict any of them.
    /// </summary>
    public bool IsCanonicalLocked { get; set; } = false;
}

```n---


### File: PodcastUniverseEditor\Models\Episodes\PodcastSeriesRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A named podcast series. Groups episodes and associates them with a broadcast station.
/// </summary>
public class PodcastSeriesRecord : AuditableEntityBase
{
    /// <summary>References StationRecord.Id â€” the station this series broadcasts from.</summary>
    public string? BroadcastStationId { get; set; }

    /// <summary>Ordered list of EpisodeRecord.Id values in this series.</summary>
    public List<string> EpisodeIds { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\AnomalyTypeDefinition.cs
```csharp


namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A category of narrative anomaly that can be attached to a story thread
/// (Cargo Mismatch, Identity Irregularity, Scheduled Absence, etc.).
/// </summary>
public class AnomalyTypeDefinition : ReferenceItemBase
{
    /// <summary>
    /// The public-facing description of this anomaly type â€” intentionally vague.
    /// e.g. "Identification signal irregularity noted."
    /// </summary>
    public string PublicDescription { get; set; } = string.Empty;

    /// <summary>
    /// If true, the anomaly is meant to be barely noticeable in rendered output.
    /// </summary>
    public bool IsSubtleByDefault { get; set; } = true;

    /// <summary>
    /// IDs of OperationTypeDefinition entries where this anomaly type may appear.
    /// Empty means it can appear in any operation.
    /// </summary>
    public List<string> AllowedOperationTypeIds { get; set; } = new();

    /// <summary>
    /// Entity kinds this anomaly type applies to (Vessel, Route, Station, etc.).
    /// </summary>
    public List<ThreadEntityKind> AllowedEntityKinds { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\AuthorityTypeDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A type of authority organisation (Port Authority, Customs, Military, etc.).
/// </summary>
public class AuthorityTypeDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\BodyTypeDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A type of celestial body (Planet, Moon, Asteroid Belt, Orbital Body, etc.).
/// Stored as editable data so the user can extend the hierarchy without code changes.
/// </summary>
public class BodyTypeDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\ClearanceStatusDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// The clearance outcome for a movement (Cleared for departure, Held for inspection, etc.).
/// </summary>
public class ClearanceStatusDefinition : ReferenceItemBase
{
    /// <summary>
    /// The full spoken phrase. e.g. "Cleared for departure.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// True if this status represents a final resolved state â€” no further
    /// action is expected in this entry.
    /// </summary>
    public bool IsTerminalState { get; set; } = true;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\CommodityCategoryDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A broad category of commodity (industrial, agricultural, fuel, restricted, etc.).
/// Used to group commodities for generation weighting and vessel class matching.
/// </summary>
public class CommodityCategoryDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\DirectiveDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A named directive that can be cited to override or explain an irregular clearance.
/// e.g. "cleared under Directive 7" implies special authority was invoked.
/// </summary>
public class DirectiveDefinition : ReferenceItemBase
{
    /// <summary>
    /// The spoken phrase. e.g. "Cleared under Directive 7.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// The organisation that issued or owns this directive (optional).
    /// References OrganisationRecord.Id.
    /// </summary>
    public string? AuthorityOrganisationId { get; set; }
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\EnvironmentalConditionDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// An environmental condition that may be noted at the end of a traffic entry.
/// e.g. "Solar flare activity remains low.--"
/// Scope is freeform text describing where the condition applies (corridor, system, sector).
/// </summary>
public class EnvironmentalConditionDefinition : ReferenceItemBase
{
    /// <summary>
    /// The full spoken phrase. e.g. "Radiation levels elevated.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// Freeform scope description, e.g. "Outer belt", "Corridor 7", "System-wide".
    /// </summary>
    public string Scope { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\InspectionStatusDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// Describes the inspection outcome or state for a movement entry.
/// </summary>
public class InspectionStatusDefinition : ReferenceItemBase
{
    /// <summary>
    /// The full spoken phrase. e.g. "No inspection required.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// True if this status implies an inspection actually took place.
    /// </summary>
    public bool ImpliesInspection { get; set; } = false;

    /// <summary>
    /// True if this status implies concern or irregularity was found.
    /// </summary>
    public bool ImpliesConcern { get; set; } = false;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\ManifestStatusDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A manifest verification status spoken during an entry.
/// ImpliesIrregularity flags statuses that should be treated as subtle anomalies.
/// </summary>
public class ManifestStatusDefinition : ReferenceItemBase
{
    /// <summary>
    /// The full spoken phrase including trailing punctuation. e.g. "Manifest verified.--"
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// True if this status implies something is not quite right. Used by validation
    /// and thread progression to assess entry anomaly level.
    /// </summary>
    public bool ImpliesIrregularity { get; set; } = false;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\NoticeTypeDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A category of broadcast notice (Operations Notice, Security Notice, etc.).
/// DefaultBodyFormat is a template for the body text when generating notices.
/// </summary>
public class NoticeTypeDefinition : ReferenceItemBase
{
    /// <summary>
    /// The header phrase spoken at the start of the notice. e.g. "Operations Notice.--"
    /// </summary>
    public string HeaderText { get; set; } = string.Empty;

    /// <summary>
    /// Optional default body phrase template for generated notices.
    /// May contain {Detail} token for insertion.
    /// </summary>
    public string DefaultBodyFormat { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\OperationTypeDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// Defines a kind of port operation (Arrival, Departure, Transfer, etc.).
/// HeaderFormat is a phrase template for the spoken header line, e.g. "Arrival at {Dock}.--"
/// </summary>
public class OperationTypeDefinition : ReferenceItemBase
{
    /// <summary>
    /// Spoken header phrase. Supports {Dock} and {Station} tokens.
    /// Example: "Departure from {Dock}.--"
    /// </summary>
    public string HeaderFormat { get; set; } = string.Empty;

    public bool RequiresOrigin { get; set; } = false;
    public bool RequiresDestination { get; set; } = false;

    /// <summary>
    /// True for port-movement operations; false for holding patterns or admin ops.
    /// </summary>
    public bool IsTrafficOperation { get; set; } = true;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\OrganisationTypeDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A type of organisation (Shipping Company, Authority, Cooperative, etc.).
/// </summary>
public class OrganisationTypeDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\PassengerCategoryDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A category of passenger manifest entry (civilian, crew rotation, diplomatic liaison, etc.).
/// </summary>
public class PassengerCategoryDefinition : ReferenceItemBase
{
    /// <summary>
    /// The spoken label used in rendered output. e.g. "civilian passengers".
    /// </summary>
    public string SpokenLabel { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\PhraseTemplate.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A reusable spoken phrase snippet used in entry rendering.
/// Templates are grouped so the generator can select from the right pool
/// (incident phrases, resolution phrases, route status phrases, notice bodies).
/// </summary>
public class PhraseTemplate : ReferenceItemBase
{
    /// <summary>
    /// The spoken text. May contain simple tokens like {Station}, {Corridor} for
    /// substitution at render time.
    /// </summary>
    public string TemplateText { get; set; } = string.Empty;

    /// <summary>
    /// Logical group name for filtering in the generator and editor UI.
    /// e.g. "incident", "resolution", "route_status", "notice_body"
    /// </summary>
    public string TemplateGroup { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\PurposeDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A declared operational purpose for a movement (Ore Transfer, Crew Rotation, etc.).
/// Drives generation weighting for cargo, vessel class, and route selection.
/// </summary>
public class PurposeDefinition : ReferenceItemBase
{
    /// <summary>
    /// The spoken phrase used in rendered output. e.g. "industrial resupply".
    /// </summary>
    public string SpokenPhrase { get; set; } = string.Empty;

    /// <summary>
    /// Specific commodity IDs commonly associated with this purpose.
    /// </summary>
    public List<string> TypicalCommodityIds { get; set; } = new();

    /// <summary>
    /// Commodity category IDs commonly associated with this purpose.
    /// </summary>
    public List<string> TypicalCommodityCategoryIds { get; set; } = new();

    /// <summary>
    /// Vessel class IDs suited to this purpose.
    /// </summary>
    public List<string> TypicalVesselClassIds { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\ReferenceItemBase.cs
```csharp


namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// Base for all user-editable vocabulary items. Each reference list entry has a short
/// code, an enabled flag, a sort order, and optional tag filters that constrain where it
/// may appear in generation.
/// </summary>
public abstract class ReferenceItemBase : AuditableEntityBase
{
    public string Code { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;
    public int SortOrder { get; set; } = 0;

    /// <summary>
    /// Tag values that must be present on a candidate entity for this item to be eligible.
    /// Empty list means no filter â€” item is universally eligible.
    /// </summary>
    public List<string> AllowedTagFilters { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\StationTypeDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// A functional type of station (Outpost, Orbital Station, Shipyard, Mining Platform, etc.).
/// </summary>
public class StationTypeDefinition : ReferenceItemBase
{
    public string SpokenLabel { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\ReferenceData\VesselClassDefinition.cs
```csharp

namespace PodcastUniverseEditor.Models.ReferenceData;

/// <summary>
/// Describes a class of vessel (Bulk Carrier, Courier, Tanker, etc.) and its
/// typical operational profile for generation and validation purposes.
/// </summary>
public class VesselClassDefinition : ReferenceItemBase
{
    /// <summary>
    /// The spoken noun used in rendered output. e.g. "bulk carrier", "courier vessel".
    /// </summary>
    public string SpokenNoun { get; set; } = string.Empty;

    public bool CanCarryCargo { get; set; } = true;
    public bool CanCarryPassengers { get; set; } = false;

    /// <summary>
    /// IDs of CommodityCategoryDefinition entries typically associated with this class.
    /// Used to weight generation and flag implausible cargo.
    /// </summary>
    public List<string> TypicalCommodityCategoryIds { get; set; } = new();

    public int TypicalPassengerMin { get; set; } = 0;
    public int TypicalPassengerMax { get; set; } = 0;
}

```n---


### File: PodcastUniverseEditor\Models\Threads\StoryBeatRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.Threads;

/// <summary>
/// A single stage beat within a story thread. Describes what the entry should look
/// like at this point in the thread's progression â€” which statuses to apply, which
/// phrase templates to use, and the severity level.
/// </summary>
public class StoryBeatRecord : EntityBase
{
    /// <summary>
    /// Zero-based index. Beat 0 is the thread's starting state (often ordinary).
    /// Beats advance in order; the thread must not skip stages without manual override.
    /// </summary>
    public int StageIndex { get; set; } = 0;

    /// <summary>References ManifestStatusDefinition.Id â€” the public manifest status for this beat.</summary>
    public string? PublicManifestStatusId { get; set; }

    /// <summary>References InspectionStatusDefinition.Id</summary>
    public string? PublicInspectionStatusId { get; set; }

    /// <summary>References DirectiveDefinition.Id</summary>
    public string? PublicDirectiveId { get; set; }

    /// <summary>References PhraseTemplate.Id â€” incident phrase for this beat.</summary>
    public string? IncidentPhraseTemplateId { get; set; }

    /// <summary>References PhraseTemplate.Id â€” resolution phrase for this beat.</summary>
    public string? ResolutionPhraseTemplateId { get; set; }

    /// <summary>
    /// Private narrative summary of what is really happening at this stage.
    /// Never rendered in spoken output.
    /// </summary>
    public string HiddenTruthSummary { get; set; } = string.Empty;

    public SeverityLevel Severity { get; set; } = SeverityLevel.Minor;
}

```n---


### File: PodcastUniverseEditor\Models\Threads\StoryThreadRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.Threads;

/// <summary>
/// A long-running narrative thread associated with a world entity (vessel, route, station, etc.).
/// The thread tracks the current stage of escalation and controls when it is eligible
/// to influence generation.
/// </summary>
public class StoryThreadRecord : AuditableEntityBase
{
    /// <summary>The kind of entity this thread targets.</summary>
    public ThreadEntityKind EntityKind { get; set; } = ThreadEntityKind.Vessel;

    /// <summary>
    /// The specific entity ID â€” references VesselRecord.Id, RouteRecord.Id, etc.
    /// depending on EntityKind.
    /// </summary>
    public string TargetEntityId { get; set; } = string.Empty;

    /// <summary>References AnomalyTypeDefinition.Id â€” the central anomaly theme of this thread.</summary>
    public string? ThemeAnomalyTypeId { get; set; }

    /// <summary>
    /// Index of the beat that has most recently been applied.
    /// Starts at -1 (no beat applied yet). Advances by 1 each time a beat is applied.
    /// </summary>
    public int CurrentStageIndex { get; set; } = -1;

    /// <summary>False to temporarily disable this thread from influencing generation.</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Minimum number of episodes that must elapse between applications of this thread.
    /// Prevents the anomaly from appearing in every episode.
    /// </summary>
    public int CooldownEpisodes { get; set; } = 2;

    /// <summary>
    /// Countdown of episodes remaining before this thread is eligible again.
    /// The generator decrements this each episode. When it reaches 0 the thread
    /// becomes eligible.
    /// </summary>
    public int EpisodesUntilEligible { get; set; } = 0;

    /// <summary>All beats defined for this thread, ordered by StageIndex.</summary>
    public List<StoryBeatRecord> Beats { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\Validation\ValidationMessage.cs
```csharp


namespace PodcastUniverseEditor.Models.Validation;

/// <summary>
/// A single validation finding. EntityType and EntityId allow the UI to
/// navigate directly to the offending record.
/// </summary>
public class ValidationMessage
{
    public ValidationSeverity Severity { get; set; } = ValidationSeverity.Info;
    public string Message { get; set; } = string.Empty;

    /// <summary>Short string identifying the record type, e.g. "EpisodeEntryRecord", "VesselRecord".</summary>
    public string EntityType { get; set; } = string.Empty;

    /// <summary>The string Id of the offending entity (matches EntityBase.Id).</summary>
    public string EntityId { get; set; } = string.Empty;

    /// <summary>The property name that failed validation, if applicable.</summary>
    public string FieldName { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\Validation\ValidationResult.cs
```csharp


namespace PodcastUniverseEditor.Models.Validation;

/// <summary>
/// Aggregates all validation findings from a single validation run.
/// </summary>
public class ValidationResult
{
    public List<ValidationMessage> Messages { get; set; } = new();

    public bool HasErrors => Messages.Any(m => m.Severity == ValidationSeverity.Error);
    public bool HasWarnings => Messages.Any(m => m.Severity == ValidationSeverity.Warning);
}

```n---


### File: PodcastUniverseEditor\Models\World\CelestialBodyRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A planet, moon, asteroid belt, or other body within a star system.
/// Supports a simple parent hierarchy (e.g. moon of a planet).
/// </summary>
public class CelestialBodyRecord : AuditableEntityBase
{
    /// <summary>References StarSystemRecord.Id</summary>
    public string StarSystemId { get; set; } = string.Empty;

    /// <summary>
    /// Optional parent body. References CelestialBodyRecord.Id.
    /// Null if this body orbits the star directly.
    /// </summary>
    public string? ParentBodyId { get; set; }

    /// <summary>References BodyTypeDefinition.Id</summary>
    public string BodyTypeId { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\World\CommodityRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A tradeable commodity in the universe (Liquid Oxygen, Structural Plating, etc.).
/// IsRestricted and IsContraband are distinct: restricted = regulated but legal;
/// contraband = illegal to declare openly.
/// </summary>
public class CommodityRecord : AuditableEntityBase
{
    /// <summary>References CommodityCategoryDefinition.Id</summary>
    public string CommodityCategoryId { get; set; } = string.Empty;

    /// <summary>Spoken unit for rendered output. e.g. "tons", "units", "canisters"</summary>
    public string UnitLabel { get; set; } = string.Empty;

    public int TypicalMinQuantity { get; set; } = 0;
    public int TypicalMaxQuantity { get; set; } = 1000;

    /// <summary>Regulated but declarable. Triggers validation if carried without a matching purpose.</summary>
    public bool IsRestricted { get; set; } = false;

    /// <summary>Cannot appear in declared cargo â€” only in actual/hidden cargo lines.</summary>
    public bool IsContraband { get; set; } = false;

    /// <summary>Station IDs where this commodity is produced.</summary>
    public List<string> ProducedAtStationIds { get; set; } = new();

    /// <summary>Station IDs where this commodity is consumed.</summary>
    public List<string> ConsumedAtStationIds { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\World\DockRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A named berth, bay, ring, or docking position at a station.
/// SpokenLabel is the short form for headers; SpokenIdentifier is the full spoken name.
/// </summary>
public class DockRecord : AuditableEntityBase
{
    /// <summary>References StationRecord.Id</summary>
    public string StationId { get; set; } = string.Empty;

    /// <summary>Short spoken form used in header. e.g. "Bay Fourteen"</summary>
    public string SpokenLabel { get; set; } = string.Empty;

    /// <summary>Full spoken identifier if different. e.g. "Docking Ring Fourteen, Sector B"</summary>
    public string SpokenIdentifier { get; set; } = string.Empty;

    /// <summary>Restricted docks should trigger a validation warning if used without a directive.</summary>
    public bool IsRestricted { get; set; } = false;

    /// <summary>Suspended docks should not receive active traffic. Validation will flag conflicts.</summary>
    public bool IsSuspended { get; set; } = false;
}

```n---


### File: PodcastUniverseEditor\Models\World\OrganisationRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A company, authority, cooperative, or other organisation active in the universe.
/// </summary>
public class OrganisationRecord : AuditableEntityBase
{
    /// <summary>References OrganisationTypeDefinition.Id</summary>
    public string OrganisationTypeId { get; set; } = string.Empty;

    /// <summary>
    /// True if this organisation has regulatory or enforcement authority.
    /// Relevant when processing directives.
    /// </summary>
    public bool IsAuthority { get; set; } = false;
}

```n---


### File: PodcastUniverseEditor\Models\World\RouteRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A defined route between two stations. FrequencyWeight and RiskWeight influence
/// how often it is chosen during generation and how likely it is to carry anomalies.
/// </summary>
public class RouteRecord : AuditableEntityBase
{
    /// <summary>References StationRecord.Id</summary>
    public string FromStationId { get; set; } = string.Empty;

    /// <summary>References StationRecord.Id</summary>
    public string ToStationId { get; set; } = string.Empty;

    /// <summary>
    /// Higher values make this route more likely to be chosen during generation.
    /// Default 1.0 â€” typical route. Increase for busy corridors.
    /// </summary>
    public double FrequencyWeight { get; set; } = 1.0;

    /// <summary>
    /// Higher values make anomaly injection more likely on this route.
    /// Default 1.0 â€” normal risk.
    /// </summary>
    public double RiskWeight { get; set; } = 1.0;

    /// <summary>References PhraseTemplate.Id for a standard route status phrase.</summary>
    public string? RouteConditionTemplateId { get; set; }

    /// <summary>Vessel class IDs permitted on this route.</summary>
    public List<string> AllowedVesselClassIds { get; set; } = new();

    /// <summary>Commodity IDs typically carried on this route.</summary>
    public List<string> TypicalCommodityIds { get; set; } = new();

    /// <summary>PurposeDefinition IDs typical for this route.</summary>
    public List<string> TypicalPurposeIds { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\World\StarSystemRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A star system in the fiction. Acts as the top-level geographic grouping for bodies and stations.
/// </summary>
public class StarSystemRecord : AuditableEntityBase
{
    /// <summary>
    /// Broad region name, e.g. "Inner Reach", "Outer Belt". Optional flavour.
    /// </summary>
    public string RegionName { get; set; } = string.Empty;
}

```n---


### File: PodcastUniverseEditor\Models\World\StationRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A space station â€” the primary setting for port traffic entries.
/// </summary>
public class StationRecord : AuditableEntityBase
{
    /// <summary>References StationTypeDefinition.Id</summary>
    public string StationTypeId { get; set; } = string.Empty;

    /// <summary>References StarSystemRecord.Id</summary>
    public string StarSystemId { get; set; } = string.Empty;

    /// <summary>References CelestialBodyRecord.Id â€” the body this station orbits or sits on.</summary>
    public string? CelestialBodyId { get; set; }

    /// <summary>References OrganisationRecord.Id</summary>
    public string? OperatorOrganisationId { get; set; }

    /// <summary>Commodity IDs this station typically imports. Used in generation weighting.</summary>
    public List<string> ImportCommodityIds { get; set; } = new();

    /// <summary>Commodity IDs this station typically exports.</summary>
    public List<string> ExportCommodityIds { get; set; } = new();

    /// <summary>PurposeDefinition IDs that make sense for traffic at this station.</summary>
    public List<string> PurposeIds { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\Models\World\VesselRecord.cs
```csharp


namespace PodcastUniverseEditor.Models.World;

/// <summary>
/// A named vessel in the universe. IsRecurringNarrativeAsset marks vessels that
/// should appear regularly and may carry story threads.
/// </summary>
public class VesselRecord : AuditableEntityBase
{
    /// <summary>Official registry code. e.g. "XF-7742". Must be unique within the project.</summary>
    public string Registry { get; set; } = string.Empty;

    /// <summary>References VesselClassDefinition.Id</summary>
    public string VesselClassId { get; set; } = string.Empty;

    /// <summary>References OrganisationRecord.Id</summary>
    public string? OperatorOrganisationId { get; set; }

    /// <summary>References StationRecord.Id â€” the vessel's registered home port.</summary>
    public string? HomeStationId { get; set; }

    /// <summary>
    /// True for vessels intended to recur in the narrative with consistent identity.
    /// The generator will favour these on routes where they are plausible.
    /// </summary>
    public bool IsRecurringNarrativeAsset { get; set; } = false;

    /// <summary>RouteRecord IDs this vessel is preferred on.</summary>
    public List<string> PreferredRouteIds { get; set; } = new();

    /// <summary>StoryThreadRecord IDs associated with this vessel.</summary>
    public List<string> AssociatedThreadIds { get; set; } = new();
}

```n---


### File: PodcastUniverseEditor\obj\Debug\net8.0-windows\.NETCoreApp,Version=v8.0.AssemblyAttributes.cs
```csharp

// <autogenerated />
[assembly: global::System.Runtime.Versioning.TargetFrameworkAttribute(".NETCoreApp,Version=v8.0", FrameworkDisplayName = ".NET 8.0")]

```n---


### File: PodcastUniverseEditor\obj\Debug\net8.0-windows\PodcastUniverseEditor.AssemblyInfo.cs
```csharp

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


[assembly: System.Reflection.AssemblyCompanyAttribute("PodcastUniverseEditor")]
[assembly: System.Reflection.AssemblyConfigurationAttribute("Debug")]
[assembly: System.Reflection.AssemblyFileVersionAttribute("1.0.0.0")]
[assembly: System.Reflection.AssemblyInformationalVersionAttribute("1.0.0+74e063a4649dc48c97c49e0397db6801463703ff")]
[assembly: System.Reflection.AssemblyProductAttribute("PodcastUniverseEditor")]
[assembly: System.Reflection.AssemblyTitleAttribute("PodcastUniverseEditor")]
[assembly: System.Reflection.AssemblyVersionAttribute("1.0.0.0")]
[assembly: System.Runtime.Versioning.TargetPlatformAttribute("Windows7.0")]
[assembly: System.Runtime.Versioning.SupportedOSPlatformAttribute("Windows7.0")]

// Generated by the MSBuild WriteCodeFragment class.


```n---


### File: PodcastUniverseEditor\obj\Debug\net8.0-windows\PodcastUniverseEditor.GlobalUsings.g.cs
```csharp

// <auto-generated/>
global using System;
global using System.Collections.Generic;
global using System.Drawing;
global using System.IO;
global using System.Linq;
global using System.Net.Http;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Windows.Forms;

```n---


### File: PodcastUniverseEditor\Services\AppState\AppStateService.cs
```csharp


namespace PodcastUniverseEditor.Services.AppState;

/// <summary>
/// Holds the currently open project and its file-system state.
/// The UI layer reads and mutates state through this service rather than
/// passing the project object directly between forms.
/// </summary>
public class AppStateService
{
    // â”€â”€ State â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// The currently loaded project. Never null after a successful load or new-project call.
    /// Replace via SetProject â€” do not assign directly.
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

    // â”€â”€ Events â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Raised after SetProject completes. Subscribe in the main form to trigger a full UI reload.
    /// </summary>
    public event Action? ProjectChanged;

    /// <summary>
    /// Raised after MarkDirty, MarkClean, or SetFilePath so the title bar and status strip
    /// can update without a full UI reload.
    /// </summary>
    public event Action? DirtyStateChanged;

    // â”€â”€ Methods â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

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

```n---


### File: PodcastUniverseEditor\Services\Export\ExportedEpisode.cs
```csharp

namespace PodcastUniverseEditor.Services.Export;

/// <summary>
/// Structured representation of an exported episode, designed for downstream tooling.
/// All fields are resolved to human-readable names at export time.
/// Hidden-truth fields are only populated when JsonExportOptions.IncludeHiddenTruth is true.
/// </summary>
public sealed class ExportedEpisode
{
    public string   EpisodeId         { get; init; } = string.Empty;
    public string   EpisodeName       { get; init; } = string.Empty;
    public string?  InUniverseDate    { get; init; }
    public bool     IsCanonicalLocked { get; init; }
    public string   ExportedAtUtc     { get; init; } = string.Empty;
    public int      EntryCount        { get; init; }
    public List<ExportedEpisodeEntry> Entries { get; init; } = new();
}

/// <summary>
/// Structured representation of a single exported episode entry.
/// Reference data IDs are resolved to display names at export time.
/// </summary>
public sealed class ExportedEpisodeEntry
{
    // â”€â”€ Identity â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public string EntryId    { get; init; } = string.Empty;
    public int    SortOrder  { get; init; }
    public string EntryKind  { get; init; } = string.Empty;
    public string SourceType { get; init; } = string.Empty;
    public bool   IsCanon    { get; init; }
    public bool   IsLocked   { get; init; }

    // â”€â”€ Rendered output â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>Rendered public broadcast text for this entry. Null if IncludeRenderedText is false.</summary>
    public string? RenderedPublicText { get; init; }

    // â”€â”€ Public structured fields (resolved to names) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public string? Vessel                { get; init; }
    public string? Station               { get; init; }
    public string? Dock                  { get; init; }
    public string? OriginStation         { get; init; }
    public string? DestinationStation    { get; init; }
    public string? OperationType         { get; init; }
    public string? DeclaredPurpose       { get; init; }
    public string? ManifestStatus        { get; init; }
    public string? InspectionStatus      { get; init; }
    public string? ClearanceStatus       { get; init; }
    public string? EnvironmentalCondition{ get; init; }
    public string? StoryThread           { get; init; }
    public string? AppliedBeat           { get; init; }
    public string? AnomalySeverity       { get; init; }

    // â”€â”€ Hidden truth (null unless JsonExportOptions.IncludeHiddenTruth = true) â”€

    public string? HiddenTruthNotes { get; init; }
    public string? ActualPurpose    { get; init; }

    // â”€â”€ Generation metadata (null unless JsonExportOptions.IncludeGenerationMetadata = true) â”€

    public int? RandomSeed { get; init; }
}

```n---


### File: PodcastUniverseEditor\Services\Export\JsonExportOptions.cs
```csharp

namespace PodcastUniverseEditor.Services.Export;

/// <summary>
/// Controls what is included in a structured JSON export of an episode.
/// By default all exports are public-layer only.
/// Hidden truth and generation metadata are opt-in and should only be
/// enabled for author/debug workflows â€” never for public-facing pipelines.
/// </summary>
public sealed class JsonExportOptions
{
    /// <summary>
    /// When true, include hidden-truth fields: HiddenTruthNotes and ActualPurpose.
    /// Default OFF â€” safe for public/downstream use.
    /// Enable only for author/debug exports.
    /// </summary>
    public bool IncludeHiddenTruth { get; init; } = false;

    /// <summary>Include the rendered public broadcast text for each entry.</summary>
    public bool IncludeRenderedText { get; init; } = true;

    /// <summary>
    /// When true, include generation metadata: RandomSeed.
    /// Useful for reproducing or auditing generated entries.
    /// Default OFF.
    /// </summary>
    public bool IncludeGenerationMetadata { get; init; } = false;

    /// <summary>Public-safe export: no hidden truth, rendered text included, no metadata.</summary>
    public static readonly JsonExportOptions Public = new();

    /// <summary>
    /// Author/debug export: includes hidden truth, rendered text, and generation metadata.
    /// Do not use this preset for downstream public pipelines.
    /// </summary>
    public static readonly JsonExportOptions AuthorDebug = new()
    {
        IncludeHiddenTruth        = true,
        IncludeRenderedText       = true,
        IncludeGenerationMetadata = true
    };
}

```n---


### File: PodcastUniverseEditor\Services\Export\ProjectExportService.cs
```csharp


namespace PodcastUniverseEditor.Services.Export;

/// <summary>
/// Exports EpisodeRecord instances to broadcast script text, TTS-friendly text,
/// or structured JSON for downstream tooling.
///
/// Export contract:
///   - All exports are public-layer only by default (no hidden truth).
///   - Hidden truth is only included when JsonExportOptions.IncludeHiddenTruth = true.
///   - TTS exports never include hidden truth regardless of options.
///   - Deterministic: same episode + same options always produces the same output.
/// </summary>
public class ProjectExportService
{
    private readonly EntryRenderingService _renderer = new();

    private static readonly JsonSerializerOptions JsonWriteOptions = new()
    {
        WriteIndented          = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters             = { new JsonStringEnumConverter() }
    };

    // â”€â”€ Public API â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Returns the episode rendered as a broadcast script, exactly as produced by
    /// EntryRenderingService. Includes the === episode header and --- separator.
    /// This is the same text shown in the Output Preview tab.
    /// </summary>
    public string ExportEpisodeAsBroadcastText(PodcastProject project, EpisodeRecord episode)
        => _renderer.RenderEpisode(project, episode);

    /// <summary>
    /// Returns the episode formatted for TTS consumption.
    /// Strips broadcast-specific visual markers (.-- pause cues, === headers, ---
    /// dividers) and produces clean prose blocks ready for copy-paste into a
    /// voice tool. Never includes hidden-truth fields.
    /// </summary>
    public string ExportEpisodeAsTtsText(
        PodcastProject  project,
        EpisodeRecord   episode,
        TtsExportOptions options)
    {
        var sb      = new StringBuilder();
        var entries = episode.Entries.OrderBy(e => e.SortOrder).ToList();

        if (options.IncludeEpisodeHeader)
        {
            sb.AppendLine(episode.Name);
            if (episode.InUniverseUtc.HasValue)
                sb.AppendLine(episode.InUniverseUtc.Value.ToString("yyyy-MM-dd"));

            if (options.BlankLineBetweenEntries)
                sb.AppendLine();
        }

        for (int i = 0; i < entries.Count; i++)
        {
            if (options.IncludeEntryMarkers)
                sb.AppendLine($"[Entry {i + 1}]");

            string raw       = _renderer.RenderEntry(project, entries[i]);
            string processed = ProcessForTts(raw, options);

            if (!string.IsNullOrWhiteSpace(processed))
                sb.AppendLine(processed);

            if (options.BlankLineBetweenEntries && i < entries.Count - 1)
                sb.AppendLine();
        }

        return sb.ToString().TrimEnd();
    }

    /// <summary>
    /// Returns the episode serialised as structured JSON suitable for downstream
    /// tooling and TTS pipeline automation.
    /// Hidden-truth fields are omitted unless options.IncludeHiddenTruth is true.
    /// </summary>
    public string ExportEpisodeAsJson(
        PodcastProject  project,
        EpisodeRecord   episode,
        JsonExportOptions options)
    {
        var exported = new ExportedEpisode
        {
            EpisodeId         = episode.Id,
            EpisodeName       = episode.Name,
            InUniverseDate    = episode.InUniverseUtc?.ToString("yyyy-MM-dd HH:mm UTC"),
            IsCanonicalLocked = episode.IsCanonicalLocked,
            ExportedAtUtc     = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss UTC"),
            EntryCount        = episode.Entries.Count,
            Entries           = episode.Entries
                                    .OrderBy(e => e.SortOrder)
                                    .Select(e => BuildExportedEntry(project, e, options))
                                    .ToList()
        };

        return JsonSerializer.Serialize(exported, JsonWriteOptions);
    }

    // â”€â”€ Private helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private ExportedEpisodeEntry BuildExportedEntry(
        PodcastProject    project,
        EpisodeEntryRecord entry,
        JsonExportOptions  options)
    {
        // Local name resolver â€” avoids pulling in ProjectLookupService as a dependency.
        string? Resolve<T>(IEnumerable<T> col, string? id) where T : EntityBase
            => string.IsNullOrEmpty(id) ? null : col.FirstOrDefault(x => x.Id == id)?.Name;

        string? beatName = null;
        if (!string.IsNullOrEmpty(entry.AppliedStoryBeatId))
        {
            beatName = project.StoryThreads
                .SelectMany(t => t.Beats)
                .FirstOrDefault(b => b.Id == entry.AppliedStoryBeatId)
                ?.Name;
        }

        return new ExportedEpisodeEntry
        {
            EntryId              = entry.Id,
            SortOrder            = entry.SortOrder,
            EntryKind            = entry.EntryKind.ToString(),
            SourceType           = entry.SourceType.ToString(),
            IsCanon              = entry.IsCanon,
            IsLocked             = entry.IsLocked,

            RenderedPublicText   = options.IncludeRenderedText
                                    ? _renderer.RenderEntry(project, entry)
                                    : null,

            Vessel               = Resolve(project.Vessels,              entry.VesselId),
            Station              = Resolve(project.Stations,             entry.StationId),
            Dock                 = Resolve(project.Docks,                entry.DockId),
            OriginStation        = Resolve(project.Stations,             entry.OriginStationId),
            DestinationStation   = Resolve(project.Stations,             entry.DestinationStationId),
            OperationType        = Resolve(project.OperationTypes,       entry.OperationTypeId),
            DeclaredPurpose      = Resolve(project.Purposes,             entry.DeclaredPurposeId),
            ManifestStatus       = Resolve(project.ManifestStatuses,     entry.ManifestStatusId),
            InspectionStatus     = Resolve(project.InspectionStatuses,   entry.InspectionStatusId),
            ClearanceStatus      = Resolve(project.ClearanceStatuses,    entry.ClearanceStatusId),
            EnvironmentalCondition = Resolve(project.EnvironmentalConditions, entry.EnvironmentalConditionId),
            StoryThread          = Resolve(project.StoryThreads,         entry.StoryThreadId),
            AppliedBeat          = beatName,
            AnomalySeverity      = entry.AnomalySeverity?.ToString(),

            // Hidden truth â€” only when explicitly enabled
            HiddenTruthNotes     = options.IncludeHiddenTruth ? entry.HiddenTruthNotes          : null,
            ActualPurpose        = options.IncludeHiddenTruth
                                    ? Resolve(project.Purposes, entry.ActualPurposeId)
                                    : null,

            // Generation metadata â€” only when explicitly enabled
            RandomSeed           = options.IncludeGenerationMetadata ? entry.RandomSeed : null
        };
    }

    /// <summary>
    /// Post-processes a single rendered entry string for TTS use:
    ///   1. Strips visual separator lines (===, ---) when StripVisualSeparators is true.
    ///   2. Removes broadcast pause markers (.-- and --) from line ends.
    ///   3. Strips leading indentation.
    ///   4. Joins all lines into a single paragraph when OneEntryPerParagraph is true.
    /// </summary>
    private static string ProcessForTts(string rendered, TtsExportOptions options)
    {
        var lines  = rendered.Split('\n');
        var result = new List<string>(lines.Length);

        foreach (var rawLine in lines)
        {
            var line    = rawLine.TrimEnd();
            var trimmed = line.Trim();

            // Strip pure visual separator lines
            if (options.StripVisualSeparators)
            {
                if (trimmed.StartsWith("===") || trimmed == "---"
                    || (trimmed.Length > 0 && trimmed.All(c => c == '-' || c == '=')))
                    continue;
            }

            // Remove broadcast pause markers (.-- keeps the sentence-ending period; -- alone is stripped)
            if (line.EndsWith(".--"))
                line = line[..^2];          // remove "--", period remains
            else if (line.EndsWith("--"))
                line = line[..^2].TrimEnd();

            // Strip leading indentation (broadcast script uses 2-space indent)
            line = line.TrimStart();

            if (!string.IsNullOrEmpty(line))
                result.Add(line);
        }

        if (result.Count == 0)
            return string.Empty;

        if (options.OneEntryPerParagraph)
            return string.Join(" ", result);

        return string.Join(Environment.NewLine, result);
    }
}

```n---


### File: PodcastUniverseEditor\Services\Export\TtsExportOptions.cs
```csharp

namespace PodcastUniverseEditor.Services.Export;

/// <summary>
/// Controls how an episode is formatted for TTS (text-to-speech) export.
/// TTS exports strip broadcast-specific visual markers and produce clean prose
/// suitable for copy-paste into external voice tools.
/// No hidden-truth fields are ever included â€” this export is always public-layer only.
/// </summary>
public sealed class TtsExportOptions
{
    /// <summary>Prepend the episode name (and in-universe date if set) before the entries.</summary>
    public bool IncludeEpisodeHeader { get; init; } = true;

    /// <summary>Insert a blank line between each entry block.</summary>
    public bool BlankLineBetweenEntries { get; init; } = true;

    /// <summary>
    /// Remove pure visual separator lines such as "===" headers and "---" dividers
    /// that appear in the broadcast script but have no spoken value.
    /// </summary>
    public bool StripVisualSeparators { get; init; } = true;

    /// <summary>
    /// Join all lines of a single entry into one prose paragraph.
    /// Recommended for TTS pipelines that expect a single block of text per cue.
    /// </summary>
    public bool OneEntryPerParagraph { get; init; } = true;

    /// <summary>Prefix each entry paragraph with a numeric marker such as "[Entry 1]".</summary>
    public bool IncludeEntryMarkers { get; init; } = false;

    /// <summary>
    /// Placeholder â€” reserved for future phonetic hint injection.
    /// Has no effect in this version.
    /// </summary>
    public bool IncludePronunciationHints { get; init; } = false;

    /// <summary>
    /// Expand common broadcast abbreviations to full spoken forms where possible.
    /// Placeholder â€” reserved for future expansion logic.
    /// Has no effect in this version.
    /// </summary>
    public bool ExpandAbbreviationsWherePossible { get; init; } = false;

    /// <summary>Sensible defaults for most TTS pipelines.</summary>
    public static readonly TtsExportOptions Default = new();
}

```n---


### File: PodcastUniverseEditor\Services\Generation\EpisodeGenerationService.cs
```csharp


namespace PodcastUniverseEditor.Services.Generation;

/// <summary>
/// Generates EpisodeEntryRecord instances from a PodcastProject's reference data,
/// routes, vessels, and story threads. All methods are deterministic given a seed.
/// Canon and locked entries are never modified or cleared.
///
/// Cooldown contract: FillEpisode ticks cooldowns at the START of the call (before
/// building entries), representing the passage of one episode since the last call.
/// GenerateEntry / GenerateEntries do not tick â€” they are single-entry operations.
/// </summary>
public class EpisodeGenerationService
{
    private readonly WeightedRandomService         _weighted    = new();
    private readonly StoryThreadProgressionService _progression = new();

    // â”€â”€ Public API â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Generates a single traffic entry in Editing mode (no story mutation).
    /// Set <paramref name="advanceStory"/> to true only when generating in simulation context.
    /// </summary>
    public EpisodeEntryRecord GenerateEntry(PodcastProject project, int? seed = null, bool advanceStory = false)
    {
        var options = advanceStory ? GenerationOptions.Simulation : GenerationOptions.Editing;
        var rng     = WeightedRandomService.CreateRandom(seed);
        return BuildEntry(project, rng, seed, sortOrder: 1, options);
    }

    /// <summary>
    /// Generates <paramref name="count"/> entries in Editing mode (no story mutation).
    /// Each entry records its per-entry seed offset for reproducibility.
    /// </summary>
    public List<EpisodeEntryRecord> GenerateEntries(PodcastProject project, int count, int? seed = null)
    {
        var rng     = WeightedRandomService.CreateRandom(seed);
        var results = new List<EpisodeEntryRecord>(count);
        for (int i = 0; i < count; i++)
        {
            int? entrySeed = seed.HasValue ? seed.Value + i : null;
            results.Add(BuildEntry(project, rng, entrySeed, sortOrder: i + 1, GenerationOptions.Editing));
        }
        return results;
    }

    /// <summary>
    /// Appends (or replaces) entries in the episode in Simulation mode.
    /// Ticks cooldowns at the START of the call (representing passage of one episode).
    /// When <paramref name="clearExisting"/> is true, all non-locked and non-canon entries
    /// are removed before generation. Locked and canon entries are never touched.
    /// </summary>
    public void FillEpisode(
        PodcastProject project,
        EpisodeRecord   episode,
        int             count,
        bool            clearExisting,
        int?            seed = null)
    {
        // Simulation mode only â€” tick first so threads advanced in a previous FillEpisode
        // call have their cooldowns decremented before new beats are applied in this pass.
        _progression.TickCooldowns(project);

        if (clearExisting)
            episode.Entries.RemoveAll(e => !e.IsLocked && !e.IsCanon);

        int nextSort = episode.Entries.Count > 0
            ? episode.Entries.Max(e => e.SortOrder) + 1
            : 1;

        var rng = WeightedRandomService.CreateRandom(seed);
        for (int i = 0; i < count; i++)
        {
            int? entrySeed = seed.HasValue ? seed.Value + i : null;
            var entry = BuildEntry(project, rng, entrySeed, sortOrder: nextSort + i, GenerationOptions.Simulation);
            episode.Entries.Add(entry);
        }
    }

    // â”€â”€ Core builder â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private EpisodeEntryRecord BuildEntry(PodcastProject project, Random rng, int? seed, int sortOrder, GenerationOptions options)
    {
        var entry = new EpisodeEntryRecord
        {
            Id         = Guid.NewGuid().ToString(),
            EntryKind  = EntryKind.Traffic,
            SourceType = EntrySourceType.Generated,
            SortOrder  = sortOrder,
            RandomSeed = seed
        };

        // â”€â”€ Hub station â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        var hub = FindHubStation(project);

        // â”€â”€ Thread selection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // Thread is selected before route so route can be biased toward the thread's
        // target vessel's preferred routes.

        StoryThreadRecord? thread = null;
        StoryBeatRecord?   beat   = null;

        var eligible = _progression.EligibleThreads(project);
        if (eligible.Count > 0 && _weighted.Chance(0.4, rng))
        {
            thread = _weighted.ChooseUniform(eligible, rng);
            if (thread != null)
                beat = _progression.PeekNextBeat(thread);
        }

        // â”€â”€ Route selection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        var route = SelectRoute(project, rng, hub, thread);

        // â”€â”€ Operation type â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        var trafficOps = project.OperationTypes
            .Where(o => o.IsEnabled && o.IsTrafficOperation)
            .ToList();
        var opType = _weighted.ChooseUniform(trafficOps, rng);

        // â”€â”€ Vessel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        var vessel     = SelectVessel(project, rng, route, thread);
        var vesselClass = vessel != null
            ? project.VesselClasses.FirstOrDefault(vc => vc.Id == vessel.VesselClassId)
            : null;

        // â”€â”€ Dock â€” filtered to hub station â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        var dockCandidates = DocksForStation(project, hub?.Id);
        var dock = _weighted.ChooseUniform(dockCandidates, rng);

        // â”€â”€ Purpose â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        string? purposeId  = SelectPurpose(project, rng, route, hub);
        var     purposeDef = purposeId != null
            ? project.Purposes.FirstOrDefault(p => p.Id == purposeId)
            : null;

        // â”€â”€ Populate structural / location fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        entry.StationId       = hub?.Id;
        entry.DockId          = dock?.Id;
        entry.VesselId        = vessel?.Id;
        entry.OperationTypeId = opType?.Id;
        entry.DeclaredPurposeId = purposeId;

        // Route endpoints based on op type direction
        if (route != null)
        {
            bool requiresOrigin      = opType?.RequiresOrigin      == true;
            bool requiresDestination = opType?.RequiresDestination == true;

            string farStation = route.FromStationId == hub?.Id
                ? route.ToStationId
                : route.FromStationId;

            if (requiresOrigin && !requiresDestination)
            {
                entry.OriginStationId = farStation;
            }
            else if (requiresDestination && !requiresOrigin)
            {
                entry.DestinationStationId = farStation;
            }
            else if (requiresOrigin && requiresDestination)
            {
                entry.OriginStationId      = route.FromStationId;
                entry.DestinationStationId = route.ToStationId;
            }

            if (!string.IsNullOrEmpty(route.RouteConditionTemplateId))
                entry.RouteStatusPhraseTemplateId = route.RouteConditionTemplateId;
        }

        // â”€â”€ Ordinary status fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        entry.ManifestStatusId          = SelectManifestStatus(project, rng);
        entry.InspectionStatusId        = SelectInspectionStatus(project, rng);
        entry.ClearanceStatusId         = SelectClearanceStatus(project, rng);
        entry.EnvironmentalConditionId  = SelectEnvironmentalCondition(project, rng);

        // â”€â”€ Cargo and passengers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        entry.DeclaredCargo      = SelectCargo(project, rng, vesselClass, route, purposeDef);
        entry.DeclaredPassengers = SelectPassengers(project, rng, vesselClass);

        // â”€â”€ Apply story beat (overrides relevant ordinary fields) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (thread != null && beat != null)
        {
            entry.StoryThreadId              = thread.Id;
            entry.AppliedStoryBeatId         = beat.Id;
            entry.AnomalySeverity            = beat.Severity;

            // Beat stamps override ordinarily generated statuses/phrases.
            // Null values from the beat are intentional (e.g. stage 6 silent arrival).
            entry.ManifestStatusId           = beat.PublicManifestStatusId;
            entry.InspectionStatusId         = beat.PublicInspectionStatusId;
            entry.DirectiveId                = beat.PublicDirectiveId;
            entry.IncidentPhraseTemplateId   = beat.IncidentPhraseTemplateId;
            entry.ResolutionPhraseTemplateId = beat.ResolutionPhraseTemplateId;

            // Only advance thread state in simulation mode
            if (options.AdvanceStory)
                _progression.AdvanceThread(thread, beat);
        }

        return entry;
    }

    // â”€â”€ Status selection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Always returns a manifest status ID. 85% chance of a non-irregular status.
    /// </summary>
    private string? SelectManifestStatus(PodcastProject project, Random rng)
    {
        var all = project.ManifestStatuses.Where(s => s.IsEnabled).ToList();
        if (all.Count == 0) return null;

        if (_weighted.Chance(0.85, rng))
        {
            var ordinary = all.Where(s => !s.ImpliesIrregularity).ToList();
            if (ordinary.Count > 0)
                return _weighted.ChooseUniform(ordinary, rng)?.Id;
        }

        return _weighted.ChooseUniform(all, rng)?.Id;
    }

    /// <summary>
    /// 60% chance of returning an inspection status. Prefers non-concern statuses.
    /// </summary>
    private string? SelectInspectionStatus(PodcastProject project, Random rng)
    {
        if (!_weighted.Chance(0.6, rng)) return null;

        var all = project.InspectionStatuses.Where(s => s.IsEnabled).ToList();
        if (all.Count == 0) return null;

        var ordinary = all.Where(s => !s.ImpliesConcern).ToList();
        return ordinary.Count > 0
            ? _weighted.ChooseUniform(ordinary, rng)?.Id
            : _weighted.ChooseUniform(all, rng)?.Id;
    }

    /// <summary>
    /// Always returns a clearance status ID. Prefers terminal-state statuses.
    /// </summary>
    private string? SelectClearanceStatus(PodcastProject project, Random rng)
    {
        var all = project.ClearanceStatuses.Where(s => s.IsEnabled).ToList();
        if (all.Count == 0) return null;

        var terminal = all.Where(s => s.IsTerminalState).ToList();
        return terminal.Count > 0
            ? _weighted.ChooseUniform(terminal, rng)?.Id
            : _weighted.ChooseUniform(all, rng)?.Id;
    }

    /// <summary>
    /// 20% chance of returning an environmental condition ID.
    /// </summary>
    private string? SelectEnvironmentalCondition(PodcastProject project, Random rng)
    {
        if (!_weighted.Chance(0.2, rng)) return null;

        var all = project.EnvironmentalConditions.Where(c => c.IsEnabled).ToList();
        return all.Count > 0 ? _weighted.ChooseUniform(all, rng)?.Id : null;
    }

    // â”€â”€ Cargo and passenger selection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Returns one declared cargo line if the vessel class can carry cargo.
    /// Commodity is chosen via purpose â†’ route â†’ vessel class category â†’ any.
    /// Returns an empty list if no cargo is appropriate.
    /// </summary>
    private List<EntryCargoLine> SelectCargo(
        PodcastProject        project,
        Random                rng,
        VesselClassDefinition? vesselClass,
        RouteRecord?           route,
        PurposeDefinition?     purpose)
    {
        if (vesselClass == null || !vesselClass.CanCarryCargo)
            return new List<EntryCargoLine>();

        // 75% chance to include cargo even when vessel can carry it
        if (!_weighted.Chance(0.75, rng))
            return new List<EntryCargoLine>();

        // Candidates: enabled, not contraband
        var candidates = project.Commodities
            .Where(c => !c.IsContraband)
            .ToList();

        if (candidates.Count == 0)
            return new List<EntryCargoLine>();

        // Filter by vessel class typical categories if specified
        if (vesselClass.TypicalCommodityCategoryIds.Count > 0)
        {
            var classFiltered = candidates
                .Where(c => vesselClass.TypicalCommodityCategoryIds.Contains(c.CommodityCategoryId))
                .ToList();
            if (classFiltered.Count > 0)
                candidates = classFiltered;
        }

        // Pick commodity: purpose typical â†’ route typical â†’ any filtered candidate
        CommodityRecord? commodity = null;

        if (purpose?.TypicalCommodityIds.Count > 0)
        {
            var purposeMatch = candidates
                .Where(c => purpose.TypicalCommodityIds.Contains(c.Id))
                .ToList();
            if (purposeMatch.Count > 0)
                commodity = _weighted.ChooseUniform(purposeMatch, rng);
        }

        if (commodity == null && route?.TypicalCommodityIds.Count > 0)
        {
            var routeMatch = candidates
                .Where(c => route.TypicalCommodityIds.Contains(c.Id))
                .ToList();
            if (routeMatch.Count > 0)
                commodity = _weighted.ChooseUniform(routeMatch, rng);
        }

        commodity ??= _weighted.ChooseUniform(candidates, rng);

        if (commodity == null)
            return new List<EntryCargoLine>();

        int min = commodity.TypicalMinQuantity;
        int max = commodity.TypicalMaxQuantity;
        if (max <= min) { min = 10; max = 100; }

        return new List<EntryCargoLine>
        {
            new EntryCargoLine
            {
                CommodityId      = commodity.Id,
                Quantity         = rng.Next(min, max + 1),
                IsDeclared       = true,
                IsHiddenTruthOnly = false
            }
        };
    }

    /// <summary>
    /// Returns one declared passenger line if the vessel class can carry passengers.
    /// Count is drawn from VesselClassDefinition.TypicalPassengerMin/Max.
    /// Returns an empty list if no passengers are appropriate.
    /// </summary>
    private List<EntryPassengerLine> SelectPassengers(
        PodcastProject        project,
        Random                rng,
        VesselClassDefinition? vesselClass)
    {
        if (vesselClass == null || !vesselClass.CanCarryPassengers)
            return new List<EntryPassengerLine>();

        // 70% chance to include passengers when vessel class allows it
        if (!_weighted.Chance(0.7, rng))
            return new List<EntryPassengerLine>();

        var categories = project.PassengerCategories
            .Where(c => c.IsEnabled)
            .ToList();

        if (categories.Count == 0)
            return new List<EntryPassengerLine>();

        var category = _weighted.ChooseUniform(categories, rng);
        if (category == null)
            return new List<EntryPassengerLine>();

        int min = vesselClass.TypicalPassengerMin;
        int max = vesselClass.TypicalPassengerMax;
        if (max <= min) { min = 1; max = 12; }

        return new List<EntryPassengerLine>
        {
            new EntryPassengerLine
            {
                PassengerCategoryId = category.Id,
                Count               = rng.Next(min, max + 1),
                IsDeclared          = true,
                IsHiddenTruthOnly   = false
            }
        };
    }

    // â”€â”€ Selection helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Returns the station that appears most frequently as a route endpoint.
    /// Falls back to the first station if no routes exist.
    /// </summary>
    private static StationRecord? FindHubStation(PodcastProject project)
    {
        if (project.Stations.Count == 0) return null;
        if (project.Routes.Count == 0)   return project.Stations[0];

        var counts = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (var r in project.Routes)
        {
            counts.TryAdd(r.FromStationId, 0);
            counts.TryAdd(r.ToStationId,   0);
            counts[r.FromStationId]++;
            counts[r.ToStationId]++;
        }

        string hubId = counts.OrderByDescending(kv => kv.Value).First().Key;
        return project.Stations.FirstOrDefault(s => s.Id == hubId);
    }

    /// <summary>
    /// Returns docks for the given station, preferring non-suspended ones.
    /// Falls back progressively: suspended at station â†’ non-suspended anywhere â†’ all docks.
    /// </summary>
    private static List<DockRecord> DocksForStation(PodcastProject project, string? stationId)
    {
        if (string.IsNullOrEmpty(stationId))
        {
            var any = project.Docks.Where(d => !d.IsSuspended).ToList();
            return any.Count > 0 ? any : project.Docks.ToList();
        }

        var atStation    = project.Docks.Where(d => d.StationId == stationId).ToList();
        var notSuspended = atStation.Where(d => !d.IsSuspended).ToList();

        if (notSuspended.Count > 0) return notSuspended;
        if (atStation.Count > 0)    return atStation;

        // Station has no docks â€” global fallback
        var globalOk = project.Docks.Where(d => !d.IsSuspended).ToList();
        return globalOk.Count > 0 ? globalOk : project.Docks.ToList();
    }

    private RouteRecord? SelectRoute(
        PodcastProject     project,
        Random             rng,
        StationRecord?     hub,
        StoryThreadRecord? thread)
    {
        if (project.Routes.Count == 0) return null;

        var candidates = hub != null
            ? project.Routes
                .Where(r => r.FromStationId == hub.Id || r.ToStationId == hub.Id)
                .ToList()
            : project.Routes.ToList();

        if (candidates.Count == 0)
            candidates = project.Routes.ToList();

        // Bias toward preferred routes of the thread's target vessel
        if (thread?.EntityKind == ThreadEntityKind.Vessel &&
            !string.IsNullOrEmpty(thread.TargetEntityId))
        {
            var vessel = project.Vessels.FirstOrDefault(v => v.Id == thread.TargetEntityId);
            if (vessel?.PreferredRouteIds.Count > 0)
            {
                var preferred = candidates
                    .Where(r => vessel.PreferredRouteIds.Contains(r.Id))
                    .ToList();
                if (preferred.Count > 0)
                    candidates = preferred;
            }
        }

        var weighted = candidates
            .Select(r => (r, r.FrequencyWeight > 0 ? r.FrequencyWeight : 1.0))
            .ToList();

        return _weighted.Choose(weighted, rng);
    }

    private VesselRecord? SelectVessel(
        PodcastProject     project,
        Random             rng,
        RouteRecord?       route,
        StoryThreadRecord? thread)
    {
        if (project.Vessels.Count == 0) return null;

        // Thread targets a specific vessel â€” use it directly
        if (thread?.EntityKind == ThreadEntityKind.Vessel &&
            !string.IsNullOrEmpty(thread.TargetEntityId))
        {
            var target = project.Vessels.FirstOrDefault(v => v.Id == thread.TargetEntityId);
            if (target != null) return target;
        }

        var candidates = project.Vessels.ToList();

        // Plausibility: filter by vessel class allowed on route
        if (route?.AllowedVesselClassIds.Count > 0)
        {
            var classFiltered = candidates
                .Where(v => route.AllowedVesselClassIds.Contains(v.VesselClassId))
                .ToList();
            if (classFiltered.Count > 0)
                candidates = classFiltered;
        }

        // Prefer vessels with this route in their preferred list
        if (route != null)
        {
            var preferred = candidates
                .Where(v => v.PreferredRouteIds.Contains(route.Id))
                .ToList();
            if (preferred.Count > 0)
                return _weighted.ChooseUniform(preferred, rng);
        }

        return _weighted.ChooseUniform(candidates, rng);
    }

    /// <summary>
    /// Selects a purpose ID weighted toward the intersection of station and route typical
    /// purposes. Falls back progressively: intersection â†’ station â†’ route â†’ any enabled.
    /// </summary>
    private string? SelectPurpose(
        PodcastProject project,
        Random         rng,
        RouteRecord?   route,
        StationRecord? hub)
    {
        var enabled = project.Purposes.Where(p => p.IsEnabled).ToList();
        if (enabled.Count == 0) return null;

        var stationIds = hub?.PurposeIds            ?? new List<string>();
        var routeIds   = route?.TypicalPurposeIds   ?? new List<string>();

        // Intersection of station + route purposes
        if (stationIds.Count > 0 && routeIds.Count > 0)
        {
            var intersection = enabled
                .Where(p => stationIds.Contains(p.Id) && routeIds.Contains(p.Id))
                .ToList();
            if (intersection.Count > 0)
                return _weighted.ChooseUniform(intersection, rng)?.Id;
        }

        // Station purposes alone
        if (stationIds.Count > 0)
        {
            var stationPurposes = enabled.Where(p => stationIds.Contains(p.Id)).ToList();
            if (stationPurposes.Count > 0)
                return _weighted.ChooseUniform(stationPurposes, rng)?.Id;
        }

        // Route purposes alone
        if (routeIds.Count > 0)
        {
            var routePurposes = enabled.Where(p => routeIds.Contains(p.Id)).ToList();
            if (routePurposes.Count > 0)
                return _weighted.ChooseUniform(routePurposes, rng)?.Id;
        }

        return _weighted.ChooseUniform(enabled, rng)?.Id;
    }
}

```n---


### File: PodcastUniverseEditor\Services\Generation\GenerationOptions.cs
```csharp

namespace PodcastUniverseEditor.Services.Generation;

/// <summary>
/// Determines whether a generation call may mutate story thread state.
/// Every public entry point in EpisodeGenerationService must explicitly choose a mode â€”
/// there is no implicit behaviour based on call path.
/// </summary>
/// <remarks>
/// <b>Simulation mode</b> (AdvanceStory = true): used by FillEpisode only.
/// Advances CurrentStageIndex and resets EpisodesUntilEligible on threads.
/// Represents real narrative progression â€” call once per episode, not per entry.
///
/// <b>Editing mode</b> (AdvanceStory = false): used by GenerateEntry, GenerateEntries,
/// and single-entry regeneration. Peeks at threads without mutating them.
/// Safe to call any number of times without changing story state.
/// Repeating the same call produces the same result.
/// </remarks>
public readonly struct GenerationOptions
{
    /// <summary>
    /// When true, beating a thread advances its CurrentStageIndex and resets its cooldown.
    /// When false, threads are peeked for preview only â€” no story state is modified.
    /// </summary>
    public bool AdvanceStory { get; init; }

    /// <summary>Non-mutating editing mode. Threads are peeked but never advanced.</summary>
    public static readonly GenerationOptions Editing    = new() { AdvanceStory = false };

    /// <summary>Authoritative simulation mode. Applied beats advance the thread.</summary>
    public static readonly GenerationOptions Simulation = new() { AdvanceStory = true };
}

```n---


### File: PodcastUniverseEditor\Services\Generation\StoryThreadProgressionService.cs
```csharp


namespace PodcastUniverseEditor.Services.Generation;

/// <summary>
/// Decides which story thread (if any) should be applied to a generated entry,
/// and advances the thread's stage index when a beat is applied.
/// Stateless â€” all mutable state lives on the thread records in the project.
/// </summary>
public class StoryThreadProgressionService
{
    // â”€â”€ Public API â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Returns all threads that are currently eligible to be applied.
    /// Eligibility criteria:
    ///   â€¢ IsActive = true
    ///   â€¢ EpisodesUntilEligible = 0
    ///   â€¢ There is a next beat (CurrentStageIndex + 1 &lt; Beats.Count)
    /// Beats are matched by StageIndex, not list position.
    /// </summary>
    public IReadOnlyList<StoryThreadRecord> EligibleThreads(PodcastProject project)
    {
        return project.StoryThreads
            .Where(t => IsEligible(t))
            .ToList();
    }

    /// <summary>
    /// Returns the next beat for the given thread (the beat whose StageIndex = CurrentStageIndex + 1),
    /// or null if no such beat exists or the thread is not eligible.
    /// Does NOT advance the thread.
    /// </summary>
    public StoryBeatRecord? PeekNextBeat(StoryThreadRecord thread)
    {
        int nextStage = thread.CurrentStageIndex + 1;
        return thread.Beats.FirstOrDefault(b => b.StageIndex == nextStage);
    }

    /// <summary>
    /// Advances the thread's CurrentStageIndex to the applied beat's StageIndex
    /// and resets EpisodesUntilEligible to CooldownEpisodes.
    /// Call this after applying the beat to an entry.
    /// </summary>
    public void AdvanceThread(StoryThreadRecord thread, StoryBeatRecord beat)
    {
        thread.CurrentStageIndex = beat.StageIndex;
        thread.EpisodesUntilEligible = thread.CooldownEpisodes;
    }

    /// <summary>
    /// Decrements EpisodesUntilEligible for all threads by 1 (minimum 0).
    /// Call this once per episode generation cycle, after all entries for the episode
    /// have been produced, so cooldowns tick down correctly.
    /// </summary>
    public void TickCooldowns(PodcastProject project)
    {
        foreach (var thread in project.StoryThreads)
        {
            if (thread.EpisodesUntilEligible > 0)
                thread.EpisodesUntilEligible--;
        }
    }

    /// <summary>
    /// Returns the target entity ID for the thread, used by the generator to bias
    /// vessel/route selection toward the thread's target entity.
    /// </summary>
    public string? TargetEntityId(StoryThreadRecord thread) =>
        string.IsNullOrEmpty(thread.TargetEntityId) ? null : thread.TargetEntityId;

    // â”€â”€ Private helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private static bool IsEligible(StoryThreadRecord thread)
    {
        if (!thread.IsActive) return false;
        if (thread.EpisodesUntilEligible > 0) return false;
        int nextStage = thread.CurrentStageIndex + 1;
        return thread.Beats.Any(b => b.StageIndex == nextStage);
    }
}

```n---


### File: PodcastUniverseEditor\Services\Generation\WeightedRandomService.cs
```csharp

namespace PodcastUniverseEditor.Services.Generation;

/// <summary>
/// Selects items from weighted collections using a caller-supplied Random instance.
/// All methods are deterministic given the same Random state.
/// </summary>
public class WeightedRandomService
{
    // â”€â”€ Public API â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Selects one item from a weighted list.
    /// Each item is a (value, weight) pair; weight must be > 0.
    /// Returns the default of T if the list is empty.
    /// </summary>
    public T? Choose<T>(IReadOnlyList<(T item, double weight)> candidates, Random rng)
    {
        if (candidates.Count == 0) return default;

        double total = 0;
        foreach (var (_, w) in candidates)
            total += w;

        double roll = rng.NextDouble() * total;
        double cumulative = 0;

        foreach (var (item, weight) in candidates)
        {
            cumulative += weight;
            if (roll < cumulative)
                return item;
        }

        // Floating-point edge: return last
        return candidates[^1].item;
    }

    /// <summary>
    /// Selects one item from an unweighted list with uniform probability.
    /// Returns the default of T if the list is empty.
    /// </summary>
    public T? ChooseUniform<T>(IReadOnlyList<T> candidates, Random rng)
    {
        if (candidates.Count == 0) return default;
        return candidates[rng.Next(candidates.Count)];
    }

    /// <summary>
    /// Returns true with the given probability (0.0â€“1.0).
    /// </summary>
    public bool Chance(double probability, Random rng) => rng.NextDouble() < probability;

    /// <summary>
    /// Creates a Random seeded with the provided value, or uses a random seed if null.
    /// </summary>
    public static Random CreateRandom(int? seed) =>
        seed.HasValue ? new Random(seed.Value) : new Random();
}

```n---


### File: PodcastUniverseEditor\Services\Lookup\ProjectLookupService.cs
```csharp


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

    // â”€â”€ Name resolution â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

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

    // â”€â”€ ComboBox list builders â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

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
    public List<LookupItem> SeriesAsLookup()                => ToLookup(_project.Series);

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

    // â”€â”€ Object lookups â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

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

    // â”€â”€ Private helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

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

```n---


### File: PodcastUniverseEditor\Services\Persistence\ProjectFileService.cs
```csharp


namespace PodcastUniverseEditor.Services.Persistence;

/// <summary>
/// Handles loading, saving, and creating PodcastProject instances as
/// *.podcastworld.json files using System.Text.Json.
/// </summary>
public class ProjectFileService
{
    public const string FileExtension = ".podcastworld.json";
    public const string FileFilter = "Podcast World files (*.podcastworld.json)|*.podcastworld.json|All files (*.*)|*.*";

    private static readonly JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        Converters = { new JsonStringEnumConverter() }
    };

    /// <summary>
    /// Serialises the project to a JSON file at the given path.
    /// Updates ModifiedUtc before writing.
    /// </summary>
    public void Save(string filePath, PodcastProject project)
    {
        project.ModifiedUtc = DateTime.UtcNow;
        string json = JsonSerializer.Serialize(project, _serializerOptions);
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Deserialises a project from a JSON file. Throws if the file cannot be parsed.
    /// Callers should handle IOException and JsonException.
    /// </summary>
    public PodcastProject Load(string filePath)
    {
        string json = File.ReadAllText(filePath);
        PodcastProject? project = JsonSerializer.Deserialize<PodcastProject>(json, _serializerOptions);
        return project ?? throw new InvalidDataException($"Failed to deserialise project from {filePath}");
    }

    /// <summary>
    /// Creates a blank, unsaved project with default metadata.
    /// </summary>
    public PodcastProject CreateNewProject()
    {
        return new PodcastProject
        {
            ProjectName = "New Podcast World",
            Description = string.Empty,
            CreatedUtc = DateTime.UtcNow,
            ModifiedUtc = DateTime.UtcNow,
            SchemaVersion = 1
        };
    }
}

```n---


### File: PodcastUniverseEditor\Services\Rendering\EntryRenderingService.cs
```csharp


namespace PodcastUniverseEditor.Services.Rendering;

/// <summary>
/// Renders EpisodeEntryRecord and EpisodeRecord instances to broadcast script text.
/// Deterministic and stateless â€” always pass the full project for reference data resolution.
/// Never exposes hidden truth fields (ActualCargo, ActualPassengers, ActualPurposeId,
/// HiddenTruthNotes). Uses only the public (declared) layer.
/// </summary>
public class EntryRenderingService
{
    // â”€â”€ Public API â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Renders a single entry to broadcast text.
    /// Returns a formatted multi-line string without a trailing newline.
    /// </summary>
    public string RenderEntry(PodcastProject project, EpisodeEntryRecord entry)
    {
        return entry.EntryKind == EntryKind.Traffic
            ? RenderTrafficEntry(project, entry)
            : RenderNoticeEntry(project, entry);
    }

    /// <summary>
    /// Renders all entries in an episode to a single script string, sorted by SortOrder.
    /// Includes an episode header line.
    /// </summary>
    public string RenderEpisode(PodcastProject project, EpisodeRecord episode)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"=== {episode.Name} ===");
        if (episode.InUniverseUtc.HasValue)
            sb.AppendLine(episode.InUniverseUtc.Value.ToString("yyyy-MM-dd HH:mm UTC"));

        var entries = episode.Entries.OrderBy(e => e.SortOrder).ToList();
        if (entries.Count == 0)
        {
            sb.Append("(no entries)");
            return sb.ToString();
        }

        sb.AppendLine("---");

        bool first = true;
        foreach (var entry in entries)
        {
            if (!first) sb.AppendLine();
            first = false;
            sb.AppendLine(RenderEntry(project, entry));
        }

        return sb.ToString().TrimEnd();
    }

    // â”€â”€ Traffic entry â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private string RenderTrafficEntry(PodcastProject p, EpisodeEntryRecord e)
    {
        var sb = new StringBuilder();
        var opts = e.RenderOptions;

        var station  = Find(p.Stations, e.StationId);
        var dock     = Find(p.Docks, e.DockId);
        var opType   = Find(p.OperationTypes, e.OperationTypeId);

        string stationName = station?.Name ?? string.Empty;
        string dockLabel   = dock != null
            ? (string.IsNullOrEmpty(dock.SpokenLabel) ? dock.Name : dock.SpokenLabel)
            : string.Empty;

        // â”€â”€ Header â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (opType != null && !string.IsNullOrEmpty(opType.HeaderFormat))
        {
            sb.AppendLine(SubstituteTokens(opType.HeaderFormat, stationName, dockLabel));
        }
        else
        {
            string fallback = string.IsNullOrEmpty(e.Name) ? "Traffic entry.--" : $"{e.Name}.--";
            sb.AppendLine(fallback);
        }

        // â”€â”€ Vessel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        var vessel = Find(p.Vessels, e.VesselId);
        if (vessel != null)
        {
            string registry = !string.IsNullOrEmpty(e.RegistryOverride)
                ? e.RegistryOverride
                : vessel.Registry;

            string vesselClassId = !string.IsNullOrEmpty(e.VesselClassOverrideId)
                ? e.VesselClassOverrideId
                : vessel.VesselClassId;
            var vesselClass = Find(p.VesselClasses, vesselClassId);
            string classNoun = vesselClass != null && !string.IsNullOrEmpty(vesselClass.SpokenNoun)
                ? vesselClass.SpokenNoun
                : vesselClass?.Name ?? string.Empty;

            var parts = new List<string> { $"Vessel {vessel.Name}" };
            if (!string.IsNullOrEmpty(registry))   parts.Add($"registry {registry}");
            if (!string.IsNullOrEmpty(classNoun))  parts.Add(classNoun);
            sb.AppendLine($"  {string.Join(", ", parts)}.--");
        }

        // â”€â”€ Route â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        var origin      = Find(p.Stations, e.OriginStationId);
        var destination = Find(p.Stations, e.DestinationStationId);

        if (origin != null)
            sb.AppendLine($"  Inbound from {origin.Name}.--");
        if (destination != null)
            sb.AppendLine($"  Outbound to {destination.Name}.--");

        // â”€â”€ Purpose â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (opts.IncludePurpose && e.DeclaredPurposeId != null)
        {
            var purpose = Find(p.Purposes, e.DeclaredPurposeId);
            if (purpose != null)
            {
                string purposeText = !string.IsNullOrEmpty(purpose.SpokenPhrase)
                    ? purpose.SpokenPhrase
                    : purpose.Name.ToLowerInvariant();
                sb.AppendLine($"  Declared purpose: {purposeText}.--");
            }
        }

        // â”€â”€ Cargo â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (opts.IncludeCargo)
        {
            var cargoLines = e.DeclaredCargo.Where(c => !c.IsHiddenTruthOnly).ToList();
            if (cargoLines.Count > 0)
            {
                var parts = cargoLines.Select(c =>
                {
                    var commodity = Find(p.Commodities, c.CommodityId);
                    string name = !string.IsNullOrEmpty(c.SpokenCommodityNameOverride)
                        ? c.SpokenCommodityNameOverride
                        : (commodity?.Name ?? "unknown commodity");
                    string unit = !string.IsNullOrEmpty(c.UnitLabelOverride)
                        ? c.UnitLabelOverride
                        : (commodity?.UnitLabel ?? "units");
                    return $"{c.Quantity} {unit} {name}";
                }).ToList();
                sb.AppendLine($"  Cargo: {string.Join(", ", parts)}.--");
            }
        }

        // â”€â”€ Passengers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (opts.IncludePassengers)
        {
            var paxLines = e.DeclaredPassengers.Where(px => !px.IsHiddenTruthOnly).ToList();
            if (paxLines.Count > 0)
            {
                var parts = paxLines.Select(px =>
                {
                    var cat = Find(p.PassengerCategories, px.PassengerCategoryId);
                    string catName = (cat != null && !string.IsNullOrEmpty(cat.SpokenLabel))
                        ? cat.SpokenLabel
                        : (cat?.Name ?? "passenger");
                    return $"{px.Count} {catName.ToLowerInvariant()}";
                }).ToList();
                sb.AppendLine($"  Passengers: {string.Join(", ", parts)}.--");
            }
        }

        // â”€â”€ Status phrases (grouped onto one line) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        var statusPhrases = new List<string>();

        if (opts.IncludeManifestStatus && e.ManifestStatusId != null)
        {
            var ms = Find(p.ManifestStatuses, e.ManifestStatusId);
            if (ms != null && !string.IsNullOrEmpty(ms.SpokenPhrase))
                statusPhrases.Add(ms.SpokenPhrase);
        }

        if (opts.IncludeInspectionStatus && e.InspectionStatusId != null)
        {
            var ins = Find(p.InspectionStatuses, e.InspectionStatusId);
            if (ins != null && !string.IsNullOrEmpty(ins.SpokenPhrase))
                statusPhrases.Add(ins.SpokenPhrase);
        }

        if (e.ClearanceStatusId != null)
        {
            var cs = Find(p.ClearanceStatuses, e.ClearanceStatusId);
            if (cs != null && !string.IsNullOrEmpty(cs.SpokenPhrase))
                statusPhrases.Add(cs.SpokenPhrase);
        }

        if (statusPhrases.Count > 0)
            sb.AppendLine("  " + string.Join(" ", statusPhrases));

        // â”€â”€ Environmental condition â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (opts.IncludeEnvironmentalStatus && e.EnvironmentalConditionId != null)
        {
            var env = Find(p.EnvironmentalConditions, e.EnvironmentalConditionId);
            if (env != null && !string.IsNullOrEmpty(env.SpokenPhrase))
                sb.AppendLine($"  {env.SpokenPhrase}");
        }

        // â”€â”€ Directive â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (e.DirectiveId != null)
        {
            var dir = Find(p.Directives, e.DirectiveId);
            if (dir != null && !string.IsNullOrEmpty(dir.SpokenPhrase))
                sb.AppendLine($"  {dir.SpokenPhrase}");
        }

        // â”€â”€ Phrase overlays â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (e.IncidentPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.IncidentPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {SubstituteTokens(pt.TemplateText, stationName, dockLabel)}");
        }

        if (e.RouteStatusPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.RouteStatusPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {SubstituteTokens(pt.TemplateText, stationName, dockLabel)}");
        }

        if (opts.IncludeResolution && e.ResolutionPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.ResolutionPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {SubstituteTokens(pt.TemplateText, stationName, dockLabel)}");
        }

        return sb.ToString().TrimEnd();
    }

    // â”€â”€ Notice entry â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private string RenderNoticeEntry(PodcastProject p, EpisodeEntryRecord e)
    {
        var sb = new StringBuilder();
        var opts = e.RenderOptions;

        var noticeType = Find(p.NoticeTypes, e.NoticeTypeId);

        // â”€â”€ Header â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (noticeType != null && !string.IsNullOrEmpty(noticeType.HeaderText))
            sb.AppendLine(noticeType.HeaderText);
        else
            sb.AppendLine(string.IsNullOrEmpty(e.Name) ? "Notice.--" : $"{e.Name}.--");

        // â”€â”€ Body â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (!string.IsNullOrEmpty(e.PublicBodyOverride))
        {
            // Author-provided body overrides everything
            sb.AppendLine($"  {e.PublicBodyOverride}");
        }
        else if (noticeType != null && !string.IsNullOrEmpty(noticeType.DefaultBodyFormat))
        {
            string body = noticeType.DefaultBodyFormat.Replace("{Detail}", e.Name);
            sb.AppendLine($"  {body}");
        }
        else if (!string.IsNullOrEmpty(e.Name))
        {
            sb.AppendLine($"  {e.Name}");
        }

        // â”€â”€ Phrase overlays â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (e.IncidentPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.IncidentPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {pt.TemplateText}");
        }

        if (opts.IncludeResolution && e.ResolutionPhraseTemplateId != null)
        {
            var pt = Find(p.PhraseTemplates, e.ResolutionPhraseTemplateId);
            if (pt != null && !string.IsNullOrEmpty(pt.TemplateText))
                sb.AppendLine($"  {pt.TemplateText}");
        }

        return sb.ToString().TrimEnd();
    }

    // â”€â”€ Private helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Substitutes {Station} and {Dock} tokens with the resolved names.
    /// Unknown tokens are left as-is for future phases.
    /// </summary>
    private static string SubstituteTokens(string template, string stationName, string dockLabel)
        => template
            .Replace("{Station}", stationName)
            .Replace("{Dock}",    dockLabel);

    private static T? Find<T>(IEnumerable<T> collection, string? id) where T : EntityBase
    {
        if (string.IsNullOrEmpty(id)) return null;
        return collection.FirstOrDefault(x => x.Id == id);
    }
}

```n---


### File: PodcastUniverseEditor\Services\Seeds\ProjectSeedFactory.cs
```csharp


namespace PodcastUniverseEditor.Services.Seeds;

/// <summary>
/// Produces a fully populated starter PodcastProject with reference vocabulary,
/// a small universe, sample routes, and one seeded story thread for Wolfgang Amadeus.
/// All IDs are stable within a single call â€” cross-references are wired correctly.
/// </summary>
public class ProjectSeedFactory
{
    public PodcastProject CreateSampleProject()
    {
        var p = new PodcastProject
        {
            ProjectName = "Helios Gate Dispatch",
            Description = "A logistics and traffic broadcast from Helios Gate station.",
            SchemaVersion = 1,
            CreatedUtc = DateTime.UtcNow,
            ModifiedUtc = DateTime.UtcNow
        };

        SeedReferenceData(p);
        SeedWorld(p);
        SeedEpisodes(p);
        SeedStoryThreads(p);

        return p;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    // Reference data
    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void SeedReferenceData(PodcastProject p)
    {
        SeedBodyTypes(p);
        SeedOrganisationTypes(p);
        SeedStationTypes(p);
        SeedAuthorityTypes(p);
        SeedCommodityCategories(p);
        SeedPassengerCategories(p);
        SeedVesselClasses(p);
        SeedOperationTypes(p);
        SeedPurposes(p);
        SeedManifestStatuses(p);
        SeedInspectionStatuses(p);
        SeedClearanceStatuses(p);
        SeedEnvironmentalConditions(p);
        SeedNoticeTypes(p);
        SeedPhraseTemplates(p);
        SeedAnomalyTypes(p);
        SeedDirectives(p);
    }

    private void SeedBodyTypes(PodcastProject p)
    {
        p.BodyTypes.AddRange(new[]
        {
            Ref<BodyTypeDefinition>("bt-planet",   "Planet",        d => d.SpokenLabel = "planet"),
            Ref<BodyTypeDefinition>("bt-moon",     "Moon",          d => d.SpokenLabel = "moon"),
            Ref<BodyTypeDefinition>("bt-belt",     "Asteroid Belt", d => d.SpokenLabel = "asteroid belt"),
            Ref<BodyTypeDefinition>("bt-orbital",  "Orbital Body",  d => d.SpokenLabel = "orbital body"),
        });
    }

    private void SeedOrganisationTypes(PodcastProject p)
    {
        p.OrganisationTypes.AddRange(new[]
        {
            Ref<OrganisationTypeDefinition>("ot-shipping",  "Shipping Company",  d => d.SpokenLabel = "shipping company"),
            Ref<OrganisationTypeDefinition>("ot-authority", "Port Authority",     d => d.SpokenLabel = "port authority"),
            Ref<OrganisationTypeDefinition>("ot-coop",      "Cooperative",        d => d.SpokenLabel = "cooperative"),
            Ref<OrganisationTypeDefinition>("ot-military",  "Military",           d => d.SpokenLabel = "military"),
            Ref<OrganisationTypeDefinition>("ot-research",  "Research Institute", d => d.SpokenLabel = "research institute"),
        });
    }

    private void SeedStationTypes(PodcastProject p)
    {
        p.StationTypes.AddRange(new[]
        {
            Ref<StationTypeDefinition>("st-outpost",    "Outpost",          d => d.SpokenLabel = "outpost"),
            Ref<StationTypeDefinition>("st-orbital",    "Orbital Station",  d => d.SpokenLabel = "orbital station"),
            Ref<StationTypeDefinition>("st-shipyard",   "Shipyard",         d => d.SpokenLabel = "shipyard"),
            Ref<StationTypeDefinition>("st-mining",     "Mining Platform",  d => d.SpokenLabel = "mining platform"),
            Ref<StationTypeDefinition>("st-agri",       "Agricultural Hub", d => d.SpokenLabel = "agricultural hub"),
            Ref<StationTypeDefinition>("st-research",   "Research Platform",d => d.SpokenLabel = "research platform"),
        });
    }

    private void SeedAuthorityTypes(PodcastProject p)
    {
        p.AuthorityTypes.AddRange(new[]
        {
            Ref<AuthorityTypeDefinition>("at-customs",  "Customs",       d => d.SpokenLabel = "customs"),
            Ref<AuthorityTypeDefinition>("at-port",     "Port Authority", d => d.SpokenLabel = "port authority"),
            Ref<AuthorityTypeDefinition>("at-security", "Security",      d => d.SpokenLabel = "security"),
        });
    }

    private void SeedCommodityCategories(PodcastProject p)
    {
        p.CommodityCategories.AddRange(new[]
        {
            Ref<CommodityCategoryDefinition>("cc-industrial",  "Industrial",       d => d.SpokenLabel = "industrial"),
            Ref<CommodityCategoryDefinition>("cc-agricultural","Agricultural",      d => d.SpokenLabel = "agricultural"),
            Ref<CommodityCategoryDefinition>("cc-medical",     "Medical",           d => d.SpokenLabel = "medical"),
            Ref<CommodityCategoryDefinition>("cc-fuel",        "Fuel",              d => d.SpokenLabel = "fuel"),
            Ref<CommodityCategoryDefinition>("cc-luxury",      "Luxury",            d => d.SpokenLabel = "luxury"),
            Ref<CommodityCategoryDefinition>("cc-restricted",  "Restricted",        d => d.SpokenLabel = "restricted"),
            Ref<CommodityCategoryDefinition>("cc-military",    "Military Dual-Use", d => d.SpokenLabel = "military dual-use"),
        });
    }

    private void SeedPassengerCategories(PodcastProject p)
    {
        p.PassengerCategories.AddRange(new[]
        {
            Ref<PassengerCategoryDefinition>("pc-civilian",    "Civilian",           d => d.SpokenLabel = "civilian passengers"),
            Ref<PassengerCategoryDefinition>("pc-technical",   "Technical Personnel",d => d.SpokenLabel = "technical personnel"),
            Ref<PassengerCategoryDefinition>("pc-crew",        "Crew Rotation",      d => d.SpokenLabel = "crew rotation"),
            Ref<PassengerCategoryDefinition>("pc-diplomatic",  "Diplomatic Liaison", d => d.SpokenLabel = "diplomatic liaison"),
            Ref<PassengerCategoryDefinition>("pc-security",    "Security Detail",    d => d.SpokenLabel = "security detail"),
            Ref<PassengerCategoryDefinition>("pc-unspecified", "Unspecified",        d => d.SpokenLabel = "unspecified passengers"),
        });
    }

    private void SeedVesselClasses(PodcastProject p)
    {
        p.VesselClasses.AddRange(new[]
        {
            Ref<VesselClassDefinition>("vc-bulk", "Bulk Carrier", d => {
                d.SpokenNoun = "bulk carrier";
                d.CanCarryCargo = true;
                d.CanCarryPassengers = false;
                d.TypicalCommodityCategoryIds = new() { "cc-industrial", "cc-agricultural" };
                d.TypicalPassengerMin = 0; d.TypicalPassengerMax = 0;
            }),
            Ref<VesselClassDefinition>("vc-freighter", "Freighter", d => {
                d.SpokenNoun = "freighter";
                d.CanCarryCargo = true;
                d.CanCarryPassengers = false;
                d.TypicalCommodityCategoryIds = new() { "cc-industrial", "cc-agricultural", "cc-medical" };
            }),
            Ref<VesselClassDefinition>("vc-courier", "Courier", d => {
                d.SpokenNoun = "courier vessel";
                d.CanCarryCargo = true;
                d.CanCarryPassengers = true;
                d.TypicalCommodityCategoryIds = new() { "cc-restricted", "cc-luxury" };
                d.TypicalPassengerMin = 1; d.TypicalPassengerMax = 6;
            }),
            Ref<VesselClassDefinition>("vc-tanker", "Tanker", d => {
                d.SpokenNoun = "tanker";
                d.CanCarryCargo = true;
                d.CanCarryPassengers = false;
                d.TypicalCommodityCategoryIds = new() { "cc-fuel", "cc-industrial" };
            }),
            Ref<VesselClassDefinition>("vc-personnel", "Personnel Transport", d => {
                d.SpokenNoun = "personnel transport";
                d.CanCarryCargo = false;
                d.CanCarryPassengers = true;
                d.TypicalPassengerMin = 20; d.TypicalPassengerMax = 200;
            }),
            Ref<VesselClassDefinition>("vc-maintenance", "Maintenance Vessel", d => {
                d.SpokenNoun = "maintenance vessel";
                d.CanCarryCargo = true;
                d.CanCarryPassengers = true;
                d.TypicalCommodityCategoryIds = new() { "cc-industrial" };
                d.TypicalPassengerMin = 0; d.TypicalPassengerMax = 12;
            }),
            Ref<VesselClassDefinition>("vc-survey", "Survey Craft", d => {
                d.SpokenNoun = "survey craft";
                d.CanCarryCargo = false;
                d.CanCarryPassengers = true;
                d.TypicalPassengerMin = 2; d.TypicalPassengerMax = 8;
            }),
        });
    }

    private void SeedOperationTypes(PodcastProject p)
    {
        p.OperationTypes.AddRange(new[]
        {
            Ref<OperationTypeDefinition>("op-arrival", "Arrival", d => {
                d.HeaderFormat = "Arrival at {Dock}.--";
                d.RequiresOrigin = true;
                d.RequiresDestination = false;
                d.IsTrafficOperation = true;
            }),
            Ref<OperationTypeDefinition>("op-departure", "Departure", d => {
                d.HeaderFormat = "Departure from {Dock}.--";
                d.RequiresOrigin = false;
                d.RequiresDestination = true;
                d.IsTrafficOperation = true;
            }),
            Ref<OperationTypeDefinition>("op-transfer", "Transfer", d => {
                d.HeaderFormat = "Transfer at {Dock}.--";
                d.RequiresOrigin = true;
                d.RequiresDestination = true;
                d.IsTrafficOperation = true;
            }),
            Ref<OperationTypeDefinition>("op-sched-arrival", "Scheduled Arrival", d => {
                d.HeaderFormat = "Scheduled arrival at {Dock}.--";
                d.RequiresOrigin = true;
                d.RequiresDestination = false;
                d.IsTrafficOperation = true;
            }),
            Ref<OperationTypeDefinition>("op-holding", "Holding Pattern", d => {
                d.HeaderFormat = "Holding pattern notation â€” {Station}.--";
                d.RequiresOrigin = false;
                d.RequiresDestination = false;
                d.IsTrafficOperation = false;
            }),
        });
    }

    private void SeedPurposes(PodcastProject p)
    {
        p.Purposes.AddRange(new[]
        {
            Ref<PurposeDefinition>("pu-ore",        "Ore Transfer",           d => { d.SpokenPhrase = "ore transfer"; d.TypicalCommodityCategoryIds = new() { "cc-industrial" }; d.TypicalVesselClassIds = new() { "vc-bulk" }; }),
            Ref<PurposeDefinition>("pu-fuel",       "Fuel Delivery",          d => { d.SpokenPhrase = "fuel delivery"; d.TypicalCommodityCategoryIds = new() { "cc-fuel" }; d.TypicalVesselClassIds = new() { "vc-tanker" }; }),
            Ref<PurposeDefinition>("pu-crew",       "Crew Rotation",          d => { d.SpokenPhrase = "crew rotation"; d.TypicalVesselClassIds = new() { "vc-personnel" }; }),
            Ref<PurposeDefinition>("pu-maint",      "Maintenance Resupply",   d => { d.SpokenPhrase = "maintenance resupply"; d.TypicalCommodityCategoryIds = new() { "cc-industrial" }; d.TypicalVesselClassIds = new() { "vc-maintenance", "vc-freighter" }; }),
            Ref<PurposeDefinition>("pu-diplomatic", "Diplomatic Courier Service", d => { d.SpokenPhrase = "diplomatic courier service"; d.TypicalVesselClassIds = new() { "vc-courier" }; }),
            Ref<PurposeDefinition>("pu-agri",       "Agricultural Delivery",  d => { d.SpokenPhrase = "agricultural delivery"; d.TypicalCommodityCategoryIds = new() { "cc-agricultural" }; d.TypicalVesselClassIds = new() { "vc-bulk", "vc-freighter" }; }),
            Ref<PurposeDefinition>("pu-internal",   "Internal Transfer",      d => d.SpokenPhrase = "internal transfer"),
            Ref<PurposeDefinition>("pu-survey",     "Survey Return",          d => { d.SpokenPhrase = "survey return"; d.TypicalVesselClassIds = new() { "vc-survey" }; }),
            Ref<PurposeDefinition>("pu-salvage",    "Salvage Processing",     d => { d.SpokenPhrase = "salvage processing"; d.TypicalCommodityCategoryIds = new() { "cc-industrial" }; }),
            Ref<PurposeDefinition>("pu-customs",    "Customs Hold Release",   d => d.SpokenPhrase = "customs hold release"),
        });
    }

    private void SeedManifestStatuses(PodcastProject p)
    {
        p.ManifestStatuses.AddRange(new[]
        {
            Ref<ManifestStatusDefinition>("ms-verified",    "Manifest Verified",    d => { d.SpokenPhrase = "Manifest verified.--"; d.ImpliesIrregularity = false; }),
            Ref<ManifestStatusDefinition>("ms-pending",     "Verification Pending", d => { d.SpokenPhrase = "Manifest verification pending.--"; d.ImpliesIrregularity = true; }),
            Ref<ManifestStatusDefinition>("ms-amended",     "Amended Prior",        d => { d.SpokenPhrase = "Manifest amended prior to departure.--"; d.ImpliesIrregularity = true; }),
            Ref<ManifestStatusDefinition>("ms-incomplete",  "Declaration Incomplete",d => { d.SpokenPhrase = "Declaration incomplete.--"; d.ImpliesIrregularity = true; }),
            Ref<ManifestStatusDefinition>("ms-discrepancy", "Discrepancy Noted",    d => { d.SpokenPhrase = "Manifest discrepancy noted.--"; d.ImpliesIrregularity = true; }),
        });
    }

    private void SeedInspectionStatuses(PodcastProject p)
    {
        p.InspectionStatuses.AddRange(new[]
        {
            Ref<InspectionStatusDefinition>("is-none",     "No Inspection",       d => { d.SpokenPhrase = "No inspection required.--"; d.ImpliesInspection = false; d.ImpliesConcern = false; }),
            Ref<InspectionStatusDefinition>("is-random",   "Random Inspection",   d => { d.SpokenPhrase = "Random inspection assigned.--"; d.ImpliesInspection = true; d.ImpliesConcern = false; }),
            Ref<InspectionStatusDefinition>("is-complete", "Inspection Completed",d => { d.SpokenPhrase = "Inspection completed.--"; d.ImpliesInspection = true; d.ImpliesConcern = false; }),
            Ref<InspectionStatusDefinition>("is-deferred", "Inspection Deferred", d => { d.SpokenPhrase = "Inspection deferred.--"; d.ImpliesInspection = false; d.ImpliesConcern = true; }),
            Ref<InspectionStatusDefinition>("is-customs",  "Customs Review",      d => { d.SpokenPhrase = "Customs review ongoing.--"; d.ImpliesInspection = true; d.ImpliesConcern = true; }),
        });
    }

    private void SeedClearanceStatuses(PodcastProject p)
    {
        p.ClearanceStatuses.AddRange(new[]
        {
            Ref<ClearanceStatusDefinition>("cs-docking",   "Cleared for Docking",    d => { d.SpokenPhrase = "Cleared for docking.--"; d.IsTerminalState = true; }),
            Ref<ClearanceStatusDefinition>("cs-departure", "Cleared for Departure",  d => { d.SpokenPhrase = "Cleared for departure.--"; d.IsTerminalState = true; }),
            Ref<ClearanceStatusDefinition>("cs-pending",   "Clearance Pending",      d => { d.SpokenPhrase = "Clearance pending.--"; d.IsTerminalState = false; }),
            Ref<ClearanceStatusDefinition>("cs-held",      "Held for Inspection",    d => { d.SpokenPhrase = "Held for inspection.--"; d.IsTerminalState = false; }),
            Ref<ClearanceStatusDefinition>("cs-priority",  "Priority Clearance",     d => { d.SpokenPhrase = "Priority clearance granted.--"; d.IsTerminalState = true; }),
            Ref<ClearanceStatusDefinition>("cs-delayed",   "Docking Delayed",        d => { d.SpokenPhrase = "Docking delayed.--"; d.IsTerminalState = false; }),
        });
    }

    private void SeedEnvironmentalConditions(PodcastProject p)
    {
        p.EnvironmentalConditions.AddRange(new[]
        {
            Ref<EnvironmentalConditionDefinition>("ec-solar-low",    "Solar Activity Low",       d => { d.SpokenPhrase = "Solar flare activity remains low.--"; d.Scope = "System-wide"; }),
            Ref<EnvironmentalConditionDefinition>("ec-radiation",    "Radiation Elevated",       d => { d.SpokenPhrase = "Radiation levels elevated.--"; d.Scope = "Outer belt"; }),
            Ref<EnvironmentalConditionDefinition>("ec-debris-stable","Debris Field Stable",      d => { d.SpokenPhrase = "Debris field stable.--"; d.Scope = "Belt approach"; }),
            Ref<EnvironmentalConditionDefinition>("ec-corridor-minor","Corridor Interference",   d => { d.SpokenPhrase = "Corridor interference remains minor.--"; d.Scope = "Corridor 7"; }),
        });
    }

    private void SeedNoticeTypes(PodcastProject p)
    {
        p.NoticeTypes.AddRange(new[]
        {
            Ref<NoticeTypeDefinition>("nt-operations", "Operations Notice", d => { d.HeaderText = "Operations Notice.--"; d.DefaultBodyFormat = "{Detail}"; }),
            Ref<NoticeTypeDefinition>("nt-security",   "Security Notice",   d => { d.HeaderText = "Security Notice.--";   d.DefaultBodyFormat = "{Detail}"; }),
            Ref<NoticeTypeDefinition>("nt-docking",    "Docking Advisory",  d => { d.HeaderText = "Docking Advisory.--";  d.DefaultBodyFormat = "{Detail}"; }),
            Ref<NoticeTypeDefinition>("nt-customs",    "Customs Notice",    d => { d.HeaderText = "Customs Notice.--";    d.DefaultBodyFormat = "{Detail}"; }),
        });
    }

    private void SeedPhraseTemplates(PodcastProject p)
    {
        // Incident phrases
        p.PhraseTemplates.AddRange(new[]
        {
            Ref<PhraseTemplate>("pt-i1", "Corridor Interference", d => { d.TemplateText = "Corridor 7 experiencing minor interference.--"; d.TemplateGroup = "incident"; }),
            Ref<PhraseTemplate>("pt-i2", "Manifest Discrepancy",  d => { d.TemplateText = "Manifest discrepancy noted.--"; d.TemplateGroup = "incident"; }),
            Ref<PhraseTemplate>("pt-i3", "Documentation Variance",d => { d.TemplateText = "Documentation variance recorded.--"; d.TemplateGroup = "incident"; }),
            Ref<PhraseTemplate>("pt-i4", "Transponder Delay",     d => { d.TemplateText = "Transponder verification incomplete.--"; d.TemplateGroup = "incident"; }),
            Ref<PhraseTemplate>("pt-i5", "Signal Irregularity",   d => { d.TemplateText = "Identification signal irregularity noted.--"; d.TemplateGroup = "incident"; }),
            Ref<PhraseTemplate>("pt-i6", "No Docking Request",    d => { d.TemplateText = "No docking request received.--"; d.TemplateGroup = "incident"; }),
        });

        // Resolution phrases
        p.PhraseTemplates.AddRange(new[]
        {
            Ref<PhraseTemplate>("pt-r1", "Situation Resolved",     d => { d.TemplateText = "Situation resolved.--"; d.TemplateGroup = "resolution"; }),
            Ref<PhraseTemplate>("pt-r2", "No Further Action",      d => { d.TemplateText = "No further action required.--"; d.TemplateGroup = "resolution"; }),
            Ref<PhraseTemplate>("pt-r3", "Operations Ongoing",     d => { d.TemplateText = "Operations ongoing.--"; d.TemplateGroup = "resolution"; }),
        });

        // Route/trajectory status phrases
        p.PhraseTemplates.AddRange(new[]
        {
            Ref<PhraseTemplate>("pt-rs1", "Trajectory Clear",      d => { d.TemplateText = "Trajectory is clear.--"; d.TemplateGroup = "route_status"; }),
            Ref<PhraseTemplate>("pt-rs2", "Approach Clear",        d => { d.TemplateText = "Approach corridor clear.--"; d.TemplateGroup = "route_status"; }),
        });

        // Notice body phrases
        p.PhraseTemplates.AddRange(new[]
        {
            Ref<PhraseTemplate>("pt-nb1", "Particulate Activity",  d => { d.TemplateText = "Elevated particulate activity detected in Corridor 7.--"; d.TemplateGroup = "notice_body"; }),
            Ref<PhraseTemplate>("pt-nb2", "Non-Essential Postponed",d => { d.TemplateText = "Non-essential departures postponed.--"; d.TemplateGroup = "notice_body"; }),
        });
    }

    private void SeedAnomalyTypes(PodcastProject p)
    {
        p.AnomalyTypes.AddRange(new[]
        {
            Ref<AnomalyTypeDefinition>("an-cargo-mismatch",    "Cargo Mismatch",       d => {
                d.PublicDescription = "Manifest discrepancy noted.";
                d.IsSubtleByDefault = true;
                d.AllowedEntityKinds = new() { ThreadEntityKind.Vessel };
            }),
            Ref<AnomalyTypeDefinition>("an-identity",          "Identity Irregularity",d => {
                d.PublicDescription = "Identification signal irregularity noted.";
                d.IsSubtleByDefault = true;
                d.AllowedEntityKinds = new() { ThreadEntityKind.Vessel };
            }),
            Ref<AnomalyTypeDefinition>("an-sched-absence",     "Scheduled Absence",    d => {
                d.PublicDescription = "Scheduled arrival â€” no docking request received.";
                d.IsSubtleByDefault = true;
                d.AllowedEntityKinds = new() { ThreadEntityKind.Vessel, ThreadEntityKind.Route };
            }),
            Ref<AnomalyTypeDefinition>("an-unusual-priority",  "Unusual Priority",     d => {
                d.PublicDescription = "Priority clearance granted under non-standard conditions.";
                d.IsSubtleByDefault = true;
                d.AllowedEntityKinds = new() { ThreadEntityKind.Vessel, ThreadEntityKind.Organisation };
            }),
            Ref<AnomalyTypeDefinition>("an-sanitised-incident","Sanitised Incident",   d => {
                d.PublicDescription = "Documentation variance recorded. No further action required.";
                d.IsSubtleByDefault = true;
                d.AllowedEntityKinds = new() { ThreadEntityKind.Station, ThreadEntityKind.Route };
            }),
            Ref<AnomalyTypeDefinition>("an-directive-override","Directive Override",   d => {
                d.PublicDescription = "Cleared under directive. Standard processing suspended.";
                d.IsSubtleByDefault = false;
                d.AllowedEntityKinds = new() { ThreadEntityKind.Vessel, ThreadEntityKind.Organisation };
            }),
        });
    }

    private void SeedDirectives(PodcastProject p)
    {
        // AuthorityOrganisationId is wired after organisations are created.
        // A deferred-wire pass runs at the end of SeedWorld.
        p.Directives.AddRange(new[]
        {
            Ref<DirectiveDefinition>("dir-7",  "Directive 7",  d => d.SpokenPhrase = "Cleared under Directive 7.--"),
            Ref<DirectiveDefinition>("dir-12", "Directive 12", d => d.SpokenPhrase = "Cleared under Directive 12.--"),
            Ref<DirectiveDefinition>("dir-authority", "Authority Clearance", d => d.SpokenPhrase = "Cleared under authority directive.--"),
        });
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    // World
    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void SeedWorld(PodcastProject p)
    {
        // Star systems
        var sysHelios = World<StarSystemRecord>("sys-helios", "Helios System",  w => w.RegionName = "Inner Reach");
        var sysVirex  = World<StarSystemRecord>("sys-virex",  "Virex System",   w => w.RegionName = "Belt Region");
        var sysLuma   = World<StarSystemRecord>("sys-luma",   "Luma System",    w => w.RegionName = "Outer Reach");
        p.StarSystems.AddRange(new[] { sysHelios, sysVirex, sysLuma });

        // Celestial bodies
        var bodyMars    = World<CelestialBodyRecord>("body-mars",    "Mars Prime",       b => { b.StarSystemId = "sys-helios"; b.BodyTypeId = "bt-planet"; });
        var bodyVirex   = World<CelestialBodyRecord>("body-virex",   "Virex Belt",       b => { b.StarSystemId = "sys-virex";  b.BodyTypeId = "bt-belt"; });
        var bodyLuma    = World<CelestialBodyRecord>("body-luma",    "Luma Orbital",     b => { b.StarSystemId = "sys-luma";   b.BodyTypeId = "bt-orbital"; });
        p.CelestialBodies.AddRange(new[] { bodyMars, bodyVirex, bodyLuma });

        // Organisations
        var orgHeliosPort   = World<OrganisationRecord>("org-helios-port", "Helios Port Authority", o => { o.OrganisationTypeId = "ot-authority"; o.IsAuthority = true; });
        var orgVirexMining  = World<OrganisationRecord>("org-virex-mine",  "Virex Mining Coop",     o => { o.OrganisationTypeId = "ot-coop"; });
        var orgLumaAgri     = World<OrganisationRecord>("org-luma-agri",   "Luma Agricultural Co",  o => { o.OrganisationTypeId = "ot-coop"; });
        var orgKestrel      = World<OrganisationRecord>("org-kestrel",     "Kestrel Lines",         o => { o.OrganisationTypeId = "ot-shipping"; });
        var orgCarthage     = World<OrganisationRecord>("org-carthage",    "Carthage Relay Services",o => { o.OrganisationTypeId = "ot-shipping"; });
        p.Organisations.AddRange(new[] { orgHeliosPort, orgVirexMining, orgLumaAgri, orgKestrel, orgCarthage });

        // Wire directive to authority org
        var dir7 = p.Directives.First(d => d.Id == "dir-7");
        dir7.AuthorityOrganisationId = "org-helios-port";

        // Stations
        var stnHeliosGate   = World<StationRecord>("stn-helios-gate",   "Helios Gate",      s => {
            s.StationTypeId = "st-orbital"; s.StarSystemId = "sys-helios"; s.CelestialBodyId = "body-mars";
            s.OperatorOrganisationId = "org-helios-port";
            s.ImportCommodityIds = new() { "com-lox", "com-nitrogen", "com-nickel", "com-copper", "com-seed", "com-medical" };
            s.ExportCommodityIds = new() { "com-plating", "com-assemblies" };
            s.PurposeIds = new() { "pu-ore", "pu-fuel", "pu-crew", "pu-maint", "pu-diplomatic", "pu-agri" };
        });
        var stnMarsPrime    = World<StationRecord>("stn-mars-prime",    "Mars Prime",       s => {
            s.StationTypeId = "st-orbital"; s.StarSystemId = "sys-helios"; s.CelestialBodyId = "body-mars";
            s.ImportCommodityIds = new() { "com-lox", "com-nitrogen", "com-seed", "com-medical" };
            s.ExportCommodityIds = new() { "com-plating" };
            s.PurposeIds = new() { "pu-ore", "pu-crew", "pu-maint", "pu-agri" };
        });
        var stnVirexBelt    = World<StationRecord>("stn-virex-belt",    "Virex Belt",       s => {
            s.StationTypeId = "st-mining"; s.StarSystemId = "sys-virex"; s.CelestialBodyId = "body-virex";
            s.OperatorOrganisationId = "org-virex-mine";
            s.ImportCommodityIds = new() { "com-lox", "com-seed" };
            s.ExportCommodityIds = new() { "com-nickel", "com-copper" };
            s.PurposeIds = new() { "pu-ore", "pu-maint", "pu-internal" };
        });
        var stnLuma         = World<StationRecord>("stn-luma",          "Luma Station",     s => {
            s.StationTypeId = "st-agri"; s.StarSystemId = "sys-luma"; s.CelestialBodyId = "body-luma";
            s.OperatorOrganisationId = "org-luma-agri";
            s.ImportCommodityIds = new() { "com-lox", "com-nitrogen" };
            s.ExportCommodityIds = new() { "com-seed" };
            s.PurposeIds = new() { "pu-agri", "pu-crew", "pu-survey" };
        });
        var stnKepler       = World<StationRecord>("stn-kepler",        "Kepler Anchorage", s => {
            s.StationTypeId = "st-outpost"; s.StarSystemId = "sys-luma";
            s.ImportCommodityIds = new() { "com-lox", "com-medical" };
            s.ExportCommodityIds = new() { "com-containers" };
            s.PurposeIds = new() { "pu-internal", "pu-customs", "pu-maint" };
        });
        p.Stations.AddRange(new[] { stnHeliosGate, stnMarsPrime, stnVirexBelt, stnLuma, stnKepler });

        // Docks for Helios Gate
        p.Docks.AddRange(new[]
        {
            World<DockRecord>("dock-hg-1",  "Bay One",       d => { d.StationId = "stn-helios-gate"; d.SpokenLabel = "Bay One";    d.SpokenIdentifier = "Bay One"; }),
            World<DockRecord>("dock-hg-2",  "Bay Two",       d => { d.StationId = "stn-helios-gate"; d.SpokenLabel = "Bay Two";    d.SpokenIdentifier = "Bay Two"; }),
            World<DockRecord>("dock-hg-14", "Bay Fourteen",  d => { d.StationId = "stn-helios-gate"; d.SpokenLabel = "Bay Fourteen"; d.SpokenIdentifier = "Bay Fourteen"; }),
            World<DockRecord>("dock-hg-r3", "Ring Three",    d => { d.StationId = "stn-helios-gate"; d.SpokenLabel = "Ring Three";  d.SpokenIdentifier = "Ring Three"; }),
            World<DockRecord>("dock-hg-r4", "Ring Four",     d => { d.StationId = "stn-helios-gate"; d.SpokenLabel = "Ring Four";   d.SpokenIdentifier = "Ring Four"; }),
        });

        // Commodities
        p.Commodities.AddRange(new[]
        {
            World<CommodityRecord>("com-lox",        "Liquid Oxygen",              c => { c.CommodityCategoryId = "cc-fuel"; c.UnitLabel = "tons"; c.TypicalMinQuantity = 5000; c.TypicalMaxQuantity = 80000; c.ProducedAtStationIds = new() { "stn-mars-prime" }; c.ConsumedAtStationIds = new() { "stn-helios-gate", "stn-virex-belt", "stn-luma", "stn-kepler" }; }),
            World<CommodityRecord>("com-nitrogen",   "Nitrogen Compounds",         c => { c.CommodityCategoryId = "cc-industrial"; c.UnitLabel = "tons"; c.TypicalMinQuantity = 2000; c.TypicalMaxQuantity = 40000; c.ProducedAtStationIds = new() { "stn-mars-prime" }; }),
            World<CommodityRecord>("com-nickel",     "Processed Nickel",           c => { c.CommodityCategoryId = "cc-industrial"; c.UnitLabel = "tons"; c.TypicalMinQuantity = 1000; c.TypicalMaxQuantity = 20000; c.ProducedAtStationIds = new() { "stn-virex-belt" }; c.ConsumedAtStationIds = new() { "stn-helios-gate" }; }),
            World<CommodityRecord>("com-copper",     "Refined Copper",             c => { c.CommodityCategoryId = "cc-industrial"; c.UnitLabel = "tons"; c.TypicalMinQuantity = 500; c.TypicalMaxQuantity = 15000; c.ProducedAtStationIds = new() { "stn-virex-belt" }; }),
            World<CommodityRecord>("com-seed",       "Agricultural Seed Stock",    c => { c.CommodityCategoryId = "cc-agricultural"; c.UnitLabel = "units"; c.TypicalMinQuantity = 100; c.TypicalMaxQuantity = 5000; c.ProducedAtStationIds = new() { "stn-luma" }; c.ConsumedAtStationIds = new() { "stn-mars-prime", "stn-virex-belt" }; }),
            World<CommodityRecord>("com-medical",    "Medical Isolates",           c => { c.CommodityCategoryId = "cc-medical"; c.UnitLabel = "units"; c.TypicalMinQuantity = 50; c.TypicalMaxQuantity = 2000; c.IsRestricted = true; }),
            World<CommodityRecord>("com-plating",    "Structural Plating",         c => { c.CommodityCategoryId = "cc-industrial"; c.UnitLabel = "tons"; c.TypicalMinQuantity = 200; c.TypicalMaxQuantity = 8000; c.ProducedAtStationIds = new() { "stn-mars-prime", "stn-helios-gate" }; }),
            World<CommodityRecord>("com-assemblies", "Guidance Assemblies",        c => { c.CommodityCategoryId = "cc-military"; c.UnitLabel = "units"; c.TypicalMinQuantity = 10; c.TypicalMaxQuantity = 500; c.IsRestricted = true; }),
            World<CommodityRecord>("com-containers", "Sealed Industrial Containers",c => { c.CommodityCategoryId = "cc-industrial"; c.UnitLabel = "containers"; c.TypicalMinQuantity = 5; c.TypicalMaxQuantity = 200; }),
        });

        // Routes
        p.Routes.AddRange(new[]
        {
            World<RouteRecord>("rt-helios-mars",   "Helios Gate â€” Mars Prime",    r => {
                r.FromStationId = "stn-helios-gate"; r.ToStationId = "stn-mars-prime";
                r.FrequencyWeight = 2.0; r.RiskWeight = 1.0;
                r.AllowedVesselClassIds = new() { "vc-bulk", "vc-freighter", "vc-tanker", "vc-personnel" };
                r.TypicalCommodityIds = new() { "com-lox", "com-nitrogen", "com-plating", "com-seed" };
                r.TypicalPurposeIds = new() { "pu-ore", "pu-fuel", "pu-agri", "pu-crew" };
                r.RouteConditionTemplateId = "pt-rs1";
            }),
            World<RouteRecord>("rt-helios-virex",  "Helios Gate â€” Virex Belt",    r => {
                r.FromStationId = "stn-helios-gate"; r.ToStationId = "stn-virex-belt";
                r.FrequencyWeight = 1.5; r.RiskWeight = 1.2;
                r.AllowedVesselClassIds = new() { "vc-bulk", "vc-freighter", "vc-maintenance" };
                r.TypicalCommodityIds = new() { "com-nickel", "com-copper", "com-lox" };
                r.TypicalPurposeIds = new() { "pu-ore", "pu-maint", "pu-fuel" };
                r.RouteConditionTemplateId = "pt-rs1";
            }),
            World<RouteRecord>("rt-helios-luma",   "Helios Gate â€” Luma Station",  r => {
                r.FromStationId = "stn-helios-gate"; r.ToStationId = "stn-luma";
                r.FrequencyWeight = 1.0; r.RiskWeight = 1.0;
                r.AllowedVesselClassIds = new() { "vc-freighter", "vc-bulk", "vc-courier" };
                r.TypicalCommodityIds = new() { "com-seed", "com-lox" };
                r.TypicalPurposeIds = new() { "pu-agri", "pu-diplomatic" };
                r.RouteConditionTemplateId = "pt-rs2";
            }),
            World<RouteRecord>("rt-helios-kepler", "Helios Gate â€” Kepler Anchorage",r => {
                r.FromStationId = "stn-helios-gate"; r.ToStationId = "stn-kepler";
                r.FrequencyWeight = 0.7; r.RiskWeight = 1.5;
                r.AllowedVesselClassIds = new() { "vc-courier", "vc-freighter", "vc-maintenance" };
                r.TypicalCommodityIds = new() { "com-containers", "com-medical" };
                r.TypicalPurposeIds = new() { "pu-internal", "pu-customs", "pu-diplomatic" };
            }),
            World<RouteRecord>("rt-virex-luma",    "Virex Belt â€” Luma Station",   r => {
                r.FromStationId = "stn-virex-belt"; r.ToStationId = "stn-luma";
                r.FrequencyWeight = 0.8; r.RiskWeight = 1.1;
                r.AllowedVesselClassIds = new() { "vc-bulk", "vc-survey" };
                r.TypicalCommodityIds = new() { "com-nickel", "com-seed" };
                r.TypicalPurposeIds = new() { "pu-ore", "pu-survey" };
            }),
        });

        // Vessels
        p.Vessels.AddRange(new[]
        {
            World<VesselRecord>("vs-helios-dawn",   "Helios Dawn",      v => {
                v.Registry = "XF-7742"; v.VesselClassId = "vc-bulk";
                v.OperatorOrganisationId = "org-kestrel";
                v.HomeStationId = "stn-helios-gate";
                v.IsRecurringNarrativeAsset = true;
                v.PreferredRouteIds = new() { "rt-helios-mars", "rt-helios-virex" };
            }),
            World<VesselRecord>("vs-kestrel-dawn",  "Kestrel Dawn",     v => {
                v.Registry = "KD-2201"; v.VesselClassId = "vc-freighter";
                v.OperatorOrganisationId = "org-kestrel";
                v.HomeStationId = "stn-helios-gate";
                v.PreferredRouteIds = new() { "rt-helios-luma", "rt-helios-mars" };
            }),
            World<VesselRecord>("vs-carthage-r6",   "Carthage Relay 6", v => {
                v.Registry = "CR-0006"; v.VesselClassId = "vc-freighter";
                v.OperatorOrganisationId = "org-carthage";
                v.HomeStationId = "stn-kepler";
                v.PreferredRouteIds = new() { "rt-helios-kepler" };
            }),
            World<VesselRecord>("vs-wolfgang",      "Wolfgang Amadeus", v => {
                v.Registry = "WA-1141"; v.VesselClassId = "vc-courier";
                // No operator deliberately â€” part of the mystery
                v.HomeStationId = null;
                v.IsRecurringNarrativeAsset = true;
                v.PreferredRouteIds = new() { "rt-helios-luma", "rt-helios-kepler" };
                // AssociatedThreadIds wired after thread creation
            }),
            World<VesselRecord>("vs-pale-meridian", "Pale Meridian",    v => {
                v.Registry = "PM-8803"; v.VesselClassId = "vc-tanker";
                v.HomeStationId = "stn-mars-prime";
                v.PreferredRouteIds = new() { "rt-helios-mars" };
            }),
        });
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    // Episodes
    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void SeedEpisodes(PodcastProject p)
    {
        var series = new PodcastSeriesRecord
        {
            Id = "ser-001",
            Name = "Helios Gate Dispatch â€” Series One",
            BroadcastStationId = "stn-helios-gate",
            CreatedUtc = DateTime.UtcNow,
            ModifiedUtc = DateTime.UtcNow
        };

        var ep1 = new EpisodeRecord
        {
            Id = "ep-001",
            Name = "Episode 1",
            SeriesId = "ser-001",
            BroadcastStationId = "stn-helios-gate",
            InUniverseUtc = new DateTime(2347, 3, 14, 6, 0, 0, DateTimeKind.Utc),
            CreatedUtc = DateTime.UtcNow,
            ModifiedUtc = DateTime.UtcNow,
            IsCanonicalLocked = false
        };

        // One sample traffic entry (hand-authored) so the project is not completely empty
        var entry1 = new EpisodeEntryRecord
        {
            Id = IdHelper.NewId(),
            Name = "Departure â€” Helios Dawn",
            EntryKind = EntryKind.Traffic,
            SourceType = EntrySourceType.Manual,
            SortOrder = 0,
            OperationTypeId = "op-departure",
            StationId = "stn-helios-gate",
            DockId = "dock-hg-14",
            VesselId = "vs-helios-dawn",
            OriginStationId = null,
            DestinationStationId = "stn-mars-prime",
            DeclaredPurposeId = "pu-ore",
            ActualPurposeId = "pu-ore",
            ManifestStatusId = "ms-verified",
            InspectionStatusId = "is-none",
            ClearanceStatusId = "cs-departure",
            EnvironmentalConditionId = "ec-solar-low",
            RouteStatusPhraseTemplateId = "pt-rs1",
            DeclaredCargo = new List<EntryCargoLine>
            {
                new() { CommodityId = "com-lox", Quantity = 38000, IsDeclared = true },
                new() { CommodityId = "com-nitrogen", Quantity = 12000, IsDeclared = true }
            },
            ActualCargo = new List<EntryCargoLine>
            {
                new() { CommodityId = "com-lox", Quantity = 38000, IsDeclared = true },
                new() { CommodityId = "com-nitrogen", Quantity = 12000, IsDeclared = true }
            },
            RenderOptions = new EntryRenderOptions
            {
                IncludePurpose = true, IncludeCargo = true, IncludePassengers = false,
                IncludeManifestStatus = true, IncludeInspectionStatus = true,
                IncludeEnvironmentalStatus = true, IncludeResolution = false
            },
            CreatedUtc = DateTime.UtcNow,
            ModifiedUtc = DateTime.UtcNow
        };

        ep1.Entries.Add(entry1);
        series.EpisodeIds.Add("ep-001");

        p.Series.Add(series);
        p.Episodes.Add(ep1);
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    // Story threads
    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void SeedStoryThreads(PodcastProject p)
    {
        // Wolfgang Amadeus identity/transponder irregularity thread.
        // Beats progress from ordinary to increasingly suspicious appearances.
        // Stage -1 = not yet applied; advances 1 at a time by the StoryThreadService.

        var thread = new StoryThreadRecord
        {
            Id = "thread-wolfgang",
            Name = "Wolfgang Amadeus â€” Identity Thread",
            EntityKind = ThreadEntityKind.Vessel,
            TargetEntityId = "vs-wolfgang",
            ThemeAnomalyTypeId = "an-identity",
            CurrentStageIndex = -1,
            IsActive = true,
            CooldownEpisodes = 2,
            EpisodesUntilEligible = 0,
            CreatedUtc = DateTime.UtcNow,
            ModifiedUtc = DateTime.UtcNow,
            Beats = new List<StoryBeatRecord>
            {
                // Beat 0 â€” ordinary diplomatic courier, no anomaly
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 0 â€” Ordinary",
                    StageIndex = 0,
                    PublicManifestStatusId = "ms-verified",
                    PublicInspectionStatusId = "is-none",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = null,
                    ResolutionPhraseTemplateId = null,
                    HiddenTruthSummary = "Normal diplomatic run. Nothing unusual recorded.",
                    Severity = SeverityLevel.Minor
                },
                // Beat 1 â€” manifest verification pending
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 1 â€” Manifest Pending",
                    StageIndex = 1,
                    PublicManifestStatusId = "ms-pending",
                    PublicInspectionStatusId = "is-none",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = null,
                    ResolutionPhraseTemplateId = "pt-r3",
                    HiddenTruthSummary = "Manifest filing delayed. Vessel claims administrative backlog.",
                    Severity = SeverityLevel.Minor
                },
                // Beat 2 â€” customs notation filed
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 2 â€” Customs Notation",
                    StageIndex = 2,
                    PublicManifestStatusId = "ms-amended",
                    PublicInspectionStatusId = "is-customs",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = "pt-i3",
                    ResolutionPhraseTemplateId = "pt-r3",
                    HiddenTruthSummary = "Customs flagged undeclared personal effects. Vessel crew uncooperative but released.",
                    Severity = SeverityLevel.Minor
                },
                // Beat 3 â€” transponder verification incomplete
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 3 â€” Transponder Issue",
                    StageIndex = 3,
                    PublicManifestStatusId = "ms-verified",
                    PublicInspectionStatusId = "is-deferred",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = "pt-i4",
                    ResolutionPhraseTemplateId = "pt-r3",
                    HiddenTruthSummary = "Transponder cycling through multiple ID codes on approach. Port authority log entry filed.",
                    Severity = SeverityLevel.Moderate
                },
                // Beat 4 â€” identification signal irregularity noted
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 4 â€” Signal Irregularity",
                    StageIndex = 4,
                    PublicManifestStatusId = "ms-pending",
                    PublicInspectionStatusId = "is-customs",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = "pt-i5",
                    ResolutionPhraseTemplateId = "pt-r3",
                    HiddenTruthSummary = "Registry WA-1141 does not match hull markings on visual inspection. Second filing submitted.",
                    Severity = SeverityLevel.Moderate
                },
                // Beat 5 â€” cleared under directive
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 5 â€” Directive Clearance",
                    StageIndex = 5,
                    PublicManifestStatusId = "ms-verified",
                    PublicInspectionStatusId = "is-complete",
                    PublicDirectiveId = "dir-7",
                    IncidentPhraseTemplateId = "pt-i5",
                    ResolutionPhraseTemplateId = "pt-r2",
                    HiddenTruthSummary = "Directive 7 invoked by port authority contact. Inspection results sealed. Vessel cleared without standard documentation.",
                    Severity = SeverityLevel.Major
                },
                // Beat 6 â€” scheduled arrival, no docking request received
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 6 â€” Silent Arrival",
                    StageIndex = 6,
                    PublicManifestStatusId = null,
                    PublicInspectionStatusId = null,
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = "pt-i6",
                    ResolutionPhraseTemplateId = null,
                    HiddenTruthSummary = "Wolfgang Amadeus appeared on docking approach without filing a request. No crew contact made. Departed before bay assignment. No record of cargo or passengers.",
                    Severity = SeverityLevel.Major
                },
            }
        };

        p.StoryThreads.Add(thread);

        // Wire the thread back to the vessel
        var vessel = p.Vessels.First(v => v.Id == "vs-wolfgang");
        vessel.AssociatedThreadIds.Add(thread.Id);
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    // Helpers
    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Creates a reference-data item with a fixed seed ID and applies configuration via action.
    /// </summary>
    private static T Ref<T>(string id, string name, Action<T> configure) where T : ReferenceItemBase, new()
    {
        var item = new T { Id = id, Name = name };
        configure(item);
        return item;
    }

    /// <summary>
    /// Creates a world record with a fixed seed ID and applies configuration via action.
    /// </summary>
    private static T World<T>(string id, string name, Action<T> configure) where T : AuditableEntityBase, new()
    {
        var item = new T { Id = id, Name = name, CreatedUtc = DateTime.UtcNow, ModifiedUtc = DateTime.UtcNow };
        configure(item);
        return item;
    }
}

```n---


### File: PodcastUniverseEditor\Services\Validation\ProjectValidationService.cs
```csharp


namespace PodcastUniverseEditor.Services.Validation;

/// <summary>
/// Runs a rule set against a PodcastProject and returns a ValidationResult.
/// Stateless â€” create once and call Validate as many times as needed.
/// Each private rule method appends to the shared result; rules are independent.
/// </summary>
public class ProjectValidationService
{
    // â”€â”€ Public API â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public ValidationResult Validate(PodcastProject project)
    {
        var result = new ValidationResult();

        ValidateVesselRegistries(project, result);

        foreach (var episode in project.Episodes)
            foreach (var entry in episode.Entries)
                ValidateEntry(project, entry, result);

        return result;
    }

    // â”€â”€ Entry-level rules â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private static void ValidateEntry(PodcastProject p, EpisodeEntryRecord entry, ValidationResult result)
    {
        // Local helpers to reduce repetition
        void Add(ValidationSeverity severity, string message, string field = "") =>
            result.Messages.Add(new ValidationMessage
            {
                Severity   = severity,
                Message    = message,
                EntityType = nameof(EpisodeEntryRecord),
                EntityId   = entry.Id,
                FieldName  = field
            });

        void Warn(string message, string field = "")  => Add(ValidationSeverity.Warning, message, field);
        void Error(string message, string field = "") => Add(ValidationSeverity.Error,   message, field);

        string label = string.IsNullOrEmpty(entry.Name) ? $"entry {entry.Id[..8]}" : $"entry '{entry.Name}'";

        if (entry.EntryKind == EntryKind.Traffic)
        {
            // Traffic entries should not carry a notice type
            if (entry.NoticeTypeId != null)
                Warn($"Traffic {label} has a notice type set â€” notice type is for notice entries only.", "NoticeTypeId");

            // Operation type field requirements
            if (entry.OperationTypeId != null)
            {
                var opType = p.OperationTypes.FirstOrDefault(o => o.Id == entry.OperationTypeId);
                if (opType == null)
                {
                    Warn($"Traffic {label}: operation type ID references a missing record.", "OperationTypeId");
                }
                else
                {
                    if (opType.RequiresOrigin && string.IsNullOrEmpty(entry.OriginStationId))
                        Error($"Traffic {label}: operation '{opType.Name}' requires an origin station.", "OriginStationId");
                    if (opType.RequiresDestination && string.IsNullOrEmpty(entry.DestinationStationId))
                        Error($"Traffic {label}: operation '{opType.Name}' requires a destination station.", "DestinationStationId");
                }
            }

            // Declared cargo must not contain contraband
            foreach (var cargo in entry.DeclaredCargo.Where(c => !c.IsHiddenTruthOnly))
            {
                var commodity = p.Commodities.FirstOrDefault(c => c.Id == cargo.CommodityId);
                if (commodity?.IsContraband == true)
                    Error($"Traffic {label}: declared cargo contains contraband commodity '{commodity.Name}'.", "DeclaredCargo");
            }
        }
        else // Notice
        {
            // Notice entries should not carry an operation type
            if (entry.OperationTypeId != null)
                Warn($"Notice {label} has an operation type set â€” operation type is for traffic entries only.", "OperationTypeId");
        }

        // Story beat must belong to the selected story thread
        if (entry.AppliedStoryBeatId != null)
        {
            if (string.IsNullOrEmpty(entry.StoryThreadId))
            {
                Error($"{label.Capitalize()}: a story beat is applied but no story thread is selected.", "AppliedStoryBeatId");
            }
            else
            {
                var thread = p.StoryThreads.FirstOrDefault(t => t.Id == entry.StoryThreadId);
                if (thread == null)
                    Warn($"{label.Capitalize()}: story thread ID references a missing record.", "StoryThreadId");
                else if (!thread.Beats.Any(b => b.Id == entry.AppliedStoryBeatId))
                    Error($"{label.Capitalize()}: the applied story beat does not belong to thread '{thread.Name}'.", "AppliedStoryBeatId");
            }
        }

        // Phrase template group enforcement
        ValidatePhraseGroup(p, entry, entry.IncidentPhraseTemplateId,    "incident",    "incident phrase",    result);
        ValidatePhraseGroup(p, entry, entry.ResolutionPhraseTemplateId,  "resolution",  "resolution phrase",  result);
        ValidatePhraseGroup(p, entry, entry.RouteStatusPhraseTemplateId, "route_status","route status phrase", result);

        // Dock state checks
        if (entry.DockId != null)
        {
            var dock = p.Docks.FirstOrDefault(d => d.Id == entry.DockId);
            if (dock == null)
            {
                Warn($"{label.Capitalize()}: dock ID references a missing record.", "DockId");
            }
            else
            {
                if (dock.IsSuspended)
                    Warn($"{label.Capitalize()}: dock '{dock.Name}' is suspended and should not receive active traffic.", "DockId");
                if (dock.IsRestricted && string.IsNullOrEmpty(entry.DirectiveId))
                    Warn($"{label.Capitalize()}: dock '{dock.Name}' is restricted but no directive has been cited.", "DirectiveId");
            }
        }

        // Dangling reference checks â€” warn rather than error (data may be added later)
        if (entry.VesselId != null && !p.Vessels.Any(v => v.Id == entry.VesselId))
            Warn($"{label.Capitalize()}: vessel ID references a missing record.", "VesselId");
        if (entry.StationId != null && !p.Stations.Any(s => s.Id == entry.StationId))
            Warn($"{label.Capitalize()}: station ID references a missing record.", "StationId");
        if (entry.OriginStationId != null && !p.Stations.Any(s => s.Id == entry.OriginStationId))
            Warn($"{label.Capitalize()}: origin station ID references a missing record.", "OriginStationId");
        if (entry.DestinationStationId != null && !p.Stations.Any(s => s.Id == entry.DestinationStationId))
            Warn($"{label.Capitalize()}: destination station ID references a missing record.", "DestinationStationId");
        if (entry.StoryThreadId != null && !p.StoryThreads.Any(t => t.Id == entry.StoryThreadId))
            Warn($"{label.Capitalize()}: story thread ID references a missing record.", "StoryThreadId");
    }

    // â”€â”€ Phrase group rule â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private static void ValidatePhraseGroup(
        PodcastProject p,
        EpisodeEntryRecord entry,
        string? phraseId,
        string expectedGroup,
        string fieldLabel,
        ValidationResult result)
    {
        if (phraseId == null) return;

        var phrase = p.PhraseTemplates.FirstOrDefault(pt => pt.Id == phraseId);
        if (phrase == null)
        {
            result.Messages.Add(new ValidationMessage
            {
                Severity   = ValidationSeverity.Warning,
                Message    = $"Entry '{entry.Name}': {fieldLabel} ID references a missing phrase template.",
                EntityType = nameof(EpisodeEntryRecord),
                EntityId   = entry.Id,
                FieldName  = fieldLabel
            });
            return;
        }

        if (!string.Equals(phrase.TemplateGroup, expectedGroup, StringComparison.OrdinalIgnoreCase))
        {
            result.Messages.Add(new ValidationMessage
            {
                Severity   = ValidationSeverity.Warning,
                Message    = $"Entry '{entry.Name}': {fieldLabel} '{phrase.Name}' belongs to group '{phrase.TemplateGroup}', expected '{expectedGroup}'.",
                EntityType = nameof(EpisodeEntryRecord),
                EntityId   = entry.Id,
                FieldName  = fieldLabel
            });
        }
    }

    // â”€â”€ Project-level rules â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private static void ValidateVesselRegistries(PodcastProject p, ValidationResult result)
    {
        // Duplicate registry codes are a world-building error
        var duplicates = p.Vessels
            .Where(v => !string.IsNullOrEmpty(v.Registry))
            .GroupBy(v => v.Registry, StringComparer.OrdinalIgnoreCase)
            .Where(g => g.Count() > 1);

        foreach (var group in duplicates)
        {
            foreach (var vessel in group)
            {
                result.Messages.Add(new ValidationMessage
                {
                    Severity   = ValidationSeverity.Warning,
                    Message    = $"Vessel '{vessel.Name}' shares registry '{vessel.Registry}' with another vessel.",
                    EntityType = nameof(VesselRecord),
                    EntityId   = vessel.Id,
                    FieldName  = "Registry"
                });
            }
        }
    }
}

// â”€â”€ String helper â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

file static class StringExtensions
{
    /// <summary>Capitalises the first character of a string.</summary>
    internal static string Capitalize(this string s) =>
        string.IsNullOrEmpty(s) ? s : char.ToUpper(s[0]) + s[1..];
}

```n---


### File: PodcastUniverseEditor\UI\LookupItem.cs
```csharp

namespace PodcastUniverseEditor.UI;

/// <summary>
/// Thin wrapper used as DataSource for ComboBoxes.
/// Id is a string â€” empty string represents "no selection" (maps to null on the model).
/// Display is the human-readable label shown in the drop-down.
/// </summary>
public sealed class LookupItem
{
    public LookupItem(string id, string display)
    {
        Id      = id;
        Display = display;
    }

    public string Id      { get; }
    public string Display { get; }

    /// <summary>Sentinel item placed at index 0 to represent "no selection".</summary>
    public static LookupItem None => new(string.Empty, "(none)");

    public override string ToString() => Display;
}

```n---


### File: PodcastUniverseEditor\UI\ReferenceDataTypeOption.cs
```csharp

namespace PodcastUniverseEditor.UI;

/// <summary>
/// Represents a single entry in the reference-data type selector list.
/// Key maps to the corresponding collection property name on PodcastProject
/// so the binding helper can locate the right list via a switch.
/// </summary>
public class ReferenceDataTypeOption
{
    public ReferenceDataTypeOption(string key, string displayName)
    {
        Key = key;
        DisplayName = displayName;
    }

    public string Key { get; set; }
    public string DisplayName { get; set; }

    public override string ToString() => DisplayName;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucCommodities.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Commodities tab.
/// Hosts a single full-tab DataGridView.
/// Public property exposes the grid so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucCommodities : UserControl
{
    public ucCommodities()
    {
        InitializeComponent();
    }

    // â”€â”€ Grid â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridCommodities => gridCommodities;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucEpisodes.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Episodes tab.
/// Hosts the full episodes/series/entry editing UI.
/// Public properties expose all controls referenced by MainForm so that
/// MainForm can own all behaviour without this control needing any project
/// or service references.
/// </summary>
public partial class ucEpisodes : UserControl
{
    public ucEpisodes()
    {
        InitializeComponent();
    }

    // â”€â”€ Lists â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ListBox LstSeries   => lstSeries;
    public ListBox LstEpisodes => lstEpisodes;

    // â”€â”€ Series buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnSeriesAdd       => btnSeriesAdd;
    public Button BtnSeriesDelete    => btnSeriesDelete;
    public Button BtnSeriesDuplicate => btnSeriesDuplicate;

    // â”€â”€ Episode search / summary â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtEpisodeSearch  => txtEpisodeSearch;
    public TextBox TxtEpisodeSummary => txtEpisodeSummary;

    // â”€â”€ Episode buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnEpisodeAdd              => btnEpisodeAdd;
    public Button BtnEpisodeDelete           => btnEpisodeDelete;
    public Button BtnEpisodeDuplicate        => btnEpisodeDuplicate;
    public Button BtnNewEpisodeAfterSelected => btnNewEpisodeAfterSelected;
    public Button BtnLockEpisodeCanon        => btnLockEpisodeCanon;
    public Button BtnUnlockEpisodeCanon      => btnUnlockEpisodeCanon;
    public Button BtnEpisodeMoveUp           => btnEpisodeMoveUp;
    public Button BtnEpisodeMoveDown         => btnEpisodeMoveDown;

    // â”€â”€ Entry grid â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public DataGridView GridEpisodeEntries => gridEpisodeEntries;

    // â”€â”€ Entry filter controls â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox  TxtEntrySearch        => txtEntrySearch;
    public ComboBox CboEntryFilterKind    => cboEntryFilterKind;
    public ComboBox CboEntryFilterVessel  => cboEntryFilterVessel;
    public ComboBox CboEntryFilterStation => cboEntryFilterStation;
    public CheckBox ChkShowLockedOnly     => chkShowLockedOnly;
    public Button   BtnClearEntryFilters  => btnClearEntryFilters;

    // â”€â”€ Entry management buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnEntryAdd       => btnEntryAdd;
    public Button BtnNoticeEntryAdd => btnNoticeEntryAdd;
    public Button BtnEntryDuplicate => btnEntryDuplicate;
    public Button BtnEntryDelete    => btnEntryDelete;
    public Button BtnEntryMoveUp    => btnEntryMoveUp;
    public Button BtnEntryMoveDown  => btnEntryMoveDown;

    // â”€â”€ Generation controls â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button         BtnGenerateEntry                    => btnGenerateEntry;
    public Button         BtnGenerateEpisodeEntries           => btnGenerateEpisodeEntries;
    public Button         BtnRegenerateSelectedEntry          => btnRegenerateSelectedEntry;
    public NumericUpDown  NumGenerateEntryCount               => numGenerateEntryCount;
    public CheckBox       ChkClearEpisodeBeforeGenerate       => chkClearEpisodeBeforeGenerate;
    public CheckBox       ChkRegenerateWithoutAdvancingThread => chkRegenerateWithoutAdvancingThread;
    public TextBox        TxtGenerationSeed                   => txtGenerationSeed;

    // â”€â”€ Export controls â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button   BtnExportEpisodeText             => btnExportEpisodeText;
    public Button   BtnExportEpisodeTts              => btnExportEpisodeTts;
    public Button   BtnExportEpisodeJson             => btnExportEpisodeJson;
    public CheckBox ChkExportIncludeHeader           => chkExportIncludeHeader;
    public CheckBox ChkExportBlankLineBetweenEntries => chkExportBlankLineBetweenEntries;
    public CheckBox ChkExportIncludeEntryMarkers     => chkExportIncludeEntryMarkers;
    public CheckBox ChkExportAuthorDebugMode         => chkExportAuthorDebugMode;

    // â”€â”€ Preview / thread summary â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtEpisodeEntryPreview => txtEpisodeEntryPreview;
    public TextBox TxtThreadSummary       => txtThreadSummary;

    // â”€â”€ Entry detail panel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Panel           PnlEntryDetail     => pnlEntryDetail;
    public FlowLayoutPanel FlpValidationHints => flpValidationHints;

    // â”€â”€ Entry fields: structural â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox      CboEntryKind       => cboEntryKind;
    public ComboBox      CboEntrySourceType => cboEntrySourceType;
    public TextBox       TxtEntryName       => txtEntryName;
    public NumericUpDown NumEntrySortOrder  => numEntrySortOrder;
    public CheckBox      ChkEntryLocked     => chkEntryLocked;
    public CheckBox      ChkEntryCanon      => chkEntryCanon;
    public NumericUpDown NumEntryRandomSeed => numEntryRandomSeed;
    public TextBox       TxtEntryNotes      => txtEntryNotes;

    // â”€â”€ Entry fields: operation / notice â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryOperationType => cboEntryOperationType;
    public ComboBox CboEntryNoticeType    => cboEntryNoticeType;

    // â”€â”€ Entry fields: location â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryStation            => cboEntryStation;
    public ComboBox CboEntryDock               => cboEntryDock;
    public ComboBox CboEntryOriginStation      => cboEntryOriginStation;
    public ComboBox CboEntryDestinationStation => cboEntryDestinationStation;

    // â”€â”€ Entry fields: vessel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryVessel              => cboEntryVessel;
    public ComboBox CboEntryVesselClassOverride => cboEntryVesselClassOverride;
    public TextBox  TxtEntryRegistryOverride    => txtEntryRegistryOverride;

    // â”€â”€ Entry fields: purpose â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryDeclaredPurpose => cboEntryDeclaredPurpose;
    public ComboBox CboEntryActualPurpose   => cboEntryActualPurpose;

    // â”€â”€ Entry fields: statuses â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryManifestStatus         => cboEntryManifestStatus;
    public ComboBox CboEntryInspectionStatus       => cboEntryInspectionStatus;
    public ComboBox CboEntryClearanceStatus        => cboEntryClearanceStatus;
    public ComboBox CboEntryEnvironmentalCondition => cboEntryEnvironmentalCondition;

    // â”€â”€ Entry fields: narrative â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryDirective          => cboEntryDirective;
    public ComboBox CboEntryIncidentPhrase     => cboEntryIncidentPhrase;
    public ComboBox CboEntryResolutionPhrase   => cboEntryResolutionPhrase;
    public ComboBox CboEntryRouteStatusPhrase  => cboEntryRouteStatusPhrase;
    public TextBox  TxtEntryPublicBodyOverride => txtEntryPublicBodyOverride;

    // â”€â”€ Entry fields: story thread â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryStoryThread      => cboEntryStoryThread;
    public ComboBox CboEntryAppliedStoryBeat => cboEntryAppliedStoryBeat;
    public ComboBox CboEntryAnomalySeverity  => cboEntryAnomalySeverity;

    // â”€â”€ Entry fields: hidden truth â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtEntryHiddenTruthNotes => txtEntryHiddenTruthNotes;

    // â”€â”€ Entry fields: schedule â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public CheckBox       ChkEntryScheduledEnabled => chkEntryScheduledEnabled;
    public DateTimePicker DtpEntryScheduledUtc     => dtpEntryScheduledUtc;

    // â”€â”€ Manifest grids â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public DataGridView GridDeclaredCargo      => gridDeclaredCargo;
    public DataGridView GridActualCargo        => gridActualCargo;
    public DataGridView GridDeclaredPassengers => gridDeclaredPassengers;
    public DataGridView GridActualPassengers   => gridActualPassengers;

    // â”€â”€ Manifest grid buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnDeclaredCargoAdd        => btnDeclaredCargoAdd;
    public Button BtnDeclaredCargoDelete     => btnDeclaredCargoDelete;
    public Button BtnActualCargoAdd          => btnActualCargoAdd;
    public Button BtnActualCargoDelete       => btnActualCargoDelete;
    public Button BtnDeclaredPassengerAdd    => btnDeclaredPassengerAdd;
    public Button BtnDeclaredPassengerDelete => btnDeclaredPassengerDelete;
    public Button BtnActualPassengerAdd      => btnActualPassengerAdd;
    public Button BtnActualPassengerDelete   => btnActualPassengerDelete;

    // â”€â”€ Episode metadata editor panel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Panel PnlEpisodeMetaEditor => pnlEpisodeMetaEditor;

    // â”€â”€ Episode fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox        TxtEpisodeName              => txtEpisodeName;
    public CheckBox       ChkEpisodeHasInUniverseDate => chkEpisodeHasInUniverseDate;
    public DateTimePicker DtpEpisodeInUniverseUtc     => dtpEpisodeInUniverseUtc;
    public ComboBox       CboEpisodeBroadcastStation  => cboEpisodeBroadcastStation;
    public ComboBox       CboEpisodeSeries            => cboEpisodeSeries;
    public CheckBox       ChkEpisodeCanonicalLocked   => chkEpisodeCanonicalLocked;
    public TextBox        TxtEpisodeNotes             => txtEpisodeNotes;

    // â”€â”€ Series fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox  TxtSeriesName             => txtSeriesName;
    public ComboBox CboSeriesBroadcastStation => cboSeriesBroadcastStation;
    public TextBox  TxtSeriesNotes            => txtSeriesNotes;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucOrganisationsDirectives.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Organisations &amp; Directives tab.
/// Hosts a horizontal SplitContainer: Organisations grid (top), Directives grid (bottom).
/// Public properties expose the grids so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucOrganisationsDirectives : UserControl
{
    public ucOrganisationsDirectives()
    {
        InitializeComponent();
    }

    // â”€â”€ Grids â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridOrganisations => gridOrganisations;
    public DataGridView GridDirectives    => gridDirectives;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucOutputPreview.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Output Preview tab.
/// Hosts a single full-tab read-only TextBox for rendered episode output.
/// Public property exposes the TextBox so MainForm can write rendered content
/// without this control needing any project or service references.
/// </summary>
public partial class ucOutputPreview : UserControl
{
    public ucOutputPreview()
    {
        InitializeComponent();
    }

    // â”€â”€ Output text â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public TextBox TxtRenderedOutput => txtRenderedOutput;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucOverview.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>Stub UserControl for the Overview tab. Content to be extracted in a future pass.</summary>
public partial class ucOverview : UserControl
{
    public ucOverview() { InitializeComponent(); }
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucReferenceData.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Reference Data tab.
/// Hosts a vertical SplitContainer: reference type list (left), items grid + buttons (right).
/// Public properties expose the key controls so MainForm can bind data and hook events
/// without this control needing any project or service references.
/// </summary>
public partial class ucReferenceData : UserControl
{
    public ucReferenceData()
    {
        InitializeComponent();
    }

    // â”€â”€ Selectors â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public ListBox ListReferenceTypes => lstReferenceTypes;

    // â”€â”€ Grid â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridReferenceItems => gridReferenceItems;

    // â”€â”€ Buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public Button BtnAdd    => btnReferenceAdd;
    public Button BtnDelete => btnReferenceDelete;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucRoutes.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Routes tab.
/// Hosts a single full-tab DataGridView.
/// Public property exposes the grid so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucRoutes : UserControl
{
    public ucRoutes()
    {
        InitializeComponent();
    }

    // â”€â”€ Grid â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridRoutes => gridRoutes;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucStationsDocks.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Stations &amp; Docks tab.
/// Hosts a horizontal SplitContainer: Stations grid + buttons (top), Docks grid + buttons (bottom).
/// Public properties expose the grids and buttons so MainForm can bind data and hook events
/// without this control needing any project or service references.
/// </summary>
public partial class ucStationsDocks : UserControl
{
    public ucStationsDocks()
    {
        InitializeComponent();
    }

    // â”€â”€ Grids â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridStations => gridStations;
    public DataGridView GridDocks    => gridDocks;

    // â”€â”€ Buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public Button BtnStationsAdd    => btnStationsAdd;
    public Button BtnStationsDelete => btnStationsDelete;
    public Button BtnDocksAdd       => btnDocksAdd;
    public Button BtnDocksDelete    => btnDocksDelete;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucSystemsBodies.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Systems &amp; Bodies tab.
/// Hosts a horizontal SplitContainer: Star Systems grid (top), Celestial Bodies grid (bottom).
/// Public properties expose the grids so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucSystemsBodies : UserControl
{
    public ucSystemsBodies()
    {
        InitializeComponent();
    }

    // â”€â”€ Grids â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridStarSystems     => gridStarSystems;
    public DataGridView GridCelestialBodies => gridCelestialBodies;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucThreads.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Threads tab.
/// Hosts a horizontal SplitContainer: Story Threads grid (top), Beats grid (bottom).
/// Public properties expose the grids so MainForm can bind data and hook events
/// without this control needing any project or service references.
/// </summary>
public partial class ucThreads : UserControl
{
    public ucThreads()
    {
        InitializeComponent();
    }

    // â”€â”€ Grids â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridThreads     => gridThreads;
    public DataGridView GridThreadBeats => gridThreadBeats;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucValidation.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Validation tab.
/// Hosts a top button bar and a read-only validation messages grid with explicit columns.
/// Public properties expose key controls so MainForm can own behaviour without this control
/// needing any project or service references.
/// </summary>
public partial class ucValidation : UserControl
{
    public ucValidation()
    {
        InitializeComponent();
    }

    // â”€â”€ Grid â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridValidationMessages => gridValidationMessages;

    // â”€â”€ Buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public Button BtnRunValidation => btnRunValidation;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucVessels.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Vessels tab.
/// Hosts a single full-tab DataGridView.
/// Public property exposes the grid so MainForm can bind data without this control
/// needing any project or service references.
/// </summary>
public partial class ucVessels : UserControl
{
    public ucVessels()
    {
        InitializeComponent();
    }

    // â”€â”€ Grid â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridVessels => gridVessels;
}

```n---


### File: PodcastUniverseEditor\UI\Forms\MainForm.cs
```csharp


namespace PodcastUniverseEditor.UI.Forms;

public partial class MainForm : Form
{
    // â”€â”€ Services â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private readonly AppStateService _appState;
    private readonly ProjectFileService _fileService;
    private readonly ProjectSeedFactory _seedFactory;

    // â”€â”€ Stateless services â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private readonly EntryRenderingService    _renderer      = new();
    private readonly ProjectValidationService _validator     = new();
    private readonly EpisodeGenerationService _generator     = new();
    private readonly ProjectExportService     _exportService = new();

    // â”€â”€ Lookup â€” recreated on every project change â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private ProjectLookupService? _lookup;

    // â”€â”€ Entry detail state â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>True while LoadEntryIntoDetailPanel is running â€” suppresses write-back handlers.</summary>
    private bool _loadingEntry;

    /// <summary>True while LoadEpisodeIntoMetaPanel is running â€” suppresses episode/series write-back handlers.</summary>
    private bool _loadingEpisodeMeta;

    /// <summary>True while btnClearEntryFilters is resetting controls â€” suppresses redundant ApplyEntryFilter calls.</summary>
    private bool _clearingEntryFilters;

    // â”€â”€ BindingSources â€” one per major collection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private readonly BindingSource _bsStarSystems      = new();
    private readonly BindingSource _bsCelestialBodies  = new();
    private readonly BindingSource _bsStations         = new();
    private readonly BindingSource _bsDocks            = new();
    private readonly BindingSource _bsRoutes           = new();
    private readonly BindingSource _bsCommodities      = new();
    private readonly BindingSource _bsOrganisations    = new();
    private readonly BindingSource _bsDirectives       = new();
    private readonly BindingSource _bsVessels          = new();
    private readonly BindingSource _bsThreads          = new();
    private readonly BindingSource _bsThreadBeats      = new();
    private readonly BindingSource _bsReferenceItems   = new();
    private readonly BindingSource _bsSeries                = new();
    private readonly BindingSource _bsEpisodes              = new();
    private readonly BindingSource _bsEntries               = new();
    private readonly BindingSource _bsValidation            = new();
    private readonly BindingSource _bsDeclaredCargo         = new();
    private readonly BindingSource _bsActualCargo           = new();
    private readonly BindingSource _bsDeclaredPassengers    = new();
    private readonly BindingSource _bsActualPassengers      = new();

    // â”€â”€ Filter views â€” non-destructive filtered projections of project lists â”€â”€â”€â”€

    private readonly BindingList<EpisodeRecord>      _episodesView = new();
    private readonly BindingList<EpisodeEntryRecord> _entriesView  = new();

    // â”€â”€ Reference type catalogue â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private static readonly List<ReferenceDataTypeOption> ReferenceTypes = new()
    {
        new("OperationTypes",         "Operation Types"),
        new("VesselClasses",          "Vessel Classes"),
        new("Purposes",               "Purposes"),
        new("ManifestStatuses",       "Manifest Statuses"),
        new("InspectionStatuses",     "Inspection Statuses"),
        new("ClearanceStatuses",      "Clearance Statuses"),
        new("EnvironmentalConditions","Environmental Conditions"),
        new("NoticeTypes",            "Notice Types"),
        new("PassengerCategories",    "Passenger Categories"),
        new("CommodityCategories",    "Commodity Categories"),
        new("StationTypes",           "Station Types"),
        new("AuthorityTypes",         "Authority Types"),
        new("AnomalyTypes",           "Anomaly Types"),
        new("PhraseTemplates",        "Phrase Templates"),
        new("Directives",             "Directives"),
        new("BodyTypes",              "Body Types"),
        new("OrganisationTypes",      "Organisation Types"),
    };

    // â”€â”€ Constructor â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public MainForm()
    {
        _appState    = new AppStateService();
        _fileService = new ProjectFileService();
        _seedFactory = new ProjectSeedFactory();

        InitializeComponent();
        InitializeTabContent(); // tab pages populated here; separated from InitializeComponent for designer compatibility

        _appState.ProjectChanged    += OnProjectChanged;
        _appState.DirtyStateChanged += OnDirtyStateChanged;

        Load += MainForm_Load;
    }

    // â”€â”€ Initialisation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void MainForm_Load(object? sender, EventArgs e)
    {
        PopulateReferenceTypesList();
        SetupEpisodeEntryColumns();

        // Overview text-changed handlers â€” subscribed once here, never in LoadProjectIntoUI.
        // Handlers read from _appState.CurrentProject at the time they fire so they always
        // write to the live project, even after a project swap.
        txtProjectName.TextChanged += (_, _) =>
        {
            _appState.CurrentProject.ProjectName = txtProjectName.Text;
            _appState.MarkDirty();
        };
        txtProjectDescription.TextChanged += (_, _) =>
        {
            _appState.CurrentProject.Description = txtProjectDescription.Text;
            _appState.MarkDirty();
        };

        // Dirty tracking for all major editable grids â€” subscribed once here.
        HookDirtyTracking(
            gridReferenceItems,
            gridStarSystems, gridCelestialBodies,
            gridStations, gridDocks,
            gridRoutes,
            gridCommodities,
            gridOrganisations, gridDirectives,
            gridVessels,
            gridThreads, gridThreadBeats,
            gridEpisodeEntries,
            gridDeclaredCargo, gridActualCargo,
            gridDeclaredPassengers, gridActualPassengers);

        // BindingSource dirty tracking for add/delete via bound grids.
        // _bsEntries is NOT included â€” its DataSource is _entriesView (a filter projection)
        // and ListChanged would fire false dirty marks whenever filtering rebuilds the view.
        HookBindingSourceDirty(
            _bsStarSystems, _bsCelestialBodies,
            _bsStations, _bsDocks,
            _bsRoutes, _bsCommodities,
            _bsOrganisations, _bsDirectives,
            _bsVessels, _bsThreads, _bsThreadBeats,
            _bsReferenceItems,
            _bsDeclaredCargo, _bsActualCargo,
            _bsDeclaredPassengers, _bsActualPassengers);

        // Bind entry list to its filter view â€” done once; ApplyEntryFilter repopulates _entriesView.
        _bsEntries.DataSource         = _entriesView;
        gridEpisodeEntries.DataSource = _bsEntries;

        // Entry detail write-back handlers â€” subscribed once here
        HookEntryDetailHandlers();

        // Episode/series metadata write-back handlers â€” subscribed once here
        HookEpisodeMetaHandlers();

        _appState.SetProject(_fileService.CreateNewProject(), null);
        SetStatus("Ready");
    }

    // â”€â”€ AppState event callbacks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void OnProjectChanged()
    {
        LoadProjectIntoUI();
        UpdateTitleBar();
        UpdateStatusFile();
    }

    private void OnDirtyStateChanged()
    {
        UpdateTitleBar();
        UpdateStatusFile();
    }

    // â”€â”€ Project loading â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Binds all grids and text fields to the current project.
    /// Must only assign values and set DataSources â€” no event subscriptions here.
    /// </summary>
    private void LoadProjectIntoUI()
    {
        var p = _appState.CurrentProject;

        // Overview â€” assign only; TextChanged handlers are already wired in MainForm_Load
        txtProjectName.Text        = p.ProjectName;
        txtProjectDescription.Text = p.Description;
        txtSchemaVersion.Text      = p.SchemaVersion.ToString();

        // World grids
        _bsStarSystems.DataSource      = p.StarSystems;
        gridStarSystems.DataSource     = _bsStarSystems;

        _bsCelestialBodies.DataSource  = p.CelestialBodies;
        gridCelestialBodies.DataSource = _bsCelestialBodies;

        _bsStations.DataSource         = p.Stations;
        gridStations.DataSource        = _bsStations;

        _bsDocks.DataSource            = p.Docks;
        gridDocks.DataSource           = _bsDocks;

        _bsRoutes.DataSource           = p.Routes;
        gridRoutes.DataSource          = _bsRoutes;

        _bsCommodities.DataSource      = p.Commodities;
        gridCommodities.DataSource     = _bsCommodities;

        _bsOrganisations.DataSource    = p.Organisations;
        gridOrganisations.DataSource   = _bsOrganisations;

        _bsDirectives.DataSource       = p.Directives;
        gridDirectives.DataSource      = _bsDirectives;

        _bsVessels.DataSource          = p.Vessels;
        gridVessels.DataSource         = _bsVessels;

        // Threads â€” beats grid is managed by gridThreads.SelectionChanged
        _bsThreads.DataSource          = p.StoryThreads;
        gridThreads.DataSource         = _bsThreads;

        // Series list â€” bound directly to project's Series list.
        _bsSeries.DataSource    = p.Series;
        lstSeries.DataSource    = _bsSeries;
        lstSeries.DisplayMember = "Name";

        // Episodes â€” bound to _episodesView so filtering is non-destructive.
        // ApplyEpisodeFilter populates _episodesView from p.Episodes, filtered by series.
        _bsEpisodes.DataSource    = _episodesView;
        lstEpisodes.DataSource    = _bsEpisodes;
        lstEpisodes.DisplayMember = "Name";
        ApplyEpisodeFilter();

        // Rebuild lookup service for the new project
        _lookup = new ProjectLookupService(p);

        // Repopulate entry detail combo boxes (and manifest grid columns) with fresh project data
        PopulateEntryDetailCombos();

        // Repopulate episode/series metadata combo boxes
        PopulateEpisodeMetaCombos();

        // Clear transient views
        ClearDetailPanel();
        txtRenderedOutput.Clear();

        // If a reference type was already selected, rebind its grid to the new project
        RefreshReferenceGrid();
    }

    // â”€â”€ Reference data â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void lstReferenceTypes_SelectedIndexChanged(object? sender, EventArgs e)
    {
        RefreshReferenceGrid();
    }

    private void btnReferenceAdd_Click(object? sender, EventArgs e)
    {
        if (lstReferenceTypes.SelectedItem is not ReferenceDataTypeOption option) return;

        var collection = GetReferenceCollection(option.Key);
        if (collection == null) return;
        var newItem = CreateNewReferenceItem(option.Key, collection.Count);

        collection.Add(newItem);

        // List<T> doesn't auto-notify BindingSource; reset manually then move to new item.
        _bsReferenceItems.ResetBindings(false);
        _bsReferenceItems.Position = _bsReferenceItems.Count - 1;
        _appState.MarkDirty();
    }

    private void btnReferenceDelete_Click(object? sender, EventArgs e)
    {
        if (_bsReferenceItems.Current is not ReferenceItemBase item) return;

        var confirm = MessageBox.Show(
            $"Delete '{item.Name}'?\nThis cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        // BindingSource.RemoveCurrent removes from the underlying List<T> directly.
        _bsReferenceItems.RemoveCurrent();
        _appState.MarkDirty();
    }

    // â”€â”€ Stations & Docks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnStationsAdd_Click(object? sender, EventArgs e)
    {
        var p       = _appState.CurrentProject;
        var station = new StationRecord { Name = $"Station {p.Stations.Count + 1}" };
        p.Stations.Add(station);
        _bsStations.ResetBindings(false);
        _bsStations.Position = _bsStations.Count - 1;
        _appState.MarkDirty();
    }

    private void btnStationsDelete_Click(object? sender, EventArgs e)
    {
        if (_bsStations.Current is not StationRecord station) return;

        var confirm = MessageBox.Show(
            $"Delete station '{station.Name}'?\nThis cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _bsStations.RemoveCurrent();
        _appState.MarkDirty();
    }

    private void btnDocksAdd_Click(object? sender, EventArgs e)
    {
        var p    = _appState.CurrentProject;
        var dock = new DockRecord
        {
            Name      = $"Dock {p.Docks.Count + 1}",
            StationId = (_bsStations.Current is StationRecord sel) ? sel.Id : string.Empty
        };
        p.Docks.Add(dock);
        _bsDocks.ResetBindings(false);
        _bsDocks.Position = _bsDocks.Count - 1;
        _appState.MarkDirty();
    }

    private void btnDocksDelete_Click(object? sender, EventArgs e)
    {
        if (_bsDocks.Current is not DockRecord dock) return;

        var confirm = MessageBox.Show(
            $"Delete dock '{dock.Name}'?\nThis cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _bsDocks.RemoveCurrent();
        _appState.MarkDirty();
    }

    // â”€â”€ Thread selection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void gridThreads_SelectionChanged(object? sender, EventArgs e)
    {
        // _bsThreads.Current tracks the selected DataGridView row via BindingSource sync.
        var thread = _bsThreads.Current as StoryThreadRecord;
        _bsThreadBeats.DataSource  = thread?.Beats;
        gridThreadBeats.DataSource = _bsThreadBeats;
    }

    // â”€â”€ Episodes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void lstEpisodes_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep)
        {
            ApplyEntryFilter(null);
            ClearDetailPanel();
            txtEpisodeSummary.Clear();
            LoadEpisodeIntoMetaPanel(null);
            return;
        }

        ApplyEntryFilter(ep);
        ClearDetailPanel();
        UpdateEpisodeSummary(ep);
        LoadEpisodeIntoMetaPanel(ep);
        RefreshRenderedOutput();
    }

    private void gridEpisodeEntries_SelectionChanged(object? sender, EventArgs e)
    {
        LoadEntryIntoDetailPanel(GetSelectedEntry());
    }

    private void btnEpisodeAdd_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;

        // Ensure at least one series exists
        if (p.Series.Count == 0)
        {
            var defaultSeries = new PodcastSeriesRecord { Name = "Series 1" };
            p.Series.Add(defaultSeries);
            _bsSeries.ResetBindings(false);
        }

        // Prefer the currently selected series; fall back to the first series.
        var seriesId = (_bsSeries.Current is PodcastSeriesRecord sel ? sel.Id : null)
                       ?? p.Series[0].Id;

        var ep = new EpisodeRecord
        {
            Name          = $"Episode {p.Episodes.Count + 1}",
            SeriesId      = seriesId,
            InUniverseUtc = DateTime.UtcNow
        };

        p.Episodes.Add(ep);
        SyncSeriesEpisodeIds(p);
        RefreshEpisodesList(selectLast: true);
        _appState.MarkDirty();
    }

    private void btnEpisodeDelete_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        if (ep.IsCanonicalLocked)
        {
            MessageBox.Show(
                "This episode is locked as canon and cannot be deleted.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Delete episode '{ep.Name}'?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _appState.CurrentProject.Episodes.Remove(ep);
        SyncSeriesEpisodeIds(_appState.CurrentProject);
        RefreshEpisodesList(selectLast: false);

        // Clear entries pane
        ApplyEntryFilter(null);
        ClearDetailPanel();

        _appState.MarkDirty();
    }

    // â”€â”€ Series management â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void lstSeries_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var series = _bsSeries.Current as PodcastSeriesRecord;
        _loadingEpisodeMeta = true;
        try { LoadSeriesIntoMetaPanel(series); }
        finally { _loadingEpisodeMeta = false; }
        ApplyEpisodeFilter();
    }

    private void btnSeriesAdd_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;
        var series = new PodcastSeriesRecord { Name = $"Series {p.Series.Count + 1}" };
        p.Series.Add(series);

        _bsSeries.ResetBindings(false);
        _bsSeries.Position = _bsSeries.Count - 1;

        // Rebuild cboEpisodeSeries so the new series appears as an option
        RefreshSeriesCombo();
        _appState.MarkDirty();
        SetStatus($"Series '{series.Name}' added.");
    }

    private void btnSeriesDelete_Click(object? sender, EventArgs e)
    {
        if (_bsSeries.Current is not PodcastSeriesRecord series) return;

        var p = _appState.CurrentProject;

        // Safety rule: refuse deletion if the series still owns episodes.
        // The user must reassign or delete those episodes first.
        bool hasEpisodes = p.Episodes.Any(ep => ep.SeriesId == series.Id);
        if (hasEpisodes)
        {
            MessageBox.Show(
                $"Series '{series.Name}' still has episodes.\n" +
                "Move all its episodes to another series (using the Series combo in the episode editor) or delete them before deleting the series.",
                "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Delete series '{series.Name}'?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        p.Series.Remove(series);
        _bsSeries.ResetBindings(false);

        // Rebuild cboEpisodeSeries so the deleted series is removed from the dropdown
        RefreshSeriesCombo();
        ApplyEpisodeFilter();
        _appState.MarkDirty();
        SetStatus($"Series '{series.Name}' deleted.");
    }

    /// <summary>
    /// Duplicates the currently selected series together with all its episodes and their entries.
    /// The duplicate is a genuine deep copy: all IDs are regenerated, timestamps are fresh,
    /// and every entry is reset to an editable manual draft (IsLocked/IsCanon/RandomSeed cleared).
    /// The original series is not modified.
    /// </summary>
    private void btnSeriesDuplicate_Click(object? sender, EventArgs e)
    {
        if (_bsSeries.Current is not PodcastSeriesRecord series) return;

        var p    = _appState.CurrentProject;
        var opts = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };

        // Deep copy the series record and give it a fresh identity
        var seriesJson = JsonSerializer.Serialize(series, opts);
        var copySeries = JsonSerializer.Deserialize<PodcastSeriesRecord>(seriesJson, opts)!;
        copySeries.Id          = Guid.NewGuid().ToString();
        copySeries.CreatedUtc  = DateTime.UtcNow;
        copySeries.ModifiedUtc = DateTime.UtcNow;
        copySeries.Name        = string.IsNullOrWhiteSpace(series.Name) ? "Series Copy" : $"{series.Name} Copy";
        copySeries.EpisodeIds  = new List<string>(); // rebuilt by SyncSeriesEpisodeIds below

        // Duplicate every episode in the original series, preserving their order in p.Episodes
        var originalEpisodes = p.Episodes
            .Where(ep => ep.SeriesId == series.Id)
            .ToList();

        foreach (var origEp in originalEpisodes)
        {
            var epJson = JsonSerializer.Serialize(origEp, opts);
            var copyEp = JsonSerializer.Deserialize<EpisodeRecord>(epJson, opts)!;
            copyEp.Id                = Guid.NewGuid().ToString();
            copyEp.CreatedUtc        = DateTime.UtcNow;
            copyEp.ModifiedUtc       = DateTime.UtcNow;
            copyEp.IsCanonicalLocked = false;
            copyEp.SeriesId          = copySeries.Id;

            // Reset every entry to a clean manual draft
            foreach (var entry in copyEp.Entries)
            {
                entry.Id          = Guid.NewGuid().ToString();
                entry.CreatedUtc  = DateTime.UtcNow;
                entry.ModifiedUtc = DateTime.UtcNow;
                entry.SourceType  = EntrySourceType.Manual;
                entry.IsLocked    = false;
                entry.IsCanon     = false;
                entry.RandomSeed  = null;
            }

            p.Episodes.Add(copyEp);
        }

        p.Series.Add(copySeries);
        SyncSeriesEpisodeIds(p);

        // Refresh series list and episode series combo
        _bsSeries.ResetBindings(false);
        RefreshSeriesCombo();

        // Select the new series by ID â€” triggers lstSeries_SelectedIndexChanged â†’ ApplyEpisodeFilter
        for (int i = 0; i < _bsSeries.Count; i++)
        {
            if (_bsSeries[i] is PodcastSeriesRecord s && s.Id == copySeries.Id)
            {
                _bsSeries.Position = i;
                break;
            }
        }

        _appState.MarkDirty();
        SetStatus($"Series '{series.Name}' duplicated with {originalEpisodes.Count} episode(s).");
    }

    /// <summary>
    /// Rebuilds cboEpisodeSeries DataSource from the current project series list,
    /// preserving the episode's current selection. Must only be called when safe
    /// (no episode write-backs should fire during the refresh).
    /// </summary>
    private void RefreshSeriesCombo()
    {
        if (_lookup == null) return;
        var currentEpSeriesId = GetSelectedLookupId(cboEpisodeSeries);
        _loadingEpisodeMeta = true;
        try
        {
            SetLookupDataSource(cboEpisodeSeries, _lookup.SeriesAsLookup());
            SetLookupCombo(cboEpisodeSeries, currentEpSeriesId);
        }
        finally { _loadingEpisodeMeta = false; }
    }

    private void btnEntryAdd_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        if (IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before adding entries.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int trafficCount = ep.Entries.Count(en => en.EntryKind == EntryKind.Traffic);

        var entry = new EpisodeEntryRecord
        {
            Name       = $"Traffic {trafficCount + 1}",
            SortOrder  = ep.Entries.Count,
            EntryKind  = EntryKind.Traffic,
            SourceType = EntrySourceType.Manual,
            StationId  = ResolveDefaultStationId(ep),
            RenderOptions = new EntryRenderOptions()  // all sections enabled â€” standard traffic defaults
        };

        ep.Entries.Add(entry);
        ApplyEntryFilter(ep);
        SelectEntryInView(entry);
        _appState.MarkDirty();
    }

    private void btnNoticeEntryAdd_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        if (IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before adding entries.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int noticeCount = ep.Entries.Count(en => en.EntryKind == EntryKind.Notice);

        var entry = new EpisodeEntryRecord
        {
            Name       = $"Notice {noticeCount + 1}",
            SortOrder  = ep.Entries.Count,
            EntryKind  = EntryKind.Notice,
            SourceType = EntrySourceType.Manual,
            // Traffic-only fields intentionally left null
            RenderOptions = new EntryRenderOptions
            {
                IncludePurpose          = false,
                IncludeCargo            = false,
                IncludePassengers       = false,
                IncludeManifestStatus   = false,
                IncludeInspectionStatus = false,
                IncludeEnvironmentalStatus = false,
                IncludeResolution       = true   // resolution phrase still useful for notices
            }
        };

        ep.Entries.Add(entry);
        ApplyEntryFilter(ep);
        SelectEntryInView(entry);
        _appState.MarkDirty();
    }

    private void btnEntryDuplicate_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;
        if (_bsEntries.Current  is not EpisodeEntryRecord original) return;

        if (IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before duplicating entries.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Deep-copy via JSON round-trip â€” same approach used for episode duplication.
        var opts = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
        var json = JsonSerializer.Serialize(original, opts);
        var copy = JsonSerializer.Deserialize<EpisodeEntryRecord>(json, opts)!;

        // Fresh identity
        copy.Id          = Guid.NewGuid().ToString();
        copy.CreatedUtc  = DateTime.UtcNow;
        copy.ModifiedUtc = DateTime.UtcNow;

        // Reset generation / lock state so the duplicate starts as a clean draft
        copy.SourceType = EntrySourceType.Manual;
        copy.IsLocked   = false;
        copy.IsCanon    = false;
        copy.RandomSeed = null;

        // Name
        copy.Name = string.IsNullOrWhiteSpace(original.Name)
            ? $"{original.EntryKind} Copy"
            : $"{original.Name} Copy";

        // Insert immediately after the original in the canonical list
        int originalIdx = ep.Entries.IndexOf(original);
        int insertIdx   = originalIdx >= 0 ? originalIdx + 1 : ep.Entries.Count;
        ep.Entries.Insert(insertIdx, copy);

        // Rewrite SortOrder to match the new list positions
        for (int i = 0; i < ep.Entries.Count; i++)
            ep.Entries[i].SortOrder = i;

        ApplyEntryFilter(ep);
        SelectEntryInView(copy);
        RefreshRenderedOutput();
        _appState.MarkDirty();
    }

    /// <summary>
    /// Resolves the default StationId for a new entry from episode or series context.
    /// Priority: episode BroadcastStationId â†’ series BroadcastStationId â†’ null.
    /// </summary>
    private string? ResolveDefaultStationId(EpisodeRecord ep)
    {
        if (!string.IsNullOrEmpty(ep.BroadcastStationId))
            return ep.BroadcastStationId;

        var series = _appState.CurrentProject.Series
            .FirstOrDefault(s => s.Id == ep.SeriesId);
        if (series != null && !string.IsNullOrEmpty(series.BroadcastStationId))
            return series.BroadcastStationId;

        return null;
    }

    /// <summary>
    /// Positions _bsEntries to the given entry in the current filtered view.
    /// Called after add operations to select the new entry and load it into the detail panel.
    /// If the entry is not visible due to active filters, selection is left as-is.
    /// </summary>
    private void SelectEntryInView(EpisodeEntryRecord entry)
    {
        for (int i = 0; i < _entriesView.Count; i++)
        {
            if (_entriesView[i].Id == entry.Id)
            {
                _bsEntries.Position = i;
                return;
            }
        }
    }

    private void btnEntryDelete_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;
        if (_bsEntries.Current is not EpisodeEntryRecord entry) return;

        if (IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before deleting entries.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (IsEntryImmutable(entry))
        {
            MessageBox.Show(
                "This entry is locked or canon and cannot be deleted.",
                "Entry Immutable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Delete entry '{entry.Name}'?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        ep.Entries.Remove(entry);
        ApplyEntryFilter(ep);
        txtEpisodeEntryPreview.Clear();
        RefreshRenderedOutput();
        _appState.MarkDirty();
    }

    private void btnEntryMoveUp_Click(object? sender, EventArgs e)
        => MoveSelectedEntry(direction: -1);

    private void btnEntryMoveDown_Click(object? sender, EventArgs e)
        => MoveSelectedEntry(direction: +1);

    /// <summary>
    /// Moves the currently selected entry one position up (direction = -1) or down (+1)
    /// in the episode's canonical entry list, then reapplies the filter and preserves selection.
    /// SortOrder values are rewritten to match the new list order.
    /// Respects canon-lock and entry-immutability guards.
    /// </summary>
    private void MoveSelectedEntry(int direction)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;
        if (_bsEntries.Current  is not EpisodeEntryRecord entry) return;

        if (IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before reordering entries.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (IsEntryImmutable(entry))
        {
            MessageBox.Show(
                "This entry is locked or canon and cannot be reordered.",
                "Entry Immutable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Work against the canonical episode list, not the filtered view.
        var list = ep.Entries;
        int idx  = list.IndexOf(entry);
        if (idx < 0) return;

        int targetIdx = idx + direction;
        if (targetIdx < 0 || targetIdx >= list.Count) return; // already at boundary â€” do nothing

        // Swap the two entries in the canonical list
        (list[idx], list[targetIdx]) = (list[targetIdx], list[idx]);

        // Rewrite SortOrder to match the new list positions
        for (int i = 0; i < list.Count; i++)
            list[i].SortOrder = i;

        // Refresh filter view, then re-select the moved entry
        ApplyEntryFilter(ep);
        SelectEntryInView(entry);
        RefreshRenderedOutput();
        _appState.MarkDirty();
    }

    // â”€â”€ Generation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnGenerateEntry_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        if (IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before generating entries.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int? seed  = ParseGenerationSeed();
        var  entry = _generator.GenerateEntry(_appState.CurrentProject, seed);
        entry.SortOrder = ep.Entries.Count + 1;
        ep.Entries.Add(entry);

        ApplyEntryFilter(ep);
        _bsEntries.Position = _bsEntries.Count - 1;
        RefreshRenderedOutput();
        _appState.MarkDirty();
        RunPostGenerationValidation("Generated 1 entry");
    }

    private void btnGenerateEpisodeEntries_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        if (IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before generating entries.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int  count      = (int)numGenerateEntryCount.Value;
        bool clearFirst = chkClearEpisodeBeforeGenerate.Checked;
        int? seed       = ParseGenerationSeed();

        if (clearFirst)
        {
            bool   hasLocked = ep.Entries.Any(x => x.IsLocked || x.IsCanon);
            string msg       = hasLocked
                ? $"Clear all non-locked/non-canon entries and generate {count} new ones?"
                : $"Clear all existing entries and generate {count} new ones?";

            var confirm = MessageBox.Show(msg, "Confirm Generation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
        }

        _generator.FillEpisode(_appState.CurrentProject, ep, count, clearFirst, seed);

        ApplyEntryFilter(ep);
        if (_bsEntries.Count > 0)
            _bsEntries.Position = 0;
        RefreshRenderedOutput();
        _appState.MarkDirty();
        RunPostGenerationValidation($"Generated {count} entries for '{ep.Name}'");
    }

    private void btnRegenerateSelectedEntry_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;
        if (_bsEntries.Current is not EpisodeEntryRecord existing) return;

        if (IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before regenerating entries.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (IsEntryImmutable(existing))
        {
            MessageBox.Show(
                "This entry is locked or canon and cannot be regenerated.",
                "Cannot Regenerate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int?  seed      = ParseGenerationSeed() ?? existing.RandomSeed;
        int   sortOrder = existing.SortOrder;
        int   idx       = ep.Entries.IndexOf(existing);
        bool  editMode  = chkRegenerateWithoutAdvancingThread.Checked;

        var replacement = _generator.GenerateEntry(_appState.CurrentProject, seed, advanceStory: !editMode);
        replacement.SortOrder = sortOrder;

        if (idx >= 0)
            ep.Entries[idx] = replacement;
        else
            ep.Entries.Add(replacement);

        ApplyEntryFilter(ep);
        _bsEntries.Position = idx >= 0 ? idx : _bsEntries.Count - 1;
        RefreshRenderedOutput();
        _appState.MarkDirty();
        RunPostGenerationValidation("Entry regenerated");
    }

    /// <summary>
    /// Parses txtGenerationSeed as an integer. Returns null if empty or unparseable.
    /// </summary>
    private int? ParseGenerationSeed()
    {
        string raw = txtGenerationSeed.Text.Trim();
        if (string.IsNullOrEmpty(raw)) return null;
        return int.TryParse(raw, out int val) ? val : null;
    }

    /// <summary>
    /// Runs validation after a generation action. Updates the status bar with counts.
    /// If errors are present, also populates the validation grid and switches to the tab.
    /// </summary>
    private void RunPostGenerationValidation(string actionLabel)
    {
        var result   = _validator.Validate(_appState.CurrentProject);
        int errors   = result.Messages.Count(m => m.Severity == ValidationSeverity.Error);
        int warnings = result.Messages.Count(m => m.Severity == ValidationSeverity.Warning);

        if (errors > 0)
        {
            var messages = new BindingList<ValidationMessage>(result.Messages);
            _bsValidation.DataSource          = messages;
            gridValidationMessages.DataSource = _bsValidation;
            tabMain.SelectedTab               = tabValidation;
            SetStatus($"{actionLabel}. Validation: {errors} error(s), {warnings} warning(s) â€” see Validation tab.");
        }
        else if (warnings > 0)
        {
            SetStatus($"{actionLabel}. {warnings} validation warning(s).");
        }
        else
        {
            SetStatus($"{actionLabel}. No validation issues.");
        }
    }

    // â”€â”€ Validation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnRunValidation_Click(object? sender, EventArgs e)
    {
        var result   = _validator.Validate(_appState.CurrentProject);
        var messages = new BindingList<ValidationMessage>(result.Messages);

        _bsValidation.DataSource          = messages;
        gridValidationMessages.DataSource = _bsValidation;
        tabMain.SelectedTab               = tabValidation;

        int errors   = result.Messages.Count(m => m.Severity == ValidationSeverity.Error);
        int warnings = result.Messages.Count(m => m.Severity == ValidationSeverity.Warning);
        SetStatus($"Validation: {errors} error(s), {warnings} warning(s).");
    }

    // â”€â”€ Menu handlers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void mnuFileNew_Click(object? sender, EventArgs e)
    {
        if (!ConfirmDiscardChanges()) return;
        _appState.SetProject(_fileService.CreateNewProject(), null);
        SetStatus("New project created.");
    }

    private void mnuFileOpen_Click(object? sender, EventArgs e)
    {
        if (!ConfirmDiscardChanges()) return;
        using var dlg = new OpenFileDialog { Filter = ProjectFileService.FileFilter, Title = "Open Project" };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        try
        {
            var project = _fileService.Load(dlg.FileName);
            _appState.SetProject(project, dlg.FileName);
            SetStatus($"Opened: {Path.GetFileName(dlg.FileName)}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to open project:\n{ex.Message}",
                "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void mnuFileSave_Click(object? sender, EventArgs e) => SaveProject(saveAs: false);

    private void mnuFileSaveAs_Click(object? sender, EventArgs e) => SaveProject(saveAs: true);

    private void mnuFileExit_Click(object? sender, EventArgs e)
    {
        if (!ConfirmDiscardChanges()) return;
        Application.Exit();
    }

    // â”€â”€ Toolbar handlers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnNewProject_Click(object? sender, EventArgs e)  => mnuFileNew_Click(sender, e);
    private void btnOpenProject_Click(object? sender, EventArgs e) => mnuFileOpen_Click(sender, e);
    private void btnSaveProject_Click(object? sender, EventArgs e) => mnuFileSave_Click(sender, e);

    // â”€â”€ Overview handlers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnLoadSampleProject_Click(object? sender, EventArgs e)
    {
        if (!ConfirmDiscardChanges()) return;
        var project = _seedFactory.CreateSampleProject();
        _appState.SetProject(project, null);
        _appState.MarkDirty();
        SetStatus("Sample project loaded.");
    }

    // â”€â”€ Save helper â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void SaveProject(bool saveAs)
    {
        string? path = _appState.CurrentFilePath;

        if (saveAs || string.IsNullOrEmpty(path))
        {
            using var dlg = new SaveFileDialog
            {
                Filter   = ProjectFileService.FileFilter,
                Title    = "Save Project",
                FileName = string.IsNullOrEmpty(path) ? "project" : Path.GetFileName(path)
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            path = dlg.FileName;
        }

        // Flush overview fields in case keyboard focus has not left the text boxes
        _appState.CurrentProject.ProjectName = txtProjectName.Text;
        _appState.CurrentProject.Description = txtProjectDescription.Text;

        try
        {
            _fileService.Save(path, _appState.CurrentProject);

            // SetFilePath updates CurrentFilePath and calls MarkClean without a full UI reload.
            // This avoids rebinding all grids (which would reset selections) just because we saved.
            _appState.SetFilePath(path);

            SetStatus($"Saved: {Path.GetFileName(path)}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to save project:\n{ex.Message}",
                "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // â”€â”€ Refresh helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Rebinds gridReferenceItems to whichever reference collection is currently selected.
    /// Safe to call at any time; does nothing if no type is selected.
    /// </summary>
    private void RefreshReferenceGrid()
    {
        if (lstReferenceTypes.SelectedItem is not ReferenceDataTypeOption opt) return;
        _bsReferenceItems.DataSource  = GetReferenceCollection(opt.Key);
        gridReferenceItems.DataSource = _bsReferenceItems;
    }

    /// <summary>
    /// Resets lstEpisodes after the underlying Episodes list has been mutated.
    /// If selectLast is true, moves selection to the last item.
    /// </summary>
    private void RefreshEpisodesList(bool selectLast)
    {
        ApplyEpisodeFilter();
        if (selectLast && _bsEpisodes.Count > 0)
            _bsEpisodes.Position = _bsEpisodes.Count - 1;
    }

    // â”€â”€ Reference data factory â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private System.Collections.IList? GetReferenceCollection(string key)
    {
        var p = _appState.CurrentProject;
        return key switch
        {
            "OperationTypes"          => p.OperationTypes,
            "VesselClasses"           => p.VesselClasses,
            "Purposes"                => p.Purposes,
            "ManifestStatuses"        => p.ManifestStatuses,
            "InspectionStatuses"      => p.InspectionStatuses,
            "ClearanceStatuses"       => p.ClearanceStatuses,
            "EnvironmentalConditions" => p.EnvironmentalConditions,
            "NoticeTypes"             => p.NoticeTypes,
            "PassengerCategories"     => p.PassengerCategories,
            "CommodityCategories"     => p.CommodityCategories,
            "StationTypes"            => p.StationTypes,
            "AuthorityTypes"          => p.AuthorityTypes,
            "AnomalyTypes"            => p.AnomalyTypes,
            "PhraseTemplates"         => p.PhraseTemplates,
            "Directives"              => p.Directives,
            "BodyTypes"               => p.BodyTypes,
            "OrganisationTypes"       => p.OrganisationTypes,
            _                         => null
        };
    }

    /// <summary>
    /// Creates a new, correctly typed reference item for the given collection key.
    /// The new item receives a fresh GUID Id from EntityBase, a placeholder name, and
    /// a numbered placeholder code derived from the current collection size so successive
    /// items don't collide (e.g. "new-operation-type-001", "new-operation-type-002").
    /// </summary>
    private static ReferenceItemBase CreateNewReferenceItem(string key, int existingCount)
    {
        int n = existingCount + 1;
        string code = PlaceholderCode(key, n);
        return key switch
        {
            "OperationTypes"          => new OperationTypeDefinition    { Name = "New Operation Type",          Code = code },
            "VesselClasses"           => new VesselClassDefinition      { Name = "New Vessel Class",             Code = code },
            "Purposes"                => new PurposeDefinition          { Name = "New Purpose",                  Code = code },
            "ManifestStatuses"        => new ManifestStatusDefinition   { Name = "New Manifest Status",          Code = code },
            "InspectionStatuses"      => new InspectionStatusDefinition { Name = "New Inspection Status",        Code = code },
            "ClearanceStatuses"       => new ClearanceStatusDefinition  { Name = "New Clearance Status",         Code = code },
            "EnvironmentalConditions" => new EnvironmentalConditionDefinition { Name = "New Environmental Condition", Code = code },
            "NoticeTypes"             => new NoticeTypeDefinition       { Name = "New Notice Type",              Code = code },
            "PassengerCategories"     => new PassengerCategoryDefinition { Name = "New Passenger Category",      Code = code },
            "CommodityCategories"     => new CommodityCategoryDefinition { Name = "New Commodity Category",      Code = code },
            "StationTypes"            => new StationTypeDefinition      { Name = "New Station Type",             Code = code },
            "AuthorityTypes"          => new AuthorityTypeDefinition    { Name = "New Authority Type",           Code = code },
            "AnomalyTypes"            => new AnomalyTypeDefinition      { Name = "New Anomaly Type",             Code = code },
            "PhraseTemplates"         => new PhraseTemplate             { Name = "New Phrase Template",          Code = code },
            "Directives"              => new DirectiveDefinition        { Name = "New Directive",                Code = code },
            "BodyTypes"               => new BodyTypeDefinition         { Name = "New Body Type",                Code = code },
            "OrganisationTypes"       => new OrganisationTypeDefinition { Name = "New Organisation Type",        Code = code },
            _ => throw new InvalidOperationException($"No reference item factory for key '{key}'.")
        };
    }

    /// <summary>
    /// Produces a lowercase hyphenated placeholder code with a zero-padded 3-digit suffix.
    /// Example: PlaceholderCode("OperationTypes", 3) â†’ "new-operation-type-003"
    /// </summary>
    private static string PlaceholderCode(string key, int n)
    {
        string stem = key switch
        {
            "OperationTypes"          => "new-operation-type",
            "VesselClasses"           => "new-vessel-class",
            "Purposes"                => "new-purpose",
            "ManifestStatuses"        => "new-manifest-status",
            "InspectionStatuses"      => "new-inspection-status",
            "ClearanceStatuses"       => "new-clearance-status",
            "EnvironmentalConditions" => "new-environmental-condition",
            "NoticeTypes"             => "new-notice-type",
            "PassengerCategories"     => "new-passenger-category",
            "CommodityCategories"     => "new-commodity-category",
            "StationTypes"            => "new-station-type",
            "AuthorityTypes"          => "new-authority-type",
            "AnomalyTypes"            => "new-anomaly-type",
            "PhraseTemplates"         => "new-phrase-template",
            "Directives"              => "new-directive",
            "BodyTypes"               => "new-body-type",
            "OrganisationTypes"       => "new-organisation-type",
            _                         => "new-item"
        };
        return $"{stem}-{n:D3}";
    }

    // â”€â”€ UI state helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void UpdateTitleBar()
    {
        string file = string.IsNullOrEmpty(_appState.CurrentFilePath)
            ? "Untitled"
            : Path.GetFileName(_appState.CurrentFilePath);
        Text = $"PodcastUniverseEditor â€” {file}{(_appState.IsDirty ? " *" : string.Empty)}";
    }

    private void UpdateStatusFile()
    {
        lblCurrentFile.Text = string.IsNullOrEmpty(_appState.CurrentFilePath)
            ? "(unsaved)"
            : _appState.CurrentFilePath;
    }

    private void SetStatus(string message) => lblStatus.Text = message;

    private bool ConfirmDiscardChanges()
    {
        if (!_appState.IsDirty) return true;
        return MessageBox.Show(
            "The current project has unsaved changes. Discard them?",
            "Unsaved Changes",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
    }

    // â”€â”€ Setup helpers (called from MainForm_Load) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void PopulateReferenceTypesList()
    {
        lstReferenceTypes.Items.Clear();
        foreach (var rt in ReferenceTypes)
            lstReferenceTypes.Items.Add(rt);
    }

    private void SetupEpisodeEntryColumns()
    {
        gridEpisodeEntries.Columns.Clear();
        gridEpisodeEntries.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { Name = "colEntrySortOrder", HeaderText = "#",      DataPropertyName = "SortOrder",  Width = 40 },
            new DataGridViewTextBoxColumn { Name = "colEntryKind",      HeaderText = "Kind",   DataPropertyName = "EntryKind",  Width = 70 },
            new DataGridViewTextBoxColumn { Name = "colEntrySource",    HeaderText = "Source", DataPropertyName = "SourceType", Width = 80 },
            new DataGridViewTextBoxColumn { Name = "colEntryName",      HeaderText = "Name",   DataPropertyName = "Name",       AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colEntryLocked",    HeaderText = "Locked", DataPropertyName = "IsLocked",   Width = 60 },
            new DataGridViewTextBoxColumn { Name = "colEntryCanon",     HeaderText = "Canon",  DataPropertyName = "IsCanon",    Width = 60 },
        });
    }

    /// <summary>
    /// Hooks dirty-tracking events on each supplied grid.
    /// CellValueChanged covers manual cell edits; UserAddedRow/UserDeletedRow cover row
    /// add/delete via the grid UI; CurrentCellDirtyStateChanged + CommitEdit forces
    /// CheckBox columns to commit immediately so CellValueChanged fires on click.
    /// Called once from MainForm_Load; safe to call before a project is loaded.
    /// </summary>
    private void HookDirtyTracking(params DataGridView[] grids)
    {
        foreach (var g in grids)
        {
            g.CellValueChanged           += (_, _) => _appState.MarkDirty();
            g.UserAddedRow               += (_, _) => _appState.MarkDirty();
            g.UserDeletedRow             += (_, _) => _appState.MarkDirty();
            // CommitEdit immediately only for checkbox cells â€” forces CellValueChanged to fire
            // on click rather than requiring the user to press Enter or leave the cell.
            // Must NOT fire for text/combo cells: CommitEdit mid-keystroke pushes the partial
            // value into the binding source, which resets the cell and swallows the keystroke.
            g.CurrentCellDirtyStateChanged += (_, _) =>
            {
                if (g.IsCurrentCellDirty && g.CurrentCell is DataGridViewCheckBoxCell)
                    g.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }
    }

    /// <summary>
    /// Hooks BindingSource.ListChanged so that programmatic add/delete via BindingSource
    /// (e.g. RemoveCurrent, Add) also marks the project dirty.
    /// </summary>
    private void HookBindingSourceDirty(params BindingSource[] sources)
    {
        foreach (var bs in sources)
        {
            bs.ListChanged += (_, e) =>
            {
                if (e.ListChangedType is ListChangedType.ItemAdded or ListChangedType.ItemDeleted)
                    _appState.MarkDirty();
            };
        }
    }

    // â”€â”€ Entry detail panel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private EpisodeEntryRecord? GetSelectedEntry() => _bsEntries.Current as EpisodeEntryRecord;

    /// <summary>
    /// Returns true when the episode-level canon lock is set.
    /// Mutating handlers (add/delete entry, generate, manifest edits) must respect this.
    /// </summary>
    private static bool IsEpisodeLocked(EpisodeRecord ep) => ep.IsCanonicalLocked;

    /// <summary>
    /// Returns true when an entry may not be mutated.
    /// An entry is immutable if it is individually locked OR if it carries the canon flag
    /// (which is set automatically when its episode is locked as canon).
    /// </summary>
    private static bool IsEntryImmutable(EpisodeEntryRecord entry) => entry.IsLocked || entry.IsCanon;

    /// <summary>
    /// Rebuilds PodcastSeriesRecord.EpisodeIds for every series so it matches
    /// the current order of PodcastProject.Episodes.
    /// PodcastProject.Episodes is the authoritative episode list; EpisodeIds is derived.
    /// Called after any episode add, insert, duplicate, or delete.
    /// </summary>
    private static void SyncSeriesEpisodeIds(PodcastProject p)
    {
        foreach (var series in p.Series)
        {
            series.EpisodeIds = p.Episodes
                .Where(ep => ep.SeriesId == series.Id)
                .Select(ep => ep.Id)
                .ToList();
        }
    }

    /// <summary>
    /// Populates all project-data combo boxes in the entry detail panel.
    /// Called each time a new project is loaded; uses the current _lookup instance.
    /// </summary>
    private void PopulateEntryDetailCombos()
    {
        if (_lookup == null) return;

        // Code enum combos â€” bind directly to enum values, not LookupItems
        cboEntryKind.DataSource       = Enum.GetValues<EntryKind>();
        cboEntrySourceType.DataSource = Enum.GetValues<EntrySourceType>();

        // Project data combos
        SetLookupDataSource(cboEntryOperationType,            _lookup.OperationTypesAsLookup());
        SetLookupDataSource(cboEntryNoticeType,               _lookup.NoticeTypesAsLookup());
        SetLookupDataSource(cboEntryStation,                  _lookup.StationsAsLookup());
        SetLookupDataSource(cboEntryDock,                     _lookup.DocksAsLookup());
        SetLookupDataSource(cboEntryOriginStation,            _lookup.StationsAsLookup());
        SetLookupDataSource(cboEntryDestinationStation,       _lookup.StationsAsLookup());
        SetLookupDataSource(cboEntryVessel,                   _lookup.VesselsAsLookup());
        SetLookupDataSource(cboEntryVesselClassOverride,      _lookup.VesselClassesAsLookup());
        SetLookupDataSource(cboEntryDeclaredPurpose,          _lookup.PurposesAsLookup());
        SetLookupDataSource(cboEntryActualPurpose,            _lookup.PurposesAsLookup());
        SetLookupDataSource(cboEntryManifestStatus,           _lookup.ManifestStatusesAsLookup());
        SetLookupDataSource(cboEntryInspectionStatus,         _lookup.InspectionStatusesAsLookup());
        SetLookupDataSource(cboEntryClearanceStatus,          _lookup.ClearanceStatusesAsLookup());
        SetLookupDataSource(cboEntryEnvironmentalCondition,   _lookup.EnvironmentalConditionsAsLookup());
        SetLookupDataSource(cboEntryDirective,                _lookup.DirectivesAsLookup());
        SetLookupDataSource(cboEntryIncidentPhrase,    _lookup.PhraseTemplatesAsLookup("incident"));
        SetLookupDataSource(cboEntryResolutionPhrase,  _lookup.PhraseTemplatesAsLookup("resolution"));
        SetLookupDataSource(cboEntryRouteStatusPhrase, _lookup.PhraseTemplatesAsLookup("route_status"));
        SetLookupDataSource(cboEntryStoryThread,              _lookup.StoryThreadsAsLookup());
        SetLookupDataSource(cboEntryAnomalySeverity,          _lookup.SeverityLevelsAsLookup());

        RefreshBeatsCbo(null);

        // Populate entry kind filter combo
        cboEntryFilterKind.Items.Clear();
        cboEntryFilterKind.Items.Add("(All)");
        foreach (var k in Enum.GetValues<EntryKind>())
            cboEntryFilterKind.Items.Add(k.ToString());
        if (cboEntryFilterKind.Items.Count > 0) cboEntryFilterKind.SelectedIndex = 0;

        // Populate vessel and station filter combos; "(all)" at index 0 = no filter
        static List<LookupItem> AsFilterList(List<LookupItem> items)
        {
            var result = new List<LookupItem> { new LookupItem(string.Empty, "(all)") };
            result.AddRange(items.Skip(1)); // skip LookupItem.None
            return result;
        }
        SetLookupDataSource(cboEntryFilterVessel,  AsFilterList(_lookup.VesselsAsLookup()));
        SetLookupDataSource(cboEntryFilterStation, AsFilterList(_lookup.StationsAsLookup()));

        // Set up manifest grid columns with current project's commodity/passenger lists
        SetupManifestGridColumns();
    }

    /// <summary>
    /// Loads an entry into the detail panel controls.
    /// Sets _loadingEntry = true while populating to suppress write-back handlers.
    /// </summary>
    private void LoadEntryIntoDetailPanel(EpisodeEntryRecord? entry)
    {
        _loadingEntry = true;
        try
        {
            if (entry == null) { ClearDetailPanel(); return; }

            cboEntryKind.SelectedItem       = entry.EntryKind;
            cboEntrySourceType.SelectedItem = entry.SourceType;
            txtEntryName.Text               = entry.Name;
            numEntrySortOrder.Value         = entry.SortOrder;
            chkEntryLocked.Checked          = entry.IsLocked;
            chkEntryCanon.Checked           = entry.IsCanon;
            numEntryRandomSeed.Value        = entry.RandomSeed ?? 0;
            txtEntryNotes.Text              = entry.Notes;

            SetLookupCombo(cboEntryOperationType,            entry.OperationTypeId);
            SetLookupCombo(cboEntryNoticeType,               entry.NoticeTypeId);
            SetLookupCombo(cboEntryStation,                  entry.StationId);
            SetLookupCombo(cboEntryDock,                     entry.DockId);
            SetLookupCombo(cboEntryOriginStation,            entry.OriginStationId);
            SetLookupCombo(cboEntryDestinationStation,       entry.DestinationStationId);
            SetLookupCombo(cboEntryVessel,                   entry.VesselId);
            SetLookupCombo(cboEntryVesselClassOverride,      entry.VesselClassOverrideId);
            txtEntryRegistryOverride.Text                  = entry.RegistryOverride ?? string.Empty;
            SetLookupCombo(cboEntryDeclaredPurpose,          entry.DeclaredPurposeId);
            SetLookupCombo(cboEntryActualPurpose,            entry.ActualPurposeId);
            SetLookupCombo(cboEntryManifestStatus,           entry.ManifestStatusId);
            SetLookupCombo(cboEntryInspectionStatus,         entry.InspectionStatusId);
            SetLookupCombo(cboEntryClearanceStatus,          entry.ClearanceStatusId);
            SetLookupCombo(cboEntryEnvironmentalCondition,   entry.EnvironmentalConditionId);
            SetLookupCombo(cboEntryDirective,                entry.DirectiveId);
            SetLookupCombo(cboEntryIncidentPhrase,   entry.IncidentPhraseTemplateId);
            SetLookupCombo(cboEntryResolutionPhrase, entry.ResolutionPhraseTemplateId);
            SetLookupCombo(cboEntryRouteStatusPhrase,entry.RouteStatusPhraseTemplateId);
            txtEntryPublicBodyOverride.Text                = entry.PublicBodyOverride ?? string.Empty;

            // Story thread â€” refresh beats first, then set beat
            var thread = string.IsNullOrEmpty(entry.StoryThreadId) ? null
                : _appState.CurrentProject.StoryThreads.FirstOrDefault(t => t.Id == entry.StoryThreadId);
            SetLookupCombo(cboEntryStoryThread, entry.StoryThreadId);
            RefreshBeatsCbo(thread);
            SetLookupCombo(cboEntryAppliedStoryBeat, entry.AppliedStoryBeatId);

            SetLookupCombo(cboEntryAnomalySeverity,          entry.AnomalySeverity?.ToString());

            txtEntryHiddenTruthNotes.Text = entry.HiddenTruthNotes ?? string.Empty;

            bool hasSchedule = entry.ScheduledUtc.HasValue;
            chkEntryScheduledEnabled.Checked = hasSchedule;
            dtpEntryScheduledUtc.Enabled     = hasSchedule;
            dtpEntryScheduledUtc.Value       = entry.ScheduledUtc ?? DateTime.UtcNow;

            pnlEntryDetail.Enabled = true;
            ApplyEntryKindLayout(entry.EntryKind);

            // Manifest grids â€” BindingList wraps actual list by reference so grid edits flow through
            _bsDeclaredCargo.DataSource      = new BindingList<EntryCargoLine>(entry.DeclaredCargo);
            gridDeclaredCargo.DataSource     = _bsDeclaredCargo;
            _bsActualCargo.DataSource        = new BindingList<EntryCargoLine>(entry.ActualCargo);
            gridActualCargo.DataSource       = _bsActualCargo;
            _bsDeclaredPassengers.DataSource = new BindingList<EntryPassengerLine>(entry.DeclaredPassengers);
            gridDeclaredPassengers.DataSource = _bsDeclaredPassengers;
            _bsActualPassengers.DataSource   = new BindingList<EntryPassengerLine>(entry.ActualPassengers);
            gridActualPassengers.DataSource  = _bsActualPassengers;
        }
        finally
        {
            _loadingEntry = false;
        }

        UpdateEntryPreview(entry);
        UpdateThreadSummary(entry);
        RefreshRenderedOutput();
    }

    private void ClearDetailPanel()
    {
        _loadingEntry = true;
        try
        {
            pnlEntryDetail.Enabled = false;
            txtEpisodeEntryPreview.Clear();
            txtThreadSummary.Clear();

            _bsDeclaredCargo.DataSource       = null;
            gridDeclaredCargo.DataSource      = null;
            _bsActualCargo.DataSource         = null;
            gridActualCargo.DataSource        = null;
            _bsDeclaredPassengers.DataSource  = null;
            gridDeclaredPassengers.DataSource = null;
            _bsActualPassengers.DataSource    = null;
            gridActualPassengers.DataSource   = null;
        }
        finally
        {
            _loadingEntry = false;
        }

        // RefreshRenderedOutput is not called in the null-entry path, so clear hints explicitly.
        UpdateEntryValidationHints(null);
    }

    /// <summary>
    /// Repopulates cboEntryAppliedStoryBeat with the beats of the given thread.
    /// Pass null to show only the "(none)" sentinel.
    /// </summary>
    private void RefreshBeatsCbo(StoryThreadRecord? thread)
    {
        var items = _lookup?.BeatsAsLookup(thread) ?? new List<LookupItem> { LookupItem.None };
        SetLookupDataSource(cboEntryAppliedStoryBeat, items);
    }

    /// <summary>
    /// Enables or disables entry detail controls based on EntryKind.
    /// Traffic entries use operation/location/vessel/purpose/status/manifest/route-status fields.
    /// Notice entries use notice type and public body override.
    /// Incident and resolution phrase controls are shared â€” both kinds use them in the renderer.
    /// Shared fields (entry header, phrases, story thread, hidden truth, schedule) are always enabled.
    /// Uses Enabled rather than Visible because the TableLayoutPanel has fixed row heights.
    /// </summary>
    private void ApplyEntryKindLayout(EntryKind kind)
    {
        bool isTraffic = kind == EntryKind.Traffic;
        bool isNotice  = kind == EntryKind.Notice;

        // Traffic-only fields
        cboEntryOperationType.Enabled          = isTraffic;
        cboEntryStation.Enabled                = isTraffic;
        cboEntryDock.Enabled                   = isTraffic;
        cboEntryOriginStation.Enabled          = isTraffic;
        cboEntryDestinationStation.Enabled     = isTraffic;
        cboEntryVessel.Enabled                 = isTraffic;
        cboEntryVesselClassOverride.Enabled    = isTraffic;
        txtEntryRegistryOverride.Enabled       = isTraffic;
        cboEntryDeclaredPurpose.Enabled        = isTraffic;
        cboEntryActualPurpose.Enabled          = isTraffic;
        cboEntryManifestStatus.Enabled         = isTraffic;
        cboEntryInspectionStatus.Enabled       = isTraffic;
        cboEntryClearanceStatus.Enabled        = isTraffic;
        cboEntryEnvironmentalCondition.Enabled = isTraffic;
        cboEntryDirective.Enabled              = isTraffic;
        cboEntryRouteStatusPhrase.Enabled      = isTraffic;
        gridDeclaredCargo.Enabled              = isTraffic;
        btnDeclaredCargoAdd.Enabled            = isTraffic;
        btnDeclaredCargoDelete.Enabled         = isTraffic;
        gridActualCargo.Enabled                = isTraffic;
        btnActualCargoAdd.Enabled              = isTraffic;
        btnActualCargoDelete.Enabled           = isTraffic;
        gridDeclaredPassengers.Enabled         = isTraffic;
        btnDeclaredPassengerAdd.Enabled        = isTraffic;
        btnDeclaredPassengerDelete.Enabled     = isTraffic;
        gridActualPassengers.Enabled           = isTraffic;
        btnActualPassengerAdd.Enabled          = isTraffic;
        btnActualPassengerDelete.Enabled       = isTraffic;

        // Notice-only fields
        cboEntryNoticeType.Enabled             = isNotice;
        txtEntryPublicBodyOverride.Enabled     = isNotice;

        // cboEntryIncidentPhrase and cboEntryResolutionPhrase are shared:
        // both Traffic and Notice render paths use IncidentPhraseTemplateId and
        // ResolutionPhraseTemplateId, so these controls remain always enabled.
    }

    /// <summary>
    /// Evaluates entry validation rules and updates the flpValidationHints panel.
    /// Advisory only â€” does not block editing or modify data.
    /// Hidden when there are no warnings.
    /// </summary>
    private void UpdateEntryValidationHints(EpisodeEntryRecord? entry)
    {
        flpValidationHints.Controls.Clear();

        if (entry == null)
        {
            flpValidationHints.Visible = false;
            return;
        }

        var p = _appState.CurrentProject;

        void Warn(string message)
        {
            var lbl = new Label
            {
                Text      = "âš  " + message,
                AutoSize  = true,
                Margin    = new Padding(0, 1, 0, 1),
                ForeColor = Color.FromArgb(120, 60, 0)
            };
            flpValidationHints.Controls.Add(lbl);
        }

        // â”€â”€ General â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (string.IsNullOrWhiteSpace(entry.Name))
            Warn("Entry name is empty");

        if (string.IsNullOrEmpty(entry.IncidentPhraseTemplateId) &&
            string.IsNullOrEmpty(entry.ResolutionPhraseTemplateId))
            Warn("Both incident and resolution phrases are missing");

        // â”€â”€ EntryKind mismatch â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.EntryKind == EntryKind.Traffic)
        {
            if (!string.IsNullOrEmpty(entry.NoticeTypeId))
                Warn("Traffic entry has a notice type set");
        }
        else if (entry.EntryKind == EntryKind.Notice)
        {
            bool hasTrafficData = !string.IsNullOrEmpty(entry.OperationTypeId)
                || !string.IsNullOrEmpty(entry.StationId)
                || !string.IsNullOrEmpty(entry.DockId)
                || !string.IsNullOrEmpty(entry.VesselId)
                || entry.DeclaredCargo.Count > 0
                || entry.ActualCargo.Count > 0
                || entry.DeclaredPassengers.Count > 0
                || entry.ActualPassengers.Count > 0;

            if (hasTrafficData)
                Warn("Notice entry contains traffic data");
        }

        // â”€â”€ Traffic completeness â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.EntryKind == EntryKind.Traffic)
        {
            if (string.IsNullOrEmpty(entry.OperationTypeId))
                Warn("Missing operation type");
            else
            {
                var opType = p.OperationTypes.FirstOrDefault(o => o.Id == entry.OperationTypeId);
                if (opType != null)
                {
                    if (opType.RequiresOrigin && string.IsNullOrEmpty(entry.OriginStationId))
                        Warn($"{opType.Name} requires origin station");
                    if (opType.RequiresDestination && string.IsNullOrEmpty(entry.DestinationStationId))
                        Warn($"{opType.Name} requires destination station");
                }
            }

            if (string.IsNullOrEmpty(entry.StationId))
                Warn("Missing station");

            if (string.IsNullOrEmpty(entry.VesselId))
                Warn("Missing vessel");
        }

        // â”€â”€ Logical inconsistencies â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (!string.IsNullOrEmpty(entry.OriginStationId) &&
            !string.IsNullOrEmpty(entry.DestinationStationId) &&
            entry.OriginStationId == entry.DestinationStationId)
            Warn("Origin and destination are the same station");

        if (entry.DeclaredCargo.Count == 0 && entry.ActualCargo.Count > 0)
            Warn("Declared cargo empty but actual cargo is present");

        if (entry.DeclaredPassengers.Count == 0 && entry.ActualPassengers.Count > 0)
            Warn("Declared passengers empty but actual passengers are present");

        // â”€â”€ World rules â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (!string.IsNullOrEmpty(entry.DockId))
        {
            var dock = p.Docks.FirstOrDefault(d => d.Id == entry.DockId);
            if (dock != null && (dock.IsRestricted || dock.IsSuspended) &&
                string.IsNullOrEmpty(entry.DirectiveId))
                Warn("Dock is restricted or suspended but no directive is set");
        }

        foreach (var cargo in entry.DeclaredCargo)
        {
            var commodity = p.Commodities.FirstOrDefault(c => c.Id == cargo.CommodityId);
            if (commodity?.IsContraband == true)
            {
                Warn("Contraband present in declared cargo");
                break;
            }
        }

        // â”€â”€ Show/hide â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        flpValidationHints.Visible = flpValidationHints.Controls.Count > 0;
    }

    /// <summary>
    /// Wires all write-back event handlers for the entry detail panel controls.
    /// Called once from MainForm_Load. Each handler guards on _loadingEntry.
    /// All write-backs call RefreshRenderedOutput() so txtRenderedOutput stays live.
    /// </summary>
    private void HookEntryDetailHandlers()
    {
        // Helper â€” look up current entry.
        // Returns null if none selected, OR if the entry is immutable (locked/canon).
        // This suppresses all write-backs for locked/canon entries without modifying each handler.
        EpisodeEntryRecord? Entry()
        {
            var entry = GetSelectedEntry();
            return (entry == null || IsEntryImmutable(entry)) ? null : entry;
        }

        // â”€â”€ Structural â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        cboEntryKind.SelectedIndexChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            if (cboEntryKind.SelectedItem is EntryKind k)
            {
                e.EntryKind = k;
                ApplyEntryKindLayout(k);
            }
            RefreshRenderedOutput();
            _appState.MarkDirty();
        };

        cboEntrySourceType.SelectedIndexChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            if (cboEntrySourceType.SelectedItem is EntrySourceType s) e.SourceType = s;
            _appState.MarkDirty();
        };

        txtEntryName.TextChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.Name = txtEntryName.Text;
            RefreshRenderedOutput();
            _appState.MarkDirty();
        };

        numEntrySortOrder.ValueChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.SortOrder = (int)numEntrySortOrder.Value;
            _appState.MarkDirty();
        };

        chkEntryLocked.CheckedChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.IsLocked = chkEntryLocked.Checked;
            _appState.MarkDirty();
        };

        chkEntryCanon.CheckedChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.IsCanon = chkEntryCanon.Checked;
            _appState.MarkDirty();
        };

        numEntryRandomSeed.ValueChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.RandomSeed = (int)numEntryRandomSeed.Value;
            _appState.MarkDirty();
        };

        txtEntryNotes.TextChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.Notes = txtEntryNotes.Text;
            _appState.MarkDirty();
        };

        // â”€â”€ Lookup combos â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // updatePreview=true also calls UpdateEntryPreview; all combos call RefreshRenderedOutput.

        void WireLookupCombo(ComboBox cbo, Action<EpisodeEntryRecord, string?> setter, bool updatePreview = false)
        {
            cbo.SelectedIndexChanged += (_, _) =>
            {
                if (_loadingEntry) return;
                var e = Entry(); if (e == null) return;
                setter(e, GetSelectedLookupId(cbo));
                if (updatePreview) UpdateEntryPreview(e);
                RefreshRenderedOutput();
                _appState.MarkDirty();
            };
        }

        WireLookupCombo(cboEntryOperationType,          (e, id) => e.OperationTypeId          = id, updatePreview: true);
        WireLookupCombo(cboEntryNoticeType,             (e, id) => e.NoticeTypeId              = id, updatePreview: true);
        WireLookupCombo(cboEntryStation,                (e, id) => e.StationId                 = id, updatePreview: true);
        WireLookupCombo(cboEntryDock,                   (e, id) => e.DockId                    = id, updatePreview: true);
        WireLookupCombo(cboEntryOriginStation,          (e, id) => e.OriginStationId            = id, updatePreview: true);
        WireLookupCombo(cboEntryDestinationStation,     (e, id) => e.DestinationStationId       = id, updatePreview: true);
        WireLookupCombo(cboEntryVessel,                 (e, id) => e.VesselId                  = id, updatePreview: true);
        WireLookupCombo(cboEntryVesselClassOverride,    (e, id) => e.VesselClassOverrideId      = id, updatePreview: true);
        WireLookupCombo(cboEntryDeclaredPurpose,        (e, id) => e.DeclaredPurposeId          = id, updatePreview: true);
        WireLookupCombo(cboEntryActualPurpose,          (e, id) => e.ActualPurposeId            = id, updatePreview: true);
        WireLookupCombo(cboEntryManifestStatus,         (e, id) => e.ManifestStatusId           = id, updatePreview: true);
        WireLookupCombo(cboEntryInspectionStatus,       (e, id) => e.InspectionStatusId         = id, updatePreview: true);
        WireLookupCombo(cboEntryClearanceStatus,        (e, id) => e.ClearanceStatusId          = id, updatePreview: true);
        WireLookupCombo(cboEntryEnvironmentalCondition, (e, id) => e.EnvironmentalConditionId   = id, updatePreview: true);
        WireLookupCombo(cboEntryDirective,              (e, id) => e.DirectiveId                = id, updatePreview: true);
        WireLookupCombo(cboEntryIncidentPhrase,         (e, id) => e.IncidentPhraseTemplateId   = id, updatePreview: true);
        WireLookupCombo(cboEntryResolutionPhrase,       (e, id) => e.ResolutionPhraseTemplateId  = id, updatePreview: true);
        WireLookupCombo(cboEntryRouteStatusPhrase,      (e, id) => e.RouteStatusPhraseTemplateId = id, updatePreview: true);
        WireLookupCombo(cboEntryAppliedStoryBeat,       (e, id) => e.AppliedStoryBeatId          = id, updatePreview: true);

        txtEntryRegistryOverride.TextChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.RegistryOverride = NullIfEmpty(txtEntryRegistryOverride.Text);
            RefreshRenderedOutput();
            _appState.MarkDirty();
        };

        txtEntryPublicBodyOverride.TextChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.PublicBodyOverride = NullIfEmpty(txtEntryPublicBodyOverride.Text);
            RefreshRenderedOutput();
            _appState.MarkDirty();
        };

        txtEntryHiddenTruthNotes.TextChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            e.HiddenTruthNotes = NullIfEmpty(txtEntryHiddenTruthNotes.Text);
            // Hidden truth notes are not reflected in rendered output
            _appState.MarkDirty();
        };

        // â”€â”€ Story thread â€” also refreshes beats combo â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        cboEntryStoryThread.SelectedIndexChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            var threadId = GetSelectedLookupId(cboEntryStoryThread);
            e.StoryThreadId      = threadId;
            e.AppliedStoryBeatId = null;
            var thread = string.IsNullOrEmpty(threadId) ? null
                : _appState.CurrentProject.StoryThreads.FirstOrDefault(t => t.Id == threadId);
            RefreshBeatsCbo(thread);
            UpdateEntryPreview(e);
            RefreshRenderedOutput();
            _appState.MarkDirty();
        };

        // â”€â”€ Anomaly severity â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        cboEntryAnomalySeverity.SelectedIndexChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            var id = GetSelectedLookupId(cboEntryAnomalySeverity);
            e.AnomalySeverity = string.IsNullOrEmpty(id) ? null : Enum.Parse<SeverityLevel>(id);
            UpdateEntryPreview(e);
            _appState.MarkDirty();
        };

        // â”€â”€ Schedule â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        chkEntryScheduledEnabled.CheckedChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            dtpEntryScheduledUtc.Enabled = chkEntryScheduledEnabled.Checked;
            e.ScheduledUtc = chkEntryScheduledEnabled.Checked ? dtpEntryScheduledUtc.Value : null;
            UpdateEntryPreview(e);
            _appState.MarkDirty();
        };

        dtpEntryScheduledUtc.ValueChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            if (chkEntryScheduledEnabled.Checked) e.ScheduledUtc = dtpEntryScheduledUtc.Value;
            UpdateEntryPreview(e);
            _appState.MarkDirty();
        };
    }

    // â”€â”€ Entry detail helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private static void SetLookupDataSource(ComboBox cbo, List<LookupItem> items)
    {
        cbo.DataSource    = null;
        cbo.DisplayMember = string.Empty;
        cbo.ValueMember   = string.Empty;
        cbo.DataSource    = items;
        cbo.DisplayMember = "Display";
        cbo.ValueMember   = "Id";
        if (cbo.Items.Count > 0) cbo.SelectedIndex = 0;
    }

    private static void SetLookupCombo(ComboBox cbo, string? id)
    {
        if (cbo.DataSource is not List<LookupItem> items) return;
        string target = id ?? string.Empty;
        var match = items.FirstOrDefault(i => i.Id == target) ?? items.FirstOrDefault();
        cbo.SelectedItem = match;
    }

    private static string? GetSelectedLookupId(ComboBox cbo)
    {
        if (cbo.SelectedItem is LookupItem item && !string.IsNullOrEmpty(item.Id))
            return item.Id;
        return null;
    }

    private static string? NullIfEmpty(string? value) =>
        string.IsNullOrEmpty(value) ? null : value;

    // â”€â”€ Rendered output â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Renders the currently selected episode to txtRenderedOutput.
    /// Clears the text box if no episode is selected.
    /// </summary>
    private void RefreshRenderedOutput()
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep)
        {
            txtRenderedOutput.Clear();
            return;
        }
        txtRenderedOutput.Text = _renderer.RenderEpisode(_appState.CurrentProject, ep);
        UpdateEntryValidationHints(GetSelectedEntry());
    }

    // â”€â”€ Episode tools â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnEpisodeMoveUp_Click(object? sender, EventArgs e)
        => MoveSelectedEpisode(direction: -1);

    private void btnEpisodeMoveDown_Click(object? sender, EventArgs e)
        => MoveSelectedEpisode(direction: +1);

    /// <summary>
    /// Moves the currently selected episode one position up (direction = -1) or down (+1)
    /// within the currently selected series, then reapplies the filter and preserves selection.
    /// Operates on p.Episodes (authoritative order); EpisodeIds is rebuilt via SyncSeriesEpisodeIds.
    /// A selected series is required â€” episodes are never moved across series boundaries.
    /// No lock check: reordering does not mutate episode content, so IsCanonicalLocked is not applied.
    /// </summary>
    private void MoveSelectedEpisode(int direction)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        var selectedSeries = _bsSeries.Current as PodcastSeriesRecord;
        if (selectedSeries == null)
        {
            SetStatus("Select a series to reorder episodes within it.");
            return;
        }

        var p = _appState.CurrentProject;

        // Collect (global index, episode) pairs for episodes in this series, preserving p.Episodes order.
        var inSeries = p.Episodes
            .Select((e, i) => (Episode: e, GlobalIndex: i))
            .Where(x => x.Episode.SeriesId == selectedSeries.Id)
            .ToList();

        int posInSeries = inSeries.FindIndex(x => x.Episode.Id == ep.Id);
        if (posInSeries < 0) return;

        int targetPosInSeries = posInSeries + direction;
        if (targetPosInSeries < 0 || targetPosInSeries >= inSeries.Count) return; // at boundary â€” do nothing

        // Swap the two episodes in the global list
        int idxA = inSeries[posInSeries].GlobalIndex;
        int idxB = inSeries[targetPosInSeries].GlobalIndex;
        (p.Episodes[idxA], p.Episodes[idxB]) = (p.Episodes[idxB], p.Episodes[idxA]);

        SyncSeriesEpisodeIds(p);
        ApplyEpisodeFilter();

        // Restore selection by ID â€” robust under active search filters
        for (int i = 0; i < _episodesView.Count; i++)
        {
            if (_episodesView[i].Id == ep.Id)
            {
                _bsEpisodes.Position = i;
                break;
            }
        }

        _appState.MarkDirty();
    }

    private void btnEpisodeDuplicate_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        // Deep copy via JSON round-trip â€” captures all nested lists (entries, cargo, passengers)
        // without shared references.
        var opts = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
        var json = JsonSerializer.Serialize(ep, opts);
        var copy = JsonSerializer.Deserialize<EpisodeRecord>(json, opts)!;

        // Fresh episode identity â€” canon lock cleared; duplicate starts as an editable draft.
        copy.Id                = Guid.NewGuid().ToString();
        copy.CreatedUtc        = DateTime.UtcNow;
        copy.ModifiedUtc       = DateTime.UtcNow;
        copy.IsCanonicalLocked = false;
        copy.Name              = string.IsNullOrWhiteSpace(ep.Name)
            ? "Episode Copy"
            : $"{ep.Name} Copy";

        // SeriesId is preserved from the JSON copy â€” duplicate stays in the same series.

        // Reset every entry to a clean manual draft.
        foreach (var entry in copy.Entries)
        {
            entry.Id          = Guid.NewGuid().ToString();
            entry.CreatedUtc  = DateTime.UtcNow;
            entry.ModifiedUtc = DateTime.UtcNow;
            entry.SourceType  = EntrySourceType.Manual;
            entry.IsLocked    = false;
            entry.IsCanon     = false;
            entry.RandomSeed  = null;
        }

        var p = _appState.CurrentProject;
        p.Episodes.Add(copy);
        SyncSeriesEpisodeIds(p);
        ApplyEpisodeFilter();

        // Select the new episode by ID â€” more robust than Count - 1 under active filters.
        for (int i = 0; i < _episodesView.Count; i++)
        {
            if (_episodesView[i].Id == copy.Id)
            {
                _bsEpisodes.Position = i;
                break;
            }
        }

        _appState.MarkDirty();
        SetStatus($"Episode '{ep.Name}' duplicated.");
    }

    private void btnLockEpisodeCanon_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;
        if (ep.IsCanonicalLocked) { SetStatus($"'{ep.Name}' is already locked."); return; }

        var confirm = MessageBox.Show(
            $"Lock '{ep.Name}' as canon?\n\n" +
            $"All {ep.Entries.Count} entries will be marked IsCanon = true and IsLocked = true.\n" +
            "This cannot be reversed from the episode level â€” entries must be unlocked individually.",
            "Confirm Canon Lock", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        // Mark episode-level lock
        ep.IsCanonicalLocked = true;

        // Mark all entries as canon history and individually locked.
        // Rule: locking an episode stamps every entry as immutable canon.
        // Unlocking the episode later only clears the episode flag â€” entries stay tagged.
        foreach (var entry in ep.Entries)
        {
            entry.IsCanon  = true;
            entry.IsLocked = true;
        }

        UpdateEpisodeSummary(ep);
        ApplyEntryFilter(ep);     // refresh grid to show updated canon/locked columns
        _appState.MarkDirty();
        SetStatus($"Episode '{ep.Name}' locked as canon â€” all entries marked locked and canon.");
    }

    private void btnUnlockEpisodeCanon_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;
        if (!ep.IsCanonicalLocked) { SetStatus($"'{ep.Name}' is not locked."); return; }

        var confirm = MessageBox.Show(
            $"Unlock '{ep.Name}'?\n\n" +
            "The episode-level canon lock will be cleared.\n" +
            "Existing entries will REMAIN individually locked and canon-tagged.\n" +
            "To edit an entry, unlock it individually via the entry's IsLocked checkbox.",
            "Confirm Unlock", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        // Rule: unlock clears only the episode-level flag.
        // Entries keep their IsCanon = true and IsLocked = true so canon history is preserved.
        // Individual entries can be unlocked manually if the author needs to revise them.
        ep.IsCanonicalLocked = false;

        UpdateEpisodeSummary(ep);
        _appState.MarkDirty();
        SetStatus($"Episode '{ep.Name}' unlocked. Entry locks remain â€” unlock entries individually to edit.");
    }

    private void btnNewEpisodeAfterSelected_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;
        if (p.Series.Count == 0)
        {
            var defaultSeries = new PodcastSeriesRecord { Name = "Series 1" };
            p.Series.Add(defaultSeries);
        }

        // Inherit the selected episode's series; fall back to the first series.
        string seriesId = (_bsEpisodes.Current is EpisodeRecord sel2 && !string.IsNullOrEmpty(sel2.SeriesId))
            ? sel2.SeriesId
            : p.Series[0].Id;

        int insertIdx = _bsEpisodes.Current is EpisodeRecord sel
            ? p.Episodes.IndexOf(sel) + 1
            : p.Episodes.Count;

        var ep = new EpisodeRecord
        {
            Name          = $"Episode {p.Episodes.Count + 1}",
            SeriesId      = seriesId,
            InUniverseUtc = DateTime.UtcNow
        };

        p.Episodes.Insert(insertIdx, ep);
        SyncSeriesEpisodeIds(p);
        ApplyEpisodeFilter();
        int viewIdx = _episodesView.IndexOf(ep);
        if (viewIdx >= 0) _bsEpisodes.Position = viewIdx;
        _appState.MarkDirty();
    }

    // â”€â”€ Manifest cargo/passenger handlers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Returns the selected entry only if it may be mutated.
    /// Returns null (and shows a message) if the episode is canon-locked or the entry is immutable.
    /// </summary>
    private EpisodeEntryRecord? GetMutableEntry()
    {
        if (_bsEpisodes.Current is EpisodeRecord ep && IsEpisodeLocked(ep))
        {
            MessageBox.Show(
                "This episode is locked as canon. Unlock it before editing.",
                "Canon Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        var entry = GetSelectedEntry();
        if (entry != null && IsEntryImmutable(entry))
        {
            MessageBox.Show(
                "This entry is locked or canon and cannot be edited.",
                "Entry Immutable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        return entry;
    }

    private void btnDeclaredCargoAdd_Click(object? sender, EventArgs e)
    {
        if (GetMutableEntry() == null) return;
        _bsDeclaredCargo.Add(new EntryCargoLine { IsDeclared = true });
        _appState.MarkDirty();
    }

    private void btnDeclaredCargoDelete_Click(object? sender, EventArgs e)
    {
        if (GetMutableEntry() == null || _bsDeclaredCargo.Current == null) return;
        _bsDeclaredCargo.RemoveCurrent();
        _appState.MarkDirty();
    }

    private void btnActualCargoAdd_Click(object? sender, EventArgs e)
    {
        if (GetMutableEntry() == null) return;
        _bsActualCargo.Add(new EntryCargoLine { IsDeclared = false, IsHiddenTruthOnly = true });
        _appState.MarkDirty();
    }

    private void btnActualCargoDelete_Click(object? sender, EventArgs e)
    {
        if (GetMutableEntry() == null || _bsActualCargo.Current == null) return;
        _bsActualCargo.RemoveCurrent();
        _appState.MarkDirty();
    }

    private void btnDeclaredPassengerAdd_Click(object? sender, EventArgs e)
    {
        if (GetMutableEntry() == null) return;
        _bsDeclaredPassengers.Add(new EntryPassengerLine { IsDeclared = true });
        _appState.MarkDirty();
    }

    private void btnDeclaredPassengerDelete_Click(object? sender, EventArgs e)
    {
        if (GetMutableEntry() == null || _bsDeclaredPassengers.Current == null) return;
        _bsDeclaredPassengers.RemoveCurrent();
        _appState.MarkDirty();
    }

    private void btnActualPassengerAdd_Click(object? sender, EventArgs e)
    {
        if (GetMutableEntry() == null) return;
        _bsActualPassengers.Add(new EntryPassengerLine { IsDeclared = false, IsHiddenTruthOnly = true });
        _appState.MarkDirty();
    }

    private void btnActualPassengerDelete_Click(object? sender, EventArgs e)
    {
        if (GetMutableEntry() == null || _bsActualPassengers.Current == null) return;
        _bsActualPassengers.RemoveCurrent();
        _appState.MarkDirty();
    }

    // â”€â”€ Filter handlers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void txtEpisodeSearch_TextChanged(object? sender, EventArgs e)
    {
        ApplyEpisodeFilter();
    }

    private void cboEntryFilterKind_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_clearingEntryFilters) return;
        if (_bsEpisodes.Current is EpisodeRecord ep)
            ApplyEntryFilter(ep);
    }

    private void cboEntryFilterVessel_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_clearingEntryFilters) return;
        if (_bsEpisodes.Current is EpisodeRecord ep)
            ApplyEntryFilter(ep);
    }

    private void cboEntryFilterStation_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_clearingEntryFilters) return;
        if (_bsEpisodes.Current is EpisodeRecord ep)
            ApplyEntryFilter(ep);
    }

    private void chkShowLockedOnly_CheckedChanged(object? sender, EventArgs e)
    {
        if (_clearingEntryFilters) return;
        if (_bsEpisodes.Current is EpisodeRecord ep)
            ApplyEntryFilter(ep);
    }

    private void txtEntrySearch_TextChanged(object? sender, EventArgs e)
    {
        if (_clearingEntryFilters) return;
        if (_bsEpisodes.Current is EpisodeRecord ep)
            ApplyEntryFilter(ep);
    }

    private void btnClearEntryFilters_Click(object? sender, EventArgs e)
    {
        _clearingEntryFilters = true;
        try
        {
            txtEntrySearch.Text = string.Empty;
            if (cboEntryFilterKind.Items.Count > 0) cboEntryFilterKind.SelectedIndex = 0;
            SetLookupCombo(cboEntryFilterVessel,  null);
            SetLookupCombo(cboEntryFilterStation, null);
            chkShowLockedOnly.Checked = false;
        }
        finally
        {
            _clearingEntryFilters = false;
        }
        if (_bsEpisodes.Current is EpisodeRecord ep)
            ApplyEntryFilter(ep);
    }

    // â”€â”€ Filter view helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void ApplyEpisodeFilter()
    {
        var p = _appState.CurrentProject;
        string search = txtEpisodeSearch.Text.Trim().ToLowerInvariant();
        var selectedSeries = _bsSeries.Current as PodcastSeriesRecord;

        _episodesView.RaiseListChangedEvents = false;
        _episodesView.Clear();
        foreach (var ep in p.Episodes)
        {
            // Series filter â€” skip episodes not in the selected series (if one is selected)
            if (selectedSeries != null && ep.SeriesId != selectedSeries.Id) continue;

            if (!string.IsNullOrEmpty(search) && !ep.Name.ToLowerInvariant().Contains(search))
                continue;
            _episodesView.Add(ep);
        }
        _episodesView.RaiseListChangedEvents = true;
        _episodesView.ResetBindings();
    }

    private void ApplyEntryFilter(EpisodeRecord? ep)
    {
        // Save current selection so we can try to restore it after the view rebuilds
        string? selectedId = GetSelectedEntry()?.Id;

        bool    lockedOnly = chkShowLockedOnly.Checked;
        string? kindStr    = cboEntryFilterKind.SelectedIndex > 0
            ? cboEntryFilterKind.SelectedItem?.ToString()
            : null;
        string? search    = string.IsNullOrWhiteSpace(txtEntrySearch.Text)
            ? null
            : txtEntrySearch.Text.Trim();
        string? vesselId  = GetSelectedLookupId(cboEntryFilterVessel);
        string? stationId = GetSelectedLookupId(cboEntryFilterStation);

        _entriesView.RaiseListChangedEvents = false;
        _entriesView.Clear();
        if (ep != null)
        {
            foreach (var entry in ep.Entries)
            {
                if (lockedOnly && !entry.IsLocked && !entry.IsCanon) continue;
                if (kindStr != null && entry.EntryKind.ToString() != kindStr) continue;
                if (search    != null && !entry.Name.Contains(search, StringComparison.OrdinalIgnoreCase)) continue;
                if (vesselId  != null && entry.VesselId  != vesselId)  continue;
                if (stationId != null && entry.StationId != stationId) continue;
                _entriesView.Add(entry);
            }
        }
        _entriesView.RaiseListChangedEvents = true;
        _entriesView.ResetBindings();

        // Restore selection: if the previously selected entry survived the filter, keep it.
        // Otherwise select the first visible entry (position 0 is set implicitly by ResetBindings).
        if (selectedId != null)
        {
            for (int i = 0; i < _entriesView.Count; i++)
            {
                if (_entriesView[i].Id == selectedId)
                {
                    _bsEntries.Position = i;
                    return;
                }
            }
        }
    }

    // â”€â”€ Thread / episode summaries â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void UpdateThreadSummary(EpisodeEntryRecord? entry)
    {
        if (entry == null || _lookup == null || string.IsNullOrEmpty(entry.StoryThreadId))
        {
            txtThreadSummary.Clear();
            return;
        }

        var thread = _lookup.Thread(entry.StoryThreadId);
        if (thread == null) { txtThreadSummary.Clear(); return; }

        var appliedBeat = _lookup.Beat(entry.AppliedStoryBeatId);
        var nextBeat    = thread.Beats.FirstOrDefault(b =>
            b.StageIndex == thread.CurrentStageIndex + 1);

        var sb = new System.Text.StringBuilder();

        // Show lock/canon state of this entry prominently
        string entryFlags = (entry.IsCanon, entry.IsLocked) switch
        {
            (true,  true)  => "  [CANON | LOCKED]",
            (true,  false) => "  [CANON]",
            (false, true)  => "  [LOCKED]",
            _              => string.Empty
        };
        sb.AppendLine($"Thread: {thread.Name}{entryFlags}");
        sb.AppendLine($"Stage: {thread.CurrentStageIndex}  Cooldown: {thread.EpisodesUntilEligible}");
        if (appliedBeat != null)
            sb.AppendLine($"Applied: {appliedBeat.Name} (Stage {appliedBeat.StageIndex})");
        if (nextBeat != null)
            sb.AppendLine($"Next:    {nextBeat.Name} (Stage {nextBeat.StageIndex})");

        txtThreadSummary.Text = sb.ToString().TrimEnd();
    }

    private void UpdateEpisodeSummary(EpisodeRecord? ep)
    {
        if (ep == null) { txtEpisodeSummary.Clear(); return; }

        var sb = new System.Text.StringBuilder();
        string lockStatus = ep.IsCanonicalLocked ? "[CANON LOCKED â€” immutable]" : "[unlocked]";
        sb.AppendLine($"{ep.Name}  {lockStatus}");

        int canonCount  = ep.Entries.Count(e => e.IsCanon);
        int lockedCount = ep.Entries.Count(e => e.IsLocked);
        sb.AppendLine($"Entries: {ep.Entries.Count}  (canon: {canonCount}, locked: {lockedCount})");

        var threadIds = ep.Entries
            .Where(e => !string.IsNullOrEmpty(e.StoryThreadId))
            .Select(e => e.StoryThreadId!)
            .Distinct();

        foreach (var tid in threadIds)
        {
            var thread = _appState.CurrentProject.StoryThreads.FirstOrDefault(t => t.Id == tid);
            if (thread == null) continue;
            int beatCount = ep.Entries.Count(e => e.StoryThreadId == tid && e.AppliedStoryBeatId != null);
            sb.AppendLine($"  Thread: {thread.Name}  Stage {thread.CurrentStageIndex}  Cooldown: {thread.EpisodesUntilEligible}  Beats here: {beatCount}");
        }

        txtEpisodeSummary.Text = sb.ToString().TrimEnd();
    }

    // â”€â”€ Manifest grid column setup â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void SetupManifestGridColumns()
    {
        if (_lookup == null) return;

        var commodities   = _lookup.CommoditiesAsLookup();
        var passengerCats = _lookup.PassengerCategoriesAsLookup();

        // Declared cargo
        gridDeclaredCargo.Columns.Clear();
        gridDeclaredCargo.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewComboBoxColumn { Name = "colDeclaredCargoCommodity", HeaderText = "Commodity",  DataPropertyName = "CommodityId", DataSource = commodities, DisplayMember = "Display", ValueMember = "Id", Width = 160 },
            new DataGridViewTextBoxColumn  { Name = "colDeclaredCargoQty",       HeaderText = "Qty",        DataPropertyName = "Quantity",    Width = 60 },
            new DataGridViewCheckBoxColumn { Name = "colDeclaredCargoDeclared",  HeaderText = "Declared",   DataPropertyName = "IsDeclared",  Width = 70 },
        });

        // Actual cargo
        gridActualCargo.Columns.Clear();
        gridActualCargo.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewComboBoxColumn { Name = "colActualCargoCommodity", HeaderText = "Commodity",   DataPropertyName = "CommodityId",      DataSource = commodities, DisplayMember = "Display", ValueMember = "Id", Width = 160 },
            new DataGridViewTextBoxColumn  { Name = "colActualCargoQty",       HeaderText = "Qty",         DataPropertyName = "Quantity",          Width = 60 },
            new DataGridViewCheckBoxColumn { Name = "colActualCargoHidden",    HeaderText = "Hidden Only", DataPropertyName = "IsHiddenTruthOnly", Width = 90 },
        });

        // Declared passengers
        gridDeclaredPassengers.Columns.Clear();
        gridDeclaredPassengers.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewComboBoxColumn { Name = "colDeclaredPassengerCat",      HeaderText = "Category", DataPropertyName = "PassengerCategoryId", DataSource = passengerCats, DisplayMember = "Display", ValueMember = "Id", Width = 140 },
            new DataGridViewTextBoxColumn  { Name = "colDeclaredPassengerCount",    HeaderText = "Count",    DataPropertyName = "Count",               Width = 60 },
            new DataGridViewCheckBoxColumn { Name = "colDeclaredPassengerDeclared", HeaderText = "Declared", DataPropertyName = "IsDeclared",          Width = 70 },
        });

        // Actual passengers
        gridActualPassengers.Columns.Clear();
        gridActualPassengers.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewComboBoxColumn { Name = "colActualPassengerCat",    HeaderText = "Category",   DataPropertyName = "PassengerCategoryId", DataSource = passengerCats, DisplayMember = "Display", ValueMember = "Id", Width = 140 },
            new DataGridViewTextBoxColumn  { Name = "colActualPassengerCount",  HeaderText = "Count",      DataPropertyName = "Count",               Width = 60 },
            new DataGridViewCheckBoxColumn { Name = "colActualPassengerHidden", HeaderText = "Hidden Only",DataPropertyName = "IsHiddenTruthOnly",   Width = 90 },
        });
    }

    // â”€â”€ Episode / series metadata panel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Populates the episode/series metadata combo boxes with current project data.
    /// Called each time a new project is loaded (after _lookup is rebuilt).
    /// </summary>
    private void PopulateEpisodeMetaCombos()
    {
        if (_lookup == null) return;
        SetLookupDataSource(cboEpisodeBroadcastStation, _lookup.StationsAsLookup());
        SetLookupDataSource(cboEpisodeSeries,           _lookup.SeriesAsLookup());
        SetLookupDataSource(cboSeriesBroadcastStation,  _lookup.StationsAsLookup());
    }

    /// <summary>
    /// Loads an episode's metadata into the metadata panel controls.
    /// Pass null to clear and disable the panel (no selection).
    /// </summary>
    private void LoadEpisodeIntoMetaPanel(EpisodeRecord? ep)
    {
        _loadingEpisodeMeta = true;
        try
        {
            if (ep == null)
            {
                // Clear and disable the episode section only.
                // The series section (txtSeriesName etc.) is driven by lstSeries independently.
                pnlEpisodeMetaEditor.Enabled        = false;
                txtEpisodeName.Text                 = string.Empty;
                chkEpisodeHasInUniverseDate.Checked = false;
                dtpEpisodeInUniverseUtc.Enabled     = false;
                dtpEpisodeInUniverseUtc.Value       = DateTime.Now;
                SetLookupCombo(cboEpisodeBroadcastStation, null);
                SetLookupCombo(cboEpisodeSeries,           null);
                chkEpisodeCanonicalLocked.Checked   = false;
                txtEpisodeNotes.Text                = string.Empty;
                return;
            }

            pnlEpisodeMetaEditor.Enabled = true;
            txtEpisodeName.Text          = ep.Name;

            bool hasDate = ep.InUniverseUtc.HasValue;
            chkEpisodeHasInUniverseDate.Checked = hasDate;
            dtpEpisodeInUniverseUtc.Enabled     = hasDate;
            dtpEpisodeInUniverseUtc.Value       = ep.InUniverseUtc ?? DateTime.UtcNow;

            SetLookupCombo(cboEpisodeBroadcastStation, ep.BroadcastStationId);
            SetLookupCombo(cboEpisodeSeries,           ep.SeriesId);
            chkEpisodeCanonicalLocked.Checked = ep.IsCanonicalLocked;
            txtEpisodeNotes.Text              = ep.Notes;
            // Series section is not loaded here â€” it is driven by lstSeries selection.
        }
        finally
        {
            _loadingEpisodeMeta = false;
        }
    }

    /// <summary>
    /// Loads a series into the series section of the metadata panel.
    /// Pass null to clear the section (no series selected).
    /// Caller must set _loadingEpisodeMeta = true before calling to suppress write-backs.
    /// </summary>
    private void LoadSeriesIntoMetaPanel(PodcastSeriesRecord? series)
    {
        if (series == null)
        {
            txtSeriesName.Text = string.Empty;
            SetLookupCombo(cboSeriesBroadcastStation, null);
            txtSeriesNotes.Text = string.Empty;
            return;
        }

        txtSeriesName.Text = series.Name;
        SetLookupCombo(cboSeriesBroadcastStation, series.BroadcastStationId);
        txtSeriesNotes.Text = series.Notes;
    }

    /// <summary>
    /// Wires all write-back event handlers for the episode/series metadata panel.
    /// Called once from MainForm_Load. Each handler guards on _loadingEpisodeMeta.
    /// </summary>
    private void HookEpisodeMetaHandlers()
    {
        EpisodeRecord? Ep() => _bsEpisodes.Current as EpisodeRecord;

        // Series() returns the series selected in lstSeries â€” that is the authoritative
        // series for the series metadata section, regardless of which episode is selected.
        PodcastSeriesRecord? Series() => _bsSeries.Current as PodcastSeriesRecord;

        // â”€â”€ Episode fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        txtEpisodeName.TextChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var ep = Ep(); if (ep == null) return;
            ep.Name = txtEpisodeName.Text;
            _bsEpisodes.ResetCurrentItem(); // refresh display name in list
            UpdateEpisodeSummary(ep);
            _appState.MarkDirty();
        };

        chkEpisodeHasInUniverseDate.CheckedChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var ep = Ep(); if (ep == null) return;
            dtpEpisodeInUniverseUtc.Enabled = chkEpisodeHasInUniverseDate.Checked;
            ep.InUniverseUtc = chkEpisodeHasInUniverseDate.Checked ? dtpEpisodeInUniverseUtc.Value : null;
            _appState.MarkDirty();
        };

        dtpEpisodeInUniverseUtc.ValueChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var ep = Ep(); if (ep == null) return;
            if (chkEpisodeHasInUniverseDate.Checked) ep.InUniverseUtc = dtpEpisodeInUniverseUtc.Value;
            _appState.MarkDirty();
        };

        cboEpisodeBroadcastStation.SelectedIndexChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var ep = Ep(); if (ep == null) return;
            ep.BroadcastStationId = GetSelectedLookupId(cboEpisodeBroadcastStation);
            _appState.MarkDirty();
        };

        cboEpisodeSeries.SelectedIndexChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var ep = Ep(); if (ep == null) return;
            ep.SeriesId = GetSelectedLookupId(cboEpisodeSeries) ?? string.Empty;
            SyncSeriesEpisodeIds(_appState.CurrentProject);
            // Re-filter the episode list: the episode may have left the currently-selected series.
            ApplyEpisodeFilter();
            _appState.MarkDirty();
        };

        // chkEpisodeCanonicalLocked has AutoCheck = false and no write-back handler.
        // It is display-only. Use btnLockEpisodeCanon / btnUnlockEpisodeCanon to change
        // canon lock state â€” those buttons enforce the full semantics (entry stamping,
        // confirmation dialogs). This prevents inconsistent episode state.

        txtEpisodeNotes.TextChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var ep = Ep(); if (ep == null) return;
            ep.Notes = txtEpisodeNotes.Text;
            _appState.MarkDirty();
        };

        // â”€â”€ Series fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        txtSeriesName.TextChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var s = Series(); if (s == null) return;
            s.Name = txtSeriesName.Text;
            // Refresh lstSeries so the updated name appears in the list.
            _bsSeries.ResetCurrentItem();
            // Rebuild cboEpisodeSeries so the updated name appears in the dropdown,
            // then restore the current selection without triggering the write-back.
            if (_lookup != null)
            {
                var currentSeriesId = GetSelectedLookupId(cboEpisodeSeries);
                _loadingEpisodeMeta = true;
                try
                {
                    SetLookupDataSource(cboEpisodeSeries, _lookup.SeriesAsLookup());
                    SetLookupCombo(cboEpisodeSeries, currentSeriesId);
                }
                finally { _loadingEpisodeMeta = false; }
            }
            _appState.MarkDirty();
        };

        cboSeriesBroadcastStation.SelectedIndexChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var s = Series(); if (s == null) return;
            s.BroadcastStationId = GetSelectedLookupId(cboSeriesBroadcastStation);
            _appState.MarkDirty();
        };

        txtSeriesNotes.TextChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var s = Series(); if (s == null) return;
            s.Notes = txtSeriesNotes.Text;
            _appState.MarkDirty();
        };
    }

    // â”€â”€ Export handlers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnExportEpisodeText_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        string text        = _exportService.ExportEpisodeAsBroadcastText(_appState.CurrentProject, ep);
        string defaultName = SanitizeFilename(ep.Name) + "_broadcast.txt";

        if (SaveExportToFile(text, defaultName, "Text Files|*.txt|All Files|*.*"))
            SetStatus($"Broadcast script exported: {defaultName}");

        // Preview the export in the Output Preview tab
        txtRenderedOutput.Text = text;
        tabMain.SelectedTab    = tabOutputPreview;
    }

    private void btnExportEpisodeTts_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        var options = new TtsExportOptions
        {
            IncludeEpisodeHeader           = chkExportIncludeHeader.Checked,
            BlankLineBetweenEntries        = chkExportBlankLineBetweenEntries.Checked,
            StripVisualSeparators          = true,   // always strip for TTS
            OneEntryPerParagraph           = true,   // always join for TTS
            IncludeEntryMarkers            = chkExportIncludeEntryMarkers.Checked
        };

        string text        = _exportService.ExportEpisodeAsTtsText(_appState.CurrentProject, ep, options);
        string defaultName = SanitizeFilename(ep.Name) + "_tts.txt";

        if (SaveExportToFile(text, defaultName, "Text Files|*.txt|All Files|*.*"))
            SetStatus($"TTS script exported: {defaultName}");

        txtRenderedOutput.Text = text;
        tabMain.SelectedTab    = tabOutputPreview;
    }

    private void btnExportEpisodeJson_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        bool debugMode = chkExportAuthorDebugMode.Checked;
        var options = new JsonExportOptions
        {
            IncludeHiddenTruth        = debugMode,
            IncludeRenderedText       = true,
            IncludeGenerationMetadata = debugMode
        };

        string json        = _exportService.ExportEpisodeAsJson(_appState.CurrentProject, ep, options);
        string suffix      = debugMode ? "_debug.json" : "_export.json";
        string defaultName = SanitizeFilename(ep.Name) + suffix;

        if (SaveExportToFile(json, defaultName, "JSON Files|*.json|All Files|*.*"))
            SetStatus($"JSON exported: {defaultName}{(debugMode ? " [debug mode â€” contains hidden truth]" : string.Empty)}");

        txtRenderedOutput.Text = json;
        tabMain.SelectedTab    = tabOutputPreview;
    }

    /// <summary>
    /// Opens a SaveFileDialog, writes content as UTF-8, and returns true on success.
    /// </summary>
    private bool SaveExportToFile(string content, string defaultFilename, string filter)
    {
        using var dlg = new SaveFileDialog
        {
            Filter   = filter,
            Title    = "Export",
            FileName = defaultFilename
        };
        if (dlg.ShowDialog() != DialogResult.OK) return false;
        File.WriteAllText(dlg.FileName, content, System.Text.Encoding.UTF8);
        return true;
    }

    /// <summary>
    /// Replaces invalid filename characters and caps length at 60 characters.
    /// </summary>
    private static string SanitizeFilename(string name)
    {
        foreach (char c in Path.GetInvalidFileNameChars())
            name = name.Replace(c, '_');
        return name.Length > 60 ? name[..60] : name;
    }

    // â”€â”€ Entry preview â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Builds a structured editor inspection summary for the selected entry.
    /// This is not rendered script output â€” it is a human-readable audit of all set fields.
    /// Omits fields that are null/empty/default to keep it concise.
    /// </summary>
    private void UpdateEntryPreview(EpisodeEntryRecord? entry)
    {
        if (entry == null || _lookup == null) { txtEpisodeEntryPreview.Clear(); return; }

        var sb = new System.Text.StringBuilder();

        // â”€â”€ Header line â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        string lockFlag   = entry.IsLocked ? " [LOCKED]" : string.Empty;
        string canonFlag  = entry.IsCanon  ? " [CANON]"  : string.Empty;
        sb.AppendLine($"#{entry.SortOrder}  {entry.EntryKind} / {entry.SourceType}{lockFlag}{canonFlag}");
        if (!string.IsNullOrEmpty(entry.Name))
            sb.AppendLine($"Name:         {entry.Name}");

        // â”€â”€ Operation / Notice â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.EntryKind == EntryKind.Traffic)
        {
            if (entry.OperationTypeId != null)
                sb.AppendLine($"Operation:    {_lookup.OperationTypeName(entry.OperationTypeId)}");
        }
        else
        {
            if (entry.NoticeTypeId != null)
                sb.AppendLine($"Notice Type:  {_lookup.NoticeTypeName(entry.NoticeTypeId)}");
        }

        // â”€â”€ Location â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.StationId != null)
            sb.AppendLine($"Station:      {_lookup.StationName(entry.StationId)}");
        if (entry.DockId != null)
            sb.AppendLine($"Dock:         {_lookup.DockName(entry.DockId)}");

        // â”€â”€ Vessel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.VesselId != null)
            sb.AppendLine($"Vessel:       {_lookup.VesselName(entry.VesselId)}");
        if (entry.VesselClassOverrideId != null)
            sb.AppendLine($"Class (ovrd): {_lookup.VesselClassName(entry.VesselClassOverrideId)}");
        if (!string.IsNullOrEmpty(entry.RegistryOverride))
            sb.AppendLine($"Registry:     {entry.RegistryOverride} [override]");

        // â”€â”€ Route â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.OriginStationId != null || entry.DestinationStationId != null)
            sb.AppendLine($"Route:        {_lookup.StationName(entry.OriginStationId)} â†’ {_lookup.StationName(entry.DestinationStationId)}");

        // â”€â”€ Purpose â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.DeclaredPurposeId != null)
            sb.AppendLine($"Declared Pur: {_lookup.PurposeName(entry.DeclaredPurposeId)}");

        bool purposeMismatch = entry.ActualPurposeId != null
                               && entry.ActualPurposeId != entry.DeclaredPurposeId;
        if (purposeMismatch)
            sb.AppendLine($"Actual Pur:   {_lookup.PurposeName(entry.ActualPurposeId)} [differs]");
        else if (entry.ActualPurposeId != null && entry.DeclaredPurposeId == null)
            sb.AppendLine($"Actual Pur:   {_lookup.PurposeName(entry.ActualPurposeId)}");

        // â”€â”€ Statuses â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.ManifestStatusId != null)
            sb.AppendLine($"Manifest:     {_lookup.ManifestStatusName(entry.ManifestStatusId)}");
        if (entry.InspectionStatusId != null)
            sb.AppendLine($"Inspection:   {_lookup.InspectionStatusName(entry.InspectionStatusId)}");
        if (entry.ClearanceStatusId != null)
            sb.AppendLine($"Clearance:    {_lookup.ClearanceStatusName(entry.ClearanceStatusId)}");
        if (entry.EnvironmentalConditionId != null)
            sb.AppendLine($"Environment:  {_lookup.EnvironmentalConditionName(entry.EnvironmentalConditionId)}");

        // â”€â”€ Narrative â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.DirectiveId != null)
            sb.AppendLine($"Directive:    {_lookup.DirectiveName(entry.DirectiveId)}");
        if (entry.IncidentPhraseTemplateId != null)
            sb.AppendLine($"Incident:     {_lookup.PhraseTemplateName(entry.IncidentPhraseTemplateId)}");
        if (entry.ResolutionPhraseTemplateId != null)
            sb.AppendLine($"Resolution:   {_lookup.PhraseTemplateName(entry.ResolutionPhraseTemplateId)}");
        if (entry.RouteStatusPhraseTemplateId != null)
            sb.AppendLine($"Route Status: {_lookup.PhraseTemplateName(entry.RouteStatusPhraseTemplateId)}");

        // â”€â”€ Story thread â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.StoryThreadId != null)
            sb.AppendLine($"Thread:       {_lookup.StoryThreadName(entry.StoryThreadId)}");
        if (entry.AppliedStoryBeatId != null)
            sb.AppendLine($"Beat:         {_lookup.StoryBeatLabel(entry.AppliedStoryBeatId)}");
        if (entry.AnomalySeverity.HasValue)
            sb.AppendLine($"Anomaly:      {entry.AnomalySeverity}");

        // â”€â”€ Cargo / Passengers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.DeclaredCargo.Count > 0 || entry.ActualCargo.Count > 0)
        {
            sb.AppendLine($"Cargo:        {entry.DeclaredCargo.Count} declared" +
                (entry.ActualCargo.Count != entry.DeclaredCargo.Count
                    ? $" / {entry.ActualCargo.Count} actual [differs]"
                    : string.Empty));
        }

        if (entry.DeclaredPassengers.Count > 0 || entry.ActualPassengers.Count > 0)
        {
            sb.AppendLine($"Passengers:   {entry.DeclaredPassengers.Count} declared" +
                (entry.ActualPassengers.Count != entry.DeclaredPassengers.Count
                    ? $" / {entry.ActualPassengers.Count} actual [differs]"
                    : string.Empty));
        }

        // â”€â”€ Hidden truth indicator â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (!string.IsNullOrWhiteSpace(entry.HiddenTruthNotes))
            sb.AppendLine("Hidden Truth: [notes present]");

        // â”€â”€ Schedule â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (entry.ScheduledUtc.HasValue)
            sb.AppendLine($"Scheduled:    {entry.ScheduledUtc.Value:yyyy-MM-dd HH:mm} UTC");

        // â”€â”€ Notes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        if (!string.IsNullOrEmpty(entry.Notes))
            sb.AppendLine($"Notes:        {entry.Notes}");

        txtEpisodeEntryPreview.Text = sb.ToString().TrimEnd();
    }
}

```n---


### File: PodcastUniverseEditor\Utilities\IdHelper.cs
```csharp

namespace PodcastUniverseEditor.Utilities;

/// <summary>
/// Centralises new-record ID generation. NewId() returns a lowercase GUID string.
/// Seeded records in ProjectSeedFactory use short, readable fixed IDs instead.
/// Keeping generation here makes it easy to change the format for new records later.
/// </summary>
public static class IdHelper
{
    public static string NewId() => Guid.NewGuid().ToString("D").ToLowerInvariant();
}

```n---


## Project Stats
- Folders requested: PodcastUniverseEditor
- Total .cs files processed: 74
- Excluded: *.Designer.cs files
- Date generated: 2026-03-29 17:26

