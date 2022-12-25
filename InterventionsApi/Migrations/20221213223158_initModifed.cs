using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterventionsApi.Migrations
{
    public partial class initModifed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reclamation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intervention_ReclamationId",
                table: "Intervention",
                column: "ReclamationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Reclamation_ReclamationId",
                table: "Intervention",
                column: "ReclamationId",
                principalTable: "Reclamation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Reclamation_ReclamationId",
                table: "Intervention");

            migrationBuilder.DropTable(
                name: "Reclamation");

            migrationBuilder.DropIndex(
                name: "IX_Intervention_ReclamationId",
                table: "Intervention");
        }
    }
}
