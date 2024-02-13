using JobOpeningTest.Modules;
using Microsoft.EntityFrameworkCore;

namespace JobOpeningTest.Data
{
    public class JobOpeningContext : DbContext
    {
        public JobOpeningContext(DbContextOptions<JobOpeningContext> options) : base(options)
        {
        }
        public DbSet<JobOpening>jobOpenings { get; set; }
    }
}
