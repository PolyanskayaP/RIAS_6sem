var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(); // добавляем сервисы CORS

var app = builder.Build();

// настраиваем CORS
app.UseCors(builder => builder.WithOrigins("https://localhost:7027")
                             .AllowCredentials());

app.Run(async (context) =>
{
    var login = context.Request.Cookies["login"];  // получаем отправленные куки
    await context.Response.WriteAsync($"Hello {login}!");
});

app.Run();