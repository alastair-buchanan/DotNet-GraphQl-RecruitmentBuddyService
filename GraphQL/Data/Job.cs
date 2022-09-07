using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RecruitmentBuddy.GraphQL.Data
{
    public class Job
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? Name { get; set; }
        
        [Required]
        [StringLength(200)]
        public Company? Company { get; set; }

        public ICollection<JobApplicant> JobApplicants { get; set; } =
            new List<JobApplicant>();
    }
}