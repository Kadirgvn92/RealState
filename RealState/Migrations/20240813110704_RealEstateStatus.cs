using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class RealEstateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealEstateStatusID",
                table: "Portfolios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RealEstateStatuses",
                columns: table => new
                {
                    RealEstateStatusID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateStatuses", x => x.RealEstateStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_RealEstateStatusID",
                table: "Portfolios",
                column: "RealEstateStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_RealEstateStatuses_RealEstateStatusID",
                table: "Portfolios",
                column: "RealEstateStatusID",
                principalTable: "RealEstateStatuses",
                principalColumn: "RealEstateStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_RealEstateStatuses_RealEstateStatusID",
                table: "Portfolios");

            migrationBuilder.DropTable(
                name: "RealEstateStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_RealEstateStatusID",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "RealEstateStatusID",
                table: "Portfolios");
        }
    }
}
