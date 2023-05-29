using _7_3_3.UrlRewritingApp;  // ������������ ���� ������ RedirectPHPRequests
using Microsoft.AspNetCore.Rewrite; // ����� � middleware URL Rewriting

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

var options = new RewriteOptions()
            .Add(new RedirectPHPRequests(extension: "html", newPath: "/html"));

app.UseRewriter(options);
app.UseStaticFiles();

app.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));

app.Run();


//using Microsoft.AspNetCore.Rewrite; // ����� � middleware URL Rewriting

//var builder = WebApplication.CreateBuilder();

//var app = builder.Build();

//var options = new RewriteOptions().Add(RewritePHPRequests);

//app.UseRewriter(options);
//app.UseStaticFiles();

//app.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));

//app.Run();

//static void RewritePHPRequests(RewriteContext context)
//{
//    var path = context.HttpContext.Request.Path;
//    var pathValue = path.Value; // ����������� ����
//                                // ���� ������ � ����� html, ���������� ������ 404
//    if (path.StartsWithSegments(new PathString("/html")))
//    {
//        context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
//        context.Result = RuleResult.EndResponse;
//        return;
//    }
//    // ���� ������ � ������ � ����������� php, �������������� ������ �� ����� html
//    if (pathValue != null && pathValue.EndsWith(".php", StringComparison.OrdinalIgnoreCase))
//    {
//        // �������� ���������� "php" � ����������� ���� � ��������� "html"
//        string proccedPath = "/html" + pathValue.Substring(0, pathValue.Length - 3) + "html";
//        context.HttpContext.Request.Path = new PathString(proccedPath);
//    }
//}