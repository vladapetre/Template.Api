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
            name: "Template",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Status = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Template", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "TemplateDescription",
            columns: table => new
            {
                TemplateAggregateRootId = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TemplateDescription", x => x.TemplateAggregateRootId);
                table.ForeignKey(
                    name: "FK_TemplateDescription_Template_TemplateAggregateRootId",
                    column: x => x.TemplateAggregateRootId,
                    principalTable: "Template",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "TemplateDescription");

        migrationBuilder.DropTable(
            name: "Template");
    }
}
