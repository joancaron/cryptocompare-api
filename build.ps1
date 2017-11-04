<#
.SYNOPSIS
  This is a helper function that runs a scriptblock and checks the PS variable $lastexitcode
  to see if an error occcured. If an error is detected then an exception is thrown.
  This function allows you to run command-line programs without having to
  explicitly check the $lastexitcode variable.
.EXAMPLE
  exec { svn info $repository_trunk } "Error executing SVN. Please verify SVN command-line client is installed"
#>
function Exec
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
        [Parameter(Position=1,Mandatory=0)][string]$errorMessage = ($msgs.error_bad_command -f $cmd)
    )
    & $cmd
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

if(Test-Path .\src\*\artifacts) { Remove-Item .\src\*\artifacts -Force -Recurse }

exec { & dotnet restore }

$tag = $(git tag -l --points-at HEAD)
$revision = @{ $true = "{0:00000}" -f [convert]::ToInt32("0" + $env:APPVEYOR_BUILD_NUMBER, 10); $false = "local" }[$env:APPVEYOR_BUILD_NUMBER -ne $NULL];
$suffix = @{ $true = ""; $false = "ci-$revision"}[$tag -ne $NULL -and $revision -ne "local"]
$commitHash = $(git rev-parse --short HEAD)
$buildSuffix = @{ $true = "$($suffix)-$($commitHash)"; $false = "$($branch)-$($commitHash)" }[$suffix -ne ""]

exec { & dotnet build CryptoCompare.sln -c Release --version-suffix=$buildSuffix -v q /nologo }

#skip integration tests
$unitTestFolders = Get-ChildItem .\test\CryptoCompare.*.Tests

foreach ($unitTestFolder in $unitTestFolders) {
    Push-Location -Path $unitTestFolder
    
    $testName = Split-Path $unitTestFolder -leaf

    exec { & dotnet xunit -configuration Release }

    Pop-Location
}

exec { & dotnet pack .\src\CryptoCompare\CryptoCompare.csproj -c Release -o .\artifacts --include-symbols --no-build --version-suffix=$suffix }
exec { & dotnet pack .\src\CryptoCompare.WebSocket\CryptoCompare.WebSocket.csproj -c Release -o .\artifacts --include-symbols --no-build --version-suffix=$suffix }
