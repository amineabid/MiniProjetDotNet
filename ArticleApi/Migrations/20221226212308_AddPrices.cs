using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleApi.Migrations
{
    public partial class AddPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Piece",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Piece");
        }
    }
}
