param($installPath, $toolsPath, $package, $project)
	
	. (Join-Path $toolsPath "cleanProject.ps1")

# Create a relative path to the targets file.
$targetsFileRelativePath = 'OpenAccessNuget.targets'

#Add the proper EnhancerAssembly project setting
$enhancerFile = [System.IO.Path]::Combine($toolsPath, 'enhancer\enhancer.exe')
$enhancerUri = new-object Uri($enhancerFile)
$installUri = new-object Uri($installPath)
$enhancerRelativePath = $installUri.MakeRelativeUri($enhancerUri).ToString().Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
$msbuild.Xml.AddProperty('EnhancerAssembly','$(SolutionDir)packages\' + $enhancerRelativePath) | out-null

# Include the new OpenAccess targets

$openAccessTargetsImport = $msbuild.Xml.CreateImportElement($targetsFileRelativePath);
$msTargetsImport = $null
if($project.Type -eq "C#")
{
	$msTargetsImport = $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith("Microsoft.CSharp.targets") }
}
elseif($project.Type -eq "VB.NET")
{
	$msTargetsImport = $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith("Microsoft.VisualBasic.targets") }
}

if($msTargetsImport -ne $null)
{
	$msbuild.Xml.InsertAfterChild($openAccessTargetsImport, $msTargetsImport)
}
else
{
	$msbuild.Xml.AddImport($openAccessTargetsImport) 
}

# Save the project
$project.Save()