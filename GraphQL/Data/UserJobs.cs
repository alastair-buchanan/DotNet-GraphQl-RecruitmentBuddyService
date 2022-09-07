namespace RecruitmentBuddy.GraphQL.Data
{
    public class UserJobs
    {
        public int UserId { get; set; }

        public Applicant? User { get; set; }

        public int JobId { get; set; }

        public Job? Speaker { get; set; }
    }
}