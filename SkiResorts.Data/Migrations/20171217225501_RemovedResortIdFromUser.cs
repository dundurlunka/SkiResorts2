using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkiResorts.Data.Migrations
{
    public partial class RemovedResortIdFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResortId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResortId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
