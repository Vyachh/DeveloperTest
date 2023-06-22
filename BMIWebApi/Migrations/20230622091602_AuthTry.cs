using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AuthTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Pacients",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Pacients",
                newName: "Password");
        }
    }
}
