using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab19_CreateAnAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TodoListID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Todos_TodoList_TodoListID",
                        column: x => x.TodoListID,
                        principalTable: "TodoList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TodoList",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Tre's Todo List" });

            migrationBuilder.InsertData(
                table: "TodoList",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Shawn's Todo List" });

            migrationBuilder.InsertData(
                table: "TodoList",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Lebron's Todo List" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "ID", "Description", "Name", "TodoListID" },
                values: new object[,]
                {
                    { 1, "Wash all the clothes in the hamper", "Wash Clothes", 1 },
                    { 3, "Take all trash bags to the dumpster", "Throw Trash", 2 },
                    { 4, "Clean all dust off dresser", "Dust Dresser", 2 },
                    { 2, "Clean the toilet and bathtub", "Clean Bathroom", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_TodoListID",
                table: "Todos",
                column: "TodoListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "TodoList");
        }
    }
}
