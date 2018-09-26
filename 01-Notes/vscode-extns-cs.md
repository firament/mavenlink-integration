# Productivity extensions for development

- ~~vscode-tidyhtml~~
	- https://marketplace.visualstudio.com/items?itemName=anweber.vscode-tidyhtml
	- format html with tidy html
	- does it work on razor? NO
- ~~ASP.NET Helper~~
	- https://marketplace.visualstudio.com/items?itemName=schneiderpat.aspnet-helper
	- parses project to enable IntelliSense for Razor pages within an ASP.NET MVC project
	- checks if used model is still valid
	- Conventions over configuration
- ~~Dotnet core commands~~
	- **Does not work**
	- https://marketplace.visualstudio.com/items?itemName=matijarmk.dotnet-core-commands
	- Dotnet core SKD commands, EntityFrameworkCore migrations and NuGet Package management
- ~~IntelliSense for CSS class names in HTML~~
	- https://marketplace.visualstudio.com/items?itemName=Zignd.html-css-class-completion
	- provides CSS class name completion for the HTML class attribute based on the definitions found in your workspace 
	- or external files referenced through the link element.

## Other - .csproj
- https://github.com/dotnet/docs/blob/master/docs/core/tools/csproj.md
```XML
<ItemGroup>
  <PackageReference Include="xunit.runner.visualstudio" Version="2.2.0" />
  <PackageReference Include="MySql.Data" Version="6.9.9" />
</ItemGroup>
```
### https://github.com/dotnet/docs/blob/master/docs/core/tools/csproj.md
- see the whole project as MSBuild sees it
	- Preprocess the project with the /pp switch of the dotnet msbuild command, 
	- which shows which files are imported, their sources, and their contributions 
	- to the build without actually building the project
	- `dotnet msbuild -pp:out/fullproject.xml`
- DotNetCliToolReference
	- `<DotNetCliToolReference>` item element specifies the CLI tool that the user wants to restore in the context of the project. 
	- It's a replacement for the tools node in project.json.
	- `<DotNetCliToolReference Include="<package-id>" Version="" />`
- 
