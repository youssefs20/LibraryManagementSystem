using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddingStatusToCheckOuts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOuts_AspNetUsers_LibrarianId",
                table: "CheckOuts");

            migrationBuilder.AlterColumn<string>(
                name: "LibrarianId",
                table: "CheckOuts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "CheckOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "img",
                table: "Books",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOuts_AspNetUsers_LibrarianId",
                table: "CheckOuts",
                column: "LibrarianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOuts_AspNetUsers_LibrarianId",
                table: "CheckOuts");

            migrationBuilder.DropColumn(
                name: "status",
                table: "CheckOuts");

            migrationBuilder.AlterColumn<string>(
                name: "LibrarianId",
                table: "CheckOuts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "img",
                table: "Books",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOuts_AspNetUsers_LibrarianId",
                table: "CheckOuts",
                column: "LibrarianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
