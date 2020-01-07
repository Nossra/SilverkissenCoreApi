using Microsoft.EntityFrameworkCore.Migrations;

namespace silverkissen.Migrations
{
    public partial class displaypicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DisplayPicture",
                table: "Images",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayPicture",
                table: "Images");
        }
    }
}
