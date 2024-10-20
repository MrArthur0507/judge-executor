
using System.Diagnostics;

namespace Executor.Api.Workers
{
    public class CodeExecutionWorker : BackgroundService
    {
        private readonly ILogger<CodeExecutionWorker> _logger;

        public CodeExecutionWorker(ILogger<CodeExecutionWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
            }
        }

        private async Task<string> ExecuteCodeInDocker(string input)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "docker",
                Arguments = $"run --rm -i --cap-drop mrarthur0507/cexecutor:latest",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false, 
                CreateNoWindow = true,
            };
            using (var process = new Process { StartInfo = processInfo })
            {
                
                process.Start();
                
                using (var writer = process.StandardInput)
                {
                    if (writer.BaseStream.CanWrite)
                    {
                        await writer.WriteAsync(input);
                    }
                }

                
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                
                process.WaitForExit();

                
                Console.WriteLine(output);
                return output;
            }

        }
    }
}
