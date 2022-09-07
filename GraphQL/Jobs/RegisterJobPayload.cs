using System.Collections.Generic;
using RecruitmentBuddy.GraphQL.Common;
using RecruitmentBuddy.GraphQL.Data;

namespace RecruitmentBuddy.GraphQL.Jobs
{
    public class RegisterJobPayload : JobPayloadBase
    {
        public RegisterJobPayload(Job job) : base(job)
        {
        }

        public RegisterJobPayload(UserError error) : base(new[] { error })
        {
        }
    }
}