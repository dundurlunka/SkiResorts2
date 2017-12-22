using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkiResorts.Data.Migrations
{
    public partial class AddedDatesToLiftCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LiftCardDate",
                table: "UserLiftCard",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "UserLiftCard",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "LiftCards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiftCardDate",
                table: "UserLiftCard");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "UserLiftCard");

            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "LiftCards");
        }
    }
}
