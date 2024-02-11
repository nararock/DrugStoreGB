using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrugStore4.Migrations
{
    /// <inheritdoc />
    public partial class RenameFieldsInAdTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Ads",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Ads",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CategoryId",
                table: "Ads",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_TypeId",
                table: "Ads",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Type_TypeId",
                table: "Ads",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Type_TypeId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_CategoryId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_TypeId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Ads",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Ads",
                newName: "Category");
        }
    }
}
