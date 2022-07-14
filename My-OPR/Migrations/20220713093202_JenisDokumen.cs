using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class JenisDokumen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryISOs_ISOSupports_IsoSupportId",
                table: "HistoryISOs");

            migrationBuilder.DropForeignKey(
                name: "FK_ISOSupports_ISOCores_ISOCoreId",
                table: "ISOSupports");

            migrationBuilder.DropForeignKey(
                name: "FK_ISOSupports_RegisteredForms_RegisteredFormId",
                table: "ISOSupports");

            migrationBuilder.DropForeignKey(
                name: "FK_KategoriDocuments_JenisDocument_JenisDocumentId",
                table: "KategoriDocuments");

            migrationBuilder.DropTable(
                name: "LaporanHarians");

            migrationBuilder.DropTable(
                name: "AnomaliLaporan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JenisDocument",
                table: "JenisDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ISOSupports",
                table: "ISOSupports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ISOCores",
                table: "ISOCores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryISOs",
                table: "HistoryISOs");

            migrationBuilder.RenameTable(
                name: "JenisDocument",
                newName: "JenisDocuments");

            migrationBuilder.RenameTable(
                name: "ISOSupports",
                newName: "ISOSupport");

            migrationBuilder.RenameTable(
                name: "ISOCores",
                newName: "ISOCore");

            migrationBuilder.RenameTable(
                name: "HistoryISOs",
                newName: "HistoryISO");

            migrationBuilder.RenameIndex(
                name: "IX_ISOSupports_RegisteredFormId",
                table: "ISOSupport",
                newName: "IX_ISOSupport_RegisteredFormId");

            migrationBuilder.RenameIndex(
                name: "IX_ISOSupports_ISOCoreId",
                table: "ISOSupport",
                newName: "IX_ISOSupport_ISOCoreId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryISOs_IsoSupportId",
                table: "HistoryISO",
                newName: "IX_HistoryISO_IsoSupportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JenisDocuments",
                table: "JenisDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ISOSupport",
                table: "ISOSupport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ISOCore",
                table: "ISOCore",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryISO",
                table: "HistoryISO",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryISO_ISOSupport_IsoSupportId",
                table: "HistoryISO",
                column: "IsoSupportId",
                principalTable: "ISOSupport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ISOSupport_ISOCore_ISOCoreId",
                table: "ISOSupport",
                column: "ISOCoreId",
                principalTable: "ISOCore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ISOSupport_RegisteredForms_RegisteredFormId",
                table: "ISOSupport",
                column: "RegisteredFormId",
                principalTable: "RegisteredForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KategoriDocuments_JenisDocuments_JenisDocumentId",
                table: "KategoriDocuments",
                column: "JenisDocumentId",
                principalTable: "JenisDocuments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryISO_ISOSupport_IsoSupportId",
                table: "HistoryISO");

            migrationBuilder.DropForeignKey(
                name: "FK_ISOSupport_ISOCore_ISOCoreId",
                table: "ISOSupport");

            migrationBuilder.DropForeignKey(
                name: "FK_ISOSupport_RegisteredForms_RegisteredFormId",
                table: "ISOSupport");

            migrationBuilder.DropForeignKey(
                name: "FK_KategoriDocuments_JenisDocuments_JenisDocumentId",
                table: "KategoriDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JenisDocuments",
                table: "JenisDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ISOSupport",
                table: "ISOSupport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ISOCore",
                table: "ISOCore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryISO",
                table: "HistoryISO");

            migrationBuilder.RenameTable(
                name: "JenisDocuments",
                newName: "JenisDocument");

            migrationBuilder.RenameTable(
                name: "ISOSupport",
                newName: "ISOSupports");

            migrationBuilder.RenameTable(
                name: "ISOCore",
                newName: "ISOCores");

            migrationBuilder.RenameTable(
                name: "HistoryISO",
                newName: "HistoryISOs");

            migrationBuilder.RenameIndex(
                name: "IX_ISOSupport_RegisteredFormId",
                table: "ISOSupports",
                newName: "IX_ISOSupports_RegisteredFormId");

            migrationBuilder.RenameIndex(
                name: "IX_ISOSupport_ISOCoreId",
                table: "ISOSupports",
                newName: "IX_ISOSupports_ISOCoreId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryISO_IsoSupportId",
                table: "HistoryISOs",
                newName: "IX_HistoryISOs_IsoSupportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JenisDocument",
                table: "JenisDocument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ISOSupports",
                table: "ISOSupports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ISOCores",
                table: "ISOCores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryISOs",
                table: "HistoryISOs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AnomaliLaporan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Anomali = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnomaliLaporan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnomaliLaporan_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaporanHarians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnomaliId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    ApprovalId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAnomaly = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    TanggalTransaksi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaporanHarians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaporanHarians_AnomaliLaporan_AnomaliId",
                        column: x => x.AnomaliId,
                        principalTable: "AnomaliLaporan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LaporanHarians_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnomaliLaporan_ServiceId",
                table: "AnomaliLaporan",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_LaporanHarians_AnomaliId",
                table: "LaporanHarians",
                column: "AnomaliId");

            migrationBuilder.CreateIndex(
                name: "IX_LaporanHarians_GroupId",
                table: "LaporanHarians",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryISOs_ISOSupports_IsoSupportId",
                table: "HistoryISOs",
                column: "IsoSupportId",
                principalTable: "ISOSupports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ISOSupports_ISOCores_ISOCoreId",
                table: "ISOSupports",
                column: "ISOCoreId",
                principalTable: "ISOCores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ISOSupports_RegisteredForms_RegisteredFormId",
                table: "ISOSupports",
                column: "RegisteredFormId",
                principalTable: "RegisteredForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KategoriDocuments_JenisDocument_JenisDocumentId",
                table: "KategoriDocuments",
                column: "JenisDocumentId",
                principalTable: "JenisDocument",
                principalColumn: "Id");
        }
    }
}
