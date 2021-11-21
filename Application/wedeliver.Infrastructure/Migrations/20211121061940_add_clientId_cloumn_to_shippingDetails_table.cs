using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class add_clientId_cloumn_to_shippingDetails_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ShippingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDetails_ClientId",
                table: "ShippingDetails",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetails_Clients_ClientId",
                table: "ShippingDetails",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetails_Clients_ClientId",
                table: "ShippingDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShippingDetails_ClientId",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ShippingDetails");
        }
    }
}
