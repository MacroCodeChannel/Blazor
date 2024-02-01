using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsManagement.Migrations
{
    /// <inheritdoc />
    public partial class BookIssuanceStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "BookIssuanceHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookIssuanceHistory_StatusId",
                table: "BookIssuanceHistory",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssuanceHistory_SystemCodeDetails_StatusId",
                table: "BookIssuanceHistory",
                column: "StatusId",
                principalTable: "SystemCodeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssuanceHistory_SystemCodeDetails_StatusId",
                table: "BookIssuanceHistory");

            migrationBuilder.DropIndex(
                name: "IX_BookIssuanceHistory_StatusId",
                table: "BookIssuanceHistory");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "BookIssuanceHistory");
        }
    }
}
