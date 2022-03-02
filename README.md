# Goals
* Create a proof-of-concept Apollo application in Azure
  * Client: WinForms desktop app
  * Middle Tier: ASP.NET Core Web API and Entity Framework Core
  * Database: Postgres
- [x] Load sample data from Apollo into Azure Postgres database
- [x] Use EF Core scaffolding to generate EF Core entities of database objects
- [x] Use Automapper to map between EF entities and DTO objects
- [x] Use swagger to generate client code for WinForms desktop app
- [x] Implement save/submit/publish/revert functionality
- [x] Use Azure scale-out to spin up additional middle tier instances when demand spikes and scale-in when demand decreases
- [x] Set up Azure Application Insights to monitor middle tier health and performance
- [x] Use Azure Web App slots to swap "qm" and "prod" instances
- [x] Set up a CI/CD pipeline using GitHub Actions to automatically deploy middle tier to Azure "qm" slot when new code is committed

# Resources
* [Tutorial: Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
* [Creating Discoverable HTTP APIs with ASP.NET Core 5 Web API](https://devblogs.microsoft.com/dotnet/creating-discoverable-http-apis-with-asp-net-core-5-web-api/)
* [Open-source HTTP API packages and tools](https://devblogs.microsoft.com/dotnet/open-source-http-api-packages-and-tools/)
* [Generating HTTP API clients using Visual Studio Connected Services](https://devblogs.microsoft.com/dotnet/generating-http-api-clients-using-visual-studio-connected-services/)
* [App Building with Azure API Management, Functions, Power Apps, and Logic Apps](https://devblogs.microsoft.com/dotnet/app-building-with-azure-api-management-functions-power-apps-and-logic-apps/)
* [Automapper Docs](https://docs.automapper.org/en/latest/index.html)
* [Npgsql Entity Framework Core Provider](https://www.npgsql.org/efcore/)
* [Entity Framework Core - Scaffolding](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli)
* [Storing connection strings for development](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings)
* [Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows#secret-manager)

# Notes
* Generate EF Core models (execute in project folder)<br />
`dotnet ef dbcontext scaffold Name=ConnectionStrings:postgres Npgsql.EntityFrameworkCore.PostgreSQL --output-dir .\Models.EF\`
