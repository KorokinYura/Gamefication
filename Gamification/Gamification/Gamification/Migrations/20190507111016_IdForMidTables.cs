using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamification.Migrations
{
    public partial class IdForMidTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersGameTasks",
                table: "UsersGameTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersBonuses",
                table: "UsersBonuses");

            migrationBuilder.AlterColumn<string>(
                name: "GameTaskId",
                table: "UsersGameTasks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UsersGameTasks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersGameTasks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "BonusId",
                table: "UsersBonuses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UsersBonuses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersBonuses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersGameTasks",
                table: "UsersGameTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersBonuses",
                table: "UsersBonuses",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersGameTasks",
                table: "UsersGameTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersBonuses",
                table: "UsersBonuses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersGameTasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersBonuses");

            migrationBuilder.AlterColumn<string>(
                name: "GameTaskId",
                table: "UsersGameTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UsersGameTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BonusId",
                table: "UsersBonuses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UsersBonuses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersGameTasks",
                table: "UsersGameTasks",
                columns: new[] { "ApplicationUserId", "GameTaskId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersBonuses",
                table: "UsersBonuses",
                columns: new[] { "ApplicationUserId", "BonusId" });
        }
    }
}
