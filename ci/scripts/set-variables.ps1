Get-ChildItem Env:

$manifest = Get-Content .\package.json | Out-String | ConvertFrom-Json

$canBePacked = '$(Build.SourceBranch)'.StartsWith("refs/tags/v") -and $(Build.Reason) -ne 'PullRequest' -and $(System.PullRequest.IsFork) -ne $true

if ($canBePacked) { 
    $version = $manifest.version
}else{
    #$version = $manifest.version + '+' + $Env:BUILD_SOURCEVERSION.Substring(0, 6)
    $version = $manifest.version
}

Write-Host "##vso[task.setvariable variable=canBePacked]$canBePacked"
Write-Host "##vso[build.updatebuildnumber]$version"
