using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrimeAlert.Migrations
{
    /// <inheritdoc />
    public partial class signupsnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Crimealerts_User_Signupspolice_ID",
                table: "User_Crimealerts");

            migrationBuilder.AlterColumn<int>(
                name: "Signupspolice_ID",
                table: "User_Crimealerts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Crimealerts_User_Signupspolice_ID",
                table: "User_Crimealerts",
                column: "Signupspolice_ID",
                principalTable: "User",
                principalColumn: "police_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Crimealerts_User_Signupspolice_ID",
                table: "User_Crimealerts");

            migrationBuilder.AlterColumn<int>(
                name: "Signupspolice_ID",
                table: "User_Crimealerts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Crimealerts_User_Signupspolice_ID",
                table: "User_Crimealerts",
                column: "Signupspolice_ID",
                principalTable: "User",
                principalColumn: "police_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
