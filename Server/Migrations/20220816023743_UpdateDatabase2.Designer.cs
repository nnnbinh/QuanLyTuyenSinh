﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyTuyenSinh.Server.Data;

#nullable disable

namespace QuanLyTuyenSinh.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220816023743_UpdateDatabase2")]
    partial class UpdateDatabase2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyTuyenSinh.Shared.HinhAnh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThiSinhId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ThiSinhId");

                    b.ToTable("HinhAnh");
                });

            modelBuilder.Entity("QuanLyTuyenSinh.Shared.ThiSinh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BacHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CBTuVan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cmnd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Diem1111")
                        .HasColumnType("float");

                    b.Property<double>("Diem1112")
                        .HasColumnType("float");

                    b.Property<double>("Diem1211")
                        .HasColumnType("float");

                    b.Property<double>("Diem1212")
                        .HasColumnType("float");

                    b.Property<double>("Diem1TB12")
                        .HasColumnType("float");

                    b.Property<double>("Diem2111")
                        .HasColumnType("float");

                    b.Property<double>("Diem2112")
                        .HasColumnType("float");

                    b.Property<double>("Diem2211")
                        .HasColumnType("float");

                    b.Property<double>("Diem2212")
                        .HasColumnType("float");

                    b.Property<double>("Diem2TB12")
                        .HasColumnType("float");

                    b.Property<double>("Diem3111")
                        .HasColumnType("float");

                    b.Property<double>("Diem3112")
                        .HasColumnType("float");

                    b.Property<double>("Diem3211")
                        .HasColumnType("float");

                    b.Property<double>("Diem3212")
                        .HasColumnType("float");

                    b.Property<double>("Diem3TB12")
                        .HasColumnType("float");

                    b.Property<double>("DiemTBPT1")
                        .HasColumnType("float");

                    b.Property<double>("DiemTBPT2")
                        .HasColumnType("float");

                    b.Property<double>("DiemTBPT3")
                        .HasColumnType("float");

                    b.Property<int>("DiemUuTienDT")
                        .HasColumnType("int");

                    b.Property<double>("DiemUuTienKV")
                        .HasColumnType("float");

                    b.Property<string>("DoiTuong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HK11")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HK12")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KhoiXetTuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KhuVuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaDKXT")
                        .HasColumnType("int");

                    b.Property<string>("MaNganhXetTuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mon1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mon2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mon3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgaySinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Ngaygui")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tong")
                        .HasColumnType("float");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TruongTHPT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("diem1")
                        .HasColumnType("float");

                    b.Property<double>("diem2")
                        .HasColumnType("float");

                    b.Property<double>("diem3")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ThiSinh");
                });

            modelBuilder.Entity("QuanLyTuyenSinh.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("QuanLyTuyenSinh.Shared.HinhAnh", b =>
                {
                    b.HasOne("QuanLyTuyenSinh.Shared.ThiSinh", "ThiSinh")
                        .WithMany("HinhAnhs")
                        .HasForeignKey("ThiSinhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThiSinh");
                });

            modelBuilder.Entity("QuanLyTuyenSinh.Shared.ThiSinh", b =>
                {
                    b.HasOne("QuanLyTuyenSinh.Shared.User", "User")
                        .WithMany("ThiSinhs")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuanLyTuyenSinh.Shared.ThiSinh", b =>
                {
                    b.Navigation("HinhAnhs");
                });

            modelBuilder.Entity("QuanLyTuyenSinh.Shared.User", b =>
                {
                    b.Navigation("ThiSinhs");
                });
#pragma warning restore 612, 618
        }
    }
}
