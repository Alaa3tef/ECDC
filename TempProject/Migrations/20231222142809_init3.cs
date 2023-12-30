using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempProject.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "CorrectiveActions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandardId",
                table: "CorrectiveActions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "userID",
                table: "CorrectiveActions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_StandardId",
                table: "CorrectiveActions",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_userID",
                table: "CorrectiveActions",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_CorrectiveActions_AspNetUsers_userID",
                table: "CorrectiveActions",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CorrectiveActions_Standards_StandardId",
                table: "CorrectiveActions",
                column: "StandardId",
                principalTable: "Standards",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorrectiveActions_AspNetUsers_userID",
                table: "CorrectiveActions");

            migrationBuilder.DropForeignKey(
                name: "FK_CorrectiveActions_Standards_StandardId",
                table: "CorrectiveActions");

            migrationBuilder.DropIndex(
                name: "IX_CorrectiveActions_StandardId",
                table: "CorrectiveActions");

            migrationBuilder.DropIndex(
                name: "IX_CorrectiveActions_userID",
                table: "CorrectiveActions");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CorrectiveActions");

            migrationBuilder.DropColumn(
                name: "StandardId",
                table: "CorrectiveActions");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "CorrectiveActions");
        }
    }
}
