using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamification.Migrations
{
    public partial class NullableAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Bonuses",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Bonuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
