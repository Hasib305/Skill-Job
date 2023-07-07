using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobfinding.Migrations
{
    /// <inheritdoc />
    public partial class ApplyCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FindjobsId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ApplyCartId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyCartItems_Findjobs_FindjobsId",
                        column: x => x.FindjobsId,
                        principalTable: "Findjobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyCartItems_FindjobsId",
                table: "ApplyCartItems",
                column: "FindjobsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyCartItems");
        }
    }
}
