using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyTuyenSinh.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HinhAnh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HocBa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThiSinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cmnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BacHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNganhXetTuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoiTuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemUuTienDT = table.Column<int>(type: "int", nullable: false),
                    KhuVuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemUuTienKV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoiXetTuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mon1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mon2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mon3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diem1111 = table.Column<double>(type: "float", nullable: false),
                    Diem1211 = table.Column<double>(type: "float", nullable: false),
                    Diem1112 = table.Column<double>(type: "float", nullable: false),
                    Diem1212 = table.Column<double>(type: "float", nullable: false),
                    Diem1TB12 = table.Column<double>(type: "float", nullable: false),
                    Diem2111 = table.Column<double>(type: "float", nullable: false),
                    Diem2211 = table.Column<double>(type: "float", nullable: false),
                    Diem2112 = table.Column<double>(type: "float", nullable: false),
                    Diem2212 = table.Column<double>(type: "float", nullable: false),
                    Diem2TB12 = table.Column<double>(type: "float", nullable: false),
                    Diem3111 = table.Column<double>(type: "float", nullable: false),
                    Diem3211 = table.Column<double>(type: "float", nullable: false),
                    Diem3112 = table.Column<double>(type: "float", nullable: false),
                    Diem3212 = table.Column<double>(type: "float", nullable: false),
                    Diem3TB12 = table.Column<double>(type: "float", nullable: false),
                    DiemTBPT1 = table.Column<double>(type: "float", nullable: false),
                    DiemTBPT2 = table.Column<double>(type: "float", nullable: false),
                    DiemTBPT3 = table.Column<double>(type: "float", nullable: false),
                    TruongTHPT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HK11 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HK12 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaDKXT = table.Column<int>(type: "int", nullable: true),
                    diem1 = table.Column<double>(type: "float", nullable: false),
                    diem2 = table.Column<double>(type: "float", nullable: false),
                    diem3 = table.Column<double>(type: "float", nullable: false),
                    Tong = table.Column<double>(type: "float", nullable: false),
                    Sdt = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaygui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CBTuVan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhAnhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThiSinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThiSinh_HinhAnh_HinhAnhId",
                        column: x => x.HinhAnhId,
                        principalTable: "HinhAnh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThiSinh_HinhAnhId",
                table: "ThiSinh",
                column: "HinhAnhId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThiSinh");

            migrationBuilder.DropTable(
                name: "HinhAnh");
        }
    }
}
