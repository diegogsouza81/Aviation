using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationApp.Migrations
{
    public partial class Addcodecolumnairplane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Airplanes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Airplanes");
        }
    }
}
