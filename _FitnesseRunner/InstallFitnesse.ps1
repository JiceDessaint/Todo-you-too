[Reflection.Assembly]::LoadWithPartialName('System.IO.Compression.FileSystem') | Out-Null


$fitnessePath = "."
$fitsharpPath = ".\fitsharp"
$urlDownloadFitnesse = "http://www.fitnesse.org/fitnesse-standalone.jar?responder=releaseDownload&release=20121220"
$urlDownloadFitsharp = "https://github.com/downloads/jediwhale/fitsharp/release.2.2.net.40.zip"

$rootpath = "T:\Path1\Path2\*"

if (Test-Path (".\fitnesse-standalone.jar"))
{
	echo "Fitnesse is in place"
}
else
{
	echo "Fitnesse not present. Downloading...."
	$client = new-object System.Net.WebClient
	$client.DownloadFile( $urlDownloadFitnesse, ".\fitnesse-standalone.jar")
}

if (Test-Path (".\fitsharp\Runner.exe"))
{
	echo "Fitsharp is in place"
}
else
{
	echo "Fitsharp not present. Downloading...."
	$client = new-object System.Net.WebClient
	$client.DownloadFile( $urlDownloadFitsharp, ".\fitsharp.zip")

	$zipIn = Get-Item(“.\fitsharp.zip”)
	New-Item .\fitsharp -type directory -force
	$zipOut = Get-Item(".\fitsharp")
	[System.IO.Compression.ZipFile]::ExtractToDirectory($zipIn, $zipOut)
}
