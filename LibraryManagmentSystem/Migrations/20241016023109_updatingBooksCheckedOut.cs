using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatingBooksCheckedOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCheckedOuts_Return_ReturnId",
                table: "BooksCheckedOuts");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnId",
                table: "BooksCheckedOuts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCheckedOuts_Return_ReturnId",
                table: "BooksCheckedOuts",
                column: "ReturnId",
                principalTable: "Return",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCheckedOuts_Return_ReturnId",
                table: "BooksCheckedOuts");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnId",
                table: "BooksCheckedOuts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCheckedOuts_Return_ReturnId",
                table: "BooksCheckedOuts",
                column: "ReturnId",
                principalTable: "Return",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
