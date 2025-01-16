using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class BooksReturned_ReturnId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BooksReturned_ReturnId",
                table: "BooksReturned",
                column: "ReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksReturned_Return_ReturnId",
                table: "BooksReturned",
                column: "ReturnId",
                principalTable: "Return",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksReturned_Return_ReturnId",
                table: "BooksReturned");

            migrationBuilder.DropIndex(
                name: "IX_BooksReturned_ReturnId",
                table: "BooksReturned");
        }
    }
}
