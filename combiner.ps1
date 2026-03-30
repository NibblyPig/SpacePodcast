# Usage examples:
# .\script.ps1 Models Services Controllers
# .\script.ps1 Domain Infrastructure
# .\script.ps1 (← processes whole current folder as before)
param(
    [Parameter(Mandatory = $false, Position = 0, ValueFromRemainingArguments = $true)]
    [string[]]$Folders
)
# If no folders specified → use current directory (old behaviour)
if ($Folders.Count -eq 0) {
    $Folders = @(".")
}
# Collect unique using statements only from the requested folders
$usings = foreach ($folder in $Folders) {
    Get-ChildItem -Path $folder -Recurse -File -Filter *.cs -ErrorAction SilentlyContinue |
        Select-String -Pattern '^using\s' |
        ForEach-Object { $_.Line.Trim() }
}
$usings = $usings | Sort-Object -Unique
# ────────────────────────────────────────────────
# Start output file
# ────────────────────────────────────────────────
$outfile = "project_codebase.md"
"# Project Codebase Summarynn## Global Using Directivesn" | Out-File -FilePath $outfile -Encoding utf8 if ($usings.Count -gt 0) { &nbsp;&nbsp;&nbsp;&nbsp;$usings | ForEach-Object { "- $_n" } | Out-File -FilePath $outfile -Append -Encoding utf8
} else {
    "None found`n" | Out-File -FilePath $outfile -Append -Encoding utf8
}
# Separator + explanation
"n## Code Filesnn" + "Below is the concatenated code from .cs files in the following folders only:n" +
($Folders -join ", ") + "nn" +
"Designer-generated files are excluded. File-local usings are removed.nn" |
    Out-File -FilePath $outfile -Append -Encoding utf8
# ────────────────────────────────────────────────
# Process files from the requested folders only
# ────────────────────────────────────────────────
$totalFiles = 0
foreach ($folder in $Folders) {
    $files = Get-ChildItem -Path $folder -Recurse -File -Filter *.cs -ErrorAction SilentlyContinue |
        Where-Object { $  _.Name -notmatch '\.Designer\.cs  $' }
    foreach ($file in $files) {
        $totalFiles++
        # Relative path (makes output nicer)
        $relPath = Resolve-Path -Relative -Path $file.FullName
        # Remove leading .\ if present
        $relPath = $relPath.TrimStart('.')
        "n### File: $relPathn```csharp
# Content without using lines
Get-Content $file.FullName |
Where-Object { $_ -notmatch '^using\s' } |
Out-File -FilePath $outfile -Append -Encoding utf8
"n``````n---n" | Out-File -FilePath $outfile -Append -Encoding utf8
}
}
# ────────────────────────────────────────────────
# Footer with stats
# ────────────────────────────────────────────────
"n## Project Statsn" +
"- Folders requested: $($Folders -join ', ')n" + "- Total .cs files processed: $totalFilesn" +
"- Excluded: *.Designer.cs filesn" + "- Date generated: $(Get-Date -Format "yyyy-MM-dd HH:mm")n" |
Out-File -FilePath $outfile -Append -Encoding utf8
Write-Host "Done. Output written to $outfile"