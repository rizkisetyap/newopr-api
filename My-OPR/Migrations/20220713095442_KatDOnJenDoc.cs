using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class KatDOnJenDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KategoriDocuments_JenisDocuments_JenisDocumentId",
                table: "KategoriDocuments");

            migrationBuilder.DropIndex(
                name: "IX_KategoriDocuments_JenisDocumentId",
                table: "KategoriDocuments");

            migrationBuilder.DropColumn(
                name: "JenisDocumentId",
                table: "KategoriDocuments");

            migrationBuilder.AddColumn<int>(
                name: "KategoriDokumenId",
                table: "JenisDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JenisDocuments_KategoriDokumenId",
                table: "JenisDocuments",
                column: "KategoriDokumenId");

            migrationBuilder.AddForeignKey(
                name: "FK_JenisDocuments_KategoriDocuments_KategoriDokumenId",
                table: "JenisDocuments",
                column: "KategoriDokumenId",
                principalTable: "KategoriDocuments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JenisDocuments_KategoriDocuments_KategoriDokumenId",
                table: "JenisDocuments");

            migrationBuilder.DropIndex(
                name: "IX_JenisDocuments_KategoriDokumenId",
                table: "JenisDocuments");

            migrationBuilder.DropColumn(
                name: "KategoriDokumenId",
                table: "JenisDocuments");

            migrationBuilder.AddColumn<int>(
                name: "JenisDocumentId",
                table: "KategoriDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KategoriDocuments_JenisDocumentId",
                table: "KategoriDocuments",
                column: "JenisDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_KategoriDocuments_JenisDocuments_JenisDocumentId",
                table: "KategoriDocuments",
                column: "JenisDocumentId",
                principalTable: "JenisDocuments",
                principalColumn: "Id");
        }
    }
}
