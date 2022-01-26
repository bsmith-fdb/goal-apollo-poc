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

# Migration Challenges
* Implementing change history logic (updating _C, _A, _H tables)
  * Should we keep the logic in stored procedures?
  * If the logic lives in C# code (assuming EntityFramework is used)
    * Will this hurt performance? (lots of DB calls)
    * How can we script the loading of data (like we do with DML DCRs)?