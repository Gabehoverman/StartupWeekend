using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Startup_Weekend_Application.Data.Migrations
{
    public partial class PingUsernameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ping");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Ping",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Ping");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ping",
                nullable: false,
                defaultValue: 0);
        }
    }
}
