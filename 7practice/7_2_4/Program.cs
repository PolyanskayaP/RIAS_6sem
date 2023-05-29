var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(options => {

    options.AddPolicy("AllowTestSite", builder => builder
        .WithOrigins("https://localhost:7027")
        .AllowAnyHeader()
        .AllowAnyMethod());

    options.AddPolicy("AllowNormSite", builder => builder
            .WithOrigins("https://localhost.com")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors();

app.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"))
    .RequireCors(options => options.AllowAnyOrigin());

app.MapGet("/home", async context => await context.Response.WriteAsync("Home Page!"))
    .RequireCors("AllowNormSite");

app.MapGet("/about", async context => await context.Response.WriteAsync("About Page!"))
    .RequireCors("AllowTestSite");

app.Run();