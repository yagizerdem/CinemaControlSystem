using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaControlSystem.Migrations
{
    /// <inheritdoc />
    public partial class timestapms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_AppUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_AppUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "ClientProfileId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ClientProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ClientProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "openAddress",
                table: "ClientProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "preferancesCsv",
                table: "ClientProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "profileImgUrl",
                table: "ClientProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "rememberLogIn",
                table: "ClientProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "showEmail",
                table: "ClientProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BossProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BossProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ClientOpinion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientProfileId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOpinion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientOpinion_ClientProfiles_ClientProfileId",
                        column: x => x.ClientProfileId,
                        principalTable: "ClientProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ClientProfileId",
                table: "Reports",
                column: "ClientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOpinion_ClientProfileId",
                table: "ClientOpinion",
                column: "ClientProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ClientProfiles_ClientProfileId",
                table: "Reports",
                column: "ClientProfileId",
                principalTable: "ClientProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ClientProfiles_ClientProfileId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "ClientOpinion");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ClientProfileId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ClientProfileId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "openAddress",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "preferancesCsv",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "profileImgUrl",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "rememberLogIn",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "showEmail",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BossProfiles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BossProfiles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AppUserId",
                table: "Reports",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_AppUserId",
                table: "Reports",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
