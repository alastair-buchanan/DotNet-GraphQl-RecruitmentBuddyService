using HotChocolate.Types.Relay;
using RecruitmentBuddy.GraphQL.Data;

namespace RecruitmentBuddy.GraphQL.Jobs
{
    public record RegisterJobInput(
        string Name,
        Company Company
    );
}