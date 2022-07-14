using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class HistoryIso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ISOCores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    JenisDokumenId = table.Column<int>(type: "int", nullable: true),
                    JenisDocumentId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISOCores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISOCores_JenisDocuments_JenisDocumentId",
                        column: x => x.JenisDocumentId,
                        principalTable: "JenisDocuments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ISOCores_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryISOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ISOCoreId = table.Column<int>(type: "int", nullable: true),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryISOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryISOs_ISOCores_ISOCoreId",
                        column: x => x.ISOCoreId,
                        principalTable: "ISOCores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryISOs_ISOCoreId",
                table: "HistoryISOs",
                column: "ISOCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ISOCores_JenisDocumentId",
                table: "ISOCores",
                column: "JenisDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ISOCores_UnitId",
                table: "ISOCores",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryISOs");

            migrationBuilder.DropTable(
                name: "ISOCores");
        }
    }
}
