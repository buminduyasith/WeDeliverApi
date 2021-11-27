using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class update_storeopen_and_restaurant_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreOpenTimes_Restaurants_RestaurantId",
                table: "StoreOpenTimes");

            migrationBuilder.DropIndex(
                name: "IX_StoreOpenTimes_RestaurantId",
                table: "StoreOpenTimes");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "StoreOpenTimes");

            migrationBuilder.AddColumn<int>(
                name: "StoreOpenTimesId1",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_StoreOpenTimesId1",
                table: "Restaurants",
                column: "StoreOpenTimesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_StoreOpenTimes_StoreOpenTimesId1",
                table: "Restaurants",
                column: "StoreOpenTimesId1",
                principalTable: "StoreOpenTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_StoreOpenTimes_StoreOpenTimesId1",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_StoreOpenTimesId1",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "StoreOpenTimesId1",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "StoreOpenTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StoreOpenTimes_RestaurantId",
                table: "StoreOpenTimes",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreOpenTimes_Restaurants_RestaurantId",
                table: "StoreOpenTimes",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
