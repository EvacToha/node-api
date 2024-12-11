using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NodeApl.API.Migrations
{
    /// <inheritdoc />
    public partial class ItitialCreate : Migration
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

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
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

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
