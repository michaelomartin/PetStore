using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetStore.Services.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_IPetType_PetTypeId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "IPetType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PetTypes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_PetTypeId",
                table: "Pets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PetTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "IPetType",
                columns: table => new
                {
                    TempId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_IPetType_TempId", x => x.TempId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_IPetType_PetTypeId",
                table: "Pets",
                column: "PetTypeId",
                principalTable: "IPetType",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
