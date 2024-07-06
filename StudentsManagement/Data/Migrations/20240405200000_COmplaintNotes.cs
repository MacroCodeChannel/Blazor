using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsManagement.Migrations
{
    /// <inheritdoc />
    public partial class COmplaintNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionStatusId",
                table: "ComplaintNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintNotes_ActionStatusId",
                table: "ComplaintNotes",
                column: "ActionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintNotes_SystemCodeDetails_ActionStatusId",
                table: "ComplaintNotes",
                column: "ActionStatusId",
                principalTable: "SystemCodeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintNotes_SystemCodeDetails_ActionStatusId",
                table: "ComplaintNotes");

            migrationBuilder.DropIndex(
                name: "IX_ComplaintNotes_ActionStatusId",
                table: "ComplaintNotes");

            migrationBuilder.DropColumn(
                name: "ActionStatusId",
                table: "ComplaintNotes");
        }
    }
}
