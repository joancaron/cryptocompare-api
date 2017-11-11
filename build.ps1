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

Write-Host "BEGIN dotnet build"

exec { & dotnet build CryptoCompare.sln -c Release -v q /nologo }

Write-Host "END dotnet build"

#skip integration tests
$unitTestFolders = Get-ChildItem .\test\*.Tests

foreach ($unitTestFolder in $unitTestFolders) {

    Write-Host "BEGIN tests on" $unitTestFolder
    Push-Location -Path $unitTestFolder
    
    $testName = Split-Path $unitTestFolder -leaf

    exec { & dotnet xunit -configuration Release }

    Write-Host "END tests on" $unitTestFolder
   
    Pop-Location
}

Write-Host "BEGIN dotnet pack"

exec { & dotnet pack .\src\CryptoCompare\CryptoCompare.csproj -c Release -o .\artifacts --include-symbols --no-build }

Write-Host "END dotnet pack"