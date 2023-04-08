browser
winget install --id Google.Chrome
winget install --id SublimeHQ.SublimeText.4

git
winget install --id Axosoft.GitKraken

ide
winget install --id Microsoft.VisualStudio.2022.Community.Preview
winget install --id Microsoft.VisualStudioCode

sdk
winget install --id Microsoft.DotNet.SDK.7
winget install --id Microsoft.DotNet.SDK.Preview

wsl
DISM /Online /Enable-Feature /All /FeatureName:Microsoft-Hyper-V
wsl --install -d Ubuntu-22.04

containers
winget install --id RedHat.Podman
https://github.com/containers/podman/blob/main/docs/tutorials/podman-for-windows.md

docker/podman run --name=mssql-server -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=pa55Paro!a" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest



database
winget install --id Microsoft.SQLServer.2019.Express
winget install --id Microsoft.SQLServerManagementStudio