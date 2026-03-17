using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetPro.Blog.Migrations
{
    /// <inheritdoc />
    public partial class AddPermalink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Permalink",
                table: "Posts",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permalink",
                table: "Categories",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permalink",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Permalink",
                table: "Categories");
        }
    }
}
