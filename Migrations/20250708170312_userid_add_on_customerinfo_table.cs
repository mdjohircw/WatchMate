using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class userid_add_on_customerinfo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "CustomerInfo");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CustomerInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfo_UserId",
                table: "CustomerInfo",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfo_Users_UserId",
                table: "CustomerInfo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_Users_UserId",
                table: "CustomerInfo");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInfo_UserId",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomerInfo");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CustomerInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "CustomerInfo",
                type: "nvarchar(150)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
