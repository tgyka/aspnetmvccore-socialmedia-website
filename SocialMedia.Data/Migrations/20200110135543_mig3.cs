using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMedia.Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dislike",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dislike",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Comment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Comment");
        }
    }
}
