using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Models.Submissions
{
    public class Submission
    {
        public string Code { get; set; }
        public string Language { get; set; }
        public Guid UserId { get; set; }
    }
}
