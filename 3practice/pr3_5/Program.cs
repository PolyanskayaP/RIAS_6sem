var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/home", appBuilder =>
{
    appBuilder.Map("/index", Index); // middleware для "/home/index"
    appBuilder.Map("/about", About); // middleware для "/home/about"
    // middleware для "/home"
    appBuilder.Run(async (context) => await context.Response.WriteAsync("Home Page"));
});

app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));

app.Run();

void Index(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
}
void About(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("About Page"));
}

/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/index", Index);
app.Map("/about", About);

app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));

app.Run();

void Index(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("Index"));
}
void About(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("About"));
}
*/
/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/index", appBuilder =>
{
    appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
});
app.Map("/about", appBuilder =>
{
    appBuilder.Run(async context => await context.Response.WriteAsync("About Page"));
});

app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));

app.Run();
*/
/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/time", appBuilder =>
{
    var time = DateTime.Now.ToShortTimeString();

    // логгируем данные - выводим на консоль приложения
    appBuilder.Use(async (context, next) =>
    {
        Console.WriteLine($"Time: {time}");
        await next();   // вызываем следующий middleware
    });

    appBuilder.Run(async context => await context.Response.WriteAsync($"Time: {time}"));
});

app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));

app.Run();
*/