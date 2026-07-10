cls

$path = "c:\gitTmpkimba"
$pathConfigFile = "$path\CloneAllRepos.config"
$configFile = "PowerShellScripts\CloneAllRepos.config"

If (!(test-path -PathType container $path))
{
	      New-Item -ItemType Directory -Path $path
          copy $configFile $path
}

If (!(test-path -Path $pathConfigFile))
{
          copy $configFile $path
}