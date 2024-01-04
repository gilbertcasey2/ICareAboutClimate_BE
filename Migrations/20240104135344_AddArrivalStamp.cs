using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICareAboutClimateBE.Migrations
{
    /// <inheritdoc />
    public partial class AddArrivalStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "arrivalTimeStamp",
                table: "formResponses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "arrivalTimeStamp",
                table: "formResponses");
        }
    }
}
