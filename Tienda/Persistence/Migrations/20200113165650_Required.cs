using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Persistence.Migrations
{
    public partial class Required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Sale_SaleIdSale",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categroria_CategoriaNomCategoria",
                table: "Producto");

            migrationBuilder.AlterColumn<string>(
                name: "NomProducto",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Detalle",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNomCategoria",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaleIdSale",
                table: "Carritos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Sale_SaleIdSale",
                table: "Carritos",
                column: "SaleIdSale",
                principalTable: "Sale",
                principalColumn: "IdSale",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categroria_CategoriaNomCategoria",
                table: "Producto",
                column: "CategoriaNomCategoria",
                principalTable: "Categroria",
                principalColumn: "NomCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Sale_SaleIdSale",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categroria_CategoriaNomCategoria",
                table: "Producto");

            migrationBuilder.AlterColumn<string>(
                name: "NomProducto",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Detalle",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNomCategoria",
                table: "Producto",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "SaleIdSale",
                table: "Carritos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Sale_SaleIdSale",
                table: "Carritos",
                column: "SaleIdSale",
                principalTable: "Sale",
                principalColumn: "IdSale",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categroria_CategoriaNomCategoria",
                table: "Producto",
                column: "CategoriaNomCategoria",
                principalTable: "Categroria",
                principalColumn: "NomCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
