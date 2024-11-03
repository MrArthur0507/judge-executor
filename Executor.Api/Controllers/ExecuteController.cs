using Executor.Models.Submissions;
using JudgeContracts;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Executor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecuteController : ControllerBase
    {
        private readonly ICodeExecutor _codeExecutor;

        public ExecuteController(ICodeExecutor codeExecutor)
        {
            _codeExecutor = codeExecutor;
        }

        [HttpPost("execute")]
        public async Task<IActionResult> ExecuteCode([FromBody] Submission submission)
        {
            ExecuteCodeResult result = await _codeExecutor.ExecuteCode(submission);
            return Ok(result);
            
        }


    }
}
