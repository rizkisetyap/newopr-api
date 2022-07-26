using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class UpdateISoCoreJenisDokId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JenisDokumenId",
                table: "ISOCores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JenisDokumenId",
                table: "ISOCores",
                type: "int",
                nullable: true);
        }
    }
}
