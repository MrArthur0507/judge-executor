
namespace Executor.Models.DbModels
{
    public class Problem : Entity { 
        public string Title { get; set; }  

        public string Description { get; set; }

        public ICollection<ProblemDetail> ProblemDetails { get; set; }
        public ICollection<TestCase> TestCases { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }

}

