using Microsoft.EntityFrameworkCore.Migrations;

namespace silverkissen.Migrations
{
    public partial class teasdasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_CatLitters_CatLitterId",
                table: "Cats");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_CatLitters_CatLitterId",
                table: "Cats",
                column: "CatLitterId",
                principalTable: "CatLitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_CatLitters_CatLitterId",
                table: "Cats");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_CatLitters_CatLitterId",
                table: "Cats",
                column: "CatLitterId",
                principalTable: "CatLitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
