using FantasyHOF.ESPN;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IESPNHTTPService, ESPNHTTPClient>();

builder.AddGraphQL()
    .AddFantasyHOFTypes();

var app = builder.Build();

app.MapGraphQL();
app.RunWithGraphQLCommands(args);
