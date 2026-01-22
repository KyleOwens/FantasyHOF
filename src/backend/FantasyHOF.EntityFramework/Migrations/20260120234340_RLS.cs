using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RLS : Migration
    {
        private readonly string[] _rlsTables =
        [
            "leagues",
            "league_imports",
            "league_seasons",
            "league_members",
            "league_season_members",
            "league_season_member_teams",
            "league_season_settings",
            "league_season_schedule_settings",
            "league_season_scoring_settings",
            "league_season_scoring_items",
            "teams",
            "team_season_stats",
            "team_matchups",
            "matchup_team_details",
            "matchup_roster_spots",
            "accumulated_stats",
            "users"
        ];

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION current_app_user_id() RETURNS text AS $$
                BEGIN
                    RETURN NULLIF(current_setting('app.current_user_id', true), '');
                EXCEPTION
                    WHEN OTHERS THEN RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION ensure_user_exists(user_id text)
                RETURNS void
                LANGUAGE sql
                SECURITY DEFINER
                AS $$
                    INSERT INTO users (id, created_at)
                    VALUES (user_id, NOW())
                    ON CONFLICT (Id) DO NOTHING;
                $$;
            ");

            string demoUserId = GetDemoUserId();

            foreach (string table in _rlsTables)
            {
                string selectPolicyName = $"rls_{table}_user_select";
                string insertPolicyName = $"rls_{table}_user_insert";
                string updatePolicyName = $"rls_{table}_user_update";
                string deletePolicyName = $"rls_{table}_user_delete";

                string idField = table == "users" ? "id" : "user_id";

                migrationBuilder.Sql($"ALTER TABLE {table} ENABLE ROW LEVEL SECURITY;");
                migrationBuilder.Sql($"ALTER TABLE {table} FORCE ROW LEVEL SECURITY;");

                migrationBuilder.Sql($"DROP POLICY IF EXISTS {selectPolicyName} on {table}");
                migrationBuilder.Sql($@"
                    CREATE POLICY {selectPolicyName} on {table}
                    FOR SELECT
                    USING ({idField} = current_app_user_id() OR {idField} = '{demoUserId}');
                ");

                // INSERT: own data only
                migrationBuilder.Sql($"DROP POLICY IF EXISTS {insertPolicyName} on {table}");
                migrationBuilder.Sql($@"
                    CREATE POLICY {insertPolicyName} on {table}
                    FOR INSERT
                    WITH CHECK ({idField} = current_app_user_id());
                ");

                // UPDATE: own data only
                migrationBuilder.Sql($"DROP POLICY IF EXISTS {updatePolicyName} on {table}");
                migrationBuilder.Sql($@"
                    CREATE POLICY {updatePolicyName} on {table}
                    FOR UPDATE
                    USING ({idField} = current_app_user_id())
                    WITH CHECK ({idField} = current_app_user_id());
                ");

                // DELETE: own data only
                migrationBuilder.Sql($"DROP POLICY IF EXISTS {deletePolicyName} on {table}");
                migrationBuilder.Sql($@"
                    CREATE POLICY {deletePolicyName} on {table}
                    FOR DELETE
                    USING ({idField} = current_app_user_id());
                ");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var table in _rlsTables)
            {
                string selectPolicyName = $"rls_{table}_user_select";
                string insertPolicyName = $"rls_{table}_user_insert";
                string updatePolicyName = $"rls_{table}_user_update";
                string deletePolicyName = $"rls_{table}_user_delete";

                migrationBuilder.Sql($"DROP POLICY IF EXISTS {selectPolicyName} ON {table};");
                migrationBuilder.Sql($"DROP POLICY IF EXISTS {insertPolicyName} ON {table};");
                migrationBuilder.Sql($"DROP POLICY IF EXISTS {updatePolicyName} ON {table};");
                migrationBuilder.Sql($"DROP POLICY IF EXISTS {deletePolicyName} ON {table};");
                migrationBuilder.Sql($"ALTER TABLE {table} DISABLE ROW LEVEL SECURITY;");
            }

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS ensure_user_exists(text);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS current_app_user_id();");
        }

        private static string GetDemoUserId()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();

            return configuration["Authentication:AdminClerkUserId"]
                ?? throw new InvalidOperationException("DemoUserId not found in configuration");
        }
    }
}
