using FantasyHOF.ApplicationExtensions;
using FantasyHOF.EntityFramework;
using FantasyHOF.ServiceExtensions;
using Hangfire;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Path = System.IO.Path;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFantasyHOFAuthenticationServices(
    builder.Configuration["Authentication:Authority"]
    ?? throw new Exception("Failed to load JWT authority from config"));

builder.Services.AddFantasyHOFDatabaseServices(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("Failed to load connection string from config"));

builder.Services.AddFantasyHOFHttpServices();
builder.Services.AddFantasyHOFCurrentUserService();
builder.Services.AddFantasyHOFApplicationServices(builder.Configuration.GetSection("Authentication"));
builder.Services.AddFantasyHOFMediatRServices();

builder.AddFantasyHOFGraphQL();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var executor = await app.Services.GetRequestExecutorAsync();
    var schemaLocation = Path.Combine(Directory.GetCurrentDirectory(), "../../frontend/src/relay/schema.graphql");

    await File.WriteAllTextAsync(schemaLocation, executor.Schema.Print());

    using IServiceScope scope = app.Services.CreateScope();

    FantasyHOFDBContext context = scope.ServiceProvider.GetRequiredService<FantasyHOFDBContext>();

    //context.Database.EnsureDeleted();
    context.Database.Migrate();

    app.UseHangfireDashboard("/hangfire");
}



app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);



