using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkiResorts.Data.Migrations
{
    public partial class NeededMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLiftCard",
                table: "UserLiftCard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLiftCard",
                table: "UserLiftCard",
                columns: new[] { "UserId", "LiftCardId", "LiftCardDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLiftCard",
                table: "UserLiftCard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLiftCard",
                table: "UserLiftCard",
                columns: new[] { "UserId", "LiftCardId" });
        }
    }
}
