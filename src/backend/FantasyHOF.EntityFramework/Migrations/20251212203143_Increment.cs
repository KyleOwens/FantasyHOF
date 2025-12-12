using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Increment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_season_members_league_seasons_league_season_id",
                table: "league_season_members");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_league_seasons_league_season_id",
                table: "team_matchups");

            migrationBuilder.DropIndex(
                name: "ix_team_matchups_league_season_id",
                table: "team_matchups");

            migrationBuilder.DropColumn(
                name: "league_season_id",
                table: "team_matchups");

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
                name: "ix_league_seasons_league_id",
                table: "league_seasons",
                column: "league_id");

            migrationBuilder.AddForeignKey(
                name: "fk_league_seasons_leagues_league_id",
                table: "league_seasons",
                column: "league_id",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_seasons_leagues_league_id",
                table: "league_seasons");

            migrationBuilder.DropIndex(
                name: "ix_league_seasons_league_id",
                table: "league_seasons");

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "stats",
                keyColumn: "id",
                keyValue: 234);

            migrationBuilder.AddColumn<int>(
                name: "league_season_id",
                table: "team_matchups",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_league_season_id",
                table: "team_matchups",
                column: "league_season_id");

            migrationBuilder.AddForeignKey(
                name: "fk_league_season_members_league_seasons_league_season_id",
                table: "league_season_members",
                column: "league_season_id",
                principalTable: "league_seasons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_league_seasons_league_season_id",
                table: "team_matchups",
                column: "league_season_id",
                principalTable: "league_seasons",
                principalColumn: "id");
        }
    }
}
