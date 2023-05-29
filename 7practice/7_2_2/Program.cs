var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(); // ��������� ������� CORS

var app = builder.Build();

// ����������� CORS
app.UseCors(builder => builder.WithOrigins("https://localhost:7027")
                             .AllowCredentials());

app.Run(async (context) =>
{
    var login = context.Request.Cookies["login"];  // �������� ������������ ����
    await context.Response.WriteAsync($"Hello {login}!");
});

app.Run();