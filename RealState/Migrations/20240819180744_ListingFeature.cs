using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class ListingFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBalcony",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HasElevator",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "HasParking",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "IsFurnished",
                table: "Listings");

            migrationBuilder.AddColumn<string>(
                name: "Balcony",
                table: "Listings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Elevator",
                table: "Listings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Furnished",
                table: "Listings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parking",
                table: "Listings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balcony",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Elevator",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Furnished",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "Listings");

            migrationBuilder.AddColumn<bool>(
                name: "HasBalcony",
                table: "Listings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasElevator",
                table: "Listings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasParking",
                table: "Listings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFurnished",
                table: "Listings",
                type: "boolean",
                nullable: true);
        }
    }
}
