var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");

app.Run(async context =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Resource not found");
});
app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("First middleware starts");
//    await next.Invoke();
//    Console.WriteLine("First middleware ends");
//});
//app.Map("/", () =>
//{
//    Console.WriteLine("Index endpoint starts and ends");
//    return "Index Page";
//});
//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Second middleware starts");
//    await next.Invoke();
//    Console.WriteLine("Second middleware ends");
//});
//app.Map("/about", () =>
//{
//    Console.WriteLine("About endpoint starts and ends");
//    return "About Page";
//});
//app.Run();