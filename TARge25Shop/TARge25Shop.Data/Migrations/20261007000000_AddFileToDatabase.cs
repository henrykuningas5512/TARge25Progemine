using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TARge25Shop.Data;

#nullable disable

namespace TARge25Shop.Data.Migrations
{
    [DbContext(typeof(TARge25ShopContext))]
    [Migration("20261007000000_AddFileToDatabase")]
    public partial class AddFileToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileToDatabases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    KindergardenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_FileToDatabases", x => x.Id));
            migrationBuilder.CreateIndex(
                name: "IX_FileToDatabases_KindergardenId",
                table: "FileToDatabases",
                column: "KindergardenId");

            migrationBuilder.CreateTable(
                name: "FileToApis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExistingFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindergardenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_FileToApis", x => x.Id));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "FileToDatabases");
            migrationBuilder.DropTable(name: "FileToApis");
        }
    }
}
