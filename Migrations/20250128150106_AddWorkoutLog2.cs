using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutLog2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLog_MemberId",
                table: "WorkoutLog",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutLog_Member_MemberId",
                table: "WorkoutLog",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutLog_Member_MemberId",
                table: "WorkoutLog");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutLog_MemberId",
                table: "WorkoutLog");
        }
    }
}
