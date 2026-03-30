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

File-local usings are removed.



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
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


[assembly: System.Reflection.AssemblyCompanyAttribute("PodcastUniverseEditor")]
[assembly: System.Reflection.AssemblyConfigurationAttribute("Debug")]
[assembly: System.Reflection.AssemblyFileVersionAttribute("1.0.0.0")]
[assembly: System.Reflection.AssemblyInformationalVersionAttribute("1.0.0+d0fc10393ea9b0bacb9b4367517422e3842ed9f0")]
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


### File: PodcastUniverseEditor\UI\Controls\ucCommodities.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

partial class ucCommodities
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
        // â”€â”€ Declare all controls (all new() calls first â€” WinForms Designer convention) â”€â”€â”€â”€â”€â”€
        gridCommodities = new DataGridView();

        // â”€â”€ Begin init / suspend â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)gridCommodities).BeginInit();
        SuspendLayout();

        // â”€â”€ gridCommodities â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridCommodities.AllowUserToAddRows          = false;
        gridCommodities.AutoGenerateColumns         = true;
        gridCommodities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridCommodities.Dock                        = DockStyle.Fill;
        gridCommodities.Location                    = new Point(0, 0);
        gridCommodities.MultiSelect                 = false;
        gridCommodities.Name                        = "gridCommodities";
        gridCommodities.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridCommodities.Size                        = new Size(858, 600);
        gridCommodities.TabIndex                    = 0;

        // â”€â”€ ucCommodities â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(gridCommodities);
        Name = "ucCommodities";
        Size = new Size(858, 600);

        // â”€â”€ End init / resume â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)gridCommodities).EndInit();
        ResumeLayout(false);
    }

    private DataGridView gridCommodities = null!;
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

    // â”€â”€ Buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public Button BtnOrganisationsAdd    => btnOrganisationsAdd;
    public Button BtnOrganisationsDelete => btnOrganisationsDelete;
    public Button BtnDirectivesAdd       => btnDirectivesAdd;
    public Button BtnDirectivesDelete    => btnDirectivesDelete;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucOrganisationsDirectives.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

partial class ucOrganisationsDirectives
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
        // â”€â”€ Declare all controls (all new() calls first â€” WinForms Designer convention) â”€â”€â”€â”€â”€â”€
        split                    = new SplitContainer();
        pnlOrgs                  = new Panel();
        lblOrganisations         = new Label();
        pnlOrgsButtons           = new Panel();
        btnOrganisationsAdd      = new Button();
        btnOrganisationsDelete   = new Button();
        gridOrganisations        = new DataGridView();
        pnlDirectives            = new Panel();
        lblDirectives            = new Label();
        pnlDirectivesButtons     = new Panel();
        btnDirectivesAdd         = new Button();
        btnDirectivesDelete      = new Button();
        gridDirectives           = new DataGridView();

        // â”€â”€ Begin init / suspend â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlOrgs.SuspendLayout();
        pnlOrgsButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridOrganisations).BeginInit();
        pnlDirectives.SuspendLayout();
        pnlDirectivesButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDirectives).BeginInit();
        SuspendLayout();

        // â”€â”€ split â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        split.Dock        = DockStyle.Fill;
        split.Location    = new Point(0, 0);
        split.Name        = "split";
        split.Orientation = Orientation.Horizontal;
        split.Size        = new Size(858, 600);
        split.TabIndex    = 0;

        // â”€â”€ pnlOrgs â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // Controls added Fill-first so Top items stack at the top
        pnlOrgs.Controls.Add(gridOrganisations);
        pnlOrgs.Controls.Add(pnlOrgsButtons);
        pnlOrgs.Controls.Add(lblOrganisations);
        pnlOrgs.Dock     = DockStyle.Fill;
        pnlOrgs.Location = new Point(0, 0);
        pnlOrgs.Name     = "pnlOrgs";
        pnlOrgs.Size     = new Size(858, 297);
        pnlOrgs.TabIndex = 0;

        // â”€â”€ lblOrganisations â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lblOrganisations.Dock     = DockStyle.Top;
        lblOrganisations.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblOrganisations.Height   = 20;
        lblOrganisations.Location = new Point(0, 0);
        lblOrganisations.Name     = "lblOrganisations";
        lblOrganisations.Size     = new Size(858, 20);
        lblOrganisations.TabIndex = 0;
        lblOrganisations.Text     = "Organisations";

        // â”€â”€ pnlOrgsButtons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        pnlOrgsButtons.Controls.Add(btnOrganisationsDelete);
        pnlOrgsButtons.Controls.Add(btnOrganisationsAdd);
        pnlOrgsButtons.Dock     = DockStyle.Bottom;
        pnlOrgsButtons.Location = new Point(0, 20);
        pnlOrgsButtons.Name     = "pnlOrgsButtons";
        pnlOrgsButtons.Padding  = new Padding(2);
        pnlOrgsButtons.Size     = new Size(858, 32);
        pnlOrgsButtons.TabIndex = 1;

        // â”€â”€ btnOrganisationsAdd â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnOrganisationsAdd.Dock                  = DockStyle.Left;
        btnOrganisationsAdd.Location              = new Point(2, 2);
        btnOrganisationsAdd.Name                  = "btnOrganisationsAdd";
        btnOrganisationsAdd.Size                  = new Size(80, 28);
        btnOrganisationsAdd.TabIndex              = 1;
        btnOrganisationsAdd.Text                  = "Add";
        btnOrganisationsAdd.UseVisualStyleBackColor = true;

        // â”€â”€ btnOrganisationsDelete â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnOrganisationsDelete.Dock                  = DockStyle.Left;
        btnOrganisationsDelete.Location              = new Point(82, 2);
        btnOrganisationsDelete.Name                  = "btnOrganisationsDelete";
        btnOrganisationsDelete.Size                  = new Size(80, 28);
        btnOrganisationsDelete.TabIndex              = 0;
        btnOrganisationsDelete.Text                  = "Delete";
        btnOrganisationsDelete.UseVisualStyleBackColor = true;

        // â”€â”€ gridOrganisations â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridOrganisations.AllowUserToAddRows          = false;
        gridOrganisations.AutoGenerateColumns         = true;
        gridOrganisations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridOrganisations.Dock                        = DockStyle.Fill;
        gridOrganisations.Location                    = new Point(0, 52);
        gridOrganisations.MultiSelect                 = false;
        gridOrganisations.Name                        = "gridOrganisations";
        gridOrganisations.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridOrganisations.Size                        = new Size(858, 245);
        gridOrganisations.TabIndex                    = 2;

        // â”€â”€ pnlDirectives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // Controls added Fill-first so Top items stack at the top
        pnlDirectives.Controls.Add(gridDirectives);
        pnlDirectives.Controls.Add(pnlDirectivesButtons);
        pnlDirectives.Controls.Add(lblDirectives);
        pnlDirectives.Dock     = DockStyle.Fill;
        pnlDirectives.Location = new Point(0, 0);
        pnlDirectives.Name     = "pnlDirectives";
        pnlDirectives.Size     = new Size(858, 297);
        pnlDirectives.TabIndex = 0;

        // â”€â”€ lblDirectives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lblDirectives.Dock     = DockStyle.Top;
        lblDirectives.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblDirectives.Height   = 20;
        lblDirectives.Location = new Point(0, 0);
        lblDirectives.Name     = "lblDirectives";
        lblDirectives.Size     = new Size(858, 20);
        lblDirectives.TabIndex = 0;
        lblDirectives.Text     = "Directives";

        // â”€â”€ pnlDirectivesButtons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        pnlDirectivesButtons.Controls.Add(btnDirectivesDelete);
        pnlDirectivesButtons.Controls.Add(btnDirectivesAdd);
        pnlDirectivesButtons.Dock     = DockStyle.Bottom;
        pnlDirectivesButtons.Location = new Point(0, 20);
        pnlDirectivesButtons.Name     = "pnlDirectivesButtons";
        pnlDirectivesButtons.Padding  = new Padding(2);
        pnlDirectivesButtons.Size     = new Size(858, 32);
        pnlDirectivesButtons.TabIndex = 1;

        // â”€â”€ btnDirectivesAdd â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnDirectivesAdd.Dock                  = DockStyle.Left;
        btnDirectivesAdd.Location              = new Point(2, 2);
        btnDirectivesAdd.Name                  = "btnDirectivesAdd";
        btnDirectivesAdd.Size                  = new Size(80, 28);
        btnDirectivesAdd.TabIndex              = 1;
        btnDirectivesAdd.Text                  = "Add";
        btnDirectivesAdd.UseVisualStyleBackColor = true;

        // â”€â”€ btnDirectivesDelete â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnDirectivesDelete.Dock                  = DockStyle.Left;
        btnDirectivesDelete.Location              = new Point(82, 2);
        btnDirectivesDelete.Name                  = "btnDirectivesDelete";
        btnDirectivesDelete.Size                  = new Size(80, 28);
        btnDirectivesDelete.TabIndex              = 0;
        btnDirectivesDelete.Text                  = "Delete";
        btnDirectivesDelete.UseVisualStyleBackColor = true;

        // â”€â”€ gridDirectives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridDirectives.AllowUserToAddRows          = false;
        gridDirectives.AutoGenerateColumns         = true;
        gridDirectives.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridDirectives.Dock                        = DockStyle.Fill;
        gridDirectives.Location                    = new Point(0, 52);
        gridDirectives.MultiSelect                 = false;
        gridDirectives.Name                        = "gridDirectives";
        gridDirectives.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridDirectives.Size                        = new Size(858, 245);
        gridDirectives.TabIndex                    = 2;

        // â”€â”€ split.Panel1 â€” Organisations â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        split.Panel1.Controls.Add(pnlOrgs);

        // â”€â”€ split.Panel2 â€” Directives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        split.Panel2.Controls.Add(pnlDirectives);

        // â”€â”€ ucOrganisationsDirectives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(split);
        Name = "ucOrganisationsDirectives";
        Size = new Size(858, 600);

        // â”€â”€ End init / resume â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        split.ResumeLayout(false);
        pnlOrgs.ResumeLayout(false);
        pnlOrgsButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridOrganisations).EndInit();
        pnlDirectives.ResumeLayout(false);
        pnlDirectivesButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDirectives).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split                  = null!;
    private Panel           pnlOrgs                = null!;
    private Label           lblOrganisations        = null!;
    private Panel           pnlOrgsButtons          = null!;
    private Button          btnOrganisationsAdd     = null!;
    private Button          btnOrganisationsDelete  = null!;
    private DataGridView    gridOrganisations       = null!;
    private Panel           pnlDirectives           = null!;
    private Label           lblDirectives           = null!;
    private Panel           pnlDirectivesButtons    = null!;
    private Button          btnDirectivesAdd        = null!;
    private Button          btnDirectivesDelete     = null!;
    private DataGridView    gridDirectives          = null!;
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


### File: PodcastUniverseEditor\UI\Controls\ucOutputPreview.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

partial class ucOutputPreview
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
        // â”€â”€ Declare all controls (all new() calls first â€” WinForms Designer convention) â”€â”€â”€â”€â”€â”€
        txtRenderedOutput = new TextBox();

        // â”€â”€ Begin init / suspend â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        SuspendLayout();

        // â”€â”€ txtRenderedOutput â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        txtRenderedOutput.Dock        = DockStyle.Fill;
        txtRenderedOutput.Font        = new Font("Consolas", 10f);
        txtRenderedOutput.Location    = new Point(0, 0);
        txtRenderedOutput.Multiline   = true;
        txtRenderedOutput.Name        = "txtRenderedOutput";
        txtRenderedOutput.ReadOnly    = true;
        txtRenderedOutput.ScrollBars  = ScrollBars.Vertical;
        txtRenderedOutput.Size        = new Size(858, 600);
        txtRenderedOutput.TabIndex    = 0;

        // â”€â”€ ucOutputPreview â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(txtRenderedOutput);
        Name = "ucOutputPreview";
        Size = new Size(858, 600);

        // â”€â”€ End init / resume â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ResumeLayout(false);
        PerformLayout();
    }

    private TextBox txtRenderedOutput = null!;
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


### File: PodcastUniverseEditor\UI\Controls\ucOverview.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

partial class ucOverview
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
        SuspendLayout();
        AutoScaleMode = AutoScaleMode.Font;
        Name          = "ucOverview";
        ResumeLayout(false);
    }
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


### File: PodcastUniverseEditor\UI\Controls\ucReferenceData.Designer.cs
```csharp

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


### File: PodcastUniverseEditor\UI\Controls\ucRoutes.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

partial class ucRoutes
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
        // â”€â”€ Declare all controls (all new() calls first â€” WinForms Designer convention) â”€â”€â”€â”€â”€â”€
        gridRoutes = new DataGridView();

        // â”€â”€ Begin init / suspend â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)gridRoutes).BeginInit();
        SuspendLayout();

        // â”€â”€ gridRoutes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridRoutes.AllowUserToAddRows          = false;
        gridRoutes.AutoGenerateColumns         = true;
        gridRoutes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridRoutes.Dock                        = DockStyle.Fill;
        gridRoutes.Location                    = new Point(0, 0);
        gridRoutes.MultiSelect                 = false;
        gridRoutes.Name                        = "gridRoutes";
        gridRoutes.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridRoutes.Size                        = new Size(858, 600);
        gridRoutes.TabIndex                    = 0;

        // â”€â”€ ucRoutes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(gridRoutes);
        Name = "ucRoutes";
        Size = new Size(858, 600);

        // â”€â”€ End init / resume â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)gridRoutes).EndInit();
        ResumeLayout(false);
    }

    private DataGridView gridRoutes = null!;
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


### File: PodcastUniverseEditor\UI\Controls\ucStationsDocks.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

partial class ucStationsDocks
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
        // â”€â”€ Declare all controls (all new() calls first â€” WinForms Designer convention) â”€â”€â”€â”€â”€â”€
        split              = new SplitContainer();
        lblStations        = new Label();
        pnlStationsButtons = new Panel();
        btnStationsAdd     = new Button();
        btnStationsDelete  = new Button();
        gridStations       = new DataGridView();
        lblDocks           = new Label();
        pnlDocksButtons    = new Panel();
        btnDocksAdd        = new Button();
        btnDocksDelete     = new Button();
        gridDocks          = new DataGridView();

        // â”€â”€ Begin init / suspend â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlStationsButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridStations).BeginInit();
        pnlDocksButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDocks).BeginInit();
        SuspendLayout();

        // â”€â”€ split â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        split.Dock             = DockStyle.Fill;
        split.Location         = new Point(0, 0);
        split.Name             = "split";
        split.Orientation      = Orientation.Horizontal;
        split.Size             = new Size(858, 809);
        split.SplitterDistance = 354;
        split.TabIndex         = 0;

        // â”€â”€ lblStations â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lblStations.Dock     = DockStyle.Top;
        lblStations.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblStations.Location = new Point(0, 0);
        lblStations.Name     = "lblStations";
        lblStations.Size     = new Size(858, 20);
        lblStations.TabIndex = 0;
        lblStations.Text     = "Stations";

        // â”€â”€ pnlStationsButtons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        pnlStationsButtons.Controls.Add(btnStationsDelete);
        pnlStationsButtons.Controls.Add(btnStationsAdd);
        pnlStationsButtons.Dock     = DockStyle.Top;
        pnlStationsButtons.Location = new Point(0, 20);
        pnlStationsButtons.Name     = "pnlStationsButtons";
        pnlStationsButtons.Padding  = new Padding(2);
        pnlStationsButtons.Size     = new Size(858, 32);
        pnlStationsButtons.TabIndex = 1;

        // â”€â”€ btnStationsAdd â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnStationsAdd.Dock                  = DockStyle.Left;
        btnStationsAdd.Location              = new Point(2, 2);
        btnStationsAdd.Name                  = "btnStationsAdd";
        btnStationsAdd.Size                  = new Size(80, 28);
        btnStationsAdd.TabIndex              = 1;
        btnStationsAdd.Text                  = "Add";
        btnStationsAdd.UseVisualStyleBackColor = true;

        // â”€â”€ btnStationsDelete â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnStationsDelete.Dock                  = DockStyle.Left;
        btnStationsDelete.Location              = new Point(82, 2);
        btnStationsDelete.Name                  = "btnStationsDelete";
        btnStationsDelete.Size                  = new Size(80, 28);
        btnStationsDelete.TabIndex              = 0;
        btnStationsDelete.Text                  = "Delete";
        btnStationsDelete.UseVisualStyleBackColor = true;

        // â”€â”€ gridStations â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridStations.AllowUserToAddRows          = false;
        gridStations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridStations.Dock                        = DockStyle.Fill;
        gridStations.Location                    = new Point(0, 52);
        gridStations.MultiSelect                 = false;
        gridStations.Name                        = "gridStations";
        gridStations.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridStations.Size                        = new Size(858, 302);
        gridStations.TabIndex                    = 2;

        // â”€â”€ lblDocks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lblDocks.Dock     = DockStyle.Top;
        lblDocks.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblDocks.Location = new Point(0, 0);
        lblDocks.Name     = "lblDocks";
        lblDocks.Size     = new Size(858, 20);
        lblDocks.TabIndex = 0;
        lblDocks.Text     = "Docks";

        // â”€â”€ pnlDocksButtons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        pnlDocksButtons.Controls.Add(btnDocksDelete);
        pnlDocksButtons.Controls.Add(btnDocksAdd);
        pnlDocksButtons.Dock     = DockStyle.Top;
        pnlDocksButtons.Location = new Point(0, 20);
        pnlDocksButtons.Name     = "pnlDocksButtons";
        pnlDocksButtons.Padding  = new Padding(2);
        pnlDocksButtons.Size     = new Size(858, 32);
        pnlDocksButtons.TabIndex = 1;

        // â”€â”€ btnDocksAdd â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnDocksAdd.Dock                  = DockStyle.Left;
        btnDocksAdd.Location              = new Point(2, 2);
        btnDocksAdd.Name                  = "btnDocksAdd";
        btnDocksAdd.Size                  = new Size(80, 28);
        btnDocksAdd.TabIndex              = 1;
        btnDocksAdd.Text                  = "Add";
        btnDocksAdd.UseVisualStyleBackColor = true;

        // â”€â”€ btnDocksDelete â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnDocksDelete.Dock                  = DockStyle.Left;
        btnDocksDelete.Location              = new Point(82, 2);
        btnDocksDelete.Name                  = "btnDocksDelete";
        btnDocksDelete.Size                  = new Size(80, 28);
        btnDocksDelete.TabIndex              = 0;
        btnDocksDelete.Text                  = "Delete";
        btnDocksDelete.UseVisualStyleBackColor = true;

        // â”€â”€ gridDocks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridDocks.AllowUserToAddRows          = false;
        gridDocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridDocks.Dock                        = DockStyle.Fill;
        gridDocks.Location                    = new Point(0, 52);
        gridDocks.MultiSelect                 = false;
        gridDocks.Name                        = "gridDocks";
        gridDocks.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridDocks.Size                        = new Size(858, 399);
        gridDocks.TabIndex                    = 2;

        // â”€â”€ split.Panel1 â€” Stations â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // DockStyle.Top: last Controls.Add = topmost â†’ lblStations last
        split.Panel1.Controls.Add(gridStations);
        split.Panel1.Controls.Add(pnlStationsButtons);
        split.Panel1.Controls.Add(lblStations);

        // â”€â”€ split.Panel2 â€” Docks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // Same stacking rule: lblDocks last = topmost
        split.Panel2.Controls.Add(gridDocks);
        split.Panel2.Controls.Add(pnlDocksButtons);
        split.Panel2.Controls.Add(lblDocks);

        // â”€â”€ ucStationsDocks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(split);
        Name = "ucStationsDocks";
        Size = new Size(858, 809);

        // â”€â”€ End init / resume â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        split.ResumeLayout(false);
        pnlStationsButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridStations).EndInit();
        pnlDocksButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDocks).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split              = null!;
    private Label           lblStations        = null!;
    private Panel           pnlStationsButtons = null!;
    private Button          btnStationsAdd     = null!;
    private Button          btnStationsDelete  = null!;
    private DataGridView    gridStations       = null!;
    private Label           lblDocks           = null!;
    private Panel           pnlDocksButtons    = null!;
    private Button          btnDocksAdd        = null!;
    private Button          btnDocksDelete     = null!;
    private DataGridView    gridDocks          = null!;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucSystemsBodies.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

/// <summary>
/// UserControl for the Systems & Bodies tab.
/// Hosts a horizontal SplitContainer: Star Systems grid + buttons (top),
/// Celestial Bodies grid + buttons (bottom).
/// Public properties expose the grids and buttons so MainForm can bind data
/// and hook events without this control needing any project or service references.
/// </summary>
public partial class ucSystemsBodies : UserControl
{
    public ucSystemsBodies()
    {
        InitializeComponent();
    }

    // â”€â”€ Grids â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public DataGridView GridStarSystems => gridStarSystems;
    public DataGridView GridCelestialBodies => gridCelestialBodies;

    // â”€â”€ Buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    public Button BtnSystemAdd => btnSystemAdd;
    public Button BtnSystemDelete => btnSystemDelete;
    public Button BtnBodyAdd => btnBodyAdd;
    public Button BtnBodyDelete => btnBodyDelete;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\ucSystemsBodies.Designer.cs
```csharp

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


### File: PodcastUniverseEditor\UI\Controls\ucThreads.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

partial class ucThreads
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
        // â”€â”€ Declare all controls (all new() calls first â€” WinForms Designer convention) â”€â”€â”€â”€â”€â”€
        split          = new SplitContainer();
        pnlThreads     = new Panel();
        lblThreads     = new Label();
        gridThreads    = new DataGridView();
        pnlBeats       = new Panel();
        lblBeats       = new Label();
        gridThreadBeats = new DataGridView();

        // â”€â”€ Begin init / suspend â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        pnlThreads.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridThreads).BeginInit();
        pnlBeats.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridThreadBeats).BeginInit();
        SuspendLayout();

        // â”€â”€ split â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        split.Dock        = DockStyle.Fill;
        split.Location    = new Point(0, 0);
        split.Name        = "split";
        split.Orientation = Orientation.Horizontal;
        split.Size        = new Size(858, 600);
        split.TabIndex    = 0;

        // â”€â”€ pnlThreads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // Add Fill first, then Top â€” last added (Top) is processed first and appears at top
        pnlThreads.Controls.Add(gridThreads);
        pnlThreads.Controls.Add(lblThreads);
        pnlThreads.Dock     = DockStyle.Fill;
        pnlThreads.Location = new Point(0, 0);
        pnlThreads.Name     = "pnlThreads";
        pnlThreads.Size     = new Size(858, 297);
        pnlThreads.TabIndex = 0;

        // â”€â”€ lblThreads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lblThreads.Dock     = DockStyle.Top;
        lblThreads.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblThreads.Height   = 20;
        lblThreads.Location = new Point(0, 0);
        lblThreads.Name     = "lblThreads";
        lblThreads.Size     = new Size(858, 20);
        lblThreads.TabIndex = 0;
        lblThreads.Text     = "Story Threads";

        // â”€â”€ gridThreads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridThreads.AllowUserToAddRows          = false;
        gridThreads.AutoGenerateColumns         = true;
        gridThreads.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridThreads.Dock                        = DockStyle.Fill;
        gridThreads.Location                    = new Point(0, 20);
        gridThreads.MultiSelect                 = false;
        gridThreads.Name                        = "gridThreads";
        gridThreads.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridThreads.Size                        = new Size(858, 277);
        gridThreads.TabIndex                    = 1;

        // â”€â”€ pnlBeats â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // Same stacking rule: grid first (Fill), label last (Top) â†’ label appears at top
        pnlBeats.Controls.Add(gridThreadBeats);
        pnlBeats.Controls.Add(lblBeats);
        pnlBeats.Dock     = DockStyle.Fill;
        pnlBeats.Location = new Point(0, 0);
        pnlBeats.Name     = "pnlBeats";
        pnlBeats.Size     = new Size(858, 297);
        pnlBeats.TabIndex = 0;

        // â”€â”€ lblBeats â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lblBeats.Dock     = DockStyle.Top;
        lblBeats.Font     = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        lblBeats.Height   = 20;
        lblBeats.Location = new Point(0, 0);
        lblBeats.Name     = "lblBeats";
        lblBeats.Size     = new Size(858, 20);
        lblBeats.TabIndex = 0;
        lblBeats.Text     = "Beats";

        // â”€â”€ gridThreadBeats â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridThreadBeats.AllowUserToAddRows          = false;
        gridThreadBeats.AutoGenerateColumns         = true;
        gridThreadBeats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridThreadBeats.Dock                        = DockStyle.Fill;
        gridThreadBeats.Location                    = new Point(0, 20);
        gridThreadBeats.MultiSelect                 = false;
        gridThreadBeats.Name                        = "gridThreadBeats";
        gridThreadBeats.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridThreadBeats.Size                        = new Size(858, 277);
        gridThreadBeats.TabIndex                    = 1;

        // â”€â”€ split.Panel1 â€” Story Threads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        split.Panel1.Controls.Add(pnlThreads);

        // â”€â”€ split.Panel2 â€” Beats â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        split.Panel2.Controls.Add(pnlBeats);

        // â”€â”€ ucThreads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(split);
        Name = "ucThreads";
        Size = new Size(858, 600);

        // â”€â”€ End init / resume â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        split.ResumeLayout(false);
        pnlThreads.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridThreads).EndInit();
        pnlBeats.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridThreadBeats).EndInit();
        ResumeLayout(false);
    }

    private SplitContainer  split           = null!;
    private Panel           pnlThreads      = null!;
    private Label           lblThreads      = null!;
    private DataGridView    gridThreads     = null!;
    private Panel           pnlBeats        = null!;
    private Label           lblBeats        = null!;
    private DataGridView    gridThreadBeats = null!;
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


### File: PodcastUniverseEditor\UI\Controls\ucValidation.Designer.cs
```csharp

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
        // â”€â”€ Declare all controls (all new() calls first â€” WinForms Designer convention) â”€â”€â”€â”€â”€â”€
        pnlContent             = new Panel();
        pnlTopBar              = new Panel();
        btnRunValidation       = new Button();
        gridValidationMessages = new DataGridView();
        colValSeverity         = new DataGridViewTextBoxColumn();
        colValMessage          = new DataGridViewTextBoxColumn();
        colValEntityType       = new DataGridViewTextBoxColumn();
        colValEntityId         = new DataGridViewTextBoxColumn();
        colValFieldName        = new DataGridViewTextBoxColumn();

        // â”€â”€ Begin init / suspend â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        pnlContent.SuspendLayout();
        pnlTopBar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridValidationMessages).BeginInit();
        SuspendLayout();

        // â”€â”€ pnlContent â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // Add Fill first, then Top â€” last added (Top) is processed first and appears at top
        pnlContent.Controls.Add(gridValidationMessages);
        pnlContent.Controls.Add(pnlTopBar);
        pnlContent.Dock     = DockStyle.Fill;
        pnlContent.Location = new Point(0, 0);
        pnlContent.Name     = "pnlContent";
        pnlContent.Size     = new Size(858, 600);
        pnlContent.TabIndex = 0;

        // â”€â”€ pnlTopBar â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        pnlTopBar.Controls.Add(btnRunValidation);
        pnlTopBar.Dock     = DockStyle.Top;
        pnlTopBar.Height   = 36;
        pnlTopBar.Location = new Point(0, 0);
        pnlTopBar.Name     = "pnlTopBar";
        pnlTopBar.Padding  = new Padding(4);
        pnlTopBar.Size     = new Size(858, 36);
        pnlTopBar.TabIndex = 0;

        // â”€â”€ btnRunValidation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        btnRunValidation.AutoSize                  = true;
        btnRunValidation.Dock                      = DockStyle.Left;
        btnRunValidation.Location                  = new Point(4, 4);
        btnRunValidation.Name                      = "btnRunValidation";
        btnRunValidation.Size                      = new Size(119, 28);
        btnRunValidation.TabIndex                  = 0;
        btnRunValidation.Text                      = "Run Validation";
        btnRunValidation.UseVisualStyleBackColor   = true;

        // â”€â”€ gridValidationMessages â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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

        // â”€â”€ colValSeverity â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        colValSeverity.DataPropertyName = "Severity";
        colValSeverity.HeaderText       = "Severity";
        colValSeverity.Name             = "colValSeverity";
        colValSeverity.Width            = 80;

        // â”€â”€ colValMessage â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        colValMessage.AutoSizeMode      = DataGridViewAutoSizeColumnMode.Fill;
        colValMessage.DataPropertyName  = "Message";
        colValMessage.HeaderText        = "Message";
        colValMessage.Name              = "colValMessage";
        colValMessage.Width             = 360;

        // â”€â”€ colValEntityType â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        colValEntityType.DataPropertyName = "EntityType";
        colValEntityType.HeaderText       = "Entity Type";
        colValEntityType.Name             = "colValEntityType";
        colValEntityType.Width            = 140;

        // â”€â”€ colValEntityId â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        colValEntityId.DataPropertyName = "EntityId";
        colValEntityId.HeaderText       = "Entity ID";
        colValEntityId.Name             = "colValEntityId";
        colValEntityId.Width            = 140;

        // â”€â”€ colValFieldName â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        colValFieldName.DataPropertyName = "FieldName";
        colValFieldName.HeaderText       = "Field";
        colValFieldName.Name             = "colValFieldName";
        colValFieldName.Width            = 120;

        // â”€â”€ ucValidation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(pnlContent);
        Name = "ucValidation";
        Size = new Size(858, 600);

        // â”€â”€ End init / resume â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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


### File: PodcastUniverseEditor\UI\Controls\ucVessels.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls;

partial class ucVessels
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
        // â”€â”€ Declare all controls (all new() calls first â€” WinForms Designer convention) â”€â”€â”€â”€â”€â”€
        gridVessels = new DataGridView();

        // â”€â”€ Begin init / suspend â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)gridVessels).BeginInit();
        SuspendLayout();

        // â”€â”€ gridVessels â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        gridVessels.AllowUserToAddRows          = false;
        gridVessels.AutoGenerateColumns         = true;
        gridVessels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridVessels.Dock                        = DockStyle.Fill;
        gridVessels.Location                    = new Point(0, 0);
        gridVessels.MultiSelect                 = false;
        gridVessels.Name                        = "gridVessels";
        gridVessels.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
        gridVessels.Size                        = new Size(858, 600);
        gridVessels.TabIndex                    = 0;

        // â”€â”€ ucVessels â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode       = AutoScaleMode.Font;
        Controls.Add(gridVessels);
        Name = "ucVessels";
        Size = new Size(858, 600);

        // â”€â”€ End init / resume â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        ((System.ComponentModel.ISupportInitialize)gridVessels).EndInit();
        ResumeLayout(false);
    }

    private DataGridView gridVessels = null!;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\Episodes\ucEpisodeEntryDetail.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls.Episodes;

/// <summary>
/// UserControl that hosts the scrollable entry-detail editing panel.
/// Layout is defined in the Designer file; this class only exposes the controls
/// needed by the parent editor.
/// </summary>
public partial class ucEpisodeEntryDetail : UserControl
{
    public ucEpisodeEntryDetail()
    {
        InitializeComponent();
    }

    public FlowLayoutPanel FlpValidationHints => flpValidationHints;

    // Entry: structural
    public ComboBox CboEntryKind => cboEntryKind;
    public ComboBox CboEntrySourceType => cboEntrySourceType;
    public TextBox TxtEntryName => txtEntryName;
    public NumericUpDown NumEntrySortOrder => numEntrySortOrder;
    public CheckBox ChkEntryLocked => chkEntryLocked;
    public CheckBox ChkEntryCanon => chkEntryCanon;
    public NumericUpDown NumEntryRandomSeed => numEntryRandomSeed;
    public TextBox TxtEntryNotes => txtEntryNotes;

    // Entry: operation / notice
    public ComboBox CboEntryOperationType => cboEntryOperationType;
    public ComboBox CboEntryNoticeType => cboEntryNoticeType;

    // Entry: location
    public ComboBox CboEntryStation => cboEntryStation;
    public ComboBox CboEntryDock => cboEntryDock;
    public ComboBox CboEntryOriginStation => cboEntryOriginStation;
    public ComboBox CboEntryDestinationStation => cboEntryDestinationStation;

    // Entry: vessel
    public ComboBox CboEntryVessel => cboEntryVessel;
    public ComboBox CboEntryVesselClassOverride => cboEntryVesselClassOverride;
    public TextBox TxtEntryRegistryOverride => txtEntryRegistryOverride;

    // Entry: purpose
    public ComboBox CboEntryDeclaredPurpose => cboEntryDeclaredPurpose;
    public ComboBox CboEntryActualPurpose => cboEntryActualPurpose;

    // Entry: statuses
    public ComboBox CboEntryManifestStatus => cboEntryManifestStatus;
    public ComboBox CboEntryInspectionStatus => cboEntryInspectionStatus;
    public ComboBox CboEntryClearanceStatus => cboEntryClearanceStatus;
    public ComboBox CboEntryEnvironmentalCondition => cboEntryEnvironmentalCondition;

    // Entry: narrative
    public ComboBox CboEntryDirective => cboEntryDirective;
    public ComboBox CboEntryIncidentPhrase => cboEntryIncidentPhrase;
    public ComboBox CboEntryResolutionPhrase => cboEntryResolutionPhrase;
    public ComboBox CboEntryRouteStatusPhrase => cboEntryRouteStatusPhrase;
    public TextBox TxtEntryPublicBodyOverride => txtEntryPublicBodyOverride;

    // Entry: story thread
    public ComboBox CboEntryStoryThread => cboEntryStoryThread;
    public ComboBox CboEntryAppliedStoryBeat => cboEntryAppliedStoryBeat;
    public ComboBox CboEntryAnomalySeverity => cboEntryAnomalySeverity;

    // Entry: hidden truth
    public TextBox TxtEntryHiddenTruthNotes => txtEntryHiddenTruthNotes;

    // Entry: schedule
    public CheckBox ChkEntryScheduledEnabled => chkEntryScheduledEnabled;
    public DateTimePicker DtpEntryScheduledUtc => dtpEntryScheduledUtc;

    // Manifest grids
    public DataGridView GridDeclaredCargo => gridDeclaredCargo;
    public DataGridView GridActualCargo => gridActualCargo;
    public DataGridView GridDeclaredPassengers => gridDeclaredPassengers;
    public DataGridView GridActualPassengers => gridActualPassengers;

    // Manifest buttons
    public Button BtnDeclaredCargoAdd => btnDeclaredCargoAdd;
    public Button BtnDeclaredCargoDelete => btnDeclaredCargoDelete;
    public Button BtnActualCargoAdd => btnActualCargoAdd;
    public Button BtnActualCargoDelete => btnActualCargoDelete;
    public Button BtnDeclaredPassengerAdd => btnDeclaredPassengerAdd;
    public Button BtnDeclaredPassengerDelete => btnDeclaredPassengerDelete;
    public Button BtnActualPassengerAdd => btnActualPassengerAdd;
    public Button BtnActualPassengerDelete => btnActualPassengerDelete;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\Episodes\ucEpisodeEntryDetail.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls.Episodes;

partial class ucEpisodeEntryDetail
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
        pnlScrollHost = new Panel();
        tblEntryDetailLayout = new TableLayoutPanel();
        lblEntrySection = new Label();
        lblEntryKind = new Label();
        cboEntryKind = new ComboBox();
        lblEntrySourceType = new Label();
        cboEntrySourceType = new ComboBox();
        lblEntryName = new Label();
        txtEntryName = new TextBox();
        lblEntrySortOrder = new Label();
        numEntrySortOrder = new NumericUpDown();
        lblEntryFlags = new Label();
        pnlEntryFlags = new Panel();
        chkEntryCanon = new CheckBox();
        chkEntryLocked = new CheckBox();
        lblEntryRandomSeed = new Label();
        numEntryRandomSeed = new NumericUpDown();
        lblEntryNotes = new Label();
        txtEntryNotes = new TextBox();
        lblOperationNoticeSection = new Label();
        lblEntryOperationType = new Label();
        cboEntryOperationType = new ComboBox();
        lblEntryNoticeType = new Label();
        cboEntryNoticeType = new ComboBox();
        lblLocationSection = new Label();
        lblEntryStation = new Label();
        cboEntryStation = new ComboBox();
        lblEntryDock = new Label();
        cboEntryDock = new ComboBox();
        lblEntryOriginStation = new Label();
        cboEntryOriginStation = new ComboBox();
        lblEntryDestinationStation = new Label();
        cboEntryDestinationStation = new ComboBox();
        lblVesselSection = new Label();
        lblEntryVessel = new Label();
        cboEntryVessel = new ComboBox();
        lblEntryVesselClassOverride = new Label();
        cboEntryVesselClassOverride = new ComboBox();
        lblEntryRegistryOverride = new Label();
        txtEntryRegistryOverride = new TextBox();
        lblPurposeSection = new Label();
        lblEntryDeclaredPurpose = new Label();
        cboEntryDeclaredPurpose = new ComboBox();
        lblEntryActualPurpose = new Label();
        cboEntryActualPurpose = new ComboBox();
        lblStatusesSection = new Label();
        lblEntryManifestStatus = new Label();
        cboEntryManifestStatus = new ComboBox();
        lblEntryInspectionStatus = new Label();
        cboEntryInspectionStatus = new ComboBox();
        lblEntryClearanceStatus = new Label();
        cboEntryClearanceStatus = new ComboBox();
        lblEntryEnvironmentalCondition = new Label();
        cboEntryEnvironmentalCondition = new ComboBox();
        lblNarrativeSection = new Label();
        lblEntryDirective = new Label();
        cboEntryDirective = new ComboBox();
        lblEntryIncidentPhrase = new Label();
        cboEntryIncidentPhrase = new ComboBox();
        lblEntryResolutionPhrase = new Label();
        cboEntryResolutionPhrase = new ComboBox();
        lblEntryRouteStatusPhrase = new Label();
        cboEntryRouteStatusPhrase = new ComboBox();
        lblEntryPublicBodyOverride = new Label();
        txtEntryPublicBodyOverride = new TextBox();
        lblStoryThreadSection = new Label();
        lblEntryStoryThread = new Label();
        cboEntryStoryThread = new ComboBox();
        lblEntryAppliedStoryBeat = new Label();
        cboEntryAppliedStoryBeat = new ComboBox();
        lblEntryAnomalySeverity = new Label();
        cboEntryAnomalySeverity = new ComboBox();
        lblHiddenTruthSection = new Label();
        lblEntryHiddenTruthNotes = new Label();
        txtEntryHiddenTruthNotes = new TextBox();
        lblScheduleSection = new Label();
        lblEntryScheduledUtc = new Label();
        pnlEntrySchedule = new Panel();
        dtpEntryScheduledUtc = new DateTimePicker();
        chkEntryScheduledEnabled = new CheckBox();
        lblDeclaredCargoSection = new Label();
        pnlDeclaredCargoContainer = new Panel();
        lblActualCargoSection = new Label();
        pnlActualCargoContainer = new Panel();
        lblDeclaredPassengersSection = new Label();
        pnlDeclaredPassengersContainer = new Panel();
        lblActualPassengersSection = new Label();
        pnlActualPassengersContainer = new Panel();
        flpValidationHints = new FlowLayoutPanel();
        gridDeclaredCargo = new DataGridView();
        pnlDeclaredCargoActions = new Panel();
        btnDeclaredCargoDelete = new Button();
        btnDeclaredCargoAdd = new Button();
        gridActualCargo = new DataGridView();
        pnlActualCargoActions = new Panel();
        btnActualCargoDelete = new Button();
        btnActualCargoAdd = new Button();
        gridDeclaredPassengers = new DataGridView();
        pnlDeclaredPassengersActions = new Panel();
        btnDeclaredPassengerDelete = new Button();
        btnDeclaredPassengerAdd = new Button();
        gridActualPassengers = new DataGridView();
        pnlActualPassengersActions = new Panel();
        btnActualPassengerDelete = new Button();
        btnActualPassengerAdd = new Button();
        pnlScrollHost.SuspendLayout();
        tblEntryDetailLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numEntrySortOrder).BeginInit();
        pnlEntryFlags.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numEntryRandomSeed).BeginInit();
        pnlEntrySchedule.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredCargo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridActualCargo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredPassengers).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridActualPassengers).BeginInit();
        SuspendLayout();
        // 
        // pnlScrollHost
        // 
        pnlScrollHost.AutoScroll = true;
        pnlScrollHost.Controls.Add(tblEntryDetailLayout);
        pnlScrollHost.Controls.Add(flpValidationHints);
        pnlScrollHost.Dock = DockStyle.Fill;
        pnlScrollHost.Location = new Point(0, 0);
        pnlScrollHost.Margin = new Padding(4, 5, 4, 5);
        pnlScrollHost.Name = "pnlScrollHost";
        pnlScrollHost.Size = new Size(571, 1000);
        pnlScrollHost.TabIndex = 0;
        // 
        // tblEntryDetailLayout
        // 
        tblEntryDetailLayout.AutoSize = true;
        tblEntryDetailLayout.ColumnCount = 2;
        tblEntryDetailLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 257F));
        tblEntryDetailLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblEntryDetailLayout.Controls.Add(lblEntrySection, 0, 0);
        tblEntryDetailLayout.Controls.Add(lblEntryKind, 0, 1);
        tblEntryDetailLayout.Controls.Add(cboEntryKind, 1, 1);
        tblEntryDetailLayout.Controls.Add(lblEntrySourceType, 0, 2);
        tblEntryDetailLayout.Controls.Add(cboEntrySourceType, 1, 2);
        tblEntryDetailLayout.Controls.Add(lblEntryName, 0, 3);
        tblEntryDetailLayout.Controls.Add(txtEntryName, 1, 3);
        tblEntryDetailLayout.Controls.Add(lblEntrySortOrder, 0, 4);
        tblEntryDetailLayout.Controls.Add(numEntrySortOrder, 1, 4);
        tblEntryDetailLayout.Controls.Add(lblEntryFlags, 0, 5);
        tblEntryDetailLayout.Controls.Add(pnlEntryFlags, 1, 5);
        tblEntryDetailLayout.Controls.Add(lblEntryRandomSeed, 0, 6);
        tblEntryDetailLayout.Controls.Add(numEntryRandomSeed, 1, 6);
        tblEntryDetailLayout.Controls.Add(lblEntryNotes, 0, 7);
        tblEntryDetailLayout.Controls.Add(txtEntryNotes, 1, 7);
        tblEntryDetailLayout.Controls.Add(lblOperationNoticeSection, 0, 8);
        tblEntryDetailLayout.Controls.Add(lblEntryOperationType, 0, 9);
        tblEntryDetailLayout.Controls.Add(cboEntryOperationType, 1, 9);
        tblEntryDetailLayout.Controls.Add(lblEntryNoticeType, 0, 10);
        tblEntryDetailLayout.Controls.Add(cboEntryNoticeType, 1, 10);
        tblEntryDetailLayout.Controls.Add(lblLocationSection, 0, 11);
        tblEntryDetailLayout.Controls.Add(lblEntryStation, 0, 12);
        tblEntryDetailLayout.Controls.Add(cboEntryStation, 1, 12);
        tblEntryDetailLayout.Controls.Add(lblEntryDock, 0, 13);
        tblEntryDetailLayout.Controls.Add(cboEntryDock, 1, 13);
        tblEntryDetailLayout.Controls.Add(lblEntryOriginStation, 0, 14);
        tblEntryDetailLayout.Controls.Add(cboEntryOriginStation, 1, 14);
        tblEntryDetailLayout.Controls.Add(lblEntryDestinationStation, 0, 15);
        tblEntryDetailLayout.Controls.Add(cboEntryDestinationStation, 1, 15);
        tblEntryDetailLayout.Controls.Add(lblVesselSection, 0, 16);
        tblEntryDetailLayout.Controls.Add(lblEntryVessel, 0, 17);
        tblEntryDetailLayout.Controls.Add(cboEntryVessel, 1, 17);
        tblEntryDetailLayout.Controls.Add(lblEntryVesselClassOverride, 0, 18);
        tblEntryDetailLayout.Controls.Add(cboEntryVesselClassOverride, 1, 18);
        tblEntryDetailLayout.Controls.Add(lblEntryRegistryOverride, 0, 19);
        tblEntryDetailLayout.Controls.Add(txtEntryRegistryOverride, 1, 19);
        tblEntryDetailLayout.Controls.Add(lblPurposeSection, 0, 20);
        tblEntryDetailLayout.Controls.Add(lblEntryDeclaredPurpose, 0, 21);
        tblEntryDetailLayout.Controls.Add(cboEntryDeclaredPurpose, 1, 21);
        tblEntryDetailLayout.Controls.Add(lblEntryActualPurpose, 0, 22);
        tblEntryDetailLayout.Controls.Add(cboEntryActualPurpose, 1, 22);
        tblEntryDetailLayout.Controls.Add(lblStatusesSection, 0, 23);
        tblEntryDetailLayout.Controls.Add(lblEntryManifestStatus, 0, 24);
        tblEntryDetailLayout.Controls.Add(cboEntryManifestStatus, 1, 24);
        tblEntryDetailLayout.Controls.Add(lblEntryInspectionStatus, 0, 25);
        tblEntryDetailLayout.Controls.Add(cboEntryInspectionStatus, 1, 25);
        tblEntryDetailLayout.Controls.Add(lblEntryClearanceStatus, 0, 26);
        tblEntryDetailLayout.Controls.Add(cboEntryClearanceStatus, 1, 26);
        tblEntryDetailLayout.Controls.Add(lblEntryEnvironmentalCondition, 0, 27);
        tblEntryDetailLayout.Controls.Add(cboEntryEnvironmentalCondition, 1, 27);
        tblEntryDetailLayout.Controls.Add(lblNarrativeSection, 0, 28);
        tblEntryDetailLayout.Controls.Add(lblEntryDirective, 0, 29);
        tblEntryDetailLayout.Controls.Add(cboEntryDirective, 1, 29);
        tblEntryDetailLayout.Controls.Add(lblEntryIncidentPhrase, 0, 30);
        tblEntryDetailLayout.Controls.Add(cboEntryIncidentPhrase, 1, 30);
        tblEntryDetailLayout.Controls.Add(lblEntryResolutionPhrase, 0, 31);
        tblEntryDetailLayout.Controls.Add(cboEntryResolutionPhrase, 1, 31);
        tblEntryDetailLayout.Controls.Add(lblEntryRouteStatusPhrase, 0, 32);
        tblEntryDetailLayout.Controls.Add(cboEntryRouteStatusPhrase, 1, 32);
        tblEntryDetailLayout.Controls.Add(lblEntryPublicBodyOverride, 0, 33);
        tblEntryDetailLayout.Controls.Add(txtEntryPublicBodyOverride, 1, 33);
        tblEntryDetailLayout.Controls.Add(lblStoryThreadSection, 0, 34);
        tblEntryDetailLayout.Controls.Add(lblEntryStoryThread, 0, 35);
        tblEntryDetailLayout.Controls.Add(cboEntryStoryThread, 1, 35);
        tblEntryDetailLayout.Controls.Add(lblEntryAppliedStoryBeat, 0, 36);
        tblEntryDetailLayout.Controls.Add(cboEntryAppliedStoryBeat, 1, 36);
        tblEntryDetailLayout.Controls.Add(lblEntryAnomalySeverity, 0, 37);
        tblEntryDetailLayout.Controls.Add(cboEntryAnomalySeverity, 1, 37);
        tblEntryDetailLayout.Controls.Add(lblHiddenTruthSection, 0, 38);
        tblEntryDetailLayout.Controls.Add(lblEntryHiddenTruthNotes, 0, 39);
        tblEntryDetailLayout.Controls.Add(txtEntryHiddenTruthNotes, 1, 39);
        tblEntryDetailLayout.Controls.Add(lblScheduleSection, 0, 40);
        tblEntryDetailLayout.Controls.Add(lblEntryScheduledUtc, 0, 41);
        tblEntryDetailLayout.Controls.Add(pnlEntrySchedule, 1, 41);
        tblEntryDetailLayout.Controls.Add(lblDeclaredCargoSection, 0, 42);
        tblEntryDetailLayout.Controls.Add(pnlDeclaredCargoContainer, 0, 43);
        tblEntryDetailLayout.Controls.Add(lblActualCargoSection, 0, 44);
        tblEntryDetailLayout.Controls.Add(pnlActualCargoContainer, 0, 45);
        tblEntryDetailLayout.Controls.Add(lblDeclaredPassengersSection, 0, 46);
        tblEntryDetailLayout.Controls.Add(pnlDeclaredPassengersContainer, 0, 47);
        tblEntryDetailLayout.Controls.Add(lblActualPassengersSection, 0, 48);
        tblEntryDetailLayout.Controls.Add(pnlActualPassengersContainer, 0, 49);
        tblEntryDetailLayout.Dock = DockStyle.Top;
        tblEntryDetailLayout.Location = new Point(0, 14);
        tblEntryDetailLayout.Margin = new Padding(4, 5, 4, 5);
        tblEntryDetailLayout.Name = "tblEntryDetailLayout";
        tblEntryDetailLayout.Padding = new Padding(6, 7, 6, 13);
        tblEntryDetailLayout.RowCount = 50;
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 303F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 303F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 270F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 270F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tblEntryDetailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tblEntryDetailLayout.Size = new Size(545, 3574);
        tblEntryDetailLayout.TabIndex = 1;
        // 
        // lblEntrySection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblEntrySection, 2);
        lblEntrySection.Location = new Point(10, 7);
        lblEntrySection.Margin = new Padding(4, 0, 4, 0);
        lblEntrySection.Name = "lblEntrySection";
        lblEntrySection.Size = new Size(143, 38);
        lblEntrySection.TabIndex = 0;
        lblEntrySection.Text = "Entry";
        // 
        // lblEntryKind
        // 
        lblEntryKind.Location = new Point(10, 54);
        lblEntryKind.Margin = new Padding(4, 0, 4, 0);
        lblEntryKind.Name = "lblEntryKind";
        lblEntryKind.Size = new Size(143, 38);
        lblEntryKind.TabIndex = 1;
        lblEntryKind.Text = "Kind:";
        // 
        // cboEntryKind
        // 
        cboEntryKind.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryKind.Location = new Point(267, 59);
        cboEntryKind.Margin = new Padding(4, 5, 4, 5);
        cboEntryKind.Name = "cboEntryKind";
        cboEntryKind.Size = new Size(171, 33);
        cboEntryKind.TabIndex = 2;
        // 
        // lblEntrySourceType
        // 
        lblEntrySourceType.Location = new Point(10, 104);
        lblEntrySourceType.Margin = new Padding(4, 0, 4, 0);
        lblEntrySourceType.Name = "lblEntrySourceType";
        lblEntrySourceType.Size = new Size(143, 38);
        lblEntrySourceType.TabIndex = 3;
        lblEntrySourceType.Text = "Source Type:";
        // 
        // cboEntrySourceType
        // 
        cboEntrySourceType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntrySourceType.Location = new Point(267, 109);
        cboEntrySourceType.Margin = new Padding(4, 5, 4, 5);
        cboEntrySourceType.Name = "cboEntrySourceType";
        cboEntrySourceType.Size = new Size(171, 33);
        cboEntrySourceType.TabIndex = 4;
        // 
        // lblEntryName
        // 
        lblEntryName.Location = new Point(10, 154);
        lblEntryName.Margin = new Padding(4, 0, 4, 0);
        lblEntryName.Name = "lblEntryName";
        lblEntryName.Size = new Size(143, 38);
        lblEntryName.TabIndex = 5;
        lblEntryName.Text = "Name:";
        // 
        // txtEntryName
        // 
        txtEntryName.Location = new Point(267, 159);
        txtEntryName.Margin = new Padding(4, 5, 4, 5);
        txtEntryName.Name = "txtEntryName";
        txtEntryName.Size = new Size(141, 31);
        txtEntryName.TabIndex = 6;
        // 
        // lblEntrySortOrder
        // 
        lblEntrySortOrder.Location = new Point(10, 204);
        lblEntrySortOrder.Margin = new Padding(4, 0, 4, 0);
        lblEntrySortOrder.Name = "lblEntrySortOrder";
        lblEntrySortOrder.Size = new Size(143, 38);
        lblEntrySortOrder.TabIndex = 7;
        lblEntrySortOrder.Text = "Sort Order:";
        // 
        // numEntrySortOrder
        // 
        numEntrySortOrder.Location = new Point(267, 209);
        numEntrySortOrder.Margin = new Padding(4, 5, 4, 5);
        numEntrySortOrder.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        numEntrySortOrder.Name = "numEntrySortOrder";
        numEntrySortOrder.Size = new Size(171, 31);
        numEntrySortOrder.TabIndex = 8;
        // 
        // lblEntryFlags
        // 
        lblEntryFlags.Location = new Point(10, 254);
        lblEntryFlags.Margin = new Padding(4, 0, 4, 0);
        lblEntryFlags.Name = "lblEntryFlags";
        lblEntryFlags.Size = new Size(143, 38);
        lblEntryFlags.TabIndex = 9;
        lblEntryFlags.Text = "Flags:";
        // 
        // pnlEntryFlags
        // 
        pnlEntryFlags.Controls.Add(chkEntryCanon);
        pnlEntryFlags.Controls.Add(chkEntryLocked);
        pnlEntryFlags.Dock = DockStyle.Fill;
        pnlEntryFlags.Location = new Point(267, 259);
        pnlEntryFlags.Margin = new Padding(4, 5, 4, 5);
        pnlEntryFlags.Name = "pnlEntryFlags";
        pnlEntryFlags.Size = new Size(268, 40);
        pnlEntryFlags.TabIndex = 12;
        // 
        // chkEntryCanon
        // 
        chkEntryCanon.AutoSize = true;
        chkEntryCanon.Location = new Point(129, 2);
        chkEntryCanon.Margin = new Padding(4, 5, 4, 5);
        chkEntryCanon.Name = "chkEntryCanon";
        chkEntryCanon.Size = new Size(89, 29);
        chkEntryCanon.TabIndex = 1;
        chkEntryCanon.Text = "Canon";
        chkEntryCanon.UseVisualStyleBackColor = true;
        // 
        // chkEntryLocked
        // 
        chkEntryLocked.AutoSize = true;
        chkEntryLocked.Location = new Point(0, 2);
        chkEntryLocked.Margin = new Padding(4, 5, 4, 5);
        chkEntryLocked.Name = "chkEntryLocked";
        chkEntryLocked.Size = new Size(94, 29);
        chkEntryLocked.TabIndex = 0;
        chkEntryLocked.Text = "Locked";
        chkEntryLocked.UseVisualStyleBackColor = true;
        // 
        // lblEntryRandomSeed
        // 
        lblEntryRandomSeed.Location = new Point(10, 304);
        lblEntryRandomSeed.Margin = new Padding(4, 0, 4, 0);
        lblEntryRandomSeed.Name = "lblEntryRandomSeed";
        lblEntryRandomSeed.Size = new Size(143, 38);
        lblEntryRandomSeed.TabIndex = 13;
        lblEntryRandomSeed.Text = "Random Seed:";
        // 
        // numEntryRandomSeed
        // 
        numEntryRandomSeed.Location = new Point(267, 309);
        numEntryRandomSeed.Margin = new Padding(4, 5, 4, 5);
        numEntryRandomSeed.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
        numEntryRandomSeed.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
        numEntryRandomSeed.Name = "numEntryRandomSeed";
        numEntryRandomSeed.Size = new Size(171, 31);
        numEntryRandomSeed.TabIndex = 14;
        // 
        // lblEntryNotes
        // 
        lblEntryNotes.Location = new Point(10, 354);
        lblEntryNotes.Margin = new Padding(4, 0, 4, 0);
        lblEntryNotes.Name = "lblEntryNotes";
        lblEntryNotes.Size = new Size(143, 38);
        lblEntryNotes.TabIndex = 15;
        lblEntryNotes.Text = "Notes:";
        // 
        // txtEntryNotes
        // 
        txtEntryNotes.Location = new Point(267, 359);
        txtEntryNotes.Margin = new Padding(4, 5, 4, 5);
        txtEntryNotes.Multiline = true;
        txtEntryNotes.Name = "txtEntryNotes";
        txtEntryNotes.ScrollBars = ScrollBars.Vertical;
        txtEntryNotes.Size = new Size(268, 101);
        txtEntryNotes.TabIndex = 16;
        // 
        // lblOperationNoticeSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblOperationNoticeSection, 2);
        lblOperationNoticeSection.Location = new Point(10, 474);
        lblOperationNoticeSection.Margin = new Padding(4, 0, 4, 0);
        lblOperationNoticeSection.Name = "lblOperationNoticeSection";
        lblOperationNoticeSection.Size = new Size(143, 38);
        lblOperationNoticeSection.TabIndex = 17;
        lblOperationNoticeSection.Text = "Operation / Notice";
        // 
        // lblEntryOperationType
        // 
        lblEntryOperationType.Location = new Point(10, 521);
        lblEntryOperationType.Margin = new Padding(4, 0, 4, 0);
        lblEntryOperationType.Name = "lblEntryOperationType";
        lblEntryOperationType.Size = new Size(143, 38);
        lblEntryOperationType.TabIndex = 18;
        lblEntryOperationType.Text = "Operation Type:";
        // 
        // cboEntryOperationType
        // 
        cboEntryOperationType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryOperationType.Location = new Point(267, 526);
        cboEntryOperationType.Margin = new Padding(4, 5, 4, 5);
        cboEntryOperationType.Name = "cboEntryOperationType";
        cboEntryOperationType.Size = new Size(171, 33);
        cboEntryOperationType.TabIndex = 19;
        // 
        // lblEntryNoticeType
        // 
        lblEntryNoticeType.Location = new Point(10, 571);
        lblEntryNoticeType.Margin = new Padding(4, 0, 4, 0);
        lblEntryNoticeType.Name = "lblEntryNoticeType";
        lblEntryNoticeType.Size = new Size(143, 38);
        lblEntryNoticeType.TabIndex = 20;
        lblEntryNoticeType.Text = "Notice Type:";
        // 
        // cboEntryNoticeType
        // 
        cboEntryNoticeType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryNoticeType.Location = new Point(267, 576);
        cboEntryNoticeType.Margin = new Padding(4, 5, 4, 5);
        cboEntryNoticeType.Name = "cboEntryNoticeType";
        cboEntryNoticeType.Size = new Size(171, 33);
        cboEntryNoticeType.TabIndex = 21;
        // 
        // lblLocationSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblLocationSection, 2);
        lblLocationSection.Location = new Point(10, 621);
        lblLocationSection.Margin = new Padding(4, 0, 4, 0);
        lblLocationSection.Name = "lblLocationSection";
        lblLocationSection.Size = new Size(143, 38);
        lblLocationSection.TabIndex = 22;
        lblLocationSection.Text = "Location";
        // 
        // lblEntryStation
        // 
        lblEntryStation.Location = new Point(10, 668);
        lblEntryStation.Margin = new Padding(4, 0, 4, 0);
        lblEntryStation.Name = "lblEntryStation";
        lblEntryStation.Size = new Size(143, 38);
        lblEntryStation.TabIndex = 23;
        lblEntryStation.Text = "Station:";
        // 
        // cboEntryStation
        // 
        cboEntryStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryStation.Location = new Point(267, 673);
        cboEntryStation.Margin = new Padding(4, 5, 4, 5);
        cboEntryStation.Name = "cboEntryStation";
        cboEntryStation.Size = new Size(171, 33);
        cboEntryStation.TabIndex = 24;
        // 
        // lblEntryDock
        // 
        lblEntryDock.Location = new Point(10, 718);
        lblEntryDock.Margin = new Padding(4, 0, 4, 0);
        lblEntryDock.Name = "lblEntryDock";
        lblEntryDock.Size = new Size(143, 38);
        lblEntryDock.TabIndex = 25;
        lblEntryDock.Text = "Dock:";
        // 
        // cboEntryDock
        // 
        cboEntryDock.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDock.Location = new Point(267, 723);
        cboEntryDock.Margin = new Padding(4, 5, 4, 5);
        cboEntryDock.Name = "cboEntryDock";
        cboEntryDock.Size = new Size(171, 33);
        cboEntryDock.TabIndex = 26;
        // 
        // lblEntryOriginStation
        // 
        lblEntryOriginStation.Location = new Point(10, 768);
        lblEntryOriginStation.Margin = new Padding(4, 0, 4, 0);
        lblEntryOriginStation.Name = "lblEntryOriginStation";
        lblEntryOriginStation.Size = new Size(143, 38);
        lblEntryOriginStation.TabIndex = 27;
        lblEntryOriginStation.Text = "Origin Station:";
        // 
        // cboEntryOriginStation
        // 
        cboEntryOriginStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryOriginStation.Location = new Point(267, 773);
        cboEntryOriginStation.Margin = new Padding(4, 5, 4, 5);
        cboEntryOriginStation.Name = "cboEntryOriginStation";
        cboEntryOriginStation.Size = new Size(171, 33);
        cboEntryOriginStation.TabIndex = 28;
        // 
        // lblEntryDestinationStation
        // 
        lblEntryDestinationStation.Location = new Point(10, 818);
        lblEntryDestinationStation.Margin = new Padding(4, 0, 4, 0);
        lblEntryDestinationStation.Name = "lblEntryDestinationStation";
        lblEntryDestinationStation.Size = new Size(143, 38);
        lblEntryDestinationStation.TabIndex = 29;
        lblEntryDestinationStation.Text = "Destination Station:";
        // 
        // cboEntryDestinationStation
        // 
        cboEntryDestinationStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDestinationStation.Location = new Point(267, 823);
        cboEntryDestinationStation.Margin = new Padding(4, 5, 4, 5);
        cboEntryDestinationStation.Name = "cboEntryDestinationStation";
        cboEntryDestinationStation.Size = new Size(171, 33);
        cboEntryDestinationStation.TabIndex = 30;
        // 
        // lblVesselSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblVesselSection, 2);
        lblVesselSection.Location = new Point(10, 865);
        lblVesselSection.Margin = new Padding(4, 0, 4, 0);
        lblVesselSection.Name = "lblVesselSection";
        lblVesselSection.Size = new Size(143, 38);
        lblVesselSection.TabIndex = 31;
        lblVesselSection.Text = "Vessel";
        // 
        // lblEntryVessel
        // 
        lblEntryVessel.Location = new Point(10, 915);
        lblEntryVessel.Margin = new Padding(4, 0, 4, 0);
        lblEntryVessel.Name = "lblEntryVessel";
        lblEntryVessel.Size = new Size(143, 38);
        lblEntryVessel.TabIndex = 32;
        lblEntryVessel.Text = "Vessel:";
        // 
        // cboEntryVessel
        // 
        cboEntryVessel.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryVessel.Location = new Point(267, 920);
        cboEntryVessel.Margin = new Padding(4, 5, 4, 5);
        cboEntryVessel.Name = "cboEntryVessel";
        cboEntryVessel.Size = new Size(171, 33);
        cboEntryVessel.TabIndex = 33;
        // 
        // lblEntryVesselClassOverride
        // 
        lblEntryVesselClassOverride.Location = new Point(10, 965);
        lblEntryVesselClassOverride.Margin = new Padding(4, 0, 4, 0);
        lblEntryVesselClassOverride.Name = "lblEntryVesselClassOverride";
        lblEntryVesselClassOverride.Size = new Size(143, 38);
        lblEntryVesselClassOverride.TabIndex = 34;
        lblEntryVesselClassOverride.Text = "Class Override:";
        // 
        // cboEntryVesselClassOverride
        // 
        cboEntryVesselClassOverride.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryVesselClassOverride.Location = new Point(267, 970);
        cboEntryVesselClassOverride.Margin = new Padding(4, 5, 4, 5);
        cboEntryVesselClassOverride.Name = "cboEntryVesselClassOverride";
        cboEntryVesselClassOverride.Size = new Size(171, 33);
        cboEntryVesselClassOverride.TabIndex = 35;
        // 
        // lblEntryRegistryOverride
        // 
        lblEntryRegistryOverride.Location = new Point(10, 1015);
        lblEntryRegistryOverride.Margin = new Padding(4, 0, 4, 0);
        lblEntryRegistryOverride.Name = "lblEntryRegistryOverride";
        lblEntryRegistryOverride.Size = new Size(143, 38);
        lblEntryRegistryOverride.TabIndex = 36;
        lblEntryRegistryOverride.Text = "Registry Override:";
        // 
        // txtEntryRegistryOverride
        // 
        txtEntryRegistryOverride.Location = new Point(267, 1020);
        txtEntryRegistryOverride.Margin = new Padding(4, 5, 4, 5);
        txtEntryRegistryOverride.Name = "txtEntryRegistryOverride";
        txtEntryRegistryOverride.Size = new Size(141, 31);
        txtEntryRegistryOverride.TabIndex = 37;
        // 
        // lblPurposeSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblPurposeSection, 2);
        lblPurposeSection.Location = new Point(10, 1062);
        lblPurposeSection.Margin = new Padding(4, 0, 4, 0);
        lblPurposeSection.Name = "lblPurposeSection";
        lblPurposeSection.Size = new Size(143, 38);
        lblPurposeSection.TabIndex = 38;
        lblPurposeSection.Text = "Purpose";
        // 
        // lblEntryDeclaredPurpose
        // 
        lblEntryDeclaredPurpose.Location = new Point(10, 1112);
        lblEntryDeclaredPurpose.Margin = new Padding(4, 0, 4, 0);
        lblEntryDeclaredPurpose.Name = "lblEntryDeclaredPurpose";
        lblEntryDeclaredPurpose.Size = new Size(143, 38);
        lblEntryDeclaredPurpose.TabIndex = 39;
        lblEntryDeclaredPurpose.Text = "Declared Purpose:";
        // 
        // cboEntryDeclaredPurpose
        // 
        cboEntryDeclaredPurpose.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDeclaredPurpose.Location = new Point(267, 1117);
        cboEntryDeclaredPurpose.Margin = new Padding(4, 5, 4, 5);
        cboEntryDeclaredPurpose.Name = "cboEntryDeclaredPurpose";
        cboEntryDeclaredPurpose.Size = new Size(171, 33);
        cboEntryDeclaredPurpose.TabIndex = 40;
        // 
        // lblEntryActualPurpose
        // 
        lblEntryActualPurpose.Location = new Point(10, 1162);
        lblEntryActualPurpose.Margin = new Padding(4, 0, 4, 0);
        lblEntryActualPurpose.Name = "lblEntryActualPurpose";
        lblEntryActualPurpose.Size = new Size(143, 38);
        lblEntryActualPurpose.TabIndex = 41;
        lblEntryActualPurpose.Text = "Actual Purpose:";
        // 
        // cboEntryActualPurpose
        // 
        cboEntryActualPurpose.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryActualPurpose.Location = new Point(267, 1167);
        cboEntryActualPurpose.Margin = new Padding(4, 5, 4, 5);
        cboEntryActualPurpose.Name = "cboEntryActualPurpose";
        cboEntryActualPurpose.Size = new Size(171, 33);
        cboEntryActualPurpose.TabIndex = 42;
        // 
        // lblStatusesSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblStatusesSection, 2);
        lblStatusesSection.Location = new Point(10, 1209);
        lblStatusesSection.Margin = new Padding(4, 0, 4, 0);
        lblStatusesSection.Name = "lblStatusesSection";
        lblStatusesSection.Size = new Size(143, 38);
        lblStatusesSection.TabIndex = 43;
        lblStatusesSection.Text = "Statuses";
        // 
        // lblEntryManifestStatus
        // 
        lblEntryManifestStatus.Location = new Point(10, 1259);
        lblEntryManifestStatus.Margin = new Padding(4, 0, 4, 0);
        lblEntryManifestStatus.Name = "lblEntryManifestStatus";
        lblEntryManifestStatus.Size = new Size(143, 38);
        lblEntryManifestStatus.TabIndex = 44;
        lblEntryManifestStatus.Text = "Manifest Status:";
        // 
        // cboEntryManifestStatus
        // 
        cboEntryManifestStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryManifestStatus.Location = new Point(267, 1264);
        cboEntryManifestStatus.Margin = new Padding(4, 5, 4, 5);
        cboEntryManifestStatus.Name = "cboEntryManifestStatus";
        cboEntryManifestStatus.Size = new Size(171, 33);
        cboEntryManifestStatus.TabIndex = 45;
        // 
        // lblEntryInspectionStatus
        // 
        lblEntryInspectionStatus.Location = new Point(10, 1309);
        lblEntryInspectionStatus.Margin = new Padding(4, 0, 4, 0);
        lblEntryInspectionStatus.Name = "lblEntryInspectionStatus";
        lblEntryInspectionStatus.Size = new Size(143, 38);
        lblEntryInspectionStatus.TabIndex = 46;
        lblEntryInspectionStatus.Text = "Inspection Status:";
        // 
        // cboEntryInspectionStatus
        // 
        cboEntryInspectionStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryInspectionStatus.Location = new Point(267, 1314);
        cboEntryInspectionStatus.Margin = new Padding(4, 5, 4, 5);
        cboEntryInspectionStatus.Name = "cboEntryInspectionStatus";
        cboEntryInspectionStatus.Size = new Size(171, 33);
        cboEntryInspectionStatus.TabIndex = 47;
        // 
        // lblEntryClearanceStatus
        // 
        lblEntryClearanceStatus.Location = new Point(10, 1359);
        lblEntryClearanceStatus.Margin = new Padding(4, 0, 4, 0);
        lblEntryClearanceStatus.Name = "lblEntryClearanceStatus";
        lblEntryClearanceStatus.Size = new Size(143, 38);
        lblEntryClearanceStatus.TabIndex = 48;
        lblEntryClearanceStatus.Text = "Clearance Status:";
        // 
        // cboEntryClearanceStatus
        // 
        cboEntryClearanceStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryClearanceStatus.Location = new Point(267, 1364);
        cboEntryClearanceStatus.Margin = new Padding(4, 5, 4, 5);
        cboEntryClearanceStatus.Name = "cboEntryClearanceStatus";
        cboEntryClearanceStatus.Size = new Size(171, 33);
        cboEntryClearanceStatus.TabIndex = 49;
        // 
        // lblEntryEnvironmentalCondition
        // 
        lblEntryEnvironmentalCondition.Location = new Point(10, 1409);
        lblEntryEnvironmentalCondition.Margin = new Padding(4, 0, 4, 0);
        lblEntryEnvironmentalCondition.Name = "lblEntryEnvironmentalCondition";
        lblEntryEnvironmentalCondition.Size = new Size(143, 38);
        lblEntryEnvironmentalCondition.TabIndex = 50;
        lblEntryEnvironmentalCondition.Text = "Environment:";
        // 
        // cboEntryEnvironmentalCondition
        // 
        cboEntryEnvironmentalCondition.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryEnvironmentalCondition.Location = new Point(267, 1414);
        cboEntryEnvironmentalCondition.Margin = new Padding(4, 5, 4, 5);
        cboEntryEnvironmentalCondition.Name = "cboEntryEnvironmentalCondition";
        cboEntryEnvironmentalCondition.Size = new Size(171, 33);
        cboEntryEnvironmentalCondition.TabIndex = 51;
        // 
        // lblNarrativeSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblNarrativeSection, 2);
        lblNarrativeSection.Location = new Point(10, 1456);
        lblNarrativeSection.Margin = new Padding(4, 0, 4, 0);
        lblNarrativeSection.Name = "lblNarrativeSection";
        lblNarrativeSection.Size = new Size(143, 38);
        lblNarrativeSection.TabIndex = 52;
        lblNarrativeSection.Text = "Narrative";
        // 
        // lblEntryDirective
        // 
        lblEntryDirective.Location = new Point(10, 1506);
        lblEntryDirective.Margin = new Padding(4, 0, 4, 0);
        lblEntryDirective.Name = "lblEntryDirective";
        lblEntryDirective.Size = new Size(143, 38);
        lblEntryDirective.TabIndex = 53;
        lblEntryDirective.Text = "Directive:";
        // 
        // cboEntryDirective
        // 
        cboEntryDirective.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryDirective.Location = new Point(267, 1511);
        cboEntryDirective.Margin = new Padding(4, 5, 4, 5);
        cboEntryDirective.Name = "cboEntryDirective";
        cboEntryDirective.Size = new Size(171, 33);
        cboEntryDirective.TabIndex = 54;
        // 
        // lblEntryIncidentPhrase
        // 
        lblEntryIncidentPhrase.Location = new Point(10, 1556);
        lblEntryIncidentPhrase.Margin = new Padding(4, 0, 4, 0);
        lblEntryIncidentPhrase.Name = "lblEntryIncidentPhrase";
        lblEntryIncidentPhrase.Size = new Size(143, 38);
        lblEntryIncidentPhrase.TabIndex = 55;
        lblEntryIncidentPhrase.Text = "Incident Phrase:";
        // 
        // cboEntryIncidentPhrase
        // 
        cboEntryIncidentPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryIncidentPhrase.Location = new Point(267, 1561);
        cboEntryIncidentPhrase.Margin = new Padding(4, 5, 4, 5);
        cboEntryIncidentPhrase.Name = "cboEntryIncidentPhrase";
        cboEntryIncidentPhrase.Size = new Size(171, 33);
        cboEntryIncidentPhrase.TabIndex = 56;
        // 
        // lblEntryResolutionPhrase
        // 
        lblEntryResolutionPhrase.Location = new Point(10, 1606);
        lblEntryResolutionPhrase.Margin = new Padding(4, 0, 4, 0);
        lblEntryResolutionPhrase.Name = "lblEntryResolutionPhrase";
        lblEntryResolutionPhrase.Size = new Size(143, 38);
        lblEntryResolutionPhrase.TabIndex = 57;
        lblEntryResolutionPhrase.Text = "Resolution Phrase:";
        // 
        // cboEntryResolutionPhrase
        // 
        cboEntryResolutionPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryResolutionPhrase.Location = new Point(267, 1611);
        cboEntryResolutionPhrase.Margin = new Padding(4, 5, 4, 5);
        cboEntryResolutionPhrase.Name = "cboEntryResolutionPhrase";
        cboEntryResolutionPhrase.Size = new Size(171, 33);
        cboEntryResolutionPhrase.TabIndex = 58;
        // 
        // lblEntryRouteStatusPhrase
        // 
        lblEntryRouteStatusPhrase.Location = new Point(10, 1726);
        lblEntryRouteStatusPhrase.Margin = new Padding(4, 0, 4, 0);
        lblEntryRouteStatusPhrase.Name = "lblEntryRouteStatusPhrase";
        lblEntryRouteStatusPhrase.Size = new Size(143, 38);
        lblEntryRouteStatusPhrase.TabIndex = 59;
        lblEntryRouteStatusPhrase.Text = "Route Status Phrase:";
        // 
        // cboEntryRouteStatusPhrase
        // 
        cboEntryRouteStatusPhrase.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryRouteStatusPhrase.Location = new Point(267, 1731);
        cboEntryRouteStatusPhrase.Margin = new Padding(4, 5, 4, 5);
        cboEntryRouteStatusPhrase.Name = "cboEntryRouteStatusPhrase";
        cboEntryRouteStatusPhrase.Size = new Size(171, 33);
        cboEntryRouteStatusPhrase.TabIndex = 60;
        // 
        // lblEntryPublicBodyOverride
        // 
        lblEntryPublicBodyOverride.Location = new Point(10, 1773);
        lblEntryPublicBodyOverride.Margin = new Padding(4, 0, 4, 0);
        lblEntryPublicBodyOverride.Name = "lblEntryPublicBodyOverride";
        lblEntryPublicBodyOverride.Size = new Size(143, 38);
        lblEntryPublicBodyOverride.TabIndex = 61;
        lblEntryPublicBodyOverride.Text = "Public Body Override:";
        // 
        // txtEntryPublicBodyOverride
        // 
        txtEntryPublicBodyOverride.Location = new Point(267, 1778);
        txtEntryPublicBodyOverride.Margin = new Padding(4, 5, 4, 5);
        txtEntryPublicBodyOverride.Multiline = true;
        txtEntryPublicBodyOverride.Name = "txtEntryPublicBodyOverride";
        txtEntryPublicBodyOverride.ScrollBars = ScrollBars.Vertical;
        txtEntryPublicBodyOverride.Size = new Size(141, 37);
        txtEntryPublicBodyOverride.TabIndex = 62;
        // 
        // lblStoryThreadSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblStoryThreadSection, 2);
        lblStoryThreadSection.Location = new Point(10, 1823);
        lblStoryThreadSection.Margin = new Padding(4, 0, 4, 0);
        lblStoryThreadSection.Name = "lblStoryThreadSection";
        lblStoryThreadSection.Size = new Size(143, 38);
        lblStoryThreadSection.TabIndex = 63;
        lblStoryThreadSection.Text = "Story Thread";
        // 
        // lblEntryStoryThread
        // 
        lblEntryStoryThread.Location = new Point(10, 1873);
        lblEntryStoryThread.Margin = new Padding(4, 0, 4, 0);
        lblEntryStoryThread.Name = "lblEntryStoryThread";
        lblEntryStoryThread.Size = new Size(143, 38);
        lblEntryStoryThread.TabIndex = 64;
        lblEntryStoryThread.Text = "Story Thread:";
        // 
        // cboEntryStoryThread
        // 
        cboEntryStoryThread.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryStoryThread.Location = new Point(267, 1878);
        cboEntryStoryThread.Margin = new Padding(4, 5, 4, 5);
        cboEntryStoryThread.Name = "cboEntryStoryThread";
        cboEntryStoryThread.Size = new Size(171, 33);
        cboEntryStoryThread.TabIndex = 65;
        // 
        // lblEntryAppliedStoryBeat
        // 
        lblEntryAppliedStoryBeat.Location = new Point(10, 1923);
        lblEntryAppliedStoryBeat.Margin = new Padding(4, 0, 4, 0);
        lblEntryAppliedStoryBeat.Name = "lblEntryAppliedStoryBeat";
        lblEntryAppliedStoryBeat.Size = new Size(143, 38);
        lblEntryAppliedStoryBeat.TabIndex = 66;
        lblEntryAppliedStoryBeat.Text = "Story Beat:";
        // 
        // cboEntryAppliedStoryBeat
        // 
        cboEntryAppliedStoryBeat.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryAppliedStoryBeat.Location = new Point(267, 1928);
        cboEntryAppliedStoryBeat.Margin = new Padding(4, 5, 4, 5);
        cboEntryAppliedStoryBeat.Name = "cboEntryAppliedStoryBeat";
        cboEntryAppliedStoryBeat.Size = new Size(171, 33);
        cboEntryAppliedStoryBeat.TabIndex = 67;
        // 
        // lblEntryAnomalySeverity
        // 
        lblEntryAnomalySeverity.Location = new Point(10, 1970);
        lblEntryAnomalySeverity.Margin = new Padding(4, 0, 4, 0);
        lblEntryAnomalySeverity.Name = "lblEntryAnomalySeverity";
        lblEntryAnomalySeverity.Size = new Size(143, 38);
        lblEntryAnomalySeverity.TabIndex = 68;
        lblEntryAnomalySeverity.Text = "Anomaly Severity:";
        // 
        // cboEntryAnomalySeverity
        // 
        cboEntryAnomalySeverity.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryAnomalySeverity.Location = new Point(267, 1975);
        cboEntryAnomalySeverity.Margin = new Padding(4, 5, 4, 5);
        cboEntryAnomalySeverity.Name = "cboEntryAnomalySeverity";
        cboEntryAnomalySeverity.Size = new Size(171, 33);
        cboEntryAnomalySeverity.TabIndex = 69;
        // 
        // lblHiddenTruthSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblHiddenTruthSection, 2);
        lblHiddenTruthSection.Location = new Point(10, 2090);
        lblHiddenTruthSection.Margin = new Padding(4, 0, 4, 0);
        lblHiddenTruthSection.Name = "lblHiddenTruthSection";
        lblHiddenTruthSection.Size = new Size(143, 38);
        lblHiddenTruthSection.TabIndex = 70;
        lblHiddenTruthSection.Text = "Hidden Truth";
        // 
        // lblEntryHiddenTruthNotes
        // 
        lblEntryHiddenTruthNotes.Location = new Point(10, 2137);
        lblEntryHiddenTruthNotes.Margin = new Padding(4, 0, 4, 0);
        lblEntryHiddenTruthNotes.Name = "lblEntryHiddenTruthNotes";
        lblEntryHiddenTruthNotes.Size = new Size(143, 38);
        lblEntryHiddenTruthNotes.TabIndex = 71;
        lblEntryHiddenTruthNotes.Text = "Hidden Truth Notes:";
        // 
        // txtEntryHiddenTruthNotes
        // 
        txtEntryHiddenTruthNotes.Location = new Point(267, 2142);
        txtEntryHiddenTruthNotes.Margin = new Padding(4, 5, 4, 5);
        txtEntryHiddenTruthNotes.Multiline = true;
        txtEntryHiddenTruthNotes.Name = "txtEntryHiddenTruthNotes";
        txtEntryHiddenTruthNotes.ScrollBars = ScrollBars.Vertical;
        txtEntryHiddenTruthNotes.Size = new Size(141, 37);
        txtEntryHiddenTruthNotes.TabIndex = 72;
        // 
        // lblScheduleSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblScheduleSection, 2);
        lblScheduleSection.Location = new Point(10, 2187);
        lblScheduleSection.Margin = new Padding(4, 0, 4, 0);
        lblScheduleSection.Name = "lblScheduleSection";
        lblScheduleSection.Size = new Size(143, 38);
        lblScheduleSection.TabIndex = 73;
        lblScheduleSection.Text = "Schedule";
        // 
        // lblEntryScheduledUtc
        // 
        lblEntryScheduledUtc.Location = new Point(10, 2234);
        lblEntryScheduledUtc.Margin = new Padding(4, 0, 4, 0);
        lblEntryScheduledUtc.Name = "lblEntryScheduledUtc";
        lblEntryScheduledUtc.Size = new Size(143, 38);
        lblEntryScheduledUtc.TabIndex = 74;
        lblEntryScheduledUtc.Text = "Scheduled (UTC):";
        // 
        // pnlEntrySchedule
        // 
        pnlEntrySchedule.Controls.Add(dtpEntryScheduledUtc);
        pnlEntrySchedule.Controls.Add(chkEntryScheduledEnabled);
        pnlEntrySchedule.Dock = DockStyle.Fill;
        pnlEntrySchedule.Location = new Point(267, 2239);
        pnlEntrySchedule.Margin = new Padding(4, 5, 4, 5);
        pnlEntrySchedule.Name = "pnlEntrySchedule";
        pnlEntrySchedule.Size = new Size(268, 293);
        pnlEntrySchedule.TabIndex = 82;
        // 
        // dtpEntryScheduledUtc
        // 
        dtpEntryScheduledUtc.Enabled = false;
        dtpEntryScheduledUtc.Format = DateTimePickerFormat.Short;
        dtpEntryScheduledUtc.Location = new Point(37, 0);
        dtpEntryScheduledUtc.Margin = new Padding(4, 5, 4, 5);
        dtpEntryScheduledUtc.Name = "dtpEntryScheduledUtc";
        dtpEntryScheduledUtc.Size = new Size(241, 31);
        dtpEntryScheduledUtc.TabIndex = 1;
        // 
        // chkEntryScheduledEnabled
        // 
        chkEntryScheduledEnabled.Location = new Point(0, 3);
        chkEntryScheduledEnabled.Margin = new Padding(4, 5, 4, 5);
        chkEntryScheduledEnabled.Name = "chkEntryScheduledEnabled";
        chkEntryScheduledEnabled.Size = new Size(29, 33);
        chkEntryScheduledEnabled.TabIndex = 0;
        chkEntryScheduledEnabled.UseVisualStyleBackColor = true;
        // 
        // lblDeclaredCargoSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblDeclaredCargoSection, 2);
        lblDeclaredCargoSection.Location = new Point(10, 2537);
        lblDeclaredCargoSection.Margin = new Padding(4, 0, 4, 0);
        lblDeclaredCargoSection.Name = "lblDeclaredCargoSection";
        lblDeclaredCargoSection.Size = new Size(143, 38);
        lblDeclaredCargoSection.TabIndex = 83;
        lblDeclaredCargoSection.Text = "Declared Cargo";
        // 
        // pnlDeclaredCargoContainer
        // 
        tblEntryDetailLayout.SetColumnSpan(pnlDeclaredCargoContainer, 2);
        pnlDeclaredCargoContainer.Location = new Point(10, 2589);
        pnlDeclaredCargoContainer.Margin = new Padding(4, 5, 4, 5);
        pnlDeclaredCargoContainer.Name = "pnlDeclaredCargoContainer";
        pnlDeclaredCargoContainer.Size = new Size(525, 293);
        pnlDeclaredCargoContainer.TabIndex = 85;
        // 
        // lblActualCargoSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblActualCargoSection, 2);
        lblActualCargoSection.Location = new Point(10, 2887);
        lblActualCargoSection.Margin = new Padding(4, 0, 4, 0);
        lblActualCargoSection.Name = "lblActualCargoSection";
        lblActualCargoSection.Size = new Size(143, 38);
        lblActualCargoSection.TabIndex = 86;
        lblActualCargoSection.Text = "Actual Cargo";
        // 
        // pnlActualCargoContainer
        // 
        tblEntryDetailLayout.SetColumnSpan(pnlActualCargoContainer, 2);
        pnlActualCargoContainer.Location = new Point(10, 2939);
        pnlActualCargoContainer.Margin = new Padding(4, 5, 4, 5);
        pnlActualCargoContainer.Name = "pnlActualCargoContainer";
        pnlActualCargoContainer.Size = new Size(525, 260);
        pnlActualCargoContainer.TabIndex = 87;
        // 
        // lblDeclaredPassengersSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblDeclaredPassengersSection, 2);
        lblDeclaredPassengersSection.Location = new Point(10, 3204);
        lblDeclaredPassengersSection.Margin = new Padding(4, 0, 4, 0);
        lblDeclaredPassengersSection.Name = "lblDeclaredPassengersSection";
        lblDeclaredPassengersSection.Size = new Size(143, 38);
        lblDeclaredPassengersSection.TabIndex = 88;
        lblDeclaredPassengersSection.Text = "Declared Passengers";
        // 
        // pnlDeclaredPassengersContainer
        // 
        tblEntryDetailLayout.SetColumnSpan(pnlDeclaredPassengersContainer, 2);
        pnlDeclaredPassengersContainer.Location = new Point(10, 3256);
        pnlDeclaredPassengersContainer.Margin = new Padding(4, 5, 4, 5);
        pnlDeclaredPassengersContainer.Name = "pnlDeclaredPassengersContainer";
        pnlDeclaredPassengersContainer.Size = new Size(525, 260);
        pnlDeclaredPassengersContainer.TabIndex = 89;
        // 
        // lblActualPassengersSection
        // 
        tblEntryDetailLayout.SetColumnSpan(lblActualPassengersSection, 2);
        lblActualPassengersSection.Location = new Point(10, 3521);
        lblActualPassengersSection.Margin = new Padding(4, 0, 4, 0);
        lblActualPassengersSection.Name = "lblActualPassengersSection";
        lblActualPassengersSection.Size = new Size(143, 20);
        lblActualPassengersSection.TabIndex = 90;
        lblActualPassengersSection.Text = "Actual Passengers";
        // 
        // pnlActualPassengersContainer
        // 
        tblEntryDetailLayout.SetColumnSpan(pnlActualPassengersContainer, 2);
        pnlActualPassengersContainer.Location = new Point(10, 3546);
        pnlActualPassengersContainer.Margin = new Padding(4, 5, 4, 5);
        pnlActualPassengersContainer.Name = "pnlActualPassengersContainer";
        pnlActualPassengersContainer.Size = new Size(525, 10);
        pnlActualPassengersContainer.TabIndex = 91;
        // 
        // flpValidationHints
        // 
        flpValidationHints.AutoSize = true;
        flpValidationHints.BackColor = Color.FromArgb(255, 252, 220);
        flpValidationHints.Dock = DockStyle.Top;
        flpValidationHints.FlowDirection = FlowDirection.TopDown;
        flpValidationHints.Location = new Point(0, 0);
        flpValidationHints.Margin = new Padding(4, 5, 4, 5);
        flpValidationHints.Name = "flpValidationHints";
        flpValidationHints.Padding = new Padding(9, 7, 9, 7);
        flpValidationHints.Size = new Size(545, 14);
        flpValidationHints.TabIndex = 0;
        flpValidationHints.Visible = false;
        flpValidationHints.WrapContents = false;
        // 
        // gridDeclaredCargo
        // 
        gridDeclaredCargo.ColumnHeadersHeight = 34;
        gridDeclaredCargo.Location = new Point(0, 0);
        gridDeclaredCargo.Name = "gridDeclaredCargo";
        gridDeclaredCargo.RowHeadersWidth = 62;
        gridDeclaredCargo.Size = new Size(240, 150);
        gridDeclaredCargo.TabIndex = 0;
        // 
        // pnlDeclaredCargoActions
        // 
        pnlDeclaredCargoActions.Location = new Point(0, 0);
        pnlDeclaredCargoActions.Name = "pnlDeclaredCargoActions";
        pnlDeclaredCargoActions.Size = new Size(200, 100);
        pnlDeclaredCargoActions.TabIndex = 0;
        // 
        // btnDeclaredCargoDelete
        // 
        btnDeclaredCargoDelete.Location = new Point(0, 0);
        btnDeclaredCargoDelete.Name = "btnDeclaredCargoDelete";
        btnDeclaredCargoDelete.Size = new Size(75, 23);
        btnDeclaredCargoDelete.TabIndex = 0;
        // 
        // btnDeclaredCargoAdd
        // 
        btnDeclaredCargoAdd.Location = new Point(0, 0);
        btnDeclaredCargoAdd.Name = "btnDeclaredCargoAdd";
        btnDeclaredCargoAdd.Size = new Size(75, 23);
        btnDeclaredCargoAdd.TabIndex = 0;
        // 
        // gridActualCargo
        // 
        gridActualCargo.ColumnHeadersHeight = 34;
        gridActualCargo.Location = new Point(0, 0);
        gridActualCargo.Name = "gridActualCargo";
        gridActualCargo.RowHeadersWidth = 62;
        gridActualCargo.Size = new Size(240, 150);
        gridActualCargo.TabIndex = 0;
        // 
        // pnlActualCargoActions
        // 
        pnlActualCargoActions.Location = new Point(0, 0);
        pnlActualCargoActions.Name = "pnlActualCargoActions";
        pnlActualCargoActions.Size = new Size(200, 100);
        pnlActualCargoActions.TabIndex = 0;
        // 
        // btnActualCargoDelete
        // 
        btnActualCargoDelete.Location = new Point(0, 0);
        btnActualCargoDelete.Name = "btnActualCargoDelete";
        btnActualCargoDelete.Size = new Size(75, 23);
        btnActualCargoDelete.TabIndex = 0;
        // 
        // btnActualCargoAdd
        // 
        btnActualCargoAdd.Location = new Point(0, 0);
        btnActualCargoAdd.Name = "btnActualCargoAdd";
        btnActualCargoAdd.Size = new Size(75, 23);
        btnActualCargoAdd.TabIndex = 0;
        // 
        // gridDeclaredPassengers
        // 
        gridDeclaredPassengers.ColumnHeadersHeight = 34;
        gridDeclaredPassengers.Location = new Point(0, 0);
        gridDeclaredPassengers.Name = "gridDeclaredPassengers";
        gridDeclaredPassengers.RowHeadersWidth = 62;
        gridDeclaredPassengers.Size = new Size(240, 150);
        gridDeclaredPassengers.TabIndex = 0;
        // 
        // pnlDeclaredPassengersActions
        // 
        pnlDeclaredPassengersActions.Location = new Point(0, 0);
        pnlDeclaredPassengersActions.Name = "pnlDeclaredPassengersActions";
        pnlDeclaredPassengersActions.Size = new Size(200, 100);
        pnlDeclaredPassengersActions.TabIndex = 0;
        // 
        // btnDeclaredPassengerDelete
        // 
        btnDeclaredPassengerDelete.Location = new Point(0, 0);
        btnDeclaredPassengerDelete.Name = "btnDeclaredPassengerDelete";
        btnDeclaredPassengerDelete.Size = new Size(75, 23);
        btnDeclaredPassengerDelete.TabIndex = 0;
        // 
        // btnDeclaredPassengerAdd
        // 
        btnDeclaredPassengerAdd.Location = new Point(0, 0);
        btnDeclaredPassengerAdd.Name = "btnDeclaredPassengerAdd";
        btnDeclaredPassengerAdd.Size = new Size(75, 23);
        btnDeclaredPassengerAdd.TabIndex = 0;
        // 
        // gridActualPassengers
        // 
        gridActualPassengers.ColumnHeadersHeight = 34;
        gridActualPassengers.Location = new Point(0, 0);
        gridActualPassengers.Name = "gridActualPassengers";
        gridActualPassengers.RowHeadersWidth = 62;
        gridActualPassengers.Size = new Size(240, 150);
        gridActualPassengers.TabIndex = 0;
        // 
        // pnlActualPassengersActions
        // 
        pnlActualPassengersActions.Location = new Point(0, 0);
        pnlActualPassengersActions.Name = "pnlActualPassengersActions";
        pnlActualPassengersActions.Size = new Size(200, 100);
        pnlActualPassengersActions.TabIndex = 0;
        // 
        // btnActualPassengerDelete
        // 
        btnActualPassengerDelete.Location = new Point(0, 0);
        btnActualPassengerDelete.Name = "btnActualPassengerDelete";
        btnActualPassengerDelete.Size = new Size(75, 23);
        btnActualPassengerDelete.TabIndex = 0;
        // 
        // btnActualPassengerAdd
        // 
        btnActualPassengerAdd.Location = new Point(0, 0);
        btnActualPassengerAdd.Name = "btnActualPassengerAdd";
        btnActualPassengerAdd.Size = new Size(75, 23);
        btnActualPassengerAdd.TabIndex = 0;
        // 
        // ucEpisodeEntryDetail
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        Controls.Add(pnlScrollHost);
        Margin = new Padding(4, 5, 4, 5);
        Name = "ucEpisodeEntryDetail";
        Size = new Size(571, 1000);
        pnlScrollHost.ResumeLayout(false);
        pnlScrollHost.PerformLayout();
        tblEntryDetailLayout.ResumeLayout(false);
        tblEntryDetailLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numEntrySortOrder).EndInit();
        pnlEntryFlags.ResumeLayout(false);
        pnlEntryFlags.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numEntryRandomSeed).EndInit();
        pnlEntrySchedule.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDeclaredCargo).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridActualCargo).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridDeclaredPassengers).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridActualPassengers).EndInit();
        ResumeLayout(false);
    }

    private void ConfigureSectionLabel(Label label)
    {
        label.AutoSize = true;
        label.Dock = DockStyle.Fill;
        label.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label.ForeColor = SystemColors.ControlDarkDark;
        label.Padding = new Padding(0, 8, 0, 0);
        label.Size = new Size(386, 28);
        label.TabIndex = 0;
    }

    private void ConfigureFieldLabel(Label label)
    {
        label.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        label.AutoSize = true;
        label.Padding = new Padding(0, 6, 0, 0);
        label.Size = new Size(50, 31);
        label.TabIndex = 0;
    }

    private void ConfigureFillControl(Control control)
    {
        control.Dock = DockStyle.Fill;
        control.Margin = new Padding(3);
    }

    private void ConfigureManifestContainer(
        Panel container,
        DataGridView grid,
        Panel actionsPanel,
        Button deleteButton,
        Button addButton)
    {
        container.Controls.Add(grid);
        container.Controls.Add(actionsPanel);
        container.Dock = DockStyle.Fill;

        actionsPanel.Controls.Add(deleteButton);
        actionsPanel.Controls.Add(addButton);
        actionsPanel.Dock = DockStyle.Bottom;
        actionsPanel.Height = 28;
        actionsPanel.Padding = new Padding(2);

        deleteButton.Dock = DockStyle.Left;
        deleteButton.Size = new Size(60, 24);
        deleteButton.TabIndex = 0;
        deleteButton.Text = "Delete";
        deleteButton.UseVisualStyleBackColor = true;

        addButton.Dock = DockStyle.Left;
        addButton.Size = new Size(60, 24);
        addButton.TabIndex = 1;
        addButton.Text = "Add";
        addButton.UseVisualStyleBackColor = true;
        addButton.BringToFront();

        grid.AllowUserToAddRows = false;
        grid.AutoGenerateColumns = false;
        grid.ColumnHeadersHeight = 34;
        grid.Dock = DockStyle.Fill;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.DataError += (s, e) => e.Cancel = true;
    }

    private Panel pnlScrollHost = null!;
    private FlowLayoutPanel flpValidationHints = null!;
    private TableLayoutPanel tblEntryDetailLayout = null!;

    private Label lblEntrySection = null!;
    private Label lblEntryKind = null!;
    private Label lblEntrySourceType = null!;
    private Label lblEntryName = null!;
    private Label lblEntrySortOrder = null!;
    private Label lblEntryFlags = null!;
    private Label lblEntryRandomSeed = null!;
    private Label lblEntryNotes = null!;

    private Label lblOperationNoticeSection = null!;
    private Label lblEntryOperationType = null!;
    private Label lblEntryNoticeType = null!;

    private Label lblLocationSection = null!;
    private Label lblEntryStation = null!;
    private Label lblEntryDock = null!;
    private Label lblEntryOriginStation = null!;
    private Label lblEntryDestinationStation = null!;

    private Label lblVesselSection = null!;
    private Label lblEntryVessel = null!;
    private Label lblEntryVesselClassOverride = null!;
    private Label lblEntryRegistryOverride = null!;

    private Label lblPurposeSection = null!;
    private Label lblEntryDeclaredPurpose = null!;
    private Label lblEntryActualPurpose = null!;

    private Label lblStatusesSection = null!;
    private Label lblEntryManifestStatus = null!;
    private Label lblEntryInspectionStatus = null!;
    private Label lblEntryClearanceStatus = null!;
    private Label lblEntryEnvironmentalCondition = null!;

    private Label lblNarrativeSection = null!;
    private Label lblEntryDirective = null!;
    private Label lblEntryIncidentPhrase = null!;
    private Label lblEntryResolutionPhrase = null!;
    private Label lblEntryRouteStatusPhrase = null!;
    private Label lblEntryPublicBodyOverride = null!;

    private Label lblStoryThreadSection = null!;
    private Label lblEntryStoryThread = null!;
    private Label lblEntryAppliedStoryBeat = null!;
    private Label lblEntryAnomalySeverity = null!;

    private Label lblHiddenTruthSection = null!;
    private Label lblEntryHiddenTruthNotes = null!;

    private Label lblScheduleSection = null!;
    private Label lblEntryScheduledUtc = null!;

    private Label lblDeclaredCargoSection = null!;
    private Label lblActualCargoSection = null!;
    private Label lblDeclaredPassengersSection = null!;
    private Label lblActualPassengersSection = null!;

    private ComboBox cboEntryKind = null!;
    private ComboBox cboEntrySourceType = null!;
    private TextBox txtEntryName = null!;
    private NumericUpDown numEntrySortOrder = null!;
    private Panel pnlEntryFlags = null!;
    private CheckBox chkEntryLocked = null!;
    private CheckBox chkEntryCanon = null!;
    private NumericUpDown numEntryRandomSeed = null!;
    private TextBox txtEntryNotes = null!;

    private ComboBox cboEntryOperationType = null!;
    private ComboBox cboEntryNoticeType = null!;

    private ComboBox cboEntryStation = null!;
    private ComboBox cboEntryDock = null!;
    private ComboBox cboEntryOriginStation = null!;
    private ComboBox cboEntryDestinationStation = null!;

    private ComboBox cboEntryVessel = null!;
    private ComboBox cboEntryVesselClassOverride = null!;
    private TextBox txtEntryRegistryOverride = null!;

    private ComboBox cboEntryDeclaredPurpose = null!;
    private ComboBox cboEntryActualPurpose = null!;

    private ComboBox cboEntryManifestStatus = null!;
    private ComboBox cboEntryInspectionStatus = null!;
    private ComboBox cboEntryClearanceStatus = null!;
    private ComboBox cboEntryEnvironmentalCondition = null!;

    private ComboBox cboEntryDirective = null!;
    private ComboBox cboEntryIncidentPhrase = null!;
    private ComboBox cboEntryResolutionPhrase = null!;
    private ComboBox cboEntryRouteStatusPhrase = null!;
    private TextBox txtEntryPublicBodyOverride = null!;

    private ComboBox cboEntryStoryThread = null!;
    private ComboBox cboEntryAppliedStoryBeat = null!;
    private ComboBox cboEntryAnomalySeverity = null!;

    private TextBox txtEntryHiddenTruthNotes = null!;

    private Panel pnlEntrySchedule = null!;
    private CheckBox chkEntryScheduledEnabled = null!;
    private DateTimePicker dtpEntryScheduledUtc = null!;

    private Panel pnlDeclaredCargoContainer = null!;
    private DataGridView gridDeclaredCargo = null!;
    private Panel pnlDeclaredCargoActions = null!;
    private Button btnDeclaredCargoDelete = null!;
    private Button btnDeclaredCargoAdd = null!;

    private Panel pnlActualCargoContainer = null!;
    private DataGridView gridActualCargo = null!;
    private Panel pnlActualCargoActions = null!;
    private Button btnActualCargoDelete = null!;
    private Button btnActualCargoAdd = null!;

    private Panel pnlDeclaredPassengersContainer = null!;
    private DataGridView gridDeclaredPassengers = null!;
    private Panel pnlDeclaredPassengersActions = null!;
    private Button btnDeclaredPassengerDelete = null!;
    private Button btnDeclaredPassengerAdd = null!;

    private Panel pnlActualPassengersContainer = null!;
    private DataGridView gridActualPassengers = null!;
    private Panel pnlActualPassengersActions = null!;
    private Button btnActualPassengerDelete = null!;
    private Button btnActualPassengerAdd = null!;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\Episodes\ucEpisodeMetaEditor.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls.Episodes;

/// <summary>
/// UserControl that hosts the scrollable episode/series metadata editing panel.
/// Layout is defined in the Designer file; this class only exposes the controls
/// needed by the parent editor.
/// </summary>
public partial class ucEpisodeMetaEditor : UserControl
{
    public ucEpisodeMetaEditor()
    {
        InitializeComponent();
    }

    // Episode fields
    public TextBox TxtEpisodeName => txtEpisodeName;
    public CheckBox ChkEpisodeHasInUniverseDate => chkEpisodeHasInUniverseDate;
    public DateTimePicker DtpEpisodeInUniverseUtc => dtpEpisodeInUniverseUtc;
    public ComboBox CboEpisodeBroadcastStation => cboEpisodeBroadcastStation;
    public ComboBox CboEpisodeSeries => cboEpisodeSeries;
    public CheckBox ChkEpisodeCanonicalLocked => chkEpisodeCanonicalLocked;
    public TextBox TxtEpisodeNotes => txtEpisodeNotes;

    // Series fields
    public TextBox TxtSeriesName => txtSeriesName;
    public ComboBox CboSeriesBroadcastStation => cboSeriesBroadcastStation;
    public TextBox TxtSeriesNotes => txtSeriesNotes;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\Episodes\ucEpisodeMetaEditor.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls.Episodes;

partial class ucEpisodeMetaEditor
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
        tblMetadataLayout = new TableLayoutPanel();
        lblEpisodeSection = new Label();
        lblEpisodeName = new Label();
        txtEpisodeName = new TextBox();
        lblEpisodeDate = new Label();
        pnlEpisodeDate = new Panel();
        dtpEpisodeInUniverseUtc = new DateTimePicker();
        chkEpisodeHasInUniverseDate = new CheckBox();
        lblEpisodeStation = new Label();
        cboEpisodeBroadcastStation = new ComboBox();
        lblEpisodeSeries = new Label();
        cboEpisodeSeries = new ComboBox();
        lblEpisodeCanonLock = new Label();
        chkEpisodeCanonicalLocked = new CheckBox();
        lblEpisodeNotes = new Label();
        txtEpisodeNotes = new TextBox();
        lblSeriesSection = new Label();
        lblSeriesName = new Label();
        txtSeriesName = new TextBox();
        lblSeriesStation = new Label();
        cboSeriesBroadcastStation = new ComboBox();
        lblSeriesNotes = new Label();
        txtSeriesNotes = new TextBox();
        tblMetadataLayout.SuspendLayout();
        pnlEpisodeDate.SuspendLayout();
        SuspendLayout();
        // 
        // tblMetadataLayout
        // 
        tblMetadataLayout.AutoSize = true;
        tblMetadataLayout.ColumnCount = 2;
        tblMetadataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
        tblMetadataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblMetadataLayout.Controls.Add(lblEpisodeSection, 0, 0);
        tblMetadataLayout.Controls.Add(lblEpisodeName, 0, 1);
        tblMetadataLayout.Controls.Add(txtEpisodeName, 1, 1);
        tblMetadataLayout.Controls.Add(lblEpisodeDate, 0, 2);
        tblMetadataLayout.Controls.Add(pnlEpisodeDate, 1, 2);
        tblMetadataLayout.Controls.Add(lblEpisodeStation, 0, 3);
        tblMetadataLayout.Controls.Add(cboEpisodeBroadcastStation, 1, 3);
        tblMetadataLayout.Controls.Add(lblEpisodeSeries, 0, 4);
        tblMetadataLayout.Controls.Add(cboEpisodeSeries, 1, 4);
        tblMetadataLayout.Controls.Add(lblEpisodeCanonLock, 0, 5);
        tblMetadataLayout.Controls.Add(chkEpisodeCanonicalLocked, 1, 5);
        tblMetadataLayout.Controls.Add(lblEpisodeNotes, 0, 6);
        tblMetadataLayout.Controls.Add(txtEpisodeNotes, 1, 6);
        tblMetadataLayout.Controls.Add(lblSeriesSection, 0, 7);
        tblMetadataLayout.Controls.Add(lblSeriesName, 0, 8);
        tblMetadataLayout.Controls.Add(txtSeriesName, 1, 8);
        tblMetadataLayout.Controls.Add(lblSeriesStation, 0, 9);
        tblMetadataLayout.Controls.Add(cboSeriesBroadcastStation, 1, 9);
        tblMetadataLayout.Controls.Add(lblSeriesNotes, 0, 10);
        tblMetadataLayout.Controls.Add(txtSeriesNotes, 1, 10);
        tblMetadataLayout.Dock = DockStyle.Fill;
        tblMetadataLayout.Location = new Point(0, 0);
        tblMetadataLayout.Margin = new Padding(4, 5, 4, 5);
        tblMetadataLayout.Name = "tblMetadataLayout";
        tblMetadataLayout.Padding = new Padding(6, 7, 6, 10);
        tblMetadataLayout.RowCount = 11;
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tblMetadataLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
        tblMetadataLayout.Size = new Size(429, 595);
        tblMetadataLayout.TabIndex = 0;
        // 
        // lblEpisodeSection
        // 
        lblEpisodeSection.AutoSize = true;
        tblMetadataLayout.SetColumnSpan(lblEpisodeSection, 2);
        lblEpisodeSection.Dock = DockStyle.Fill;
        lblEpisodeSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblEpisodeSection.ForeColor = SystemColors.ControlDarkDark;
        lblEpisodeSection.Location = new Point(10, 7);
        lblEpisodeSection.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeSection.Name = "lblEpisodeSection";
        lblEpisodeSection.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeSection.Size = new Size(409, 40);
        lblEpisodeSection.TabIndex = 0;
        lblEpisodeSection.Text = "Episode";
        // 
        // lblEpisodeName
        // 
        lblEpisodeName.AutoSize = true;
        lblEpisodeName.Location = new Point(10, 47);
        lblEpisodeName.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeName.Name = "lblEpisodeName";
        lblEpisodeName.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeName.Size = new Size(63, 33);
        lblEpisodeName.TabIndex = 1;
        lblEpisodeName.Text = "Name:";
        // 
        // txtEpisodeName
        // 
        txtEpisodeName.Dock = DockStyle.Fill;
        txtEpisodeName.Location = new Point(147, 52);
        txtEpisodeName.Margin = new Padding(4, 5, 4, 5);
        txtEpisodeName.Name = "txtEpisodeName";
        txtEpisodeName.Size = new Size(272, 31);
        txtEpisodeName.TabIndex = 2;
        // 
        // lblEpisodeDate
        // 
        lblEpisodeDate.AutoSize = true;
        lblEpisodeDate.Location = new Point(10, 94);
        lblEpisodeDate.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeDate.Name = "lblEpisodeDate";
        lblEpisodeDate.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeDate.Size = new Size(99, 33);
        lblEpisodeDate.TabIndex = 3;
        lblEpisodeDate.Text = "Date (UTC):";
        // 
        // pnlEpisodeDate
        // 
        pnlEpisodeDate.Controls.Add(dtpEpisodeInUniverseUtc);
        pnlEpisodeDate.Controls.Add(chkEpisodeHasInUniverseDate);
        pnlEpisodeDate.Dock = DockStyle.Fill;
        pnlEpisodeDate.Location = new Point(147, 99);
        pnlEpisodeDate.Margin = new Padding(4, 5, 4, 5);
        pnlEpisodeDate.Name = "pnlEpisodeDate";
        pnlEpisodeDate.Size = new Size(272, 37);
        pnlEpisodeDate.TabIndex = 4;
        // 
        // dtpEpisodeInUniverseUtc
        // 
        dtpEpisodeInUniverseUtc.Enabled = false;
        dtpEpisodeInUniverseUtc.Format = DateTimePickerFormat.Short;
        dtpEpisodeInUniverseUtc.Location = new Point(34, 0);
        dtpEpisodeInUniverseUtc.Margin = new Padding(4, 5, 4, 5);
        dtpEpisodeInUniverseUtc.Name = "dtpEpisodeInUniverseUtc";
        dtpEpisodeInUniverseUtc.Size = new Size(184, 31);
        dtpEpisodeInUniverseUtc.TabIndex = 1;
        // 
        // chkEpisodeHasInUniverseDate
        // 
        chkEpisodeHasInUniverseDate.Location = new Point(0, 3);
        chkEpisodeHasInUniverseDate.Margin = new Padding(4, 5, 4, 5);
        chkEpisodeHasInUniverseDate.Name = "chkEpisodeHasInUniverseDate";
        chkEpisodeHasInUniverseDate.Size = new Size(29, 33);
        chkEpisodeHasInUniverseDate.TabIndex = 0;
        chkEpisodeHasInUniverseDate.UseVisualStyleBackColor = true;
        // 
        // lblEpisodeStation
        // 
        lblEpisodeStation.AutoSize = true;
        lblEpisodeStation.Location = new Point(10, 141);
        lblEpisodeStation.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeStation.Name = "lblEpisodeStation";
        lblEpisodeStation.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeStation.Size = new Size(71, 33);
        lblEpisodeStation.TabIndex = 5;
        lblEpisodeStation.Text = "Station:";
        // 
        // cboEpisodeBroadcastStation
        // 
        cboEpisodeBroadcastStation.Dock = DockStyle.Fill;
        cboEpisodeBroadcastStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEpisodeBroadcastStation.FormattingEnabled = true;
        cboEpisodeBroadcastStation.Location = new Point(147, 146);
        cboEpisodeBroadcastStation.Margin = new Padding(4, 5, 4, 5);
        cboEpisodeBroadcastStation.Name = "cboEpisodeBroadcastStation";
        cboEpisodeBroadcastStation.Size = new Size(272, 33);
        cboEpisodeBroadcastStation.TabIndex = 6;
        // 
        // lblEpisodeSeries
        // 
        lblEpisodeSeries.AutoSize = true;
        lblEpisodeSeries.Location = new Point(10, 188);
        lblEpisodeSeries.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeSeries.Name = "lblEpisodeSeries";
        lblEpisodeSeries.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeSeries.Size = new Size(62, 33);
        lblEpisodeSeries.TabIndex = 7;
        lblEpisodeSeries.Text = "Series:";
        // 
        // cboEpisodeSeries
        // 
        cboEpisodeSeries.Dock = DockStyle.Fill;
        cboEpisodeSeries.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEpisodeSeries.FormattingEnabled = true;
        cboEpisodeSeries.Location = new Point(147, 193);
        cboEpisodeSeries.Margin = new Padding(4, 5, 4, 5);
        cboEpisodeSeries.Name = "cboEpisodeSeries";
        cboEpisodeSeries.Size = new Size(272, 33);
        cboEpisodeSeries.TabIndex = 8;
        // 
        // lblEpisodeCanonLock
        // 
        lblEpisodeCanonLock.AutoSize = true;
        lblEpisodeCanonLock.Location = new Point(10, 235);
        lblEpisodeCanonLock.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeCanonLock.Name = "lblEpisodeCanonLock";
        lblEpisodeCanonLock.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeCanonLock.Size = new Size(0, 33);
        lblEpisodeCanonLock.TabIndex = 9;
        // 
        // chkEpisodeCanonicalLocked
        // 
        chkEpisodeCanonicalLocked.AutoCheck = false;
        chkEpisodeCanonicalLocked.Location = new Point(147, 240);
        chkEpisodeCanonicalLocked.Margin = new Padding(4, 5, 4, 5);
        chkEpisodeCanonicalLocked.Name = "chkEpisodeCanonicalLocked";
        chkEpisodeCanonicalLocked.Size = new Size(271, 55);
        chkEpisodeCanonicalLocked.TabIndex = 10;
        chkEpisodeCanonicalLocked.Text = "Canon Locked (use Lock/Unlock buttons)";
        chkEpisodeCanonicalLocked.UseVisualStyleBackColor = true;
        // 
        // lblEpisodeNotes
        // 
        lblEpisodeNotes.AutoSize = true;
        lblEpisodeNotes.Location = new Point(10, 300);
        lblEpisodeNotes.Margin = new Padding(4, 0, 4, 0);
        lblEpisodeNotes.Name = "lblEpisodeNotes";
        lblEpisodeNotes.Padding = new Padding(0, 8, 0, 0);
        lblEpisodeNotes.Size = new Size(63, 33);
        lblEpisodeNotes.TabIndex = 11;
        lblEpisodeNotes.Text = "Notes:";
        // 
        // txtEpisodeNotes
        // 
        txtEpisodeNotes.Dock = DockStyle.Fill;
        txtEpisodeNotes.Location = new Point(147, 305);
        txtEpisodeNotes.Margin = new Padding(4, 5, 4, 5);
        txtEpisodeNotes.Multiline = true;
        txtEpisodeNotes.Name = "txtEpisodeNotes";
        txtEpisodeNotes.ScrollBars = ScrollBars.Vertical;
        txtEpisodeNotes.Size = new Size(272, 59);
        txtEpisodeNotes.TabIndex = 12;
        // 
        // lblSeriesSection
        // 
        lblSeriesSection.AutoSize = true;
        tblMetadataLayout.SetColumnSpan(lblSeriesSection, 2);
        lblSeriesSection.Dock = DockStyle.Fill;
        lblSeriesSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSeriesSection.ForeColor = SystemColors.ControlDarkDark;
        lblSeriesSection.Location = new Point(10, 369);
        lblSeriesSection.Margin = new Padding(4, 0, 4, 0);
        lblSeriesSection.Name = "lblSeriesSection";
        lblSeriesSection.Padding = new Padding(0, 8, 0, 0);
        lblSeriesSection.Size = new Size(409, 40);
        lblSeriesSection.TabIndex = 13;
        lblSeriesSection.Text = "Series";
        // 
        // lblSeriesName
        // 
        lblSeriesName.AutoSize = true;
        lblSeriesName.Location = new Point(10, 409);
        lblSeriesName.Margin = new Padding(4, 0, 4, 0);
        lblSeriesName.Name = "lblSeriesName";
        lblSeriesName.Padding = new Padding(0, 8, 0, 0);
        lblSeriesName.Size = new Size(63, 33);
        lblSeriesName.TabIndex = 14;
        lblSeriesName.Text = "Name:";
        // 
        // txtSeriesName
        // 
        txtSeriesName.Dock = DockStyle.Fill;
        txtSeriesName.Location = new Point(147, 414);
        txtSeriesName.Margin = new Padding(4, 5, 4, 5);
        txtSeriesName.Name = "txtSeriesName";
        txtSeriesName.Size = new Size(272, 31);
        txtSeriesName.TabIndex = 15;
        // 
        // lblSeriesStation
        // 
        lblSeriesStation.AutoSize = true;
        lblSeriesStation.Location = new Point(10, 456);
        lblSeriesStation.Margin = new Padding(4, 0, 4, 0);
        lblSeriesStation.Name = "lblSeriesStation";
        lblSeriesStation.Padding = new Padding(0, 8, 0, 0);
        lblSeriesStation.Size = new Size(71, 33);
        lblSeriesStation.TabIndex = 16;
        lblSeriesStation.Text = "Station:";
        // 
        // cboSeriesBroadcastStation
        // 
        cboSeriesBroadcastStation.Dock = DockStyle.Fill;
        cboSeriesBroadcastStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSeriesBroadcastStation.FormattingEnabled = true;
        cboSeriesBroadcastStation.Location = new Point(147, 461);
        cboSeriesBroadcastStation.Margin = new Padding(4, 5, 4, 5);
        cboSeriesBroadcastStation.Name = "cboSeriesBroadcastStation";
        cboSeriesBroadcastStation.Size = new Size(272, 33);
        cboSeriesBroadcastStation.TabIndex = 17;
        // 
        // lblSeriesNotes
        // 
        lblSeriesNotes.AutoSize = true;
        lblSeriesNotes.Location = new Point(10, 503);
        lblSeriesNotes.Margin = new Padding(4, 0, 4, 0);
        lblSeriesNotes.Name = "lblSeriesNotes";
        lblSeriesNotes.Padding = new Padding(0, 8, 0, 0);
        lblSeriesNotes.Size = new Size(63, 33);
        lblSeriesNotes.TabIndex = 18;
        lblSeriesNotes.Text = "Notes:";
        // 
        // txtSeriesNotes
        // 
        txtSeriesNotes.Dock = DockStyle.Fill;
        txtSeriesNotes.Location = new Point(147, 508);
        txtSeriesNotes.Margin = new Padding(4, 5, 4, 5);
        txtSeriesNotes.Multiline = true;
        txtSeriesNotes.Name = "txtSeriesNotes";
        txtSeriesNotes.ScrollBars = ScrollBars.Vertical;
        txtSeriesNotes.Size = new Size(272, 77);
        txtSeriesNotes.TabIndex = 19;
        // 
        // ucEpisodeMetaEditor
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        Controls.Add(tblMetadataLayout);
        Margin = new Padding(4, 5, 4, 5);
        Name = "ucEpisodeMetaEditor";
        Size = new Size(429, 595);
        tblMetadataLayout.ResumeLayout(false);
        tblMetadataLayout.PerformLayout();
        pnlEpisodeDate.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private TableLayoutPanel tblMetadataLayout = null!;
    private Label lblEpisodeSection = null!;
    private Label lblSeriesSection = null!;

    private Label lblEpisodeName = null!;
    private Label lblEpisodeDate = null!;
    private Label lblEpisodeStation = null!;
    private Label lblEpisodeSeries = null!;
    private Label lblEpisodeCanonLock = null!;
    private Label lblEpisodeNotes = null!;

    private Label lblSeriesName = null!;
    private Label lblSeriesStation = null!;
    private Label lblSeriesNotes = null!;

    private Panel pnlEpisodeDate = null!;

    private TextBox txtEpisodeName = null!;
    private CheckBox chkEpisodeHasInUniverseDate = null!;
    private DateTimePicker dtpEpisodeInUniverseUtc = null!;
    private ComboBox cboEpisodeBroadcastStation = null!;
    private ComboBox cboEpisodeSeries = null!;
    private CheckBox chkEpisodeCanonicalLocked = null!;
    private TextBox txtEpisodeNotes = null!;

    private TextBox txtSeriesName = null!;
    private ComboBox cboSeriesBroadcastStation = null!;
    private TextBox txtSeriesNotes = null!;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\Episodes\ucEpisodes.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls.Episodes;

/// <summary>
/// UserControl for the Episodes tab.
/// Hosts the full episodes/series/entry editing UI.
/// Public properties expose all controls referenced by MainForm so that
/// MainForm can own all behaviour without this control needing any project
/// or service references.
/// Entry-detail controls are forwarded through ucEntryDetail (ucEpisodeEntryDetail).
/// Episode/series meta controls are forwarded through ucMetaEditor (ucEpisodeMetaEditor).
/// </summary>
public partial class ucEpisodes : UserControl
{
    public ucEpisodes()
    {
        InitializeComponent();
    }

    // â”€â”€ Lists â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ListBox LstSeries => lstSeries;
    public ListBox LstEpisodes => lstEpisodes;

    // â”€â”€ Series buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnSeriesAdd => btnSeriesAdd;
    public Button BtnSeriesDelete => btnSeriesDelete;
    public Button BtnSeriesDuplicate => btnSeriesDuplicate;

    // â”€â”€ Episode search / summary â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtEpisodeSearch => txtEpisodeSearch;
    public TextBox TxtEpisodeSummary => txtEpisodeSummary;

    // â”€â”€ Episode buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnEpisodeAdd => btnEpisodeAdd;
    public Button BtnEpisodeDelete => btnEpisodeDelete;
    public Button BtnEpisodeDuplicate => btnEpisodeDuplicate;
    public Button BtnNewEpisodeAfterSelected => btnNewEpisodeAfterSelected;
    public Button BtnLockEpisodeCanon => btnLockEpisodeCanon;
    public Button BtnUnlockEpisodeCanon => btnUnlockEpisodeCanon;
    public Button BtnEpisodeMoveUp => btnEpisodeMoveUp;
    public Button BtnEpisodeMoveDown => btnEpisodeMoveDown;

    // â”€â”€ Entry grid â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public DataGridView GridEpisodeEntries => gridEpisodeEntries;

    // â”€â”€ Entry filter controls â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtEntrySearch => txtEntrySearch;
    public ComboBox CboEntryFilterKind => cboEntryFilterKind;
    public ComboBox CboEntryFilterVessel => cboEntryFilterVessel;
    public ComboBox CboEntryFilterStation => cboEntryFilterStation;
    public CheckBox ChkShowLockedOnly => chkShowLockedOnly;
    public Button BtnClearEntryFilters => btnClearEntryFilters;

    // â”€â”€ Entry management buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnEntryAdd => btnEntryAdd;
    public Button BtnNoticeEntryAdd => btnNoticeEntryAdd;
    public Button BtnEntryDuplicate => btnEntryDuplicate;
    public Button BtnEntryDelete => btnEntryDelete;
    public Button BtnEntryMoveUp => btnEntryMoveUp;
    public Button BtnEntryMoveDown => btnEntryMoveDown;

    // â”€â”€ Generation controls â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnGenerateEntry => btnGenerateEntry;
    public Button BtnGenerateEpisodeEntries => btnGenerateEpisodeEntries;
    public Button BtnRegenerateSelectedEntry => btnRegenerateSelectedEntry;
    public NumericUpDown NumGenerateEntryCount => numGenerateEntryCount;
    public CheckBox ChkClearEpisodeBeforeGenerate => chkClearEpisodeBeforeGenerate;
    public CheckBox ChkRegenerateWithoutAdvancingThread => chkRegenerateWithoutAdvancingThread;
    public TextBox TxtGenerationSeed => txtGenerationSeed;

    // â”€â”€ Export controls â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnExportEpisodeText => btnExportEpisodeText;
    public Button BtnExportEpisodeTts => btnExportEpisodeTts;
    public Button BtnExportEpisodeJson => btnExportEpisodeJson;
    public CheckBox ChkExportIncludeHeader => chkExportIncludeHeader;
    public CheckBox ChkExportBlankLineBetweenEntries => chkExportBlankLineBetweenEntries;
    public CheckBox ChkExportIncludeEntryMarkers => chkExportIncludeEntryMarkers;
    public CheckBox ChkExportAuthorDebugMode => chkExportAuthorDebugMode;

    // â”€â”€ Preview / thread summary â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtEpisodeEntryPreview => txtEpisodeEntryPreview;
    public TextBox TxtThreadSummary => txtThreadSummary;

    // â”€â”€ Entry detail panel (child UC) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Control PnlEntryDetail => ucEntryDetail;
    public FlowLayoutPanel FlpValidationHints => ucEntryDetail.FlpValidationHints;

    // â”€â”€ Entry fields: structural â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryKind => ucEntryDetail.CboEntryKind;
    public ComboBox CboEntrySourceType => ucEntryDetail.CboEntrySourceType;
    public TextBox TxtEntryName => ucEntryDetail.TxtEntryName;
    public NumericUpDown NumEntrySortOrder => ucEntryDetail.NumEntrySortOrder;
    public CheckBox ChkEntryLocked => ucEntryDetail.ChkEntryLocked;
    public CheckBox ChkEntryCanon => ucEntryDetail.ChkEntryCanon;
    public NumericUpDown NumEntryRandomSeed => ucEntryDetail.NumEntryRandomSeed;
    public TextBox TxtEntryNotes => ucEntryDetail.TxtEntryNotes;

    // â”€â”€ Entry fields: operation / notice â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryOperationType => ucEntryDetail.CboEntryOperationType;
    public ComboBox CboEntryNoticeType => ucEntryDetail.CboEntryNoticeType;

    // â”€â”€ Entry fields: location â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryStation => ucEntryDetail.CboEntryStation;
    public ComboBox CboEntryDock => ucEntryDetail.CboEntryDock;
    public ComboBox CboEntryOriginStation => ucEntryDetail.CboEntryOriginStation;
    public ComboBox CboEntryDestinationStation => ucEntryDetail.CboEntryDestinationStation;

    // â”€â”€ Entry fields: vessel â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryVessel => ucEntryDetail.CboEntryVessel;
    public ComboBox CboEntryVesselClassOverride => ucEntryDetail.CboEntryVesselClassOverride;
    public TextBox TxtEntryRegistryOverride => ucEntryDetail.TxtEntryRegistryOverride;

    // â”€â”€ Entry fields: purpose â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryDeclaredPurpose => ucEntryDetail.CboEntryDeclaredPurpose;
    public ComboBox CboEntryActualPurpose => ucEntryDetail.CboEntryActualPurpose;

    // â”€â”€ Entry fields: statuses â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryManifestStatus => ucEntryDetail.CboEntryManifestStatus;
    public ComboBox CboEntryInspectionStatus => ucEntryDetail.CboEntryInspectionStatus;
    public ComboBox CboEntryClearanceStatus => ucEntryDetail.CboEntryClearanceStatus;
    public ComboBox CboEntryEnvironmentalCondition => ucEntryDetail.CboEntryEnvironmentalCondition;

    // â”€â”€ Entry fields: narrative â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryDirective => ucEntryDetail.CboEntryDirective;
    public ComboBox CboEntryIncidentPhrase => ucEntryDetail.CboEntryIncidentPhrase;
    public ComboBox CboEntryResolutionPhrase => ucEntryDetail.CboEntryResolutionPhrase;
    public ComboBox CboEntryRouteStatusPhrase => ucEntryDetail.CboEntryRouteStatusPhrase;
    public TextBox TxtEntryPublicBodyOverride => ucEntryDetail.TxtEntryPublicBodyOverride;

    // â”€â”€ Entry fields: story thread â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public ComboBox CboEntryStoryThread => ucEntryDetail.CboEntryStoryThread;
    public ComboBox CboEntryAppliedStoryBeat => ucEntryDetail.CboEntryAppliedStoryBeat;
    public ComboBox CboEntryAnomalySeverity => ucEntryDetail.CboEntryAnomalySeverity;

    // â”€â”€ Entry fields: hidden truth â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtEntryHiddenTruthNotes => ucEntryDetail.TxtEntryHiddenTruthNotes;

    // â”€â”€ Entry fields: schedule â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public CheckBox ChkEntryScheduledEnabled => ucEntryDetail.ChkEntryScheduledEnabled;
    public DateTimePicker DtpEntryScheduledUtc => ucEntryDetail.DtpEntryScheduledUtc;

    // â”€â”€ Manifest grids â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public DataGridView GridDeclaredCargo => ucEntryDetail.GridDeclaredCargo;
    public DataGridView GridActualCargo => ucEntryDetail.GridActualCargo;
    public DataGridView GridDeclaredPassengers => ucEntryDetail.GridDeclaredPassengers;
    public DataGridView GridActualPassengers => ucEntryDetail.GridActualPassengers;

    // â”€â”€ Manifest grid buttons â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Button BtnDeclaredCargoAdd => ucEntryDetail.BtnDeclaredCargoAdd;
    public Button BtnDeclaredCargoDelete => ucEntryDetail.BtnDeclaredCargoDelete;
    public Button BtnActualCargoAdd => ucEntryDetail.BtnActualCargoAdd;
    public Button BtnActualCargoDelete => ucEntryDetail.BtnActualCargoDelete;
    public Button BtnDeclaredPassengerAdd => ucEntryDetail.BtnDeclaredPassengerAdd;
    public Button BtnDeclaredPassengerDelete => ucEntryDetail.BtnDeclaredPassengerDelete;
    public Button BtnActualPassengerAdd => ucEntryDetail.BtnActualPassengerAdd;
    public Button BtnActualPassengerDelete => ucEntryDetail.BtnActualPassengerDelete;

    // â”€â”€ Episode metadata editor panel (child UC) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Control PnlEpisodeMetaEditor => ucMetaEditor;

    // â”€â”€ Episode fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtEpisodeName => ucMetaEditor.TxtEpisodeName;
    public CheckBox ChkEpisodeHasInUniverseDate => ucMetaEditor.ChkEpisodeHasInUniverseDate;
    public DateTimePicker DtpEpisodeInUniverseUtc => ucMetaEditor.DtpEpisodeInUniverseUtc;
    public ComboBox CboEpisodeBroadcastStation => ucMetaEditor.CboEpisodeBroadcastStation;
    public ComboBox CboEpisodeSeries => ucMetaEditor.CboEpisodeSeries;
    public CheckBox ChkEpisodeCanonicalLocked => ucMetaEditor.ChkEpisodeCanonicalLocked;
    public TextBox TxtEpisodeNotes => ucMetaEditor.TxtEpisodeNotes;

    // â”€â”€ Series fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public TextBox TxtSeriesName => ucMetaEditor.TxtSeriesName;
    public ComboBox CboSeriesBroadcastStation => ucMetaEditor.CboSeriesBroadcastStation;
    public TextBox TxtSeriesNotes => ucMetaEditor.TxtSeriesNotes;
}

```n---


### File: PodcastUniverseEditor\UI\Controls\Episodes\ucEpisodes.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Controls.Episodes;

partial class ucEpisodes
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
        splitEpisodesMain = new SplitContainer();
        splitSeriesEpisodes = new SplitContainer();
        pnlSeriesSection = new Panel();
        lstSeries = new ListBox();
        pnlSeriesActions = new Panel();
        btnSeriesDuplicate = new Button();
        btnSeriesDelete = new Button();
        btnSeriesAdd = new Button();
        lblSeries = new Label();
        pnlEpisodeSection = new Panel();
        lstEpisodes = new ListBox();
        pnlEpisodeActions = new Panel();
        btnEpisodeMoveDown = new Button();
        btnEpisodeMoveUp = new Button();
        btnEpisodeDuplicate = new Button();
        btnNewEpisodeAfterSelected = new Button();
        btnLockEpisodeCanon = new Button();
        btnUnlockEpisodeCanon = new Button();
        btnEpisodeDelete = new Button();
        btnEpisodeAdd = new Button();
        txtEpisodeSummary = new TextBox();
        ucMetaEditor = new ucEpisodeMetaEditor();
        txtEpisodeSearch = new TextBox();
        lblEpisodes = new Label();
        splitEpisodeWorkspace = new SplitContainer();
        pnlEntryListSection = new Panel();
        gridEpisodeEntries = new DataGridView();
        pnlEntryToolRows = new Panel();
        pnlEntryExportTools = new Panel();
        btnExportEpisodeText = new Button();
        btnExportEpisodeTts = new Button();
        btnExportEpisodeJson = new Button();
        chkExportIncludeHeader = new CheckBox();
        chkExportBlankLineBetweenEntries = new CheckBox();
        chkExportIncludeEntryMarkers = new CheckBox();
        chkExportAuthorDebugMode = new CheckBox();
        pnlEntryGenerationTools = new Panel();
        btnGenerateEntry = new Button();
        btnGenerateEpisodeEntries = new Button();
        btnRegenerateSelectedEntry = new Button();
        numGenerateEntryCount = new NumericUpDown();
        chkClearEpisodeBeforeGenerate = new CheckBox();
        lblGenerationSeed = new Label();
        txtGenerationSeed = new TextBox();
        chkRegenerateWithoutAdvancingThread = new CheckBox();
        pnlEntryListActions = new Panel();
        btnEntryMoveDown = new Button();
        btnEntryMoveUp = new Button();
        btnEntryDelete = new Button();
        btnEntryDuplicate = new Button();
        btnNoticeEntryAdd = new Button();
        btnEntryAdd = new Button();
        pnlEntryFilters = new Panel();
        pnlEntryFilterSecondaryRow = new Panel();
        cboEntryFilterVessel = new ComboBox();
        cboEntryFilterStation = new ComboBox();
        chkShowLockedOnly = new CheckBox();
        btnClearEntryFilters = new Button();
        pnlEntryFilterPrimaryRow = new Panel();
        txtEntrySearch = new TextBox();
        lblEntrySearch = new Label();
        cboEntryFilterKind = new ComboBox();
        lblEntryKind = new Label();
        lblEntries = new Label();
        pnlSelectedEntrySection = new Panel();
        ucEntryDetail = new ucEpisodeEntryDetail();
        txtThreadSummary = new TextBox();
        txtEpisodeEntryPreview = new TextBox();
        ((System.ComponentModel.ISupportInitialize)splitEpisodesMain).BeginInit();
        splitEpisodesMain.Panel1.SuspendLayout();
        splitEpisodesMain.Panel2.SuspendLayout();
        splitEpisodesMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitSeriesEpisodes).BeginInit();
        splitSeriesEpisodes.Panel1.SuspendLayout();
        splitSeriesEpisodes.Panel2.SuspendLayout();
        splitSeriesEpisodes.SuspendLayout();
        pnlSeriesSection.SuspendLayout();
        pnlSeriesActions.SuspendLayout();
        pnlEpisodeSection.SuspendLayout();
        pnlEpisodeActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitEpisodeWorkspace).BeginInit();
        splitEpisodeWorkspace.Panel1.SuspendLayout();
        splitEpisodeWorkspace.Panel2.SuspendLayout();
        splitEpisodeWorkspace.SuspendLayout();
        pnlEntryListSection.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridEpisodeEntries).BeginInit();
        pnlEntryToolRows.SuspendLayout();
        pnlEntryExportTools.SuspendLayout();
        pnlEntryGenerationTools.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numGenerateEntryCount).BeginInit();
        pnlEntryListActions.SuspendLayout();
        pnlEntryFilters.SuspendLayout();
        pnlEntryFilterSecondaryRow.SuspendLayout();
        pnlEntryFilterPrimaryRow.SuspendLayout();
        pnlSelectedEntrySection.SuspendLayout();
        SuspendLayout();
        // 
        // splitEpisodesMain
        // 
        splitEpisodesMain.Dock = DockStyle.Fill;
        splitEpisodesMain.Location = new Point(0, 0);
        splitEpisodesMain.Name = "splitEpisodesMain";
        // 
        // splitEpisodesMain.Panel1
        // 
        splitEpisodesMain.Panel1.Controls.Add(splitSeriesEpisodes);
        splitEpisodesMain.Panel1MinSize = 260;
        // 
        // splitEpisodesMain.Panel2
        // 
        splitEpisodesMain.Panel2.Controls.Add(splitEpisodeWorkspace);
        splitEpisodesMain.Size = new Size(1040, 760);
        splitEpisodesMain.SplitterDistance = 381;
        splitEpisodesMain.TabIndex = 0;
        // 
        // splitSeriesEpisodes
        // 
        splitSeriesEpisodes.Dock = DockStyle.Fill;
        splitSeriesEpisodes.Location = new Point(0, 0);
        splitSeriesEpisodes.Name = "splitSeriesEpisodes";
        splitSeriesEpisodes.Orientation = Orientation.Horizontal;
        // 
        // splitSeriesEpisodes.Panel1
        // 
        splitSeriesEpisodes.Panel1.Controls.Add(pnlSeriesSection);
        splitSeriesEpisodes.Panel1MinSize = 100;
        // 
        // splitSeriesEpisodes.Panel2
        // 
        splitSeriesEpisodes.Panel2.Controls.Add(pnlEpisodeSection);
        splitSeriesEpisodes.Size = new Size(381, 760);
        splitSeriesEpisodes.SplitterDistance = 150;
        splitSeriesEpisodes.TabIndex = 0;
        // 
        // pnlSeriesSection
        // 
        pnlSeriesSection.Controls.Add(lstSeries);
        pnlSeriesSection.Controls.Add(pnlSeriesActions);
        pnlSeriesSection.Controls.Add(lblSeries);
        pnlSeriesSection.Dock = DockStyle.Fill;
        pnlSeriesSection.Location = new Point(0, 0);
        pnlSeriesSection.Name = "pnlSeriesSection";
        pnlSeriesSection.Size = new Size(381, 150);
        pnlSeriesSection.TabIndex = 0;
        // 
        // lstSeries
        // 
        lstSeries.Dock = DockStyle.Fill;
        lstSeries.IntegralHeight = false;
        lstSeries.ItemHeight = 25;
        lstSeries.Location = new Point(0, 22);
        lstSeries.Name = "lstSeries";
        lstSeries.Size = new Size(381, 92);
        lstSeries.TabIndex = 2;
        // 
        // pnlSeriesActions
        // 
        pnlSeriesActions.Controls.Add(btnSeriesDuplicate);
        pnlSeriesActions.Controls.Add(btnSeriesDelete);
        pnlSeriesActions.Controls.Add(btnSeriesAdd);
        pnlSeriesActions.Dock = DockStyle.Bottom;
        pnlSeriesActions.Location = new Point(0, 114);
        pnlSeriesActions.Name = "pnlSeriesActions";
        pnlSeriesActions.Size = new Size(381, 36);
        pnlSeriesActions.TabIndex = 1;
        // 
        // btnSeriesDuplicate
        // 
        btnSeriesDuplicate.Dock = DockStyle.Left;
        btnSeriesDuplicate.Location = new Point(152, 0);
        btnSeriesDuplicate.Name = "btnSeriesDuplicate";
        btnSeriesDuplicate.Size = new Size(72, 36);
        btnSeriesDuplicate.TabIndex = 0;
        btnSeriesDuplicate.Text = "Dup";
        btnSeriesDuplicate.UseVisualStyleBackColor = true;
        // 
        // btnSeriesDelete
        // 
        btnSeriesDelete.Dock = DockStyle.Left;
        btnSeriesDelete.Location = new Point(76, 0);
        btnSeriesDelete.Name = "btnSeriesDelete";
        btnSeriesDelete.Size = new Size(76, 36);
        btnSeriesDelete.TabIndex = 1;
        btnSeriesDelete.Text = "Delete";
        btnSeriesDelete.UseVisualStyleBackColor = true;
        // 
        // btnSeriesAdd
        // 
        btnSeriesAdd.Dock = DockStyle.Left;
        btnSeriesAdd.Location = new Point(0, 0);
        btnSeriesAdd.Name = "btnSeriesAdd";
        btnSeriesAdd.Size = new Size(76, 36);
        btnSeriesAdd.TabIndex = 2;
        btnSeriesAdd.Text = "Add";
        btnSeriesAdd.UseVisualStyleBackColor = true;
        // 
        // lblSeries
        // 
        lblSeries.Dock = DockStyle.Top;
        lblSeries.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSeries.Location = new Point(0, 0);
        lblSeries.Name = "lblSeries";
        lblSeries.Size = new Size(381, 22);
        lblSeries.TabIndex = 0;
        lblSeries.Text = "Series";
        // 
        // pnlEpisodeSection
        // 
        pnlEpisodeSection.Controls.Add(lstEpisodes);
        pnlEpisodeSection.Controls.Add(pnlEpisodeActions);
        pnlEpisodeSection.Controls.Add(txtEpisodeSummary);
        pnlEpisodeSection.Controls.Add(ucMetaEditor);
        pnlEpisodeSection.Controls.Add(txtEpisodeSearch);
        pnlEpisodeSection.Controls.Add(lblEpisodes);
        pnlEpisodeSection.Dock = DockStyle.Fill;
        pnlEpisodeSection.Location = new Point(0, 0);
        pnlEpisodeSection.Name = "pnlEpisodeSection";
        pnlEpisodeSection.Size = new Size(381, 606);
        pnlEpisodeSection.TabIndex = 0;
        // 
        // lstEpisodes
        // 
        lstEpisodes.Dock = DockStyle.Fill;
        lstEpisodes.IntegralHeight = false;
        lstEpisodes.ItemHeight = 25;
        lstEpisodes.Location = new Point(0, 53);
        lstEpisodes.Name = "lstEpisodes";
        lstEpisodes.Size = new Size(381, 117);
        lstEpisodes.TabIndex = 2;
        // 
        // pnlEpisodeActions
        // 
        pnlEpisodeActions.Controls.Add(btnEpisodeMoveDown);
        pnlEpisodeActions.Controls.Add(btnEpisodeMoveUp);
        pnlEpisodeActions.Controls.Add(btnEpisodeDuplicate);
        pnlEpisodeActions.Controls.Add(btnNewEpisodeAfterSelected);
        pnlEpisodeActions.Controls.Add(btnLockEpisodeCanon);
        pnlEpisodeActions.Controls.Add(btnUnlockEpisodeCanon);
        pnlEpisodeActions.Controls.Add(btnEpisodeDelete);
        pnlEpisodeActions.Controls.Add(btnEpisodeAdd);
        pnlEpisodeActions.Dock = DockStyle.Bottom;
        pnlEpisodeActions.Location = new Point(0, 170);
        pnlEpisodeActions.Name = "pnlEpisodeActions";
        pnlEpisodeActions.Size = new Size(381, 36);
        pnlEpisodeActions.TabIndex = 3;
        // 
        // btnEpisodeMoveDown
        // 
        btnEpisodeMoveDown.Dock = DockStyle.Left;
        btnEpisodeMoveDown.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEpisodeMoveDown.Location = new Point(342, 0);
        btnEpisodeMoveDown.Name = "btnEpisodeMoveDown";
        btnEpisodeMoveDown.Size = new Size(34, 36);
        btnEpisodeMoveDown.TabIndex = 0;
        btnEpisodeMoveDown.Text = "▼";
        btnEpisodeMoveDown.UseVisualStyleBackColor = true;
        // 
        // btnEpisodeMoveUp
        // 
        btnEpisodeMoveUp.Dock = DockStyle.Left;
        btnEpisodeMoveUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEpisodeMoveUp.Location = new Point(308, 0);
        btnEpisodeMoveUp.Name = "btnEpisodeMoveUp";
        btnEpisodeMoveUp.Size = new Size(34, 36);
        btnEpisodeMoveUp.TabIndex = 1;
        btnEpisodeMoveUp.Text = "▲";
        btnEpisodeMoveUp.UseVisualStyleBackColor = true;
        // 
        // btnEpisodeDuplicate
        // 
        btnEpisodeDuplicate.Dock = DockStyle.Left;
        btnEpisodeDuplicate.Location = new Point(258, 0);
        btnEpisodeDuplicate.Name = "btnEpisodeDuplicate";
        btnEpisodeDuplicate.Size = new Size(50, 36);
        btnEpisodeDuplicate.TabIndex = 2;
        btnEpisodeDuplicate.Text = "Dup";
        btnEpisodeDuplicate.UseVisualStyleBackColor = true;
        // 
        // btnNewEpisodeAfterSelected
        // 
        btnNewEpisodeAfterSelected.Dock = DockStyle.Left;
        btnNewEpisodeAfterSelected.Location = new Point(208, 0);
        btnNewEpisodeAfterSelected.Name = "btnNewEpisodeAfterSelected";
        btnNewEpisodeAfterSelected.Size = new Size(50, 36);
        btnNewEpisodeAfterSelected.TabIndex = 3;
        btnNewEpisodeAfterSelected.Text = "Ins";
        btnNewEpisodeAfterSelected.UseVisualStyleBackColor = true;
        // 
        // btnLockEpisodeCanon
        // 
        btnLockEpisodeCanon.Dock = DockStyle.Left;
        btnLockEpisodeCanon.Location = new Point(158, 0);
        btnLockEpisodeCanon.Name = "btnLockEpisodeCanon";
        btnLockEpisodeCanon.Size = new Size(50, 36);
        btnLockEpisodeCanon.TabIndex = 4;
        btnLockEpisodeCanon.Text = "Lock";
        btnLockEpisodeCanon.UseVisualStyleBackColor = true;
        // 
        // btnUnlockEpisodeCanon
        // 
        btnUnlockEpisodeCanon.Dock = DockStyle.Left;
        btnUnlockEpisodeCanon.Location = new Point(100, 0);
        btnUnlockEpisodeCanon.Name = "btnUnlockEpisodeCanon";
        btnUnlockEpisodeCanon.Size = new Size(58, 36);
        btnUnlockEpisodeCanon.TabIndex = 5;
        btnUnlockEpisodeCanon.Text = "Unlock";
        btnUnlockEpisodeCanon.UseVisualStyleBackColor = true;
        // 
        // btnEpisodeDelete
        // 
        btnEpisodeDelete.Dock = DockStyle.Left;
        btnEpisodeDelete.Location = new Point(50, 0);
        btnEpisodeDelete.Name = "btnEpisodeDelete";
        btnEpisodeDelete.Size = new Size(50, 36);
        btnEpisodeDelete.TabIndex = 6;
        btnEpisodeDelete.Text = "Del";
        btnEpisodeDelete.UseVisualStyleBackColor = true;
        // 
        // btnEpisodeAdd
        // 
        btnEpisodeAdd.Dock = DockStyle.Left;
        btnEpisodeAdd.Location = new Point(0, 0);
        btnEpisodeAdd.Name = "btnEpisodeAdd";
        btnEpisodeAdd.Size = new Size(50, 36);
        btnEpisodeAdd.TabIndex = 7;
        btnEpisodeAdd.Text = "Add";
        btnEpisodeAdd.UseVisualStyleBackColor = true;
        // 
        // txtEpisodeSummary
        // 
        txtEpisodeSummary.BackColor = SystemColors.ControlLight;
        txtEpisodeSummary.Dock = DockStyle.Bottom;
        txtEpisodeSummary.Location = new Point(0, 206);
        txtEpisodeSummary.Multiline = true;
        txtEpisodeSummary.Name = "txtEpisodeSummary";
        txtEpisodeSummary.ReadOnly = true;
        txtEpisodeSummary.ScrollBars = ScrollBars.Vertical;
        txtEpisodeSummary.Size = new Size(381, 60);
        txtEpisodeSummary.TabIndex = 4;
        // 
        // ucMetaEditor
        // 
        ucMetaEditor.AutoScroll = true;
        ucMetaEditor.Dock = DockStyle.Bottom;
        ucMetaEditor.Enabled = false;
        ucMetaEditor.Location = new Point(0, 266);
        ucMetaEditor.Margin = new Padding(4, 5, 4, 5);
        ucMetaEditor.Name = "ucMetaEditor";
        ucMetaEditor.Size = new Size(381, 340);
        ucMetaEditor.TabIndex = 5;
        // 
        // txtEpisodeSearch
        // 
        txtEpisodeSearch.Dock = DockStyle.Top;
        txtEpisodeSearch.Location = new Point(0, 22);
        txtEpisodeSearch.Name = "txtEpisodeSearch";
        txtEpisodeSearch.PlaceholderText = "Search episodes...";
        txtEpisodeSearch.Size = new Size(381, 31);
        txtEpisodeSearch.TabIndex = 1;
        // 
        // lblEpisodes
        // 
        lblEpisodes.Dock = DockStyle.Top;
        lblEpisodes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblEpisodes.Location = new Point(0, 0);
        lblEpisodes.Name = "lblEpisodes";
        lblEpisodes.Size = new Size(381, 22);
        lblEpisodes.TabIndex = 0;
        lblEpisodes.Text = "Episodes";
        // 
        // splitEpisodeWorkspace
        // 
        splitEpisodeWorkspace.Dock = DockStyle.Fill;
        splitEpisodeWorkspace.Location = new Point(0, 0);
        splitEpisodeWorkspace.Name = "splitEpisodeWorkspace";
        splitEpisodeWorkspace.Orientation = Orientation.Horizontal;
        // 
        // splitEpisodeWorkspace.Panel1
        // 
        splitEpisodeWorkspace.Panel1.Controls.Add(pnlEntryListSection);
        splitEpisodeWorkspace.Panel1MinSize = 240;
        // 
        // splitEpisodeWorkspace.Panel2
        // 
        splitEpisodeWorkspace.Panel2.Controls.Add(pnlSelectedEntrySection);
        splitEpisodeWorkspace.Panel2MinSize = 240;
        splitEpisodeWorkspace.Size = new Size(655, 760);
        splitEpisodeWorkspace.SplitterDistance = 300;
        splitEpisodeWorkspace.TabIndex = 0;
        // 
        // pnlEntryListSection
        // 
        pnlEntryListSection.Controls.Add(gridEpisodeEntries);
        pnlEntryListSection.Controls.Add(pnlEntryToolRows);
        pnlEntryListSection.Controls.Add(pnlEntryFilters);
        pnlEntryListSection.Controls.Add(lblEntries);
        pnlEntryListSection.Dock = DockStyle.Fill;
        pnlEntryListSection.Location = new Point(0, 0);
        pnlEntryListSection.Name = "pnlEntryListSection";
        pnlEntryListSection.Size = new Size(655, 300);
        pnlEntryListSection.TabIndex = 0;
        // 
        // gridEpisodeEntries
        // 
        gridEpisodeEntries.AllowUserToAddRows = false;
        gridEpisodeEntries.ColumnHeadersHeight = 34;
        gridEpisodeEntries.Dock = DockStyle.Fill;
        gridEpisodeEntries.Location = new Point(0, 84);
        gridEpisodeEntries.MultiSelect = false;
        gridEpisodeEntries.Name = "gridEpisodeEntries";
        gridEpisodeEntries.RowHeadersWidth = 62;
        gridEpisodeEntries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridEpisodeEntries.Size = new Size(655, 108);
        gridEpisodeEntries.TabIndex = 2;
        // 
        // pnlEntryToolRows
        // 
        pnlEntryToolRows.Controls.Add(pnlEntryExportTools);
        pnlEntryToolRows.Controls.Add(pnlEntryGenerationTools);
        pnlEntryToolRows.Controls.Add(pnlEntryListActions);
        pnlEntryToolRows.Dock = DockStyle.Bottom;
        pnlEntryToolRows.Location = new Point(0, 192);
        pnlEntryToolRows.Name = "pnlEntryToolRows";
        pnlEntryToolRows.Size = new Size(655, 108);
        pnlEntryToolRows.TabIndex = 3;
        // 
        // pnlEntryExportTools
        // 
        pnlEntryExportTools.Controls.Add(btnExportEpisodeText);
        pnlEntryExportTools.Controls.Add(btnExportEpisodeTts);
        pnlEntryExportTools.Controls.Add(btnExportEpisodeJson);
        pnlEntryExportTools.Controls.Add(chkExportIncludeHeader);
        pnlEntryExportTools.Controls.Add(chkExportBlankLineBetweenEntries);
        pnlEntryExportTools.Controls.Add(chkExportIncludeEntryMarkers);
        pnlEntryExportTools.Controls.Add(chkExportAuthorDebugMode);
        pnlEntryExportTools.Dock = DockStyle.Top;
        pnlEntryExportTools.Location = new Point(0, 72);
        pnlEntryExportTools.Name = "pnlEntryExportTools";
        pnlEntryExportTools.Size = new Size(655, 36);
        pnlEntryExportTools.TabIndex = 2;
        // 
        // btnExportEpisodeText
        // 
        btnExportEpisodeText.Dock = DockStyle.Left;
        btnExportEpisodeText.Location = new Point(382, 0);
        btnExportEpisodeText.Name = "btnExportEpisodeText";
        btnExportEpisodeText.Size = new Size(84, 36);
        btnExportEpisodeText.TabIndex = 0;
        btnExportEpisodeText.Text = "Broadcast";
        btnExportEpisodeText.UseVisualStyleBackColor = true;
        // 
        // btnExportEpisodeTts
        // 
        btnExportEpisodeTts.Dock = DockStyle.Left;
        btnExportEpisodeTts.Location = new Point(330, 0);
        btnExportEpisodeTts.Name = "btnExportEpisodeTts";
        btnExportEpisodeTts.Size = new Size(52, 36);
        btnExportEpisodeTts.TabIndex = 1;
        btnExportEpisodeTts.Text = "TTS";
        btnExportEpisodeTts.UseVisualStyleBackColor = true;
        // 
        // btnExportEpisodeJson
        // 
        btnExportEpisodeJson.Dock = DockStyle.Left;
        btnExportEpisodeJson.Location = new Point(272, 0);
        btnExportEpisodeJson.Name = "btnExportEpisodeJson";
        btnExportEpisodeJson.Size = new Size(58, 36);
        btnExportEpisodeJson.TabIndex = 2;
        btnExportEpisodeJson.Text = "JSON";
        btnExportEpisodeJson.UseVisualStyleBackColor = true;
        // 
        // chkExportIncludeHeader
        // 
        chkExportIncludeHeader.Checked = true;
        chkExportIncludeHeader.CheckState = CheckState.Checked;
        chkExportIncludeHeader.Dock = DockStyle.Left;
        chkExportIncludeHeader.Location = new Point(202, 0);
        chkExportIncludeHeader.Name = "chkExportIncludeHeader";
        chkExportIncludeHeader.Size = new Size(70, 36);
        chkExportIncludeHeader.TabIndex = 3;
        chkExportIncludeHeader.Text = "Header";
        chkExportIncludeHeader.UseVisualStyleBackColor = true;
        // 
        // chkExportBlankLineBetweenEntries
        // 
        chkExportBlankLineBetweenEntries.Checked = true;
        chkExportBlankLineBetweenEntries.CheckState = CheckState.Checked;
        chkExportBlankLineBetweenEntries.Dock = DockStyle.Left;
        chkExportBlankLineBetweenEntries.Location = new Point(136, 0);
        chkExportBlankLineBetweenEntries.Name = "chkExportBlankLineBetweenEntries";
        chkExportBlankLineBetweenEntries.Size = new Size(66, 36);
        chkExportBlankLineBetweenEntries.TabIndex = 4;
        chkExportBlankLineBetweenEntries.Text = "Blanks";
        chkExportBlankLineBetweenEntries.UseVisualStyleBackColor = true;
        // 
        // chkExportIncludeEntryMarkers
        // 
        chkExportIncludeEntryMarkers.Dock = DockStyle.Left;
        chkExportIncludeEntryMarkers.Location = new Point(64, 0);
        chkExportIncludeEntryMarkers.Name = "chkExportIncludeEntryMarkers";
        chkExportIncludeEntryMarkers.Size = new Size(72, 36);
        chkExportIncludeEntryMarkers.TabIndex = 5;
        chkExportIncludeEntryMarkers.Text = "Markers";
        chkExportIncludeEntryMarkers.UseVisualStyleBackColor = true;
        // 
        // chkExportAuthorDebugMode
        // 
        chkExportAuthorDebugMode.Dock = DockStyle.Left;
        chkExportAuthorDebugMode.Location = new Point(0, 0);
        chkExportAuthorDebugMode.Name = "chkExportAuthorDebugMode";
        chkExportAuthorDebugMode.Size = new Size(64, 36);
        chkExportAuthorDebugMode.TabIndex = 6;
        chkExportAuthorDebugMode.Text = "Debug";
        chkExportAuthorDebugMode.UseVisualStyleBackColor = true;
        // 
        // pnlEntryGenerationTools
        // 
        pnlEntryGenerationTools.Controls.Add(btnGenerateEntry);
        pnlEntryGenerationTools.Controls.Add(btnGenerateEpisodeEntries);
        pnlEntryGenerationTools.Controls.Add(btnRegenerateSelectedEntry);
        pnlEntryGenerationTools.Controls.Add(numGenerateEntryCount);
        pnlEntryGenerationTools.Controls.Add(chkClearEpisodeBeforeGenerate);
        pnlEntryGenerationTools.Controls.Add(lblGenerationSeed);
        pnlEntryGenerationTools.Controls.Add(txtGenerationSeed);
        pnlEntryGenerationTools.Controls.Add(chkRegenerateWithoutAdvancingThread);
        pnlEntryGenerationTools.Dock = DockStyle.Top;
        pnlEntryGenerationTools.Location = new Point(0, 36);
        pnlEntryGenerationTools.Name = "pnlEntryGenerationTools";
        pnlEntryGenerationTools.Size = new Size(655, 36);
        pnlEntryGenerationTools.TabIndex = 1;
        // 
        // btnGenerateEntry
        // 
        btnGenerateEntry.Dock = DockStyle.Left;
        btnGenerateEntry.Location = new Point(482, 0);
        btnGenerateEntry.Name = "btnGenerateEntry";
        btnGenerateEntry.Size = new Size(88, 36);
        btnGenerateEntry.TabIndex = 0;
        btnGenerateEntry.Text = "Gen Entry";
        btnGenerateEntry.UseVisualStyleBackColor = true;
        // 
        // btnGenerateEpisodeEntries
        // 
        btnGenerateEpisodeEntries.Dock = DockStyle.Left;
        btnGenerateEpisodeEntries.Location = new Point(386, 0);
        btnGenerateEpisodeEntries.Name = "btnGenerateEpisodeEntries";
        btnGenerateEpisodeEntries.Size = new Size(96, 36);
        btnGenerateEpisodeEntries.TabIndex = 1;
        btnGenerateEpisodeEntries.Text = "Fill Episode";
        btnGenerateEpisodeEntries.UseVisualStyleBackColor = true;
        // 
        // btnRegenerateSelectedEntry
        // 
        btnRegenerateSelectedEntry.Dock = DockStyle.Left;
        btnRegenerateSelectedEntry.Location = new Point(314, 0);
        btnRegenerateSelectedEntry.Name = "btnRegenerateSelectedEntry";
        btnRegenerateSelectedEntry.Size = new Size(72, 36);
        btnRegenerateSelectedEntry.TabIndex = 2;
        btnRegenerateSelectedEntry.Text = "Regen";
        btnRegenerateSelectedEntry.UseVisualStyleBackColor = true;
        // 
        // numGenerateEntryCount
        // 
        numGenerateEntryCount.Dock = DockStyle.Left;
        numGenerateEntryCount.Location = new Point(262, 0);
        numGenerateEntryCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numGenerateEntryCount.Name = "numGenerateEntryCount";
        numGenerateEntryCount.Size = new Size(52, 31);
        numGenerateEntryCount.TabIndex = 3;
        numGenerateEntryCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // chkClearEpisodeBeforeGenerate
        // 
        chkClearEpisodeBeforeGenerate.Dock = DockStyle.Left;
        chkClearEpisodeBeforeGenerate.Location = new Point(204, 0);
        chkClearEpisodeBeforeGenerate.Name = "chkClearEpisodeBeforeGenerate";
        chkClearEpisodeBeforeGenerate.Size = new Size(58, 36);
        chkClearEpisodeBeforeGenerate.TabIndex = 4;
        chkClearEpisodeBeforeGenerate.Text = "Clear";
        chkClearEpisodeBeforeGenerate.UseVisualStyleBackColor = true;
        // 
        // lblGenerationSeed
        // 
        lblGenerationSeed.Dock = DockStyle.Left;
        lblGenerationSeed.Location = new Point(162, 0);
        lblGenerationSeed.Name = "lblGenerationSeed";
        lblGenerationSeed.Size = new Size(42, 36);
        lblGenerationSeed.TabIndex = 5;
        lblGenerationSeed.Text = "Seed:";
        lblGenerationSeed.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtGenerationSeed
        // 
        txtGenerationSeed.Dock = DockStyle.Left;
        txtGenerationSeed.Location = new Point(90, 0);
        txtGenerationSeed.Name = "txtGenerationSeed";
        txtGenerationSeed.Size = new Size(72, 31);
        txtGenerationSeed.TabIndex = 6;
        // 
        // chkRegenerateWithoutAdvancingThread
        // 
        chkRegenerateWithoutAdvancingThread.Checked = true;
        chkRegenerateWithoutAdvancingThread.CheckState = CheckState.Checked;
        chkRegenerateWithoutAdvancingThread.Dock = DockStyle.Left;
        chkRegenerateWithoutAdvancingThread.Location = new Point(0, 0);
        chkRegenerateWithoutAdvancingThread.Name = "chkRegenerateWithoutAdvancingThread";
        chkRegenerateWithoutAdvancingThread.Size = new Size(90, 36);
        chkRegenerateWithoutAdvancingThread.TabIndex = 7;
        chkRegenerateWithoutAdvancingThread.Text = "Edit mode";
        chkRegenerateWithoutAdvancingThread.UseVisualStyleBackColor = true;
        // 
        // pnlEntryListActions
        // 
        pnlEntryListActions.Controls.Add(btnEntryMoveDown);
        pnlEntryListActions.Controls.Add(btnEntryMoveUp);
        pnlEntryListActions.Controls.Add(btnEntryDelete);
        pnlEntryListActions.Controls.Add(btnEntryDuplicate);
        pnlEntryListActions.Controls.Add(btnNoticeEntryAdd);
        pnlEntryListActions.Controls.Add(btnEntryAdd);
        pnlEntryListActions.Dock = DockStyle.Top;
        pnlEntryListActions.Location = new Point(0, 0);
        pnlEntryListActions.Name = "pnlEntryListActions";
        pnlEntryListActions.Size = new Size(655, 36);
        pnlEntryListActions.TabIndex = 0;
        // 
        // btnEntryMoveDown
        // 
        btnEntryMoveDown.Dock = DockStyle.Left;
        btnEntryMoveDown.Location = new Point(406, 0);
        btnEntryMoveDown.Name = "btnEntryMoveDown";
        btnEntryMoveDown.Size = new Size(34, 36);
        btnEntryMoveDown.TabIndex = 0;
        btnEntryMoveDown.Text = "▼";
        btnEntryMoveDown.UseVisualStyleBackColor = true;
        // 
        // btnEntryMoveUp
        // 
        btnEntryMoveUp.Dock = DockStyle.Left;
        btnEntryMoveUp.Location = new Point(372, 0);
        btnEntryMoveUp.Name = "btnEntryMoveUp";
        btnEntryMoveUp.Size = new Size(34, 36);
        btnEntryMoveUp.TabIndex = 1;
        btnEntryMoveUp.Text = "▲";
        btnEntryMoveUp.UseVisualStyleBackColor = true;
        // 
        // btnEntryDelete
        // 
        btnEntryDelete.Dock = DockStyle.Left;
        btnEntryDelete.Location = new Point(302, 0);
        btnEntryDelete.Name = "btnEntryDelete";
        btnEntryDelete.Size = new Size(70, 36);
        btnEntryDelete.TabIndex = 2;
        btnEntryDelete.Text = "Delete";
        btnEntryDelete.UseVisualStyleBackColor = true;
        // 
        // btnEntryDuplicate
        // 
        btnEntryDuplicate.Dock = DockStyle.Left;
        btnEntryDuplicate.Location = new Point(226, 0);
        btnEntryDuplicate.Name = "btnEntryDuplicate";
        btnEntryDuplicate.Size = new Size(76, 36);
        btnEntryDuplicate.TabIndex = 3;
        btnEntryDuplicate.Text = "Duplicate";
        btnEntryDuplicate.UseVisualStyleBackColor = true;
        // 
        // btnNoticeEntryAdd
        // 
        btnNoticeEntryAdd.Dock = DockStyle.Left;
        btnNoticeEntryAdd.Location = new Point(116, 0);
        btnNoticeEntryAdd.Name = "btnNoticeEntryAdd";
        btnNoticeEntryAdd.Size = new Size(110, 36);
        btnNoticeEntryAdd.TabIndex = 4;
        btnNoticeEntryAdd.Text = "Add Notice";
        btnNoticeEntryAdd.UseVisualStyleBackColor = true;
        // 
        // btnEntryAdd
        // 
        btnEntryAdd.Dock = DockStyle.Left;
        btnEntryAdd.Location = new Point(0, 0);
        btnEntryAdd.Name = "btnEntryAdd";
        btnEntryAdd.Size = new Size(116, 36);
        btnEntryAdd.TabIndex = 5;
        btnEntryAdd.Text = "Add Traffic";
        btnEntryAdd.UseVisualStyleBackColor = true;
        // 
        // pnlEntryFilters
        // 
        pnlEntryFilters.Controls.Add(pnlEntryFilterSecondaryRow);
        pnlEntryFilters.Controls.Add(pnlEntryFilterPrimaryRow);
        pnlEntryFilters.Dock = DockStyle.Top;
        pnlEntryFilters.Location = new Point(0, 22);
        pnlEntryFilters.Name = "pnlEntryFilters";
        pnlEntryFilters.Size = new Size(655, 62);
        pnlEntryFilters.TabIndex = 1;
        // 
        // pnlEntryFilterSecondaryRow
        // 
        pnlEntryFilterSecondaryRow.Controls.Add(cboEntryFilterVessel);
        pnlEntryFilterSecondaryRow.Controls.Add(cboEntryFilterStation);
        pnlEntryFilterSecondaryRow.Controls.Add(chkShowLockedOnly);
        pnlEntryFilterSecondaryRow.Controls.Add(btnClearEntryFilters);
        pnlEntryFilterSecondaryRow.Dock = DockStyle.Top;
        pnlEntryFilterSecondaryRow.Location = new Point(0, 31);
        pnlEntryFilterSecondaryRow.Name = "pnlEntryFilterSecondaryRow";
        pnlEntryFilterSecondaryRow.Size = new Size(655, 31);
        pnlEntryFilterSecondaryRow.TabIndex = 1;
        // 
        // cboEntryFilterVessel
        // 
        cboEntryFilterVessel.Dock = DockStyle.Fill;
        cboEntryFilterVessel.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterVessel.Location = new Point(0, 0);
        cboEntryFilterVessel.Name = "cboEntryFilterVessel";
        cboEntryFilterVessel.Size = new Size(413, 33);
        cboEntryFilterVessel.TabIndex = 0;
        // 
        // cboEntryFilterStation
        // 
        cboEntryFilterStation.Dock = DockStyle.Right;
        cboEntryFilterStation.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterStation.Location = new Point(413, 0);
        cboEntryFilterStation.Name = "cboEntryFilterStation";
        cboEntryFilterStation.Size = new Size(130, 33);
        cboEntryFilterStation.TabIndex = 1;
        // 
        // chkShowLockedOnly
        // 
        chkShowLockedOnly.Dock = DockStyle.Right;
        chkShowLockedOnly.Location = new Point(543, 0);
        chkShowLockedOnly.Name = "chkShowLockedOnly";
        chkShowLockedOnly.Size = new Size(60, 31);
        chkShowLockedOnly.TabIndex = 2;
        chkShowLockedOnly.Text = "Locked";
        chkShowLockedOnly.UseVisualStyleBackColor = true;
        // 
        // btnClearEntryFilters
        // 
        btnClearEntryFilters.Dock = DockStyle.Right;
        btnClearEntryFilters.Location = new Point(603, 0);
        btnClearEntryFilters.Name = "btnClearEntryFilters";
        btnClearEntryFilters.Size = new Size(52, 31);
        btnClearEntryFilters.TabIndex = 3;
        btnClearEntryFilters.Text = "Clear";
        btnClearEntryFilters.UseVisualStyleBackColor = true;
        // 
        // pnlEntryFilterPrimaryRow
        // 
        pnlEntryFilterPrimaryRow.Controls.Add(txtEntrySearch);
        pnlEntryFilterPrimaryRow.Controls.Add(lblEntrySearch);
        pnlEntryFilterPrimaryRow.Controls.Add(cboEntryFilterKind);
        pnlEntryFilterPrimaryRow.Controls.Add(lblEntryKind);
        pnlEntryFilterPrimaryRow.Dock = DockStyle.Top;
        pnlEntryFilterPrimaryRow.Location = new Point(0, 0);
        pnlEntryFilterPrimaryRow.Name = "pnlEntryFilterPrimaryRow";
        pnlEntryFilterPrimaryRow.Size = new Size(655, 31);
        pnlEntryFilterPrimaryRow.TabIndex = 0;
        // 
        // txtEntrySearch
        // 
        txtEntrySearch.Dock = DockStyle.Fill;
        txtEntrySearch.Location = new Point(77, 0);
        txtEntrySearch.Name = "txtEntrySearch";
        txtEntrySearch.Size = new Size(432, 31);
        txtEntrySearch.TabIndex = 1;
        // 
        // lblEntrySearch
        // 
        lblEntrySearch.Dock = DockStyle.Left;
        lblEntrySearch.Location = new Point(0, 0);
        lblEntrySearch.Name = "lblEntrySearch";
        lblEntrySearch.Size = new Size(77, 31);
        lblEntrySearch.TabIndex = 0;
        lblEntrySearch.Text = "Search:";
        lblEntrySearch.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cboEntryFilterKind
        // 
        cboEntryFilterKind.Dock = DockStyle.Right;
        cboEntryFilterKind.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEntryFilterKind.Location = new Point(509, 0);
        cboEntryFilterKind.Name = "cboEntryFilterKind";
        cboEntryFilterKind.Size = new Size(110, 33);
        cboEntryFilterKind.TabIndex = 3;
        // 
        // lblEntryKind
        // 
        lblEntryKind.Dock = DockStyle.Right;
        lblEntryKind.Location = new Point(619, 0);
        lblEntryKind.Name = "lblEntryKind";
        lblEntryKind.Size = new Size(36, 31);
        lblEntryKind.TabIndex = 2;
        lblEntryKind.Text = "Kind:";
        lblEntryKind.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblEntries
        // 
        lblEntries.Dock = DockStyle.Top;
        lblEntries.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblEntries.Location = new Point(0, 0);
        lblEntries.Name = "lblEntries";
        lblEntries.Size = new Size(655, 22);
        lblEntries.TabIndex = 0;
        lblEntries.Text = "Entries";
        // 
        // pnlSelectedEntrySection
        // 
        pnlSelectedEntrySection.Controls.Add(ucEntryDetail);
        pnlSelectedEntrySection.Controls.Add(txtThreadSummary);
        pnlSelectedEntrySection.Controls.Add(txtEpisodeEntryPreview);
        pnlSelectedEntrySection.Dock = DockStyle.Fill;
        pnlSelectedEntrySection.Location = new Point(0, 0);
        pnlSelectedEntrySection.Name = "pnlSelectedEntrySection";
        pnlSelectedEntrySection.Size = new Size(655, 456);
        pnlSelectedEntrySection.TabIndex = 0;
        // 
        // ucEntryDetail
        // 
        ucEntryDetail.AutoScroll = true;
        ucEntryDetail.Dock = DockStyle.Fill;
        ucEntryDetail.Enabled = false;
        ucEntryDetail.Location = new Point(0, 0);
        ucEntryDetail.Margin = new Padding(4, 5, 4, 5);
        ucEntryDetail.Name = "ucEntryDetail";
        ucEntryDetail.Size = new Size(655, 298);
        ucEntryDetail.TabIndex = 0;
        // 
        // txtThreadSummary
        // 
        txtThreadSummary.BackColor = SystemColors.Info;
        txtThreadSummary.Dock = DockStyle.Bottom;
        txtThreadSummary.Location = new Point(0, 298);
        txtThreadSummary.Multiline = true;
        txtThreadSummary.Name = "txtThreadSummary";
        txtThreadSummary.ReadOnly = true;
        txtThreadSummary.ScrollBars = ScrollBars.Vertical;
        txtThreadSummary.Size = new Size(655, 68);
        txtThreadSummary.TabIndex = 1;
        // 
        // txtEpisodeEntryPreview
        // 
        txtEpisodeEntryPreview.BackColor = SystemColors.ControlLight;
        txtEpisodeEntryPreview.Dock = DockStyle.Bottom;
        txtEpisodeEntryPreview.Location = new Point(0, 366);
        txtEpisodeEntryPreview.Multiline = true;
        txtEpisodeEntryPreview.Name = "txtEpisodeEntryPreview";
        txtEpisodeEntryPreview.ReadOnly = true;
        txtEpisodeEntryPreview.ScrollBars = ScrollBars.Vertical;
        txtEpisodeEntryPreview.Size = new Size(655, 90);
        txtEpisodeEntryPreview.TabIndex = 2;
        // 
        // ucEpisodes
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(splitEpisodesMain);
        Name = "ucEpisodes";
        Size = new Size(1040, 760);
        splitEpisodesMain.Panel1.ResumeLayout(false);
        splitEpisodesMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitEpisodesMain).EndInit();
        splitEpisodesMain.ResumeLayout(false);
        splitSeriesEpisodes.Panel1.ResumeLayout(false);
        splitSeriesEpisodes.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitSeriesEpisodes).EndInit();
        splitSeriesEpisodes.ResumeLayout(false);
        pnlSeriesSection.ResumeLayout(false);
        pnlSeriesActions.ResumeLayout(false);
        pnlEpisodeSection.ResumeLayout(false);
        pnlEpisodeSection.PerformLayout();
        pnlEpisodeActions.ResumeLayout(false);
        splitEpisodeWorkspace.Panel1.ResumeLayout(false);
        splitEpisodeWorkspace.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitEpisodeWorkspace).EndInit();
        splitEpisodeWorkspace.ResumeLayout(false);
        pnlEntryListSection.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridEpisodeEntries).EndInit();
        pnlEntryToolRows.ResumeLayout(false);
        pnlEntryExportTools.ResumeLayout(false);
        pnlEntryGenerationTools.ResumeLayout(false);
        pnlEntryGenerationTools.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numGenerateEntryCount).EndInit();
        pnlEntryListActions.ResumeLayout(false);
        pnlEntryFilters.ResumeLayout(false);
        pnlEntryFilterSecondaryRow.ResumeLayout(false);
        pnlEntryFilterPrimaryRow.ResumeLayout(false);
        pnlEntryFilterPrimaryRow.PerformLayout();
        pnlSelectedEntrySection.ResumeLayout(false);
        pnlSelectedEntrySection.PerformLayout();
        ResumeLayout(false);
    }

    // ── Control fields ─────────────────────────────────────────────────────────

    private SplitContainer splitEpisodesMain = null!;
    private SplitContainer splitSeriesEpisodes = null!;
    private SplitContainer splitEpisodeWorkspace = null!;

    private Panel pnlSeriesSection = null!;
    private Label lblSeries = null!;
    private ListBox lstSeries = null!;
    private Panel pnlSeriesActions = null!;
    private Button btnSeriesAdd = null!;
    private Button btnSeriesDelete = null!;
    private Button btnSeriesDuplicate = null!;

    private Panel pnlEpisodeSection = null!;
    private Label lblEpisodes = null!;
    private TextBox txtEpisodeSearch = null!;
    private ListBox lstEpisodes = null!;
    private TextBox txtEpisodeSummary = null!;
    private ucEpisodeMetaEditor ucMetaEditor = null!;
    private Panel pnlEpisodeActions = null!;
    private Button btnEpisodeAdd = null!;
    private Button btnEpisodeDelete = null!;
    private Button btnEpisodeDuplicate = null!;
    private Button btnNewEpisodeAfterSelected = null!;
    private Button btnLockEpisodeCanon = null!;
    private Button btnUnlockEpisodeCanon = null!;
    private Button btnEpisodeMoveUp = null!;
    private Button btnEpisodeMoveDown = null!;

    private Panel pnlEntryListSection = null!;
    private Label lblEntries = null!;
    private Panel pnlEntryFilters = null!;
    private Panel pnlEntryFilterPrimaryRow = null!;
    private Panel pnlEntryFilterSecondaryRow = null!;
    private Label lblEntrySearch = null!;
    private Label lblEntryKind = null!;
    private TextBox txtEntrySearch = null!;
    private ComboBox cboEntryFilterKind = null!;
    private ComboBox cboEntryFilterVessel = null!;
    private ComboBox cboEntryFilterStation = null!;
    private CheckBox chkShowLockedOnly = null!;
    private Button btnClearEntryFilters = null!;

    private DataGridView gridEpisodeEntries = null!;

    private Panel pnlEntryToolRows = null!;
    private Panel pnlEntryListActions = null!;
    private Panel pnlEntryGenerationTools = null!;
    private Panel pnlEntryExportTools = null!;

    private Button btnEntryAdd = null!;
    private Button btnNoticeEntryAdd = null!;
    private Button btnEntryDuplicate = null!;
    private Button btnEntryDelete = null!;
    private Button btnEntryMoveUp = null!;
    private Button btnEntryMoveDown = null!;

    private Button btnGenerateEntry = null!;
    private Button btnGenerateEpisodeEntries = null!;
    private Button btnRegenerateSelectedEntry = null!;
    private NumericUpDown numGenerateEntryCount = null!;
    private CheckBox chkClearEpisodeBeforeGenerate = null!;
    private Label lblGenerationSeed = null!;
    private TextBox txtGenerationSeed = null!;
    private CheckBox chkRegenerateWithoutAdvancingThread = null!;

    private Button btnExportEpisodeText = null!;
    private Button btnExportEpisodeTts = null!;
    private Button btnExportEpisodeJson = null!;
    private CheckBox chkExportIncludeHeader = null!;
    private CheckBox chkExportBlankLineBetweenEntries = null!;
    private CheckBox chkExportIncludeEntryMarkers = null!;
    private CheckBox chkExportAuthorDebugMode = null!;

    private Panel pnlSelectedEntrySection = null!;
    private ucEpisodeEntryDetail ucEntryDetail = null!;
    private TextBox txtThreadSummary = null!;
    private TextBox txtEpisodeEntryPreview = null!;
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

    private readonly EntryRenderingService _renderer = new();
    private readonly ProjectValidationService _validator = new();
    private readonly EpisodeGenerationService _generator = new();
    private readonly ProjectExportService _exportService = new();

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

    private readonly BindingSource _bsStarSystems = new();
    private readonly BindingSource _bsCelestialBodies = new();
    private readonly BindingSource _bsStations = new();
    private readonly BindingSource _bsDocks = new();
    private readonly BindingSource _bsRoutes = new();
    private readonly BindingSource _bsCommodities = new();
    private readonly BindingSource _bsOrganisations = new();
    private readonly BindingSource _bsDirectives = new();
    private readonly BindingSource _bsVessels = new();
    private readonly BindingSource _bsThreads = new();
    private readonly BindingSource _bsThreadBeats = new();
    private readonly BindingSource _bsReferenceItems = new();
    private readonly BindingSource _bsSeries = new();
    private readonly BindingSource _bsEpisodes = new();
    private readonly BindingSource _bsEntries = new();
    private readonly BindingSource _bsValidation = new();
    private readonly BindingSource _bsDeclaredCargo = new();
    private readonly BindingSource _bsActualCargo = new();
    private readonly BindingSource _bsDeclaredPassengers = new();
    private readonly BindingSource _bsActualPassengers = new();

    // â”€â”€ Filter views â€” non-destructive filtered projections of project lists â”€â”€â”€â”€

    private readonly BindingList<EpisodeRecord> _episodesView = new();
    private readonly BindingList<EpisodeEntryRecord> _entriesView = new();

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
        _appState = new AppStateService();
        _fileService = new ProjectFileService();
        _seedFactory = new ProjectSeedFactory();

        InitializeComponent();
        InitializeTabContent(); // tab pages populated here; separated from InitializeComponent for designer compatibility

        _appState.ProjectChanged += OnProjectChanged;
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
        _bsEntries.DataSource = _entriesView;
        gridEpisodeEntries.DataSource = _bsEntries;

        // Entry detail write-back handlers â€” subscribed once here
        HookEntryDetailHandlers();

        // Episode/series metadata write-back handlers â€” subscribed once here
        HookEpisodeMetaHandlers();

        // Stations grid consistency â€” StarSystem/CelestialBody coupling
        HookStationsGridConsistency();

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
        txtProjectName.Text = p.ProjectName;
        txtProjectDescription.Text = p.Description;
        txtSchemaVersion.Text = p.SchemaVersion.ToString();

        // World grids
        _bsStarSystems.DataSource = p.StarSystems;
        gridStarSystems.DataSource = _bsStarSystems;

        _bsCelestialBodies.DataSource = p.CelestialBodies;
        gridCelestialBodies.DataSource = _bsCelestialBodies;

        _bsStations.DataSource = p.Stations;
        gridStations.DataSource = _bsStations;

        _bsDocks.DataSource = p.Docks;
        gridDocks.DataSource = _bsDocks;

        _bsRoutes.DataSource = p.Routes;
        gridRoutes.DataSource = _bsRoutes;

        _bsCommodities.DataSource = p.Commodities;
        gridCommodities.DataSource = _bsCommodities;

        _bsOrganisations.DataSource = p.Organisations;
        gridOrganisations.DataSource = _bsOrganisations;

        _bsDirectives.DataSource = p.Directives;
        gridDirectives.DataSource = _bsDirectives;

        _bsVessels.DataSource = p.Vessels;
        gridVessels.DataSource = _bsVessels;

        // Threads â€” beats grid is managed by gridThreads.SelectionChanged
        _bsThreads.DataSource = p.StoryThreads;
        gridThreads.DataSource = _bsThreads;

        // Series list â€” bound directly to project's Series list.
        _bsSeries.DataSource = p.Series;
        lstSeries.DataSource = _bsSeries;
        lstSeries.DisplayMember = "Name";

        // Episodes â€” bound to _episodesView so filtering is non-destructive.
        // ApplyEpisodeFilter populates _episodesView from p.Episodes, filtered by series.
        _bsEpisodes.DataSource = _episodesView;
        lstEpisodes.DataSource = _bsEpisodes;
        lstEpisodes.DisplayMember = "Name";
        ApplyEpisodeFilter();

        // Rebuild lookup service for the new project
        _lookup = new ProjectLookupService(p);

        // Repopulate entry detail combo boxes (and manifest grid columns) with fresh project data
        PopulateEntryDetailCombos();

        // Set up Systems & Bodies grid columns with current project's lookup data
        SetupSystemsBodiesColumns();

        // Set up Stations grid columns with current project's lookup data
        SetupStationsDockColumns();

        // Repopulate episode/series metadata combo boxes
        PopulateEpisodeMetaCombos();

        // Clear transient views
        ClearDetailPanel();
        txtRenderedOutput.Clear();

        // If a reference type was already selected, rebind its grid to the new project
        RefreshReferenceGrid();

        // Loading the UI fires TextChanged / other handlers that spuriously mark the project
        // dirty. Clear that flag â€” the project is genuinely clean immediately after a load.
        _appState.MarkClean();
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

    // â”€â”€ Systems & Bodies â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnSystemAdd_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;
        var system = new StarSystemRecord { Name = $"System {p.StarSystems.Count + 1}" };
        p.StarSystems.Add(system);
        _bsStarSystems.ResetBindings(false);
        _bsStarSystems.Position = _bsStarSystems.Count - 1;
        _appState.MarkDirty();
        _lookup = new ProjectLookupService(p);
        SetupSystemsBodiesColumns();
        SetupStationsDockColumns();
    }

    private void btnSystemDelete_Click(object? sender, EventArgs e)
    {
        if (_bsStarSystems.Current is not StarSystemRecord system) return;

        var confirm = MessageBox.Show(
            $"Delete star system '{system.Name}'?\nThis cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _bsStarSystems.RemoveCurrent();
        _appState.MarkDirty();
        _lookup = new ProjectLookupService(_appState.CurrentProject);
        SetupSystemsBodiesColumns();
        SetupStationsDockColumns();
    }

    private void btnBodyAdd_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;
        var body = new CelestialBodyRecord
        {
            Name = $"Body {p.CelestialBodies.Count + 1}",
            StarSystemId = (_bsStarSystems.Current is StarSystemRecord sel) ? sel.Id : string.Empty
        };
        p.CelestialBodies.Add(body);
        _bsCelestialBodies.ResetBindings(false);
        _bsCelestialBodies.Position = _bsCelestialBodies.Count - 1;
        _appState.MarkDirty();
        _lookup = new ProjectLookupService(p);
        SetupSystemsBodiesColumns();
        SetupStationsDockColumns();
    }

    private void btnBodyDelete_Click(object? sender, EventArgs e)
    {
        if (_bsCelestialBodies.Current is not CelestialBodyRecord body) return;

        var confirm = MessageBox.Show(
            $"Delete celestial body '{body.Name}'?\nThis cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _bsCelestialBodies.RemoveCurrent();
        _appState.MarkDirty();
        _lookup = new ProjectLookupService(_appState.CurrentProject);
        SetupSystemsBodiesColumns();
        SetupStationsDockColumns();
    }

    // â”€â”€ Stations & Docks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnStationsAdd_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;
        var station = new StationRecord { Name = $"Station {p.Stations.Count + 1}" };
        p.Stations.Add(station);
        _bsStations.ResetBindings(false);
        _bsStations.Position = _bsStations.Count - 1;
        _appState.MarkDirty();
        _lookup = new ProjectLookupService(p);
        SetupStationsDockColumns();
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
        _lookup = new ProjectLookupService(_appState.CurrentProject);
        SetupStationsDockColumns();
    }

    private void btnDocksAdd_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;
        var dock = new DockRecord
        {
            Name = $"Dock {p.Docks.Count + 1}",
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

    // â”€â”€ Organisations & Directives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void btnOrganisationsAdd_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;
        var org = new OrganisationRecord { Name = $"Organisation {p.Organisations.Count + 1}" };
        p.Organisations.Add(org);
        _bsOrganisations.ResetBindings(false);
        _bsOrganisations.Position = _bsOrganisations.Count - 1;
        _appState.MarkDirty();
    }

    private void btnOrganisationsDelete_Click(object? sender, EventArgs e)
    {
        if (_bsOrganisations.Current is not OrganisationRecord org) return;

        var confirm = MessageBox.Show(
            $"Delete organisation '{org.Name}'?\nThis cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _bsOrganisations.RemoveCurrent();
        _appState.MarkDirty();
    }

    private void btnDirectivesAdd_Click(object? sender, EventArgs e)
    {
        var p = _appState.CurrentProject;
        var directive = new DirectiveDefinition { Name = $"Directive {p.Directives.Count + 1}" };
        p.Directives.Add(directive);
        _bsDirectives.ResetBindings(false);
        _bsDirectives.Position = _bsDirectives.Count - 1;
        _appState.MarkDirty();
    }

    private void btnDirectivesDelete_Click(object? sender, EventArgs e)
    {
        if (_bsDirectives.Current is not DirectiveDefinition directive) return;

        var confirm = MessageBox.Show(
            $"Delete directive '{directive.Name}'?\nThis cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _bsDirectives.RemoveCurrent();
        _appState.MarkDirty();
    }

    // â”€â”€ Thread selection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void gridThreads_SelectionChanged(object? sender, EventArgs e)
    {
        // _bsThreads.Current tracks the selected DataGridView row via BindingSource sync.
        var thread = _bsThreads.Current as StoryThreadRecord;
        _bsThreadBeats.DataSource = thread?.Beats;
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
            Name = $"Episode {p.Episodes.Count + 1}",
            SeriesId = seriesId,
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

        var p = _appState.CurrentProject;
        var opts = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };

        // Deep copy the series record and give it a fresh identity
        var seriesJson = JsonSerializer.Serialize(series, opts);
        var copySeries = JsonSerializer.Deserialize<PodcastSeriesRecord>(seriesJson, opts)!;
        copySeries.Id = Guid.NewGuid().ToString();
        copySeries.CreatedUtc = DateTime.UtcNow;
        copySeries.ModifiedUtc = DateTime.UtcNow;
        copySeries.Name = string.IsNullOrWhiteSpace(series.Name) ? "Series Copy" : $"{series.Name} Copy";
        copySeries.EpisodeIds = new List<string>(); // rebuilt by SyncSeriesEpisodeIds below

        // Duplicate every episode in the original series, preserving their order in p.Episodes
        var originalEpisodes = p.Episodes
            .Where(ep => ep.SeriesId == series.Id)
            .ToList();

        foreach (var origEp in originalEpisodes)
        {
            var epJson = JsonSerializer.Serialize(origEp, opts);
            var copyEp = JsonSerializer.Deserialize<EpisodeRecord>(epJson, opts)!;
            copyEp.Id = Guid.NewGuid().ToString();
            copyEp.CreatedUtc = DateTime.UtcNow;
            copyEp.ModifiedUtc = DateTime.UtcNow;
            copyEp.IsCanonicalLocked = false;
            copyEp.SeriesId = copySeries.Id;

            // Reset every entry to a clean manual draft
            foreach (var entry in copyEp.Entries)
            {
                entry.Id = Guid.NewGuid().ToString();
                entry.CreatedUtc = DateTime.UtcNow;
                entry.ModifiedUtc = DateTime.UtcNow;
                entry.SourceType = EntrySourceType.Manual;
                entry.IsLocked = false;
                entry.IsCanon = false;
                entry.RandomSeed = null;
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
            Name = $"Traffic {trafficCount + 1}",
            SortOrder = ep.Entries.Count,
            EntryKind = EntryKind.Traffic,
            SourceType = EntrySourceType.Manual,
            StationId = ResolveDefaultStationId(ep),
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
            Name = $"Notice {noticeCount + 1}",
            SortOrder = ep.Entries.Count,
            EntryKind = EntryKind.Notice,
            SourceType = EntrySourceType.Manual,
            // Traffic-only fields intentionally left null
            RenderOptions = new EntryRenderOptions
            {
                IncludePurpose = false,
                IncludeCargo = false,
                IncludePassengers = false,
                IncludeManifestStatus = false,
                IncludeInspectionStatus = false,
                IncludeEnvironmentalStatus = false,
                IncludeResolution = true   // resolution phrase still useful for notices
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
        if (_bsEntries.Current is not EpisodeEntryRecord original) return;

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
        copy.Id = Guid.NewGuid().ToString();
        copy.CreatedUtc = DateTime.UtcNow;
        copy.ModifiedUtc = DateTime.UtcNow;

        // Reset generation / lock state so the duplicate starts as a clean draft
        copy.SourceType = EntrySourceType.Manual;
        copy.IsLocked = false;
        copy.IsCanon = false;
        copy.RandomSeed = null;

        // Name
        copy.Name = string.IsNullOrWhiteSpace(original.Name)
            ? $"{original.EntryKind} Copy"
            : $"{original.Name} Copy";

        // Insert immediately after the original in the canonical list
        int originalIdx = ep.Entries.IndexOf(original);
        int insertIdx = originalIdx >= 0 ? originalIdx + 1 : ep.Entries.Count;
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
        if (_bsEntries.Current is not EpisodeEntryRecord entry) return;

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
        int idx = list.IndexOf(entry);
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

        int? seed = ParseGenerationSeed();
        var entry = _generator.GenerateEntry(_appState.CurrentProject, seed);
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

        int count = (int)numGenerateEntryCount.Value;
        bool clearFirst = chkClearEpisodeBeforeGenerate.Checked;
        int? seed = ParseGenerationSeed();

        if (clearFirst)
        {
            bool hasLocked = ep.Entries.Any(x => x.IsLocked || x.IsCanon);
            string msg = hasLocked
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

        int? seed = ParseGenerationSeed() ?? existing.RandomSeed;
        int sortOrder = existing.SortOrder;
        int idx = ep.Entries.IndexOf(existing);
        bool editMode = chkRegenerateWithoutAdvancingThread.Checked;

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
        var result = _validator.Validate(_appState.CurrentProject);
        int errors = result.Messages.Count(m => m.Severity == ValidationSeverity.Error);
        int warnings = result.Messages.Count(m => m.Severity == ValidationSeverity.Warning);

        if (errors > 0)
        {
            var messages = new BindingList<ValidationMessage>(result.Messages);
            _bsValidation.DataSource = messages;
            gridValidationMessages.DataSource = _bsValidation;
            tabMain.SelectedTab = tabValidation;
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
        var result = _validator.Validate(_appState.CurrentProject);
        var messages = new BindingList<ValidationMessage>(result.Messages);

        _bsValidation.DataSource = messages;
        gridValidationMessages.DataSource = _bsValidation;
        tabMain.SelectedTab = tabValidation;

        int errors = result.Messages.Count(m => m.Severity == ValidationSeverity.Error);
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

    private void btnNewProject_Click(object? sender, EventArgs e) => mnuFileNew_Click(sender, e);
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
                Filter = ProjectFileService.FileFilter,
                Title = "Save Project",
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
        _bsReferenceItems.DataSource = GetReferenceCollection(opt.Key);
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
            "OperationTypes" => p.OperationTypes,
            "VesselClasses" => p.VesselClasses,
            "Purposes" => p.Purposes,
            "ManifestStatuses" => p.ManifestStatuses,
            "InspectionStatuses" => p.InspectionStatuses,
            "ClearanceStatuses" => p.ClearanceStatuses,
            "EnvironmentalConditions" => p.EnvironmentalConditions,
            "NoticeTypes" => p.NoticeTypes,
            "PassengerCategories" => p.PassengerCategories,
            "CommodityCategories" => p.CommodityCategories,
            "StationTypes" => p.StationTypes,
            "AuthorityTypes" => p.AuthorityTypes,
            "AnomalyTypes" => p.AnomalyTypes,
            "PhraseTemplates" => p.PhraseTemplates,
            "Directives" => p.Directives,
            "BodyTypes" => p.BodyTypes,
            "OrganisationTypes" => p.OrganisationTypes,
            _ => null
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
            "OperationTypes" => new OperationTypeDefinition { Name = "New Operation Type", Code = code },
            "VesselClasses" => new VesselClassDefinition { Name = "New Vessel Class", Code = code },
            "Purposes" => new PurposeDefinition { Name = "New Purpose", Code = code },
            "ManifestStatuses" => new ManifestStatusDefinition { Name = "New Manifest Status", Code = code },
            "InspectionStatuses" => new InspectionStatusDefinition { Name = "New Inspection Status", Code = code },
            "ClearanceStatuses" => new ClearanceStatusDefinition { Name = "New Clearance Status", Code = code },
            "EnvironmentalConditions" => new EnvironmentalConditionDefinition { Name = "New Environmental Condition", Code = code },
            "NoticeTypes" => new NoticeTypeDefinition { Name = "New Notice Type", Code = code },
            "PassengerCategories" => new PassengerCategoryDefinition { Name = "New Passenger Category", Code = code },
            "CommodityCategories" => new CommodityCategoryDefinition { Name = "New Commodity Category", Code = code },
            "StationTypes" => new StationTypeDefinition { Name = "New Station Type", Code = code },
            "AuthorityTypes" => new AuthorityTypeDefinition { Name = "New Authority Type", Code = code },
            "AnomalyTypes" => new AnomalyTypeDefinition { Name = "New Anomaly Type", Code = code },
            "PhraseTemplates" => new PhraseTemplate { Name = "New Phrase Template", Code = code },
            "Directives" => new DirectiveDefinition { Name = "New Directive", Code = code },
            "BodyTypes" => new BodyTypeDefinition { Name = "New Body Type", Code = code },
            "OrganisationTypes" => new OrganisationTypeDefinition { Name = "New Organisation Type", Code = code },
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
            "OperationTypes" => "new-operation-type",
            "VesselClasses" => "new-vessel-class",
            "Purposes" => "new-purpose",
            "ManifestStatuses" => "new-manifest-status",
            "InspectionStatuses" => "new-inspection-status",
            "ClearanceStatuses" => "new-clearance-status",
            "EnvironmentalConditions" => "new-environmental-condition",
            "NoticeTypes" => "new-notice-type",
            "PassengerCategories" => "new-passenger-category",
            "CommodityCategories" => "new-commodity-category",
            "StationTypes" => "new-station-type",
            "AuthorityTypes" => "new-authority-type",
            "AnomalyTypes" => "new-anomaly-type",
            "PhraseTemplates" => "new-phrase-template",
            "Directives" => "new-directive",
            "BodyTypes" => "new-body-type",
            "OrganisationTypes" => "new-organisation-type",
            _ => "new-item"
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
            g.CellValueChanged += (_, _) => _appState.MarkDirty();
            g.UserAddedRow += (_, _) => _appState.MarkDirty();
            g.UserDeletedRow += (_, _) => _appState.MarkDirty();
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
        cboEntryKind.DataSource = Enum.GetValues<EntryKind>();
        cboEntrySourceType.DataSource = Enum.GetValues<EntrySourceType>();

        // Project data combos
        SetLookupDataSource(cboEntryOperationType, _lookup.OperationTypesAsLookup());
        SetLookupDataSource(cboEntryNoticeType, _lookup.NoticeTypesAsLookup());
        SetLookupDataSource(cboEntryStation, _lookup.StationsAsLookup());
        SetLookupDataSource(cboEntryDock, _lookup.DocksAsLookup());
        SetLookupDataSource(cboEntryOriginStation, _lookup.StationsAsLookup());
        SetLookupDataSource(cboEntryDestinationStation, _lookup.StationsAsLookup());
        SetLookupDataSource(cboEntryVessel, _lookup.VesselsAsLookup());
        SetLookupDataSource(cboEntryVesselClassOverride, _lookup.VesselClassesAsLookup());
        SetLookupDataSource(cboEntryDeclaredPurpose, _lookup.PurposesAsLookup());
        SetLookupDataSource(cboEntryActualPurpose, _lookup.PurposesAsLookup());
        SetLookupDataSource(cboEntryManifestStatus, _lookup.ManifestStatusesAsLookup());
        SetLookupDataSource(cboEntryInspectionStatus, _lookup.InspectionStatusesAsLookup());
        SetLookupDataSource(cboEntryClearanceStatus, _lookup.ClearanceStatusesAsLookup());
        SetLookupDataSource(cboEntryEnvironmentalCondition, _lookup.EnvironmentalConditionsAsLookup());
        SetLookupDataSource(cboEntryDirective, _lookup.DirectivesAsLookup());
        SetLookupDataSource(cboEntryIncidentPhrase, _lookup.PhraseTemplatesAsLookup("incident"));
        SetLookupDataSource(cboEntryResolutionPhrase, _lookup.PhraseTemplatesAsLookup("resolution"));
        SetLookupDataSource(cboEntryRouteStatusPhrase, _lookup.PhraseTemplatesAsLookup("route_status"));
        SetLookupDataSource(cboEntryStoryThread, _lookup.StoryThreadsAsLookup());
        SetLookupDataSource(cboEntryAnomalySeverity, _lookup.SeverityLevelsAsLookup());

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
        SetLookupDataSource(cboEntryFilterVessel, AsFilterList(_lookup.VesselsAsLookup()));
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

            cboEntryKind.SelectedItem = entry.EntryKind;
            cboEntrySourceType.SelectedItem = entry.SourceType;
            txtEntryName.Text = entry.Name;
            numEntrySortOrder.Value = entry.SortOrder;
            chkEntryLocked.Checked = entry.IsLocked;
            chkEntryCanon.Checked = entry.IsCanon;
            numEntryRandomSeed.Value = entry.RandomSeed ?? 0;
            txtEntryNotes.Text = entry.Notes;

            SetLookupCombo(cboEntryOperationType, entry.OperationTypeId);
            SetLookupCombo(cboEntryNoticeType, entry.NoticeTypeId);
            SetLookupCombo(cboEntryStation, entry.StationId);
            SetLookupCombo(cboEntryDock, entry.DockId);
            SetLookupCombo(cboEntryOriginStation, entry.OriginStationId);
            SetLookupCombo(cboEntryDestinationStation, entry.DestinationStationId);
            SetLookupCombo(cboEntryVessel, entry.VesselId);
            SetLookupCombo(cboEntryVesselClassOverride, entry.VesselClassOverrideId);
            txtEntryRegistryOverride.Text = entry.RegistryOverride ?? string.Empty;
            SetLookupCombo(cboEntryDeclaredPurpose, entry.DeclaredPurposeId);
            SetLookupCombo(cboEntryActualPurpose, entry.ActualPurposeId);
            SetLookupCombo(cboEntryManifestStatus, entry.ManifestStatusId);
            SetLookupCombo(cboEntryInspectionStatus, entry.InspectionStatusId);
            SetLookupCombo(cboEntryClearanceStatus, entry.ClearanceStatusId);
            SetLookupCombo(cboEntryEnvironmentalCondition, entry.EnvironmentalConditionId);
            SetLookupCombo(cboEntryDirective, entry.DirectiveId);
            SetLookupCombo(cboEntryIncidentPhrase, entry.IncidentPhraseTemplateId);
            SetLookupCombo(cboEntryResolutionPhrase, entry.ResolutionPhraseTemplateId);
            SetLookupCombo(cboEntryRouteStatusPhrase, entry.RouteStatusPhraseTemplateId);
            txtEntryPublicBodyOverride.Text = entry.PublicBodyOverride ?? string.Empty;

            // Story thread â€” refresh beats first, then set beat
            var thread = string.IsNullOrEmpty(entry.StoryThreadId) ? null
                : _appState.CurrentProject.StoryThreads.FirstOrDefault(t => t.Id == entry.StoryThreadId);
            SetLookupCombo(cboEntryStoryThread, entry.StoryThreadId);
            RefreshBeatsCbo(thread);
            SetLookupCombo(cboEntryAppliedStoryBeat, entry.AppliedStoryBeatId);

            SetLookupCombo(cboEntryAnomalySeverity, entry.AnomalySeverity?.ToString());

            txtEntryHiddenTruthNotes.Text = entry.HiddenTruthNotes ?? string.Empty;

            bool hasSchedule = entry.ScheduledUtc.HasValue;
            chkEntryScheduledEnabled.Checked = hasSchedule;
            dtpEntryScheduledUtc.Enabled = hasSchedule;
            dtpEntryScheduledUtc.Value = entry.ScheduledUtc ?? DateTime.UtcNow;

            pnlEntryDetail.Enabled = true;
            ApplyEntryKindLayout(entry.EntryKind);

            // Manifest grids â€” BindingList wraps actual list by reference so grid edits flow through
            _bsDeclaredCargo.DataSource = new BindingList<EntryCargoLine>(entry.DeclaredCargo);
            gridDeclaredCargo.DataSource = _bsDeclaredCargo;
            _bsActualCargo.DataSource = new BindingList<EntryCargoLine>(entry.ActualCargo);
            gridActualCargo.DataSource = _bsActualCargo;
            _bsDeclaredPassengers.DataSource = new BindingList<EntryPassengerLine>(entry.DeclaredPassengers);
            gridDeclaredPassengers.DataSource = _bsDeclaredPassengers;
            _bsActualPassengers.DataSource = new BindingList<EntryPassengerLine>(entry.ActualPassengers);
            gridActualPassengers.DataSource = _bsActualPassengers;
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

            _bsDeclaredCargo.DataSource = null;
            gridDeclaredCargo.DataSource = null;
            _bsActualCargo.DataSource = null;
            gridActualCargo.DataSource = null;
            _bsDeclaredPassengers.DataSource = null;
            gridDeclaredPassengers.DataSource = null;
            _bsActualPassengers.DataSource = null;
            gridActualPassengers.DataSource = null;
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
        bool isNotice = kind == EntryKind.Notice;

        // Traffic-only fields
        cboEntryOperationType.Enabled = isTraffic;
        cboEntryStation.Enabled = isTraffic;
        cboEntryDock.Enabled = isTraffic;
        cboEntryOriginStation.Enabled = isTraffic;
        cboEntryDestinationStation.Enabled = isTraffic;
        cboEntryVessel.Enabled = isTraffic;
        cboEntryVesselClassOverride.Enabled = isTraffic;
        txtEntryRegistryOverride.Enabled = isTraffic;
        cboEntryDeclaredPurpose.Enabled = isTraffic;
        cboEntryActualPurpose.Enabled = isTraffic;
        cboEntryManifestStatus.Enabled = isTraffic;
        cboEntryInspectionStatus.Enabled = isTraffic;
        cboEntryClearanceStatus.Enabled = isTraffic;
        cboEntryEnvironmentalCondition.Enabled = isTraffic;
        cboEntryDirective.Enabled = isTraffic;
        cboEntryRouteStatusPhrase.Enabled = isTraffic;
        gridDeclaredCargo.Enabled = isTraffic;
        btnDeclaredCargoAdd.Enabled = isTraffic;
        btnDeclaredCargoDelete.Enabled = isTraffic;
        gridActualCargo.Enabled = isTraffic;
        btnActualCargoAdd.Enabled = isTraffic;
        btnActualCargoDelete.Enabled = isTraffic;
        gridDeclaredPassengers.Enabled = isTraffic;
        btnDeclaredPassengerAdd.Enabled = isTraffic;
        btnDeclaredPassengerDelete.Enabled = isTraffic;
        gridActualPassengers.Enabled = isTraffic;
        btnActualPassengerAdd.Enabled = isTraffic;
        btnActualPassengerDelete.Enabled = isTraffic;

        // Notice-only fields
        cboEntryNoticeType.Enabled = isNotice;
        txtEntryPublicBodyOverride.Enabled = isNotice;

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
                Text = "âš  " + message,
                AutoSize = true,
                Margin = new Padding(0, 1, 0, 1),
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

        WireLookupCombo(cboEntryOperationType, (e, id) => e.OperationTypeId = id, updatePreview: true);
        WireLookupCombo(cboEntryNoticeType, (e, id) => e.NoticeTypeId = id, updatePreview: true);
        WireLookupCombo(cboEntryStation, (e, id) => e.StationId = id, updatePreview: true);
        WireLookupCombo(cboEntryDock, (e, id) => e.DockId = id, updatePreview: true);
        WireLookupCombo(cboEntryOriginStation, (e, id) => e.OriginStationId = id, updatePreview: true);
        WireLookupCombo(cboEntryDestinationStation, (e, id) => e.DestinationStationId = id, updatePreview: true);
        WireLookupCombo(cboEntryVessel, (e, id) => e.VesselId = id, updatePreview: true);
        WireLookupCombo(cboEntryVesselClassOverride, (e, id) => e.VesselClassOverrideId = id, updatePreview: true);
        WireLookupCombo(cboEntryDeclaredPurpose, (e, id) => e.DeclaredPurposeId = id, updatePreview: true);
        WireLookupCombo(cboEntryActualPurpose, (e, id) => e.ActualPurposeId = id, updatePreview: true);
        WireLookupCombo(cboEntryManifestStatus, (e, id) => e.ManifestStatusId = id, updatePreview: true);
        WireLookupCombo(cboEntryInspectionStatus, (e, id) => e.InspectionStatusId = id, updatePreview: true);
        WireLookupCombo(cboEntryClearanceStatus, (e, id) => e.ClearanceStatusId = id, updatePreview: true);
        WireLookupCombo(cboEntryEnvironmentalCondition, (e, id) => e.EnvironmentalConditionId = id, updatePreview: true);
        WireLookupCombo(cboEntryDirective, (e, id) => e.DirectiveId = id, updatePreview: true);
        WireLookupCombo(cboEntryIncidentPhrase, (e, id) => e.IncidentPhraseTemplateId = id, updatePreview: true);
        WireLookupCombo(cboEntryResolutionPhrase, (e, id) => e.ResolutionPhraseTemplateId = id, updatePreview: true);
        WireLookupCombo(cboEntryRouteStatusPhrase, (e, id) => e.RouteStatusPhraseTemplateId = id, updatePreview: true);
        WireLookupCombo(cboEntryAppliedStoryBeat, (e, id) => e.AppliedStoryBeatId = id, updatePreview: true);

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
            e.StoryThreadId = threadId;
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
        cbo.DataSource = null;
        cbo.DisplayMember = string.Empty;
        cbo.ValueMember = string.Empty;
        cbo.DataSource = items;
        cbo.DisplayMember = "Display";
        cbo.ValueMember = "Id";
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
        copy.Id = Guid.NewGuid().ToString();
        copy.CreatedUtc = DateTime.UtcNow;
        copy.ModifiedUtc = DateTime.UtcNow;
        copy.IsCanonicalLocked = false;
        copy.Name = string.IsNullOrWhiteSpace(ep.Name)
            ? "Episode Copy"
            : $"{ep.Name} Copy";

        // SeriesId is preserved from the JSON copy â€” duplicate stays in the same series.

        // Reset every entry to a clean manual draft.
        foreach (var entry in copy.Entries)
        {
            entry.Id = Guid.NewGuid().ToString();
            entry.CreatedUtc = DateTime.UtcNow;
            entry.ModifiedUtc = DateTime.UtcNow;
            entry.SourceType = EntrySourceType.Manual;
            entry.IsLocked = false;
            entry.IsCanon = false;
            entry.RandomSeed = null;
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
            entry.IsCanon = true;
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
            Name = $"Episode {p.Episodes.Count + 1}",
            SeriesId = seriesId,
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
            SetLookupCombo(cboEntryFilterVessel, null);
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

        bool lockedOnly = chkShowLockedOnly.Checked;
        string? kindStr = cboEntryFilterKind.SelectedIndex > 0
            ? cboEntryFilterKind.SelectedItem?.ToString()
            : null;
        string? search = string.IsNullOrWhiteSpace(txtEntrySearch.Text)
            ? null
            : txtEntrySearch.Text.Trim();
        string? vesselId = GetSelectedLookupId(cboEntryFilterVessel);
        string? stationId = GetSelectedLookupId(cboEntryFilterStation);

        _entriesView.RaiseListChangedEvents = false;
        _entriesView.Clear();
        if (ep != null)
        {
            foreach (var entry in ep.Entries)
            {
                if (lockedOnly && !entry.IsLocked && !entry.IsCanon) continue;
                if (kindStr != null && entry.EntryKind.ToString() != kindStr) continue;
                if (search != null && !entry.Name.Contains(search, StringComparison.OrdinalIgnoreCase)) continue;
                if (vesselId != null && entry.VesselId != vesselId) continue;
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
        var nextBeat = thread.Beats.FirstOrDefault(b =>
            b.StageIndex == thread.CurrentStageIndex + 1);

        var sb = new System.Text.StringBuilder();

        // Show lock/canon state of this entry prominently
        string entryFlags = (entry.IsCanon, entry.IsLocked) switch
        {
            (true, true) => "  [CANON | LOCKED]",
            (true, false) => "  [CANON]",
            (false, true) => "  [LOCKED]",
            _ => string.Empty
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

        int canonCount = ep.Entries.Count(e => e.IsCanon);
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

    private void SetupSystemsBodiesColumns()
    {
        if (_lookup == null) return;

        var starSystems  = _lookup.StarSystemsAsLookup();
        var bodyTypes    = _lookup.BodyTypesAsLookup();
        var parentBodies = _lookup.BodiesAsLookup();

        // Star Systems
        gridStarSystems.AutoGenerateColumns = false;
        gridStarSystems.Columns.Clear();
        gridStarSystems.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { Name = "colStarSystemName",       HeaderText = "Name",        DataPropertyName = "Name",       Width = 160 },
            new DataGridViewTextBoxColumn { Name = "colStarSystemRegionName", HeaderText = "Region Name", DataPropertyName = "RegionName", Width = 160 },
        });

        // Celestial Bodies
        gridCelestialBodies.AutoGenerateColumns = false;
        gridCelestialBodies.Columns.Clear();
        gridCelestialBodies.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn  { Name = "colBodyName",       HeaderText = "Name",        DataPropertyName = "Name",        Width = 160 },
            new DataGridViewComboBoxColumn { Name = "colBodyStarSystem", HeaderText = "Star System", DataPropertyName = "StarSystemId", DataSource = starSystems,  DisplayMember = "Display", ValueMember = "Id", Width = 140 },
            new DataGridViewComboBoxColumn { Name = "colBodyParent",     HeaderText = "Parent Body", DataPropertyName = "ParentBodyId", DataSource = parentBodies, DisplayMember = "Display", ValueMember = "Id", Width = 140 },
            new DataGridViewComboBoxColumn { Name = "colBodyType",       HeaderText = "Body Type",   DataPropertyName = "BodyTypeId",   DataSource = bodyTypes,    DisplayMember = "Display", ValueMember = "Id", Width = 120 },
        });
    }

    private void SetupStationsDockColumns()
    {
        if (_lookup == null) return;

        var stationTypes = _lookup.StationTypesAsLookup();
        var starSystems  = _lookup.StarSystemsAsLookup();
        var bodies       = _lookup.BodiesAsLookup();

        gridStations.AutoGenerateColumns = false;
        gridStations.Columns.Clear();
        gridStations.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn  { Name = "colStationName",       HeaderText = "Name",           DataPropertyName = "Name",            Width = 160 },
            new DataGridViewComboBoxColumn { Name = "colStationTypeId",     HeaderText = "Station Type",   DataPropertyName = "StationTypeId",   DataSource = stationTypes, DisplayMember = "Display", ValueMember = "Id", Width = 130 },
            new DataGridViewComboBoxColumn { Name = "colStationStarSystem", HeaderText = "Star System",    DataPropertyName = "StarSystemId",    DataSource = starSystems,  DisplayMember = "Display", ValueMember = "Id", Width = 130 },
            new DataGridViewComboBoxColumn { Name = "colStationBody",       HeaderText = "Celestial Body", DataPropertyName = "CelestialBodyId", DataSource = bodies,       DisplayMember = "Display", ValueMember = "Id", Width = 140 },
        });
    }

    /// <summary>
    /// Wires StarSystem/CelestialBody consistency checks to gridStations.
    /// Called once from MainForm_Load. Uses column names set by SetupStationsDockColumns.
    /// </summary>
    private void HookStationsGridConsistency()
    {
        // 1. When StarSystem changes, clear CelestialBodyId if it belongs to a different system.
        gridStations.CellValueChanged += (_, e) =>
        {
            if (e.RowIndex < 0) return;
            if (gridStations.Columns[e.ColumnIndex]?.Name != "colStationStarSystem") return;
            if (_bsStations[e.RowIndex] is not StationRecord station) return;
            if (string.IsNullOrEmpty(station.CelestialBodyId)) return;

            var body = _appState.CurrentProject.CelestialBodies
                .FirstOrDefault(b => b.Id == station.CelestialBodyId);
            if (body == null || body.StarSystemId == station.StarSystemId) return;

            station.CelestialBodyId = null;
            // Refresh only this row so the combo reflects the cleared value.
            gridStations.InvalidateRow(e.RowIndex);
            _bsStations.ResetItem(e.RowIndex);
        };

        // 2. Validate that CelestialBody belongs to the same StarSystem before committing.
        gridStations.CellValidating += (_, e) =>
        {
            if (e.RowIndex < 0) return;
            if (gridStations.Columns[e.ColumnIndex]?.Name != "colStationBody") return;

            var newBodyId = e.FormattedValue as string;
            if (string.IsNullOrEmpty(newBodyId)) return;
            if (_bsStations[e.RowIndex] is not StationRecord station) return;
            if (string.IsNullOrEmpty(station.StarSystemId)) return;

            var body = _appState.CurrentProject.CelestialBodies
                .FirstOrDefault(b => b.Id == newBodyId);
            if (body == null || body.StarSystemId == station.StarSystemId) return;

            var sys = _appState.CurrentProject.StarSystems
                .FirstOrDefault(s => s.Id == station.StarSystemId);
            var sysName = sys?.Name ?? station.StarSystemId;
            MessageBox.Show(
                $"The selected body belongs to a different star system.\n" +
                $"Station star system: {sysName}",
                "System Mismatch",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        };

        // 3. Filter CelestialBody dropdown to only show bodies in the row's current StarSystem.
        gridStations.EditingControlShowing += (_, e) =>
        {
            if (gridStations.CurrentCell == null) return;
            if (gridStations.Columns[gridStations.CurrentCell.ColumnIndex]?.Name != "colStationBody") return;
            if (e.Control is not ComboBox combo) return;
            if (_lookup == null) return;

            var rowIndex = gridStations.CurrentCell.RowIndex;
            if (rowIndex < 0 || rowIndex >= _bsStations.Count) return;
            if (_bsStations[rowIndex] is not StationRecord station) return;

            List<LookupItem> filtered;
            if (string.IsNullOrEmpty(station.StarSystemId))
            {
                filtered = _lookup.BodiesAsLookup();
            }
            else
            {
                var matchingBodies = _appState.CurrentProject.CelestialBodies
                    .Where(b => b.StarSystemId == station.StarSystemId)
                    .Select(b => new LookupItem(b.Id, b.Name))
                    .ToList();
                filtered = new List<LookupItem> { LookupItem.None }.Concat(matchingBodies).ToList();
            }

            combo.DataSource    = filtered;
            combo.DisplayMember = "Display";
            combo.ValueMember   = "Id";
        };
    }

    private void SetupManifestGridColumns()
    {
        if (_lookup == null) return;

        var commodities = _lookup.CommoditiesAsLookup();
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
        SetLookupDataSource(cboEpisodeSeries, _lookup.SeriesAsLookup());
        SetLookupDataSource(cboSeriesBroadcastStation, _lookup.StationsAsLookup());
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
                pnlEpisodeMetaEditor.Enabled = false;
                txtEpisodeName.Text = string.Empty;
                chkEpisodeHasInUniverseDate.Checked = false;
                dtpEpisodeInUniverseUtc.Enabled = false;
                dtpEpisodeInUniverseUtc.Value = DateTime.Now;
                SetLookupCombo(cboEpisodeBroadcastStation, null);
                SetLookupCombo(cboEpisodeSeries, null);
                chkEpisodeCanonicalLocked.Checked = false;
                txtEpisodeNotes.Text = string.Empty;
                return;
            }

            pnlEpisodeMetaEditor.Enabled = true;
            if (txtEpisodeName.Text != ep.Name)
                txtEpisodeName.Text = ep.Name;

            bool hasDate = ep.InUniverseUtc.HasValue;
            chkEpisodeHasInUniverseDate.Checked = hasDate;
            dtpEpisodeInUniverseUtc.Enabled = hasDate;
            dtpEpisodeInUniverseUtc.Value = ep.InUniverseUtc ?? DateTime.UtcNow;

            SetLookupCombo(cboEpisodeBroadcastStation, ep.BroadcastStationId);
            SetLookupCombo(cboEpisodeSeries, ep.SeriesId);
            chkEpisodeCanonicalLocked.Checked = ep.IsCanonicalLocked;
            txtEpisodeNotes.Text = ep.Notes;
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

        string text = _exportService.ExportEpisodeAsBroadcastText(_appState.CurrentProject, ep);
        string defaultName = SanitizeFilename(ep.Name) + "_broadcast.txt";

        if (SaveExportToFile(text, defaultName, "Text Files|*.txt|All Files|*.*"))
            SetStatus($"Broadcast script exported: {defaultName}");

        // Preview the export in the Output Preview tab
        txtRenderedOutput.Text = text;
        tabMain.SelectedTab = tabOutputPreview;
    }

    private void btnExportEpisodeTts_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        var options = new TtsExportOptions
        {
            IncludeEpisodeHeader = chkExportIncludeHeader.Checked,
            BlankLineBetweenEntries = chkExportBlankLineBetweenEntries.Checked,
            StripVisualSeparators = true,   // always strip for TTS
            OneEntryPerParagraph = true,   // always join for TTS
            IncludeEntryMarkers = chkExportIncludeEntryMarkers.Checked
        };

        string text = _exportService.ExportEpisodeAsTtsText(_appState.CurrentProject, ep, options);
        string defaultName = SanitizeFilename(ep.Name) + "_tts.txt";

        if (SaveExportToFile(text, defaultName, "Text Files|*.txt|All Files|*.*"))
            SetStatus($"TTS script exported: {defaultName}");

        txtRenderedOutput.Text = text;
        tabMain.SelectedTab = tabOutputPreview;
    }

    private void btnExportEpisodeJson_Click(object? sender, EventArgs e)
    {
        if (_bsEpisodes.Current is not EpisodeRecord ep) return;

        bool debugMode = chkExportAuthorDebugMode.Checked;
        var options = new JsonExportOptions
        {
            IncludeHiddenTruth = debugMode,
            IncludeRenderedText = true,
            IncludeGenerationMetadata = debugMode
        };

        string json = _exportService.ExportEpisodeAsJson(_appState.CurrentProject, ep, options);
        string suffix = debugMode ? "_debug.json" : "_export.json";
        string defaultName = SanitizeFilename(ep.Name) + suffix;

        if (SaveExportToFile(json, defaultName, "JSON Files|*.json|All Files|*.*"))
            SetStatus($"JSON exported: {defaultName}{(debugMode ? " [debug mode â€” contains hidden truth]" : string.Empty)}");

        txtRenderedOutput.Text = json;
        tabMain.SelectedTab = tabOutputPreview;
    }

    /// <summary>
    /// Opens a SaveFileDialog, writes content as UTF-8, and returns true on success.
    /// </summary>
    private bool SaveExportToFile(string content, string defaultFilename, string filter)
    {
        using var dlg = new SaveFileDialog
        {
            Filter = filter,
            Title = "Export",
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

        string lockFlag = entry.IsLocked ? " [LOCKED]" : string.Empty;
        string canonFlag = entry.IsCanon ? " [CANON]" : string.Empty;
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


### File: PodcastUniverseEditor\UI\Forms\MainForm.Designer.cs
```csharp

namespace PodcastUniverseEditor.UI.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    /// <summary>
    /// Designer-managed shell.
    /// Declares and configures: MenuStrip, ToolStrip, StatusStrip, TabControl, TabPages.
    /// Tab content is intentionally absent here â€” it is populated by InitializeTabContent(),
    /// which is called from the MainForm constructor after this method completes.
    /// Keeping this method flat (no helper calls) ensures the WinForms Designer can parse it.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        // â”€â”€ Declare all shell controls (all new() calls first â€” WinForms Designer convention)

        menuMain = new MenuStrip();
        mnuFile = new ToolStripMenuItem();
        mnuFileNew = new ToolStripMenuItem();
        mnuFileOpen = new ToolStripMenuItem();
        mnuFileSave = new ToolStripMenuItem();
        mnuFileSaveAs = new ToolStripMenuItem();
        mnuFileExit = new ToolStripMenuItem();

        toolMain = new ToolStrip();
        btnNewProject = new ToolStripButton();
        btnOpenProject = new ToolStripButton();
        btnSaveProject = new ToolStripButton();

        statusMain = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        lblCurrentFile = new ToolStripStatusLabel();

        tabMain = new TabControl();
        tabOverview = new TabPage();
        tabReferenceData = new TabPage();
        tabSystemsBodies = new TabPage();
        tabStationsDocks = new TabPage();
        tabRoutes = new TabPage();
        tabCommodities = new TabPage();
        tabOrganisationsDirectives = new TabPage();
        tabVessels = new TabPage();
        tabThreads = new TabPage();
        tabEpisodes = new TabPage();
        tabOutputPreview = new TabPage();
        tabValidation = new TabPage();

        SuspendLayout();

        // â”€â”€ MenuStrip â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        menuMain.Name = "menuMain";

        mnuFile.Name = "mnuFile";
        mnuFile.Text = "&File";

        mnuFileNew.Name = "mnuFileNew";
        mnuFileNew.Text = "&New Project\tCtrl+N";
        mnuFileNew.ShortcutKeys = Keys.Control | Keys.N;
        mnuFileNew.Click += mnuFileNew_Click;

        mnuFileOpen.Name = "mnuFileOpen";
        mnuFileOpen.Text = "&Open...\tCtrl+O";
        mnuFileOpen.ShortcutKeys = Keys.Control | Keys.O;
        mnuFileOpen.Click += mnuFileOpen_Click;

        mnuFileSave.Name = "mnuFileSave";
        mnuFileSave.Text = "&Save\tCtrl+S";
        mnuFileSave.ShortcutKeys = Keys.Control | Keys.S;
        mnuFileSave.Click += mnuFileSave_Click;

        mnuFileSaveAs.Name = "mnuFileSaveAs";
        mnuFileSaveAs.Text = "Save &As...";
        mnuFileSaveAs.Click += mnuFileSaveAs_Click;

        mnuFileExit.Name = "mnuFileExit";
        mnuFileExit.Text = "E&xit";
        mnuFileExit.Click += mnuFileExit_Click;

        mnuFile.DropDownItems.AddRange(new ToolStripItem[]
        {
            mnuFileNew, mnuFileOpen,
            new ToolStripSeparator(),
            mnuFileSave, mnuFileSaveAs,
            new ToolStripSeparator(),
            mnuFileExit
        });
        menuMain.Items.Add(mnuFile);

        // â”€â”€ ToolStrip â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        toolMain.Name = "toolMain";

        btnNewProject.Name = "btnNewProject";
        btnNewProject.Text = "New";
        btnNewProject.ToolTipText = "New Project";
        btnNewProject.Click += btnNewProject_Click;

        btnOpenProject.Name = "btnOpenProject";
        btnOpenProject.Text = "Open";
        btnOpenProject.ToolTipText = "Open Project";
        btnOpenProject.Click += btnOpenProject_Click;

        btnSaveProject.Name = "btnSaveProject";
        btnSaveProject.Text = "Save";
        btnSaveProject.ToolTipText = "Save Project";
        btnSaveProject.Click += btnSaveProject_Click;

        toolMain.Items.AddRange(new ToolStripItem[]
        {
            btnNewProject,
            btnOpenProject,
            new ToolStripSeparator(),
            btnSaveProject
        });

        // â”€â”€ StatusStrip â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        statusMain.Name = "statusMain";

        lblStatus.Name = "lblStatus";
        lblStatus.Text = "Ready";
        lblStatus.Spring = false;

        lblCurrentFile.Name = "lblCurrentFile";
        lblCurrentFile.Text = string.Empty;
        lblCurrentFile.Spring = true;
        lblCurrentFile.TextAlign = ContentAlignment.MiddleRight;

        statusMain.Items.AddRange(new ToolStripItem[] { lblStatus, lblCurrentFile });

        // â”€â”€ TabControl and TabPages â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        tabMain.Name = "tabMain";
        tabMain.Dock = DockStyle.Fill;

        tabOverview.Name = "tabOverview";
        tabOverview.Text = "Overview";
        tabReferenceData.Name = "tabReferenceData";
        tabReferenceData.Text = "Reference Data";
        tabSystemsBodies.Name = "tabSystemsBodies";
        tabSystemsBodies.Text = "Systems & Bodies";
        tabStationsDocks.Name = "tabStationsDocks";
        tabStationsDocks.Text = "Stations & Docks";
        tabRoutes.Name = "tabRoutes";
        tabRoutes.Text = "Routes";
        tabCommodities.Name = "tabCommodities";
        tabCommodities.Text = "Commodities";
        tabOrganisationsDirectives.Name = "tabOrganisationsDirectives";
        tabOrganisationsDirectives.Text = "Orgs & Directives";
        tabVessels.Name = "tabVessels";
        tabVessels.Text = "Vessels";
        tabThreads.Name = "tabThreads";
        tabThreads.Text = "Threads";
        tabEpisodes.Name = "tabEpisodes";
        tabEpisodes.Text = "Episodes";
        tabOutputPreview.Name = "tabOutputPreview";
        tabOutputPreview.Text = "Output Preview";
        tabValidation.Name = "tabValidation";
        tabValidation.Text = "Validation";

        tabMain.TabPages.AddRange(new TabPage[]
        {
            tabOverview, tabReferenceData, tabSystemsBodies, tabStationsDocks,
            tabRoutes, tabCommodities, tabOrganisationsDirectives, tabVessels,
            tabThreads, tabEpisodes, tabOutputPreview, tabValidation
        });

        // â”€â”€ Form â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1280, 800);
        MinimumSize = new Size(900, 600);
        Text = "PodcastUniverseEditor";
        Controls.Add(tabMain);
        Controls.Add(toolMain);
        Controls.Add(menuMain);
        Controls.Add(statusMain);
        MainMenuStrip = menuMain;

        ResumeLayout(false);
        PerformLayout();
    }

    // â”€â”€ Tab content initialisation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Populates each TabPage with its content controls.
    /// Called from the MainForm constructor after InitializeComponent() completes.
    /// Separated so InitializeComponent() remains flat and WinForms Designer-compatible.
    /// Extracted tabs (e.g. ucStationsDocks) create and host their UserControl here.
    /// </summary>
    private void InitializeTabContent()
    {
        InitializeTabOverview();
        InitializeTabReferenceData();
        InitializeTabSystemsBodies();
        InitializeTabStationsDocks();
        InitializeTabRoutes();
        InitializeTabCommodities();
        InitializeTabOrganisationsDirectives();
        InitializeTabVessels();
        InitializeTabThreads();
        InitializeTabEpisodes();
        InitializeTabOutputPreview();
        InitializeTabValidation();
    }

    // â”€â”€ Tab: Overview â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabOverview()
    {
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(12),
            ColumnCount = 2,
            RowCount = 5,
            AutoSize = false
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        layout.Controls.Add(new Label { Text = "Project Name:", Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true }, 0, 0);
        txtProjectName = new TextBox { Name = "txtProjectName", Dock = DockStyle.Fill };
        layout.Controls.Add(txtProjectName, 1, 0);

        layout.Controls.Add(new Label { Text = "Schema Version:", Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true }, 0, 1);
        txtSchemaVersion = new TextBox { Name = "txtSchemaVersion", Dock = DockStyle.Fill, ReadOnly = true };
        layout.Controls.Add(txtSchemaVersion, 1, 1);

        layout.Controls.Add(new Label { Text = "Description:", Anchor = AnchorStyles.Left | AnchorStyles.Top, AutoSize = true }, 0, 2);
        txtProjectDescription = new TextBox { Name = "txtProjectDescription", Dock = DockStyle.Fill, Multiline = true };
        layout.Controls.Add(txtProjectDescription, 1, 2);

        btnLoadSampleProject = new Button { Name = "btnLoadSampleProject", Text = "Load Sample Project", AutoSize = true };
        btnLoadSampleProject.Click += btnLoadSampleProject_Click;
        layout.Controls.Add(btnLoadSampleProject, 1, 3);

        tabOverview.Controls.Add(layout);
    }

    // â”€â”€ Tab: Reference Data â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabReferenceData()
    {
        ucReferenceData = new PodcastUniverseEditor.UI.Controls.ucReferenceData { Dock = DockStyle.Fill };
        lstReferenceTypes = ucReferenceData.ListReferenceTypes;
        gridReferenceItems = ucReferenceData.GridReferenceItems;
        lstReferenceTypes.SelectedIndexChanged += lstReferenceTypes_SelectedIndexChanged;
        ucReferenceData.BtnAdd.Click += btnReferenceAdd_Click;
        ucReferenceData.BtnDelete.Click += btnReferenceDelete_Click;
        tabReferenceData.Controls.Add(ucReferenceData);
    }

    // â”€â”€ Tab: Systems & Bodies â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabSystemsBodies()
    {
        ucSystemsBodies = new PodcastUniverseEditor.UI.Controls.ucSystemsBodies { Dock = DockStyle.Fill };
        gridStarSystems = ucSystemsBodies.GridStarSystems;
        gridCelestialBodies = ucSystemsBodies.GridCelestialBodies;
        ucSystemsBodies.BtnSystemAdd.Click += btnSystemAdd_Click;
        ucSystemsBodies.BtnSystemDelete.Click += btnSystemDelete_Click;
        ucSystemsBodies.BtnBodyAdd.Click += btnBodyAdd_Click;
        ucSystemsBodies.BtnBodyDelete.Click += btnBodyDelete_Click;
        tabSystemsBodies.Controls.Add(ucSystemsBodies);
    }

    // â”€â”€ Tab: Stations & Docks â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabStationsDocks()
    {
        // Tab content is owned by ucStationsDocks. Grid and button fields are assigned here
        // so that the rest of MainForm (binding, dirty-tracking, event handlers) continues to
        // work without requiring any further changes to those call sites.
        ucStationsDocks = new PodcastUniverseEditor.UI.Controls.ucStationsDocks { Dock = DockStyle.Fill };
        gridStations = ucStationsDocks.GridStations;
        gridDocks = ucStationsDocks.GridDocks;
        ucStationsDocks.BtnStationsAdd.Click += btnStationsAdd_Click;
        ucStationsDocks.BtnStationsDelete.Click += btnStationsDelete_Click;
        ucStationsDocks.BtnDocksAdd.Click += btnDocksAdd_Click;
        ucStationsDocks.BtnDocksDelete.Click += btnDocksDelete_Click;
        tabStationsDocks.Controls.Add(ucStationsDocks);
    }

    // â”€â”€ Tab: Routes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabRoutes()
    {
        ucRoutes = new PodcastUniverseEditor.UI.Controls.ucRoutes { Dock = DockStyle.Fill };
        gridRoutes = ucRoutes.GridRoutes;
        tabRoutes.Controls.Add(ucRoutes);
    }

    // â”€â”€ Tab: Commodities â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabCommodities()
    {
        ucCommodities = new PodcastUniverseEditor.UI.Controls.ucCommodities { Dock = DockStyle.Fill };
        gridCommodities = ucCommodities.GridCommodities;
        tabCommodities.Controls.Add(ucCommodities);
    }

    // â”€â”€ Tab: Organisations & Directives â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabOrganisationsDirectives()
    {
        // Tab content is owned by ucOrganisationsDirectives. Grid and button fields are assigned
        // here so that the rest of MainForm (binding, dirty-tracking, event handlers) continues
        // to work without requiring any further changes to those call sites.
        ucOrganisationsDirectives = new PodcastUniverseEditor.UI.Controls.ucOrganisationsDirectives { Dock = DockStyle.Fill };
        gridOrganisations         = ucOrganisationsDirectives.GridOrganisations;
        gridDirectives            = ucOrganisationsDirectives.GridDirectives;
        btnOrganisationsAdd       = ucOrganisationsDirectives.BtnOrganisationsAdd;
        btnOrganisationsDelete    = ucOrganisationsDirectives.BtnOrganisationsDelete;
        btnDirectivesAdd          = ucOrganisationsDirectives.BtnDirectivesAdd;
        btnDirectivesDelete       = ucOrganisationsDirectives.BtnDirectivesDelete;
        ucOrganisationsDirectives.BtnOrganisationsAdd.Click    += btnOrganisationsAdd_Click;
        ucOrganisationsDirectives.BtnOrganisationsDelete.Click += btnOrganisationsDelete_Click;
        ucOrganisationsDirectives.BtnDirectivesAdd.Click       += btnDirectivesAdd_Click;
        ucOrganisationsDirectives.BtnDirectivesDelete.Click    += btnDirectivesDelete_Click;
        tabOrganisationsDirectives.Controls.Add(ucOrganisationsDirectives);
    }

    // â”€â”€ Tab: Vessels â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabVessels()
    {
        ucVessels = new PodcastUniverseEditor.UI.Controls.ucVessels { Dock = DockStyle.Fill };
        gridVessels = ucVessels.GridVessels;
        tabVessels.Controls.Add(ucVessels);
    }

    // â”€â”€ Tab: Threads â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabThreads()
    {
        ucThreads = new PodcastUniverseEditor.UI.Controls.ucThreads { Dock = DockStyle.Fill };
        gridThreads = ucThreads.GridThreads;
        gridThreadBeats = ucThreads.GridThreadBeats;
        gridThreads.SelectionChanged += gridThreads_SelectionChanged;
        tabThreads.Controls.Add(ucThreads);
    }

    // â”€â”€ Tab: Episodes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabEpisodes()
    {
        ucEpisodes = new PodcastUniverseEditor.UI.Controls.Episodes.ucEpisodes { Dock = DockStyle.Fill };

        // â”€â”€ Forward fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lstSeries = ucEpisodes.LstSeries;
        lstEpisodes = ucEpisodes.LstEpisodes;
        gridEpisodeEntries = ucEpisodes.GridEpisodeEntries;
        txtEpisodeEntryPreview = ucEpisodes.TxtEpisodeEntryPreview;
        txtEpisodeSummary = ucEpisodes.TxtEpisodeSummary;
        txtEpisodeSearch = ucEpisodes.TxtEpisodeSearch;
        pnlEntryDetail = ucEpisodes.PnlEntryDetail;
        pnlEpisodeMetaEditor = ucEpisodes.PnlEpisodeMetaEditor;
        flpValidationHints = ucEpisodes.FlpValidationHints;
        numGenerateEntryCount = ucEpisodes.NumGenerateEntryCount;
        chkClearEpisodeBeforeGenerate = ucEpisodes.ChkClearEpisodeBeforeGenerate;
        chkRegenerateWithoutAdvancingThread = ucEpisodes.ChkRegenerateWithoutAdvancingThread;
        txtGenerationSeed = ucEpisodes.TxtGenerationSeed;
        cboEntryFilterKind = ucEpisodes.CboEntryFilterKind;
        txtEntrySearch = ucEpisodes.TxtEntrySearch;
        cboEntryFilterVessel = ucEpisodes.CboEntryFilterVessel;
        cboEntryFilterStation = ucEpisodes.CboEntryFilterStation;
        chkShowLockedOnly = ucEpisodes.ChkShowLockedOnly;
        txtThreadSummary = ucEpisodes.TxtThreadSummary;
        gridDeclaredCargo = ucEpisodes.GridDeclaredCargo;
        gridActualCargo = ucEpisodes.GridActualCargo;
        gridDeclaredPassengers = ucEpisodes.GridDeclaredPassengers;
        gridActualPassengers = ucEpisodes.GridActualPassengers;
        btnDeclaredCargoAdd = ucEpisodes.BtnDeclaredCargoAdd;
        btnDeclaredCargoDelete = ucEpisodes.BtnDeclaredCargoDelete;
        btnActualCargoAdd = ucEpisodes.BtnActualCargoAdd;
        btnActualCargoDelete = ucEpisodes.BtnActualCargoDelete;
        btnDeclaredPassengerAdd = ucEpisodes.BtnDeclaredPassengerAdd;
        btnDeclaredPassengerDelete = ucEpisodes.BtnDeclaredPassengerDelete;
        btnActualPassengerAdd = ucEpisodes.BtnActualPassengerAdd;
        btnActualPassengerDelete = ucEpisodes.BtnActualPassengerDelete;
        cboEntryKind = ucEpisodes.CboEntryKind;
        cboEntrySourceType = ucEpisodes.CboEntrySourceType;
        txtEntryName = ucEpisodes.TxtEntryName;
        numEntrySortOrder = ucEpisodes.NumEntrySortOrder;
        chkEntryLocked = ucEpisodes.ChkEntryLocked;
        chkEntryCanon = ucEpisodes.ChkEntryCanon;
        numEntryRandomSeed = ucEpisodes.NumEntryRandomSeed;
        txtEntryNotes = ucEpisodes.TxtEntryNotes;
        cboEntryOperationType = ucEpisodes.CboEntryOperationType;
        cboEntryNoticeType = ucEpisodes.CboEntryNoticeType;
        cboEntryStation = ucEpisodes.CboEntryStation;
        cboEntryDock = ucEpisodes.CboEntryDock;
        cboEntryOriginStation = ucEpisodes.CboEntryOriginStation;
        cboEntryDestinationStation = ucEpisodes.CboEntryDestinationStation;
        cboEntryVessel = ucEpisodes.CboEntryVessel;
        cboEntryVesselClassOverride = ucEpisodes.CboEntryVesselClassOverride;
        txtEntryRegistryOverride = ucEpisodes.TxtEntryRegistryOverride;
        cboEntryDeclaredPurpose = ucEpisodes.CboEntryDeclaredPurpose;
        cboEntryActualPurpose = ucEpisodes.CboEntryActualPurpose;
        cboEntryManifestStatus = ucEpisodes.CboEntryManifestStatus;
        cboEntryInspectionStatus = ucEpisodes.CboEntryInspectionStatus;
        cboEntryClearanceStatus = ucEpisodes.CboEntryClearanceStatus;
        cboEntryEnvironmentalCondition = ucEpisodes.CboEntryEnvironmentalCondition;
        cboEntryDirective = ucEpisodes.CboEntryDirective;
        cboEntryIncidentPhrase = ucEpisodes.CboEntryIncidentPhrase;
        cboEntryResolutionPhrase = ucEpisodes.CboEntryResolutionPhrase;
        cboEntryRouteStatusPhrase = ucEpisodes.CboEntryRouteStatusPhrase;
        txtEntryPublicBodyOverride = ucEpisodes.TxtEntryPublicBodyOverride;
        cboEntryStoryThread = ucEpisodes.CboEntryStoryThread;
        cboEntryAppliedStoryBeat = ucEpisodes.CboEntryAppliedStoryBeat;
        cboEntryAnomalySeverity = ucEpisodes.CboEntryAnomalySeverity;
        txtEntryHiddenTruthNotes = ucEpisodes.TxtEntryHiddenTruthNotes;
        chkEntryScheduledEnabled = ucEpisodes.ChkEntryScheduledEnabled;
        dtpEntryScheduledUtc = ucEpisodes.DtpEntryScheduledUtc;
        txtEpisodeName = ucEpisodes.TxtEpisodeName;
        chkEpisodeHasInUniverseDate = ucEpisodes.ChkEpisodeHasInUniverseDate;
        dtpEpisodeInUniverseUtc = ucEpisodes.DtpEpisodeInUniverseUtc;
        cboEpisodeBroadcastStation = ucEpisodes.CboEpisodeBroadcastStation;
        cboEpisodeSeries = ucEpisodes.CboEpisodeSeries;
        chkEpisodeCanonicalLocked = ucEpisodes.ChkEpisodeCanonicalLocked;
        txtEpisodeNotes = ucEpisodes.TxtEpisodeNotes;
        txtSeriesName = ucEpisodes.TxtSeriesName;
        cboSeriesBroadcastStation = ucEpisodes.CboSeriesBroadcastStation;
        txtSeriesNotes = ucEpisodes.TxtSeriesNotes;
        btnExportEpisodeText = ucEpisodes.BtnExportEpisodeText;
        btnExportEpisodeTts = ucEpisodes.BtnExportEpisodeTts;
        btnExportEpisodeJson = ucEpisodes.BtnExportEpisodeJson;
        chkExportIncludeHeader = ucEpisodes.ChkExportIncludeHeader;
        chkExportBlankLineBetweenEntries = ucEpisodes.ChkExportBlankLineBetweenEntries;
        chkExportIncludeEntryMarkers = ucEpisodes.ChkExportIncludeEntryMarkers;
        chkExportAuthorDebugMode = ucEpisodes.ChkExportAuthorDebugMode;

        // â”€â”€ Wire events â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        lstSeries.SelectedIndexChanged += lstSeries_SelectedIndexChanged;
        ucEpisodes.BtnSeriesAdd.Click += btnSeriesAdd_Click;
        ucEpisodes.BtnSeriesDelete.Click += btnSeriesDelete_Click;
        ucEpisodes.BtnSeriesDuplicate.Click += btnSeriesDuplicate_Click;

        lstEpisodes.SelectedIndexChanged += lstEpisodes_SelectedIndexChanged;
        txtEpisodeSearch.TextChanged += txtEpisodeSearch_TextChanged;
        ucEpisodes.BtnEpisodeAdd.Click += btnEpisodeAdd_Click;
        ucEpisodes.BtnEpisodeDelete.Click += btnEpisodeDelete_Click;
        ucEpisodes.BtnEpisodeDuplicate.Click += btnEpisodeDuplicate_Click;
        ucEpisodes.BtnNewEpisodeAfterSelected.Click += btnNewEpisodeAfterSelected_Click;
        ucEpisodes.BtnLockEpisodeCanon.Click += btnLockEpisodeCanon_Click;
        ucEpisodes.BtnUnlockEpisodeCanon.Click += btnUnlockEpisodeCanon_Click;
        ucEpisodes.BtnEpisodeMoveUp.Click += btnEpisodeMoveUp_Click;
        ucEpisodes.BtnEpisodeMoveDown.Click += btnEpisodeMoveDown_Click;

        gridEpisodeEntries.SelectionChanged += gridEpisodeEntries_SelectionChanged;
        ucEpisodes.BtnEntryAdd.Click += btnEntryAdd_Click;
        ucEpisodes.BtnNoticeEntryAdd.Click += btnNoticeEntryAdd_Click;
        ucEpisodes.BtnEntryDuplicate.Click += btnEntryDuplicate_Click;
        ucEpisodes.BtnEntryDelete.Click += btnEntryDelete_Click;
        ucEpisodes.BtnEntryMoveUp.Click += btnEntryMoveUp_Click;
        ucEpisodes.BtnEntryMoveDown.Click += btnEntryMoveDown_Click;

        ucEpisodes.BtnGenerateEntry.Click += btnGenerateEntry_Click;
        ucEpisodes.BtnGenerateEpisodeEntries.Click += btnGenerateEpisodeEntries_Click;
        ucEpisodes.BtnRegenerateSelectedEntry.Click += btnRegenerateSelectedEntry_Click;

        cboEntryFilterKind.SelectedIndexChanged += cboEntryFilterKind_SelectedIndexChanged;
        txtEntrySearch.TextChanged += txtEntrySearch_TextChanged;
        cboEntryFilterVessel.SelectedIndexChanged += cboEntryFilterVessel_SelectedIndexChanged;
        cboEntryFilterStation.SelectedIndexChanged += cboEntryFilterStation_SelectedIndexChanged;
        chkShowLockedOnly.CheckedChanged += chkShowLockedOnly_CheckedChanged;
        ucEpisodes.BtnClearEntryFilters.Click += btnClearEntryFilters_Click;

        ucEpisodes.BtnExportEpisodeText.Click += btnExportEpisodeText_Click;
        ucEpisodes.BtnExportEpisodeTts.Click += btnExportEpisodeTts_Click;
        ucEpisodes.BtnExportEpisodeJson.Click += btnExportEpisodeJson_Click;

        ucEpisodes.BtnDeclaredCargoAdd.Click += btnDeclaredCargoAdd_Click;
        ucEpisodes.BtnDeclaredCargoDelete.Click += btnDeclaredCargoDelete_Click;
        ucEpisodes.BtnActualCargoAdd.Click += btnActualCargoAdd_Click;
        ucEpisodes.BtnActualCargoDelete.Click += btnActualCargoDelete_Click;
        ucEpisodes.BtnDeclaredPassengerAdd.Click += btnDeclaredPassengerAdd_Click;
        ucEpisodes.BtnDeclaredPassengerDelete.Click += btnDeclaredPassengerDelete_Click;
        ucEpisodes.BtnActualPassengerAdd.Click += btnActualPassengerAdd_Click;
        ucEpisodes.BtnActualPassengerDelete.Click += btnActualPassengerDelete_Click;

        tabEpisodes.Controls.Add(ucEpisodes);
    }

    // â”€â”€ Tab: Output Preview â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabOutputPreview()
    {
        ucOutputPreview = new PodcastUniverseEditor.UI.Controls.ucOutputPreview { Dock = DockStyle.Fill };
        txtRenderedOutput = ucOutputPreview.TxtRenderedOutput;
        tabOutputPreview.Controls.Add(ucOutputPreview);
    }

    // â”€â”€ Tab: Validation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private void InitializeTabValidation()
    {
        ucValidation = new PodcastUniverseEditor.UI.Controls.ucValidation { Dock = DockStyle.Fill };
        gridValidationMessages = ucValidation.GridValidationMessages;
        ucValidation.BtnRunValidation.Click += btnRunValidation_Click;
        tabValidation.Controls.Add(ucValidation);
    }

    // â”€â”€ Layout helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Creates a Panel with a bold label header at top and a DataGridView filling the rest.
    /// </summary>
    private static Panel BuildLabelledGridPanel(string label, out DataGridView grid, string gridName)
    {
        var panel = new Panel { Dock = DockStyle.Fill };
        var lbl = new Label { Text = label, Dock = DockStyle.Top, Height = 20, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };
        grid = new DataGridView
        {
            Name = gridName,
            Dock = DockStyle.Fill,
            AutoGenerateColumns = true,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false
        };
        panel.Controls.Add(grid);
        panel.Controls.Add(lbl);
        return panel;
    }

    /// <summary>Creates a full-tab DataGridView with standard settings.</summary>
    private static DataGridView BuildStandaloneGrid(string name) => new DataGridView
    {
        Name = name,
        Dock = DockStyle.Fill,
        AutoGenerateColumns = true,
        AllowUserToAddRows = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        MultiSelect = false
    };

    // â”€â”€ Control fields â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    // Menu
    private MenuStrip menuMain = null!;
    private ToolStripMenuItem mnuFile = null!;
    private ToolStripMenuItem mnuFileNew = null!;
    private ToolStripMenuItem mnuFileOpen = null!;
    private ToolStripMenuItem mnuFileSave = null!;
    private ToolStripMenuItem mnuFileSaveAs = null!;
    private ToolStripMenuItem mnuFileExit = null!;

    // Toolbar
    private ToolStrip toolMain = null!;
    private ToolStripButton btnNewProject = null!;
    private ToolStripButton btnOpenProject = null!;
    private ToolStripButton btnSaveProject = null!;

    // Status strip
    private StatusStrip statusMain = null!;
    private ToolStripStatusLabel lblStatus = null!;
    private ToolStripStatusLabel lblCurrentFile = null!;

    // Tabs
    private TabControl tabMain = null!;
    private TabPage tabOverview = null!;
    private TabPage tabReferenceData = null!;
    private TabPage tabSystemsBodies = null!;
    private TabPage tabStationsDocks = null!;
    private TabPage tabRoutes = null!;
    private TabPage tabCommodities = null!;
    private TabPage tabOrganisationsDirectives = null!;
    private TabPage tabVessels = null!;
    private TabPage tabThreads = null!;
    private TabPage tabEpisodes = null!;
    private TabPage tabOutputPreview = null!;
    private TabPage tabValidation = null!;

    // Overview
    private TextBox txtProjectName = null!;
    private TextBox txtProjectDescription = null!;
    private TextBox txtSchemaVersion = null!;
    private Button btnLoadSampleProject = null!;

    // Reference data
    private PodcastUniverseEditor.UI.Controls.ucReferenceData ucReferenceData = null!;
    private ListBox lstReferenceTypes = null!;        // assigned from ucReferenceData.ListReferenceTypes
    private DataGridView gridReferenceItems = null!;  // assigned from ucReferenceData.GridReferenceItems

    // Systems & Bodies
    private PodcastUniverseEditor.UI.Controls.ucSystemsBodies ucSystemsBodies = null!;
    private DataGridView gridStarSystems = null!;  // assigned from ucSystemsBodies.GridStarSystems
    private DataGridView gridCelestialBodies = null!;  // assigned from ucSystemsBodies.GridCelestialBodies
    private Button btnSystemAdd = null!;  // assigned from ucSystemsBodies.BtnSystemAdd
    private Button btnSystemDelete = null!;  // assigned from ucSystemsBodies.BtnSystemDelete
    private Button btnBodyAdd = null!;  // assigned from ucSystemsBodies.BtnBodyAdd
    private Button btnBodyDelete = null!;  // assigned from ucSystemsBodies.BtnBodyDelete

    // Stations & Docks
    private PodcastUniverseEditor.UI.Controls.ucStationsDocks ucStationsDocks = null!;
    private DataGridView gridStations = null!;  // assigned from ucStationsDocks.GridStations
    private DataGridView gridDocks = null!;  // assigned from ucStationsDocks.GridDocks

    // Routes
    private PodcastUniverseEditor.UI.Controls.ucRoutes ucRoutes = null!;
    private DataGridView gridRoutes = null!;  // assigned from ucRoutes.GridRoutes

    // Commodities
    private PodcastUniverseEditor.UI.Controls.ucCommodities ucCommodities = null!;
    private DataGridView gridCommodities = null!;  // assigned from ucCommodities.GridCommodities

    // Organisations & Directives
    private PodcastUniverseEditor.UI.Controls.ucOrganisationsDirectives ucOrganisationsDirectives = null!;
    private DataGridView gridOrganisations    = null!;  // assigned from ucOrganisationsDirectives.GridOrganisations
    private DataGridView gridDirectives       = null!;  // assigned from ucOrganisationsDirectives.GridDirectives
    private Button       btnOrganisationsAdd    = null!;  // assigned from ucOrganisationsDirectives.BtnOrganisationsAdd
    private Button       btnOrganisationsDelete = null!;  // assigned from ucOrganisationsDirectives.BtnOrganisationsDelete
    private Button       btnDirectivesAdd       = null!;  // assigned from ucOrganisationsDirectives.BtnDirectivesAdd
    private Button       btnDirectivesDelete    = null!;  // assigned from ucOrganisationsDirectives.BtnDirectivesDelete

    // Vessels
    private PodcastUniverseEditor.UI.Controls.ucVessels ucVessels = null!;
    private DataGridView gridVessels = null!;  // assigned from ucVessels.GridVessels

    // Threads
    private PodcastUniverseEditor.UI.Controls.ucThreads ucThreads = null!;
    private DataGridView gridThreads = null!;  // assigned from ucThreads.GridThreads
    private DataGridView gridThreadBeats = null!;  // assigned from ucThreads.GridThreadBeats

    // Episodes
    private PodcastUniverseEditor.UI.Controls.Episodes.ucEpisodes ucEpisodes = null!;

    // Episodes â€” list + grid (forwarded from ucEpisodes)
    private ListBox lstSeries = null!;
    private ListBox lstEpisodes = null!;
    private DataGridView gridEpisodeEntries = null!;
    private TextBox txtEpisodeEntryPreview = null!;
    private TextBox txtEpisodeSummary = null!;
    private TextBox txtEpisodeSearch = null!;
    private NumericUpDown numGenerateEntryCount = null!;
    private CheckBox chkClearEpisodeBeforeGenerate = null!;
    private CheckBox chkRegenerateWithoutAdvancingThread = null!;
    private TextBox txtGenerationSeed = null!;
    private TextBox txtEntrySearch = null!;
    private ComboBox cboEntryFilterKind = null!;
    private ComboBox cboEntryFilterVessel = null!;
    private ComboBox cboEntryFilterStation = null!;
    private CheckBox chkShowLockedOnly = null!;

    // Episodes â€” entry detail panel (ucEpisodeEntryDetail child UC)
    private Control pnlEntryDetail = null!;

    // Entry: structural
    private ComboBox cboEntryKind = null!;
    private ComboBox cboEntrySourceType = null!;
    private TextBox txtEntryName = null!;
    private NumericUpDown numEntrySortOrder = null!;
    private CheckBox chkEntryLocked = null!;
    private CheckBox chkEntryCanon = null!;
    private NumericUpDown numEntryRandomSeed = null!;
    private TextBox txtEntryNotes = null!;

    // Entry: operation / notice
    private ComboBox cboEntryOperationType = null!;
    private ComboBox cboEntryNoticeType = null!;

    // Entry: location
    private ComboBox cboEntryStation = null!;
    private ComboBox cboEntryDock = null!;
    private ComboBox cboEntryOriginStation = null!;
    private ComboBox cboEntryDestinationStation = null!;

    // Entry: vessel
    private ComboBox cboEntryVessel = null!;
    private ComboBox cboEntryVesselClassOverride = null!;
    private TextBox txtEntryRegistryOverride = null!;

    // Entry: purpose
    private ComboBox cboEntryDeclaredPurpose = null!;
    private ComboBox cboEntryActualPurpose = null!;

    // Entry: statuses
    private ComboBox cboEntryManifestStatus = null!;
    private ComboBox cboEntryInspectionStatus = null!;
    private ComboBox cboEntryClearanceStatus = null!;
    private ComboBox cboEntryEnvironmentalCondition = null!;

    // Entry: narrative
    private ComboBox cboEntryDirective = null!;
    private ComboBox cboEntryIncidentPhrase = null!;
    private ComboBox cboEntryResolutionPhrase = null!;
    private ComboBox cboEntryRouteStatusPhrase = null!;
    private TextBox txtEntryPublicBodyOverride = null!;

    // Entry: story thread
    private ComboBox cboEntryStoryThread = null!;
    private ComboBox cboEntryAppliedStoryBeat = null!;
    private ComboBox cboEntryAnomalySeverity = null!;

    // Entry: hidden truth
    private TextBox txtEntryHiddenTruthNotes = null!;

    // Entry: schedule
    private CheckBox chkEntryScheduledEnabled = null!;
    private DateTimePicker dtpEntryScheduledUtc = null!;

    // Entry: thread summary
    private TextBox txtThreadSummary = null!;

    // Entry: validation hints panel
    private FlowLayoutPanel flpValidationHints = null!;

    // Entry: manifest grids
    private DataGridView gridDeclaredCargo = null!;
    private DataGridView gridActualCargo = null!;
    private DataGridView gridDeclaredPassengers = null!;
    private DataGridView gridActualPassengers = null!;
    private Button btnDeclaredCargoAdd = null!;
    private Button btnDeclaredCargoDelete = null!;
    private Button btnActualCargoAdd = null!;
    private Button btnActualCargoDelete = null!;
    private Button btnDeclaredPassengerAdd = null!;
    private Button btnDeclaredPassengerDelete = null!;
    private Button btnActualPassengerAdd = null!;
    private Button btnActualPassengerDelete = null!;

    // Episodes â€” metadata editor (ucEpisodeMetaEditor child UC)
    private Control pnlEpisodeMetaEditor = null!;
    private TextBox txtEpisodeName = null!;
    private CheckBox chkEpisodeHasInUniverseDate = null!;
    private DateTimePicker dtpEpisodeInUniverseUtc = null!;
    private ComboBox cboEpisodeBroadcastStation = null!;
    private ComboBox cboEpisodeSeries = null!;
    private CheckBox chkEpisodeCanonicalLocked = null!;
    private TextBox txtEpisodeNotes = null!;
    private TextBox txtSeriesName = null!;
    private ComboBox cboSeriesBroadcastStation = null!;
    private TextBox txtSeriesNotes = null!;

    // Episodes â€” export controls
    private Button btnExportEpisodeText = null!;
    private Button btnExportEpisodeTts = null!;
    private Button btnExportEpisodeJson = null!;
    private CheckBox chkExportIncludeHeader = null!;
    private CheckBox chkExportBlankLineBetweenEntries = null!;
    private CheckBox chkExportIncludeEntryMarkers = null!;
    private CheckBox chkExportAuthorDebugMode = null!;

    // Output Preview
    private PodcastUniverseEditor.UI.Controls.ucOutputPreview ucOutputPreview = null!;
    private TextBox txtRenderedOutput = null!;  // assigned from ucOutputPreview.TxtRenderedOutput

    // Validation
    private PodcastUniverseEditor.UI.Controls.ucValidation ucValidation = null!;
    private DataGridView gridValidationMessages = null!;  // assigned from ucValidation.GridValidationMessages
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
- Total .cs files processed: 91
- Date generated: 2026-03-30 23:16

