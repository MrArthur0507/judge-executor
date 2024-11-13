using Executor.Mapping;
using Executor.Services.Crud;
using Executor.Services.CRUD.Contracts;
using Executor.Services.CRUD.Implementations;
using MassTransit;
using Microsoft.EntityFrameworkCore;


namespace Executor.Api.Extensions
{
    public static class HostExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataAccess.AppContext.AppDbContext>(options => {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), x=> x.MigrationsAssembly("Executor.DataAccess"));
                
            });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICodeExecutor, CodeExecutor>();
            services.AddScoped<IProblemService, ProblemService>();
            services.AddScoped<IProblemDetailService, ProblemDetailService>();
            services.AddScoped<ITestCaseService, TestCaseService>();
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
