using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class UpdateISoCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISOCores_Units_UnitId",
                table: "ISOCores");

            migrationBuilder.DropTable(
                name: "ServiceSubLayanan");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "ISOCores",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ISOCores_UnitId",
                table: "ISOCores",
                newName: "IX_ISOCores_GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ServiceId",
                table: "Units",
                column: "ServiceId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_ISOCores_Groups_GroupId",
            //     table: "ISOCores",
            //     column: "GroupId",
            //     principalTable: "Groups",
            //     principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Services_ServiceId",
                table: "Units",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISOCores_Groups_GroupId",
                table: "ISOCores");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Services_ServiceId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ServiceId",
                table: "Units");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "ISOCores",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ISOCores_GroupId",
                table: "ISOCores",
                newName: "IX_ISOCores_UnitId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ISOCores_Units_UnitId",
                table: "ISOCores",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
