
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Executor.Models.DbModels
{
    public class ProblemDetail : Entity { 

        [Required]
        public Guid ProblemId { get; set; }

        [ForeignKey("ProblemId")]
        public Problem Problem { get; set; }

        public string Language { get; set; }
        
        public string TemplateCode { get; set; }
        
        public string LanguageDescription { get; set; }

    }

}

