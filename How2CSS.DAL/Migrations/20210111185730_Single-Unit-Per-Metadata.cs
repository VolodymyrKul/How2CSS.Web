using Microsoft.EntityFrameworkCore.Migrations;

namespace How2CSS.DAL.Migrations
{
    public partial class SingleUnitPerMetadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitDistributions");

            migrationBuilder.AddColumn<int>(
                name: "IdUnit",
                table: "Metadatas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUnitNavigationId",
                table: "Metadatas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metadatas_IdUnitNavigationId",
                table: "Metadatas",
                column: "IdUnitNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Metadatas_Units_IdUnitNavigationId",
                table: "Metadatas",
                column: "IdUnitNavigationId",
                principalTable: "Units",
                principalColumn: "Id_Unit",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metadatas_Units_IdUnitNavigationId",
                table: "Metadatas");

            migrationBuilder.DropIndex(
                name: "IX_Metadatas_IdUnitNavigationId",
                table: "Metadatas");

            migrationBuilder.DropColumn(
                name: "IdUnit",
                table: "Metadatas");

            migrationBuilder.DropColumn(
                name: "IdUnitNavigationId",
                table: "Metadatas");

            migrationBuilder.CreateTable(
                name: "UnitDistributions",
                columns: table => new
                {
                    Id_UnitDistribution = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMetadata = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUnit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUnitDistribution", x => x.Id_UnitDistribution);
                    table.ForeignKey(
                        name: "R_6",
                        column: x => x.IdUnit,
                        principalTable: "Units",
                        principalColumn: "Id_Unit",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "R_7",
                        column: x => x.IdMetadata,
                        principalTable: "Metadatas",
                        principalColumn: "Id_Metadata",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UnitDistributions",
                columns: new[] { "Id_UnitDistribution", "IdMetadata", "IdUnit" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UnitDistributions_IdMetadata",
                table: "UnitDistributions",
                column: "IdMetadata");

            migrationBuilder.CreateIndex(
                name: "IX_UnitDistributions_IdUnit",
                table: "UnitDistributions",
                column: "IdUnit");
        }
    }
}
