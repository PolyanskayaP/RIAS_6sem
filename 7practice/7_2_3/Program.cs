var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(options => options.AddPolicy("AllowLocalhost7027", builder => builder
                    .WithOrigins("https://localhost:7027")
                    .AllowAnyHeader()
                    .AllowAnyMethod())
               );

var app = builder.Build();

app.UseCors("AllowLocalhost7027");

app.Run(async context => await context.Response.WriteAsync("Hello client!"));

app.Run();