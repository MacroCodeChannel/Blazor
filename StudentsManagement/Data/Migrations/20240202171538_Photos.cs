using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsManagement.Migrations
{
    /// <inheritdoc />
    public partial class Photos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Photo",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Photo",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Parents");
        }
    }
}
