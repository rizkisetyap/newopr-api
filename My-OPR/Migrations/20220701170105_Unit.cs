using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class Unit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_SubLayanan_SubLayananId",
                table: "RegisteredForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_SubLayanan_SubLayananId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubLayanan",
                table: "SubLayanan");

            migrationBuilder.RenameTable(
                name: "SubLayanan",
                newName: "Units");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_Units_SubLayananId",
                table: "RegisteredForms",
                column: "SubLayananId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Units_SubLayananId",
                table: "Services",
                column: "SubLayananId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_Units_SubLayananId",
                table: "RegisteredForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Units_SubLayananId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "SubLayanan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubLayanan",
                table: "SubLayanan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_SubLayanan_SubLayananId",
                table: "RegisteredForms",
                column: "SubLayananId",
                principalTable: "SubLayanan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_SubLayanan_SubLayananId",
                table: "Services",
                column: "SubLayananId",
                principalTable: "SubLayanan",
                principalColumn: "Id");
        }
    }
}
