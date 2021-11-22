using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemovedMentorId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_MentorId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MentorId1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "MentorId1",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "MentorId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "MentorId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MentorId",
                table: "Reviews",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MentorId",
                table: "Posts",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_MentorId",
                table: "Posts",
                column: "MentorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_MentorId",
                table: "Reviews",
                column: "MentorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_MentorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_MentorId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MentorId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Posts_MentorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Posts");

            migrationBuilder.AlterColumn<Guid>(
                name: "MentorId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MentorId1",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MentorId1",
                table: "Reviews",
                column: "MentorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_MentorId1",
                table: "Reviews",
                column: "MentorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
