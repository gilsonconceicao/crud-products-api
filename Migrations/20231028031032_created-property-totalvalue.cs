using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_products_api.Migrations
{
    /// <inheritdoc />
    public partial class createdpropertytotalvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalValue",
                table: "Products",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Products");
        }
    }
}
