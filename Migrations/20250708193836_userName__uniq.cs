﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMate_API.Migrations
{
    /// <inheritdoc />
    public partial class userName__uniq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");
        }
    }
}
