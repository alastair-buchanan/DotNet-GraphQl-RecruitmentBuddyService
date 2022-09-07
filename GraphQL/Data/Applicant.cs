using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentBuddy.GraphQL.Data
{
    public class Applicant
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? FirstName { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(200)]
        public string? UserName { get; set; }

        [Required]
        [StringLength(256)]
        public string? EmailAddress { get; set; }
        
        [Required]
        [StringLength(256)]
        public string? Password { get; set; }
        
        [Required]
        [StringLength(256)]
        public string? Qualification { get; set; }
        
        [Required]
        [StringLength(256)]
        public string? JobStatus { get; set; }
        
        [StringLength(4000)]
        public string? AboutMe { get; set; }

        public ICollection<ProgrammingLanguage> ProgrammingLanguages{ get; set; } =
            new List<ProgrammingLanguage>();
        
        public ICollection<JobApplicant> JobApplicants { get; set; } =
            new List<JobApplicant>();
    }
}