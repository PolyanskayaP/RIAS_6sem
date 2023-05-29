using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication("Bearer")  // ���������� �������� ��������������
    .AddJwtBearer();      // ����������� �������������� � ������� jwt-�������
builder.Services.AddAuthorization();            // ���������� �������� �����������

var app = builder.Build();

app.UseAuthentication();   // ���������� middleware �������������� 
app.UseAuthorization();   // ���������� middleware ����������� 

app.Map("/hello", [Authorize]() => "Hello World!");
app.Map("/", () => "Home Page");

app.Run();


//var builder = WebApplication.CreateBuilder();
//// ���������� �������� ��������������
//object p = builder.Services.AddAuthentication("Bearer") // ����� �������������� - � ������� jwt-�������
//    .AddJwtBearer();      // ����������� �������������� � ������� jwt-�������

//var app = builder.Build();

//app.UseAuthentication();   // ���������� middleware ��������������
//app.UseDefaultFiles();  
//app.UseStaticFiles();

//app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

//app.Run();
