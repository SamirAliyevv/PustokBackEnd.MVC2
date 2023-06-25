﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pustok.DAL;

#nullable disable

namespace Pustok.Migrations
{
    [DbContext(typeof(RelationsBooksShop))]
    [Migration("20230620201720_OrdersColumnadSliders")]
    partial class OrdersColumnadSliders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pustok.Entities.Authors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Pustok.Entities.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Percent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("StockStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AuthorsId");

                    b.HasIndex("GenresId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Pustok.Entities.BooksImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PosterImage")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BooksId");

                    b.ToTable("BooksImages");
                });

            modelBuilder.Entity("Pustok.Entities.BooksOrders", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("BooksOrders");
                });

            modelBuilder.Entity("Pustok.Entities.BooksTags", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("BooksTags");
                });

            modelBuilder.Entity("Pustok.Entities.Features", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IconClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Pustok.Entities.Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Pustok.Entities.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOred")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Pustok.Entities.Settings", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Key");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Pustok.Entities.Sliders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeaderTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Pustok.Entities.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Pustok.Entities.Books", b =>
                {
                    b.HasOne("Pustok.Entities.Authors", "Authors")
                        .WithMany("Books")
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pustok.Entities.Genres", "Genres")
                        .WithMany("Books")
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("Pustok.Entities.BooksImage", b =>
                {
                    b.HasOne("Pustok.Entities.Books", "Books")
                        .WithMany("BooksImages")
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");
                });

            modelBuilder.Entity("Pustok.Entities.BooksOrders", b =>
                {
                    b.HasOne("Pustok.Entities.Books", "Books")
                        .WithMany("BooksOrders")
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pustok.Entities.Orders", "Orders")
                        .WithMany("BooksOrders")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Pustok.Entities.BooksTags", b =>
                {
                    b.HasOne("Pustok.Entities.Books", "Books")
                        .WithMany("BooksTags")
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pustok.Entities.Tags", "Tags")
                        .WithMany("BooksTags")
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Pustok.Entities.Authors", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Pustok.Entities.Books", b =>
                {
                    b.Navigation("BooksImages");

                    b.Navigation("BooksOrders");

                    b.Navigation("BooksTags");
                });

            modelBuilder.Entity("Pustok.Entities.Genres", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Pustok.Entities.Orders", b =>
                {
                    b.Navigation("BooksOrders");
                });

            modelBuilder.Entity("Pustok.Entities.Tags", b =>
                {
                    b.Navigation("BooksTags");
                });
#pragma warning restore 612, 618
        }
    }
}
