using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class packages_table_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerDayWatchedVideo",
                table: "CustomerPackage");

            migrationBuilder.DropColumn(
                name: "TotalAdsWatched",
                table: "CustomerPackage");

            migrationBuilder.AddColumn<int>(
                name: "MinDailyViews",
                table: "Package",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinDailyViews",
                table: "Package");

            migrationBuilder.AddColumn<int>(
                name: "PerDayWatchedVideo",
                table: "CustomerPackage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAdsWatched",
                table: "CustomerPackage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
