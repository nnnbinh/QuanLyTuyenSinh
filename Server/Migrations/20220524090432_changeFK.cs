using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyTuyenSinh.Server.Migrations
{
    public partial class changeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThiSinh_HinhAnh_HinhAnhId",
                table: "ThiSinh");

            migrationBuilder.DropIndex(
                name: "IX_ThiSinh_HinhAnhId",
                table: "ThiSinh");

            migrationBuilder.DropColumn(
                name: "HinhAnhId",
                table: "ThiSinh");

            migrationBuilder.DropColumn(
                name: "HocBa",
                table: "HinhAnh");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "ThiSinh",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ThiSinhId",
                table: "HinhAnh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_ThiSinhId",
                table: "HinhAnh",
                column: "ThiSinhId");

            migrationBuilder.AddForeignKey(
                name: "FK_HinhAnh_ThiSinh_ThiSinhId",
                table: "HinhAnh",
                column: "ThiSinhId",
                principalTable: "ThiSinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HinhAnh_ThiSinh_ThiSinhId",
                table: "HinhAnh");

            migrationBuilder.DropIndex(
                name: "IX_HinhAnh_ThiSinhId",
                table: "HinhAnh");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "ThiSinh");

            migrationBuilder.DropColumn(
                name: "ThiSinhId",
                table: "HinhAnh");

            migrationBuilder.AddColumn<int>(
                name: "HinhAnhId",
                table: "ThiSinh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HocBa",
                table: "HinhAnh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ThiSinh_HinhAnhId",
                table: "ThiSinh",
                column: "HinhAnhId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThiSinh_HinhAnh_HinhAnhId",
                table: "ThiSinh",
                column: "HinhAnhId",
                principalTable: "HinhAnh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
