using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class createPharmacyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineOrders_Pharmacy_PharmacyID",
                table: "MedicineOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_Locations_LocationId1",
                table: "Pharmacy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Pharmacy",
                newName: "Pharmacies");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacy_LocationId1",
                table: "Pharmacies",
                newName: "IX_Pharmacies_LocationId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineOrders_Pharmacies_PharmacyID",
                table: "MedicineOrders",
                column: "PharmacyID",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Locations_LocationId1",
                table: "Pharmacies",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineOrders_Pharmacies_PharmacyID",
                table: "MedicineOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Locations_LocationId1",
                table: "Pharmacies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                newName: "Pharmacy");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_LocationId1",
                table: "Pharmacy",
                newName: "IX_Pharmacy_LocationId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineOrders_Pharmacy_PharmacyID",
                table: "MedicineOrders",
                column: "PharmacyID",
                principalTable: "Pharmacy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_Locations_LocationId1",
                table: "Pharmacy",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
