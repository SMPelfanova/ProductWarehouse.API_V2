﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductWarehouse.Persistence.EF;

#nullable disable

namespace ProductWarehouse.Persistence.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240124152658_WerehouseDBInitialMigration")]
    partial class WerehouseDBInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f31c3eb-19eb-49ad-b6bd-4336ca404a58"),
                            Name = "Zara"
                        },
                        new
                        {
                            Id = new Guid("6b59cdc2-f178-48e3-bec6-b8dbdb6cf9f3"),
                            Name = "Bershka"
                        },
                        new
                        {
                            Id = new Guid("8454e24f-8dda-4be9-b6b9-ab03f94a4f39"),
                            Name = "Stella Nova"
                        });
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("50d7e6ea-f259-4222-93ab-400d5bee7de8"),
                            Name = "Casual"
                        },
                        new
                        {
                            Id = new Guid("fb086129-98b8-4ef0-bebd-612dbdaf37b2"),
                            Name = "Comfortable"
                        });
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("Userid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("StatusId");

                    b.HasIndex("Userid");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.OrderDetails", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("0843b8ed-b929-401b-b41f-24e6c4099d35"),
                            Name = "Pending"
                        },
                        new
                        {
                            Id = new Guid("7e084488-6cb3-460b-8542-7225e2794d59"),
                            Name = "Delivered"
                        });
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.HasKey("Id");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.ProductGroups", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("ProductGroups", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.ProductSize", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductSizes", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f4caab1a-06b2-4561-88d7-afac3072ca99"),
                            Name = "XS"
                        },
                        new
                        {
                            Id = new Guid("7700abc9-25a4-4a89-a405-5e1c759301af"),
                            Name = "S"
                        },
                        new
                        {
                            Id = new Guid("9b750f43-4710-4c09-b619-7fc0c371b2db"),
                            Name = "M"
                        },
                        new
                        {
                            Id = new Guid("64161ff0-d23e-4275-9e87-42c84659acf0"),
                            Name = "L"
                        },
                        new
                        {
                            Id = new Guid("a6dc1b2b-ab3d-429d-b4ab-d02f12b20d2b"),
                            Name = "XL"
                        });
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Order", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.OrderDetails", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Order", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.Size", "Size")
                        .WithMany("OrderDetails")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Product", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.ProductGroups", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Group", "Group")
                        .WithMany("ProductGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.Product", "Product")
                        .WithMany("ProductGroups")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.ProductSize", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Product", "Product")
                        .WithMany("ProductSizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.Size", "Size")
                        .WithMany("ProductSizes")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Group", b =>
                {
                    b.Navigation("ProductGroups");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ProductGroups");

                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Size", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}