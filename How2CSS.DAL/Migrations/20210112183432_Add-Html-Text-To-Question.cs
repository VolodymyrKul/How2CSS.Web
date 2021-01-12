using Microsoft.EntityFrameworkCore.Migrations;

namespace How2CSS.DAL.Migrations
{
    public partial class AddHtmlTextToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HtmlText",
                table: "Questions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlText",
                table: "Questions");
        }
    }
}
