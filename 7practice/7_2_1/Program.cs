var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(); // ��������� ������� CORS

var app = builder.Build();

// ����������� CORS
app.UseCors(builder => builder.AllowAnyOrigin());

app.Map("/", async context => await context.Response.WriteAsync("Hello METANIT.COM!"));

app.Run();