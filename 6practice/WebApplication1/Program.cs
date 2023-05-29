var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions { WebRootPath = "static" });  // изменяем папку для хранения статики

var app = builder.Build();

app.UseStaticFiles();   // добавляем поддержку статических файлов

app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

app.Run();