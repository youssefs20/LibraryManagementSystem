using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class EnablingCancelToCheckOuts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCheckedOuts_Profile_ProfileId",
                table: "BooksCheckedOuts");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "BooksCheckedOuts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCheckedOuts_Profile_ProfileId",
                table: "BooksCheckedOuts",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCheckedOuts_Profile_ProfileId",
                table: "BooksCheckedOuts");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "BooksCheckedOuts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCheckedOuts_Profile_ProfileId",
                table: "BooksCheckedOuts",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id");
        }
    }
}
