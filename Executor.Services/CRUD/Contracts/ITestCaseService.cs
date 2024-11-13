using Executor.Models.Dtos.Creational;
using Executor.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Services.CRUD.Contracts
{
    public interface ITestCaseService
    {
        Task<IEnumerable<TestCaseDto>> GetAllTestCasesAsync();
        Task<TestCaseDto> GetTestCaseAsync(Guid id);
        Task<IEnumerable<TestCaseDto>> GetTestCasesByProblemIdAsync(Guid problemId);
        Task<TestCaseDto> CreateTestCaseAsync(CreateTestCaseDto testCaseDto);
        Task<TestCaseDto> UpdateTestCaseAsync(TestCaseDto testCaseDto);
        Task<bool> DeleteTestCaseAsync(Guid id);

    }
}
