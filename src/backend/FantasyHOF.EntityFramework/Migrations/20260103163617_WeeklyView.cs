using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class WeeklyView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_weekly_aggregation_data AS
                SELECT
                        member_teams.member_id                                                      AS member_id
                    ,   matchups.team_id                                                            AS team_id
                    ,   seasons.league_id                                                           AS league_id
                    ,   seasons.year                                                                AS year
                    ,   matchups.week                                                               AS week
                    ,   matchups.matchup_type_id                                                    AS matchup_type_id
                    ,   matchup_owner_details.score                                                 AS score
                    ,   COALESCE(matchup_opponent_details.score,0)                                  AS opponent_score
                    ,   matchup_owner_details.score - COALESCE(matchup_opponent_details.score, 0)   AS score_margin
                    ,   matchup_owner_details.matchup_outcome_id                                    AS matchup_outcome_id
                FROM team_matchups matchups

                INNER JOIN matchup_team_details matchup_owner_details       ON matchup_owner_details.id = matchups.owner_matchup_details_id
                LEFT  JOIN matchup_team_details matchup_opponent_details    ON matchup_opponent_details.id = matchups.opponent_matchup_details_id
                INNER JOIN league_season_member_teams member_teams          ON member_teams.team_id = matchups.team_id
                INNER JOIN league_seasons seasons                           ON seasons.id = member_teams.league_season_id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_weekly_aggregation_data");
        }
    }
}
