using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobfinding.Migrations
{
    /// <inheritdoc />
    public partial class Apply_and_ApplyItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Apply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apply", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applyitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false),
                    FindjobId = table.Column<int>(type: "int", nullable: false),
                    ApplyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applyitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applyitems_Apply_ApplyId",
                        column: x => x.ApplyId,
                        principalTable: "Apply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applyitems_Findjobs_FindjobId",
                        column: x => x.FindjobId,
                        principalTable: "Findjobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applyitems_ApplyId",
                table: "Applyitems",
                column: "ApplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applyitems_FindjobId",
                table: "Applyitems",
                column: "FindjobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applyitems");

            migrationBuilder.DropTable(
                name: "Apply");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
