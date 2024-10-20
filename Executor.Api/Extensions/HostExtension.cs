using Executor.Api.Services.Contracts;
using Executor.Api.Services.Implementation;
using Executor.Api.Workers;

namespace Executor.Api.Extensions
{
    public static class HostExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHostedService<CodeExecutionWorker>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    builder => builder.WithOrigins("http://localhost:4200") 
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
            services.AddScoped<IExecutionService, ExecutionService>();
        }

        public static void ConfigurePipeline(this WebApplication? app)
        {
            
            
            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseCors("AllowAngular");
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
