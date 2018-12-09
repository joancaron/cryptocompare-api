Get-ChildItem Env:

$manifest = Get-Content .\package.json | Out-String | ConvertFrom-Json

$isTriggeredByTag = $false
$version = $manifest.version

if ($Env:BUILD_SOURCEBRANCH.StartsWith("refs/tags/v")) { 
    $isTriggeredByTag = $true
    
}else{
    $commitId = & git rev-parse --short HEAD
    $version = $manifest.version + '+' + $commitId
}

Write-Host "##vso[task.setvariable variable=isTriggeredByTag]$isTriggeredByTag"
Write-Host "##vso[build.updatebuildnumber]$version"

