using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace How2CSS.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id_Level = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    TasksCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKLevel", x => x.Id_Level);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    Password = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    Role = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUser", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    Id_UserAchievement = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "TEXT", unicode: false, maxLength: 500, nullable: true),
                    IdLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    SaveDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUserAchievement", x => x.Id_UserAchievement);
                    table.ForeignKey(
                        name: "R_1",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "R_3",
                        column: x => x.IdLevel,
                        principalTable: "Levels",
                        principalColumn: "Id_Level",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AchievementDatas",
                columns: table => new
                {
                    Id_AchievementData = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompletedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CorrectCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentMark = table.Column<int>(type: "INTEGER", nullable: false),
                    TryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUserAchievement = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKAchievementData", x => x.Id_AchievementData);
                    table.ForeignKey(
                        name: "R_2",
                        column: x => x.IdUserAchievement,
                        principalTable: "UserAchievements",
                        principalColumn: "Id_UserAchievement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "TasksCount", "Title" },
                values: new object[] { 1, 30, "CSS_Part1" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "TasksCount", "Title" },
                values: new object[] { 2, 30, "CSS_Part2" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "TasksCount", "Title" },
                values: new object[] { 3, 30, "CSS_Part3" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "TasksCount", "Title" },
                values: new object[] { 4, 30, "CSS_Part4" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "TasksCount", "Title" },
                values: new object[] { 5, 30, "CSS_Part5" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 1, "ilivocs@gmail.com", "Oksana", "Iliv", "_Aa123456", "0123456789", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 2, "turyanmykh@gmail.com", "Mykhailo", "Turianskyi", "_Aa123456", "1234567890", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 3, "stasenoleks@gmail.com", "Oleksandr", "Stasenko", "_Aa123456", "2345678901", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 4, "pynzynyura@gmail.com", "Yurii", "Pynzyn", "_Aa123456", "3456789012", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 5, "hladyoandr@gmail.com", "Andrii", "Hlado", "_Aa123456", "4567890123", "User" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 1, 1, 1, "Need to learn margin", new DateTime(2020, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task1 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 2, 2, 1, "Need to learn padding", new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task2 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 3, 3, 1, "Need to learn border", new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task3 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 4, 4, 1, "Need to learn links", new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task4 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 5, 5, 1, "Need to learn tables", new DateTime(2020, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task5 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 6, 1, 2, "Need to learn position", new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task1 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 7, 2, 2, "Need to learn float", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task2 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 8, 3, 2, "Need to learn align", new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task3 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 9, 4, 2, "Need to learn opacity", new DateTime(2020, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task4 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 10, 5, 2, "Need to learn forms", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task5 Achivement" });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 1, 15, 12, 24, 1, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 28, 24, 19, 38, 10, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 27, 28, 23, 46, 9, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 26, 25, 20, 40, 9, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 25, 22, 17, 34, 9, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 24, 26, 21, 42, 8, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 23, 23, 18, 36, 8, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 22, 20, 15, 30, 8, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 21, 24, 19, 38, 7, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 20, 21, 16, 32, 7, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 19, 18, 13, 26, 7, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 18, 22, 17, 34, 6, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 17, 19, 14, 28, 6, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 16, 16, 11, 22, 6, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 15, 29, 26, 52, 5, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 14, 26, 23, 46, 5, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 13, 23, 20, 40, 5, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 12, 27, 24, 48, 4, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 11, 24, 21, 42, 4, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 10, 21, 18, 36, 4, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 9, 25, 22, 44, 3, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 8, 22, 19, 38, 3, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 7, 19, 16, 32, 3, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 6, 23, 20, 40, 2, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 5, 20, 17, 34, 2, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 4, 17, 14, 28, 2, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 3, 21, 18, 36, 1, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 2, 18, 15, 30, 1, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 29, 27, 22, 44, 10, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 30, 30, 25, 50, 10, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementDatas_IdUserAchievement",
                table: "AchievementDatas",
                column: "IdUserAchievement");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_IdLevel",
                table: "UserAchievements",
                column: "IdLevel");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_IdUser",
                table: "UserAchievements",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievementDatas");

            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
