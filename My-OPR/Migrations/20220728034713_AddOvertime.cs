using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class AddOvertime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestOvertimeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    RequestOvertimeStatusId = table.Column<int>(type: "int", nullable: false),
                    RequesterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TanggalApprove = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Catatan = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JamMulai = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JamSelesai = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Alasan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvertimeDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overtimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Overtimes_Employees_ApprovalId",
                        column: x => x.ApprovalId,
                        principalTable: "Employees",
                        principalColumn: "NPP");
                    table.ForeignKey(
                        name: "FK_Overtimes_Employees_UserId",
                        column: x => x.UserId,
                        principalTable: "Employees",
                        principalColumn: "NPP",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Overtimes_ApprovalId",
                table: "Overtimes",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Overtimes_OvertimeDetailId",
                table: "Overtimes",
                column: "OvertimeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Overtimes_UserId",
                table: "Overtimes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Overtimes");

            migrationBuilder.DropTable(
                name: "OvertimeDetails");

            migrationBuilder.DropTable(
                name: "RequestOvertimeStatuses");
        }
    }
}
