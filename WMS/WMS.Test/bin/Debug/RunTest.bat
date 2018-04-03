echo "Run using Chrome"
set _browser=chrome
vstest.console.exe wms.Test.dll


echo "Run using IE"
set _browser=InternetExplorer
mvstest.console.exe wms.Test.dll