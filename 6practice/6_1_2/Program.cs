var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseDefaultFiles();  // поддержка страниц html по умолчанию
app.UseStaticFiles();

app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

app.Run();