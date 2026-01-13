using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNFLLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "fantasy_providers",
                keyColumn: "id",
                keyValue: 4,
                column: "logo_url",
                value: "/provider-logos//nfl-logo.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "fantasy_providers",
                keyColumn: "id",
                keyValue: 4,
                column: "logo_url",
                value: "/provider-logos//NFL-logo.webp");
        }
    }
}
