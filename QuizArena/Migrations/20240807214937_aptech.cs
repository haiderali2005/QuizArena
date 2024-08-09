using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizArena.Migrations
{
    public partial class aptech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_table_quizresults_table_Users_UserId",
                table: "table_quizresults");

            migrationBuilder.DropIndex(
                name: "IX_table_quizresults_UserId",
                table: "table_quizresults");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "table_quizresults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "table_quizresults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_table_quizresults_UserId",
                table: "table_quizresults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_table_quizresults_table_Users_UserId",
                table: "table_quizresults",
                column: "UserId",
                principalTable: "table_Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
