using AutoMapper;
using Executor.DataAccess.AppContext;
using Executor.Models.DbModels;
using Executor.Models.Dtos.Creational;
using Executor.Models.Dtos;
using Executor.Services.CRUD.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Executor.Services.CRUD.Implementations
{
    public class TestCaseService : ITestCaseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TestCaseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestCaseDto>> GetAllTestCasesAsync()
        {
            var testCases = await _context.TestCases.ToListAsync();
            return _mapper.Map<IEnumerable<TestCaseDto>>(testCases);
        }

        public async Task<TestCaseDto> GetTestCaseAsync(Guid id)
        {
            var testCase = await _context.TestCases.FirstOrDefaultAsync(tc => tc.Id == id);

            if (testCase == null)
                return null;

            return _mapper.Map<TestCaseDto>(testCase);
        }

        public async Task<IEnumerable<TestCaseDto>> GetTestCasesByProblemIdAsync(Guid problemId)
        {
            var testCases = await _context.TestCases
                .Where(tc => tc.ProblemId == problemId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<TestCaseDto>>(testCases);
        }

        public async Task<TestCaseDto> CreateTestCaseAsync(CreateTestCaseDto createTestCaseDto)
        {
            var testCase = _mapper.Map<TestCase>(createTestCaseDto);
            _context.TestCases.Add(testCase);
            await _context.SaveChangesAsync();

            return _mapper.Map<TestCaseDto>(testCase);
        }

        public async Task<TestCaseDto> UpdateTestCaseAsync(TestCaseDto testCaseDto)
        {
            var existingTestCase = await _context.TestCases
                .FirstOrDefaultAsync(tc => tc.Id == testCaseDto.Id);

            if (existingTestCase == null)
                return null;

            _mapper.Map(testCaseDto, existingTestCase);

            _context.TestCases.Update(existingTestCase);
            await _context.SaveChangesAsync();

            return _mapper.Map<TestCaseDto>(existingTestCase);
        }

        public async Task<bool> DeleteTestCaseAsync(Guid id)
        {
            var testCase = await _context.TestCases.FirstOrDefaultAsync(tc => tc.Id == id);

            if (testCase == null)
                return false;

            _context.TestCases.Remove(testCase);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
