using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuffyMate.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ReportedById",
                schema: "application",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "ReportedById",
                schema: "application",
                table: "Reports",
                newName: "ReporterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportedById",
                schema: "application",
                table: "Reports",
                newName: "IX_Reports_ReporterUserId");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                schema: "authentication",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                schema: "application",
                table: "Reports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReportedUserId",
                schema: "application",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "application",
                table: "Pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                schema: "application",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedUserId",
                schema: "application",
                table: "Reports",
                column: "ReportedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ReportedUserId",
                schema: "application",
                table: "Reports",
                column: "ReportedUserId",
                principalSchema: "authentication",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ReporterUserId",
                schema: "application",
                table: "Reports",
                column: "ReporterUserId",
                principalSchema: "authentication",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ReportedUserId",
                schema: "application",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ReporterUserId",
                schema: "application",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReportedUserId",
                schema: "application",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                schema: "authentication",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsResolved",
                schema: "application",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportedUserId",
                schema: "application",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "application",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsRead",
                schema: "application",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ReporterUserId",
                schema: "application",
                table: "Reports",
                newName: "ReportedById");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReporterUserId",
                schema: "application",
                table: "Reports",
                newName: "IX_Reports_ReportedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ReportedById",
                schema: "application",
                table: "Reports",
                column: "ReportedById",
                principalSchema: "authentication",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
