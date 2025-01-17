using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaControlSystem.Migrations
{
    /// <inheritdoc />
    public partial class opinionupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opinion",
                table: "ClientOpinions",
                newName: "Header");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "ClientOpinions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "ClientOpinions");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "ClientOpinions",
                newName: "Opinion");
        }
    }
}
