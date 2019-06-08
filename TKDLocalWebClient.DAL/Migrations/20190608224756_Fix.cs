using Microsoft.EntityFrameworkCore.Migrations;

namespace TKDLocalWebClient.DAL.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoomsaeType",
                table: "Poomsaes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PoomsaeType",
                table: "Poomsaes",
                nullable: true);
        }
    }
}
