using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtGallery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedArtModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "arts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "arts",
                columns: new[] { "Id", "Artist", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Kidus-Workneh", "A new form of art", "Art1" },
                    { 2, "Abenezer-Daniel", "A new form of art", "Art2" },
                    { 3, "Urael-Alemayehu", "A new form of art", "Art3" },
                    { 4, "Ayesha-Abduljelil", "A new form of art", "Art4" },
                    { 5, "Lucy", "A new form of art", "Art5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
