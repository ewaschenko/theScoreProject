# theScoreProject
Take home project for theScore

# Deploy Backend
- Download & Install SQL Express
https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- Download & Install Microsoft SSMS https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15
- Download & Install .NET 6 and .NET Core CLI https://docs.microsoft.com/en-us/ef/core/cli/dotnet
- Log onto SQL Express server with SSMS and create a new database called dev
- In Visual Studio 2022 add ConnectionString to appsettings.json
- Open Package Manager Console and execute ```dotnet ef database update```
- Run theScoreAPI

# Deploy Front End
```npm install```
```ng serve --proxy-config proxy.conf.json --open```
