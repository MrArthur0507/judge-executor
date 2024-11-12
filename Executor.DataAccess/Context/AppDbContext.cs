
using Executor.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Executor.DataAccess.AppContext
{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Problem> Problems { get; set; }
        public DbSet<ProblemDetail> ProblemDetails { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<Submission> Submissions { get; set; }
    }
}