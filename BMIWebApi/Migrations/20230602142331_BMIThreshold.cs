using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class BMIThreshold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Index",
                table: "BMIThresholds",
                newName: "IndexTo");

            migrationBuilder.AddColumn<double>(
                name: "IndexFrom",
                table: "BMIThresholds",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndexFrom",
                table: "BMIThresholds");

            migrationBuilder.RenameColumn(
                name: "IndexTo",
                table: "BMIThresholds",
                newName: "Index");

        }
    }
}
