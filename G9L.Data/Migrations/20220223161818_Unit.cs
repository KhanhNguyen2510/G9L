using Microsoft.EntityFrameworkCore.Migrations;

namespace G9L.Data.Migrations
{
    public partial class Unit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsUnit",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UnitProduct",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    NumberInBarrel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitProduct", x => new { x.ProductID, x.NumberInBarrel });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitProduct");

            migrationBuilder.DropColumn(
                name: "IsUnit",
                table: "Product");
        }
    }
}
