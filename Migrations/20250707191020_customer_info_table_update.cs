using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class customer_info_table_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_Users_UserId",
                table: "CustomerInfo");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInfo_UserId",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomerInfo");

            migrationBuilder.RenameColumn(
                name: "CustomerInfoId",
                table: "CustomerInfo",
                newName: "CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "CustmerImage",
                table: "CustomerInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailOrPhone",
                table: "CustomerInfo",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustmerImage",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "EmailOrPhone",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "CustomerInfo");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerInfo",
                newName: "CustomerInfoId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CustomerInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

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
    }
}
