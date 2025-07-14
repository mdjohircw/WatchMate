using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class userPackages_table_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPackage_Users_UserId",
                table: "UserPackage");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPackage",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPackage_UserId",
                table: "UserPackage",
                newName: "IX_UserPackage_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPackage_CustomerInfo_CustomerId",
                table: "UserPackage",
                column: "CustomerId",
                principalTable: "CustomerInfo",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPackage_CustomerInfo_CustomerId",
                table: "UserPackage");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "UserPackage",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPackage_CustomerId",
                table: "UserPackage",
                newName: "IX_UserPackage_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPackage_Users_UserId",
                table: "UserPackage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
