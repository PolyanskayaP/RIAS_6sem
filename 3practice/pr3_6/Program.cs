using pr3_6;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseToken("555555");

app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));

app.Run();

/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseMiddleware<TokenMiddleware>();

app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));

app.Run();
*/

/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
*/