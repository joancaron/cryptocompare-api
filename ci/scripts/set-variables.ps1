Get-ChildItem Env:

$manifest = Get-Content .\package.json | Out-String | ConvertFrom-Json

$isTriggeredByTag = $false
$version = $manifest.version

if ($Env:BUILD_SOURCEBRANCH.StartsWith("refs/tags/v")) { 
    $isTriggeredByTag = $true
}else{
    $version += '+' + $Env:BUILD_SOURCEVERSION.Substring(0, 6)
}

Write-Host "##vso[task.setvariable variable=isTriggeredByTag]$isTriggeredByTag"
Write-Host "##vso[build.updatebuildnumber]$version"
