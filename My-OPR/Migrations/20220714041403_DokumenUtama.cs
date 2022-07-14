using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class DokumenUtama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Services_Units_SubLayananId",
            //     table: "Services");

            migrationBuilder.DropTable(
                name: "HistoryISO");

            migrationBuilder.DropTable(
                name: "ISOSupport");

            migrationBuilder.DropTable(
                name: "ISOCore");

            migrationBuilder.DropIndex(
                name: "IX_Services_SubLayananId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SubLayananId",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "ServiceSubLayanan",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSubLayanan", x => new { x.ServicesId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_ServiceSubLayanan_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSubLayanan_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSubLayanan_UnitsId",
                table: "ServiceSubLayanan",
                column: "UnitsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceSubLayanan");

            migrationBuilder.AddColumn<int>(
                name: "SubLayananId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ISOCore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISOCore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ISOSupport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISOCoreId = table.Column<int>(type: "int", nullable: false),
                    RegisteredFormId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISOSupport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISOSupport_ISOCore_ISOCoreId",
                        column: x => x.ISOCoreId,
                        principalTable: "ISOCore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ISOSupport_RegisteredForms_RegisteredFormId",
                        column: x => x.RegisteredFormId,
                        principalTable: "RegisteredForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryISO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsoSupportId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryISO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryISO_ISOSupport_IsoSupportId",
                        column: x => x.IsoSupportId,
                        principalTable: "ISOSupport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_SubLayananId",
                table: "Services",
                column: "SubLayananId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryISO_IsoSupportId",
                table: "HistoryISO",
                column: "IsoSupportId");

            migrationBuilder.CreateIndex(
                name: "IX_ISOSupport_ISOCoreId",
                table: "ISOSupport",
                column: "ISOCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ISOSupport_RegisteredFormId",
                table: "ISOSupport",
                column: "RegisteredFormId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Services_Units_SubLayananId",
            //     table: "Services",
            //     column: "SubLayananId",
            //     principalTable: "Units",
            //     principalColumn: "Id");
        }
    }
}
