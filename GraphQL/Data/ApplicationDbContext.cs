using Microsoft.EntityFrameworkCore;

namespace RecruitmentBuddy.GraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Applicant>()
                .HasIndex(a => a.FirstName)
                .IsUnique();
            
            modelBuilder
                .Entity<Job>()
                .HasIndex(a => a.Name)
                .IsUnique();
            
            // Many-to-many: Speaker <-> Session
            modelBuilder
                .Entity<JobApplicant>()
                .HasKey(ss => new { ss.JobId, ss.ApplicantId });
        }

        public DbSet<Applicant> Applicants { get; set; } = default!;
        
        public DbSet<Job> Jobs { get; set; } = default!;
        
        public DbSet<Company> Companys { get; set; } = default!;
        
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; } = default!;
    }
}