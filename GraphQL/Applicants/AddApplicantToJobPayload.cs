using System.Threading;
using System.Threading.Tasks;
using RecruitmentBuddy.GraphQL.Common;
using RecruitmentBuddy.GraphQL.Data;
using RecruitmentBuddy.GraphQL.DataLoader;
using RecruitmentBuddy.GraphQL.Jobs;

namespace RecruitmentBuddy.GraphQL.Applicants
{
    public class AddApplicantToJobPayload : ApplicantPayloadBase
    {
        private int? _jobId;
        public AddApplicantToJobPayload(Applicant applicant, int jobId) : base(applicant)
        {
            _jobId = jobId;
        }

        public AddApplicantToJobPayload(UserError error) : base(new[] { error })
        {
        }

        public async Task<Job?> GetJobAsync(
            JobByIdDataLoader jobById,
            CancellationToken cancellationToken)
        {
            if (_jobId.HasValue)
            {
                return await jobById.LoadAsync(_jobId.Value, cancellationToken);
            }

            return null;
        }
    }
}