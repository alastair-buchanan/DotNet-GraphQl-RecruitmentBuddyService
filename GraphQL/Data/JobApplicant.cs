namespace RecruitmentBuddy.GraphQL.Data
{
    public class JobApplicant
    {
        public int JobId { get; set; }

        public Job? Job { get; set; }

        public int ApplicantId { get; set; }

        public Applicant? Applicant { get; set; }
    }
}