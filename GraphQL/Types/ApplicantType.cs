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
    public class ApplicantType : ObjectType<Applicant>
    {
        protected override void Configure(IObjectTypeDescriptor<Applicant> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) =>
                    ctx.DataLoader<ApplicantByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
            
            /*descriptor
                .Field(t => t.JobApplicants)
                .ResolveWith<ApplicantResolvers>(t => t.GetApplicantsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("applicants");
            
            descriptor
                .Field(t => t.Applicant)
                .ResolveWith<ApplicantResolvers>(t => t.GetTrackAsync(default!, default!, default));

            descriptor
                .Field(t => t.TrackId)
                .ID(nameof(Track));*/

            descriptor
                .Field(t => t.Id)
                .ID(nameof(Applicant));
        }
        
        /*private class ApplicantResolvers
        {
            public async Task<IEnumerable<Applicant>> GetJobsAsync(
                Applicant applicant,
                [ScopedService] ApplicationDbContext dbContext,
                JobByIdDataLoader jobById,
                CancellationToken cancellationToken)
            {
                int[] jobIds = await dbContext.Applicants
                    .Where(s => s.Id == applicant.Id)
                    .Include(s => s.JobApplicants)
                    .SelectMany(s => s.JobApplicants.Select(t => t.JobId))
                    .ToArrayAsync();

                return await jobById.LoadAsync(jobIds, cancellationToken);
            }
            
            public async Task<Applicant?> GetApplicantAsync(
                Applicant applicant,
                ApplicantByIdDataLoader trackById,
                CancellationToken cancellationToken)
            {
                if (!applicant.Id is null)
                {
                    return null;
                }

                return await trackById.LoadAsync(applicant.Id, cancellationToken);
            }
        }*/
    }
}