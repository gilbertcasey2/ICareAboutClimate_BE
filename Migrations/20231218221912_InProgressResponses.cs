using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICareAboutClimateBE.Migrations
{
    /// <inheritdoc />
    public partial class InProgressResponses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormResponseid1",
                table: "individualQuestionResponses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_individualQuestionResponses_FormResponseid1",
                table: "individualQuestionResponses",
                column: "FormResponseid1");

            migrationBuilder.AddForeignKey(
                name: "FK_individualQuestionResponses_formResponses_FormResponseid1",
                table: "individualQuestionResponses",
                column: "FormResponseid1",
                principalTable: "formResponses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_individualQuestionResponses_formResponses_FormResponseid1",
                table: "individualQuestionResponses");

            migrationBuilder.DropIndex(
                name: "IX_individualQuestionResponses_FormResponseid1",
                table: "individualQuestionResponses");

            migrationBuilder.DropColumn(
                name: "FormResponseid1",
                table: "individualQuestionResponses");
        }
    }
}
