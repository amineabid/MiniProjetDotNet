using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterventionsApi.Migrations
{
    public partial class ChangeNullableReclamations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Reclamation_ReclamationId",
                table: "Intervention");

            migrationBuilder.AlterColumn<int>(
                name: "ReclamationId",
                table: "Intervention",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Reclamation_ReclamationId",
                table: "Intervention",
                column: "ReclamationId",
                principalTable: "Reclamation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Reclamation_ReclamationId",
                table: "Intervention");

            migrationBuilder.AlterColumn<int>(
                name: "ReclamationId",
                table: "Intervention",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Reclamation_ReclamationId",
                table: "Intervention",
                column: "ReclamationId",
                principalTable: "Reclamation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
