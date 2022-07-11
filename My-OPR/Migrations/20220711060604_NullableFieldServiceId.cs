using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class NullableFieldServiceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_KategoriDocuments_KategoriDocumentId",
                table: "RegisteredForms");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_Services_ServiceId",
                table: "RegisteredForms");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "RegisteredForms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriDocumentId",
                table: "RegisteredForms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_KategoriDocuments_KategoriDocumentId",
                table: "RegisteredForms",
                column: "KategoriDocumentId",
                principalTable: "KategoriDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_Services_ServiceId",
                table: "RegisteredForms",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_KategoriDocuments_KategoriDocumentId",
                table: "RegisteredForms");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForms_Services_ServiceId",
                table: "RegisteredForms");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "RegisteredForms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriDocumentId",
                table: "RegisteredForms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_KategoriDocuments_KategoriDocumentId",
                table: "RegisteredForms",
                column: "KategoriDocumentId",
                principalTable: "KategoriDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForms_Services_ServiceId",
                table: "RegisteredForms",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
