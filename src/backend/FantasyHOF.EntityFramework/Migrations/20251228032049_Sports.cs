using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Sports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sports", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "sports",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Football" });

            migrationBuilder.CreateIndex(
                name: "ix_leagues_sport_id",
                table: "leagues",
                column: "sport_id");

            migrationBuilder.AddForeignKey(
                name: "fk_leagues_sports_sport_id",
                table: "leagues",
                column: "sport_id",
                principalTable: "sports",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leagues_sports_sport_id",
                table: "leagues");

            migrationBuilder.DropTable(
                name: "sports");

            migrationBuilder.DropIndex(
                name: "ix_leagues_sport_id",
                table: "leagues");
        }
    }
}
