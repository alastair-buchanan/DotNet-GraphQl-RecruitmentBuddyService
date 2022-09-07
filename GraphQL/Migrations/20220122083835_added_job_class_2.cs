using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentBuddy.GraphQL.Migrations
{
    public partial class added_job_class_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Name",
                table: "Jobs",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jobs_Name",
                table: "Jobs");
        }
    }
}
