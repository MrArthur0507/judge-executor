namespace Executor.Models.Dtos
{
    public class ProblemDetailDto
    {
        public Guid Id { get; set; }
        public Guid ProblemId { get; set; }
        public string LanguageName { get; set; } 
        public string TemplateCode { get; set; }
        public string LanguageDescription { get; set; }
        
    }
}