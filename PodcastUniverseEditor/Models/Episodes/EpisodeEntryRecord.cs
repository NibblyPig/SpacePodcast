using PodcastUniverseEditor.Models.Common;

namespace PodcastUniverseEditor.Models.Episodes;

/// <summary>
/// A single entry in a podcast episode — either a traffic movement or a broadcast notice.
/// The public layer (Declared*, ManifestStatusId, etc.) drives rendered output.
/// The hidden layer (Actual*, HiddenTruthNotes) is the narrator's private truth.
/// </summary>
public class EpisodeEntryRecord : AuditableEntityBase
{
    // ── Structural ──────────────────────────────────────────────────────────

    public EntryKind EntryKind { get; set; } = EntryKind.Traffic;
    public EntrySourceType SourceType { get; set; } = EntrySourceType.Manual;
    public int SortOrder { get; set; } = 0;

    // ── Operation / Notice type ──────────────────────────────────────────────

    /// <summary>References OperationTypeDefinition.Id. Null for notices.</summary>
    public string? OperationTypeId { get; set; }

    /// <summary>References NoticeTypeDefinition.Id. Null for traffic entries.</summary>
    public string? NoticeTypeId { get; set; }

    // ── Location ─────────────────────────────────────────────────────────────

    /// <summary>References StationRecord.Id — the station where this event is logged.</summary>
    public string? StationId { get; set; }

    /// <summary>References DockRecord.Id</summary>
    public string? DockId { get; set; }

    // ── Vessel ───────────────────────────────────────────────────────────────

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

    // ── Route ────────────────────────────────────────────────────────────────

    /// <summary>References StationRecord.Id</summary>
    public string? OriginStationId { get; set; }

    /// <summary>References StationRecord.Id</summary>
    public string? DestinationStationId { get; set; }

    // ── Purpose (public / hidden split) ─────────────────────────────────────

    /// <summary>References PurposeDefinition.Id — what is declared to port authority.</summary>
    public string? DeclaredPurposeId { get; set; }

    /// <summary>References PurposeDefinition.Id — what the vessel is actually doing.</summary>
    public string? ActualPurposeId { get; set; }

    // ── Cargo (public / hidden split) ────────────────────────────────────────

    /// <summary>Cargo lines as declared in the manifest. These appear in rendered output.</summary>
    public List<EntryCargoLine> DeclaredCargo { get; set; } = new();

    /// <summary>
    /// The actual cargo, which may differ from declared.
    /// Lines with IsHiddenTruthOnly = true do not appear in rendering.
    /// </summary>
    public List<EntryCargoLine> ActualCargo { get; set; } = new();

    // ── Passengers (public / hidden split) ───────────────────────────────────

    public List<EntryPassengerLine> DeclaredPassengers { get; set; } = new();
    public List<EntryPassengerLine> ActualPassengers { get; set; } = new();

    // ── Statuses ─────────────────────────────────────────────────────────────

    /// <summary>References ManifestStatusDefinition.Id</summary>
    public string? ManifestStatusId { get; set; }

    /// <summary>References InspectionStatusDefinition.Id</summary>
    public string? InspectionStatusId { get; set; }

    /// <summary>References ClearanceStatusDefinition.Id</summary>
    public string? ClearanceStatusId { get; set; }

    /// <summary>References EnvironmentalConditionDefinition.Id</summary>
    public string? EnvironmentalConditionId { get; set; }

    // ── Narrative overlays ───────────────────────────────────────────────────

    /// <summary>References DirectiveDefinition.Id — authority invoked for irregular clearance.</summary>
    public string? DirectiveId { get; set; }

    /// <summary>References PhraseTemplate.Id — incident phrase appended after statuses.</summary>
    public string? IncidentPhraseTemplateId { get; set; }

    /// <summary>References PhraseTemplate.Id — resolution phrase appended after incident.</summary>
    public string? ResolutionPhraseTemplateId { get; set; }

    /// <summary>References PhraseTemplate.Id — route/trajectory status phrase.</summary>
    public string? RouteStatusPhraseTemplateId { get; set; }

    /// <summary>
    /// Allows the author to write a completely custom spoken body for a notice entry,
    /// bypassing template rendering. Not used for traffic entries.
    /// </summary>
    public string? PublicBodyOverride { get; set; }

    // ── Hidden truth ─────────────────────────────────────────────────────────

    /// <summary>
    /// Private notes about what is really happening. Never rendered in spoken output.
    /// </summary>
    public string? HiddenTruthNotes { get; set; }

    // ── Story thread ─────────────────────────────────────────────────────────

    /// <summary>References StoryThreadRecord.Id</summary>
    public string? StoryThreadId { get; set; }

    /// <summary>References StoryBeatRecord.Id within the thread.</summary>
    public string? AppliedStoryBeatId { get; set; }

    /// <summary>The narrative severity of the anomaly applied to this entry, if any.</summary>
    public SeverityLevel? AnomalySeverity { get; set; }

    // ── State ────────────────────────────────────────────────────────────────

    /// <summary>
    /// Locked entries may not be regenerated without explicit user action.
    /// </summary>
    public bool IsLocked { get; set; } = false;

    /// <summary>
    /// Canon entries are part of the official timeline. Future generation must
    /// not contradict them. Set automatically when the parent episode is locked.
    /// </summary>
    public bool IsCanon { get; set; } = false;

    // ── Generation metadata ──────────────────────────────────────────────────

    /// <summary>The random seed used when this entry was generated. Enables reproducible regeneration.</summary>
    public int? RandomSeed { get; set; }

    // ── Render options ───────────────────────────────────────────────────────

    public EntryRenderOptions RenderOptions { get; set; } = new();

    /// <summary>Optional in-universe date/time this entry is scheduled for.</summary>
    public DateTime? ScheduledUtc { get; set; }
}
