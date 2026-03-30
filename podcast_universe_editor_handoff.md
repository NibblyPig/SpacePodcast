# PodcastUniverseEditor handoff

## What this project is
WinForms desktop editor for a podcast-universe authoring tool.

The project has been undergoing a refactor from a giant programmatic `MainForm` into extracted `UserControl`s.

The current focus is **UI extraction and stabilisation**, especially the **Episodes** area.

---

## Current architectural direction

### General rule now
- `MainForm` still owns behaviour and event wiring.
- Extracted `UserControl`s are mainly presentation shells that expose controls/properties to `MainForm`.
- For problematic controls, the goal is now:
  - layout in `.Designer.cs`
  - minimal `.cs` code-behind
  - no constructor-built monster layouts if avoidable
  - designer-safe structure

### Important preference
For WinForms layout work:
- prefer proper `.Designer.cs` layout over runtime `BuildLayout()` methods
- avoid post-`InitializeComponent()` code that re-docks/re-sizes everything unless absolutely necessary
- use descriptive private names, not vague names like `entryRow1`, `panel1`, etc.

---

## What has already been done

### Extracted / created user controls
There are now multiple extracted controls under `UI/Controls`, including Episodes-related controls under `UI/Controls/Episodes/`.

The Episodes area was broken apart into:
- `ucEpisodes`
- `ucEpisodeMetaEditor`
- `ucEpisodeEntryDetail`

### `ucEpisodeMetaEditor`
This was cleaned up successfully.
Current desired state:
- layout lives in `ucEpisodeMetaEditor.Designer.cs`
- `.cs` contains constructor + public property forwarding only
- control is opening correctly in designer
- visually looked good after cleanup

### `ucEpisodes`
This has been partially stabilised and manually improved.
High-level layout intent:
- left side: series + episodes + episode summary + metadata editor
- right side: entry list/grid + filters + buttons/tools + selected entry detail

The right side currently has three tool/button rows under the entry grid:
- entry list actions
- generation tools
- export tools

Decision at last review:
- leave those rows as-is for now
- do not optimise further until actual usage reveals annoyances

---

## Immediate current issue

### `ucEpisodeEntryDetail` label text bug
The new designer-based version visually opened in the designer, but the labels appeared blank.

Symptom:
- rows and controls are visible
- labels exist but their `Text` values are blank in the designer view

Likely cause:
- the helper methods (`ConfigureFieldLabel`, `ConfigureSectionLabel`) were setting layout properties but not reliably setting `.Text` on the actual designer-created labels in the final generated file, or the generated designer content ended up missing the explicit assignments.

### What needs to happen next
Fix `ucEpisodeEntryDetail.Designer.cs` so every label has an explicit `Text` assigned.
Examples:
- `lblEntryKind.Text = "Kind:";`
- `lblEntrySourceType.Text = "Source Type:";`
- `lblEntrySection.Text = "Entry";`
- etc.

Do **not** reintroduce a constructor `BuildLayout()` pattern.
Keep it designer-led like `ucEpisodeMetaEditor`.

---

## Important files / state to know

### Episodes-related files
- `UI/Controls/Episodes/ucEpisodes.cs`
- `UI/Controls/Episodes/ucEpisodes.Designer.cs`
- `UI/Controls/Episodes/ucEpisodeMetaEditor.cs`
- `UI/Controls/Episodes/ucEpisodeMetaEditor.Designer.cs`
- `UI/Controls/Episodes/ucEpisodeEntryDetail.cs`
- `UI/Controls/Episodes/ucEpisodeEntryDetail.Designer.cs`

### Current intended responsibilities
#### `ucEpisodes`
Top-level shell only.
Contains:
- series list
- episode list
- episode summary
- metadata editor host / embedded metadata control
- entry filters
- entry grid
- entry tool rows
- selected-entry detail area

#### `ucEpisodeMetaEditor`
Episode/series metadata editor only.
This one is already in a good shape.

#### `ucEpisodeEntryDetail`
Selected-entry detail editor only.
This is the big, dense control currently being cleaned up.

---

## UI intent for `ucEpisodes`

### Left side
- top: series list + series buttons
- below: episode list + search
- episode summary box
- episode action buttons
- episode metadata editor

### Right side
- top: entry filters
- entry grid
- entry action/generation/export rows
- bottom: selected entry detail editor
- thread summary box
- rendered preview box

### Decision made about top-right tools area
There was discussion about tabs/grouping.
Final decision **for now**:
- leave the current three rows visible
- defer regrouping until actual usage makes the pain clearer

So do **not** do extra UX redesign there yet.

---

## Naming preference going forward
Refactors should improve vague private names.
Examples of good naming:
- `pnlEntryListSection`
- `pnlEntryFilters`
- `pnlEntryGenerationTools`
- `pnlEntryExportTools`
- `pnlSelectedEntrySection`
- `tblMetadataLayout`
- `pnlEpisodeDate`

Avoid vague names like:
- `panel1`
- `panel2`
- `entryRow1`
- `entryRow2`
- `entryRow3`

Public property names that `MainForm` depends on should generally be preserved.

---

## Behaviour constraints
When continuing:
- preserve `MainForm` behaviour and event wiring
- do not redesign workflows unless explicitly asked
- prefer layout-only / naming-only cleanup unless there is a real bug
- keep `.Designer.cs` as source of truth for layout where possible

---

## Recommended next task in the new conversation
1. Fix the blank label text issue in `ucEpisodeEntryDetail.Designer.cs`
2. Verify the control opens correctly in the WinForms designer
3. Verify the app still runs
4. Then continue section-by-section visual cleanup of `ucEpisodeEntryDetail` only if needed