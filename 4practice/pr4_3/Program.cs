var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<ITimeService, ShortTimeService>();

var app = builder.Build();

app.UseMiddleware<TimeMessageMiddleware>();

app.Run();

class TimeMessageMiddleware
{
    private readonly RequestDelegate next;

    public TimeMessageMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITimeService timeService)
    {
        context.Response.ContentType = "text/html;charset=utf-8";
        await context.Response.WriteAsync($"<h1>Time: {timeService.GetTime()}</h1>");
    }
}
interface ITimeService
{
    string GetTime();
}
class ShortTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}

/*var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<ITimeService, ShortTimeService>();
builder.Services.AddTransient<TimeMessage>();

var app = builder.Build();

app.Run(async context =>
{
    var timeMessage = context.RequestServices.GetService<TimeMessage>();
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
});

app.Run();

class TimeMessage
{
    ITimeService timeService;
    public TimeMessage(ITimeService timeService)
    {
        this.timeService = timeService;
    }
    public string GetTime() => $"Time: {timeService.GetTime()}";
}
interface ITimeService
{
    string GetTime();
}
class ShortTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}
*/

/*var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<ITimeService, ShortTimeService>();

var app = builder.Build();

app.Run(async context =>
{
    var timeService = app.Services.GetRequiredService<ITimeService>();
    await context.Response.WriteAsync($"Time: {timeService.GetTime()}");
});

app.Run();
/*
var builder = WebApplication.CreateBuilder();

//builder.Services.AddTransient<ITimeService, ShortTimeService>();

var app = builder.Build();

app.Run(async context =>
{
    var timeService = app.Services.GetService<ITimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});

app.Run();
*/
/*
//var builder = WebApplication.CreateBuilder();

//builder.Services.AddTransient<ITimeService, ShortTimeService>();

//var app = builder.Build();

//app.Run(async context =>
//{
//    var timeService = app.Services.GetService<ITimeService>();
//    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
//});

//app.Run();

interface ITimeService
{
    string GetTime();
}
class ShortTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}

 interface ITimeService
{
    string GetTime();
}
class ShortTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}

 */