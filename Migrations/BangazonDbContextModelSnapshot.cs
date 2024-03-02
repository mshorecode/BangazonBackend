﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    partial class BangazonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryType = "Men's Apparel"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryType = "Women's Apparel"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryType = "Children's Apparel"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryType = "Electronics"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            PaymentId = 1,
                            Status = true
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            PaymentId = 2,
                            Status = true
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentId"));

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            PaymentId = 1,
                            PaymentType = "Cash"
                        },
                        new
                        {
                            PaymentId = 2,
                            PaymentType = "Card"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ProductDescription = "A three pack of polo shirts",
                            ProductImageUrl = "https://www.trueclassictees.com/cdn/shop/products/StaplePolo3pack.jpg?v=1680043192&%3Bwidth=500&em-format=avif&em-width=500",
                            ProductName = "Assortment of Polo Shirts",
                            ProductPrice = 30.00m,
                            SellerId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ProductDescription = "A nice dress",
                            ProductImageUrl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSqvN814z6D8TvpO5h1fMllSOg3-hY9hCOb3qCdbUw-3e5tQi5J1oNvBwt2atWcE6gsEudtrrIZ9vCkoN_96PXTZKP-J3XC2rmyxcuDEHfHFIgwbEIW2Km5&usqp=CAE",
                            ProductName = "Dress",
                            ProductPrice = 40.00m,
                            SellerId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            ProductDescription = "A nice Sonic t-shirt",
                            ProductImageUrl = "https://m.media-amazon.com/images/I/812lr5yYl2S._AC_SX679_.jpg",
                            ProductName = "Sonic T-Shirt",
                            ProductPrice = 15.00m,
                            SellerId = 1
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 4,
                            ProductDescription = "A nice gaming laptop",
                            ProductImageUrl = "https://c1.neweggimages.com/ProductImageCompressAll1280/34-236-449-01.jpg",
                            ProductName = "ASUS ROG STRIX Laptop",
                            ProductPrice = 1700.00m,
                            SellerId = 1
                        });
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Seller")
                        .HasColumnType("boolean");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersOrderId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("OrderProduct", (string)null);
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("Bangazon.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
