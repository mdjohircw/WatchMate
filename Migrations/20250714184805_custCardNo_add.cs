using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class custCardNo_add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustCardNo",
                table: "CustomerInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfo_CustCardNo",
                table: "CustomerInfo",
                column: "CustCardNo",
                unique: true,
                filter: "[CustCardNo] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerInfo_CustCardNo",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "CustCardNo",
                table: "CustomerInfo");
        }
    }
}
