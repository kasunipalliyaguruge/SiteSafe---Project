using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteSafe4.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlertsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Alerts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Severity",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupervisorId",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Alerts");
        }
    }
}
