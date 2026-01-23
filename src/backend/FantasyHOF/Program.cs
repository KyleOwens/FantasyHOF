using FantasyHOF.ApplicationBuilderExtensions;
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

string connectionString = builder.Configuration.GetConnectionString("AppConnection")
    ?? throw new Exception("Failed to load connection string from config");

builder.Services.AddFantasyHOFAuthenticationServices(
    builder.Environment,
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
    app.UseHangfireDashboard("/hangfire");
}

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

app.MapGraphQL();

app.RunWithGraphQLCommands(args);



