using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class Notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    BuyerID = table.Column<int>(type: "integer", nullable: true),
                    SellerID = table.Column<int>(type: "integer", nullable: true),
                    QuestID = table.Column<int>(type: "integer", nullable: true),
                    FSBOId = table.Column<int>(type: "integer", nullable: true),
                    PortfolioID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_Buyers_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Buyers",
                        principalColumn: "BuyerID");
                    table.ForeignKey(
                        name: "FK_Notifications_FSBOs_FSBOId",
                        column: x => x.FSBOId,
                        principalTable: "FSBOs",
                        principalColumn: "FSBOId");
                    table.ForeignKey(
                        name: "FK_Notifications_Portfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioID");
                    table.ForeignKey(
                        name: "FK_Notifications_Quests_QuestID",
                        column: x => x.QuestID,
                        principalTable: "Quests",
                        principalColumn: "QuestID");
                    table.ForeignKey(
                        name: "FK_Notifications_Sellers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Sellers",
                        principalColumn: "SellerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_BuyerID",
                table: "Notifications",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FSBOId",
                table: "Notifications",
                column: "FSBOId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PortfolioID",
                table: "Notifications",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_QuestID",
                table: "Notifications",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SellerID",
                table: "Notifications",
                column: "SellerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
