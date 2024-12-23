using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NodeApl.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSamples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_Nodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Nodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samples_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "FullName", "ParentId", "Type" },
                values: new object[,]
                {
                    { 1, "Шаблоны", null, "Шаблон" },
                    { 2, "Изделия", null, "Изделие" },
                    { 3, "Документы", null, "Документ" },
                    { 4, "Шаблон 1", 1, "Шаблон" },
                    { 5, "Шаблон 2", 1, "Шаблон" },
                    { 6, "Шаблон 3", 1, "Шаблон" },
                    { 7, "Изделие 1", 2, "Изделие" },
                    { 8, "Изделие 2", 2, "Изделие" },
                    { 9, "Документ 1", 3, "Документ" },
                    { 10, "Документ 2", 3, "Документ" },
                    { 11, "Документ 3", 3, "Документ" },
                    { 12, "Документ 4", 3, "Документ" }
                });

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "FullName", "NodeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 1", 4 },
                    { 2, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 1", 4 },
                    { 3, new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 1", 4 },
                    { 4, new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 1", 4 },
                    { 5, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 1", 4 },
                    { 6, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 2", 5 },
                    { 7, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 2", 5 },
                    { 8, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 2", 5 },
                    { 9, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 2", 5 },
                    { 10, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 3", 6 },
                    { 11, new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 3", 6 },
                    { 12, new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 3", 6 },
                    { 13, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 3", 6 },
                    { 14, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 3", 6 },
                    { 15, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 3", 6 },
                    { 16, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 3", 6 },
                    { 17, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Шаблона 3", 6 },
                    { 18, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Изделия 1", 7 },
                    { 19, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Изделия 1", 7 },
                    { 20, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Изделия 1", 7 },
                    { 21, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Изделия 1", 7 },
                    { 22, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Изделия 1", 7 },
                    { 23, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Изделия 2", 8 },
                    { 24, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Изделия 2", 8 },
                    { 25, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Изделия 2", 8 },
                    { 26, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Документа 1", 9 },
                    { 27, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Документа 1", 9 },
                    { 28, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Документа 2", 10 },
                    { 29, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Документа 2", 10 },
                    { 30, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Документа 3", 11 },
                    { 31, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Документа 3", 11 },
                    { 32, new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Документа 4", 12 },
                    { 33, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Описание Документа 4", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_NodeId",
                table: "Samples",
                column: "NodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
