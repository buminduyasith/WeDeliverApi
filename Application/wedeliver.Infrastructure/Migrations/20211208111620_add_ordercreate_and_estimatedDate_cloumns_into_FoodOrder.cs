using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class add_ordercreate_and_estimatedDate_cloumns_into_FoodOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedDate",
                table: "FoodOrder",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCreatedDate",
                table: "FoodOrder",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedDate",
                table: "FoodOrder");

            migrationBuilder.DropColumn(
                name: "OrderCreatedDate",
                table: "FoodOrder");
        }
    }
}
