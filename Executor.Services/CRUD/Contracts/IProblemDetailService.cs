using Executor.Models.Dtos.Creational;
using Executor.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Services.CRUD.Contracts
{
    public interface IProblemDetailService
    {
        Task<IEnumerable<ProblemDetailDto>> GetAllProblemDetailsAsync();
        Task<ProblemDetailDto> GetProblemDetailAsync(Guid id);
        Task<IEnumerable<ProblemDetailDto>> GetProblemDetailsByProblemIdAsync(Guid problemId);
        Task<ProblemDetailDto> CreateProblemDetailAsync(CreateProblemDetailDto problemDetail);
        Task<ProblemDetailDto> UpdateProblemDetailAsync(ProblemDetailDto problemDetail);
        Task<bool> DeleteProblemDetailAsync(Guid id);
    }
}
