mkdir tools
mkdir reports\coverage\history

nuget install OpenCover -ExcludeVersion -OutputDirectory  tools
nuget install xunit.runner.console -ExcludeVersion -OutputDirectory tools
if "%APPVEYOR%"=="True" nuget install coveralls.io -ExcludeVersion -OutputDirectory tools
if "%APPVEYOR%"=="" nuget install ReportGenerator -ExcludeVersion -OutputDirectory tools

if "%APPVEYOR%"=="" dotnet build

set APPVEYOR_API_URL=

set TestResult=0

tools\OpenCover\tools\OpenCover.Console.exe -target:"tools\xunit.runner.console\tools\xunit.console.x86.exe" -targetargs:"Planner.Tests\bin\Debug\net462\Planner.Tests.exe -noShadow -xml test-results.xml" -register:user -output:"reports\coverage\coverage.xml" -skipautoprops -filter:"+[Planner*]* -[Planner*]Planner.Migrations* -[Planner.Test*]*"  -excludebyattribute:*.ExcludeFromCodeCoverage* -mergebyhash -returntargetcode

IF %ERRORLEVEL% NEQ 0 (
  set TestResult=%ERRORLEVEL%
)

if "%APPVEYOR%"=="True" tools\coveralls.io\tools\coveralls.net.exe --opencover reports\coverage\coverage.xml

if "%APPVEYOR%"=="" tools\ReportGenerator\tools\ReportGenerator.exe -reports:reports\coverage\coverage.xml -targetdir:reports\coverage -historydir:reports\coverage\history

cd Planner

node_modules\.bin\karma.cmd start --single-run

cd ..

if "%APPVEYOR%"=="True" powershell .\upload-results.ps1

exit /B %TestResult%