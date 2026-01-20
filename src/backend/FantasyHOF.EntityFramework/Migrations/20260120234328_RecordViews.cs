using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RecordViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_player_aggregation_data AS
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
                INNER JOIN team_matchups owner_matchups ON owner_matchups.owner_matchup_details_id = owner_matchup_details.id
                INNER JOIN league_season_member_teams member_teams ON member_teams.team_id = owner_matchup_details.team_id
                INNER JOIN league_seasons seasons ON seasons.id = member_teams.league_season_id
            ");

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
                ),
                scalars AS (
                SELECT
                        weekly_data.member_id                                                                           AS member_id
                        ,  weekly_data.league_id                                                                           AS league_id
                        ,  weekly_data.year                                                                                AS year
                        ,  MIN(teams.season_rank)                                                                          AS season_rank -- If a member has multiple teams, then select the best rank
                        ,  COUNT(*)                                                                                        AS total_matchups
                        ,  SUM(weekly_data.score)                                                                          AS points_for
                        ,  SUM(weekly_data.opponent_score)                                                                 AS points_against
                        ,  COUNT(*) FILTER (WHERE weekly_data.matchup_outcome_id = 0)                                      AS wins
                        ,  COUNT(*) FILTER (WHERE weekly_data.matchup_outcome_id = 1)                                      AS losses
                        ,  COUNT(*) FILTER (WHERE weekly_data.score = extremes.max_score)                                  AS top_weeks
                        ,  COUNT(*) FILTER (WHERE weekly_data.score = extremes.min_score)                                  AS bottom_weeks
                        ,  COUNT(*) FILTER (WHERE weekly_data.score_margin > 50)                                           AS blowout_wins
                        ,  COUNT(*) FILTER (WHERE weekly_data.score_margin < -50 )                                         AS blowout_losses
                        ,  COUNT(*) FILTER (WHERE weekly_data.score_margin <= 3 AND weekly_data.matchup_outcome_id = 0)    AS narrow_wins
                        ,  COUNT(*) FILTER (WHERE weekly_data.score_margin >= -3 AND weekly_data.matchup_outcome_id = 1)   AS narrow_losses
                        ,  COUNT(*) FILTER (WHERE weekly_data.score > 200)                                                 AS outstanding_performances
                        ,  COUNT(*) FILTER (WHERE weekly_data.score < 100)                                                 AS poor_performances
                FROM vw_weekly_aggregation_data weekly_data

                            INNER JOIN teams ON teams.id = weekly_data.team_id
                            INNER JOIN weekly_matchup_score_extremes extremes
                                    ON extremes.league_id = weekly_data.league_id
                                AND extremes.year = weekly_data.year
                                AND extremes.week = weekly_data.week

                GROUP BY weekly_data.league_id
                        , weekly_data.year
                        , weekly_data.member_id
                )
                SELECT
                        *
                    ,   COALESCE(points_for::decimal/NULLIF(total_matchups, 0), 0)      AS points_for_average
                    ,   COALESCE(points_against::decimal/NULLIF(total_matchups, 0), 0)  AS points_against_average
                    ,   COALESCE(wins::decimal/NULLIF(total_matchups, 0), 0)            AS win_percentage
                    ,   COALESCE(top_weeks/NULLIF(total_matchups, 0) , 0)               AS top_week_percentage
                    ,   COALESCE(bottom_weeks/NULLIF(total_matchups, 0)  , 0)           AS bottom_week_percentage
                FROM scalars
            ");

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
                ),
                scalars as (
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
                    ,   COUNT(*) FILTER (WHERE season_reference.season_rank = 1)                                    AS championships
                    ,   COUNT(*) FILTER (WHERE season_reference.season_rank = last_places.last_place_rank)          AS last_places
                    ,   COUNT(*) FILTER (WHERE season_reference.wins > season_reference.losses)                     AS winning_seasons
                    ,   COUNT(*) FILTER (WHERE season_reference.losses > season_reference.wins)                     AS losing_seasons
                    ,   SUM(season_reference.outstanding_performances)                                              AS outstanding_performances
                    ,   SUM(season_reference.poor_performances)                                                     AS poor_performances
                FROM vw_league_season_member_aggregated_stats season_reference

                INNER JOIN last_places ON last_places.league_id = season_reference.league_id AND last_places.year = season_reference.year

                GROUP BY
                        season_reference.league_id
                    ,   season_reference.member_id
                )
                SELECT
                        *
                    ,   COALESCE(points_for::decimal/NULLIF(total_matchups, 0), 0)      AS points_for_average
                    ,   COALESCE(points_against::decimal/NULLIF(total_matchups, 0), 0)  AS points_against_average
                    ,   COALESCE(wins::decimal/NULLIF(total_matchups, 0), 0)            AS win_percentage
                    ,   COALESCE(top_weeks::decimal/NULLIF(total_matchups, 0), 0)       AS top_week_percentage
                    ,   COALESCE(bottom_weeks::decimal/NULLIF(total_matchups, 0), 0)    AS bottom_week_percentage
                    ,   COALESCE(championships::decimal/NULLIF(total_seasons, 0), 0)    AS championship_percentage
                    ,   COALESCE(last_places::decimal/NULLIF(total_seasons, 0), 0)      AS last_place_percentage
                    ,   COALESCE(winning_seasons::decimal/NULLIF(total_seasons, 0), 0)  AS winning_season_percentage
                    ,   COALESCE(losing_seasons::decimal/NULLIF(total_seasons, 0), 0)   AS losing_season_percentage
                FROM scalars
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_league_member_aggregated_stats");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_league_season_member_aggregated_stats");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_weekly_aggregation_data");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_player_aggregation_data");
        }
    }
}
