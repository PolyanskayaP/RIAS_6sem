using pr4_4;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<ICounter, RandomCounter>();
builder.Services.AddSingleton<CounterService>();

//builder.Services.AddTransient<ICounter, RandomCounter>();
//builder.Services.AddTransient<CounterService>();

var app = builder.Build();

app.UseMiddleware<CounterMiddleware>();

app.Run();

public interface ICounter
{
    int Value { get; }
}