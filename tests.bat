mkdir tools
mkdir reports\coverage\history

nuget install OpenCover -ExcludeVersion -OutputDirectory  tools
nuget install xunit.runner.console -ExcludeVersion -OutputDirectory tools
if "%APPVEYOR%"=="True" nuget install coveralls.io -ExcludeVersion -OutputDirectory tools
if "%APPVEYOR%"=="" nuget install ReportGenerator -ExcludeVersion -OutputDirectory tools

if "%APPVEYOR%"=="" dotnet build

tools\OpenCover\tools\OpenCover.Console.exe -target:"tools\xunit.runner.console\tools\xunit.console.x86.exe" -targetargs:"Planner.Tests\bin\Debug\net452\Planner.Tests.exe -noShadow -appveyor" -register:user -output:"reports\coverage\coverage.xml" -skipautoprops -filter:"+[Planner*]* -[Planner*]Planner.Data.Migrations* -[Planner.Test*]*"  -excludebyattribute:*.ExcludeFromCodeCoverage* -mergebyhash

if "%APPVEYOR%"=="True" tools\coveralls.io\tools\coveralls.net.exe --opencover reports\coverage\coverage.xml

if "%APPVEYOR%"=="" tools\ReportGenerator\tools\ReportGenerator.exe -reports:reports\coverage\coverage.xml -targetdir:reports\coverage -historydir:reports\coverage\history