using Microsoft.EntityFrameworkCore.Migrations;

namespace wedeliver.Infrastructure.Migrations
{
    public partial class AddCityCloumntoShippingDetailsAndAddInvoiceUrlColumnToFoodOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "City",
            //    table: "ShippingDetails",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceUrl",
                table: "FoodOrder",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.DropColumn(
            //    name: "City",
            //    table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceUrl",
                table: "FoodOrder");
        }
    }
}
