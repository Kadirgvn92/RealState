using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Buyers_BuyerID",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_BuyerID",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "BuyerID",
                table: "Portfolios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerID",
                table: "Portfolios",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_BuyerID",
                table: "Portfolios",
                column: "BuyerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Buyers_BuyerID",
                table: "Portfolios",
                column: "BuyerID",
                principalTable: "Buyers",
                principalColumn: "BuyerID");
        }
    }
}
