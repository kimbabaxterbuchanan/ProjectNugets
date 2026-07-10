cls
$path = "c:\gitTmpMain"
$pathConfigFile = "$path\CloneAllRepos.config"
$configFile = "PowerShellScripts\CloneAllRepos.config"

If(!(test-path -PathType container $path))
{
	      New-Item -ItemType Directory -Path $path
          copy $configFile $path
}
If(!(test-path -Path $pathConfigFile))
{
          copy $configFile $path
}
cd $path


Get-Content "CloneAllRepos.config" | foreach-object -begin {$h=@{}} -process { 
    $k = [regex]::split($_,'='); 
    if(($k[0].CompareTo("") -ne 0) -and ($k[0].StartsWith("[") -ne $True)) { 
        $h.Add($k[0], $k[1]) 
    } 
}
$url = $h.Get_Item("Url")
$username = $h.Get_Item("Username")
$password = $h.Get_Item("Password")

# Retrieve list of all repositories
$base64AuthInfo = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(("{0}:{1}" -f $username,$password)))
$headers = @{
    "Authorization" = ("Basic {0}" -f $base64AuthInfo)
    "Accept" = "application/json"
}

Add-Type -AssemblyName System.Web
$gitcred = ("{0}:{1}" -f  [System.Web.HttpUtility]::UrlEncode($username),$password)

$resp = Invoke-WebRequest -Headers $headers -Uri ("{0}/_apis/git/repositories?api-version=1.0" -f $url)
$json = convertFrom-JSON $resp.Content

# Clone or pull all repositories
$initpath = get-location


foreach ($entry in $json.value) { 
    $name = $entry.name 

    $url = $entry.remoteUrl
    Write-Progress -Activity  $name  $url
    if((Test-Path -Path $name)) {
        rmdir -Force -Recurse $name
    }
                
    git clone --quiet $url
    
    cd $name


    git fetch --all

    $branches = git branch -r

    foreach($branch in $branches){
        $branch = $branch.ToLower()
        
        $branchName = $branch.Replace('origin/','')
        $branchName = $branchName.Replace(' ','')

        git fetch origin 

#        git uncheckout $branchName

    }
    cd $path

}
