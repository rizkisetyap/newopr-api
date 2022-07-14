using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class UpdateRegForms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JenisDokumenId",
                table: "RegisteredForms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredForms_JenisDokumenId",
                table: "RegisteredForms",
                column: "JenisDokumenId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_JenisDocuments_JenisDokumenId",
                table: "RegisteredForms",
                column: "JenisDokumenId",
                principalTable: "JenisDocuments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_JenisDocuments_JenisDokumenId",
                table: "RegisteredForms");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredForms_JenisDokumenId",
                table: "RegisteredForms");

            migrationBuilder.DropColumn(
                name: "JenisDokumenId",
                table: "RegisteredForms");
        }
    }
}
