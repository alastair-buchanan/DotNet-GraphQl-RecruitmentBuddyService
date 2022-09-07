using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentBuddy.GraphQL.Migrations
{
    public partial class add_applicants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantJob_Applicant_ApplicantsId",
                table: "ApplicantJob");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantJob_Job_JobsId",
                table: "ApplicantJob");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingLanguage_Applicant_ApplicantId",
                table: "ProgrammingLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgrammingLanguage",
                table: "ProgrammingLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicant",
                table: "Applicant");

            migrationBuilder.RenameTable(
                name: "ProgrammingLanguage",
                newName: "ProgrammingLanguages");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companys");

            migrationBuilder.RenameTable(
                name: "Applicant",
                newName: "Applicants");

            migrationBuilder.RenameIndex(
                name: "IX_ProgrammingLanguage_ApplicantId",
                table: "ProgrammingLanguages",
                newName: "IX_ProgrammingLanguages_ApplicantId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_CompanyId",
                table: "Jobs",
                newName: "IX_Jobs_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgrammingLanguages",
                table: "ProgrammingLanguages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantJob_Applicants_ApplicantsId",
                table: "ApplicantJob",
                column: "ApplicantsId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantJob_Jobs_JobsId",
                table: "ApplicantJob",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Companys_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingLanguages_Applicants_ApplicantId",
                table: "ProgrammingLanguages",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantJob_Applicants_ApplicantsId",
                table: "ApplicantJob");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantJob_Jobs_JobsId",
                table: "ApplicantJob");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Companys_CompanyId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingLanguages_Applicants_ApplicantId",
                table: "ProgrammingLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgrammingLanguages",
                table: "ProgrammingLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.RenameTable(
                name: "ProgrammingLanguages",
                newName: "ProgrammingLanguage");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Applicants",
                newName: "Applicant");

            migrationBuilder.RenameIndex(
                name: "IX_ProgrammingLanguages_ApplicantId",
                table: "ProgrammingLanguage",
                newName: "IX_ProgrammingLanguage_ApplicantId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CompanyId",
                table: "Job",
                newName: "IX_Job_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgrammingLanguage",
                table: "ProgrammingLanguage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicant",
                table: "Applicant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantJob_Applicant_ApplicantsId",
                table: "ApplicantJob",
                column: "ApplicantsId",
                principalTable: "Applicant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantJob_Job_JobsId",
                table: "ApplicantJob",
                column: "JobsId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Company_CompanyId",
                table: "Job",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingLanguage_Applicant_ApplicantId",
                table: "ProgrammingLanguage",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
