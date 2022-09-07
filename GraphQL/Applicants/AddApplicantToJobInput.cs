using HotChocolate.Types.Relay;
using RecruitmentBuddy.GraphQL.Data;

namespace RecruitmentBuddy.GraphQL.Applicants
{
    public record AddApplicantToJobInput(
        [ID(nameof(Job))] 
        int JobId,
        [ID(nameof(Applicant))] 
        int ApplicantId);
}