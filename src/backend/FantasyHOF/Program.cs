using FantasyHOF.ApplicationBuilderExtensions;
using FantasyHOF.EntityFramework;
using FantasyHOF.ServiceExtensions;
using FantasyHOF.WebApplicationExtensions;
using Hangfire;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "HH:mm:ss";
});

builder.Logging.SetMinimumLevel(LogLevel.Information);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("Failed to load connection string from config");

builder.Services.AddFantasyHOFAuthenticationServices(
    builder.Configuration["Authentication:Authority"]
    ?? throw new Exception("Failed to load JWT authority from config"));

builder.Services.AddFantasyHOFDatabaseServices(connectionString);

builder.Services.AddFantasyHOFHttpServices();
builder.Services.AddFantasyHOFCurrentUserService();
builder.Services.AddFantasyHOFApplicationServices(builder.Configuration.GetSection("Authentication"), connectionString);
builder.Services.AddFantasyHOFMediatRServices();

await builder.AddFantasyHOFGraphQL();

var app = builder.Build();

await app.AddGraphQLDeveloperToolsAsync();

if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();

    FantasyHOFDBContext context = scope.ServiceProvider.GetRequiredService<FantasyHOFDBContext>();

    context.Database.EnsureDeleted();
    context.Database.Migrate();

    app.UseHangfireDashboard("/hangfire");
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);



