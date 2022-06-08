using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beispiel.Anwendung.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BaseProperty = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level2Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Level2Property = table.Column<string>(type: "TEXT", nullable: true),
                    IsCondition = table.Column<bool>(type: "INTEGER", nullable: false),
                    BaseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level2Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Level2Models_BaseModels_BaseId",
                        column: x => x.BaseId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Level3Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Level3Property = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Level2Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level3Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Level3Models_Level2Models_Level2Id",
                        column: x => x.Level2Id,
                        principalTable: "Level2Models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Level4Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Level4Property = table.Column<string>(type: "TEXT", nullable: true),
                    ListProperty = table.Column<string>(type: "TEXT", nullable: true),
                    Level2Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    Level3Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level4Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Level4Models_Level2Models_Level2Id",
                        column: x => x.Level2Id,
                        principalTable: "Level2Models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Level4Models_Level3Models_Level3Id",
                        column: x => x.Level3Id,
                        principalTable: "Level3Models",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BaseModels",
                columns: new[] { "Id", "BaseProperty", "Description", "Name", "Status" },
                values: new object[] { new Guid("4f4305bb-17ab-4a42-a1b2-f706573fa850"), "Base Property", "Base Description", "Base Name", 1 });

            migrationBuilder.InsertData(
                table: "Level2Models",
                columns: new[] { "Id", "BaseId", "Description", "IsCondition", "Level2Property", "Name", "Status" },
                values: new object[] { new Guid("18262137-dd04-4977-93cf-f2698ae7d900"), new Guid("4f4305bb-17ab-4a42-a1b2-f706573fa850"), "Level2 Description", true, "Level2 Property", "Level2 Name", 1 });

            migrationBuilder.InsertData(
                table: "Level3Models",
                columns: new[] { "Id", "Description", "Level2Id", "Level3Property", "Name", "Number", "Status" },
                values: new object[] { new Guid("324cdcbf-6486-4e62-81c4-65196a6f52ca"), "Level3 Description", new Guid("18262137-dd04-4977-93cf-f2698ae7d900"), "Level3 Property", "Level3 Name", 42, 1 });

            migrationBuilder.InsertData(
                table: "Level4Models",
                columns: new[] { "Id", "Description", "Level2Id", "Level3Id", "Level4Property", "ListProperty", "Name", "Status" },
                values: new object[] { new Guid("8f0cf5b8-9420-4441-ab6a-e25a78fd738e"), "Level4 Description", new Guid("18262137-dd04-4977-93cf-f2698ae7d900"), new Guid("324cdcbf-6486-4e62-81c4-65196a6f52ca"), "Level4 Property", "[\"Value 1\",\"Value 2\"]", "Level4 Name", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Level2Models_BaseId",
                table: "Level2Models",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Level3Models_Level2Id",
                table: "Level3Models",
                column: "Level2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Level4Models_Level2Id",
                table: "Level4Models",
                column: "Level2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Level4Models_Level3Id",
                table: "Level4Models",
                column: "Level3Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Level4Models");

            migrationBuilder.DropTable(
                name: "Level3Models");

            migrationBuilder.DropTable(
                name: "Level2Models");

            migrationBuilder.DropTable(
                name: "BaseModels");
        }
    }
}
