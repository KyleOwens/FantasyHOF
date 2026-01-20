using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.EntityFramework.Extensions
{
    public static class PostMigrationScriptsExtension
    {
        public static async Task ApplyPostMigrationScriptsAsync(this FantasyHOFDBContext database)
        {
            await database.Database.ExecuteSqlRawAsync(@"
                GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO fantasyhof_app;
                GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO fantasyhof_app;
            ");
        }
    }
}
