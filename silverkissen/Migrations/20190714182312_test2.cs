using Microsoft.EntityFrameworkCore.Migrations;

namespace silverkissen.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_CatLitters_CatLitterId",
                table: "Cats");

            migrationBuilder.AlterColumn<int>(
                name: "CatLitterId",
                table: "Cats",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_CatLitters_CatLitterId",
                table: "Cats",
                column: "CatLitterId",
                principalTable: "CatLitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_CatLitters_CatLitterId",
                table: "Cats");

            migrationBuilder.AlterColumn<int>(
                name: "CatLitterId",
                table: "Cats",
                nullable: true,
                oldClrType: typeof(int));

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
