using Executor.Api.Workers;
using Executor.Api.Extensions;
var builder = WebApplication.CreateBuilder(args);


// The host configuration happens in extension methods inside the static HostExtension class.

builder.Services.ConfigureServices();

var app = builder.Build();

app.ConfigurePipeline();

app.Run();
