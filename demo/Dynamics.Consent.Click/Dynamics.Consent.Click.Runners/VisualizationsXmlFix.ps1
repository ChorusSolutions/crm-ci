$Visualizations = Get-ChildItem "..\**\**\Entities\**\Visualizations\*.xml" -Recurse
$Visualizations  | ForEach-Object -Process   { $_.FullName }
$Visualizations  | ForEach-Object -Process   {(Get-Content $_.FullName) -replace '<savedqueries>', ''| Set-Content $_.FullName}
$Visualizations  | ForEach-Object -Process   {(Get-Content $_.FullName) -replace '</savedqueries>', ''| Set-Content $_.FullName}