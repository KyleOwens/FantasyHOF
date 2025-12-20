using FantasyHOF.Application.Mappers;
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Enums;
using FantasyHOF.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddTransient<IESPNAPIClientBuilder, ESPNAPIClientBuilder>();
builder.Services.AddSingleton<IESPNLeagueMapper, ESPNLeagueMapper>();

builder.Services.AddDbContext<FantasyHOFDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention();

    options.EnableSensitiveDataLogging();
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(FantasyHOF.Application.AssemblyMarker).Assembly);
});

builder.AddGraphQL()
    .AddFantasyHOFTypes()
    .AddGlobalObjectIdentification()
    .AddMutationConventions(applyToAllMutations: true)
    .AddErrorInterfaceType<ICodedException>();
    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();

    FantasyHOFDBContext context = scope.ServiceProvider.GetRequiredService<FantasyHOFDBContext>();

    //context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.MapGraphQL();
app.RunWithGraphQLCommands(args);



