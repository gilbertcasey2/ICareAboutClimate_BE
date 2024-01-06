using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICareAboutClimateBE.Migrations
{
    /// <inheritdoc />
    public partial class ClearOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "individualQuestionResponses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "individualQuestionResponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    formResponseid = table.Column<int>(type: "int", nullable: false),
                    answerIndex = table.Column<int>(type: "int", nullable: true),
                    answerIndexes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isFinalResponse = table.Column<bool>(type: "bit", nullable: true),
                    isMultipleChoice = table.Column<bool>(type: "bit", nullable: false),
                    otherAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    questionIndex = table.Column<int>(type: "int", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_individualQuestionResponses_formResponseid",
                table: "individualQuestionResponses",
                column: "formResponseid");
        }
    }
}
