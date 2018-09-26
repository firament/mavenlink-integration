## `dotnet new webapp -o mlpoca`

Output:
```
Welcome to .NET Core!
---------------------
Learn more about .NET Core: https://aka.ms/dotnet-docs
Use 'dotnet --help' to see available commands or visit: https://aka.ms/dotnet-cli-docs

Telemetry
---------
The .NET Core tools collect usage data in order to help us improve your experience. The data is anonymous and doesn't include command-line arguments. The data is collected by Microsoft and shared with the community. You can opt-out of telemetry by setting the DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about .NET Core CLI Tools telemetry: https://aka.ms/dotnet-cli-telemetry

Configuring...
--------------
A command is running to populate your local package cache to improve restore speed and enable offline access. This command takes up to one minute to complete and only runs once.
Decompressing 100% 6727 ms
Expanding 100% 8466 ms

ASP.NET Core
------------
Successfully installed the ASP.NET Core HTTPS Development Certificate.
To trust the certificate run 'dotnet dev-certs https --trust' (Windows and macOS only). For establishing trust on other platforms refer to the platform specific documentation.
For more information on configuring HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.
Getting ready...
The template "ASP.NET Core Web App" was created successfully.
This template contains technologies from parties other than Microsoft, see https://aka.ms/aspnetcore-template-3pn-210 for details.

Processing post-creation actions...
Running 'dotnet restore' on mlpoca/mlpoca.csproj...
  Restoring packages for /media/sak/70_Current/Learning/mlpoca/mlpoca.csproj...
  Generating MSBuild file /media/sak/70_Current/Learning/mlpoca/obj/mlpoca.csproj.nuget.g.props.
  Generating MSBuild file /media/sak/70_Current/Learning/mlpoca/obj/mlpoca.csproj.nuget.g.targets.
  Restore completed in 591.88 ms for /media/sak/70_Current/Learning/mlpoca/mlpoca.csproj.

Restore succeeded.
```

## `dotnet run`
Output:
```
Using launch settings from /media/sak/70_Current/Learning/mlpoca/Properties/launchSettings.json...
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using '/home/sak/.aspnet/DataProtection-Keys' as key repository; keys will not be encrypted at rest.
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[58]
      Creating key {94d1303c-b2a2-41d7-be13-330d13efb757} with creation date 2018-09-18 14:02:23Z, activation date 2018-09-18 14:02:23Z, and expiration date 2018-12-17 14:02:23Z.
warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
      No XML encryptor configured. Key {94d1303c-b2a2-41d7-be13-330d13efb757} may be persisted to storage in unencrypted form.
info: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[39]
      Writing data to file '/home/sak/.aspnet/DataProtection-Keys/key-94d1303c-b2a2-41d7-be13-330d13efb757.xml'.
Hosting environment: Development
Content root path: /media/sak/70_Current/Learning/mlpoca
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.

```
