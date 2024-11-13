using Executor.Models.Dtos.Creational;
using Executor.Models.Dtos;
using Executor.Services.Crud;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Executor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly IProblemService _problemService;

        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProblems()
        {
            var problems = await _problemService.GetAllProblemsAsync();
            return Ok(problems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProblem(Guid id)
        {
            var problem = await _problemService.GetProblemAsync(id);
            if (problem == null)
                return NotFound();

            return Ok(problem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProblem([FromBody] CreateProblemDto createProblemDto)
        {
            var problem = await _problemService.CreateProblemAsync(createProblemDto);
            return CreatedAtAction(nameof(GetProblem), new { id = problem.Id }, problem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProblem(Guid id, [FromBody] ProblemDto problemDto)
        {
            if (id != problemDto.Id)
                return BadRequest();

            var updatedProblem = await _problemService.UpdateProblemAsync(problemDto);
            if (updatedProblem == null)
                return NotFound();

            return Ok(updatedProblem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblem(Guid id)
        {
            var result = await _problemService.DeleteProblemAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
