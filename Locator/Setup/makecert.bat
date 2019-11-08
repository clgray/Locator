"makecert.exe" -n CN=localhost -ss My -pe -sky exchange -sr LocalMachine
"winhttpcertcfg.exe" -g -c Local_Machine\My -s localhost -a NetworkService
pause