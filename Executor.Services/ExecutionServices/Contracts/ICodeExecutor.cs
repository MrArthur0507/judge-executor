using Executor.Models.Submissions;

public interface ICodeExecutor
{
    public Task<string> ExecuteCode(Submission submission);
}