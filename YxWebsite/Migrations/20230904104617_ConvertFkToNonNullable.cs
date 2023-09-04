using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YxWebsite.Migrations
{
    /// <inheritdoc />
    public partial class ConvertFkToNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLanguageCottage_DbLanguageCottageCategory_LcCategoryId",
                table: "DbLanguageCottage");

            migrationBuilder.AlterColumn<int>(
                name: "LcCategoryId",
                table: "DbLanguageCottage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLanguageCottage_DbLanguageCottageCategory_LcCategoryId",
                table: "DbLanguageCottage",
                column: "LcCategoryId",
                principalTable: "DbLanguageCottageCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLanguageCottage_DbLanguageCottageCategory_LcCategoryId",
                table: "DbLanguageCottage");

            migrationBuilder.AlterColumn<int>(
                name: "LcCategoryId",
                table: "DbLanguageCottage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DbLanguageCottage_DbLanguageCottageCategory_LcCategoryId",
                table: "DbLanguageCottage",
                column: "LcCategoryId",
                principalTable: "DbLanguageCottageCategory",
                principalColumn: "Id");
        }
    }
}
