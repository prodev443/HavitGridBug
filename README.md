# Requirements

- .NET Core 8
- SQL Server

# Setup
- Install dotnet dependencies: `dotnet restore`
- Create a development database in SQL Server 
- Copy appsettings.json.example to appsettings.json and edit "Default" SQL Server Connection
- Run migrations with `dotnet ef database update`
- You need to populate the customers table with fake data

# Where is the bug?

Go to the home page and you'll see an HxGrid there