using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalRoster6.Migrations
{
    public partial class AddedOneToManyAnimalCaretaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Handler",
                table: "Animals",
                newName: "CaretakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CaretakerId",
                table: "Animals",
                column: "CaretakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Caretakers_CaretakerId",
                table: "Animals",
                column: "CaretakerId",
                principalTable: "Caretakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Caretakers_CaretakerId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CaretakerId",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "CaretakerId",
                table: "Animals",
                newName: "Handler");
        }
    }
}
