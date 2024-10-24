using Executor.Api.Services.Contracts;
using Executor.Models.Submissions;
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
        private readonly IExecutionService _executionService;
        private readonly IPublishEndpoint _publishEndpoint;
        public ExecuteController(IExecutionService executionService, IPublishEndpoint publishEndpoint)
        {
            _executionService = executionService;
            _publishEndpoint = publishEndpoint;
        }

        //[HttpPost("execute")]
        //public async Task<IActionResult> ExecuteCode([FromBody] Submission submission)
        //{
            
        //    if (string.IsNullOrWhiteSpace(submission.Code))
        //    {
        //        return BadRequest("Code cannot be empty.");
        //    }

        //    var output = await _executionService.ExecuteCode(submission);
        //    return Ok(output);
        //}

        [HttpPost("execute")]
        public async Task<IActionResult> ExecuteCode([FromBody] Submission submission)
        {
            JudgeContracts.ExecuteCode executeCode = new JudgeContracts.ExecuteCode();
            executeCode.Code = submission.Code;
            executeCode.Language = "c";
            await _publishEndpoint.Publish(executeCode);

            return Ok();
        }


    }
}
