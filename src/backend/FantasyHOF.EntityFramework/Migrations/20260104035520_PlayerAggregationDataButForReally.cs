using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class PlayerAggregationDataButForReally : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_player_aggregation_stats AS
                SELECT
                        seasons.league_id
                    ,   member_teams.member_id
                    ,   seasons.year
                    ,   owner_matchups.week
                    ,   roster_spots.points_scored
                    ,   roster_spots.player_id
                    ,   roster_spots.position_id
                FROM matchup_roster_spots roster_spots

                INNER JOIN matchup_team_details owner_matchup_details ON owner_matchup_details.id = roster_spots.matchup_team_details_id
                INNER JOIN team_matchups owner_matchups ON owner_matchups.team_id = owner_matchup_details.team_id
                INNER JOIN league_season_member_teams member_teams ON member_teams.team_id = owner_matchup_details.team_id
                INNER JOIN league_seasons seasons ON seasons.id = member_teams.league_season_id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_player_aggregation_stats");
        }
    }
}
