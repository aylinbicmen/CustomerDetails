﻿// <auto-generated />
using System;
using CustomerDetails.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerDetails.Migrations
{
    [DbContext(typeof(CustomerDetailsDbContext))]
    partial class CustomerDetailsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerDetails.Data.db.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AddressTypes", "Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Bireysel"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Kurumsal"
                        });
                });

            modelBuilder.Entity("CustomerDetails.Data.db.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AddressTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("IdentityNo")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaxNo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TaxOffice")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.ToTable("Customers", "Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Yedi Eylül Mah. Efeler/Aydın",
                            AddressTypeId = 1,
                            BirthDate = new DateTime(1985, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ece.akyurek@gmail.com",
                            IdentityNo = "18015526289",
                            IsActive = true,
                            Name = "Ece",
                            Phone = "5322262496",
                            Surname = "Akyürek"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Kazım Özalp Sok. Kadıköy/İstanbul",
                            AddressTypeId = 2,
                            BirthDate = new DateTime(1972, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "atakan-ozansoy@gmail.com",
                            IsActive = true,
                            Name = "Atakan",
                            Phone = "5333441212",
                            Surname = "Ozansoy",
                            TaxNo = "5421977337",
                            TaxOffice = "Kadıköy"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1996, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tuna_yildirim@outlook.com",
                            IsActive = true,
                            Name = "Tuna",
                            Phone = "5305759862",
                            Surname = "Yıldırım"
                        });
                });

            modelBuilder.Entity("CustomerDetails.Data.db.Customer", b =>
                {
                    b.HasOne("CustomerDetails.Data.db.AddressType", "AddressType")
                        .WithMany("Customers")
                        .HasForeignKey("AddressTypeId");

                    b.Navigation("AddressType");
                });

            modelBuilder.Entity("CustomerDetails.Data.db.AddressType", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
