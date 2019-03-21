# COMP3618FinalProject
Final Project for COMP 3618 Winter 2019 

## Must do
### Restore the database from a bak file
* Right click on `Databases` -> `Restore Databases...` -> Browse your .bak file in `Device` -> `OK`
### Set the tconst as the primary key
(since there wasn't a primary key, it would cause problem when scaffolding if you didn't set it)
* Run SQL query
```SQL
USE IMDb;  
GO
ALTER TABLE movie.titlebasics
	ALTER COLUMN tconst VARCHAR(12) NOT NULL;
GO
ALTER TABLE movie.titlebasics
	ADD CONSTRAINT PK_titlebasics_tconst PRIMARY KEY CLUSTERED (tconst); 
```
* Change connection strings
  * In `IMDbContext.cs` line 25
  
  ```c#
  optionsBuilder.UseSqlServer("Server=(YourServerName);Database=IMDb;Trusted_Connection=True;");
  ```
  * In `Startup.cs` line 31
  
  ```c#
  var connection = @"Server=(YourServerName);Database=IMDb;Trusted_Connection=True;ConnectRetryCount=0";
  ```


## Do the following only when you want to build it from scratch
### Scaffold from the database
* Run Scaffold command
```powershell
Scaffold-DbContext "Server=(YourServerName);Database=IMDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```
