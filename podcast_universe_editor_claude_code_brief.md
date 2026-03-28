# Podcast Universe Editor — Claude Code Build Brief

## 1. Purpose

Build a **WinForms desktop application in C# / .NET 8** called **PodcastUniverseEditor**.

The application is a **universe editor + podcast episode generator + canon tracker** for a fictional, low-drama, logistics-style space broadcast.

The tonal target is:
- mundane
- procedural
- sleep-friendly
- slightly uncanny only through implication
- subtle long-term intrigue
- no melodrama

Think:
- Radio 4 shipping forecast cadence
- station operations announcements
- dry logistics bulletins
- very gradual worldbuilding through repeated irregularities

The application must support:
1. editing universe data
2. storing editable vocabulary and phrase lists
3. generating consistent routine traffic entries
4. manually authoring or overriding entries
5. gradual, stateful story-thread progression
6. public spoken output vs hidden truth
7. canon locking so future generation does not contradict the past
8. save/load via JSON project files

---

## 2. Critical design principles

These are mandatory.

### 2.1 Data first, prose last
Store structured fields first.
The spoken output must always be rendered from structured data.

Do **not** make prose the source of truth.

### 2.2 Public truth and hidden truth are separate
Each entry may contain:
- **declared/public/spoken** values
- **actual/hidden** values

Example:
- declared cargo = sealed industrial containers
- actual cargo = restricted weapons components

The renderer uses the public layer.
The generator/validation/history logic may use both.

### 2.3 Vocabulary must be editable data, not hard-coded enums
Anything the user might want to expand later should be stored in editable project data.
Examples:
- operation types
- vessel classes
- manifest statuses
- inspection statuses
- clearance statuses
- environmental conditions
- notice types
- phrase templates
- anomaly types
- directives
- purposes
- passenger categories
- commodity categories
- station types

Only a few technical enums are allowed in code.

### 2.4 Intrigue must be stateful, not random
Anomalies must be able to recur and progress over time via **story threads**.
A recurring vessel such as `Wolfgang Amadeus` must be able to show increasingly suspicious but subtle irregularities across many episodes.

### 2.5 Canon cannot be silently overwritten
Once episodes or entries are locked as canon, future generation and validation must be able to consult them.

### 2.6 Validation is essential
The app must validate internal consistency.
Examples:
- cargo plausible for route
- origin/destination sensible
- vessel class compatible with manifest/passengers
- hidden anomaly stage progression not jumping too fast
- suspended dock not actively used unless intentional
- same vessel not simultaneously in impossible places

### 2.7 WinForms UI should be practical, not fancy
Use WinForms with normal controls and predictable naming.
The user may hand-build or refine parts of the designer.

---

## 3. High-level architecture

Solution structure should be:

```text
PodcastUniverseEditor
├─ Models
│  ├─ Common
│  ├─ ReferenceData
│  ├─ World
│  ├─ Episodes
│  ├─ Threads
│  └─ Validation
├─ Services
│  ├─ Persistence
│  ├─ Generation
│  ├─ Rendering
│  ├─ Validation
│  ├─ Lookup
│  └─ Seeds
├─ UI
│  ├─ Forms
│  ├─ Controls
│  ├─ Presenters
│  └─ Binding
├─ Utilities
├─ Data
└─ Program.cs
```

Target framework:
- **.NET 8 WinForms**

Serialization:
- **System.Text.Json**

Project file extension:
- `*.podcastworld.json`

---

## 4. What the application must do

### 4.1 Reference data editing
The user must be able to edit all vocabulary/reference data lists.

### 4.2 World editing
The user must be able to edit:
- star systems
- celestial bodies
- stations
- docks/bays/rings
- organisations
- commodities
- routes
- vessels

### 4.3 Episode editing
The user must be able to:
- create podcast series
- create episodes
- add/edit/reorder entries
- insert notices
- generate one entry
- generate many entries
- regenerate selected entry
- duplicate entry
- lock entry
- preview rendered output

### 4.4 Custom entry authoring
The user must be able to create a fully manual entry using structured fields.
The app should still render it using standard output rules.

### 4.5 Generator
The generator must support:
- random valid traffic entry generation
- notice generation
- thread-aware escalation
- weighted route/cargo selection
- controlled anomaly injection
- reproducible generation via random seed

### 4.6 Validation
There must be validation results with severity levels:
- Info
- Warning
- Error

### 4.7 Search/filter/history
The user must be able to search for:
- vessel appearances
- cargo occurrences
- directives
- stations
- story threads
- anomalies across time

---

## 5. Technical enums allowed in code

Only these kinds of enums should exist in code:

- `EntryKind` → Traffic / Notice
- `EntrySourceType` → Manual / Generated
- `ThreadEntityKind` → Vessel / Route / Station / Commodity / Organisation
- `SeverityLevel` → Minor / Moderate / Major
- `ValidationSeverity` → Info / Warning / Error

Everything else should be editable data.

---

## 6. Domain model

Use POCOs with GUID string IDs. All records should support notes, tags, metadata, audit dates.

### 6.1 Common base classes

Implement:
- `EntityBase`
- `AuditableEntityBase`

Expected fields:
- `Id`
- `Name`
- `Notes`
- `Tags`
- `Metadata`
- `IsArchived`
- `CreatedUtc`
- `ModifiedUtc`

---

## 7. Reference-data classes

Create these under `Models/ReferenceData`.

### 7.1 `ReferenceItemBase`
Properties:
- `Code`
- `IsEnabled`
- `SortOrder`
- `AllowedTagFilters`

### 7.2 `OperationTypeDefinition`
Properties:
- `HeaderFormat`
- `RequiresOrigin`
- `RequiresDestination`
- `IsTrafficOperation`

### 7.3 `VesselClassDefinition`
Properties:
- `SpokenNoun`
- `CanCarryCargo`
- `CanCarryPassengers`
- `TypicalCommodityCategoryIds`
- `TypicalPassengerMin`
- `TypicalPassengerMax`

### 7.4 `PurposeDefinition`
Properties:
- `SpokenPhrase`
- `TypicalCommodityIds`
- `TypicalCommodityCategoryIds`
- `TypicalVesselClassIds`

### 7.5 `ManifestStatusDefinition`
Properties:
- `SpokenPhrase`
- `ImpliesIrregularity`

### 7.6 `InspectionStatusDefinition`
Properties:
- `SpokenPhrase`
- `ImpliesInspection`
- `ImpliesConcern`

### 7.7 `ClearanceStatusDefinition`
Properties:
- `SpokenPhrase`
- `IsTerminalState`

### 7.8 `EnvironmentalConditionDefinition`
Properties:
- `SpokenPhrase`
- `Scope`

### 7.9 `NoticeTypeDefinition`
Properties:
- `HeaderText`
- `DefaultBodyFormat`

### 7.10 `PassengerCategoryDefinition`
Properties:
- `SpokenLabel`

### 7.11 `CommodityCategoryDefinition`
Properties:
- `SpokenLabel`

### 7.12 `StationTypeDefinition`
Properties:
- `SpokenLabel`

### 7.13 `AuthorityTypeDefinition`
Properties:
- `SpokenLabel`

### 7.14 `AnomalyTypeDefinition`
Properties:
- `PublicDescription`
- `IsSubtleByDefault`
- `AllowedOperationTypeIds`
- `AllowedEntityKinds`

### 7.15 `PhraseTemplate`
Properties:
- `TemplateText`
- `TemplateGroup`

### 7.16 `DirectiveDefinition`
Properties:
- `SpokenPhrase`
- `AuthorityOrganisationId`

### 7.17 `BodyTypeDefinition`
Add this now for future celestial hierarchy.
Properties:
- `SpokenLabel`

### 7.18 `OrganisationTypeDefinition`
Properties:
- `SpokenLabel`

---

## 8. World classes

Create these under `Models/World`.

### 8.1 `StarSystemRecord`
Properties:
- `RegionName`

### 8.2 `CelestialBodyRecord`
Properties:
- `StarSystemId`
- `ParentBodyId`
- `BodyTypeId`

### 8.3 `OrganisationRecord`
Properties:
- `OrganisationTypeId`
- `IsAuthority`

### 8.4 `StationRecord`
Properties:
- `StationTypeId`
- `StarSystemId`
- `CelestialBodyId`
- `OperatorOrganisationId`
- `ImportCommodityIds`
- `ExportCommodityIds`
- `PurposeIds`

### 8.5 `DockRecord`
Properties:
- `StationId`
- `SpokenLabel`
- `SpokenIdentifier`
- `IsRestricted`
- `IsSuspended`

### 8.6 `CommodityRecord`
Properties:
- `CommodityCategoryId`
- `UnitLabel`
- `TypicalMinQuantity`
- `TypicalMaxQuantity`
- `IsRestricted`
- `IsContraband`
- `ProducedAtStationIds`
- `ConsumedAtStationIds`

### 8.7 `RouteRecord`
Properties:
- `FromStationId`
- `ToStationId`
- `FrequencyWeight`
- `RiskWeight`
- `RouteConditionTemplateId`
- `AllowedVesselClassIds`
- `TypicalCommodityIds`
- `TypicalPurposeIds`

### 8.8 `VesselRecord`
Properties:
- `Registry`
- `VesselClassId`
- `OperatorOrganisationId`
- `HomeStationId`
- `IsRecurringNarrativeAsset`
- `PreferredRouteIds`
- `AssociatedThreadIds`

---

## 9. Episode classes

Create under `Models/Episodes`.

### 9.1 `PodcastSeriesRecord`
Properties:
- `BroadcastStationId`
- `EpisodeIds`

### 9.2 `EpisodeRecord`
Properties:
- `SeriesId`
- `InUniverseUtc`
- `BroadcastStationId`
- `Entries`
- `IsCanonicalLocked`

### 9.3 `EntryCargoLine`
Properties:
- `CommodityId`
- `SpokenCommodityNameOverride`
- `Quantity`
- `UnitLabelOverride`
- `IsDeclared`
- `IsHiddenTruthOnly`

### 9.4 `EntryPassengerLine`
Properties:
- `PassengerCategoryId`
- `Count`
- `IsDeclared`
- `IsHiddenTruthOnly`

### 9.5 `EntryRenderOptions`
Properties:
- `IncludePurpose`
- `IncludeCargo`
- `IncludePassengers`
- `IncludeManifestStatus`
- `IncludeInspectionStatus`
- `IncludeEnvironmentalStatus`
- `IncludeResolution`

### 9.6 `EpisodeEntryRecord`
Properties:
- `EntryKind`
- `SourceType`
- `SortOrder`
- `OperationTypeId`
- `NoticeTypeId`
- `StationId`
- `DockId`
- `VesselId`
- `VesselClassOverrideId`
- `RegistryOverride`
- `OriginStationId`
- `DestinationStationId`
- `DeclaredPurposeId`
- `ActualPurposeId`
- `DeclaredCargo`
- `ActualCargo`
- `DeclaredPassengers`
- `ActualPassengers`
- `ManifestStatusId`
- `InspectionStatusId`
- `ClearanceStatusId`
- `EnvironmentalConditionId`
- `DirectiveId`
- `IncidentPhraseTemplateId`
- `ResolutionPhraseTemplateId`
- `RouteStatusPhraseTemplateId`
- `PublicBodyOverride`
- `HiddenTruthNotes`
- `StoryThreadId`
- `AppliedStoryBeatId`
- `AnomalySeverity`
- `IsLocked`
- `IsCanon`
- `RandomSeed`
- `RenderOptions`
- `ScheduledUtc`

---

## 10. Thread classes

Create under `Models/Threads`.

### 10.1 `StoryThreadRecord`
Properties:
- `EntityKind`
- `TargetEntityId`
- `ThemeAnomalyTypeId`
- `CurrentStageIndex`
- `IsActive`
- `CooldownEpisodes`
- `EpisodesUntilEligible`
- `Beats`

### 10.2 `StoryBeatRecord`
Properties:
- `StageIndex`
- `PublicManifestStatusId`
- `PublicInspectionStatusId`
- `PublicDirectiveId`
- `IncidentPhraseTemplateId`
- `ResolutionPhraseTemplateId`
- `HiddenTruthSummary`
- `Severity`

---

## 11. Validation classes

Create under `Models/Validation`.

### 11.1 `ValidationMessage`
Properties:
- `Severity`
- `Message`
- `EntityType`
- `EntityId`
- `FieldName`

### 11.2 `ValidationResult`
Properties:
- `Messages`
- `HasErrors`
- `HasWarnings`

---

## 12. Top-level project container

Create `PodcastProject` under `Models`.

Properties:
- `SchemaVersion`
- `ProjectName`
- `Description`
- `CreatedUtc`
- `ModifiedUtc`

Collections:
- all reference-data collections
- all world-data collections
- all episode collections
- all story-thread collections

Include:
- `OperationTypes`
- `VesselClasses`
- `Purposes`
- `ManifestStatuses`
- `InspectionStatuses`
- `ClearanceStatuses`
- `EnvironmentalConditions`
- `NoticeTypes`
- `PassengerCategories`
- `CommodityCategories`
- `StationTypes`
- `AuthorityTypes`
- `AnomalyTypes`
- `PhraseTemplates`
- `Directives`
- `BodyTypes`
- `OrganisationTypes`
- `StarSystems`
- `CelestialBodies`
- `Organisations`
- `Stations`
- `Docks`
- `Commodities`
- `Routes`
- `Vessels`
- `Series`
- `Episodes`
- `StoryThreads`

---

## 13. Services to implement

Create these services with clear responsibilities.

### 13.1 Persistence
#### `ProjectFileService`
Responsibilities:
- save project JSON
- load project JSON
- new project creation
- schema version support

Methods:
- `Save(string filePath, PodcastProject project)`
- `PodcastProject Load(string filePath)`
- `PodcastProject CreateNewProject()`

### 13.2 Seed data
#### `ProjectSeedFactory`
Responsibilities:
- create a sample starter universe
- populate starter vocabulary
- create a few stations/routes/commodities/vessels
- create example thread for recurring anomalies

### 13.3 Lookup
#### `ProjectLookupService`
Responsibilities:
- resolve names by ID
- common lookup helpers
- station/route/vessel/commodity resolution

### 13.4 Rendering
#### `EntryRenderingService`
Responsibilities:
- render traffic entry text
- render notice text
- render whole episode script
- omit optional fields if empty or disabled in `EntryRenderOptions`

Methods:
- `string RenderEntry(EpisodeEntryRecord entry, PodcastProject project)`
- `string RenderEpisode(EpisodeRecord episode, PodcastProject project)`

#### Rendering rules
Use the standard pattern:

Example traffic output:
```text
Departure from Bay Fourteen.--
The bulk carrier Helios Dawn, registry XF-7742, outbound for Mars Prime.--
Declared purpose: industrial resupply.--
Cargo manifest:--
- thirty-eight thousand tons of liquid oxygen
- twelve thousand tons of nitrogen compounds
No passengers aboard.--
Manifest verified.--
No inspection required.--
Cleared for departure.--
Trajectory is clear.--
Solar flare activity remains low.--
End of entry.
```

Example notice output:
```text
Operations Notice.--
Elevated particulate activity detected in Corridor 7.--
Non-essential departures postponed.--
Affected areas: Rings 2 through 5.--
Until further notice.--
End of notice.
```

### 13.5 Validation
#### `ProjectValidationService`
Responsibilities:
- validate whole project
- validate episode
- validate entry

Checks should include:
- missing required references
- missing origin on arrivals
- missing destination on departures
- dock suspension conflicts
- implausible route/cargo combinations
- vessel/passenger mismatch
- duplicate registries
- thread progression jumps
- contradictory canon
- hidden truth without plausible public cover where relevant

Methods:
- `ValidationResult ValidateProject(PodcastProject project)`
- `ValidationResult ValidateEpisode(EpisodeRecord episode, PodcastProject project)`
- `ValidationResult ValidateEntry(EpisodeEntryRecord entry, PodcastProject project)`

### 13.6 Generation
#### `RandomProvider`
Wrapper around RNG so generation can be seeded.

#### `WeightedSelectionService`
Responsibilities:
- weighted random choice helper

#### `EpisodeGenerationService`
Responsibilities:
- generate one traffic entry
- generate many traffic entries
- generate notice
- regenerate selected entry
- optionally apply thread beat

Methods:
- `EpisodeEntryRecord GenerateTrafficEntry(PodcastProject project, EpisodeRecord episode, int? seed = null)`
- `List<EpisodeEntryRecord> GenerateTrafficEntries(PodcastProject project, EpisodeRecord episode, int count, int? seed = null)`
- `EpisodeEntryRecord GenerateNoticeEntry(PodcastProject project, EpisodeRecord episode, int? seed = null)`
- `EpisodeEntryRecord RegenerateEntry(PodcastProject project, EpisodeRecord episode, EpisodeEntryRecord existing, bool preserveLockedFields)`

Generation must be weighted by:
- route frequency
- station import/export logic
- commodity suitability
- vessel class compatibility
- purpose suitability
- thread eligibility

### 13.7 Thread progression
#### `StoryThreadService`
Responsibilities:
- determine eligible threads
- advance thread stage
- apply current beat to generated entry
- prevent over-escalation

Methods:
- `List<StoryThreadRecord> GetEligibleThreads(PodcastProject project, EpisodeRecord episode)`
- `StoryBeatRecord? GetNextBeat(StoryThreadRecord thread)`
- `void ApplyBeat(EpisodeEntryRecord entry, StoryThreadRecord thread, StoryBeatRecord beat)`
- `void AdvanceThread(StoryThreadRecord thread)`

---

## 14. Story progression requirements

This is important.

The app must support gradual subtle escalation.
Example recurring ship: `Wolfgang Amadeus`.

Possible progression:
1. ordinary diplomatic courier
2. manifest verification pending
3. customs notation filed
4. transponder verification incomplete
5. identification signal irregularity noted
6. cleared under directive
7. scheduled arrival, no docking request received

The system should never jump directly from stage 1 to stage 6 without intentional manual override.

The user must be able to edit all beats and phrase selections.

---

## 15. Generator rules for subtle intrigue

### 15.1 Normality ratio
The generator must support configurable rates such as:
- 90–95% ordinary entries
- 5–10% mild irregularity
- ~1% more significant irregularity

### 15.2 One primary anomaly per entry
Avoid stacking multiple strong irregularities in one entry.

### 15.3 Occasional return to normal
Recurring suspicious entities must sometimes appear normal again.

### 15.4 Repetition matters
The same vessel, route, dock, directive, or authority must be able to recur.

### 15.5 Hidden truth is not always spoken
The app must permit hidden reality that does not appear directly in the rendered output.

---

## 16. Starter vocabulary / sample seed data

Please seed the project with a useful but modest starter dataset.

### 16.1 Operation types
Seed at least:
- Arrival
- Departure
- Transfer
- Scheduled Arrival
- Holding Pattern

### 16.2 Vessel classes
Seed at least:
- Bulk Carrier
- Freighter
- Courier
- Tanker
- Personnel Transport
- Maintenance Vessel
- Survey Craft

### 16.3 Purposes
Seed at least:
- Ore Transfer
- Fuel Delivery
- Crew Rotation
- Maintenance Resupply
- Diplomatic Courier Service
- Agricultural Delivery
- Internal Transfer
- Survey Return
- Salvage Processing
- Customs Hold Release

### 16.4 Manifest statuses
Seed examples such as:
- Manifest verified.--
- Manifest verification pending.--
- Manifest amended prior to departure.--
- Declaration incomplete.--
- Manifest discrepancy noted.--

### 16.5 Inspection statuses
Seed examples such as:
- No inspection required.--
- Random inspection assigned.--
- Inspection completed.--
- Inspection deferred.--
- Customs review ongoing.--

### 16.6 Clearance statuses
Seed examples such as:
- Cleared for docking.--
- Cleared for departure.--
- Clearance pending.--
- Held for inspection.--
- Priority clearance granted.--
- Docking delayed.--

### 16.7 Environmental conditions
Seed examples such as:
- Solar flare activity remains low.--
- Radiation levels elevated.--
- Debris field stable.--
- Corridor interference remains minor.--

### 16.8 Notice types
Seed examples such as:
- Operations Notice.--
- Security Notice.--
- Docking Advisory.--
- Customs Notice.--

### 16.9 Passenger categories
Seed examples such as:
- civilian
- technical personnel
- crew rotation
- diplomatic liaison
- security detail
- unspecified passengers

### 16.10 Commodity categories
Seed examples such as:
- industrial
- agricultural
- medical
- fuel
- luxury
- restricted
- military dual-use

### 16.11 Station types
Seed examples such as:
- Outpost
- Orbital Station
- Shipyard
- Mining Platform
- Agricultural Hub
- Research Platform

### 16.12 Phrase templates
Seed template groups for:
- incident phrasing
- resolution phrasing
- route status phrasing
- notice bodies

Seed examples such as:
- Trajectory is clear.--
- Corridor 7 experiencing minor interference.--
- Manifest discrepancy noted.--
- Documentation variance recorded.--
- Situation resolved.--
- No further action required.--
- Operations ongoing.--

### 16.13 Anomaly types
Seed examples such as:
- Cargo Mismatch
- Identity Irregularity
- Scheduled Absence
- Unusual Priority
- Sanitised Incident
- Directive Override

### 16.14 Systems/stations/routes sample world
Seed a starter universe with at least:

Star systems:
- Helios System
- Virex System
- Luma System

Bodies:
- Mars Prime
- Virex Belt
- Luma Station Body or orbital reference

Stations:
- Helios Gate (trade hub)
- Mars Prime (major destination)
- Virex Belt (mining)
- Luma Station (agricultural)
- Kepler Anchorage (outer route stop)

Docks for at least one station:
- Bay One
- Bay Two
- Bay Fourteen
- Ring Three
- Ring Four

Commodities:
- Liquid Oxygen
- Nitrogen Compounds
- Processed Nickel
- Refined Copper
- Agricultural Seed Stock
- Medical Isolates
- Structural Plating
- Guidance Assemblies
- Sealed Industrial Containers

Vessels:
- Helios Dawn
- Kestrel Dawn
- Carthage Relay 6
- Wolfgang Amadeus
- Pale Meridian

### 16.15 Story thread seed
Seed one usable thread for `Wolfgang Amadeus` involving identity/transponder irregularity progression.

---

## 17. WinForms UI requirements

The UI should be conventional and easy to wire by hand if needed.
Use a `MainForm` with a `MenuStrip`, `ToolStrip`, `StatusStrip`, and `TabControl`.

Do not over-engineer MVVM. Basic services + form code-behind is acceptable.

### 17.1 Main form
Create:
- `MainForm`

Controls on `MainForm`:
- `menuMain`
- `toolMain`
- `statusMain`
- `tabsMain`

Menu items:
- `mnuFile`
  - `mnuFileNew`
  - `mnuFileOpen`
  - `mnuFileSave`
  - `mnuFileSaveAs`
  - `mnuFileExit`
- `mnuProject`
  - `mnuProjectValidate`
  - `mnuProjectSeedSample`
- `mnuEpisode`
  - `mnuEpisodeGenerateOne`
  - `mnuEpisodeGenerateMany`
  - `mnuEpisodeRender`
- `mnuHelp`
  - `mnuHelpAbout`

ToolStrip buttons:
- `btnNewProject`
- `btnOpenProject`
- `btnSaveProject`
- `btnValidateProject`
- `btnGenerateEntry`
- `btnGenerateEpisode`
- `btnRenderEpisode`

Tab pages on `tabsMain`:
- `tabOverview`
- `tabReferenceData`
- `tabSystemsBodies`
- `tabStationsDocks`
- `tabRoutes`
- `tabCommodities`
- `tabOrganisations`
- `tabVessels`
- `tabThreads`
- `tabEpisodes`
- `tabPreview`
- `tabValidation`

### 17.2 Overview tab
Purpose: basic project metadata.

Controls:
- `lblProjectName`
- `txtProjectName`
- `lblProjectDescription`
- `txtProjectDescription`
- `lblSchemaVersion`
- `txtSchemaVersion`
- `btnOverviewApply`

### 17.3 Reference data tab
Use a split layout.

Controls:
- `splitReferenceData`
- `lstReferenceTypes` (left list of reference collections)
- `gridReferenceItems` (main grid)
- `propReferenceItem` or details panel on right/bottom if convenient
- buttons:
  - `btnReferenceAdd`
  - `btnReferenceDelete`
  - `btnReferenceDuplicate`
  - `btnReferenceSaveChanges`

Supported reference collections selectable in `lstReferenceTypes`:
- Operation Types
- Vessel Classes
- Purposes
- Manifest Statuses
- Inspection Statuses
- Clearance Statuses
- Environmental Conditions
- Notice Types
- Passenger Categories
- Commodity Categories
- Station Types
- Authority Types
- Anomaly Types
- Phrase Templates
- Directives
- Body Types
- Organisation Types

### 17.4 Systems & Bodies tab
Controls:
- `splitSystemsBodies`
- `grpStarSystems`
- `gridStarSystems`
- `grpCelestialBodies`
- `gridCelestialBodies`
- buttons:
  - `btnSystemAdd`
  - `btnSystemDelete`
  - `btnBodyAdd`
  - `btnBodyDelete`

### 17.5 Stations & Docks tab
Controls:
- `splitStationsDocks`
- `gridStations`
- `gridDocks`
- `btnStationAdd`
- `btnStationDelete`
- `btnDockAdd`
- `btnDockDelete`
- `btnStationApply`

Expected station columns:
- Name
- Type
- System
- Body
- Operator
- Imports
- Exports
- Purposes

Expected dock columns:
- Name
- Station
- SpokenLabel
- SpokenIdentifier
- IsRestricted
- IsSuspended

### 17.6 Routes tab
Controls:
- `gridRoutes`
- `btnRouteAdd`
- `btnRouteDelete`
- `btnRouteDuplicate`
- `btnRouteApply`

Columns:
- Name
- FromStation
- ToStation
- FrequencyWeight
- RiskWeight
- RouteConditionTemplate
- AllowedVesselClasses
- TypicalCommodities
- TypicalPurposes

### 17.7 Commodities tab
Controls:
- `gridCommodities`
- `btnCommodityAdd`
- `btnCommodityDelete`
- `btnCommodityApply`

Columns:
- Name
- Category
- UnitLabel
- TypicalMinQuantity
- TypicalMaxQuantity
- IsRestricted
- IsContraband
- ProducedAtStations
- ConsumedAtStations

### 17.8 Organisations tab
Controls:
- `gridOrganisations`
- `btnOrganisationAdd`
- `btnOrganisationDelete`
- `btnOrganisationApply`

### 17.9 Vessels tab
Controls:
- `gridVessels`
- `btnVesselAdd`
- `btnVesselDelete`
- `btnVesselApply`

Columns:
- Name
- Registry
- VesselClass
- Operator
- HomeStation
- IsRecurringNarrativeAsset
- PreferredRoutes
- AssociatedThreads

### 17.10 Threads tab
Controls:
- `splitThreads`
- `gridThreads`
- `gridStoryBeats`
- `btnThreadAdd`
- `btnThreadDelete`
- `btnBeatAdd`
- `btnBeatDelete`
- `btnAdvanceThread`
- `btnThreadApply`

Thread columns:
- Name
- EntityKind
- TargetEntity
- ThemeAnomalyType
- CurrentStageIndex
- IsActive
- CooldownEpisodes
- EpisodesUntilEligible

Beat columns:
- StageIndex
- PublicManifestStatus
- PublicInspectionStatus
- PublicDirective
- IncidentPhraseTemplate
- ResolutionPhraseTemplate
- HiddenTruthSummary
- Severity

### 17.11 Episodes tab
This is the most important editor.
Use a three-pane layout.

Controls:
- `splitEpisodesOuter`
- `splitEpisodesInner`
- `lstSeries`
- `lstEpisodes`
- `gridEpisodeEntries`
- `grpEntryEditor`

Episode-level buttons:
- `btnSeriesAdd`
- `btnSeriesDelete`
- `btnEpisodeAdd`
- `btnEpisodeDelete`
- `btnEpisodeDuplicate`
- `btnEpisodeLock`

Generation buttons:
- `btnEpisodeGenerateOne`
- `btnEpisodeGenerateMany`
- `btnEpisodeGenerateNotice`
- `btnEpisodeRegenerateSelected`
- `btnEpisodeDuplicateEntry`
- `btnEpisodeDeleteEntry`
- `btnEpisodeMoveEntryUp`
- `btnEpisodeMoveEntryDown`

Custom/manual entry section controls:
- `cmbEntryKind`
- `cmbOperationType`
- `cmbNoticeType`
- `cmbEntryStation`
- `cmbEntryDock`
- `cmbEntryVessel`
- `cmbEntryOrigin`
- `cmbEntryDestination`
- `cmbDeclaredPurpose`
- `cmbActualPurpose`
- `cmbManifestStatus`
- `cmbInspectionStatus`
- `cmbClearanceStatus`
- `cmbEnvironmentalCondition`
- `cmbDirective`
- `cmbIncidentPhrase`
- `cmbResolutionPhrase`
- `cmbRouteStatusPhrase`
- `cmbStoryThread`
- `cmbAnomalySeverity`

Text boxes / checkboxes:
- `txtRegistryOverride`
- `txtPublicBodyOverride`
- `txtHiddenTruthNotes`
- `chkEntryLocked`
- `chkEntryCanon`
- `chkRenderPurpose`
- `chkRenderCargo`
- `chkRenderPassengers`
- `chkRenderManifestStatus`
- `chkRenderInspectionStatus`
- `chkRenderEnvironmentalStatus`
- `chkRenderResolution`
- `dtpScheduledUtc`
- `numRandomSeed`

Sub-grids in entry editor:
- `gridDeclaredCargo`
- `gridActualCargo`
- `gridDeclaredPassengers`
- `gridActualPassengers`

Entry editor buttons:
- `btnEntryApply`
- `btnEntryReset`
- `btnDeclaredCargoAdd`
- `btnDeclaredCargoDelete`
- `btnActualCargoAdd`
- `btnActualCargoDelete`
- `btnDeclaredPassengerAdd`
- `btnDeclaredPassengerDelete`
- `btnActualPassengerAdd`
- `btnActualPassengerDelete`

Entry list columns in `gridEpisodeEntries`:
- SortOrder
- EntryKind
- OperationType/NoticeType
- Vessel
- Origin
- Destination
- ManifestStatus
- InspectionStatus
- ClearanceStatus
- StoryThread
- IsLocked
- IsCanon

### 17.12 Preview tab
Controls:
- `txtEpisodePreview`
- `btnPreviewRenderSelectedEpisode`
- `btnPreviewCopyToClipboard`
- `btnPreviewExportText`

`txtEpisodePreview` should be multiline, read-only, scrollable.

### 17.13 Validation tab
Controls:
- `gridValidationMessages`
- `btnValidationRunProject`
- `btnValidationRunEpisode`
- `chkValidationErrors`
- `chkValidationWarnings`
- `chkValidationInfo`

Columns:
- Severity
- Message
- EntityType
- EntityId
- FieldName

---

## 18. Event wiring / expected handlers

Please create code-behind and wire the following methods.

### 18.1 Main form
- `MainForm_Load`
- `mnuFileNew_Click`
- `mnuFileOpen_Click`
- `mnuFileSave_Click`
- `mnuFileSaveAs_Click`
- `mnuFileExit_Click`
- `mnuProjectValidate_Click`
- `mnuProjectSeedSample_Click`
- `mnuEpisodeGenerateOne_Click`
- `mnuEpisodeGenerateMany_Click`
- `mnuEpisodeRender_Click`
- `tabsMain_SelectedIndexChanged`

### 18.2 Overview
- `btnOverviewApply_Click`

### 18.3 Reference data
- `lstReferenceTypes_SelectedIndexChanged`
- `btnReferenceAdd_Click`
- `btnReferenceDelete_Click`
- `btnReferenceDuplicate_Click`
- `btnReferenceSaveChanges_Click`

### 18.4 Systems/bodies
- `btnSystemAdd_Click`
- `btnSystemDelete_Click`
- `btnBodyAdd_Click`
- `btnBodyDelete_Click`

### 18.5 Stations/docks
- `btnStationAdd_Click`
- `btnStationDelete_Click`
- `btnDockAdd_Click`
- `btnDockDelete_Click`
- `btnStationApply_Click`

### 18.6 Routes
- `btnRouteAdd_Click`
- `btnRouteDelete_Click`
- `btnRouteDuplicate_Click`
- `btnRouteApply_Click`

### 18.7 Commodities
- `btnCommodityAdd_Click`
- `btnCommodityDelete_Click`
- `btnCommodityApply_Click`

### 18.8 Organisations
- `btnOrganisationAdd_Click`
- `btnOrganisationDelete_Click`
- `btnOrganisationApply_Click`

### 18.9 Vessels
- `btnVesselAdd_Click`
- `btnVesselDelete_Click`
- `btnVesselApply_Click`

### 18.10 Threads
- `gridThreads_SelectionChanged`
- `btnThreadAdd_Click`
- `btnThreadDelete_Click`
- `btnBeatAdd_Click`
- `btnBeatDelete_Click`
- `btnAdvanceThread_Click`
- `btnThreadApply_Click`

### 18.11 Episodes
- `lstSeries_SelectedIndexChanged`
- `lstEpisodes_SelectedIndexChanged`
- `gridEpisodeEntries_SelectionChanged`
- `btnSeriesAdd_Click`
- `btnSeriesDelete_Click`
- `btnEpisodeAdd_Click`
- `btnEpisodeDelete_Click`
- `btnEpisodeDuplicate_Click`
- `btnEpisodeLock_Click`
- `btnEpisodeGenerateOne_Click`
- `btnEpisodeGenerateMany_Click`
- `btnEpisodeGenerateNotice_Click`
- `btnEpisodeRegenerateSelected_Click`
- `btnEpisodeDuplicateEntry_Click`
- `btnEpisodeDeleteEntry_Click`
- `btnEpisodeMoveEntryUp_Click`
- `btnEpisodeMoveEntryDown_Click`
- `btnEntryApply_Click`
- `btnEntryReset_Click`
- `btnDeclaredCargoAdd_Click`
- `btnDeclaredCargoDelete_Click`
- `btnActualCargoAdd_Click`
- `btnActualCargoDelete_Click`
- `btnDeclaredPassengerAdd_Click`
- `btnDeclaredPassengerDelete_Click`
- `btnActualPassengerAdd_Click`
- `btnActualPassengerDelete_Click`

### 18.12 Preview
- `btnPreviewRenderSelectedEpisode_Click`
- `btnPreviewCopyToClipboard_Click`
- `btnPreviewExportText_Click`

### 18.13 Validation
- `btnValidationRunProject_Click`
- `btnValidationRunEpisode_Click`

---

## 19. CRUD expectations

The application should implement practical CRUD over all top-level collections.

At minimum:
- add item
- delete item
- duplicate item where sensible
- edit item in grid or detail panel
- apply/save changes
- refresh dependent dropdowns after edits

Important:
- IDs should remain stable
- deleting referenced items should either be blocked or validated clearly
- list selections should preserve context where possible

---

## 20. Data binding approach

Use `BindingList<T>` or `BindingSource` for grid-based WinForms editing.

Expected approach:
- `BindingSource` per major tab
- helper methods to rebind grids after project load or collection switch
- lookup columns via `DataGridViewComboBoxColumn` where appropriate

Implement practical helper methods in `MainForm` or helper classes for:
- loading current collection into a grid
- refreshing combo box data sources
- syncing selected entity into detail controls

---

## 21. Output and rendering behaviour

The application should render using standard order, omitting absent optional blocks.

### 21.1 Traffic entries
Preferred order:
1. header
2. vessel identity and movement
3. declared purpose (optional)
4. cargo block (optional)
5. passenger block (optional)
6. manifest status (optional)
7. inspection status (optional)
8. clearance status
9. route/trajectory status (optional)
10. environmental condition (optional)
11. directive (optional)
12. incident phrase (optional)
13. resolution phrase (optional)
14. closing line

### 21.2 Notices
Preferred order:
1. notice header
2. body line(s)
3. affected areas (optional)
4. duration or until further notice (optional)
5. closing line

### 21.3 Formatting style
- use `.--` punctuation cadence
- no florid prose
- dry, consistent tone
- preserve repeated structure

---

## 22. Search support

At minimum provide utility methods or future-ready structure for searching by:
- vessel name or registry
- station name
- commodity name
- directive
- thread name
- anomaly type

A full search UI is optional in the first implementation, but internal services should not make later search difficult.

---

## 23. Acceptance criteria

The implementation is considered successful when all of the following are true:

1. Project can be created, saved, loaded.
2. Reference vocabulary is editable and stored in JSON.
3. World entities are editable and reference each other by ID.
4. Episodes can be created and edited.
5. Entries can be generated and manually overridden.
6. Public and hidden truth are both supported in entry data.
7. Rendered output follows consistent broadcast format.
8. Story threads can be created, edited, and advanced.
9. Validation catches basic contradictions.
10. Sample project loads with useful starter data.
11. UI control names and event handlers exist as specified above.

---

## 24. Explicit non-goals for now

Do **not** spend time on these yet unless trivial:
- cloud sync
- database backend
- user accounts
- multiplayer collaboration
- fancy custom control libraries
- drag-drop timeline editors
- audio generation / TTS
- advanced theming

JSON files + standard WinForms controls are sufficient.

---

## 25. Implementation order

Build in this order:

### Phase 1
- project setup
- models
- enums
- persistence service
- seed factory

### Phase 2
- main form shell
- tabs and controls with specified names
- load/save/new wiring
- simple grid binding for main collections

### Phase 3
- reference-data editing
- world-data editing
- combo refresh infrastructure

### Phase 4
- episode model editing
- entry editor
- preview tab

### Phase 5
- rendering service
- validation service

### Phase 6
- generation service
- weighted selection
- thread progression
- seed story thread

### Phase 7
- polish, duplication helpers, locking, export text, filtering

---

## 26. Constraints for Claude Code

These are important.

1. Do not collapse public and hidden truth into a single field.
2. Do not hard-code vocabulary that should be editable data.
3. Do not make the generator purely random; it must be weighted and able to respect thread progression.
4. Do not make prose the primary data store.
5. Do not invent a radically different architecture.
6. Use the class names and form/control names given above unless there is a compile-blocking issue.
7. Keep code readable and pragmatic.
8. Prefer simple service classes over excessive abstraction.
9. Add comments where the user is likely to extend logic later.
10. Ensure the project compiles.

---

## 27. Suggested follow-up prompt to Claude Code

Use this after providing the full brief above:

```text
Read the attached brief carefully and implement the project exactly to that specification.

Priorities:
1. correct architecture
2. correct models and JSON persistence
3. correct WinForms shell and named controls/events
4. practical CRUD and binding
5. renderer, validator, generator, and thread system scaffolding

Do not simplify away the public-vs-hidden truth model.
Do not replace editable reference data with enums except for the explicitly permitted technical enums.
Do not redesign the form/control naming unless absolutely necessary.

Produce a compilable .NET 8 WinForms solution named PodcastUniverseEditor.
Where WinForms designer-generated UI is awkward, still create the form classes, partial classes, named controls, and event handlers so the user can refine layout by hand.

Seed the project with sample data and at least one recurring story thread involving the vessel Wolfgang Amadeus.

After generating the code, provide a concise summary of:
- what was created
- any areas left intentionally basic
- any manual UI tweaks that may still be convenient
```

---

## 28. Optional second prompt for refinement pass

```text
Now audit the generated solution against the brief.

Check specifically:
- form and control names
- event handler presence
- class names and namespaces
- public/hidden truth fields
- JSON save/load correctness
- seed data completeness
- renderer output format
- thread progression model
- validation coverage

Patch any deviations from the spec.
Then list remaining limitations honestly.
```

---

## 29. Optional third prompt for generator improvement later

```text
Improve only the generation logic.
Do not change the UI structure or domain model unless necessary.

Focus on:
- weighted route and cargo selection
- subtle anomaly injection
- story thread progression
- recurring vessels and directives
- avoiding over-stacked anomalies
- generating mostly ordinary traffic with light intrigue

Keep the tone procedural and understated.
```

