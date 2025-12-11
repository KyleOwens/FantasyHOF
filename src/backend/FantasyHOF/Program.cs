using FantasyHOF.Application.Mappers;
using FantasyHOF.ESPN;
using FantasyHOF.GraphQL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddTransient<IESPNAPIClientBuilder, ESPNAPIClientBuilder>();
builder.Services.AddSingleton<IESPNLeagueMapper, ESPNLeagueMapper>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(FantasyHOF.Application.AssemblyMarker).Assembly);
});

builder.AddGraphQL()
    .AddFantasyHOFTypes()
    .AddErrorFilter<FantasyHOFErrorFilter>();
    
var app = builder.Build();

app.MapGraphQL();
app.RunWithGraphQLCommands(args);
