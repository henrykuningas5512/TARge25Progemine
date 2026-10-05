using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARge25Shop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Kindergarden5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExistingFilePath",
                table: "Kindergarden");

            migrationBuilder.DropColumn(
                name: "SpaceshipId",
                table: "Kindergarden");

            migrationBuilder.RenameTable(
                name: "FileToApi",
                newName: "FileToApis");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "FileToApis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ExistingFilePath",
                table: "FileToApis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpaceshipId",
                table: "FileToApis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileToApis",
                table: "FileToApis",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FileToApis",
                table: "FileToApis");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FileToApis");

            migrationBuilder.DropColumn(
                name: "ExistingFilePath",
                table: "FileToApis");

            migrationBuilder.DropColumn(
                name: "SpaceshipId",
                table: "FileToApis");

            migrationBuilder.RenameTable(
                name: "FileToApis",
                newName: "FileToApi");

            migrationBuilder.AddColumn<string>(
                name: "ExistingFilePath",
                table: "Kindergarden",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpaceshipId",
                table: "Kindergarden",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
