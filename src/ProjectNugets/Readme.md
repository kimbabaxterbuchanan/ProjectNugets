ProjectNugets
Kimba Buchanan
7/10/2024

There are two major Forms to this project.  Display and Load. Each form contains a set of 
radio buttons to select between Main/Master and Upgrade branches

1. Display	
	Will allow the user to display Solution, Nuget and Any data.
	Solution - will display the selected solutions project and nuget information
	Nuget - will display all solutions/projects that reference the selected Nuget
	Any - allows for canned or custom queries.
2. Load
	will allow you to Create Tables, Get Repo, update Nuget, Browse
	Create Tables
		will drop each table and recreate it
	Get Repo	
		will provide a method to run canned PS or custom PS Scripts
	Update Nuget	
		will verify and update missing IsNuget flags
	Browse
		used in conjunction with Create Tables, will allow the user 
			to select the folder where the checked out repos exist
			run *.csproj searches for all referenced Wellpath or Third Party Nugets
			store the findings in the Database Tables.
