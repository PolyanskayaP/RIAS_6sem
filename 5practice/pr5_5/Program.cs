var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<TimeService>();   // Добавляем сервис

var app = builder.Build();

app.Map("/time", (TimeService timeService) => $"Time: {timeService.Time}");
app.Map("/", () => "Hello METANIT.COM");

app.Run();

// сервис
public class TimeService
{
    public string Time => DateTime.Now.ToLongTimeString();
}