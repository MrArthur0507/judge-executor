using Executor.Models.Dtos.Creational;
using Executor.Models.Dtos;
using Executor.Services.CRUD.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Executor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCaseController : ControllerBase
    {
        private readonly ITestCaseService _testCaseService;

        public TestCaseController(ITestCaseService testCaseService)
        {
            _testCaseService = testCaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestCases()
        {
            var testCases = await _testCaseService.GetAllTestCasesAsync();
            return Ok(testCases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestCase(Guid id)
        {
            var testCase = await _testCaseService.GetTestCaseAsync(id);
            if (testCase == null)
                return NotFound();

            return Ok(testCase);
        }

        [HttpGet("byProblem/{problemId}")]
        public async Task<IActionResult> GetTestCasesByProblemId(Guid problemId)
        {
            var testCases = await _testCaseService.GetTestCasesByProblemIdAsync(problemId);
            return Ok(testCases);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestCase([FromBody] CreateTestCaseDto createTestCaseDto)
        {
            var testCase = await _testCaseService.CreateTestCaseAsync(createTestCaseDto);
            return CreatedAtAction(nameof(GetTestCase), new { id = testCase.Id }, testCase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestCase(Guid id, [FromBody] TestCaseDto testCaseDto)
        {
            if (id != testCaseDto.Id)
                return BadRequest();

            var updatedTestCase = await _testCaseService.UpdateTestCaseAsync(testCaseDto);
            if (updatedTestCase == null)
                return NotFound();

            return Ok(updatedTestCase);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCase(Guid id)
        {
            var result = await _testCaseService.DeleteTestCaseAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
