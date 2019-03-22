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
  * In `Web.config` line 87
  
  ```c#
  <add name="IMDbEntities1" connectionString="metadata=res://*/Models.MovieModel.csdl|res://*/Models.MovieModel.ssdl|res://*/Models.MovieModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(YourServerName);initial catalog=IMDb;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  ```
