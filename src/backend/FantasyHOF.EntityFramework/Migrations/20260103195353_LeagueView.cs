using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class LeagueView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_league_member_aggregated_stats AS
                WITH last_places AS (
                    SELECT
                            seasons.league_id       AS league_id
                        ,   seasons.year            AS year
                        ,   MAX(teams.season_rank)  AS last_place_rank
                    FROM league_seasons seasons

                    INNER JOIN league_season_member_teams member_teams  ON member_teams.league_season_id = seasons.id
                    INNER JOIN teams                                    ON teams.id = member_teams.team_id

                    GROUP BY seasons.league_id, seasons.year
                )
                SELECT
                        season_reference.league_id                                                                  AS league_id
                    ,   season_reference.member_id                                                                  AS member_id
                    ,   COUNT(*)                                                                                    AS total_seasons
                    ,   SUM(season_reference.total_matchups)                                                        AS total_matchups
                    ,   SUM(season_reference.points_for)                                                            AS points_for
                    ,   SUM(season_reference.points_against)                                                        AS points_against
                    ,   SUM(season_reference.wins)                                                                  AS wins
                    ,   SUM(season_reference.losses)                                                                AS losses
                    ,   SUM(season_reference.top_weeks)                                                             AS top_weeks
                    ,   SUM(season_reference.bottom_weeks)                                                          AS bottom_weeks
                    ,   SUM(season_reference.blowout_wins)                                                          AS blowout_wins
                    ,   SUM(season_reference.blowout_losses)                                                        AS blowout_losses
                    ,   SUM(season_reference.narrow_wins)                                                           AS narrow_wins
                    ,   SUM(season_reference.narrow_losses)                                                         AS narrow_losses
                    ,   SUM(CASE WHEN season_reference.season_rank = 1 THEN 1 ELSE 0 END)                           AS championships
                    ,   SUM(CASE WHEN season_reference.season_rank = last_places.last_place_rank THEN 1 ELSE 0 END) AS last_places
                    ,   SUM(CASE WHEN season_reference.wins > season_reference.losses THEN 1 ELSE 0 END)            AS winning_seasons
                    ,   SUM(CASE WHEN season_reference.losses > season_reference.wins THEN 1 ELSE 0 END)            AS losing_seasons
                    ,   SUM(season_reference.outstanding_performances)                                              AS outstanding_performances
                    ,   SUM(season_reference.poor_performances)                                                     AS poor_performances
                FROM vw_league_season_member_aggregated_stats season_reference

                INNER JOIN last_places ON last_places.league_id = season_reference.league_id AND last_places.year = season_reference.year

                GROUP BY
                        season_reference.league_id
                    ,   season_reference.member_id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_league_member_aggregated_stats");
        }
    }
}
