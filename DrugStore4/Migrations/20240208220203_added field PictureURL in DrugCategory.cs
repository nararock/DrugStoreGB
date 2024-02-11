using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrugStore4.Migrations
{
    /// <inheritdoc />
    public partial class addedfieldPictureURLinDrugCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureURL",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureURL",
                table: "Category");
        }
    }
}
