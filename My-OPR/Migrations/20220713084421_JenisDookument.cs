using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class JenisDookument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "ListApps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JenisDocumentId",
                table: "KategoriDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JenisDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisDocument", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListApps_GroupId",
                table: "ListApps",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriDocuments_JenisDocumentId",
                table: "KategoriDocuments",
                column: "JenisDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_KategoriDocuments_JenisDocument_JenisDocumentId",
                table: "KategoriDocuments",
                column: "JenisDocumentId",
                principalTable: "JenisDocument",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListApps_Groups_GroupId",
                table: "ListApps",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KategoriDocuments_JenisDocument_JenisDocumentId",
                table: "KategoriDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ListApps_Groups_GroupId",
                table: "ListApps");

            migrationBuilder.DropTable(
                name: "JenisDocument");

            migrationBuilder.DropIndex(
                name: "IX_ListApps_GroupId",
                table: "ListApps");

            migrationBuilder.DropIndex(
                name: "IX_KategoriDocuments_JenisDocumentId",
                table: "KategoriDocuments");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ListApps");

            migrationBuilder.DropColumn(
                name: "JenisDocumentId",
                table: "KategoriDocuments");
        }
    }
}
