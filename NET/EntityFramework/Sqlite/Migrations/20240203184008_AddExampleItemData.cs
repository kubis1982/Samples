using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddExampleItemData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExampleItemData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    ExampleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleItemData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleItemData_ExampleDatas_ExampleId",
                        column: x => x.ExampleId,
                        principalTable: "ExampleDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExampleItemData_ExampleId",
                table: "ExampleItemData",
                column: "ExampleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleItemData");
        }
    }
}
