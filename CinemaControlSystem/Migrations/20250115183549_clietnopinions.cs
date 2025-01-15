using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaControlSystem.Migrations
{
    /// <inheritdoc />
    public partial class clietnopinions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientOpinion_ClientProfiles_ClientProfileId",
                table: "ClientOpinion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientOpinion",
                table: "ClientOpinion");

            migrationBuilder.RenameTable(
                name: "ClientOpinion",
                newName: "ClientOpinions");

            migrationBuilder.RenameIndex(
                name: "IX_ClientOpinion_ClientProfileId",
                table: "ClientOpinions",
                newName: "IX_ClientOpinions_ClientProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientOpinions",
                table: "ClientOpinions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientOpinions_ClientProfiles_ClientProfileId",
                table: "ClientOpinions",
                column: "ClientProfileId",
                principalTable: "ClientProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientOpinions_ClientProfiles_ClientProfileId",
                table: "ClientOpinions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientOpinions",
                table: "ClientOpinions");

            migrationBuilder.RenameTable(
                name: "ClientOpinions",
                newName: "ClientOpinion");

            migrationBuilder.RenameIndex(
                name: "IX_ClientOpinions_ClientProfileId",
                table: "ClientOpinion",
                newName: "IX_ClientOpinion_ClientProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientOpinion",
                table: "ClientOpinion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientOpinion_ClientProfiles_ClientProfileId",
                table: "ClientOpinion",
                column: "ClientProfileId",
                principalTable: "ClientProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
