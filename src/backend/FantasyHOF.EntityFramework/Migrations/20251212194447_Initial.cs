using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fantasy_members",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provider_member_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    first_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    last_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fantasy_members", x => x.id);
                });

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
                    table.ForeignKey(
                        name: "fk_league_season_settings_league_seasons_league_season_id",
                        column: x => x.league_season_id,
                        principalTable: "league_seasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "team_matchups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    team_id = table.Column<int>(type: "integer", nullable: false),
                    week = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    opponent_id = table.Column<int>(type: "integer", nullable: false),
                    league_season_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team_matchups", x => x.id);
                    table.ForeignKey(
                        name: "fk_team_matchups_league_seasons_league_season_id",
                        column: x => x.league_season_id,
                        principalTable: "league_seasons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_team_matchups_teams_opponent_id",
                        column: x => x.opponent_id,
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
                    win_percentage = table.Column<double>(type: "double precision", nullable: false),
                    points_against = table.Column<float>(type: "real", nullable: false),
                    points_for = table.Column<float>(type: "real", nullable: false)
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
                name: "league_season_member_teams",
                columns: table => new
                {
                    league_season_id = table.Column<int>(type: "integer", nullable: false),
                    member_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_season_member_teams", x => new { x.league_season_id, x.member_id, x.team_id });
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
                        principalColumn: "id",
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
                    points_scored = table.Column<float>(type: "real", nullable: false)
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
                        name: "fk_matchup_roster_spots_team_matchups_matchup_id",
                        column: x => x.matchup_id,
                        principalTable: "team_matchups",
                        principalColumn: "id",
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
                    points = table.Column<float>(type: "real", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "accumulated_stats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    matchup_roster_spot_id = table.Column<int>(type: "integer", nullable: false),
                    stat_id = table.Column<int>(type: "integer", nullable: false),
                    stat_value = table.Column<float>(type: "real", nullable: false),
                    points_scored = table.Column<float>(type: "real", nullable: false)
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

            migrationBuilder.InsertData(
                table: "fantasy_providers",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "ESPN" });

            migrationBuilder.CreateIndex(
                name: "ix_accumulated_stats_matchup_roster_spot_id",
                table: "accumulated_stats",
                column: "matchup_roster_spot_id");

            migrationBuilder.CreateIndex(
                name: "ix_accumulated_stats_stat_id",
                table: "accumulated_stats",
                column: "stat_id");

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
                name: "ix_league_season_settings_league_season_id",
                table: "league_season_settings",
                column: "league_season_id",
                unique: true);

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
                name: "ix_players_provider_id",
                table: "players",
                column: "provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_league_season_id",
                table: "team_matchups",
                column: "league_season_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_opponent_id",
                table: "team_matchups",
                column: "opponent_id");

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
                name: "leagues");

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
                name: "team_matchups");

            migrationBuilder.DropTable(
                name: "fantasy_members");

            migrationBuilder.DropTable(
                name: "league_season_settings");

            migrationBuilder.DropTable(
                name: "fantasy_providers");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "league_seasons");
        }
    }
}
