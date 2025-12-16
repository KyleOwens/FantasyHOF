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
                name: "position",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_position", x => x.id);
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
                    logo_url = table.Column<string>(type: "text", nullable: false),
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
                    score = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team_matchups", x => x.id);
                    table.ForeignKey(
                        name: "fk_team_matchups_teams_opponent_team_id",
                        column: x => x.opponent_team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "fk_matchup_roster_spots_position_position_id",
                        column: x => x.position_id,
                        principalTable: "position",
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
                        onDelete: ReferentialAction.Restrict);
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
                table: "position",
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
                    { 25, "Rookie" }
                });

            migrationBuilder.InsertData(
                table: "stats",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "AttemptedPasses" },
                    { 1, "CompletedPasses" },
                    { 2, "IncompletePasses" },
                    { 3, "PassingYards" },
                    { 4, "PassingTouchdowns" },
                    { 5, "PassingYardsPer5" },
                    { 6, "PassingYardsPer10" },
                    { 7, "PassingYardsPer20" },
                    { 8, "PassingYardsPer25" },
                    { 9, "PassingYardsPer50" },
                    { 10, "PassingYardsPer100" },
                    { 11, "PassCompletionsPer5" },
                    { 12, "PassCompletionsPer10" },
                    { 13, "PassIncompletionsPer5" },
                    { 14, "PassIncompletionsPer10" },
                    { 15, "PassingTD40PlusBonus" },
                    { 16, "PassingTD50PlusBonus" },
                    { 17, "Passing300To399YardGame" },
                    { 18, "Passing400PlusYardGame" },
                    { 19, "PassingTwoPointConversion" },
                    { 20, "InterceptionsThrown" },
                    { 21, "CompletionPercentage" },
                    { 22, "PassingYardsPerGame" },
                    { 23, "RushingAttempts" },
                    { 24, "RushingYards" },
                    { 25, "RushingTouchdowns" },
                    { 26, "RushingTwoPointConversion" },
                    { 27, "RushingYardsPer5" },
                    { 28, "RushingYardsPer10" },
                    { 29, "RushingYardsPer20" },
                    { 30, "RushingYardsPer25" },
                    { 31, "RushingYardsPer50" },
                    { 32, "RushingYardsPer100" },
                    { 33, "RushingAttemptsPer5" },
                    { 34, "RushingAttemptsPer10" },
                    { 35, "RushingTD40PlusBonus" },
                    { 36, "RushingTD50PlusBonus" },
                    { 37, "Rushing100To199YardGame" },
                    { 38, "Rushing200PlusYardGame" },
                    { 39, "RushingYardsPerAttempt" },
                    { 40, "RushingYardsPerGame" },
                    { 41, "Receptions" },
                    { 42, "ReceivingYards" },
                    { 43, "ReceivingTouchdowns" },
                    { 44, "ReceivingTwoPointConversion" },
                    { 45, "ReceivingTD40PlusBonus" },
                    { 46, "ReceivingTD50PlusBonus" },
                    { 47, "ReceivingYardsPer5" },
                    { 48, "ReceivingYardsPer10" },
                    { 49, "ReceivingYardsPer20" },
                    { 50, "ReceivingYardsPer25" },
                    { 51, "ReceivingYardsPer50" },
                    { 52, "ReceivingYardsPer100" },
                    { 53, "EachReception" },
                    { 54, "ReceptionsPer5" },
                    { 55, "ReceptionsPer10" },
                    { 56, "Receiving100To199YardGame" },
                    { 57, "Receiving200PlusYardGame" },
                    { 58, "ReceivingTargets" },
                    { 59, "ReceivingYardsAfterCatch" },
                    { 60, "ReceivingYardsPerCatch" },
                    { 61, "ReceivingYardsPerGame" },
                    { 62, "TotalTwoPointConversions" },
                    { 63, "FumbleRecoveredForTD" },
                    { 64, "Sacked" },
                    { 65, "PassingFumbles" },
                    { 66, "RushingFumbles" },
                    { 67, "ReceivingFumbles" },
                    { 68, "TotalFumbles" },
                    { 69, "PassingFumblesLost" },
                    { 70, "RushingFumblesLost" },
                    { 71, "ReceivingFumblesLost" },
                    { 72, "TotalFumblesLost" },
                    { 73, "TotalTurnovers" },
                    { 74, "FieldGoalMade50Plus" },
                    { 75, "FieldGoalAttempted50Plus" },
                    { 76, "FieldGoalMissed50Plus" },
                    { 77, "FieldGoalMade40To49" },
                    { 78, "FieldGoalAttempted40To49" },
                    { 79, "FieldGoalMissed40To49" },
                    { 80, "FieldGoalMade0To39" },
                    { 81, "FieldGoalAttempted0To39" },
                    { 82, "FieldGoalMissed0To39" },
                    { 83, "TotalFieldGoalsMade" },
                    { 84, "TotalFieldGoalsAttempted" },
                    { 85, "TotalFieldGoalsMissed" },
                    { 86, "PATMade" },
                    { 87, "PATAttempted" },
                    { 88, "PATMissed" },
                    { 89, "PointsAllowed0" },
                    { 90, "PointsAllowed1To6" },
                    { 91, "PointsAllowed7To13" },
                    { 92, "PointsAllowed14To17" },
                    { 93, "BlockedKickReturnTD" },
                    { 94, "FumbleOrIntReturnTD" },
                    { 95, "DefenseInterception" },
                    { 96, "DefenseFumbleRecovered" },
                    { 97, "BlockedKick" },
                    { 98, "Safety" },
                    { 99, "Sack" },
                    { 100, "HalfSack" },
                    { 101, "KickoffReturnTD" },
                    { 102, "PuntReturnTD" },
                    { 103, "InterceptionReturnTD" },
                    { 104, "FumbleReturnTD" },
                    { 105, "TotalReturnTD" },
                    { 106, "FumbleForced" },
                    { 107, "AssistedTackles" },
                    { 108, "SoloTackles" },
                    { 109, "TotalTackles" },
                    { 110, "Every3Tackles" },
                    { 111, "Every5Tackles" },
                    { 112, "Stuffs" },
                    { 113, "PassesDefended" },
                    { 114, "KickoffReturnYards" },
                    { 115, "PuntReturnYards" },
                    { 116, "KickoffReturnYardsPer10" },
                    { 117, "KickoffReturnYardsPer25" },
                    { 118, "PuntReturnYardsPer10" },
                    { 119, "PuntReturnYardsPer25" },
                    { 120, "PointsAllowed" },
                    { 121, "PointsAllowed18To21" },
                    { 122, "PointsAllowed22To27" },
                    { 123, "PointsAllowed28To34" },
                    { 124, "PointsAllowed35To45" },
                    { 125, "PointsAllowed46Plus" },
                    { 126, "PointsAllowedPerGame" },
                    { 127, "YardsAllowed" },
                    { 128, "YardsAllowedLessThan100" },
                    { 129, "YardsAllowed100To199" },
                    { 130, "YardsAllowed200To299" },
                    { 131, "YardsAllowed300To349" },
                    { 132, "YardsAllowed350To399" },
                    { 133, "YardsAllowed400To449" },
                    { 134, "YardsAllowed450To499" },
                    { 135, "YardsAllowed500To549" },
                    { 136, "YardsAllowed550Plus" },
                    { 137, "YardsAllowedPerGame" },
                    { 138, "Punts" },
                    { 139, "PuntYards" },
                    { 140, "PuntsInside10" },
                    { 141, "PuntsInside20" },
                    { 142, "BlockedPunts" },
                    { 143, "PuntsReturned" },
                    { 144, "PuntingReturnYards" },
                    { 145, "Touchbacks" },
                    { 146, "FairCatches" },
                    { 147, "PuntAverage" },
                    { 148, "PuntAverage44Plus" },
                    { 149, "PuntAverage42To43_9" },
                    { 150, "PuntAverage40To41_9" },
                    { 151, "PuntAverage38To39_9" },
                    { 152, "PuntAverage36To37_9" },
                    { 153, "PuntAverage34To35_9" },
                    { 154, "PuntAverage33_9OrLess" },
                    { 155, "TeamWin" },
                    { 156, "TeamLoss" },
                    { 157, "TeamTie" },
                    { 158, "PointsScored" },
                    { 159, "PointsPerGame" },
                    { 160, "MarginOfVictory" },
                    { 161, "WinMargin25Plus" },
                    { 162, "WinMargin20To24" },
                    { 163, "WinMargin15To19" },
                    { 164, "WinMargin10To14" },
                    { 165, "WinMargin5To9" },
                    { 166, "WinMargin1To4" },
                    { 167, "LossMargin1To4" },
                    { 168, "LossMargin5To9" },
                    { 169, "LossMargin10To14" },
                    { 170, "LossMargin15To19" },
                    { 171, "LossMargin20To24" },
                    { 172, "LossMargin25Plus" },
                    { 173, "MarginOfVictoryPerGame" },
                    { 174, "WinningPercentage" },
                    { 175, "PassingTD0To9Bonus" },
                    { 176, "PassingTD10To19Bonus" },
                    { 177, "PassingTD20To29Bonus" },
                    { 178, "PassingTD30To39Bonus" },
                    { 179, "RushingTD0To9Bonus" },
                    { 180, "RushingTD10To19Bonus" },
                    { 181, "RushingTD20To29Bonus" },
                    { 182, "RushingTD30To39Bonus" },
                    { 183, "ReceivingTD0To9Bonus" },
                    { 184, "ReceivingTD10To19Bonus" },
                    { 185, "ReceivingTD20To29Bonus" },
                    { 186, "ReceivingTD30To39Bonus" },
                    { 187, "DSTPointsAllowed" },
                    { 188, "DSTPointsAllowed0" },
                    { 189, "DSTPointsAllowed1To6" },
                    { 190, "DSTPointsAllowed7To13" },
                    { 191, "DSTPointsAllowed14To17" },
                    { 192, "DSTPointsAllowed18To21" },
                    { 193, "DSTPointsAllowed22To27" },
                    { 194, "DSTPointsAllowed28To34" },
                    { 195, "DSTPointsAllowed35To45" },
                    { 196, "DSTPointsAllowed46Plus" },
                    { 197, "DSTPointsAllowedPerGame" },
                    { 198, "FieldGoalMade50To59" },
                    { 199, "FieldGoalAttempted50To59" },
                    { 200, "FieldGoalMissed50To59" },
                    { 201, "FieldGoalMade60Plus" },
                    { 202, "FieldGoalAttempted60Plus" },
                    { 203, "FieldGoalMissed60Plus" },
                    { 204, "OffensiveTwoPointReturn" },
                    { 205, "DefensiveTwoPointReturn" },
                    { 206, "TwoPointReturn" },
                    { 207, "OffensiveOnePointSafety" },
                    { 208, "DefensiveOnePointSafety" },
                    { 209, "OnePointSafety" },
                    { 210, "GamesPlayed" },
                    { 211, "PassingFirstDown" },
                    { 212, "RushingFirstDown" },
                    { 213, "ReceivingFirstDown" },
                    { 214, "FieldGoalMadeYards" },
                    { 215, "FieldGoalMissedYards" },
                    { 216, "FieldGoalAttemptYards" },
                    { 217, "FieldGoalMadeYardsPer5" },
                    { 218, "FieldGoalMadeYardsPer10" },
                    { 219, "FieldGoalMadeYardsPer20" },
                    { 220, "FieldGoalMadeYardsPer25" },
                    { 221, "FieldGoalMadeYardsPer50" },
                    { 222, "FieldGoalMadeYardsPer100" },
                    { 223, "FieldGoalMissedYardsPer5" },
                    { 224, "FieldGoalMissedYardsPer10" },
                    { 225, "FieldGoalMissedYardsPer20" },
                    { 226, "FieldGoalMissedYardsPer25" },
                    { 227, "FieldGoalMissedYardsPer50" },
                    { 228, "FieldGoalMissedYardsPer100" },
                    { 229, "FieldGoalAttemptYardsPer5" },
                    { 230, "FieldGoalAttemptYardsPer10" },
                    { 231, "FieldGoalAttemptYardsPer20" },
                    { 232, "FieldGoalAttemptYardsPer25" },
                    { 233, "FieldGoalAttemptYardsPer50" },
                    { 234, "FieldGoalAttemptYardsPer100" }
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
                name: "ix_fantasy_members_fantasy_provider_id",
                table: "fantasy_members",
                column: "fantasy_provider_id");

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
                name: "ix_players_provider_id",
                table: "players",
                column: "provider_id");

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
                name: "position");

            migrationBuilder.DropTable(
                name: "team_matchups");

            migrationBuilder.DropTable(
                name: "fantasy_members");

            migrationBuilder.DropTable(
                name: "league_season_settings");

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
