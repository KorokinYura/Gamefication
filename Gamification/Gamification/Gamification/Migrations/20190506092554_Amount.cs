﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamification.Migrations
{
    public partial class Amount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Bonuses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Bonuses");
        }
    }
}
