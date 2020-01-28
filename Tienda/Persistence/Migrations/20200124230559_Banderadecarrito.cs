using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Persistence.Migrations
{
    public partial class Banderadecarrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vendido",
                table: "Carritos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendido",
                table: "Carritos");
        }
    }
}
