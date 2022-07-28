using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_OPR.Migrations
{
    public partial class Fixrelasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Overtimes_OvertimeDetails_OvertimeDetailId",
                table: "Overtimes");

            migrationBuilder.DropIndex(
                name: "IX_Overtimes_OvertimeDetailId",
                table: "Overtimes");

            migrationBuilder.DropColumn(
                name: "OvertimeDetailId",
                table: "Overtimes");

            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeId",
                table: "OvertimeDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OvertimeDetails_OvertimeId",
                table: "OvertimeDetails",
                column: "OvertimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OvertimeDetails_Overtimes_OvertimeId",
                table: "OvertimeDetails",
                column: "OvertimeId",
                principalTable: "Overtimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OvertimeDetails_Overtimes_OvertimeId",
                table: "OvertimeDetails");

            migrationBuilder.DropIndex(
                name: "IX_OvertimeDetails_OvertimeId",
                table: "OvertimeDetails");

            migrationBuilder.DropColumn(
                name: "OvertimeId",
                table: "OvertimeDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "OvertimeDetailId",
                table: "Overtimes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Overtimes_OvertimeDetailId",
                table: "Overtimes",
                column: "OvertimeDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Overtimes_OvertimeDetails_OvertimeDetailId",
                table: "Overtimes",
                column: "OvertimeDetailId",
                principalTable: "OvertimeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
