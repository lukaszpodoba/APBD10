using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD10.Migrations
{
    /// <inheritdoc />
    public partial class AddingvaluestoCategoryTableGetandPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "name" },
                values: new object[] { 1, "Category 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 1);
        }
    }
}
