using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using RecruitmentBuddy.GraphQL.Data;
using RecruitmentBuddy.GraphQL.Extensions;

namespace RecruitmentBuddy.GraphQL.Jobs
{
    [ExtendObjectType(Name = "Mutation")]
    public class JobMutations
    {
        [UseApplicationDbContext]
        public async Task<RegisterJobPayload> RegisterJobAsync(
            RegisterJobInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var job = new Job
            {
                Name = input.Name,
                Company = input.Company
            };

            context.Jobs.Add(job);

            await context.SaveChangesAsync(cancellationToken);

            return new RegisterJobPayload(job);
        }
    }
}