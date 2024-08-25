using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hero_csharp.Migrations
{
    /// <inheritdoc />
    public partial class Hero4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_SuperPowers_SuperpowerId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_SuperpowerId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "SuperpowerId",
                table: "Heroes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperPowers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "School",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HeroSuperPower",
                columns: table => new
                {
                    HeroesId = table.Column<int>(type: "int", nullable: false),
                    SuperPowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSuperPower", x => new { x.HeroesId, x.SuperPowersId });
                    table.ForeignKey(
                        name: "FK_HeroSuperPower_Heroes_HeroesId",
                        column: x => x.HeroesId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroSuperPower_SuperPowers_SuperPowersId",
                        column: x => x.SuperPowersId,
                        principalTable: "SuperPowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroSuperPower_SuperPowersId",
                table: "HeroSuperPower",
                column: "SuperPowersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroSuperPower");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperPowers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "School",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SuperpowerId",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_SuperpowerId",
                table: "Heroes",
                column: "SuperpowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_SuperPowers_SuperpowerId",
                table: "Heroes",
                column: "SuperpowerId",
                principalTable: "SuperPowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
