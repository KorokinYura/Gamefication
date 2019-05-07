using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamification.Migrations
{
    public partial class IdIntForBonusesAndTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GameTaskId",
                table: "UsersGameTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BonusId",
                table: "UsersBonuses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GameTaskId",
                table: "UsersGameTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BonusId",
                table: "UsersBonuses",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
