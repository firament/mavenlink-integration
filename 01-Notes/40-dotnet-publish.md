# dotnet publish

```sh
# For use in integrated terminal, or from root path
dotnet publish -v n -f netcoreapp2.1 -c Release -o ~/Downloads/mlpoca-pub-c 2>&1 | tee out/mlpoca-pub-c-n.log
```

Packs the application and its dependencies into a folder for deployment to a hosting system.

- `dotnet publish` compiles the application, reads through its dependencies specified in the project file, 
- and publishes the resulting set of files to a directory. 
- The output includes the following assets:
	- Intermediate Language (IL) code in an assembly with a dll extension.
	- .deps.json file that includes all of the dependencies of the project.
	- .runtime.config.json file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).
	- The application's dependencies, which are copied from the NuGet cache into the output folder.
- The dotnet publish command's output is ready for deployment to a hosting system


## Synopsis
```sh
dotnet publish 
	[<PROJECT>] 
	[-c|--configuration] 
	[-f|--framework] 
	[--force] 
	[--manifest] 
	[--no-build] 
	[--no-dependencies]
    [--no-restore] 
	[-o|--output] 
	[-r|--runtime] 
	[--self-contained] 
	[-v|--verbosity] 
	[--version-suffix]

dotnet publish [-h|--help]
```

## Arguments
- `PROJECT`
	- The project to publish. If not specified, it defaults to the current directory.
- `-c|--configuration {_Debug_|Release}`
- `-f|--framework <FRAMEWORK>`
	- `netcoreapp2.1`
	- Publishes the application for the specified target framework. 
	- You must specify the target framework in the project file.
	- https://docs.microsoft.com/en-us/dotnet/standard/frameworks
- `--force`
	- Forces all dependencies to be resolved even if the last restore was successful. 
	- Specifying this flag is the same as deleting the project.assets.json file.
- `--manifest <PATH_TO_MANIFEST_FILE>`
	- Specifies one or several target manifests to use to trim the set of packages published with the app. 
	- The manifest file is part of the output of the dotnet store command. 
	- To specify multiple manifests, add a `--manifest` option for each manifest. 
- `--no-build`
	- Doesn't build the project before publishing. 
	- It also implicitly sets the `--no-restore` flag.
- `--no-dependencies`
	- Ignores project-to-project references and only restores the root project.
- `--no-restore`
	- Doesn't execute an implicit restore when running the command.
- `-o|--output <OUTPUT_DIRECTORY>`
	- Specifies the path for the output directory. 
	- If not specified, it defaults to ./bin/[configuration]/[framework]/publish/ for a framework-dependent deployment 
	- or ./bin/[configuration]/[framework]/[runtime]/publish/ for a self-contained deployment. 
	- If the path is relative, 
	- the output directory generated is relative to the project file location, not to the current working directory.
- `--self-contained`
	- Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. 
	- If a runtime identifier is specified, its default value is `true`.
- `-r|--runtime <RUNTIME_IDENTIFIER>`
	- Publishes the application for a given runtime.
	- This is used when creating a self-contained deployment (SCD).
	- Default is to publish a framework-dependent deployment (FDD).
	- See https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
		- `win-x64`, `linux-x64` 
- `-v|--verbosity <LEVEL>`
	- Sets the verbosity level of the command. 
	- Allowed values are 
		- q[uiet]
		- m[inimal]
		- n[ormal]
		- d[etailed]
		- diag[nostic]
- `--version-suffix <VERSION_SUFFIX>`
	- Defines the version suffix to replace the asterisk (*) in the version field of the project file.

## Examples
- `dotnet publish --framework netcoreapp1.1 --runtime osx.10.11-x64`
	- must list this RID in the project file
- Update the project's dependencies and tools.
	- `dotnet restore`
	- Starting with .NET Core 2.0, `dotnet restore` is run implicitly by all commands that require a restore to occur, 
	- such as dotnet new, dotnet build and dotnet run.
- Create a Debug build
	- `dotnet build`
- Deploy your app
	- `dotnet publish -f netcoreapp2.1 -c Release`
- Run
	- `dotnet fdd.dll`

## --runtime
- https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json
- https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
	```xml
	<PropertyGroup>
		<RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
	</PropertyGroup>
	```

## Framework-dependent deployments (FDD)
- For an FDD, you deploy only your app and third-party dependencies. 
- This is the default deployment model for .NET Core and ASP.NET Core apps that target .NET Core.
- **Advantages:**
	- You don't have to define the target operating systems that your .NET Core app will run on in advance. Because .NET Core uses a common PE file format for executables and libraries regardless of operating system, .NET Core can execute your app regardless of the underlying operating system. For more information on the PE file format, see .NET Assembly File Format.
	- The size of your deployment package is small. You only deploy your app and its dependencies, not .NET Core itself.
	- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.
- **Disadvantages:**
	- Your app can run only if the version of .NET Core that you target, or a later version, is already installed on the host system.
	- It's possible for the .NET Core runtime and libraries to change without your knowledge in future releases. In rare cases, this may change the behavior of your app.
- Including third-party dependencies
	```xml
	<ItemGroup>
	<PackageReference Include="Newtonsoft.Json" Version="10.0.2" />
	</ItemGroup>
	```
- use globalization invariant mode
	- can reduce the total size of your deployment by taking advantage of globalization invariant mode
		```xml
		<Project Sdk="Microsoft.NET.Sdk">
		<PropertyGroup>
			<OutputType>Exe</OutputType>
			<TargetFramework>netcoreapp2.1</TargetFramework>
		</PropertyGroup>
		<ItemGroup>
			<RuntimeHostConfigurationOption Include="System.Globalization.Invariant" Value="true" />
		</ItemGroup> 
		</Project>	
		```

## Target frameworks preprocessor symbols
- https://docs.microsoft.com/en-us/dotnet/standard/frameworks
	```cs
	public class MyClass
	{
		static void Main()
		{
	#if NET40
			Console.WriteLine("Target framework: .NET Framework 4.0");
	#elif NET45  
			Console.WriteLine("Target framework: .NET Framework 4.5");
	#else
			Console.WriteLine("Target framework: .NET Standard 1.4");
	#endif
		}
	}
	```

| Target Frameworks | Symbols                                                                                                                        |
|-------------------|--------------------------------------------------------------------------------------------------------------------------------|
| .NET Framework    | NET20, NET35, NET40, NET45, NET451, NET452, NET46, NET461, NET462, NET47, NET471, NET472                                       |
| .NET Standard     | NETSTANDARD1_0, NETSTANDARD1_1, NETSTANDARD1_2, NETSTANDARD1_3, NETSTANDARD1_4, NETSTANDARD1_5, NETSTANDARD1_6, NETSTANDARD2_0 |
| .NET Core         | NETCOREAPP1_0, NETCOREAPP1_1, NETCOREAPP2_0, NETCOREAPP2_1                                                                     |
