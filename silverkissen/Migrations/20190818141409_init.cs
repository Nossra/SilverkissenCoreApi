using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace silverkissen.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatLitters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ReadyDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Vaccinated = table.Column<bool>(nullable: false),
                    Chipped = table.Column<bool>(nullable: false),
                    Pedigree = table.Column<bool>(nullable: false),
                    PedigreeName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    AmountOfKids = table.Column<int>(nullable: false),
                    SVERAK = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatLitters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Filename = table.Column<string>(nullable: true),
                    Filetype = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatLitter_Image",
                columns: table => new
                {
                    CatLitterId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatLitter_Image", x => new { x.CatLitterId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_CatLitter_Image_CatLitters_CatLitterId",
                        column: x => x.CatLitterId,
                        principalTable: "CatLitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatLitter_Parent",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false),
                    CatLitterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatLitter_Parent", x => new { x.CatId, x.CatLitterId });
                    table.ForeignKey(
                        name: "FK_CatLitter_Parent_CatLitters_CatLitterId",
                        column: x => x.CatLitterId,
                        principalTable: "CatLitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Breed = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Parent = table.Column<bool>(nullable: false),
                    Pedigree = table.Column<bool>(nullable: false),
                    Chipped = table.Column<bool>(nullable: false),
                    Vaccinated = table.Column<bool>(nullable: false),
                    CatLitterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cats_CatLitters_CatLitterId",
                        column: x => x.CatLitterId,
                        principalTable: "CatLitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Image",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Image", x => new { x.CatId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_Cat_Image_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatLitter_Parent_CatLitterId",
                table: "CatLitter_Parent",
                column: "CatLitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Cats_CatLitterId",
                table: "Cats",
                column: "CatLitterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_Image");

            migrationBuilder.DropTable(
                name: "CatLitter_Image");

            migrationBuilder.DropTable(
                name: "CatLitter_Parent");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "CatLitters");
        }
    }
}
