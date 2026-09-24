using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARge25Shop.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewWorkingMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Spaceships");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Spaceships",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
