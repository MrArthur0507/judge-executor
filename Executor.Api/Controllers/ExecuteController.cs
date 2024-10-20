using Executor.Api.Services.Contracts;
using Executor.Api.Workers;
using Executor.Models.Submissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Executor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecuteController : ControllerBase
    {
        private readonly IExecutionService _executionService;
        public ExecuteController(IExecutionService executionService)
        {
            _executionService = executionService;
        }

        [HttpPost("execute")]
        public async Task<IActionResult> ExecuteCode([FromBody] Submission submission)
        {
            
            if (string.IsNullOrWhiteSpace(submission.Code))
            {
                return BadRequest("Code cannot be empty.");
            }

            var output = await _executionService.ExecuteCode(submission);
            return Ok(output);
        }

        
    }
}
