using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizArena.Migrations
{
    public partial class newwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "table_Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuizImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_Quizzes", x => x.QuizId);
                });

            migrationBuilder.CreateTable(
                name: "table_Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "table_Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_table_Questions_table_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "table_Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table_quizresults",
                columns: table => new
                {
                    result_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: true),
                    TotalQuestions = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_quizresults", x => x.result_id);
                    table.ForeignKey(
                        name: "FK_table_quizresults_table_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "table_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table_Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_table_Options_table_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "table_Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table_UserProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    SelectedOptionId = table.Column<int>(type: "int", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    QuizId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_UserProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_table_UserProgresses_table_Options_SelectedOptionId",
                        column: x => x.SelectedOptionId,
                        principalTable: "table_Options",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_table_UserProgresses_table_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "table_Questions",
                        principalColumn: "QuestionId");
                    table.ForeignKey(
                        name: "FK_table_UserProgresses_table_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "table_Quizzes",
                        principalColumn: "QuizId");
                    table.ForeignKey(
                        name: "FK_table_UserProgresses_table_Quizzes_QuizId1",
                        column: x => x.QuizId1,
                        principalTable: "table_Quizzes",
                        principalColumn: "QuizId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_table_Options_QuestionId",
                table: "table_Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_table_Questions_QuizId",
                table: "table_Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_table_quizresults_UserId",
                table: "table_quizresults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_table_UserProgresses_QuestionId",
                table: "table_UserProgresses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_table_UserProgresses_QuizId",
                table: "table_UserProgresses",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_table_UserProgresses_QuizId1",
                table: "table_UserProgresses",
                column: "QuizId1");

            migrationBuilder.CreateIndex(
                name: "IX_table_UserProgresses_SelectedOptionId",
                table: "table_UserProgresses",
                column: "SelectedOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_quizresults");

            migrationBuilder.DropTable(
                name: "table_UserProgresses");

            migrationBuilder.DropTable(
                name: "table_Users");

            migrationBuilder.DropTable(
                name: "table_Options");

            migrationBuilder.DropTable(
                name: "table_Questions");

            migrationBuilder.DropTable(
                name: "table_Quizzes");
        }
    }
}
