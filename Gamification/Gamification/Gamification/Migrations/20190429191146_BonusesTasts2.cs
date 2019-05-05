using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamification.Migrations
{
    public partial class BonusesTasts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonuses_AspNetUsers_ApplicationUserId",
                table: "Bonuses");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTasks_AspNetUsers_ApplicationUserId",
                table: "GameTasks");

            migrationBuilder.DropIndex(
                name: "IX_GameTasks_ApplicationUserId",
                table: "GameTasks");

            migrationBuilder.DropIndex(
                name: "IX_Bonuses_ApplicationUserId",
                table: "Bonuses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "GameTasks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Bonuses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "GameTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Bonuses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameTasks_ApplicationUserId",
                table: "GameTasks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_ApplicationUserId",
                table: "Bonuses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bonuses_AspNetUsers_ApplicationUserId",
                table: "Bonuses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTasks_AspNetUsers_ApplicationUserId",
                table: "GameTasks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
