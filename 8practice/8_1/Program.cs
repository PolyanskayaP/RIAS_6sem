using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication("Bearer")  // добавление сервисов аутентификации
    .AddJwtBearer();      // подключение аутентификации с помощью jwt-токенов
builder.Services.AddAuthorization();            // добавление сервисов авторизации

var app = builder.Build();

app.UseAuthentication();   // добавление middleware аутентификации 
app.UseAuthorization();   // добавление middleware авторизации 

app.Map("/hello", [Authorize]() => "Hello World!");
app.Map("/", () => "Home Page");

app.Run();


//var builder = WebApplication.CreateBuilder();
//// добавление сервисов аутентификации
//object p = builder.Services.AddAuthentication("Bearer") // схема аутентификации - с помощью jwt-токенов
//    .AddJwtBearer();      // подключение аутентификации с помощью jwt-токенов

//var app = builder.Build();

//app.UseAuthentication();   // добавление middleware аутентификации
//app.UseDefaultFiles();  
//app.UseStaticFiles();

//app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

//app.Run();
