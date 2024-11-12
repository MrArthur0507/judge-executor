namespace Executor.Models.Dtos
{
    public class TestCaseDto
    {
        public Guid Id { get; set; }
        public Guid ProblemId { get; set; }
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        public bool IsZeroCase { get; set; }
        
    }
}