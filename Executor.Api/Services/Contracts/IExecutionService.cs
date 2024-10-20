using Executor.Models.Submissions;

namespace Executor.Api.Services.Contracts
{
    public interface IExecutionService
    {
        Task<string> ExecuteCode(Submission submission);
    }
}
