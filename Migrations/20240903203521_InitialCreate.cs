using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend_assignment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    FirstAnswerId = table.Column<int>(type: "integer", nullable: false),
                    SecondAnswerId = table.Column<int>(type: "integer", nullable: false),
                    ThirdAnswerId = table.Column<int>(type: "integer", nullable: false),
                    FourthAnswerId = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Answer_CorrectAnswerId",
                        column: x => x.CorrectAnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Answer_FirstAnswerId",
                        column: x => x.FirstAnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Answer_FourthAnswerId",
                        column: x => x.FourthAnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Answer_SecondAnswerId",
                        column: x => x.SecondAnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Answer_ThirdAnswerId",
                        column: x => x.ThirdAnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionPaper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Q1Id = table.Column<int>(type: "integer", nullable: false),
                    Q2Id = table.Column<int>(type: "integer", nullable: false),
                    Q3Id = table.Column<int>(type: "integer", nullable: false),
                    Q4Id = table.Column<int>(type: "integer", nullable: false),
                    Q5Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPaper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionPaper_Questions_Q1Id",
                        column: x => x.Q1Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionPaper_Questions_Q2Id",
                        column: x => x.Q2Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionPaper_Questions_Q3Id",
                        column: x => x.Q3Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionPaper_Questions_Q4Id",
                        column: x => x.Q4Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionPaper_Questions_Q5Id",
                        column: x => x.Q5Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionPaperId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_QuestionPaper_QuestionPaperId",
                        column: x => x.QuestionPaperId,
                        principalTable: "QuestionPaper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    Q1AnswerId = table.Column<int>(type: "integer", nullable: true),
                    Q2AnswerId = table.Column<int>(type: "integer", nullable: true),
                    Q3AnswerId = table.Column<int>(type: "integer", nullable: true),
                    Q4AnswerId = table.Column<int>(type: "integer", nullable: true),
                    Q5AnswerId = table.Column<int>(type: "integer", nullable: true),
                    ExamId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responses_Answer_Q1AnswerId",
                        column: x => x.Q1AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responses_Answer_Q2AnswerId",
                        column: x => x.Q2AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responses_Answer_Q3AnswerId",
                        column: x => x.Q3AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responses_Answer_Q4AnswerId",
                        column: x => x.Q4AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responses_Answer_Q5AnswerId",
                        column: x => x.Q5AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responses_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExamId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    MaxScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { 1, "Mumbai" },
                    { 2, "Delhi" },
                    { 3, "Chennai" },
                    { 4, "Banglore" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CorrectAnswerId", "FirstAnswerId", "FourthAnswerId", "SecondAnswerId", "ThirdAnswerId" },
                values: new object[] { 1, "What is the capital of India?", 1, 1, 4, 2, 3 });

            migrationBuilder.InsertData(
                table: "QuestionPaper",
                columns: new[] { "Id", "Q1Id", "Q2Id", "Q3Id", "Q4Id", "Q5Id" },
                values: new object[] { 1, 1, 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "QuestionPaperId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_QuestionPaperId",
                table: "Exams",
                column: "QuestionPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPaper_Q1Id",
                table: "QuestionPaper",
                column: "Q1Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPaper_Q2Id",
                table: "QuestionPaper",
                column: "Q2Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPaper_Q3Id",
                table: "QuestionPaper",
                column: "Q3Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPaper_Q4Id",
                table: "QuestionPaper",
                column: "Q4Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPaper_Q5Id",
                table: "QuestionPaper",
                column: "Q5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CorrectAnswerId",
                table: "Questions",
                column: "CorrectAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FirstAnswerId",
                table: "Questions",
                column: "FirstAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FourthAnswerId",
                table: "Questions",
                column: "FourthAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SecondAnswerId",
                table: "Questions",
                column: "SecondAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ThirdAnswerId",
                table: "Questions",
                column: "ThirdAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_ExamId",
                table: "Responses",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_Q1AnswerId",
                table: "Responses",
                column: "Q1AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_Q2AnswerId",
                table: "Responses",
                column: "Q2AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_Q3AnswerId",
                table: "Responses",
                column: "Q3AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_Q4AnswerId",
                table: "Responses",
                column: "Q4AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_Q5AnswerId",
                table: "Responses",
                column: "Q5AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_StudentId",
                table: "Responses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ExamId",
                table: "Results",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "QuestionPaper");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Answer");
        }
    }
}
