echo "Running using Firefox"
set _browser=firefox
vstest.console.exe wms.specs.dll
echo "---------------------------------------------------------------------------"
echo "Running using Internet Explorer"
set _browser=InternetExplorer
vstest.console.exe wms.specs.dll
echo "---------------------------------------------------------------------------"
echo "Running using chrome"
set _browser=chrome
vstest.console.exe wms.specs.dll