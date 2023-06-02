using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class BMIIndexTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BMIIndexId",
                table: "Pacients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BMIIndexId",
                table: "Pacients");
        }
    }
}
