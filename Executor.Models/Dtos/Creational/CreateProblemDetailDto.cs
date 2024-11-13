using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Models.Dtos.Creational
{
    public class CreateProblemDetailDto
    {
        public Guid ProblemId { get; set; }
        public string Language { get; set; }
        public string TemplateCode { get; set; }
        public string LanguageDescription { get; set; }
    }
}
