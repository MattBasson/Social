# Social

Solution runs on .netCore 3.1
Open up in your editor of choice run in IIS Express.

## Social.Watson.API (Web Api)
Hit the root of this site to get swagger docs.
Initially was going to be the endpoint of the Social Api which would sanitize the input before saving the item to the database using another api.

PLease remember to update Watson Key settings in the appsettings.json file.


##Social.Database.API (Web Api)
Hit the root of this site to get the swagger docs.
This contains all the ddatabase logic, that does all Crud Operations.
Currently uses SQL lite and EF Core.
to get working 
 dotnet tool install --global dotnet-ef

 and then

 dotnet ef database update (either from WebApi project or the infrastructure project.)

 