using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeApl.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersSamples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Samples");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Samples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 19,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 20,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 21,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 22,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 23,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 24,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 25,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 26,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 27,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 28,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 29,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 30,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 31,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 32,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 33,
                column: "UserId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Samples_UserId",
                table: "Samples",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samples_Users_UserId",
                table: "Samples",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samples_Users_UserId",
                table: "Samples");

            migrationBuilder.DropIndex(
                name: "IX_Samples_UserId",
                table: "Samples");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Samples");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Samples",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedBy",
                value: "Антон");

            migrationBuilder.UpdateData(
                table: "Samples",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedBy",
                value: "Антон");
        }
    }
}
