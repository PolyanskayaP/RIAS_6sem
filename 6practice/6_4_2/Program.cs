var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/error/{0}");

app.Map("/hello", () => "Hello ASP.NET Core");
app.Map("/error/{statusCode}", (int statusCode) => $"Error. Status Code: {statusCode}");

app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//// обработка ошибок HTTP
//app.UseStatusCodePages(async statusCodeContext =>
//{
//    var response = statusCodeContext.HttpContext.Response;
//    var path = statusCodeContext.HttpContext.Request.Path;

//    response.ContentType = "text/plain; charset=UTF-8";
//    if (response.StatusCode == 403)
//    {
//        await response.WriteAsync($"Path: {path}. Access Denied ");
//    }
//    else if (response.StatusCode == 404)
//    {
//        await response.WriteAsync($"Resource {path} Not Found");
//    }
//});

//app.Map("/hello", () => "Hello ASP.NET Core");

//app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//// обработка ошибок HTTP
//app.UseStatusCodePages("text/plain", "Error: Resource Not Found. Status code: {0}");

//app.Map("/hello", () => "Hello ASP.NET Core");

//app.Run();