using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.Persistence.Contexts.Template.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Example",
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
                    principalTable: "Example",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ExampleDescription");

        migrationBuilder.DropTable(
            name: "Example");
    }
}
