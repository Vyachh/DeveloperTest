using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class BMIIndexTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           



            migrationBuilder.DropForeignKey(
                name: "FK_BMIIndex_Pacients_PacientID",
                table: "BMIIndex");

            migrationBuilder.RenameColumn(
                name: "PacientID",
                table: "BMIIndex",
                newName: "PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_BMIIndex_PacientID",
                table: "BMIIndex",
                newName: "IX_BMIIndex_PacientId");

            migrationBuilder.AddForeignKey(
                name: "FK_BMIIndex_Pacients_PacientId",
                table: "BMIIndex",
                column: "PacientId",
                principalTable: "Pacients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BMIIndex_Pacients_PacientId",
                table: "BMIIndex");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                table: "BMIIndex",
                newName: "PacientID");

            migrationBuilder.RenameIndex(
                name: "IX_BMIIndex_PacientId",
                table: "BMIIndex",
                newName: "IX_BMIIndex_PacientID");

            migrationBuilder.AddForeignKey(
                name: "FK_BMIIndex_Pacients_PacientID",
                table: "BMIIndex",
                column: "PacientID",
                principalTable: "Pacients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
