var builder = WebApplication.CreateBuilder();
WebApplication app = builder.Build();

app.Environment.EnvironmentName = "Test";   // измен€ем название среды на Test

if (app.Environment.IsEnvironment("Test")) // ≈сли проект в состо€нии "Test"
{
    app.Run(async (context) => await context.Response.WriteAsync("In Test Stage"));
}
else
{
    app.Run(async (context) => await context.Response.WriteAsync("In Development or Production Stage"));
}

app.Run();
/*
var builder = WebApplication.CreateBuilder();
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.Run(async (context) => await context.Response.WriteAsync("In Development Stage"));
}
else
{
    app.Run(async (context) => await context.Response.WriteAsync("In Production Stage"));
}
Console.WriteLine($"{app.Environment.EnvironmentName}");

app.Run();*/
