var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapWhen(
    context => context.Request.Path == "/time", // условие: если путь запроса "/time"
    appBuilder => appBuilder.Run(async context =>
    {
        var time = DateTime.Now.ToShortTimeString();
        await context.Response.WriteAsync($"current time: {time}");
    })
);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();

/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseWhen(
    context => context.Request.Path == "/time", // условие: если путь запроса "/time"
    HandleTimeRequest
);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();

void HandleTimeRequest(IApplicationBuilder appBuilder)
{
    appBuilder.Use(async (context, next) =>
    {
        var time = DateTime.Now.ToShortTimeString();
        Console.WriteLine($"current time: {time}");
        await next();   // вызываем следующий middleware
    });
}
*/
/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseWhen(
    context => context.Request.Path == "/time", // условие: если путь запроса "/time"
    appBuilder =>
    {
        appBuilder.Use(async (context, next) =>
        {
            var time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Time: {time}");
            await next();   // вызываем следующий middleware
        });
    });

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();
*/
/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseWhen(
    context => context.Request.Path == "/time", // если путь запроса "/time"
    appBuilder =>
    {
        // логгируем данные - выводим на консоль приложения
        appBuilder.Use(async (context, next) =>
        {
            var time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Time: {time}");
            await next();   // вызываем следующий middleware
        });

        // отправляем ответ
        appBuilder.Run(async context =>
        {
            var time = DateTime.Now.ToShortTimeString();
            await context.Response.WriteAsync($"Time: {time}");
        });
    });

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();*/