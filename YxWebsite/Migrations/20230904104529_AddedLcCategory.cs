using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YxWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddedLcCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RecordId",
                table: "DbLanguageCottage",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,3)");

            migrationBuilder.AddColumn<int>(
                name: "LcCategoryId",
                table: "DbLanguageCottage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "DbJapaneseDictionary",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "DbJapaneseDictionary",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DbLanguageCottageCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbLanguageCottageCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbLanguageCottage_LcCategoryId",
                table: "DbLanguageCottage",
                column: "LcCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbLanguageCottage_DbLanguageCottageCategory_LcCategoryId",
                table: "DbLanguageCottage",
                column: "LcCategoryId",
                principalTable: "DbLanguageCottageCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLanguageCottage_DbLanguageCottageCategory_LcCategoryId",
                table: "DbLanguageCottage");

            migrationBuilder.DropTable(
                name: "DbLanguageCottageCategory");

            migrationBuilder.DropIndex(
                name: "IX_DbLanguageCottage_LcCategoryId",
                table: "DbLanguageCottage");

            migrationBuilder.DropColumn(
                name: "LcCategoryId",
                table: "DbLanguageCottage");

            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "DbJapaneseDictionary");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "DbJapaneseDictionary");

            migrationBuilder.AlterColumn<decimal>(
                name: "RecordId",
                table: "DbLanguageCottage",
                type: "decimal(4,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
