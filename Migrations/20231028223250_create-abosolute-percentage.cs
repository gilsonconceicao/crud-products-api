using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_products_api.Migrations
{
    /// <inheritdoc />
    public partial class createabosolutepercentage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "typeOfCalculation",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "typeOfCalculation",
                table: "Products");
        }
    }
}
