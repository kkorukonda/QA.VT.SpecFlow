#will upate app settings value provided from external source

#example of how to call this script,-> cd into the same directory of this file, make sure appsettings.json is in the same directory
# run the following command : .\SettingUpdaterScript.ps1 -browser "chrome" -env "dev"


Param (
    [string]$browser = $(throw "browser param is required"),
    [string]$env = $(throw "env param is required")
)
 #Path to your appsettings.json file
$jsonFilePath = "appsettings.json"

# Read the content of the JSON file
$jsonContent = Get-Content -Path $jsonFilePath | ConvertFrom-Json

# Update the values with command-line arguments
$jsonContent.Browser = $browser
$jsonContent.Environment = $env

# Save the changes back to the appsettings.json file
$jsonContent | ConvertTo-Json | Set-Content -Path $jsonFilePath