using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YxWebsite.Migrations
{
    /// <inheritdoc />
    public partial class ChangeHashToSalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "DbLogin",
                newName: "Salt");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "DbLogin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "DbLogin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "DbLogin");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "DbLogin");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "DbLogin",
                newName: "Hash");
        }
    }
}
