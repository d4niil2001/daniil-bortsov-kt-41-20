using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace daniil_bortsov_kt_41_20.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "Grades",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0,
                comment: "Год");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "Grades");
        }
    }
}
