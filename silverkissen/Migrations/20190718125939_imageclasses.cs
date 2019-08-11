using Microsoft.EntityFrameworkCore.Migrations;

namespace silverkissen.Migrations
{
    public partial class imageclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Cats_CatId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CatId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "CatImages",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatImages", x => new { x.CatId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_CatImages_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatLitterImages",
                columns: table => new
                {
                    CatLitterId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatLitterImages", x => new { x.CatLitterId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_CatLitterImages_CatLitters_CatLitterId",
                        column: x => x.CatLitterId,
                        principalTable: "CatLitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatImages");

            migrationBuilder.DropTable(
                name: "CatLitterImages");

            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CatId",
                table: "Images",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Cats_CatId",
                table: "Images",
                column: "CatId",
                principalTable: "Cats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
