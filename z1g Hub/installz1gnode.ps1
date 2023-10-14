$installDir = "$env:USERPROFILE\NodeJS"

if (-Not (Test-Path -Path $installDir)) {
    New-Item -Path $installDir -ItemType Directory
}

$nodeVersion = "18.17.1"
$downloadUrl = "https://nodejs.org/dist/v$nodeVersion/node-v$nodeVersion-win-x64.zip"
$zipPath = "$installDir\node.zip"
Invoke-WebRequest -Uri $downloadUrl -OutFile $zipPath
Expand-Archive -Path $zipPath -DestinationPath $installDir -Force
$env:Path = "$installDir;$env:Path"
Remove-Item -Path $zipPath

node -v
npm -v
