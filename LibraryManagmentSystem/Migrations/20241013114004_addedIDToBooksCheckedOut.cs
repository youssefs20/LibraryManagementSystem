using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedIDToBooksCheckedOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksReturned_BooksCheckedOuts_BooksCheckedOutCheckOutId_BooksCheckedOutBookId",
                table: "BooksReturned");

            migrationBuilder.DropIndex(
                name: "IX_BooksReturned_BooksCheckedOutCheckOutId_BooksCheckedOutBookId",
                table: "BooksReturned");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksCheckedOuts",
                table: "BooksCheckedOuts");

            migrationBuilder.DropColumn(
                name: "returnedBooksCount",
                table: "CheckOuts");

            migrationBuilder.DropColumn(
                name: "BooksCheckedOutBookId",
                table: "BooksReturned");

            migrationBuilder.DropColumn(
                name: "BooksCheckedOutCheckOutId",
                table: "BooksReturned");

            migrationBuilder.AddColumn<int>(
                name: "BooksCheckedOutId",
                table: "BooksReturned",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BooksCheckedOuts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksCheckedOuts",
                table: "BooksCheckedOuts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BooksReturned_BooksCheckedOutId",
                table: "BooksReturned",
                column: "BooksCheckedOutId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksCheckedOuts_CheckOutId",
                table: "BooksCheckedOuts",
                column: "CheckOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksReturned_BooksCheckedOuts_BooksCheckedOutId",
                table: "BooksReturned",
                column: "BooksCheckedOutId",
                principalTable: "BooksCheckedOuts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksReturned_BooksCheckedOuts_BooksCheckedOutId",
                table: "BooksReturned");

            migrationBuilder.DropIndex(
                name: "IX_BooksReturned_BooksCheckedOutId",
                table: "BooksReturned");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksCheckedOuts",
                table: "BooksCheckedOuts");

            migrationBuilder.DropIndex(
                name: "IX_BooksCheckedOuts_CheckOutId",
                table: "BooksCheckedOuts");

            migrationBuilder.DropColumn(
                name: "BooksCheckedOutId",
                table: "BooksReturned");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BooksCheckedOuts");

            migrationBuilder.AddColumn<int>(
                name: "returnedBooksCount",
                table: "CheckOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BooksCheckedOutBookId",
                table: "BooksReturned",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BooksCheckedOutCheckOutId",
                table: "BooksReturned",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksCheckedOuts",
                table: "BooksCheckedOuts",
                columns: new[] { "CheckOutId", "BookId" });

            migrationBuilder.CreateIndex(
                name: "IX_BooksReturned_BooksCheckedOutCheckOutId_BooksCheckedOutBookId",
                table: "BooksReturned",
                columns: new[] { "BooksCheckedOutCheckOutId", "BooksCheckedOutBookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BooksReturned_BooksCheckedOuts_BooksCheckedOutCheckOutId_BooksCheckedOutBookId",
                table: "BooksReturned",
                columns: new[] { "BooksCheckedOutCheckOutId", "BooksCheckedOutBookId" },
                principalTable: "BooksCheckedOuts",
                principalColumns: new[] { "CheckOutId", "BookId" });
        }
    }
}
