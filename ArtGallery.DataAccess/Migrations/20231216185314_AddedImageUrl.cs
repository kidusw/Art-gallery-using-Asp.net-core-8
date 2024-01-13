using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imageurl",
                table: "arts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Imageurl",
                value: "");

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Imageurl",
                value: "");

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Imageurl",
                value: "");

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Imageurl",
                value: "");

            migrationBuilder.UpdateData(
                table: "arts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Imageurl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imageurl",
                table: "arts");
        }
    }
}
