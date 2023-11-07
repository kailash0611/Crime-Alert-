using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeAlert.Migrations
{
    /// <inheritdoc />
    public partial class PictureColumnAddedincriminalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Admin_AddCriminals",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Admin_AddCriminals");
        }
    }
}
