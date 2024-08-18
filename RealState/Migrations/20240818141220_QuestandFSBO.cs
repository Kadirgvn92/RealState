using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class QuestandFSBO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FSBOs",
                columns: table => new
                {
                    FSBOId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListingNumber = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FSBOs", x => x.FSBOId);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: true),
                    AddressLine = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longtitude = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RealEstateTypeID = table.Column<int>(type: "integer", nullable: false),
                    RealEstateCategoryID = table.Column<int>(type: "integer", nullable: false),
                    RealEstateStatusID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.QuestID);
                    table.ForeignKey(
                        name: "FK_Quest_RealEstateCategories_RealEstateCategoryID",
                        column: x => x.RealEstateCategoryID,
                        principalTable: "RealEstateCategories",
                        principalColumn: "RealEstateCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quest_RealEstateStatuses_RealEstateStatusID",
                        column: x => x.RealEstateStatusID,
                        principalTable: "RealEstateStatuses",
                        principalColumn: "RealEstateStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quest_RealEstateTypes_RealEstateTypeID",
                        column: x => x.RealEstateTypeID,
                        principalTable: "RealEstateTypes",
                        principalColumn: "RealEstateTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quest_RealEstateCategoryID",
                table: "Quest",
                column: "RealEstateCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Quest_RealEstateStatusID",
                table: "Quest",
                column: "RealEstateStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Quest_RealEstateTypeID",
                table: "Quest",
                column: "RealEstateTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FSBOs");

            migrationBuilder.DropTable(
                name: "Quest");
        }
    }
}
