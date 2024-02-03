using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddExampleItemSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExampleItemData_ExampleDatas_ExampleId",
                table: "ExampleItemData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExampleItemData",
                table: "ExampleItemData");

            migrationBuilder.RenameTable(
                name: "ExampleItemData",
                newName: "ExampleItemDatas");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleItemData_ExampleId",
                table: "ExampleItemDatas",
                newName: "IX_ExampleItemDatas_ExampleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExampleItemDatas",
                table: "ExampleItemDatas",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ExampleDatas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nazwa1" },
                    { 2, "Nazwa2" },
                    { 3, "Nazwa3" },
                    { 4, "Nazwa4" }
                });

            migrationBuilder.InsertData(
                table: "ExampleItemDatas",
                columns: new[] { "Id", "ExampleId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Nazwa1" },
                    { 2, 4, "Nazwa4" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExampleItemDatas_ExampleDatas_ExampleId",
                table: "ExampleItemDatas",
                column: "ExampleId",
                principalTable: "ExampleDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExampleItemDatas_ExampleDatas_ExampleId",
                table: "ExampleItemDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExampleItemDatas",
                table: "ExampleItemDatas");

            migrationBuilder.DeleteData(
                table: "ExampleDatas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExampleDatas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExampleItemDatas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExampleItemDatas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExampleDatas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExampleDatas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "ExampleItemDatas",
                newName: "ExampleItemData");

            migrationBuilder.RenameIndex(
                name: "IX_ExampleItemDatas_ExampleId",
                table: "ExampleItemData",
                newName: "IX_ExampleItemData_ExampleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExampleItemData",
                table: "ExampleItemData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExampleItemData_ExampleDatas_ExampleId",
                table: "ExampleItemData",
                column: "ExampleId",
                principalTable: "ExampleDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
