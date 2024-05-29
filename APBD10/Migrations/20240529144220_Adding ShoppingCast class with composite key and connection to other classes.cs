using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD10.Migrations
{
    /// <inheritdoc />
    public partial class AddingShoppingCastclasswithcompositekeyandconnectiontootherclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PK_product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    width = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    height = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    depth = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PK_product);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    FK_account = table.Column<int>(type: "int", nullable: false),
                    FK_product = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => new { x.FK_account, x.FK_product });
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Accounts_FK_account",
                        column: x => x.FK_account,
                        principalTable: "Accounts",
                        principalColumn: "PK_account",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_FK_product",
                        column: x => x.FK_product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_FK_product",
                table: "ShoppingCarts",
                column: "FK_product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
