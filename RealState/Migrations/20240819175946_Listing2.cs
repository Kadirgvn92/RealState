using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class Listing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListingNumber = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Neighborhood = table.Column<string>(type: "text", nullable: true),
                    ListingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PropertyType = table.Column<string>(type: "text", nullable: true),
                    GrossArea = table.Column<int>(type: "integer", nullable: true),
                    NetArea = table.Column<int>(type: "integer", nullable: true),
                    RoomCount = table.Column<string>(type: "text", nullable: true),
                    BuildingAge = table.Column<string>(type: "text", nullable: true),
                    FloorNumber = table.Column<int>(type: "integer", nullable: true),
                    TotalFloors = table.Column<int>(type: "integer", nullable: true),
                    HeatingType = table.Column<string>(type: "text", nullable: true),
                    BathroomCount = table.Column<int>(type: "integer", nullable: true),
                    HasBalcony = table.Column<bool>(type: "boolean", nullable: true),
                    HasElevator = table.Column<bool>(type: "boolean", nullable: true),
                    HasParking = table.Column<bool>(type: "boolean", nullable: true),
                    IsFurnished = table.Column<bool>(type: "boolean", nullable: true),
                    UsageStatus = table.Column<string>(type: "text", nullable: true),
                    IsInHousingComplex = table.Column<bool>(type: "boolean", nullable: true),
                    HousingComplexName = table.Column<string>(type: "text", nullable: true),
                    MonthlyFee = table.Column<decimal>(type: "numeric", nullable: true),
                    Deposit = table.Column<decimal>(type: "numeric", nullable: true),
                    OwnerType = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
