var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<TimeService>();   // ��������� ������

var app = builder.Build();

app.Map("/time", (TimeService timeService) => $"Time: {timeService.Time}");
app.Map("/", () => "Hello METANIT.COM");

app.Run();

// ������
public class TimeService
{
    public string Time => DateTime.Now.ToLongTimeString();
}