using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCoreApiSamples.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    todo_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    todo_item_description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    todo_item_is_completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TodoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItem_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "todo_name" },
                values: new object[] { 1, "Project management" });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "todo_item_description", "todo_item_is_completed", "TodoId" },
                values: new object[] { 1, "Create a Database Context", false, 1 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "todo_item_description", "todo_item_is_completed", "TodoId" },
                values: new object[] { 2, "Create Todo entity", false, 1 });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "todo_item_description", "todo_item_is_completed", "TodoId" },
                values: new object[] { 3, "Create TodoItem entity", false, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_TodoId",
                table: "TodoItem",
                column: "TodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItem");

            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
