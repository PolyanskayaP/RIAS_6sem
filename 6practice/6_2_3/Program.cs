var builder = WebApplication.CreateBuilder();

builder.Logging.ClearProviders();   // удаляем все провайдеры
builder.Logging.AddConsole();   // добавляем провайдер для логгирования на консоль

var app = builder.Build();

var loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
ILogger logger = loggerFactory.CreateLogger<Program>();
app.Run(async (context) =>
{
    logger.LogInformation($"Requested Path: {context.Request.Path}");
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
