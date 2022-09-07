using System.Collections.Generic;
using RecruitmentBuddy.GraphQL.Common;
using RecruitmentBuddy.GraphQL.Data;

namespace RecruitmentBuddy.GraphQL.Applicants
{
    public class RegisterApplicantPayload : ApplicantPayloadBase
    {
        public RegisterApplicantPayload(Applicant applicant) : base(applicant)
        {
        }

        public RegisterApplicantPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}