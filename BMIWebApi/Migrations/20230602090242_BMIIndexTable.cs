using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class BMIIndexTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Pacients");

            migrationBuilder.CreateTable(
                name: "BMIIndex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientID = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMIIndex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BMIIndex_Pacients_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BMIIndex_PacientID",
                table: "BMIIndex",
                column: "PacientID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BMIIndex");

            migrationBuilder.AddColumn<double>(
                name: "Index",
                table: "Pacients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
