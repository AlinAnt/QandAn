using Microsoft.EntityFrameworkCore.Migrations;

namespace QandAn.Migrations
{
    public partial class dopquestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionTitle",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionTitle",
                table: "Questions");
        }
    }
}
