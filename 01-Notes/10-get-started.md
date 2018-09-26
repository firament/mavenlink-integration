# ASP.NET Core Razor Pages app with Visual Studio Code

https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages-vsc/razor-pages-start?view=aspnetcore-2.1

## Initialize
```
dotnet new webapp -o mlpoca
cd mlpoca
dotnet run
```

http://localhost:5000

### Project files and folders

| File or folder  | Purpose |
| ---  | --- |
| wwwroot  | Contains static files. See Static files. |
| Pages  | Folder for Razor Pages. |
| appsettings.json  | Configuration |
| Program.cs  | Hosts the ASP.NET Core app. |
| Startup.cs  | Configures services and the request pipeline. See Startup. |


### Open the project
> First time.

- Select Yes to the Warn message "Required assets to build and debug are missing from 'RazorPagesMovie'. Add them?"
- Select Restore to the Info message "There are unresolved dependencies".

## Data Models
### Add a Model
-    Add a folder named Models.
-    Add a class to the Models folder named Movie.cs.
-    Add the following code to the Models/Movie.cs file:

### Add a database context class
MovieContext.cs
```cs
using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
                : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
```

### Add a database connection string
appsettings.json

```cs
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "ConnectionStrings": {
    "MovieContext": "Data Source=MvcMovie.db"
  }
}
```

### Register the database context
- Console
`dotnet add package Microsoft.EntityFrameworkCore.SQLite`
- Startup.cs
```cs
using RazorPagesMovie.Models;
using Microsoft.EntityFrameworkCore;

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<MovieContext>(options =>
        options.UseSqlite(Configuration.GetConnectionString("MovieContext")));
    services.AddMvc();
}
```

EF tools for the command-line interface (CLI) are provided in Microsoft.EntityFrameworkCore.Tools.DotNet. 
To install this package, add it to the DotNetCliToolReference collection in the .csproj file. 
Note: You have to install this package by editing the .csproj file; you can't use the install-package command or the package manager GUI.

RazorPagesMovie.csproj 
```xml
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.1.0-preview1-final"/>
</ItemGroup>
```

From the command line, run the following .NET Core CLI commands:
```sh
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```

