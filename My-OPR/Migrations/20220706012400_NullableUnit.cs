using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class NullableUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_Units_SubLayananId",
                table: "RegisteredForms");

            migrationBuilder.AlterColumn<int>(
                name: "SubLayananId",
                table: "RegisteredForms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_Units_SubLayananId",
                table: "RegisteredForms",
                column: "SubLayananId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_Units_SubLayananId",
                table: "RegisteredForms");

            migrationBuilder.AlterColumn<int>(
                name: "SubLayananId",
                table: "RegisteredForms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_Units_SubLayananId",
                table: "RegisteredForms",
                column: "SubLayananId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
