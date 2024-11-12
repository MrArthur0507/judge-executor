namespace Executor.Models.Dtos
{
    public class SubmissionDto
    {
        public Guid Id { get; set; }
        public Guid ProblemId { get; set; }
        public Guid UserId { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        
    }
}