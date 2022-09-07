using System.ComponentModel.DataAnnotations;

namespace RecruitmentBuddy.GraphQL.Data
{
    public class Company
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? Name { get; set; }
    }
}