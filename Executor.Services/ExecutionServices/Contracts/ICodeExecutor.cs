using Executor.Models.Submissions;
using JudgeContracts;

public interface ICodeExecutor
{
    public Task<ExecuteCodeResult> ExecuteCode(Submission submission);
}