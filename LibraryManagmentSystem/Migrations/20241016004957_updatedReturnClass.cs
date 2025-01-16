using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatedReturnClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Return",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BooksCheckedOuts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReturnId",
                table: "BooksCheckedOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BooksCheckedOuts_ReturnId",
                table: "BooksCheckedOuts",
                column: "ReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCheckedOuts_Return_ReturnId",
                table: "BooksCheckedOuts",
                column: "ReturnId",
                principalTable: "Return",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCheckedOuts_Return_ReturnId",
                table: "BooksCheckedOuts");

            migrationBuilder.DropIndex(
                name: "IX_BooksCheckedOuts_ReturnId",
                table: "BooksCheckedOuts");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Return");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BooksCheckedOuts");

            migrationBuilder.DropColumn(
                name: "ReturnId",
                table: "BooksCheckedOuts");
        }
    }
}
