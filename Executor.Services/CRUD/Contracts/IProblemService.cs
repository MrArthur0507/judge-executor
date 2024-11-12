using Executor.Models.Dtos;
using Executor.Models.Dtos.Creational;

namespace Executor.Services.Crud
{
    public interface IProblemService
    {
        Task<IEnumerable<ProblemDto>> GetAllProblemsAsync();
        Task<ProblemDto> GetProblemAsync(Guid id);
        Task<ProblemDto> CreateProblemAsync(CreateProblemDto problem);
        Task<ProblemDto> UpdateProblemAsync(ProblemDto problem);
        Task<bool> DeleteProblemAsync(Guid id);
    }
}