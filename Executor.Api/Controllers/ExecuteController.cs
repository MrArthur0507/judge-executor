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

        public ExecuteController()
        {
            
        }

        [HttpPost("execute")]
        public async Task<IActionResult> ExecuteCode([FromBody] Submission submission)
        {
            return Ok();
            
        }


    }
}
