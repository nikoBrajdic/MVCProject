using Microsoft.EntityFrameworkCore.Migrations;

namespace TKDLocalWebClient.DAL.Migrations
{
    public partial class Addendum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PoomsaeTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PoomsaeTypes",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
