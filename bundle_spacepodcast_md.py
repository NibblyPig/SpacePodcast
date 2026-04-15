#!/usr/bin/env python3
"""
Bundle SpacePodcast markdown for AI handoff.

What it does
------------
- Keeps key control files separate:
  * Podcast_Style_Guide*.md
  * Episode_Template*.md
  * Claude_Prompt*.md / Claude_Bootstrap_Prompt*.md
  * station_opening_adjectives*.md
  * script*.md
  * refs*.md
- Excludes obviously legacy / non-worldbuilding files by default:
  * podcast_universe_editor_*.md
  * project_codebase.md
- Groups the remaining markdown into logical bundle files:
  1) station_core_bundle.md
  2) appendix_bundle.md
  3) locations_bundle.md
  4) rings_bundle.md
  5) misc_bundle.md (only if needed)

Recommended usage
-----------------
    python bundle_spacepodcast_md.py "C:\Development\SpacePodcast"

Outputs
-------
Creates:
    <root>\_handoff\
with:
    00_manifest.md
    copied key files
    bundle files
    99_summary.md
"""

from __future__ import annotations

import argparse
import fnmatch
import re
from pathlib import Path

KEEP_PATTERNS = [
    "Podcast_Style_Guide*.md",
    "Episode_Template*.md",
    "Claude_Prompt*.md",
    "Claude_Bootstrap_Prompt*.md",
    "station_opening_adjectives*.md",
    "script*.md",
    "refs*.md",
]

EXCLUDE_PATTERNS = [
    "podcast_universe_editor_*.md",
    "project_codebase.md",
]

EXCLUDE_DIRS = {
    ".git", ".obsidian", ".trash", "__pycache__", ".venv", "venv", "_handoff"
}


def rel(path: Path, root: Path) -> str:
    return path.relative_to(root).as_posix()


def match_any(path: Path, patterns: list[str], root: Path) -> bool:
    name = path.name
    rel_name = rel(path, root)
    return any(fnmatch.fnmatch(name, p) or fnmatch.fnmatch(rel_name, p) for p in patterns)


def natural_key(path: Path):
    s = path.as_posix().lower()
    return [int(t) if t.isdigit() else t for t in re.split(r"(\d+)", s)]


def collect_md_files(root: Path) -> list[Path]:
    files = []
    for p in root.rglob("*.md"):
        if not p.is_file():
            continue
        rel_parts = p.relative_to(root).parts
        if any(part.lower() in EXCLUDE_DIRS for part in rel_parts):
            continue
        files.append(p)
    return sorted(files, key=natural_key)


def read_text(path: Path) -> str:
    try:
        return path.read_text(encoding="utf-8")
    except UnicodeDecodeError:
        return path.read_text(encoding="utf-8", errors="replace")


def format_section(title: str, body: str) -> str:
    return f"{title}\n{'=' * len(title)}\n\n```markdown\n{body.rstrip()}\n```\n\n"


def categorize(path: Path, root: Path) -> str:
    r = rel(path, root)

    # Top-level station docs under Obsidian root
    if r.startswith("Obsidian/"):
        parts = r.split("/")
        if len(parts) == 2:
            return "station_core"

    if r.startswith("Obsidian/Appendix/"):
        return "appendix"

    if r.startswith("Obsidian/Locations/"):
        return "locations"

    if r.startswith("Obsidian/Rings/"):
        return "rings"

    return "misc"


def main() -> int:
    ap = argparse.ArgumentParser()
    ap.add_argument("root", type=Path, help="SpacePodcast root, e.g. C:\\Development\\SpacePodcast")
    ap.add_argument("--out-dir", type=Path, default=None, help="Output dir (default: <root>\\_handoff)")
    ap.add_argument("--keep", action="append", default=[], help="Extra keep patterns")
    ap.add_argument("--exclude", action="append", default=[], help="Extra exclude patterns")
    args = ap.parse_args()

    root = args.root.resolve()
    out_dir = (args.out_dir or (root / "_handoff")).resolve()
    out_dir.mkdir(parents=True, exist_ok=True)

    keep_patterns = KEEP_PATTERNS + args.keep
    exclude_patterns = EXCLUDE_PATTERNS + args.exclude

    all_files = collect_md_files(root)

    kept = []
    bundled = []

    for p in all_files:
        if match_any(p, exclude_patterns, root):
            continue
        if match_any(p, keep_patterns, root):
            kept.append(p)
        else:
            bundled.append(p)

    categories = {
        "station_core": [],
        "appendix": [],
        "locations": [],
        "rings": [],
        "misc": [],
    }

    for p in bundled:
        categories[categorize(p, root)].append(p)

    # Write manifest
    manifest_lines = []
    manifest_lines.append("AI HANDOFF MANIFEST\n")
    manifest_lines.append("===================\n\n")

    manifest_lines.append("Kept separate:\n")
    for p in kept:
        manifest_lines.append(f"- {rel(p, root)}\n")
    if not kept:
        manifest_lines.append("(none)\n")

    manifest_lines.append("\nBundled:\n")
    for cat, paths in categories.items():
        if not paths:
            continue
        manifest_lines.append(f"\n{cat}:\n")
        for p in paths:
            manifest_lines.append(f"- {rel(p, root)}\n")

    manifest_path = out_dir / "00_manifest.md"
    manifest_path.write_text("".join(manifest_lines), encoding="utf-8")

    # Copy kept files
    copied = []
    for p in kept:
        dest = out_dir / p.name
        if dest.exists() and dest.resolve() != p.resolve():
            safe = rel(p, root).replace("/", "__")
            dest = out_dir / safe
        dest.write_text(read_text(p), encoding="utf-8")
        copied.append(dest)

    # Write grouped bundles
    bundle_map = {
        "station_core": "10_station_core_bundle.md",
        "appendix": "20_appendix_bundle.md",
        "locations": "30_locations_bundle.md",
        "rings": "40_rings_bundle.md",
        "misc": "50_misc_bundle.md",
    }

    written_bundles = []
    for cat, out_name in bundle_map.items():
        paths = categories[cat]
        if not paths:
            continue

        sections = []
        header = f"{cat.upper()} BUNDLE\n{'=' * (len(cat) + 7)}\n\nIncluded files:\n"
        for p in paths:
            header += f"- {rel(p, root)}\n"
        header += "\n"
        sections.append(header)

        for p in paths:
            sections.append(format_section(rel(p, root), read_text(p)))

        out_path = out_dir / out_name
        out_path.write_text("".join(sections), encoding="utf-8")
        written_bundles.append(out_path)

    # Summary
    summary_lines = []
    summary_lines.append("HANDOFF OUTPUT\n")
    summary_lines.append("==============\n\n")
    summary_lines.append(f"Manifest: {manifest_path.name}\n\n")
    summary_lines.append("Separate files:\n")
    for p in copied:
        summary_lines.append(f"- {p.name}\n")
    if not copied:
        summary_lines.append("(none)\n")
    summary_lines.append("\nBundle files:\n")
    for p in written_bundles:
        summary_lines.append(f"- {p.name}\n")
    if not written_bundles:
        summary_lines.append("(none)\n")

    summary_path = out_dir / "99_summary.md"
    summary_path.write_text("".join(summary_lines), encoding="utf-8")

    print(f"Created handoff package in: {out_dir}")
    print(f"Manifest: {manifest_path.name}")
    print("Separate files:")
    for p in copied:
        print(f"  - {p.name}")
    print("Bundle files:")
    for p in written_bundles:
        print(f"  - {p.name}")
    print(f"Summary: {summary_path.name}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
