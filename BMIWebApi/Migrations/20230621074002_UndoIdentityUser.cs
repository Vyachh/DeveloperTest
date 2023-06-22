using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UndoIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Pacients");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Pacients");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Pacients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Pacients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Pacients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Pacients",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Pacients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Pacients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
