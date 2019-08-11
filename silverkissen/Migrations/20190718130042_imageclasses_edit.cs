using Microsoft.EntityFrameworkCore.Migrations;

namespace silverkissen.Migrations
{
    public partial class imageclasses_edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatImages_Cats_CatId",
                table: "CatImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CatLitterImages_CatLitters_CatLitterId",
                table: "CatLitterImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatLitterImages",
                table: "CatLitterImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatImages",
                table: "CatImages");

            migrationBuilder.RenameTable(
                name: "CatLitterImages",
                newName: "CatLitter_Image");

            migrationBuilder.RenameTable(
                name: "CatImages",
                newName: "Cat_Image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatLitter_Image",
                table: "CatLitter_Image",
                columns: new[] { "CatLitterId", "ImageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_Image",
                table: "Cat_Image",
                columns: new[] { "CatId", "ImageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Image_Cats_CatId",
                table: "Cat_Image",
                column: "CatId",
                principalTable: "Cats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatLitter_Image_CatLitters_CatLitterId",
                table: "CatLitter_Image",
                column: "CatLitterId",
                principalTable: "CatLitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Image_Cats_CatId",
                table: "Cat_Image");

            migrationBuilder.DropForeignKey(
                name: "FK_CatLitter_Image_CatLitters_CatLitterId",
                table: "CatLitter_Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatLitter_Image",
                table: "CatLitter_Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_Image",
                table: "Cat_Image");

            migrationBuilder.RenameTable(
                name: "CatLitter_Image",
                newName: "CatLitterImages");

            migrationBuilder.RenameTable(
                name: "Cat_Image",
                newName: "CatImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatLitterImages",
                table: "CatLitterImages",
                columns: new[] { "CatLitterId", "ImageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatImages",
                table: "CatImages",
                columns: new[] { "CatId", "ImageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CatImages_Cats_CatId",
                table: "CatImages",
                column: "CatId",
                principalTable: "Cats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatLitterImages_CatLitters_CatLitterId",
                table: "CatLitterImages",
                column: "CatLitterId",
                principalTable: "CatLitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
