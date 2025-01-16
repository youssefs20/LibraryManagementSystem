using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedReturnedBooksClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Profile_ProfileId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Books_ProfileId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "Return");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Return");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Profile",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_UserId",
                table: "Profile",
                newName: "IX_Profile_MemberId");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "BooksCheckedOuts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BooksReturned",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnId = table.Column<int>(type: "int", nullable: false),
                    BooksCheckedOutCheckOutId = table.Column<int>(type: "int", nullable: true),
                    BooksCheckedOutBookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksReturned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksReturned_BooksCheckedOuts_BooksCheckedOutCheckOutId_BooksCheckedOutBookId",
                        columns: x => new { x.BooksCheckedOutCheckOutId, x.BooksCheckedOutBookId },
                        principalTable: "BooksCheckedOuts",
                        principalColumns: new[] { "CheckOutId", "BookId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksCheckedOuts_ProfileId",
                table: "BooksCheckedOuts",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksReturned_BooksCheckedOutCheckOutId_BooksCheckedOutBookId",
                table: "BooksReturned",
                columns: new[] { "BooksCheckedOutCheckOutId", "BooksCheckedOutBookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCheckedOuts_Profile_ProfileId",
                table: "BooksCheckedOuts",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_MemberId",
                table: "Profile",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCheckedOuts_Profile_ProfileId",
                table: "BooksCheckedOuts");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_MemberId",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "BooksReturned");

            migrationBuilder.DropIndex(
                name: "IX_BooksCheckedOuts_ProfileId",
                table: "BooksCheckedOuts");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "BooksCheckedOuts");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Profile",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_MemberId",
                table: "Profile",
                newName: "IX_Profile_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "Return",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Return",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ProfileId",
                table: "Books",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Profile_ProfileId",
                table: "Books",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
