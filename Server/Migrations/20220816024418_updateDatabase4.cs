using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyTuyenSinh.Server.Migrations
{
    public partial class updateDatabase4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerifyToken",
                table: "UserReg",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerifyToken",
                table: "UserReg");
        }
    }
}
