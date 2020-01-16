using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Persistence.Migrations
{
    public partial class Segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdCar",
                table: "ProdCar");

            migrationBuilder.DropColumn(
                name: "NomCategoria",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "ProdCar");

            migrationBuilder.DropColumn(
                name: "IdCar",
                table: "ProdCar");

            migrationBuilder.DropColumn(
                name: "IdSale",
                table: "Carritos");

            migrationBuilder.AddColumn<int>(
                name: "IdProdCar",
                table: "ProdCar",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdCar",
                table: "ProdCar",
                column: "IdProdCar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdCar",
                table: "ProdCar");

            migrationBuilder.DropColumn(
                name: "IdProdCar",
                table: "ProdCar");

            migrationBuilder.AddColumn<string>(
                name: "NomCategoria",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "ProdCar",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdCar",
                table: "ProdCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSale",
                table: "Carritos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdCar",
                table: "ProdCar",
                column: "IdProducto");
        }
    }
}
