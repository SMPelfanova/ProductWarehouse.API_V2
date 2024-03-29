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
    [Migration("20240205145401_WerehouseDBRelationFixes")]
    partial class WerehouseDBRelationFixes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Baskets", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.BasketLine", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "BasketId");

                    b.HasIndex("BasketId");

                    b.HasIndex("SizeId");

                    b.ToTable("BasketLines", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cabb3b71-67d1-423d-97d1-24ad195e8f93"),
                            Name = "Zara"
                        },
                        new
                        {
                            Id = new Guid("64d0b670-0224-4a52-ba91-a50210e0f060"),
                            Name = "Bershka"
                        },
                        new
                        {
                            Id = new Guid("cc3ba321-cbfc-43a2-a63e-dd30b6f59d5a"),
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Groups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("51945acd-123c-4ded-be93-1980493d8aab"),
                            Name = "Casual"
                        },
                        new
                        {
                            Id = new Guid("ab42bf33-1860-418a-aa0f-4656abf962eb"),
                            Name = "Comfortable"
                        });
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.HasIndex("PaymentId")
                        .IsUnique()
                        .HasFilter("[PaymentId] IS NOT NULL");

                    b.HasIndex("StatusId");

                    b.HasIndex("Userid");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.OrderLine", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("OrderLines", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f88493d-c546-4e63-8d27-5a90a608f800"),
                            Name = "Pending"
                        },
                        new
                        {
                            Id = new Guid("066ebde3-ed9f-409f-9e3a-a6d565af31de"),
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PaymentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

                    b.Property<int>("QuantityInStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("ProductId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductSizes", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Sizes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("784f031d-f568-4725-89cc-612ef01c92ca"),
                            Name = "XS"
                        },
                        new
                        {
                            Id = new Guid("6a6a8330-b769-401e-8d7d-6e68c5ca30ff"),
                            Name = "S"
                        },
                        new
                        {
                            Id = new Guid("a463beb0-547f-4440-b1be-7110525c862d"),
                            Name = "M"
                        },
                        new
                        {
                            Id = new Guid("6ee74602-7b69-400c-8d01-5a48267a3fa2"),
                            Name = "L"
                        },
                        new
                        {
                            Id = new Guid("40b7d31a-1ce7-4194-b485-59484ada6472"),
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
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Basket", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.User", "User")
                        .WithOne("Basket")
                        .HasForeignKey("ProductWarehouse.Domain.Entities.Basket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.BasketLine", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Basket", "Basket")
                        .WithMany("BasketLines")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.Product", "Product")
                        .WithMany("BasketLines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.Size", "Size")
                        .WithMany("BasketLines")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Order", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Payment", "Payment")
                        .WithOne("Order")
                        .HasForeignKey("ProductWarehouse.Domain.Entities.Order", "PaymentId");

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

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.OrderLine", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Order", "Orders")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.Product", "Product")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.Size", "Size")
                        .WithMany("OrderLines")
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

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("ProductWarehouse.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductWarehouse.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Basket", b =>
                {
                    b.Navigation("BasketLines");
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
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Payment", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Product", b =>
                {
                    b.Navigation("BasketLines");

                    b.Navigation("OrderLines");

                    b.Navigation("ProductGroups");

                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.Size", b =>
                {
                    b.Navigation("BasketLines");

                    b.Navigation("OrderLines");

                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("ProductWarehouse.Domain.Entities.User", b =>
                {
                    b.Navigation("Basket")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
