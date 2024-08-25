using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hero_csharp.Migrations
{
    /// <inheritdoc />
    public partial class Hero1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_SuperPower_SuperpowerId",
                table: "Heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperPower",
                table: "SuperPower");

            migrationBuilder.RenameTable(
                name: "SuperPower",
                newName: "SuperPowers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperPowers",
                table: "SuperPowers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_SuperPowers_SuperpowerId",
                table: "Heroes",
                column: "SuperpowerId",
                principalTable: "SuperPowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_SuperPowers_SuperpowerId",
                table: "Heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperPowers",
                table: "SuperPowers");

            migrationBuilder.RenameTable(
                name: "SuperPowers",
                newName: "SuperPower");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperPower",
                table: "SuperPower",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_SuperPower_SuperpowerId",
                table: "Heroes",
                column: "SuperpowerId",
                principalTable: "SuperPower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
