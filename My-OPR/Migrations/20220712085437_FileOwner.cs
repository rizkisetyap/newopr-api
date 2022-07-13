using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class FileOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KelompokId",
                table: "RegisteredForms");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "FileRegisteredIsos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FileRegisteredIsos_ServiceId",
                table: "FileRegisteredIsos",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileRegisteredIsos_Services_ServiceId",
                table: "FileRegisteredIsos",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileRegisteredIsos_Services_ServiceId",
                table: "FileRegisteredIsos");

            migrationBuilder.DropIndex(
                name: "IX_FileRegisteredIsos_ServiceId",
                table: "FileRegisteredIsos");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "FileRegisteredIsos");

            migrationBuilder.AddColumn<int>(
                name: "KelompokId",
                table: "RegisteredForms",
                type: "int",
                nullable: true);
        }
    }
}
