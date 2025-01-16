using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class returndate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOuts_AspNetUsers_MemberId",
                table: "CheckOuts");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "CheckOuts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BooksReturned",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOuts_AspNetUsers_MemberId",
                table: "CheckOuts",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOuts_AspNetUsers_MemberId",
                table: "CheckOuts");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BooksReturned");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "CheckOuts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOuts_AspNetUsers_MemberId",
                table: "CheckOuts",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
