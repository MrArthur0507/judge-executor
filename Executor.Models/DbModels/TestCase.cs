
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Executor.Models.DbModels
{
    public class TestCase : Entity { 
        
        [Required]
        public Guid ProblemId { get; set; }
        
        [ForeignKey("ProblemId")]
        public Problem Problem { get; set; }

        public string Input { get; set; }
        
        public string ExpectedOutput { get; set; }
        
        public bool IsZeroCase { get; set; }
        
    }

}

