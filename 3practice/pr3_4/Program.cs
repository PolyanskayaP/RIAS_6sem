var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapWhen(
    context => context.Request.Path == "/time", // �������: ���� ���� ������� "/time"
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
    context => context.Request.Path == "/time", // �������: ���� ���� ������� "/time"
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
        await next();   // �������� ��������� middleware
    });
}
*/
/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseWhen(
    context => context.Request.Path == "/time", // �������: ���� ���� ������� "/time"
    appBuilder =>
    {
        appBuilder.Use(async (context, next) =>
        {
            var time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Time: {time}");
            await next();   // �������� ��������� middleware
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
    context => context.Request.Path == "/time", // ���� ���� ������� "/time"
    appBuilder =>
    {
        // ��������� ������ - ������� �� ������� ����������
        appBuilder.Use(async (context, next) =>
        {
            var time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Time: {time}");
            await next();   // �������� ��������� middleware
        });

        // ���������� �����
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