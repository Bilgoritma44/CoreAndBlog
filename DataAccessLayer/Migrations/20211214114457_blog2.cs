using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class blog2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogScore",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "BlogScore",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogScore",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "BlogScore",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
