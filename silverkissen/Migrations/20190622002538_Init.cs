using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace silverkissen.Migrations
{
    public partial class Init : Migration
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
                    Status = table.Column<string>(nullable: true),
                    AmountOfKids = table.Column<int>(nullable: false),
                    SVERAK = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatLitters", x => x.Id);
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
                    SVERAK = table.Column<bool>(nullable: false),
                    Pedigree = table.Column<bool>(nullable: false),
                    Chipped = table.Column<bool>(nullable: false),
                    Vaccinated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
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
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatId = table.Column<int>(nullable: false),
                    CatLitterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatFamilies_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatFamilies_CatLitters_CatLitterId",
                        column: x => x.CatLitterId,
                        principalTable: "CatLitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatImages_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatLitterImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    CatLitterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatLitterImages", x => new { x.CatLitterId, x.ImageId });
                    table.UniqueConstraint("AK_CatLitterImages_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatLitterImages_CatLitters_CatLitterId",
                        column: x => x.CatLitterId,
                        principalTable: "CatLitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatLitterImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatFamilies_CatId",
                table: "CatFamilies",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_CatFamilies_CatLitterId",
                table: "CatFamilies",
                column: "CatLitterId");

            migrationBuilder.CreateIndex(
                name: "IX_CatImages_CatId",
                table: "CatImages",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_CatImages_ImageId",
                table: "CatImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CatLitterImages_ImageId",
                table: "CatLitterImages",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatFamilies");

            migrationBuilder.DropTable(
                name: "CatImages");

            migrationBuilder.DropTable(
                name: "CatLitterImages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "CatLitters");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
