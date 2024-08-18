﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RealState.Context;

#nullable disable

namespace RealState.Migrations
{
    [DbContext(typeof(RealStateContext))]
    [Migration("20240818101300_softDelete")]
    partial class softDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RealState.Entity.AppRole", b =>
                {
                    b.Property<int>("AppRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AppRoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AppRoleId");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("RealState.Entity.AppUser", b =>
                {
                    b.Property<int>("AppUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AppUserID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleID")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AppUserID");

                    b.HasIndex("RoleID");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("RealState.Entity.Buyer", b =>
                {
                    b.Property<int>("BuyerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BuyerID"));

                    b.Property<string>("Budget")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("PreferredLocation")
                        .HasColumnType("text");

                    b.Property<string>("Rooms")
                        .HasColumnType("text");

                    b.HasKey("BuyerID");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("RealState.Entity.Drawing", b =>
                {
                    b.Property<int>("DrawingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DrawingId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Geometry>("Geometry")
                        .HasColumnType("geometry");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PortfolioID")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DrawingId");

                    b.HasIndex("PortfolioID");

                    b.ToTable("Drawings");
                });

            modelBuilder.Entity("RealState.Entity.Portfolio", b =>
                {
                    b.Property<int>("PortfolioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PortfolioID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("RealEstateAddressID")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstateCategoryID")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstateStatusID")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstateTypeID")
                        .HasColumnType("integer");

                    b.Property<int?>("SellerID")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PortfolioID");

                    b.HasIndex("RealEstateAddressID")
                        .IsUnique();

                    b.HasIndex("RealEstateCategoryID");

                    b.HasIndex("RealEstateStatusID");

                    b.HasIndex("RealEstateTypeID");

                    b.HasIndex("SellerID");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("RealState.Entity.RealEstateAddress", b =>
                {
                    b.Property<int>("RealEstateAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RealEstateAddressID"));

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PortfolioID")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RealEstateAddressID");

                    b.ToTable("RealEstateAddresses");
                });

            modelBuilder.Entity("RealState.Entity.RealEstateCategory", b =>
                {
                    b.Property<int>("RealEstateCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RealEstateCategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("RealEstateCategoryID");

                    b.ToTable("RealEstateCategories");
                });

            modelBuilder.Entity("RealState.Entity.RealEstateStatus", b =>
                {
                    b.Property<int>("RealEstateStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RealEstateStatusID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RealEstateStatusID");

                    b.ToTable("RealEstateStatuses");
                });

            modelBuilder.Entity("RealState.Entity.RealEstateType", b =>
                {
                    b.Property<int>("RealEstateTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RealEstateTypeID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RealEstateTypeID");

                    b.ToTable("RealEstateTypes");
                });

            modelBuilder.Entity("RealState.Entity.Seller", b =>
                {
                    b.Property<int>("SellerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SellerID"));

                    b.Property<string>("AskingPrice")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ListingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("PropertyTitle")
                        .HasColumnType("text");

                    b.HasKey("SellerID");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("RealState.Entity.AppUser", b =>
                {
                    b.HasOne("RealState.Entity.AppRole", "AppRole")
                        .WithMany("AppUsers")
                        .HasForeignKey("RoleID")
                        .IsRequired();

                    b.Navigation("AppRole");
                });

            modelBuilder.Entity("RealState.Entity.Drawing", b =>
                {
                    b.HasOne("RealState.Entity.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioID");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("RealState.Entity.Portfolio", b =>
                {
                    b.HasOne("RealState.Entity.RealEstateAddress", "RealEstateAddress")
                        .WithOne("Portfolio")
                        .HasForeignKey("RealState.Entity.Portfolio", "RealEstateAddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealState.Entity.RealEstateCategory", "RealEstateCategory")
                        .WithMany("Portfolios")
                        .HasForeignKey("RealEstateCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealState.Entity.RealEstateStatus", "RealEstateStatus")
                        .WithMany("Portfolios")
                        .HasForeignKey("RealEstateStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealState.Entity.RealEstateType", "RealEstateType")
                        .WithMany("Portfolios")
                        .HasForeignKey("RealEstateTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealState.Entity.Seller", "Seller")
                        .WithMany("Portfolios")
                        .HasForeignKey("SellerID");

                    b.Navigation("RealEstateAddress");

                    b.Navigation("RealEstateCategory");

                    b.Navigation("RealEstateStatus");

                    b.Navigation("RealEstateType");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("RealState.Entity.AppRole", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("RealState.Entity.RealEstateAddress", b =>
                {
                    b.Navigation("Portfolio")
                        .IsRequired();
                });

            modelBuilder.Entity("RealState.Entity.RealEstateCategory", b =>
                {
                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("RealState.Entity.RealEstateStatus", b =>
                {
                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("RealState.Entity.RealEstateType", b =>
                {
                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("RealState.Entity.Seller", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
