using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using RecruitmentBuddy.GraphQL.Data;
using RecruitmentBuddy.GraphQL.DataLoader;
using RecruitmentBuddy.GraphQL.Extensions;

namespace RecruitmentBuddy.GraphQL.Types
{
    public class JobType : ObjectType<Job>
    {
        protected override void Configure(IObjectTypeDescriptor<Job> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) =>
                    ctx.DataLoader<JobByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
            
            descriptor
                .Field(t => t.JobApplicants)
                .ResolveWith<JobResolvers>(t => t.GetApplicantsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("applicants");
            
            descriptor
                .Field(t => t.Id)
                .ID(nameof(Applicant));
        }
        
        private class JobResolvers
        {
            public async Task<IEnumerable<Applicant>> GetApplicantsAsync(
                Job job,
                [ScopedService] ApplicationDbContext dbContext,
                ApplicantByIdDataLoader applicantById,
                CancellationToken cancellationToken)
            {
                int[] jobIds = await dbContext.Jobs
                    .Where(s => s.Id == job.Id)
                    .Include(s => s.JobApplicants)
                    .SelectMany(s => s.JobApplicants.Select(t => t.ApplicantId))
                    .ToArrayAsync();

                return await applicantById.LoadAsync(jobIds, cancellationToken);
            }
        }
    }
}