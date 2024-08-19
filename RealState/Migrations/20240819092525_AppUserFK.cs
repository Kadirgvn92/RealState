using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class AppUserFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Sellers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Quests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Portfolios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "FSBOs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "CalendarEvents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Buyers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_AppUserID",
                table: "Sellers",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_AppUserID",
                table: "Quests",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_AppUserID",
                table: "Portfolios",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_FSBOs_AppUserID",
                table: "FSBOs",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_AppUserID",
                table: "CalendarEvents",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_AppUserID",
                table: "Buyers",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_AppUsers_AppUserID",
                table: "Buyers",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "AppUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvents_AppUsers_AppUserID",
                table: "CalendarEvents",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "AppUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FSBOs_AppUsers_AppUserID",
                table: "FSBOs",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "AppUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_AppUsers_AppUserID",
                table: "Portfolios",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "AppUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_AppUsers_AppUserID",
                table: "Quests",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "AppUserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_AppUsers_AppUserID",
                table: "Sellers",
                column: "AppUserID",
                principalTable: "AppUsers",
                principalColumn: "AppUserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_AppUsers_AppUserID",
                table: "Buyers");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvents_AppUsers_AppUserID",
                table: "CalendarEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_FSBOs_AppUsers_AppUserID",
                table: "FSBOs");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_AppUsers_AppUserID",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_AppUsers_AppUserID",
                table: "Quests");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AppUsers_AppUserID",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_AppUserID",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Quests_AppUserID",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_AppUserID",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_FSBOs_AppUserID",
                table: "FSBOs");

            migrationBuilder.DropIndex(
                name: "IX_CalendarEvents_AppUserID",
                table: "CalendarEvents");

            migrationBuilder.DropIndex(
                name: "IX_Buyers_AppUserID",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "FSBOs");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Buyers");
        }
    }
}
