using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class JustInit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Drawings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioID",
                table: "Drawings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    BuyerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric", nullable: false),
                    PreferredLocation = table.Column<string>(type: "text", nullable: false),
                    Rooms = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.BuyerID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateAddresses",
                columns: table => new
                {
                    RealEstateAddressID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    BuildingNumber = table.Column<string>(type: "text", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    Neighborhood = table.Column<string>(type: "text", nullable: false),
                    AddressLine = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PortfolioID = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateAddresses", x => x.RealEstateAddressID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateCategories",
                columns: table => new
                {
                    RealEstateCategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateCategories", x => x.RealEstateCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateTypes",
                columns: table => new
                {
                    RealEstateTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTypes", x => x.RealEstateTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PropertyTitle = table.Column<string>(type: "text", nullable: false),
                    AskingPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ListingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerID);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    PortfolioID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SellerID = table.Column<int>(type: "integer", nullable: true),
                    BuyerID = table.Column<int>(type: "integer", nullable: true),
                    RealEstateAddressID = table.Column<int>(type: "integer", nullable: false),
                    RealEstateTypeID = table.Column<int>(type: "integer", nullable: false),
                    RealEstateCategoryID = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.PortfolioID);
                    table.ForeignKey(
                        name: "FK_Portfolios_Buyers_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyers",
                        principalColumn: "BuyerID");
                    table.ForeignKey(
                        name: "FK_Portfolios_RealEstateAddresses_RealEstateAddressID",
                        column: x => x.RealEstateAddressID,
                        principalTable: "RealEstateAddresses",
                        principalColumn: "RealEstateAddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_RealEstateCategories_RealEstateCategoryID",
                        column: x => x.RealEstateCategoryID,
                        principalTable: "RealEstateCategories",
                        principalColumn: "RealEstateCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_RealEstateTypes_RealEstateTypeID",
                        column: x => x.RealEstateTypeID,
                        principalTable: "RealEstateTypes",
                        principalColumn: "RealEstateTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Sellers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Sellers",
                        principalColumn: "SellerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drawings_PortfolioID",
                table: "Drawings",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_BuyerID",
                table: "Portfolios",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_RealEstateAddressID",
                table: "Portfolios",
                column: "RealEstateAddressID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_RealEstateCategoryID",
                table: "Portfolios",
                column: "RealEstateCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_RealEstateTypeID",
                table: "Portfolios",
                column: "RealEstateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_SellerID",
                table: "Portfolios",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drawings_Portfolios_PortfolioID",
                table: "Drawings",
                column: "PortfolioID",
                principalTable: "Portfolios",
                principalColumn: "PortfolioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drawings_Portfolios_PortfolioID",
                table: "Drawings");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "RealEstateAddresses");

            migrationBuilder.DropTable(
                name: "RealEstateCategories");

            migrationBuilder.DropTable(
                name: "RealEstateTypes");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Drawings_PortfolioID",
                table: "Drawings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Drawings");

            migrationBuilder.DropColumn(
                name: "PortfolioID",
                table: "Drawings");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerAddress = table.Column<string>(type: "text", nullable: true),
                    CustomerDescription = table.Column<string>(type: "text", nullable: true),
                    CustomerFullName = table.Column<string>(type: "text", nullable: true),
                    CustomerPhone = table.Column<string>(type: "text", nullable: true),
                    CustomerPrice = table.Column<double>(type: "double precision", nullable: true),
                    CustomerType = table.Column<string>(type: "text", nullable: true),
                    FSBODate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ListingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ListingNumber = table.Column<string>(type: "text", nullable: true),
                    ListingRoomCount = table.Column<string>(type: "text", nullable: true),
                    NextCallDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });
        }
    }
}
