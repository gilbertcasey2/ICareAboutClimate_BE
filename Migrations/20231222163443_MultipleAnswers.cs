using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICareAboutClimateBE.Migrations
{
    /// <inheritdoc />
    public partial class MultipleAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "answerIndex",
                table: "individualQuestionResponses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "answerIndexes",
                table: "individualQuestionResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isMultipleChoice",
                table: "individualQuestionResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "otherAnswer",
                table: "individualQuestionResponses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "answerIndexes",
                table: "individualQuestionResponses");

            migrationBuilder.DropColumn(
                name: "isMultipleChoice",
                table: "individualQuestionResponses");

            migrationBuilder.DropColumn(
                name: "otherAnswer",
                table: "individualQuestionResponses");

            migrationBuilder.AlterColumn<int>(
                name: "answerIndex",
                table: "individualQuestionResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
