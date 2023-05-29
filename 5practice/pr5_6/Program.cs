var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/{controller}/Index/5", (string controller) => $"Controller: {controller}");
app.Map("/Home/{action}/{id}", (string action) => $"Action: {action}");

app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map("/{message?}", (string? message) => $"Message: {message}");
//app.Map("/", () => "Index Page");

//app.Run();


//var builder = WebApplication.CreateBuilder();

//var app = builder.Build();

//app.Map("/hello", () => "Hello METANIT.COM");
//app.Map("/{message}", (string message) => $"Message: {message}");

//app.Map("/", () => "Index Page");

//app.Run();