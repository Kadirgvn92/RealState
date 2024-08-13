using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class SellerDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sellers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sellers");
        }
    }
}
