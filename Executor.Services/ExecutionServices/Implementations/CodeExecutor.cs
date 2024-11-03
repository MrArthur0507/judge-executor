
using Executor.Models.Submissions;
using JudgeContracts;
using MassTransit;

public class CodeExecutor : ICodeExecutor
{
    private readonly IRequestClient<ExecuteCode> _client;
    public CodeExecutor(IRequestClient<ExecuteCode> client)
    {
        _client = client;
    }
    public async Task<ExecuteCodeResult> ExecuteCode(Submission submission)
    {
        var response = await _client.GetResponse<ExecuteCodeResult>(new ExecuteCode() {
            Code = submission.Code,
            Language = submission.Language
        });
        return response.Message;
    }
}