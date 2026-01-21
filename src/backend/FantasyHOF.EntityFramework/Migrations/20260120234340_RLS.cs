using Microsoft.EntityFrameworkCore.Migrations;

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

            foreach (string table in _rlsTables)
            {
                string policyName = $"rls_{table}_user_select_own";

                migrationBuilder.Sql($"ALTER TABLE {table} ENABLE ROW LEVEL SECURITY;");
                migrationBuilder.Sql($"ALTER TABLE {table} FORCE ROW LEVEL SECURITY;");

                migrationBuilder.Sql($"DROP POLICY IF EXISTS {policyName} on {table}");
                migrationBuilder.Sql($@"
                    CREATE POLICY {policyName} on {table}
                    FOR ALL
                    USING (user_id = current_app_user_id());
                ");
            }

            migrationBuilder.Sql($"ALTER TABLE users ENABLE ROW LEVEL SECURITY;");
            migrationBuilder.Sql($"ALTER TABLE users FORCE ROW LEVEL SECURITY;");

            migrationBuilder.Sql($"DROP POLICY IF EXISTS rls_users_user_select_own on users");
            migrationBuilder.Sql($@"
                    CREATE POLICY rls_users_user_select_own on users
                    FOR ALL
                    USING (id = current_app_user_id());
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var table in _rlsTables)
            {
                string policyName = $"rls_{table}_user_select_own";

                migrationBuilder.Sql($"DROP POLICY IF EXISTS {policyName} ON {table};");
                migrationBuilder.Sql($"ALTER TABLE {table} DISABLE ROW LEVEL SECURITY;");
            }

            migrationBuilder.Sql($"DROP POLICY IF EXISTS rls_users_user_select_own ON users;");
            migrationBuilder.Sql($"ALTER TABLE users DISABLE ROW LEVEL SECURITY;");

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS ensure_user_exists(text);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS current_app_user_id();");
        }
    }
}
