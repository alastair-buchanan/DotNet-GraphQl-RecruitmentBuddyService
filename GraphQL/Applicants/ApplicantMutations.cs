using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using RecruitmentBuddy.GraphQL.Common;
using RecruitmentBuddy.GraphQL.Data;
using RecruitmentBuddy.GraphQL.Extensions;

namespace RecruitmentBuddy.GraphQL.Applicants
{
    [ExtendObjectType(Name = "Mutation")]
    public class ApplicantMutations
    {
        [UseApplicationDbContext]
        public async Task<RegisterApplicantPayload> RegisterApplicantAsync(
            RegisterApplicantInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var applicant = new Applicant
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName,
                EmailAddress = input.EmailAddress,
                Password = input.Password,
                Qualification = input.Qualification,
                JobStatus = input.JobStatus,
                AboutMe = input.AboutMe,
            };

            context.Applicants.Add(applicant);

            await context.SaveChangesAsync(cancellationToken);

            return new RegisterApplicantPayload(applicant);
        }
        
        [UseApplicationDbContext]
        public async Task<AddApplicantToJobPayload> AddApplicantToJobAsync(
            AddApplicantToJobInput input,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            Applicant applicant = await context.Applicants.FirstOrDefaultAsync(
                t => t.Id == input.JobId, cancellationToken);
            
            if (applicant is null)
            {
                return new AddApplicantToJobPayload(
                    new UserError("Applicant not found.", "APPLICANT_NOT_FOUND"));
            }
            
            applicant.JobApplicants.Add(
                new JobApplicant
                {
                    JobId = input.JobId
                });
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(
                "OnApplicantAdded_" + input.JobId,
                input.ApplicantId,
                cancellationToken);

            return new AddApplicantToJobPayload(applicant, input.JobId );
        }
    }
}