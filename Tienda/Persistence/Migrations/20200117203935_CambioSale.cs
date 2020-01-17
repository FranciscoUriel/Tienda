using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Persistence.Migrations
{
    public partial class CambioSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Sale_SaleIdSale",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_SaleIdSale",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "ProdCar");

            migrationBuilder.DropColumn(
                name: "SaleIdSale",
                table: "Carritos");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Sale",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "carritoIdCar",
                table: "Sale",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_carritoIdCar",
                table: "Sale",
                column: "carritoIdCar");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Carritos_carritoIdCar",
                table: "Sale",
                column: "carritoIdCar",
                principalTable: "Carritos",
                principalColumn: "IdCar",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Carritos_carritoIdCar",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_carritoIdCar",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "carritoIdCar",
                table: "Sale");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "ProdCar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SaleIdSale",
                table: "Carritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_SaleIdSale",
                table: "Carritos",
                column: "SaleIdSale");

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Sale_SaleIdSale",
                table: "Carritos",
                column: "SaleIdSale",
                principalTable: "Sale",
                principalColumn: "IdSale",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
