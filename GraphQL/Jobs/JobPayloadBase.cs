using System.Collections.Generic;
using HotChocolate.Types;
using RecruitmentBuddy.GraphQL.Common;
using RecruitmentBuddy.GraphQL.Data;

namespace RecruitmentBuddy.GraphQL.Jobs
{
    public class JobPayloadBase : Payload
    {
        protected JobPayloadBase(Job job)
        {
            Job = job;
        }

        protected JobPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
        
        public Job? Job { get; }
    }
}