using System.Collections.Generic;
using HotChocolate.Types;
using RecruitmentBuddy.GraphQL.Common;
using RecruitmentBuddy.GraphQL.Data;

namespace RecruitmentBuddy.GraphQL.Applicants
{
    public class ApplicantPayloadBase : Payload
    {
        protected ApplicantPayloadBase(Applicant applicant)
        {
            Applicant = applicant;
        }

        protected ApplicantPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Applicant? Applicant { get; }
    }
}