using Executor.Api.Services.Contracts;
using Executor.Api.Services.Implementation;
using MassTransit;

namespace Executor.Api.Extensions
{
    public static class HostExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });



            // Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "https://judge.bpenchev.info")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddScoped<IExecutionService, ExecutionService>();
        }

        public static void ConfigurePipeline(this WebApplication? app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            
            app.UseCors("AllowSpecificOrigins");

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
