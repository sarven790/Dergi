using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DergiAboneTakip.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(nullable: false),
                    Ay = table.Column<int>(nullable: false),
                    Fiyat = table.Column<decimal>(nullable: false),
                    AboneTarih = table.Column<DateTime>(nullable: false),
                    Durum = table.Column<bool>(nullable: false),
                    DergiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "kategoris",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "uyelers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KulAdi = table.Column<string>(nullable: true),
                    KulSoyadi = table.Column<string>(nullable: true),
                    Sifre = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Yetki = table.Column<int>(nullable: false),
                    Durum = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uyelers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "dergilers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DergiAdi = table.Column<string>(nullable: true),
                    Fiyat = table.Column<decimal>(nullable: false),
                    Durum = table.Column<bool>(nullable: false),
                    KateID = table.Column<int>(nullable: false),
                    kategoriID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dergilers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dergilers_kategoris_kategoriID",
                        column: x => x.kategoriID,
                        principalTable: "kategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dergilers_kategoriID",
                table: "dergilers",
                column: "kategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abones");

            migrationBuilder.DropTable(
                name: "dergilers");

            migrationBuilder.DropTable(
                name: "uyelers");

            migrationBuilder.DropTable(
                name: "kategoris");
        }
    }
}
