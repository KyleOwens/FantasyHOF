using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SeasonalView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_league_season_member_aggregated_stats AS
                WITH weekly_matchup_score_extremes AS (
                    SELECT
                            league_id   AS league_id
                        ,   year        AS year
                        ,   week        AS week
                        ,   MAX(score)  AS max_score
                        ,   MIN(score)  AS min_score
                    FROM vw_weekly_aggregation_data
                    GROUP BY
                            league_id
                        ,   year
                        ,   week
                )
                SELECT
                        weekly_data.member_id                                                                                   AS member_id
                    ,   weekly_data.league_id                                                                                   AS league_id
                    ,   weekly_data.year                                                                                        AS year
                    ,   MIN(teams.season_rank)                                                                                  AS season_rank -- If a member has multiple teams, then select the best rank
                    ,   COUNT(*)                                                                                                AS total_matchups
                    ,   SUM(weekly_data.score)                                                                                  AS points_for
                    ,   SUM(weekly_data.opponent_score)                                                                         AS points_against
                    ,   SUM(CASE WHEN weekly_data.matchup_outcome_id = 0 THEN 1 ELSE 0 END)                                     AS wins
                    ,   SUM(CASE WHEN weekly_data.matchup_outcome_id = 1 THEN 1 ELSE 0 END)                                     AS losses
                    ,   SUM(CASE WHEN weekly_data.score = extremes.max_score THEN 1 ELSE 0 END)                                 AS top_weeks
                    ,   SUM(CASE WHEN weekly_data.score = extremes.min_score THEN 1 ELSE 0 END)                                 AS bottom_weeks
                    ,   SUM(CASE WHEN weekly_data.score_margin > 50 THEN 1 ELSE 0 END)                                          AS blowout_wins
                    ,   SUM(CASE WHEN weekly_data.score_margin < -50 THEN 1 ELSE 0 END)                                         AS blowout_losses
                    ,   SUM(CASE WHEN weekly_data.score_margin <= 3 AND weekly_data.matchup_outcome_id = 0 THEN 1 ELSE 0 END)   AS narrow_wins
                    ,   SUM(CASE WHEN weekly_data.score_margin >= -3 AND weekly_data.matchup_outcome_id = 1 THEN 1 ELSE 0 END)  AS narrow_losses
                    ,   SUM(CASE WHEN weekly_data.score > 200 THEN 1 ELSE 0 END)                                                AS outstanding_performances
                    ,   SUM(CASE WHEN weekly_data.score < 100 THEN 1 ELSE 0 END)                                                AS poor_performances
                FROM vw_weekly_aggregation_data weekly_data

                INNER JOIN teams ON teams.id = weekly_data.team_id
                INNER JOIN weekly_matchup_score_extremes extremes
                    ON  extremes.league_id = weekly_data.league_id
                    AND extremes.year = weekly_data.year
                    AND extremes.week = weekly_data.week

                GROUP BY
                        weekly_data.league_id
                    ,   weekly_data.year
                    ,   weekly_data.member_id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_league_season_member_aggregated_stats");
        }
    }
}
