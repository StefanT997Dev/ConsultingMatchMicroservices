using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class OneToManyForUserReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MentorId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MentorId",
                table: "Reviews",
                column: "MentorId");

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
                name: "FK_Reviews_AspNetUsers_MentorId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MentorId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Reviews");
        }
    }
}
