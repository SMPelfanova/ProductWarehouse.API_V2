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
    [Migration("20240130122330_WerehouseNullableFK")]
    partial class WerehouseNullableFK
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
                            Id = new Guid("1bbef41e-edbe-46e1-8647-438b36592b1b"),
                            Name = "Zara"
                        },
                        new
                        {
                            Id = new Guid("32d7937e-d655-4f7f-896d-a6803ff89469"),
                            Name = "Bershka"
                        },
                        new
                        {
                            Id = new Guid("b54374fd-d751-47e6-9046-ed3791b95b2e"),
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
                            Id = new Guid("cf229d36-f421-46db-b6b9-b4f118eb4e81"),
                            Name = "Casual"
                        },
                        new
                        {
                            Id = new Guid("5e2d79ca-02e1-485b-a5c3-eb9410e668cb"),
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

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid?>("Userid")
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
                            Id = new Guid("fa2f6a50-b884-43d9-8d61-e11da958d5e7"),
                            Name = "Pending"
                        },
                        new
                        {
                            Id = new Guid("07faf2a1-3b1c-4065-a49a-d587afa7b251"),
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
                            Id = new Guid("0b28d08c-b209-4436-a990-89d934f00eac"),
                            Name = "XS"
                        },
                        new
                        {
                            Id = new Guid("57767a17-7abb-404b-aa7e-0512ba82c907"),
                            Name = "S"
                        },
                        new
                        {
                            Id = new Guid("5d5a9f85-6edf-40d3-b5b3-4e6f69e4c2e1"),
                            Name = "M"
                        },
                        new
                        {
                            Id = new Guid("d11dd3ed-3506-43df-81a4-bcc9cd3e639c"),
                            Name = "L"
                        },
                        new
                        {
                            Id = new Guid("f4978666-30f8-4f3b-9205-3a7c76749800"),
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
                        .HasForeignKey("PaymentId");

                    b.HasOne("ProductWarehouse.Domain.Entities.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("Userid");

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
