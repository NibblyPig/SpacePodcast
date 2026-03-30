using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using PodcastUniverseEditor.Models;
using PodcastUniverseEditor.Models.Common;
using PodcastUniverseEditor.Models.Episodes;
using PodcastUniverseEditor.Models.ReferenceData;
using PodcastUniverseEditor.Models.Threads;
using PodcastUniverseEditor.Models.Validation;
using PodcastUniverseEditor.Models.World;
using PodcastUniverseEditor.Services.AppState;
using PodcastUniverseEditor.Services.Lookup;
using PodcastUniverseEditor.Services.Persistence;
using PodcastUniverseEditor.Services.Export;
using PodcastUniverseEditor.Services.Generation;
using PodcastUniverseEditor.Services.Rendering;
using PodcastUniverseEditor.Services.Seeds;
using PodcastUniverseEditor.Services.Validation;
using PodcastUniverseEditor.UI;

namespace PodcastUniverseEditor.UI.Forms;

public partial class MainForm : Form
{
    // ── Services ─────────────────────────────────────────────────────────────

    private readonly AppStateService _appState;
    private readonly ProjectFileService _fileService;
    private readonly ProjectSeedFactory _seedFactory;

    // ── Stateless services ────────────────────────────────────────────────────

    private readonly EntryRenderingService _renderer = new();
    private readonly ProjectValidationService _validator = new();
    private readonly EpisodeGenerationService _generator = new();
    private readonly ProjectExportService _exportService = new();

    // ── Lookup — recreated on every project change ────────────────────────────

    private ProjectLookupService? _lookup;

    // ── Entry detail state ────────────────────────────────────────────────────

    /// <summary>True while LoadEntryIntoDetailPanel is running — suppresses write-back handlers.</summary>
    private bool _loadingEntry;

    /// <summary>True while LoadEpisodeIntoMetaPanel is running — suppresses episode/series write-back handlers.</summary>
    private bool _loadingEpisodeMeta;

    /// <summary>True while btnClearEntryFilters is resetting controls — suppresses redundant ApplyEntryFilter calls.</summary>
    private bool _clearingEntryFilters;

    // ── BindingSources — one per major collection ─────────────────────────────

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

    // ── Filter views — non-destructive filtered projections of project lists ────

    private readonly BindingList<EpisodeRecord> _episodesView = new();
    private readonly BindingList<EpisodeEntryRecord> _entriesView = new();

    // ── Reference type catalogue ──────────────────────────────────────────────

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

    // ── Constructor ───────────────────────────────────────────────────────────

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

    // ── Initialisation ────────────────────────────────────────────────────────

    private void MainForm_Load(object? sender, EventArgs e)
    {
        PopulateReferenceTypesList();
        SetupEpisodeEntryColumns();

        // Overview text-changed handlers — subscribed once here, never in LoadProjectIntoUI.
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

        // Dirty tracking for all major editable grids — subscribed once here.
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
        // _bsEntries is NOT included — its DataSource is _entriesView (a filter projection)
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

        // Bind entry list to its filter view — done once; ApplyEntryFilter repopulates _entriesView.
        _bsEntries.DataSource = _entriesView;
        gridEpisodeEntries.DataSource = _bsEntries;

        // Entry detail write-back handlers — subscribed once here
        HookEntryDetailHandlers();

        // Episode/series metadata write-back handlers — subscribed once here
        HookEpisodeMetaHandlers();

        // Stations grid consistency — StarSystem/CelestialBody coupling
        HookStationsGridConsistency();

        _appState.SetProject(_fileService.CreateNewProject(), null);
        SetStatus("Ready");
    }

    // ── AppState event callbacks ──────────────────────────────────────────────

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

    // ── Project loading ───────────────────────────────────────────────────────

    /// <summary>
    /// Binds all grids and text fields to the current project.
    /// Must only assign values and set DataSources — no event subscriptions here.
    /// </summary>
    private void LoadProjectIntoUI()
    {
        var p = _appState.CurrentProject;

        // Overview — assign only; TextChanged handlers are already wired in MainForm_Load
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

        // Threads — beats grid is managed by gridThreads.SelectionChanged
        _bsThreads.DataSource = p.StoryThreads;
        gridThreads.DataSource = _bsThreads;

        // Series list — bound directly to project's Series list.
        _bsSeries.DataSource = p.Series;
        lstSeries.DataSource = _bsSeries;
        lstSeries.DisplayMember = "Name";

        // Episodes — bound to _episodesView so filtering is non-destructive.
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
        // dirty. Clear that flag — the project is genuinely clean immediately after a load.
        _appState.MarkClean();
    }

    // ── Reference data ────────────────────────────────────────────────────────

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

    // ── Systems & Bodies ─────────────────────────────────────────────────────

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

    // ── Stations & Docks ─────────────────────────────────────────────────────

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

    // ── Organisations & Directives ────────────────────────────────────────────

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

    // ── Thread selection ──────────────────────────────────────────────────────

    private void gridThreads_SelectionChanged(object? sender, EventArgs e)
    {
        // _bsThreads.Current tracks the selected DataGridView row via BindingSource sync.
        var thread = _bsThreads.Current as StoryThreadRecord;
        _bsThreadBeats.DataSource = thread?.Beats;
        gridThreadBeats.DataSource = _bsThreadBeats;
    }

    // ── Episodes ──────────────────────────────────────────────────────────────

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

    // ── Series management ─────────────────────────────────────────────────────

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

        // Select the new series by ID — triggers lstSeries_SelectedIndexChanged → ApplyEpisodeFilter
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
            RenderOptions = new EntryRenderOptions()  // all sections enabled — standard traffic defaults
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

        // Deep-copy via JSON round-trip — same approach used for episode duplication.
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
    /// Priority: episode BroadcastStationId → series BroadcastStationId → null.
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
        if (targetIdx < 0 || targetIdx >= list.Count) return; // already at boundary — do nothing

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

    // ── Generation ────────────────────────────────────────────────────────────

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
            SetStatus($"{actionLabel}. Validation: {errors} error(s), {warnings} warning(s) — see Validation tab.");
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

    // ── Validation ────────────────────────────────────────────────────────────

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

    // ── Menu handlers ─────────────────────────────────────────────────────────

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

    // ── Toolbar handlers ──────────────────────────────────────────────────────

    private void btnNewProject_Click(object? sender, EventArgs e) => mnuFileNew_Click(sender, e);
    private void btnOpenProject_Click(object? sender, EventArgs e) => mnuFileOpen_Click(sender, e);
    private void btnSaveProject_Click(object? sender, EventArgs e) => mnuFileSave_Click(sender, e);

    // ── Overview handlers ─────────────────────────────────────────────────────

    private void btnLoadSampleProject_Click(object? sender, EventArgs e)
    {
        if (!ConfirmDiscardChanges()) return;
        var project = _seedFactory.CreateSampleProject();
        _appState.SetProject(project, null);
        _appState.MarkDirty();
        SetStatus("Sample project loaded.");
    }

    // ── Save helper ───────────────────────────────────────────────────────────

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

    // ── Refresh helpers ───────────────────────────────────────────────────────

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

    // ── Reference data factory ────────────────────────────────────────────────

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
    /// Example: PlaceholderCode("OperationTypes", 3) → "new-operation-type-003"
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

    // ── UI state helpers ──────────────────────────────────────────────────────

    private void UpdateTitleBar()
    {
        string file = string.IsNullOrEmpty(_appState.CurrentFilePath)
            ? "Untitled"
            : Path.GetFileName(_appState.CurrentFilePath);
        Text = $"PodcastUniverseEditor — {file}{(_appState.IsDirty ? " *" : string.Empty)}";
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

    // ── Setup helpers (called from MainForm_Load) ─────────────────────────────

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
            // CommitEdit immediately only for checkbox cells — forces CellValueChanged to fire
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

    // ── Entry detail panel ────────────────────────────────────────────────────

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

        // Code enum combos — bind directly to enum values, not LookupItems
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

            // Story thread — refresh beats first, then set beat
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

            // Manifest grids — BindingList wraps actual list by reference so grid edits flow through
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
    /// Incident and resolution phrase controls are shared — both kinds use them in the renderer.
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
    /// Advisory only — does not block editing or modify data.
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
                Text = "⚠ " + message,
                AutoSize = true,
                Margin = new Padding(0, 1, 0, 1),
                ForeColor = Color.FromArgb(120, 60, 0)
            };
            flpValidationHints.Controls.Add(lbl);
        }

        // ── General ──────────────────────────────────────────────────────────

        if (string.IsNullOrWhiteSpace(entry.Name))
            Warn("Entry name is empty");

        if (string.IsNullOrEmpty(entry.IncidentPhraseTemplateId) &&
            string.IsNullOrEmpty(entry.ResolutionPhraseTemplateId))
            Warn("Both incident and resolution phrases are missing");

        // ── EntryKind mismatch ────────────────────────────────────────────────

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

        // ── Traffic completeness ──────────────────────────────────────────────

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

        // ── Logical inconsistencies ───────────────────────────────────────────

        if (!string.IsNullOrEmpty(entry.OriginStationId) &&
            !string.IsNullOrEmpty(entry.DestinationStationId) &&
            entry.OriginStationId == entry.DestinationStationId)
            Warn("Origin and destination are the same station");

        if (entry.DeclaredCargo.Count == 0 && entry.ActualCargo.Count > 0)
            Warn("Declared cargo empty but actual cargo is present");

        if (entry.DeclaredPassengers.Count == 0 && entry.ActualPassengers.Count > 0)
            Warn("Declared passengers empty but actual passengers are present");

        // ── World rules ───────────────────────────────────────────────────────

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

        // ── Show/hide ─────────────────────────────────────────────────────────

        flpValidationHints.Visible = flpValidationHints.Controls.Count > 0;
    }

    /// <summary>
    /// Wires all write-back event handlers for the entry detail panel controls.
    /// Called once from MainForm_Load. Each handler guards on _loadingEntry.
    /// All write-backs call RefreshRenderedOutput() so txtRenderedOutput stays live.
    /// </summary>
    private void HookEntryDetailHandlers()
    {
        // Helper — look up current entry.
        // Returns null if none selected, OR if the entry is immutable (locked/canon).
        // This suppresses all write-backs for locked/canon entries without modifying each handler.
        EpisodeEntryRecord? Entry()
        {
            var entry = GetSelectedEntry();
            return (entry == null || IsEntryImmutable(entry)) ? null : entry;
        }

        // ── Structural ────────────────────────────────────────────────────────

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

        // ── Lookup combos ─────────────────────────────────────────────────────
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

        // ── Story thread — also refreshes beats combo ─────────────────────────

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

        // ── Anomaly severity ──────────────────────────────────────────────────

        cboEntryAnomalySeverity.SelectedIndexChanged += (_, _) =>
        {
            if (_loadingEntry) return;
            var e = Entry(); if (e == null) return;
            var id = GetSelectedLookupId(cboEntryAnomalySeverity);
            e.AnomalySeverity = string.IsNullOrEmpty(id) ? null : Enum.Parse<SeverityLevel>(id);
            UpdateEntryPreview(e);
            _appState.MarkDirty();
        };

        // ── Schedule ──────────────────────────────────────────────────────────

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

    // ── Entry detail helpers ──────────────────────────────────────────────────

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

    // ── Rendered output ───────────────────────────────────────────────────────

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

    // ── Episode tools ─────────────────────────────────────────────────────────

    private void btnEpisodeMoveUp_Click(object? sender, EventArgs e)
        => MoveSelectedEpisode(direction: -1);

    private void btnEpisodeMoveDown_Click(object? sender, EventArgs e)
        => MoveSelectedEpisode(direction: +1);

    /// <summary>
    /// Moves the currently selected episode one position up (direction = -1) or down (+1)
    /// within the currently selected series, then reapplies the filter and preserves selection.
    /// Operates on p.Episodes (authoritative order); EpisodeIds is rebuilt via SyncSeriesEpisodeIds.
    /// A selected series is required — episodes are never moved across series boundaries.
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
        if (targetPosInSeries < 0 || targetPosInSeries >= inSeries.Count) return; // at boundary — do nothing

        // Swap the two episodes in the global list
        int idxA = inSeries[posInSeries].GlobalIndex;
        int idxB = inSeries[targetPosInSeries].GlobalIndex;
        (p.Episodes[idxA], p.Episodes[idxB]) = (p.Episodes[idxB], p.Episodes[idxA]);

        SyncSeriesEpisodeIds(p);
        ApplyEpisodeFilter();

        // Restore selection by ID — robust under active search filters
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

        // Deep copy via JSON round-trip — captures all nested lists (entries, cargo, passengers)
        // without shared references.
        var opts = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
        var json = JsonSerializer.Serialize(ep, opts);
        var copy = JsonSerializer.Deserialize<EpisodeRecord>(json, opts)!;

        // Fresh episode identity — canon lock cleared; duplicate starts as an editable draft.
        copy.Id = Guid.NewGuid().ToString();
        copy.CreatedUtc = DateTime.UtcNow;
        copy.ModifiedUtc = DateTime.UtcNow;
        copy.IsCanonicalLocked = false;
        copy.Name = string.IsNullOrWhiteSpace(ep.Name)
            ? "Episode Copy"
            : $"{ep.Name} Copy";

        // SeriesId is preserved from the JSON copy — duplicate stays in the same series.

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

        // Select the new episode by ID — more robust than Count - 1 under active filters.
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
            "This cannot be reversed from the episode level — entries must be unlocked individually.",
            "Confirm Canon Lock", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        // Mark episode-level lock
        ep.IsCanonicalLocked = true;

        // Mark all entries as canon history and individually locked.
        // Rule: locking an episode stamps every entry as immutable canon.
        // Unlocking the episode later only clears the episode flag — entries stay tagged.
        foreach (var entry in ep.Entries)
        {
            entry.IsCanon = true;
            entry.IsLocked = true;
        }

        UpdateEpisodeSummary(ep);
        ApplyEntryFilter(ep);     // refresh grid to show updated canon/locked columns
        _appState.MarkDirty();
        SetStatus($"Episode '{ep.Name}' locked as canon — all entries marked locked and canon.");
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
        SetStatus($"Episode '{ep.Name}' unlocked. Entry locks remain — unlock entries individually to edit.");
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

    // ── Manifest cargo/passenger handlers ────────────────────────────────────

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

    // ── Filter handlers ───────────────────────────────────────────────────────

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

    // ── Filter view helpers ───────────────────────────────────────────────────

    private void ApplyEpisodeFilter()
    {
        var p = _appState.CurrentProject;
        string search = txtEpisodeSearch.Text.Trim().ToLowerInvariant();
        var selectedSeries = _bsSeries.Current as PodcastSeriesRecord;

        _episodesView.RaiseListChangedEvents = false;
        _episodesView.Clear();
        foreach (var ep in p.Episodes)
        {
            // Series filter — skip episodes not in the selected series (if one is selected)
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

    // ── Thread / episode summaries ────────────────────────────────────────────

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
        string lockStatus = ep.IsCanonicalLocked ? "[CANON LOCKED — immutable]" : "[unlocked]";
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

    // ── Manifest grid column setup ────────────────────────────────────────────

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
        //    When CelestialBody changes and StarSystem is unset, infer it from the body.
        gridStations.CellValueChanged += (_, e) =>
        {
            if (e.RowIndex < 0) return;
            if (_bsStations[e.RowIndex] is not StationRecord station) return;

            var colName = gridStations.Columns[e.ColumnIndex]?.Name;

            if (colName == "colStationStarSystem")
            {
                if (string.IsNullOrEmpty(station.CelestialBodyId)) return;
                var body = _appState.CurrentProject.CelestialBodies
                    .FirstOrDefault(b => b.Id == station.CelestialBodyId);
                if (body == null || body.StarSystemId == station.StarSystemId) return;
                station.CelestialBodyId = null;
                gridStations.InvalidateRow(e.RowIndex);
                _bsStations.ResetItem(e.RowIndex);
            }
            else if (colName == "colStationBody")
            {
                if (string.IsNullOrEmpty(station.CelestialBodyId)) return;
                if (!string.IsNullOrEmpty(station.StarSystemId)) return;
                var body = _appState.CurrentProject.CelestialBodies
                    .FirstOrDefault(b => b.Id == station.CelestialBodyId);
                if (body == null || string.IsNullOrEmpty(body.StarSystemId)) return;
                station.StarSystemId = body.StarSystemId;
                gridStations.InvalidateRow(e.RowIndex);
                _bsStations.ResetItem(e.RowIndex);
            }
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

    // ── Episode / series metadata panel ──────────────────────────────────────

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
            // Series section is not loaded here — it is driven by lstSeries selection.
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

        // Series() returns the series selected in lstSeries — that is the authoritative
        // series for the series metadata section, regardless of which episode is selected.
        PodcastSeriesRecord? Series() => _bsSeries.Current as PodcastSeriesRecord;

        // ── Episode fields ────────────────────────────────────────────────────

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
        // canon lock state — those buttons enforce the full semantics (entry stamping,
        // confirmation dialogs). This prevents inconsistent episode state.

        txtEpisodeNotes.TextChanged += (_, _) =>
        {
            if (_loadingEpisodeMeta) return;
            var ep = Ep(); if (ep == null) return;
            ep.Notes = txtEpisodeNotes.Text;
            _appState.MarkDirty();
        };

        // ── Series fields ─────────────────────────────────────────────────────

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

    // ── Export handlers ───────────────────────────────────────────────────────

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
            SetStatus($"JSON exported: {defaultName}{(debugMode ? " [debug mode — contains hidden truth]" : string.Empty)}");

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

    // ── Entry preview ─────────────────────────────────────────────────────────

    /// <summary>
    /// Builds a structured editor inspection summary for the selected entry.
    /// This is not rendered script output — it is a human-readable audit of all set fields.
    /// Omits fields that are null/empty/default to keep it concise.
    /// </summary>
    private void UpdateEntryPreview(EpisodeEntryRecord? entry)
    {
        if (entry == null || _lookup == null) { txtEpisodeEntryPreview.Clear(); return; }

        var sb = new System.Text.StringBuilder();

        // ── Header line ──────────────────────────────────────────────────────

        string lockFlag = entry.IsLocked ? " [LOCKED]" : string.Empty;
        string canonFlag = entry.IsCanon ? " [CANON]" : string.Empty;
        sb.AppendLine($"#{entry.SortOrder}  {entry.EntryKind} / {entry.SourceType}{lockFlag}{canonFlag}");
        if (!string.IsNullOrEmpty(entry.Name))
            sb.AppendLine($"Name:         {entry.Name}");

        // ── Operation / Notice ───────────────────────────────────────────────

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

        // ── Location ─────────────────────────────────────────────────────────

        if (entry.StationId != null)
            sb.AppendLine($"Station:      {_lookup.StationName(entry.StationId)}");
        if (entry.DockId != null)
            sb.AppendLine($"Dock:         {_lookup.DockName(entry.DockId)}");

        // ── Vessel ───────────────────────────────────────────────────────────

        if (entry.VesselId != null)
            sb.AppendLine($"Vessel:       {_lookup.VesselName(entry.VesselId)}");
        if (entry.VesselClassOverrideId != null)
            sb.AppendLine($"Class (ovrd): {_lookup.VesselClassName(entry.VesselClassOverrideId)}");
        if (!string.IsNullOrEmpty(entry.RegistryOverride))
            sb.AppendLine($"Registry:     {entry.RegistryOverride} [override]");

        // ── Route ────────────────────────────────────────────────────────────

        if (entry.OriginStationId != null || entry.DestinationStationId != null)
            sb.AppendLine($"Route:        {_lookup.StationName(entry.OriginStationId)} → {_lookup.StationName(entry.DestinationStationId)}");

        // ── Purpose ──────────────────────────────────────────────────────────

        if (entry.DeclaredPurposeId != null)
            sb.AppendLine($"Declared Pur: {_lookup.PurposeName(entry.DeclaredPurposeId)}");

        bool purposeMismatch = entry.ActualPurposeId != null
                               && entry.ActualPurposeId != entry.DeclaredPurposeId;
        if (purposeMismatch)
            sb.AppendLine($"Actual Pur:   {_lookup.PurposeName(entry.ActualPurposeId)} [differs]");
        else if (entry.ActualPurposeId != null && entry.DeclaredPurposeId == null)
            sb.AppendLine($"Actual Pur:   {_lookup.PurposeName(entry.ActualPurposeId)}");

        // ── Statuses ─────────────────────────────────────────────────────────

        if (entry.ManifestStatusId != null)
            sb.AppendLine($"Manifest:     {_lookup.ManifestStatusName(entry.ManifestStatusId)}");
        if (entry.InspectionStatusId != null)
            sb.AppendLine($"Inspection:   {_lookup.InspectionStatusName(entry.InspectionStatusId)}");
        if (entry.ClearanceStatusId != null)
            sb.AppendLine($"Clearance:    {_lookup.ClearanceStatusName(entry.ClearanceStatusId)}");
        if (entry.EnvironmentalConditionId != null)
            sb.AppendLine($"Environment:  {_lookup.EnvironmentalConditionName(entry.EnvironmentalConditionId)}");

        // ── Narrative ────────────────────────────────────────────────────────

        if (entry.DirectiveId != null)
            sb.AppendLine($"Directive:    {_lookup.DirectiveName(entry.DirectiveId)}");
        if (entry.IncidentPhraseTemplateId != null)
            sb.AppendLine($"Incident:     {_lookup.PhraseTemplateName(entry.IncidentPhraseTemplateId)}");
        if (entry.ResolutionPhraseTemplateId != null)
            sb.AppendLine($"Resolution:   {_lookup.PhraseTemplateName(entry.ResolutionPhraseTemplateId)}");
        if (entry.RouteStatusPhraseTemplateId != null)
            sb.AppendLine($"Route Status: {_lookup.PhraseTemplateName(entry.RouteStatusPhraseTemplateId)}");

        // ── Story thread ─────────────────────────────────────────────────────

        if (entry.StoryThreadId != null)
            sb.AppendLine($"Thread:       {_lookup.StoryThreadName(entry.StoryThreadId)}");
        if (entry.AppliedStoryBeatId != null)
            sb.AppendLine($"Beat:         {_lookup.StoryBeatLabel(entry.AppliedStoryBeatId)}");
        if (entry.AnomalySeverity.HasValue)
            sb.AppendLine($"Anomaly:      {entry.AnomalySeverity}");

        // ── Cargo / Passengers ───────────────────────────────────────────────

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

        // ── Hidden truth indicator ───────────────────────────────────────────

        if (!string.IsNullOrWhiteSpace(entry.HiddenTruthNotes))
            sb.AppendLine("Hidden Truth: [notes present]");

        // ── Schedule ─────────────────────────────────────────────────────────

        if (entry.ScheduledUtc.HasValue)
            sb.AppendLine($"Scheduled:    {entry.ScheduledUtc.Value:yyyy-MM-dd HH:mm} UTC");

        // ── Notes ────────────────────────────────────────────────────────────

        if (!string.IsNullOrEmpty(entry.Notes))
            sb.AppendLine($"Notes:        {entry.Notes}");

        txtEpisodeEntryPreview.Text = sb.ToString().TrimEnd();
    }
}