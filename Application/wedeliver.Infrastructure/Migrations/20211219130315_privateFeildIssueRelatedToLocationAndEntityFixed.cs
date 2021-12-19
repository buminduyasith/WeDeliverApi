using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class privateFeildIssueRelatedToLocationAndEntityFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Locations_LocationId1",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Locations_LocationId1",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Locations_LocationId1",
                table: "Riders");

            migrationBuilder.RenameColumn(
                name: "LocationId1",
                table: "Riders",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Riders_LocationId1",
                table: "Riders",
                newName: "IX_Riders_LocationId");

            migrationBuilder.RenameColumn(
                name: "LocationId1",
                table: "Restaurants",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_LocationId1",
                table: "Restaurants",
                newName: "IX_Restaurants_LocationId");

            migrationBuilder.RenameColumn(
                name: "LocationId1",
                table: "Pharmacies",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_LocationId1",
                table: "Pharmacies",
                newName: "IX_Pharmacies_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Locations_LocationId",
                table: "Pharmacies",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Locations_LocationId",
                table: "Restaurants",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Locations_LocationId",
                table: "Riders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Locations_LocationId",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Locations_LocationId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Locations_LocationId",
                table: "Riders");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Riders",
                newName: "LocationId1");

            migrationBuilder.RenameIndex(
                name: "IX_Riders_LocationId",
                table: "Riders",
                newName: "IX_Riders_LocationId1");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Restaurants",
                newName: "LocationId1");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_LocationId",
                table: "Restaurants",
                newName: "IX_Restaurants_LocationId1");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Pharmacies",
                newName: "LocationId1");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_LocationId",
                table: "Pharmacies",
                newName: "IX_Pharmacies_LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Locations_LocationId1",
                table: "Pharmacies",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Locations_LocationId1",
                table: "Restaurants",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Locations_LocationId1",
                table: "Riders",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
