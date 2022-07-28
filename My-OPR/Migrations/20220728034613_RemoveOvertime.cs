using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class RemoveOvertime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Overtimes");

            migrationBuilder.DropTable(
                name: "OvertimeDetails");

            migrationBuilder.DropTable(
                name: "RequestOvertimeStatuses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestOvertimeStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOvertimeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OvertimeDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequestOvertimeStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Catatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalApprove = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvertimeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OvertimeDetails_Employees_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Employees",
                        principalColumn: "NPP");
                    table.ForeignKey(
                        name: "FK_OvertimeDetails_RequestOvertimeStatuses_RequestOvertimeStatusId",
                        column: x => x.RequestOvertimeStatusId,
                        principalTable: "RequestOvertimeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Overtimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeNPP = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OvertimeDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alasan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    JamMulai = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JamSelesai = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Npp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overtimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Overtimes_Employees_EmployeeNPP",
                        column: x => x.EmployeeNPP,
                        principalTable: "Employees",
                        principalColumn: "NPP");
                    table.ForeignKey(
                        name: "FK_Overtimes_OvertimeDetails_OvertimeDetailId",
                        column: x => x.OvertimeDetailId,
                        principalTable: "OvertimeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_RequesterId",
                table: "OvertimeDetails",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_RequestOvertimeStatusId",
                table: "OvertimeDetails",
                column: "RequestOvertimeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Overtimes_EmployeeNPP",
                table: "Overtimes",
                column: "EmployeeNPP");

            migrationBuilder.CreateIndex(
                name: "IX_Overtimes_OvertimeDetailId",
                table: "Overtimes",
                column: "OvertimeDetailId");
        }
    }
}
