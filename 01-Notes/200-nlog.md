
## Packages
- NLog
- NLog.Web
- ~~NLog.Web.AspNetCore~~



- https://github.com/NLog/NLog.Web/wiki/Getting-started-with-ASP.NET-Core-2
	- Add dependency in csproj manually or using NuGet
		- NLog.Web.AspNetCore 4.5+
		- in csproj:
			```xml
			<PackageReference Include="NLog.Web.AspNetCore" Version="4.5.1" />
			<PackageReference Include="NLog" Version="4.5.1" />
			```
	- Create nlog.config (lowercase all) file in the root of your project.


## See Aloso
- https://github.com/damienbod/AspNetCoreNlog
