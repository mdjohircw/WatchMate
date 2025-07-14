using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class adVideo_packageId_add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdVideo_Package_PackageId",
                table: "AdVideo");

            migrationBuilder.DropIndex(
                name: "IX_AdVideo_PackageId",
                table: "AdVideo");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "AdVideo");

            migrationBuilder.AddColumn<string>(
                name: "PackageIds",
                table: "AdVideo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageIds",
                table: "AdVideo");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "AdVideo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AdVideo_PackageId",
                table: "AdVideo",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdVideo_Package_PackageId",
                table: "AdVideo",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
