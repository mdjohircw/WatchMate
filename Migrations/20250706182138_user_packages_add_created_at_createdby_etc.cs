using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class user_packages_add_created_at_createdby_etc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPackage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "UserPackage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "UserPackage",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "UserPackage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "UserPackage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerDayWatchedVideo",
                table: "UserPackage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserPackage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "UserPackage",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserPackage");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserPackage");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "UserPackage");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "UserPackage");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserPackage");

            migrationBuilder.DropColumn(
                name: "PerDayWatchedVideo",
                table: "UserPackage");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserPackage");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserPackage");
        }
    }
}
