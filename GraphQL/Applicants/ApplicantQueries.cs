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

namespace RecruitmentBuddy.GraphQL.Applicants
{
    [ExtendObjectType(Name = "Query")]
    public class ApplicantQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public IQueryable<Applicant> GetApplicants(
            [ScopedService] ApplicationDbContext context) =>
            context.Applicants;

        [UseApplicationDbContext]
        public Task<Applicant> GetApplicantsByIdAsync(
            [ID(nameof(Applicant))]int id,
            ApplicantByIdDataLoader applicantById,
            CancellationToken cancellationToken) =>
            applicantById.LoadAsync(id, cancellationToken);

        [UseApplicationDbContext]
        public async Task<IEnumerable<Applicant>> GetApplicantsByIdAsync(
            [ID(nameof(Applicant))]int[] ids,
            ApplicantByIdDataLoader applicantById,
            CancellationToken cancellationToken) =>
            await applicantById.LoadAsync(ids, cancellationToken);
        
        public Task<Applicant> GetTrackByIdAsync(
            [ID(nameof(Applicant))] int id,
            ApplicantByIdDataLoader trackById,
            CancellationToken cancellationToken) =>
            trackById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Applicant>> GetTracksByIdAsync(
            [ID(nameof(Applicant))] int[] ids,
            ApplicantByIdDataLoader trackById,
            CancellationToken cancellationToken) =>
            await trackById.LoadAsync(ids, cancellationToken);
    }
}