namespace RecruitmentBuddy.GraphQL.Applicants
{
    public record RegisterApplicantInput(
        string FirstName,
        string LastName,
        string UserName,
        string EmailAddress,
        string Password,
        string Qualification,
        string JobStatus,
        string? AboutMe
    );
}