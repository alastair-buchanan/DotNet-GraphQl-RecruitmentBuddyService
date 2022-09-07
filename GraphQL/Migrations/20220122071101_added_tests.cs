using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentBuddy.GraphQL.Migrations
{
    public partial class added_tests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantJob");

            migrationBuilder.DropTable(
                name: "SessionAttendee");

            migrationBuilder.DropTable(
                name: "SessionSpeaker");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.CreateTable(
                name: "JobApplicant",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplicant", x => new { x.JobId, x.ApplicantId });
                    table.ForeignKey(
                        name: "FK_JobApplicant_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplicant_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_UserName",
                table: "Applicants",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplicant_ApplicantId",
                table: "JobApplicant",
                column: "ApplicantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplicant");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_UserName",
                table: "Applicants");

            migrationBuilder.CreateTable(
                name: "ApplicantJob",
                columns: table => new
                {
                    ApplicantsId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantJob", x => new { x.ApplicantsId, x.JobsId });
                    table.ForeignKey(
                        name: "FK_ApplicantJob_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantJob_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bio = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Website = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Abstract = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    EndTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionAttendee",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttendeeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAttendee", x => new { x.SessionId, x.AttendeeId });
                    table.ForeignKey(
                        name: "FK_SessionAttendee_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionAttendee_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionSpeaker",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeakerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSpeaker", x => new { x.SessionId, x.SpeakerId });
                    table.ForeignKey(
                        name: "FK_SessionSpeaker_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSpeaker_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJob_JobsId",
                table: "ApplicantJob",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_UserName",
                table: "Attendees",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttendee_AttendeeId",
                table: "SessionAttendee",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TrackId",
                table: "Sessions",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSpeaker_SpeakerId",
                table: "SessionSpeaker",
                column: "SpeakerId");
        }
    }
}
