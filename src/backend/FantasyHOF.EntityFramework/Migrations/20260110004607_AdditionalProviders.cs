using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalProviders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "fantasy_providers",
                keyColumn: "id",
                keyValue: 1,
                column: "logo_url",
                value: "/provider-logos//espn-logo.webp");

            migrationBuilder.InsertData(
                table: "fantasy_providers",
                columns: new[] { "id", "logo_url", "name" },
                values: new object[,]
                {
                    { 2, "/provider-logos//sleeper-logo.webp", "Sleeper" },
                    { 3, "/provider-logos//yahoo-logo.webp", "Yahoo" },
                    { 4, "/provider-logos//NFL-logo.webp", "NFL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fantasy_providers",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "fantasy_providers",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "fantasy_providers",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "fantasy_providers",
                keyColumn: "id",
                keyValue: 1,
                column: "logo_url",
                value: "/espn-logo.png");
        }
    }
}
