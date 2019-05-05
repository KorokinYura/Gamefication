using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamification.Migrations
{
    public partial class BonusesTasts1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersBonuses",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    BonusId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBonuses", x => new { x.ApplicationUserId, x.BonusId });
                });

            migrationBuilder.CreateTable(
                name: "UsersGameTasks",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    GameTaskId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGameTasks", x => new { x.ApplicationUserId, x.GameTaskId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersBonuses");

            migrationBuilder.DropTable(
                name: "UsersGameTasks");
        }
    }
}
