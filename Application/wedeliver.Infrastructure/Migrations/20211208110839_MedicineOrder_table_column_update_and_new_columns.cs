using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class MedicineOrder_table_column_update_and_new_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineOrders_Pharmacy_PharmacyID",
                table: "MedicineOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineOrders_Riders_RiderId",
                table: "MedicineOrders");

            migrationBuilder.RenameColumn(
                name: "MedsDiscription",
                table: "MedicineOrders",
                newName: "OrderNo");

            migrationBuilder.AlterColumn<int>(
                name: "RiderId",
                table: "MedicineOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "MedicineOrders",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyID",
                table: "MedicineOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "MedicineOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillURl",
                table: "MedicineOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedDelivery",
                table: "MedicineOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MedsItemIntext",
                table: "MedicineOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "MedicineOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ShippingDetailsId",
                table: "MedicineOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicineOrders_ShippingDetailsId",
                table: "MedicineOrders",
                column: "ShippingDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineOrders_Pharmacy_PharmacyID",
                table: "MedicineOrders",
                column: "PharmacyID",
                principalTable: "Pharmacy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineOrders_Riders_RiderId",
                table: "MedicineOrders",
                column: "RiderId",
                principalTable: "Riders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineOrders_ShippingDetails_ShippingDetailsId",
                table: "MedicineOrders",
                column: "ShippingDetailsId",
                principalTable: "ShippingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineOrders_Pharmacy_PharmacyID",
                table: "MedicineOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineOrders_Riders_RiderId",
                table: "MedicineOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineOrders_ShippingDetails_ShippingDetailsId",
                table: "MedicineOrders");

            migrationBuilder.DropIndex(
                name: "IX_MedicineOrders_ShippingDetailsId",
                table: "MedicineOrders");

            migrationBuilder.DropColumn(
                name: "EstimatedDelivery",
                table: "MedicineOrders");

            migrationBuilder.DropColumn(
                name: "MedsItemIntext",
                table: "MedicineOrders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "MedicineOrders");

            migrationBuilder.DropColumn(
                name: "ShippingDetailsId",
                table: "MedicineOrders");

            migrationBuilder.RenameColumn(
                name: "OrderNo",
                table: "MedicineOrders",
                newName: "MedsDiscription");

            migrationBuilder.AlterColumn<int>(
                name: "RiderId",
                table: "MedicineOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "MedicineOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyID",
                table: "MedicineOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "MedicineOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BillURl",
                table: "MedicineOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineOrders_Pharmacy_PharmacyID",
                table: "MedicineOrders",
                column: "PharmacyID",
                principalTable: "Pharmacy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineOrders_Riders_RiderId",
                table: "MedicineOrders",
                column: "RiderId",
                principalTable: "Riders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
