using Executor.Models.Dtos.Creational;
using Executor.Models.Dtos;
using Executor.Services.CRUD.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Executor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemDetailController : ControllerBase
    {
        private readonly IProblemDetailService _problemDetailService;

        public ProblemDetailController(IProblemDetailService problemDetailService)
        {
            _problemDetailService = problemDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProblemDetails()
        {
            var problemDetails = await _problemDetailService.GetAllProblemDetailsAsync();
            return Ok(problemDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProblemDetail(Guid id)
        {
            var problemDetail = await _problemDetailService.GetProblemDetailAsync(id);
            if (problemDetail == null)
                return NotFound();

            return Ok(problemDetail);
        }

        [HttpGet("byProblem/{problemId}")]
        public async Task<IActionResult> GetProblemDetailsByProblemId(Guid problemId)
        {
            var problemDetails = await _problemDetailService.GetProblemDetailsByProblemIdAsync(problemId);
            return Ok(problemDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProblemDetail([FromBody] CreateProblemDetailDto createProblemDetailDto)
        {
            var problemDetail = await _problemDetailService.CreateProblemDetailAsync(createProblemDetailDto);
            return CreatedAtAction(nameof(GetProblemDetail), new { id = problemDetail.Id }, problemDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProblemDetail(Guid id, [FromBody] ProblemDetailDto problemDetailDto)
        {
            if (id != problemDetailDto.Id)
                return BadRequest();

            var updatedProblemDetail = await _problemDetailService.UpdateProblemDetailAsync(problemDetailDto);
            if (updatedProblemDetail == null)
                return NotFound();

            return Ok(updatedProblemDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblemDetail(Guid id)
        {
            var result = await _problemDetailService.DeleteProblemDetailAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
