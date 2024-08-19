using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class ListingCancel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Balcony = table.Column<string>(type: "text", nullable: true),
                    BathroomCount = table.Column<int>(type: "integer", nullable: true),
                    BuildingAge = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deposit = table.Column<decimal>(type: "numeric", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Elevator = table.Column<string>(type: "text", nullable: true),
                    FloorNumber = table.Column<int>(type: "integer", nullable: true),
                    Furnished = table.Column<string>(type: "text", nullable: true),
                    GrossArea = table.Column<int>(type: "integer", nullable: true),
                    HeatingType = table.Column<string>(type: "text", nullable: true),
                    HousingComplexName = table.Column<string>(type: "text", nullable: true),
                    IsInHousingComplex = table.Column<bool>(type: "boolean", nullable: true),
                    ListingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ListingNumber = table.Column<string>(type: "text", nullable: false),
                    MonthlyFee = table.Column<decimal>(type: "numeric", nullable: true),
                    Neighborhood = table.Column<string>(type: "text", nullable: true),
                    NetArea = table.Column<int>(type: "integer", nullable: true),
                    OwnerType = table.Column<string>(type: "text", nullable: true),
                    Parking = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<string>(type: "text", nullable: true),
                    PropertyType = table.Column<string>(type: "text", nullable: true),
                    RoomCount = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    TotalFloors = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsageStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingID);
                });
        }
    }
}
