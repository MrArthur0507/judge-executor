using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Models.Dtos.Creational
{
    public class CreateTestCaseDto
    {
        public Guid ProblemId { get; set; }
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        public bool IsZeroCase { get; set; }
    }
}
