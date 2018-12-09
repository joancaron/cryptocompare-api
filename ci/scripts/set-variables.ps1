Get-ChildItem Env:

$manifest = Get-Content .\package.json | Out-String | ConvertFrom-Json

$isPackable = $false
$version = $manifest.version

if ($(Build.SourceBranch).StartsWith("refs/tags/v")
    ) { 
    $isPackable = $true
}else{
    $version += '+' + $Env:BUILD_SOURCEVERSION.Substring(0, 6)
}

Write-Host "##vso[task.setvariable variable=isTriggeredByTag]$isTriggeredByTag"
Write-Host "##vso[build.updatebuildnumber]$version"
