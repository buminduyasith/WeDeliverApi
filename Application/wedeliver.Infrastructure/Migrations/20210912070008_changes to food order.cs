using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class changestofoodorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_Riders_RiderId",
                table: "FoodOrder");

            migrationBuilder.DropIndex(
                name: "IX_FoodOrder_RiderId",
                table: "FoodOrder");

            migrationBuilder.DropColumn(
                name: "RiderId",
                table: "FoodOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RiderId",
                table: "FoodOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrder_RiderId",
                table: "FoodOrder",
                column: "RiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_Riders_RiderId",
                table: "FoodOrder",
                column: "RiderId",
                principalTable: "Riders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
