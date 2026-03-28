using PodcastUniverseEditor.Models;
using PodcastUniverseEditor.Models.Common;
using PodcastUniverseEditor.Models.Episodes;
using PodcastUniverseEditor.Models.ReferenceData;
using PodcastUniverseEditor.Models.Threads;
using PodcastUniverseEditor.Models.World;
using PodcastUniverseEditor.Utilities;

namespace PodcastUniverseEditor.Services.Seeds;

/// <summary>
/// Produces a fully populated starter PodcastProject with reference vocabulary,
/// a small universe, sample routes, and one seeded story thread for Wolfgang Amadeus.
/// All IDs are stable within a single call — cross-references are wired correctly.
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

    // ────────────────────────────────────────────────────────────────────────
    // Reference data
    // ────────────────────────────────────────────────────────────────────────

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
                d.HeaderFormat = "Holding pattern notation — {Station}.--";
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
                d.PublicDescription = "Scheduled arrival — no docking request received.";
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

    // ────────────────────────────────────────────────────────────────────────
    // World
    // ────────────────────────────────────────────────────────────────────────

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
            World<RouteRecord>("rt-helios-mars",   "Helios Gate — Mars Prime",    r => {
                r.FromStationId = "stn-helios-gate"; r.ToStationId = "stn-mars-prime";
                r.FrequencyWeight = 2.0; r.RiskWeight = 1.0;
                r.AllowedVesselClassIds = new() { "vc-bulk", "vc-freighter", "vc-tanker", "vc-personnel" };
                r.TypicalCommodityIds = new() { "com-lox", "com-nitrogen", "com-plating", "com-seed" };
                r.TypicalPurposeIds = new() { "pu-ore", "pu-fuel", "pu-agri", "pu-crew" };
                r.RouteConditionTemplateId = "pt-rs1";
            }),
            World<RouteRecord>("rt-helios-virex",  "Helios Gate — Virex Belt",    r => {
                r.FromStationId = "stn-helios-gate"; r.ToStationId = "stn-virex-belt";
                r.FrequencyWeight = 1.5; r.RiskWeight = 1.2;
                r.AllowedVesselClassIds = new() { "vc-bulk", "vc-freighter", "vc-maintenance" };
                r.TypicalCommodityIds = new() { "com-nickel", "com-copper", "com-lox" };
                r.TypicalPurposeIds = new() { "pu-ore", "pu-maint", "pu-fuel" };
                r.RouteConditionTemplateId = "pt-rs1";
            }),
            World<RouteRecord>("rt-helios-luma",   "Helios Gate — Luma Station",  r => {
                r.FromStationId = "stn-helios-gate"; r.ToStationId = "stn-luma";
                r.FrequencyWeight = 1.0; r.RiskWeight = 1.0;
                r.AllowedVesselClassIds = new() { "vc-freighter", "vc-bulk", "vc-courier" };
                r.TypicalCommodityIds = new() { "com-seed", "com-lox" };
                r.TypicalPurposeIds = new() { "pu-agri", "pu-diplomatic" };
                r.RouteConditionTemplateId = "pt-rs2";
            }),
            World<RouteRecord>("rt-helios-kepler", "Helios Gate — Kepler Anchorage",r => {
                r.FromStationId = "stn-helios-gate"; r.ToStationId = "stn-kepler";
                r.FrequencyWeight = 0.7; r.RiskWeight = 1.5;
                r.AllowedVesselClassIds = new() { "vc-courier", "vc-freighter", "vc-maintenance" };
                r.TypicalCommodityIds = new() { "com-containers", "com-medical" };
                r.TypicalPurposeIds = new() { "pu-internal", "pu-customs", "pu-diplomatic" };
            }),
            World<RouteRecord>("rt-virex-luma",    "Virex Belt — Luma Station",   r => {
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
                // No operator deliberately — part of the mystery
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

    // ────────────────────────────────────────────────────────────────────────
    // Episodes
    // ────────────────────────────────────────────────────────────────────────

    private void SeedEpisodes(PodcastProject p)
    {
        var series = new PodcastSeriesRecord
        {
            Id = "ser-001",
            Name = "Helios Gate Dispatch — Series One",
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
            Name = "Departure — Helios Dawn",
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

    // ────────────────────────────────────────────────────────────────────────
    // Story threads
    // ────────────────────────────────────────────────────────────────────────

    private void SeedStoryThreads(PodcastProject p)
    {
        // Wolfgang Amadeus identity/transponder irregularity thread.
        // Beats progress from ordinary to increasingly suspicious appearances.
        // Stage -1 = not yet applied; advances 1 at a time by the StoryThreadService.

        var thread = new StoryThreadRecord
        {
            Id = "thread-wolfgang",
            Name = "Wolfgang Amadeus — Identity Thread",
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
                // Beat 0 — ordinary diplomatic courier, no anomaly
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 0 — Ordinary",
                    StageIndex = 0,
                    PublicManifestStatusId = "ms-verified",
                    PublicInspectionStatusId = "is-none",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = null,
                    ResolutionPhraseTemplateId = null,
                    HiddenTruthSummary = "Normal diplomatic run. Nothing unusual recorded.",
                    Severity = SeverityLevel.Minor
                },
                // Beat 1 — manifest verification pending
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 1 — Manifest Pending",
                    StageIndex = 1,
                    PublicManifestStatusId = "ms-pending",
                    PublicInspectionStatusId = "is-none",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = null,
                    ResolutionPhraseTemplateId = "pt-r3",
                    HiddenTruthSummary = "Manifest filing delayed. Vessel claims administrative backlog.",
                    Severity = SeverityLevel.Minor
                },
                // Beat 2 — customs notation filed
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 2 — Customs Notation",
                    StageIndex = 2,
                    PublicManifestStatusId = "ms-amended",
                    PublicInspectionStatusId = "is-customs",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = "pt-i3",
                    ResolutionPhraseTemplateId = "pt-r3",
                    HiddenTruthSummary = "Customs flagged undeclared personal effects. Vessel crew uncooperative but released.",
                    Severity = SeverityLevel.Minor
                },
                // Beat 3 — transponder verification incomplete
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 3 — Transponder Issue",
                    StageIndex = 3,
                    PublicManifestStatusId = "ms-verified",
                    PublicInspectionStatusId = "is-deferred",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = "pt-i4",
                    ResolutionPhraseTemplateId = "pt-r3",
                    HiddenTruthSummary = "Transponder cycling through multiple ID codes on approach. Port authority log entry filed.",
                    Severity = SeverityLevel.Moderate
                },
                // Beat 4 — identification signal irregularity noted
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 4 — Signal Irregularity",
                    StageIndex = 4,
                    PublicManifestStatusId = "ms-pending",
                    PublicInspectionStatusId = "is-customs",
                    PublicDirectiveId = null,
                    IncidentPhraseTemplateId = "pt-i5",
                    ResolutionPhraseTemplateId = "pt-r3",
                    HiddenTruthSummary = "Registry WA-1141 does not match hull markings on visual inspection. Second filing submitted.",
                    Severity = SeverityLevel.Moderate
                },
                // Beat 5 — cleared under directive
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 5 — Directive Clearance",
                    StageIndex = 5,
                    PublicManifestStatusId = "ms-verified",
                    PublicInspectionStatusId = "is-complete",
                    PublicDirectiveId = "dir-7",
                    IncidentPhraseTemplateId = "pt-i5",
                    ResolutionPhraseTemplateId = "pt-r2",
                    HiddenTruthSummary = "Directive 7 invoked by port authority contact. Inspection results sealed. Vessel cleared without standard documentation.",
                    Severity = SeverityLevel.Major
                },
                // Beat 6 — scheduled arrival, no docking request received
                new() {
                    Id = IdHelper.NewId(), Name = "Stage 6 — Silent Arrival",
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

    // ────────────────────────────────────────────────────────────────────────
    // Helpers
    // ────────────────────────────────────────────────────────────────────────

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
