using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentBuddy.GraphQL.Migrations
{
    public partial class RefactoringNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applicants_UserName",
                table: "Applicants");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_FirstName",
                table: "Applicants",
                column: "FirstName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applicants_FirstName",
                table: "Applicants");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_UserName",
                table: "Applicants",
                column: "UserName",
                unique: true);
        }
    }
}
