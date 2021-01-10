using Microsoft.EntityFrameworkCore.Migrations;

namespace Georgescu_Diana_Proiect.Migrations
{
    public partial class ClothCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeID",
                table: "Cloth",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClothCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClothCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothCategory_Cloth_ClothID",
                        column: x => x.ClothID,
                        principalTable: "Cloth",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_SizeID",
                table: "Cloth",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothCategory_CategoryID",
                table: "ClothCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothCategory_ClothID",
                table: "ClothCategory",
                column: "ClothID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_Size_SizeID",
                table: "Cloth",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_Size_SizeID",
                table: "Cloth");

            migrationBuilder.DropTable(
                name: "ClothCategory");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_SizeID",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "Cloth");
        }
    }
}
