using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Addedforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "arts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_arts_CategoryId",
                table: "arts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_arts_categories_CategoryId",
                table: "arts",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_arts_categories_CategoryId",
                table: "arts");

            migrationBuilder.DropIndex(
                name: "IX_arts_CategoryId",
                table: "arts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "arts");
        }
    }
}
