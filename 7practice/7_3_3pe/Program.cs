using Microsoft.AspNetCore.Rewrite; // Пакет с middleware URL Rewriting

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

IHostEnvironment? env = app.Services.GetService<IHostEnvironment>();
if (env is not null)
{
    var options = new RewriteOptions()
                    .AddApacheModRewrite(env.ContentRootFileProvider, "rewrite.txt");
    app.UseRewriter(options);
}

app.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));
app.MapGet("/home/products", async context =>
    await context.Response.WriteAsync($"Values:  id = {context.Request.Query["id"]} name = {context.Request.Query["name"]}"));

app.Run();