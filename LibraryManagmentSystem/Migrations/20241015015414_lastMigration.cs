using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class lastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksReturned_BooksCheckedOuts_BooksCheckedOutId",
                table: "BooksReturned");

            migrationBuilder.DropIndex(
                name: "IX_BooksReturned_BooksCheckedOutId",
                table: "BooksReturned");

            migrationBuilder.DropColumn(
                name: "BooksCheckedOutId",
                table: "BooksReturned");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "UsersBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "UsersBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "BooksReturned",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "BooksReturned",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "BooksCheckedOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "UsersBooks");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "UsersBooks");

            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "BooksReturned");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "BooksReturned");

            migrationBuilder.DropColumn(
                name: "status",
                table: "BooksCheckedOuts");

            migrationBuilder.AddColumn<int>(
                name: "BooksCheckedOutId",
                table: "BooksReturned",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BooksReturned_BooksCheckedOutId",
                table: "BooksReturned",
                column: "BooksCheckedOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksReturned_BooksCheckedOuts_BooksCheckedOutId",
                table: "BooksReturned",
                column: "BooksCheckedOutId",
                principalTable: "BooksCheckedOuts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
