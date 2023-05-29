var builder = WebApplication.CreateBuilder();
var app = builder.Build();

var loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
ILogger logger = loggerFactory.CreateLogger<Program>();
app.Run(async (context) =>
{
    logger.LogInformation($"Requested Path: {context.Request.Path}");
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
