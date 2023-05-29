var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Use(GetDate);
app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));
app.Run();
async Task GetDate(HttpContext context, Func<Task> next)
{
    string? path = context.Request.Path.Value?.ToLower();
    if (path == "/date")
    {
        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
    }
    else
    {
        await next.Invoke();
    }
}

/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Use(async (context, next) =>
{
    string? path = context.Request.Path.Value?.ToLower();
    if (path == "/date")
    {
        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
    }
    else
    {
        await next.Invoke();
    }
});

app.Run(async (context) => await context.Response.WriteAsync($"Hello METANIT.COM"));

app.Run();
*/

/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

string date = "";

app.Use(async (context, next) =>
{
    date = DateTime.Now.ToShortDateString();
    await next.Invoke();                 // вызываем middleware из app.Run
    Console.WriteLine($"Current date: {date}");  // Current date: 08.12.2021
});

app.Run(async (context) => await context.Response.WriteAsync($"Date: {date}"));

app.Run();
*/