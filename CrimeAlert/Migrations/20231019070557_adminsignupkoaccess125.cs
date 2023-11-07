using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeAlert.Migrations
{
    /// <inheritdoc />
    public partial class adminsignupkoaccess125 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Signupspolice_ID",
                table: "User_Crimealerts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_Crimealerts_Signupspolice_ID",
                table: "User_Crimealerts",
                column: "Signupspolice_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Crimealerts_User_Signupspolice_ID",
                table: "User_Crimealerts",
                column: "Signupspolice_ID",
                principalTable: "User",
                principalColumn: "police_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Crimealerts_User_Signupspolice_ID",
                table: "User_Crimealerts");

            migrationBuilder.DropIndex(
                name: "IX_User_Crimealerts_Signupspolice_ID",
                table: "User_Crimealerts");

            migrationBuilder.DropColumn(
                name: "Signupspolice_ID",
                table: "User_Crimealerts");
        }
    }
}
