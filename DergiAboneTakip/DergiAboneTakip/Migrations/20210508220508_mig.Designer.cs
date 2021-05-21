﻿// <auto-generated />
using System;
using DergiAboneTakip.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DergiAboneTakip.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210508220508_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DergiAboneTakip.Models.AboneTablosu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AboneTarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("Ay")
                        .HasColumnType("int");

                    b.Property<int>("DergiID")
                        .HasColumnType("int");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UyeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("abones");
                });

            modelBuilder.Entity("DergiAboneTakip.Models.DergilerTablosu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DergiAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KateID")
                        .HasColumnType("int");

                    b.Property<int?>("kategoriID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("kategoriID");

                    b.ToTable("dergilers");
                });

            modelBuilder.Entity("DergiAboneTakip.Models.KategoriTablosu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KategoriAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("kategoris");
                });

            modelBuilder.Entity("DergiAboneTakip.Models.UyelerTablosu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("KulAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KulSoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Yetki")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("uyelers");
                });

            modelBuilder.Entity("DergiAboneTakip.Models.DergilerTablosu", b =>
                {
                    b.HasOne("DergiAboneTakip.Models.KategoriTablosu", "kategori")
                        .WithMany()
                        .HasForeignKey("kategoriID");
                });
#pragma warning restore 612, 618
        }
    }
}