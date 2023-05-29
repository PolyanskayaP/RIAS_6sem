using pr4_6;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<ITimer, Timer>();
builder.Services.AddSingleton<TimeService>();

var app = builder.Build();

app.UseMiddleware<TimerMiddleware>();

app.Run();

public interface ITimer
{
    string Time { get; }
}
public class Timer : ITimer
{
    public Timer()
    {
        Time = DateTime.Now.ToLongTimeString();
    }
    public string Time { get; }
}
public class TimeService
{
    private ITimer timer;
    public TimeService(ITimer timer)
    {
        this.timer = timer;
    }
    public string GetTime() => timer.Time;
}