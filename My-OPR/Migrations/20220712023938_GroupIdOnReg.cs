using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class GroupIdOnReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "RegisteredForms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KelompokId",
                table: "RegisteredForms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredForms_GroupId",
                table: "RegisteredForms",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_Groups_GroupId",
                table: "RegisteredForms",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_Groups_GroupId",
                table: "RegisteredForms");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredForms_GroupId",
                table: "RegisteredForms");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "RegisteredForms");

            migrationBuilder.DropColumn(
                name: "KelompokId",
                table: "RegisteredForms");
        }
    }
}
