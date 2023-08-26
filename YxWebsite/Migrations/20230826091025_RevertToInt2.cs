using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YxWebsite.Migrations
{
    /// <inheritdoc />
    public partial class RevertToInt2 : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
