# Parameters
param (
    [string]$SolutionDir = ".\",
    [string]$ExtraResources,
    [string]$OutDir,
    [string]$Config = "Release"
)

# Resources
class Resource {
    [string]$Source
    [string]$DestName
}

$resources = @(
    [Resource]@{
        Source = "$($SolutionDir)crashtest\target\release\crashtest.dll"
    },
    [Resource]@{
        Source = "$($SolutionDir)sentry-native\bin\sentry.dll"
        DestName = "sentryffi.dll"
    },
    [Resource]@{
        Source = "$($SolutionDir)sentry-native\bin\crashpad_handler.exe"
    }
)

if ($ExtraResources.Length -ne 0) {
    $resources +=
    [Resource]@{
        Source = $ExtraResources
    }
}

foreach ($r in $resources) {
    # DestName optional, for renaming of file. Will cause issues if used with folders
    if ($r.DestName) {
        $dest_path = Join-Path -Path $($OutDir) -ChildPath $($r.DestName)
        $echo_path = $dest_path
    }
    else {
        $dest_path = $OutDir
        $echo_path = Join-Path -Path $OutDir -ChildPath $(Split-Path $r.Source -Leaf)
    }
    Write-Output "Copying $($r.Source) => $($echo_path)"
    try {
        Copy-Item "$($r.Source)" -Destination "$($dest_path)" -Recurse -Force -errorAction stop
    }
    catch {
        throw $_
    }
}
