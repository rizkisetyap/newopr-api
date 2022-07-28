using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class NamaColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nama",
                table: "Overtimes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nama",
                table: "Overtimes");
        }
    }
}
