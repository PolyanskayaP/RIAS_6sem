using pr4_5;

var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<TimeService>();

var app = builder.Build();

app.UseMiddleware<TimerMiddleware>();
app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));

app.Run();