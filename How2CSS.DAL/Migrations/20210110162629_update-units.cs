using Microsoft.EntityFrameworkCore.Migrations;

namespace How2CSS.DAL.Migrations
{
    public partial class updateunits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDifficulty",
                table: "TaskDistributions");

            migrationBuilder.AddColumn<int>(
                name: "TaskDifficulty",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDifficulty",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskDifficulty",
                table: "TaskDistributions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
