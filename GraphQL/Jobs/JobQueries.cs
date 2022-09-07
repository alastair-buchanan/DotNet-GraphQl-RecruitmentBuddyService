using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using RecruitmentBuddy.GraphQL.Data;
using RecruitmentBuddy.GraphQL.DataLoader;
using RecruitmentBuddy.GraphQL.Extensions;

namespace RecruitmentBuddy.GraphQL.Jobs
{
    [ExtendObjectType(Name = "Query")]
    public class JobQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public IQueryable<Job> GetJobs(
            [ScopedService] ApplicationDbContext context) =>
            context.Jobs;

        public Task<Job> GetJobByIdAsync(
            [ID(nameof(Job))]int id,
            JobByIdDataLoader jobById,
            CancellationToken cancellationToken) =>
            jobById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Job>> GetJobsByIdAsync(
            [ID(nameof(Job))]int[] ids,
            JobByIdDataLoader jobById,
            CancellationToken cancellationToken) =>
            await jobById.LoadAsync(ids, cancellationToken);
    }
}