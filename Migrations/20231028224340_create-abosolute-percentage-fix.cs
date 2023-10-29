using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud_products_api.Migrations
{
    /// <inheritdoc />
    public partial class createabosolutepercentagefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "typeOfCalculation",
                table: "Products",
                newName: "TypeOfCalculation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfCalculation",
                table: "Products",
                newName: "typeOfCalculation");
        }
    }
}
