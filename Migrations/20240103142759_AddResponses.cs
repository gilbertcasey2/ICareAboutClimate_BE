using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICareAboutClimateBE.Migrations
{
    /// <inheritdoc />
    public partial class AddResponses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "individualQuestionResponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionIndex = table.Column<int>(type: "int", nullable: false),
                    answerIndex = table.Column<int>(type: "int", nullable: true),
                    answerIndexes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otherAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isFinalResponse = table.Column<bool>(type: "bit", nullable: true),
                    isMultipleChoice = table.Column<bool>(type: "bit", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    formResponseid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_individualQuestionResponses", x => x.id);
                    table.ForeignKey(
                        name: "FK_individualQuestionResponses_formResponses_formResponseid",
                        column: x => x.formResponseid,
                        principalTable: "formResponses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inProgressQuestionResponses",
                columns: table => new
                {
                    progressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionIndex = table.Column<int>(type: "int", nullable: false),
                    answerIndex = table.Column<int>(type: "int", nullable: true),
                    answerIndexes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otherAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isFinalResponse = table.Column<bool>(type: "bit", nullable: true),
                    isMultipleChoice = table.Column<bool>(type: "bit", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    formResponseid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inProgressQuestionResponses", x => x.progressId);
                    table.ForeignKey(
                        name: "FK_inProgressQuestionResponses_formResponses_formResponseid",
                        column: x => x.formResponseid,
                        principalTable: "formResponses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_individualQuestionResponses_formResponseid",
                table: "individualQuestionResponses",
                column: "formResponseid");

            migrationBuilder.CreateIndex(
                name: "IX_inProgressQuestionResponses_formResponseid",
                table: "inProgressQuestionResponses",
                column: "formResponseid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "individualQuestionResponses");

            migrationBuilder.DropTable(
                name: "inProgressQuestionResponses");
        }
    }
}
