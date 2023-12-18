using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICareAboutClimateBE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "formResponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    formIndex = table.Column<int>(type: "int", nullable: true),
                    storeageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formResponses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "individualQuestionResponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionIndex = table.Column<int>(type: "int", nullable: false),
                    answerIndex = table.Column<int>(type: "int", nullable: false),
                    isFinalResponse = table.Column<bool>(type: "bit", nullable: true),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormResponseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_individualQuestionResponses", x => x.id);
                    table.ForeignKey(
                        name: "FK_individualQuestionResponses_formResponses_FormResponseid",
                        column: x => x.FormResponseid,
                        principalTable: "formResponses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_individualQuestionResponses_FormResponseid",
                table: "individualQuestionResponses",
                column: "FormResponseid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "individualQuestionResponses");

            migrationBuilder.DropTable(
                name: "formResponses");
        }
    }
}
