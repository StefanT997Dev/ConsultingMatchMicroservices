using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class DeleteAspNetRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE \"public\".\"AspNetUserRoles\" CASCADE");

            migrationBuilder.Sql("DROP TABLE \"public\".\"AspNetRoles\" CASCADE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
