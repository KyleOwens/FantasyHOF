using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class PositionDisplayNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 0,
                column: "name",
                value: "Quarterback");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Team quarterback");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Running back");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Running back or wide receiver");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Wide receiver");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Wide receiver or tight end");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Tight end");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Offensive player");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Defensive tackle");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Defensive end");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 10,
                column: "name",
                value: "Linebacker");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 11,
                column: "name",
                value: "Defensive line");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 12,
                column: "name",
                value: "Cornerback");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 13,
                column: "name",
                value: "Safety");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 14,
                column: "name",
                value: "Defensive back");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 15,
                column: "name",
                value: "Defensive player");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 16,
                column: "name",
                value: "Defense & special teams");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 17,
                column: "name",
                value: "Kicker");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 18,
                column: "name",
                value: "Punter");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 19,
                column: "name",
                value: "Head coach");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 20,
                column: "name",
                value: "Bench");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 21,
                column: "name",
                value: "Injured reserve");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 23,
                column: "name",
                value: "Flex");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 24,
                column: "name",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 0,
                column: "name",
                value: "QB");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "TQB");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "RB");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "RBWR");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "WR");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "WRTE");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "TE");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "OP");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "DT");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "DE");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 10,
                column: "name",
                value: "LB");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 11,
                column: "name",
                value: "DL");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 12,
                column: "name",
                value: "CB");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 13,
                column: "name",
                value: "S");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 14,
                column: "name",
                value: "DB");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 15,
                column: "name",
                value: "DP");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 16,
                column: "name",
                value: "DST");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 17,
                column: "name",
                value: "K");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 18,
                column: "name",
                value: "P");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 19,
                column: "name",
                value: "HC");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 20,
                column: "name",
                value: "BE");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 21,
                column: "name",
                value: "IR");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 23,
                column: "name",
                value: "RBWRTE");

            migrationBuilder.UpdateData(
                table: "positions",
                keyColumn: "id",
                keyValue: 24,
                column: "name",
                value: "ER");
        }
    }
}
