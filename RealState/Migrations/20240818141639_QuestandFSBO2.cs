using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Migrations
{
    /// <inheritdoc />
    public partial class QuestandFSBO2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quest_RealEstateCategories_RealEstateCategoryID",
                table: "Quest");

            migrationBuilder.DropForeignKey(
                name: "FK_Quest_RealEstateStatuses_RealEstateStatusID",
                table: "Quest");

            migrationBuilder.DropForeignKey(
                name: "FK_Quest_RealEstateTypes_RealEstateTypeID",
                table: "Quest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quest",
                table: "Quest");

            migrationBuilder.RenameTable(
                name: "Quest",
                newName: "Quests");

            migrationBuilder.RenameIndex(
                name: "IX_Quest_RealEstateTypeID",
                table: "Quests",
                newName: "IX_Quests_RealEstateTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Quest_RealEstateStatusID",
                table: "Quests",
                newName: "IX_Quests_RealEstateStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Quest_RealEstateCategoryID",
                table: "Quests",
                newName: "IX_Quests_RealEstateCategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quests",
                table: "Quests",
                column: "QuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_RealEstateCategories_RealEstateCategoryID",
                table: "Quests",
                column: "RealEstateCategoryID",
                principalTable: "RealEstateCategories",
                principalColumn: "RealEstateCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_RealEstateStatuses_RealEstateStatusID",
                table: "Quests",
                column: "RealEstateStatusID",
                principalTable: "RealEstateStatuses",
                principalColumn: "RealEstateStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_RealEstateTypes_RealEstateTypeID",
                table: "Quests",
                column: "RealEstateTypeID",
                principalTable: "RealEstateTypes",
                principalColumn: "RealEstateTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_RealEstateCategories_RealEstateCategoryID",
                table: "Quests");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_RealEstateStatuses_RealEstateStatusID",
                table: "Quests");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_RealEstateTypes_RealEstateTypeID",
                table: "Quests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quests",
                table: "Quests");

            migrationBuilder.RenameTable(
                name: "Quests",
                newName: "Quest");

            migrationBuilder.RenameIndex(
                name: "IX_Quests_RealEstateTypeID",
                table: "Quest",
                newName: "IX_Quest_RealEstateTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Quests_RealEstateStatusID",
                table: "Quest",
                newName: "IX_Quest_RealEstateStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Quests_RealEstateCategoryID",
                table: "Quest",
                newName: "IX_Quest_RealEstateCategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quest",
                table: "Quest",
                column: "QuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quest_RealEstateCategories_RealEstateCategoryID",
                table: "Quest",
                column: "RealEstateCategoryID",
                principalTable: "RealEstateCategories",
                principalColumn: "RealEstateCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quest_RealEstateStatuses_RealEstateStatusID",
                table: "Quest",
                column: "RealEstateStatusID",
                principalTable: "RealEstateStatuses",
                principalColumn: "RealEstateStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quest_RealEstateTypes_RealEstateTypeID",
                table: "Quest",
                column: "RealEstateTypeID",
                principalTable: "RealEstateTypes",
                principalColumn: "RealEstateTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
