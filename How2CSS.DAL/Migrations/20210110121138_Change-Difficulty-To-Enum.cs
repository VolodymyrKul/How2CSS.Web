using Microsoft.EntityFrameworkCore.Migrations;

namespace How2CSS.DAL.Migrations
{
    public partial class ChangeDifficultyToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id_Level",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id_Level",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id_Level",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id_Level",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskDistributions",
                keyColumn: "Id_TaskDistribution",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id_Level",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "TaskDifficulty",
                table: "TaskDistributions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LevelDifficulty",
                table: "Levels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskDifficulty",
                table: "TaskDistributions",
                type: "TEXT",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "LevelDifficulty",
                table: "Levels",
                type: "TEXT",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "LevelDifficulty", "TasksCount", "Title" },
                values: new object[] { 1, "Hard", 30, "CSS_Part1" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "LevelDifficulty", "TasksCount", "Title" },
                values: new object[] { 2, "Hard", 30, "CSS_Part2" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "LevelDifficulty", "TasksCount", "Title" },
                values: new object[] { 3, "Hard", 30, "CSS_Part3" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "LevelDifficulty", "TasksCount", "Title" },
                values: new object[] { 4, "Hard", 30, "CSS_Part4" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "LevelDifficulty", "TasksCount", "Title" },
                values: new object[] { 5, "Hard", 30, "CSS_Part5" });

            migrationBuilder.InsertData(
                table: "TaskDistributions",
                columns: new[] { "Id_TaskDistribution", "IdLevel", "IdTask", "TaskDifficulty", "TaskOrder" },
                values: new object[] { 1, 1, 1, "CSS", 1 });
        }
    }
}
