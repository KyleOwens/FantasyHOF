using HotChocolate.Execution;
using Path = System.IO.Path;

namespace FantasyHOF.WebApplicationExtensions
{
    public static class AddGraphQLDeveloperToolsExtension
    {
        public static async Task<WebApplication?> AddGraphQLDeveloperToolsAsync(this WebApplication? app)
        {
            if (app == null) throw new InvalidOperationException("Couldn't add GraphQL tools");

            if (app.Environment.IsDevelopment())
            {
                var executor = await app.Services.GetRequestExecutorAsync();
                var schemaLocation = Path.Combine(Directory.GetCurrentDirectory(), "../../frontend/src/relay/schema.graphql");

                await File.WriteAllTextAsync(schemaLocation, executor.Schema.Print());
            }

            return app;
        }
    }
}
