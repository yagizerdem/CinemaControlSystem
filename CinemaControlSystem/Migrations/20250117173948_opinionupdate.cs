using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaControlSystem.Migrations
{
    /// <inheritdoc />
    public partial class opinionupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opinion",
                table: "ClientOpinions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opinion",
                table: "ClientOpinions");
        }
    }
}
