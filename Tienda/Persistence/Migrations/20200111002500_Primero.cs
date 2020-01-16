using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Persistence.Migrations
{
    public partial class Primero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categroria",
                columns: table => new
                {
                    NomCategoria = table.Column<string>(nullable: false),
                    Detalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categroria", x => x.NomCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSale = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSale);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProducto = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Detalle = table.Column<string>(nullable: true),
                    NomCategoria = table.Column<string>(nullable: true),
                    CategoriaNomCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categroria_CategoriaNomCategoria",
                        column: x => x.CategoriaNomCategoria,
                        principalTable: "Categroria",
                        principalColumn: "NomCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    IdCar = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    IdSale = table.Column<int>(nullable: false),
                    SaleIdSale = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Carritos_Sale_SaleIdSale",
                        column: x => x.SaleIdSale,
                        principalTable: "Sale",
                        principalColumn: "IdSale",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdCar",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoIdProducto = table.Column<int>(nullable: true),
                    IdCar = table.Column<int>(nullable: false),
                    CarritoIdCar = table.Column<int>(nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCar", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_ProdCar_Carritos_CarritoIdCar",
                        column: x => x.CarritoIdCar,
                        principalTable: "Carritos",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdCar_Producto_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_SaleIdSale",
                table: "Carritos",
                column: "SaleIdSale");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCar_CarritoIdCar",
                table: "ProdCar",
                column: "CarritoIdCar");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCar_ProductoIdProducto",
                table: "ProdCar",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaNomCategoria",
                table: "Producto",
                column: "CategoriaNomCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdCar");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Categroria");
        }
    }
}
