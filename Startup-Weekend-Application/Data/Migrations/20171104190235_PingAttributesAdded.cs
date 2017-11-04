using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Startup_Weekend_Application.Data.Migrations
{
    public partial class PingAttributesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Ping",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayStyle",
                table: "Ping",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "Ping",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Ping");

            migrationBuilder.DropColumn(
                name: "PlayStyle",
                table: "Ping");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "Ping");
        }
    }
}
