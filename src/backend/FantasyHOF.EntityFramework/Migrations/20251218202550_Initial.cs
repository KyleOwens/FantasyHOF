using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fantasy_providers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fantasy_providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "matchup_outcomes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matchup_outcomes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "matchup_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matchup_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provider_team_id = table.Column<int>(type: "integer", nullable: false),
                    abbreviation = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fantasy_members",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fantasy_provider_id = table.Column<int>(type: "integer", nullable: false),
                    provider_member_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    first_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    last_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fantasy_members", x => x.id);
                    table.ForeignKey(
                        name: "fk_fantasy_members_fantasy_providers_fantasy_provider_id",
                        column: x => x.fantasy_provider_id,
                        principalTable: "fantasy_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "leagues",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fantasy_provider_id = table.Column<int>(type: "integer", nullable: false),
                    provider_league_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sport_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_leagues", x => x.id);
                    table.ForeignKey(
                        name: "fk_leagues_fantasy_providers_fantasy_provider_id",
                        column: x => x.fantasy_provider_id,
                        principalTable: "fantasy_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provider_id = table.Column<int>(type: "integer", nullable: false),
                    provider_player_id = table.Column<int>(type: "integer", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_players", x => x.id);
                    table.ForeignKey(
                        name: "fk_players_fantasy_providers_provider_id",
                        column: x => x.provider_id,
                        principalTable: "fantasy_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "team_matchups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    team_id = table.Column<int>(type: "integer", nullable: false),
                    opponent_team_id = table.Column<int>(type: "integer", nullable: true),
                    week = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<decimal>(type: "numeric", nullable: false),
                    matchup_outcome_id = table.Column<int>(type: "integer", nullable: false),
                    matchup_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team_matchups", x => x.id);
                    table.ForeignKey(
                        name: "fk_team_matchups_matchup_outcomes_matchup_outcome_id",
                        column: x => x.matchup_outcome_id,
                        principalTable: "matchup_outcomes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_team_matchups_matchup_types_matchup_type_id",
                        column: x => x.matchup_type_id,
                        principalTable: "matchup_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_team_matchups_teams_opponent_team_id",
                        column: x => x.opponent_team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_team_matchups_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "team_season_stats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    team_id = table.Column<int>(type: "integer", nullable: false),
                    wins = table.Column<int>(type: "integer", nullable: false),
                    losses = table.Column<int>(type: "integer", nullable: false),
                    ties = table.Column<int>(type: "integer", nullable: false),
                    win_percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    points_against = table.Column<decimal>(type: "numeric", nullable: false),
                    points_for = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team_season_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_team_season_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "league_seasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    league_id = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_seasons", x => x.id);
                    table.ForeignKey(
                        name: "fk_league_seasons_leagues_league_id",
                        column: x => x.league_id,
                        principalTable: "leagues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "matchup_roster_spots",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    matchup_id = table.Column<int>(type: "integer", nullable: false),
                    player_id = table.Column<int>(type: "integer", nullable: false),
                    position_id = table.Column<int>(type: "integer", nullable: false),
                    points_scored = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matchup_roster_spots", x => x.id);
                    table.ForeignKey(
                        name: "fk_matchup_roster_spots_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_matchup_roster_spots_positions_position_id",
                        column: x => x.position_id,
                        principalTable: "positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_matchup_roster_spots_team_matchups_matchup_id",
                        column: x => x.matchup_id,
                        principalTable: "team_matchups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "league_season_members",
                columns: table => new
                {
                    league_season_id = table.Column<int>(type: "integer", nullable: false),
                    member_id = table.Column<int>(type: "integer", nullable: false),
                    is_league_creator = table.Column<bool>(type: "boolean", nullable: false),
                    is_league_manager = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_season_members", x => new { x.league_season_id, x.member_id });
                    table.ForeignKey(
                        name: "fk_league_season_members_fantasy_members_member_id",
                        column: x => x.member_id,
                        principalTable: "fantasy_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_league_season_members_league_seasons_league_season_id",
                        column: x => x.league_season_id,
                        principalTable: "league_seasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "league_season_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    league_season_id = table.Column<int>(type: "integer", nullable: false),
                    league_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_season_settings", x => x.id);
                    table.UniqueConstraint("ak_league_season_settings_league_season_id", x => x.league_season_id);
                    table.ForeignKey(
                        name: "fk_league_season_settings_league_seasons_league_season_id",
                        column: x => x.league_season_id,
                        principalTable: "league_seasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accumulated_stats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    matchup_roster_spot_id = table.Column<int>(type: "integer", nullable: false),
                    stat_id = table.Column<int>(type: "integer", nullable: false),
                    stat_value = table.Column<decimal>(type: "numeric", nullable: false),
                    points_scored = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accumulated_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_accumulated_stats_matchup_roster_spots_matchup_roster_spot_",
                        column: x => x.matchup_roster_spot_id,
                        principalTable: "matchup_roster_spots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_accumulated_stats_stats_stat_id",
                        column: x => x.stat_id,
                        principalTable: "stats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "league_season_member_teams",
                columns: table => new
                {
                    member_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<int>(type: "integer", nullable: false),
                    league_season_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_season_member_teams", x => new { x.member_id, x.team_id });
                    table.ForeignKey(
                        name: "fk_league_season_member_teams_league_season_members_league_sea",
                        columns: x => new { x.league_season_id, x.member_id },
                        principalTable: "league_season_members",
                        principalColumns: new[] { "league_season_id", "member_id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_league_season_member_teams_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "league_season_schedule_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    league_season_id = table.Column<int>(type: "integer", nullable: false),
                    matchup_count = table.Column<int>(type: "integer", nullable: false),
                    matchup_length = table.Column<int>(type: "integer", nullable: false),
                    playoff_matchup_length = table.Column<int>(type: "integer", nullable: false),
                    playoff_team_count = table.Column<int>(type: "integer", nullable: false),
                    variable_playoff_matchup_length = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_season_schedule_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_league_season_schedule_settings_league_season_settings_leag",
                        column: x => x.league_season_id,
                        principalTable: "league_season_settings",
                        principalColumn: "league_season_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "league_season_scoring_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    league_season_id = table.Column<int>(type: "integer", nullable: false),
                    home_team_bonus_points = table.Column<int>(type: "integer", nullable: false),
                    matchup_tie_rule = table.Column<string>(type: "text", nullable: false),
                    matchup_tie_rule_by = table.Column<int>(type: "integer", nullable: false),
                    player_rank_type = table.Column<string>(type: "text", nullable: false),
                    playoff_home_team_bonus_points = table.Column<int>(type: "integer", nullable: false),
                    playoff_matchup_tie_rule = table.Column<string>(type: "text", nullable: false),
                    playoff_matchup_tie_rule_by = table.Column<int>(type: "integer", nullable: false),
                    scoring_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_season_scoring_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_league_season_scoring_settings_league_season_settings_leagu",
                        column: x => x.league_season_id,
                        principalTable: "league_season_settings",
                        principalColumn: "league_season_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "league_season_scoring_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    league_season_id = table.Column<int>(type: "integer", nullable: false),
                    stat_id = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_season_scoring_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_league_season_scoring_items_league_season_scoring_settings_",
                        column: x => x.league_season_id,
                        principalTable: "league_season_scoring_settings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_league_season_scoring_items_stats_stat_id",
                        column: x => x.stat_id,
                        principalTable: "stats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "fantasy_providers",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "ESPN" });

            migrationBuilder.InsertData(
                table: "matchup_outcomes",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "Win" },
                    { 1, "Loss" },
                    { 2, "Tie" },
                    { 3, "Undecided" },
                    { 999, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "matchup_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "Regular season" },
                    { 1, "Losers bracket" },
                    { 2, "Winners consolation" },
                    { 3, "Winners bracket" },
                    { 999, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "QB" },
                    { 1, "TQB" },
                    { 2, "RB" },
                    { 3, "RBWR" },
                    { 4, "WR" },
                    { 5, "WRTE" },
                    { 6, "TE" },
                    { 7, "OP" },
                    { 8, "DT" },
                    { 9, "DE" },
                    { 10, "LB" },
                    { 11, "DL" },
                    { 12, "CB" },
                    { 13, "S" },
                    { 14, "DB" },
                    { 15, "DP" },
                    { 16, "DST" },
                    { 17, "K" },
                    { 18, "P" },
                    { 19, "HC" },
                    { 20, "BE" },
                    { 21, "IR" },
                    { 23, "RBWRTE" },
                    { 24, "ER" },
                    { 25, "Rookie" },
                    { 999, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "stats",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "Attempted passes" },
                    { 1, "Completed passes" },
                    { 2, "Incomplete passes" },
                    { 3, "Passing yards" },
                    { 4, "Passing touchdowns" },
                    { 5, "Passing yards (per 5)" },
                    { 6, "Passing yards (per 10)" },
                    { 7, "Passing yards (per 20)" },
                    { 8, "Passing yards (per 25)" },
                    { 9, "Passing yards (per 50)" },
                    { 10, "Passing yards (per 100)" },
                    { 11, "Pass completions (per 5)" },
                    { 12, "Pass completions (per 10)" },
                    { 13, "Pass incompletions (per 5)" },
                    { 14, "Pass incompletions (per 10)" },
                    { 15, "40+ yard passing TD bonus" },
                    { 16, "50+ yard passing TD bonus" },
                    { 17, "300–399 passing yard game" },
                    { 18, "400+ passing yard game" },
                    { 19, "Passing two-point conversion" },
                    { 20, "Interceptions thrown" },
                    { 21, "Completion percentage" },
                    { 22, "Passing yards per game" },
                    { 23, "Rushing attempts" },
                    { 24, "Rushing yards" },
                    { 25, "Rushing touchdowns" },
                    { 26, "Rushing two-point conversion" },
                    { 27, "Rushing yards (per 5)" },
                    { 28, "Rushing yards (per 10)" },
                    { 29, "Rushing yards (per 20)" },
                    { 30, "Rushing yards (per 25)" },
                    { 31, "Rushing yards (per 50)" },
                    { 32, "Rushing yards (per 100)" },
                    { 33, "Rushing attempts (per 5)" },
                    { 34, "Rushing attempts (per 10)" },
                    { 35, "40+ yard rushing TD bonus" },
                    { 36, "50+ yard rushing TD bonus" },
                    { 37, "100–199 rushing yard game" },
                    { 38, "200+ rushing yard game" },
                    { 39, "Rushing yards per attempt" },
                    { 40, "Rushing yards per game" },
                    { 41, "Receptions" },
                    { 42, "Receiving yards" },
                    { 43, "Receiving touchdowns" },
                    { 44, "Receiving two-point conversion" },
                    { 45, "40+ yard receiving TD bonus" },
                    { 46, "50+ yard receiving TD bonus" },
                    { 47, "Receiving yards (per 5)" },
                    { 48, "Receiving yards (per 10)" },
                    { 49, "Receiving yards (per 20)" },
                    { 50, "Receiving yards (per 25)" },
                    { 51, "Receiving yards (per 50)" },
                    { 52, "Receiving yards (per 100)" },
                    { 53, "Each reception" },
                    { 54, "Receptions (per 5)" },
                    { 55, "Receptions (per 10)" },
                    { 56, "100–199 receiving yard game" },
                    { 57, "200+ receiving yard game" },
                    { 58, "Receiving targets" },
                    { 59, "Yards after catch" },
                    { 60, "Yards per reception" },
                    { 61, "Receiving yards per game" },
                    { 62, "Total two-point conversions" },
                    { 63, "Fumble recovered for touchdown" },
                    { 64, "Times sacked" },
                    { 65, "Passing fumbles" },
                    { 66, "Rushing fumbles" },
                    { 67, "Receiving fumbles" },
                    { 68, "Total fumbles" },
                    { 69, "Passing fumbles lost" },
                    { 70, "Rushing fumbles lost" },
                    { 71, "Receiving fumbles lost" },
                    { 72, "Total fumbles lost" },
                    { 73, "Total turnovers" },
                    { 74, "50+ yard field goals made" },
                    { 75, "50+ yard field goals attempted" },
                    { 76, "50+ yard field goals missed" },
                    { 77, "40–49 yard field goals made" },
                    { 78, "40–49 yard field goals attempted" },
                    { 79, "40–49 yard field goals missed" },
                    { 80, "0–39 yard field goals made" },
                    { 81, "0–39 yard field goals attempted" },
                    { 82, "0–39 yard field goals missed" },
                    { 83, "Total field goals made" },
                    { 84, "Total field goals attempted" },
                    { 85, "Total field goals missed" },
                    { 86, "Extra points made" },
                    { 87, "Extra points attempted" },
                    { 88, "Extra points missed" },
                    { 89, "0 points allowed" },
                    { 90, "1–6 points allowed" },
                    { 91, "7–13 points allowed" },
                    { 92, "14–17 points allowed" },
                    { 93, "Blocked kick returned for TD" },
                    { 94, "Fumble or interception return TD" },
                    { 95, "Defensive interception" },
                    { 96, "Defensive fumble recovered" },
                    { 97, "Blocked kick" },
                    { 98, "Safety" },
                    { 99, "Sack" },
                    { 100, "Half sack" },
                    { 101, "Kickoff return TD" },
                    { 102, "Punt return TD" },
                    { 103, "Interception return TD" },
                    { 104, "Fumble return TD" },
                    { 105, "Total return TDs" },
                    { 106, "Fumbles forced" },
                    { 107, "Assisted tackles" },
                    { 108, "Solo tackles" },
                    { 109, "Total tackles" },
                    { 110, "Every 3 tackles" },
                    { 111, "Every 5 tackles" },
                    { 112, "Stuffs (tackles for loss)" },
                    { 113, "Passes defended" },
                    { 114, "Kickoff return yards" },
                    { 115, "Punt return yards" },
                    { 116, "Kickoff return yards (per 10)" },
                    { 117, "Kickoff return yards (per 25)" },
                    { 118, "Punt return yards (per 10)" },
                    { 119, "Punt return yards (per 25)" },
                    { 120, "Points allowed" },
                    { 121, "18–21 points allowed" },
                    { 122, "22–27 points allowed" },
                    { 123, "28–34 points allowed" },
                    { 124, "35–45 points allowed" },
                    { 125, "46+ points allowed" },
                    { 126, "Points allowed per game" },
                    { 127, "Yards allowed" },
                    { 128, "Under 100 yards allowed" },
                    { 129, "100–199 yards allowed" },
                    { 130, "200–299 yards allowed" },
                    { 131, "300–349 yards allowed" },
                    { 132, "350–399 yards allowed" },
                    { 133, "400–449 yards allowed" },
                    { 134, "450–499 yards allowed" },
                    { 135, "500–549 yards allowed" },
                    { 136, "550+ yards allowed" },
                    { 137, "Yards allowed per game" },
                    { 138, "Punts" },
                    { 139, "Punt yards" },
                    { 140, "Punts inside the 10" },
                    { 141, "Punts inside the 20" },
                    { 142, "Blocked punts" },
                    { 143, "Punts returned" },
                    { 144, "Punt return yards allowed" },
                    { 145, "Touchbacks" },
                    { 146, "Fair catches" },
                    { 147, "Punt average" },
                    { 148, "Punt average (44+ yards)" },
                    { 149, "Punt average (42–43.9 yards)" },
                    { 150, "Punt average (40–41.9 yards)" },
                    { 151, "Punt average (38–39.9 yards)" },
                    { 152, "Punt average (36–37.9 yards)" },
                    { 153, "Punt average (34–35.9 yards)" },
                    { 154, "Punt average (33.9 yards or less)" },
                    { 155, "Team win" },
                    { 156, "Team loss" },
                    { 157, "Team tie" },
                    { 158, "Points scored" },
                    { 159, "Points per game" },
                    { 160, "Margin of victory" },
                    { 161, "Win margin 25+" },
                    { 162, "Win margin 20–24" },
                    { 163, "Win margin 15–19" },
                    { 164, "Win margin 10–14" },
                    { 165, "Win margin 5–9" },
                    { 166, "Win margin 1–4" },
                    { 167, "Loss margin 1–4" },
                    { 168, "Loss margin 5–9" },
                    { 169, "Loss margin 10–14" },
                    { 170, "Loss margin 15–19" },
                    { 171, "Loss margin 20–24" },
                    { 172, "Loss margin 25+" },
                    { 173, "Margin of victory per game" },
                    { 174, "Winning percentage" },
                    { 175, "Passing TD bonus (0–9 yards)" },
                    { 176, "Passing TD bonus (10–19 yards)" },
                    { 177, "Passing TD bonus (20–29 yards)" },
                    { 178, "Passing TD bonus (30–39 yards)" },
                    { 179, "Rushing TD bonus (0–9 yards)" },
                    { 180, "Rushing TD bonus (10–19 yards)" },
                    { 181, "Rushing TD bonus (20–29 yards)" },
                    { 182, "Rushing TD bonus (30–39 yards)" },
                    { 183, "Receiving TD bonus (0–9 yards)" },
                    { 184, "Receiving TD bonus (10–19 yards)" },
                    { 185, "Receiving TD bonus (20–29 yards)" },
                    { 186, "Receiving TD bonus (30–39 yards)" },
                    { 187, "D/ST points allowed" },
                    { 188, "D/ST 0 points allowed" },
                    { 189, "D/ST 1–6 points allowed" },
                    { 190, "D/ST 7–13 points allowed" },
                    { 191, "D/ST 14–17 points allowed" },
                    { 192, "D/ST 18–21 points allowed" },
                    { 193, "D/ST 22–27 points allowed" },
                    { 194, "D/ST 28–34 points allowed" },
                    { 195, "D/ST 35–45 points allowed" },
                    { 196, "D/ST 46+ points allowed" },
                    { 197, "D/ST points allowed per game" },
                    { 198, "50–59 yard field goals made" },
                    { 199, "50–59 yard field goals attempted" },
                    { 200, "50–59 yard field goals missed" },
                    { 201, "60+ yard field goals made" },
                    { 202, "60+ yard field goals attempted" },
                    { 203, "60+ yard field goals missed" },
                    { 204, "Offensive two-point return" },
                    { 205, "Defensive two-point return" },
                    { 206, "Two-point return" },
                    { 207, "Offensive one-point safety" },
                    { 208, "Defensive one-point safety" },
                    { 209, "One-point safety" },
                    { 210, "Games played" },
                    { 211, "Passing first downs" },
                    { 212, "Rushing first downs" },
                    { 213, "Receiving first downs" },
                    { 214, "Field goal made yards" },
                    { 215, "Field goal missed yards" },
                    { 216, "Field goal attempt yards" },
                    { 217, "Field goal made yards (per 5)" },
                    { 218, "Field goal made yards (per 10)" },
                    { 219, "Field goal made yards (per 20)" },
                    { 220, "Field goal made yards (per 25)" },
                    { 221, "Field goal made yards (per 50)" },
                    { 222, "Field goal made yards (per 100)" },
                    { 223, "Field goal missed yards (per 5)" },
                    { 224, "Field goal missed yards (per 10)" },
                    { 225, "Field goal missed yards (per 20)" },
                    { 226, "Field goal missed yards (per 25)" },
                    { 227, "Field goal missed yards (per 50)" },
                    { 228, "Field goal missed yards (per 100)" },
                    { 229, "Field goal attempt yards (per 5)" },
                    { 230, "Field goal attempt yards (per 10)" },
                    { 231, "Field goal attempt yards (per 20)" },
                    { 232, "Field goal attempt yards (per 25)" },
                    { 233, "Field goal attempt yards (per 50)" },
                    { 234, "Field goal attempt yards (per 100)" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_accumulated_stats_matchup_roster_spot_id",
                table: "accumulated_stats",
                column: "matchup_roster_spot_id");

            migrationBuilder.CreateIndex(
                name: "ix_accumulated_stats_stat_id",
                table: "accumulated_stats",
                column: "stat_id");

            migrationBuilder.CreateIndex(
                name: "ix_fantasy_members_fantasy_provider_id_provider_member_id",
                table: "fantasy_members",
                columns: new[] { "fantasy_provider_id", "provider_member_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_league_season_member_teams_league_season_id_member_id",
                table: "league_season_member_teams",
                columns: new[] { "league_season_id", "member_id" });

            migrationBuilder.CreateIndex(
                name: "ix_league_season_member_teams_team_id",
                table: "league_season_member_teams",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_league_season_members_member_id",
                table: "league_season_members",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "ix_league_season_schedule_settings_league_season_id",
                table: "league_season_schedule_settings",
                column: "league_season_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_league_season_scoring_items_league_season_id",
                table: "league_season_scoring_items",
                column: "league_season_id");

            migrationBuilder.CreateIndex(
                name: "ix_league_season_scoring_items_stat_id",
                table: "league_season_scoring_items",
                column: "stat_id");

            migrationBuilder.CreateIndex(
                name: "ix_league_season_scoring_settings_league_season_id",
                table: "league_season_scoring_settings",
                column: "league_season_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_league_seasons_league_id",
                table: "league_seasons",
                column: "league_id");

            migrationBuilder.CreateIndex(
                name: "ix_leagues_fantasy_provider_id",
                table: "leagues",
                column: "fantasy_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_matchup_roster_spots_matchup_id",
                table: "matchup_roster_spots",
                column: "matchup_id");

            migrationBuilder.CreateIndex(
                name: "ix_matchup_roster_spots_player_id",
                table: "matchup_roster_spots",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_matchup_roster_spots_position_id",
                table: "matchup_roster_spots",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "ix_players_provider_id_provider_player_id",
                table: "players",
                columns: new[] { "provider_id", "provider_player_id" });

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_matchup_outcome_id",
                table: "team_matchups",
                column: "matchup_outcome_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_matchup_type_id",
                table: "team_matchups",
                column: "matchup_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_opponent_team_id",
                table: "team_matchups",
                column: "opponent_team_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_team_id",
                table: "team_matchups",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_season_stats_team_id",
                table: "team_season_stats",
                column: "team_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accumulated_stats");

            migrationBuilder.DropTable(
                name: "league_season_member_teams");

            migrationBuilder.DropTable(
                name: "league_season_schedule_settings");

            migrationBuilder.DropTable(
                name: "league_season_scoring_items");

            migrationBuilder.DropTable(
                name: "team_season_stats");

            migrationBuilder.DropTable(
                name: "matchup_roster_spots");

            migrationBuilder.DropTable(
                name: "league_season_members");

            migrationBuilder.DropTable(
                name: "league_season_scoring_settings");

            migrationBuilder.DropTable(
                name: "stats");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "team_matchups");

            migrationBuilder.DropTable(
                name: "fantasy_members");

            migrationBuilder.DropTable(
                name: "league_season_settings");

            migrationBuilder.DropTable(
                name: "matchup_outcomes");

            migrationBuilder.DropTable(
                name: "matchup_types");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "league_seasons");

            migrationBuilder.DropTable(
                name: "leagues");

            migrationBuilder.DropTable(
                name: "fantasy_providers");
        }
    }
}
