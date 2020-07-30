# WebApi
 WebApi with MongoDB

### Installation Process 

1) Download/Fork/Clone the repository 
```bash
git clone https://github.com/MDrakakis/WebApi.git
```
2) You will need these two Nuget Packages 
``` MongoDB.Bson``` and ``` MongoDB.Driver ``` 

3) Open appsettings.json. Change the following lines to look to your database settings.
```json
"UserDatabaseSettings": {
    "UserCollectionName": "Users",
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "UserDB"
```
