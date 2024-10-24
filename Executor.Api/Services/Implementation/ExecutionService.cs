using Executor.Api.Services.Contracts;
using Executor.Models.Submissions;
using System.Diagnostics;

namespace Executor.Api.Services.Implementation
{
    public class ExecutionService : IExecutionService
    {
        public async Task<string> ExecuteCode(Submission submission)
        {
           return await ExecuteCodeInDocker(submission.Code);
        }

        private async Task<string> ExecuteCodeInDocker(string input)
        {
            
            
            var processInfo = new ProcessStartInfo
            {
                FileName = "docker",
                Arguments = $"run --rm  --cap-drop=ALL --tmpfs /tmp --user limiteduser --memory=256m --cpus=0.5 --pids-limit=10 -i mrarthur0507/c_language_executor:1.0",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
            };

            using (var process = new Process { StartInfo = processInfo })
            {

                process.Start();
                
                var task = process.WaitForExitAsync();

                using (var writer = process.StandardInput)
                {
                    if (writer.BaseStream.CanWrite)
                    {
                        await writer.WriteAsync(input);
                        await writer.WriteAsync(Environment.NewLine);
                    }
                }

                if (await Task.WhenAny(task, Task.Delay(5000)) == task)
                {
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    return output;
                }
                else
                {
                    process.Kill();
                    return "Timeout";
                }
            }
        }
    }
}
