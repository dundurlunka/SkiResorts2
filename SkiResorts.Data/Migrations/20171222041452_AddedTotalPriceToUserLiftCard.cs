using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SkiResorts.Data.Migrations
{
    public partial class AddedTotalPriceToUserLiftCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentPerDay",
                table: "LiftCards");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "UserLiftCard",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "UserLiftCard");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentPerDay",
                table: "LiftCards",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
