using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class userId_and_packageId_foreginKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPackage_Users_UsersUserId",
                table: "UserPackage");

            migrationBuilder.DropIndex(
                name: "IX_UserPackage_UsersUserId",
                table: "UserPackage");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "UserPackage");

            migrationBuilder.CreateIndex(
                name: "IX_UserPackage_UserId",
                table: "UserPackage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPackage_Users_UserId",
                table: "UserPackage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPackage_Users_UserId",
                table: "UserPackage");

            migrationBuilder.DropIndex(
                name: "IX_UserPackage_UserId",
                table: "UserPackage");

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "UserPackage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserPackage_UsersUserId",
                table: "UserPackage",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPackage_Users_UsersUserId",
                table: "UserPackage",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
