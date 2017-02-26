New-Item -ItemType directory -Path .\tools -ErrorAction Ignore
New-Item -ItemType directory -Path .\reports\coverage\history -ErrorAction Ignore

&.\nuget install OpenCover -ExcludeVersion -OutputDirectory  tools
&.\nuget install xunit.runner.console -ExcludeVersion -OutputDirectory tools

if ($Env:APPVEYOR -eq "True" ) {
	&.\nuget install coveralls.io -ExcludeVersion -OutputDirectory tools
}
else {
	&.\nuget install ReportGenerator -ExcludeVersion -OutputDirectory tools
	dotnet build
}

$env:APPVEYOR_API_URL = $null

$TestResult=0

$p = Start-Process -FilePath "tools\OpenCover\tools\OpenCover.Console.exe" -ArgumentList "-target:`"tools\xunit.runner.console\tools\xunit.console.x86.exe`" -targetargs:`"Planner.Tests\bin\Debug\net462\Planner.Tests.exe -noShadow -xml test-results.xml`" -register:user -output:`"reports\coverage\coverage.xml`" -skipautoprops -filter:`"+[Planner*]* -[Planner*]Planner.Migrations* -[Planner.Test*]*`" -excludebyattribute:*.ExcludeFromCodeCoverage* -mergebyhash -returntargetcode" -Wait -NoNewWindow -PassThru
Write-Host $p.ExitCode

if ($p.ExitCode -ne 0) {
	$TestResult=$p.ExitCode
}

if ($Env:APPVEYOR -eq "True" ) {
	.\tools\coveralls.io\tools\coveralls.net.exe --opencover reports\coverage\coverage.xml
}
else {
	.\tools\ReportGenerator\tools\ReportGenerator.exe -reports:reports\coverage\coverage.xml -targetdir:reports\coverage -historydir:reports\coverage\history
}

exit $TestResult