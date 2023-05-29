using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.Persistence.Contexts.Template.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "template");

            migrationBuilder.CreateTable(
                name: "Example",
                schema: "template",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExampleDescription",
                schema: "template",
                columns: table => new
                {
                    ExampleAggregateRootId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleDescription", x => x.ExampleAggregateRootId);
                    table.ForeignKey(
                        name: "FK_ExampleDescription_Example_ExampleAggregateRootId",
                        column: x => x.ExampleAggregateRootId,
                        principalSchema: "template",
                        principalTable: "Example",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleDescription",
                schema: "template");

            migrationBuilder.DropTable(
                name: "Example",
                schema: "template");
        }
    }
}
