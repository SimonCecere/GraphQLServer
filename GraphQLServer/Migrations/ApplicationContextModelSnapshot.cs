﻿// <auto-generated />
using System;
using GraphQLServer.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLServer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GraphQLServer.DbModels.ItemOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShippedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.Property<string>("TrackingNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("ItemOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 2,
                            Quantity = 5,
                            ShippedDateTime = new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(443),
                            SubmissionId = 2,
                            TrackingNumber = "1Z204E380338943508"
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 1,
                            Quantity = 3,
                            ShippedDateTime = new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1217),
                            SubmissionId = 2,
                            TrackingNumber = "1Z204E380338943508"
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Quantity = 7,
                            ShippedDateTime = new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1241),
                            SubmissionId = 2,
                            TrackingNumber = "1Z204E380338943587"
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 2,
                            Quantity = 5,
                            ShippedDateTime = new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1245),
                            SubmissionId = 3,
                            TrackingNumber = "1Z204E380338945687"
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 1,
                            Quantity = 10,
                            ShippedDateTime = new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1249),
                            SubmissionId = 3,
                            TrackingNumber = "1Z204E380338945687"
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 3,
                            Quantity = 2,
                            ShippedDateTime = new DateTime(2020, 12, 8, 23, 30, 35, 677, DateTimeKind.Local).AddTicks(1252),
                            SubmissionId = 1,
                            TrackingNumber = "1Z204E380338945987"
                        });
                });

            modelBuilder.Entity("GraphQLServer.DbModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Buffer")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("MethodOfShipment")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SKU")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("SKU")
                        .IsUnique()
                        .HasFilter("[SKU] IS NOT NULL");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Buffer = 20,
                            Description = "Elder Wand",
                            Inventory = 1000,
                            MethodOfShipment = "UPS",
                            SKU = "EW02112152"
                        },
                        new
                        {
                            Id = 2,
                            Buffer = 10,
                            Description = "Philosophy 101",
                            Inventory = 200,
                            MethodOfShipment = "UPS",
                            SKU = "PH02112101"
                        },
                        new
                        {
                            Id = 3,
                            Buffer = 10,
                            Description = "Cookie Dough",
                            Inventory = 600,
                            MethodOfShipment = "UPS",
                            SKU = "CD02112613"
                        });
                });

            modelBuilder.Entity("GraphQLServer.DbModels.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address1")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Address2")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("LastName")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Status")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("SubmissionId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("ClientSubmissionId");

                    b.HasKey("Id");

                    b.ToTable("Submission");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address1 = "1175 S Pokegama Ave",
                            City = "Grand Rapids",
                            CountryCode = "USA",
                            DateTime = new DateTime(2020, 12, 8, 23, 30, 35, 674, DateTimeKind.Local).AddTicks(5515),
                            Email = "culvers@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "6125555555",
                            PostalCode = "55744",
                            State = "MN",
                            Status = "PENDING",
                            SubmissionId = "4564123456789456"
                        },
                        new
                        {
                            Id = 2,
                            Address1 = "239 Vauxhall Bridge Rd",
                            City = "London",
                            CountryCode = "GBR",
                            DateTime = new DateTime(2020, 12, 8, 23, 30, 35, 676, DateTimeKind.Local).AddTicks(8811),
                            Email = "alan@example.com",
                            FirstName = "Alan",
                            LastName = "Watts",
                            Phone = "6125555555",
                            PostalCode = "SO40 9RB",
                            State = "",
                            Status = "PENDING",
                            SubmissionId = "7893541231456654"
                        },
                        new
                        {
                            Id = 3,
                            Address1 = "6000 Universal Blvd",
                            City = "Orlando",
                            CountryCode = "USA",
                            DateTime = new DateTime(2020, 12, 8, 23, 30, 35, 676, DateTimeKind.Local).AddTicks(8901),
                            Email = "AlbusD@hogwarts.com",
                            FirstName = "Albus",
                            LastName = "Dumbledore",
                            Phone = "6125555555",
                            PostalCode = "32819",
                            State = "FL",
                            Status = "PENDING",
                            SubmissionId = "7893541231456654"
                        });
                });

            modelBuilder.Entity("GraphQLServer.DbModels.ItemOrder", b =>
                {
                    b.HasOne("GraphQLServer.DbModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQLServer.DbModels.Submission", "Submission")
                        .WithMany("ItemOrders")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("GraphQLServer.DbModels.Submission", b =>
                {
                    b.Navigation("ItemOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
