var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Environment.EnvironmentName = "Production";

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(app => app.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Error 500. DivideByZeroException occurred!");
    }));
}

app.Run(async (context) =>
{
    int a = 5;
    int b = 0;
    int c = a / b;
    await context.Response.WriteAsync($"c = {c}");
});

app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Environment.EnvironmentName = "Production"; // ������ ��� ���������

//// ���� ���������� �� ��������� � �������� ����������
//// �������������� �� ������ "/error"
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//}

//// middleware, ������� ������������ ����������
//app.Map("/error", app => app.Run(async context =>
//{
//    context.Response.StatusCode = 500;
//    await context.Response.WriteAsync("Error 500. DivideByZeroException occurred!");
//}));

//// middleware, ��� ������������ ����������
//app.Run(async (context) =>
//{
//    int a = 5;
//    int b = 0;
//    int c = a / b;
//    await context.Response.WriteAsync($"c = {c}");
//});

//app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Environment.EnvironmentName = "Production"; // ������ ��� ���������

//app.Run(async (context) =>
//{
//    int a = 5;
//    int b = 0;
//    int c = a / b;
//    await context.Response.WriteAsync($"c = {c}");
//});

//app.Run();