using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentBuddy.GraphQL.Data
{
    public class ProgrammingLanguage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Name { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? Type { get; set; }
        
        [Required]
        [StringLength(200)]
        public DateTime? DateStarted { get; set; }
        
        [Required]
        [StringLength(200)]
        public int? ProficiencyLevel { get; set; }
    }
}