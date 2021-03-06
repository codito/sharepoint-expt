# sharepoint-expt
Experiments with SharePoint focused on the Enterprise Content Management capabilities (taxonomy, managed metadata and so on).

## Requirements
These experiments are with .NET core, you will need SDK >= 2.0 to run the examples. I used vscode, you can bring your favorite editor.

1. Get .NET core sdk from https://www.microsoft.com/net/download/windows
2. Build the code: `dotnet build`
3. Run the spconsole project: `dotnet run --project .\src\spconsole\spconsole.csproj csom`

## SharePoint SOAP
Sample code is in `src/websvc` directory. Tested in an on-premise deployment.

Protocol documentation is in [msdn](https://msdn.microsoft.com/en-us/library/dd958731(v=office.12).aspx).
Protocol examples are also in [msdn](https://msdn.microsoft.com/en-us/library/dd958731(v=office.12).aspx).

## SharePoint CSOM
Sample code is in `src\csom` directory.

Official nuget packages are available at <https://www.nuget.org/profiles/OfficeDeveloperPlatformTeam>.
