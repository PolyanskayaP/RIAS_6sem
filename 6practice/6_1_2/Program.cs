var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseDefaultFiles();  // ��������� ������� html �� ���������
app.UseStaticFiles();

app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

app.Run();