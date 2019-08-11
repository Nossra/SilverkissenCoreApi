using Microsoft.EntityFrameworkCore.Migrations;

namespace silverkissen.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_CatLitters_CatLitterId",
                table: "Cats");

            migrationBuilder.RenameColumn(
                name: "CatLitterId",
                table: "Cats",
                newName: "CatLitterIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Cats_CatLitterId",
                table: "Cats",
                newName: "IX_Cats_CatLitterIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_CatLitters_CatLitterIdId",
                table: "Cats",
                column: "CatLitterIdId",
                principalTable: "CatLitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_CatLitters_CatLitterIdId",
                table: "Cats");

            migrationBuilder.RenameColumn(
                name: "CatLitterIdId",
                table: "Cats",
                newName: "CatLitterId");

            migrationBuilder.RenameIndex(
                name: "IX_Cats_CatLitterIdId",
                table: "Cats",
                newName: "IX_Cats_CatLitterId");

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
