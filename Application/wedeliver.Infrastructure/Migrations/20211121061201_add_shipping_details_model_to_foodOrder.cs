using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class add_shipping_details_model_to_foodOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingDetailsId",
                table: "FoodOrder",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrder_ShippingDetailsId",
                table: "FoodOrder",
                column: "ShippingDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_ShippingDetails_ShippingDetailsId",
                table: "FoodOrder",
                column: "ShippingDetailsId",
                principalTable: "ShippingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_ShippingDetails_ShippingDetailsId",
                table: "FoodOrder");

            migrationBuilder.DropIndex(
                name: "IX_FoodOrder_ShippingDetailsId",
                table: "FoodOrder");

            migrationBuilder.DropColumn(
                name: "ShippingDetailsId",
                table: "FoodOrder");
        }
    }
}
