var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("users/{**info}", (string info) => $"User Info: {info}");

app.Map("/", () => "Index Page");

app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map(
//    "{controller=Home}/{action=Index}/{id?}",
//    (string controller, string action, string? id) =>
//        $"Controller: {controller} \nAction: {action} \nId: {id}"
//);

//app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map("/users/{id}/{name}", HandleRequest);
//app.Map("/users/{id?}", (string? id) => $"User Id: {id ?? "Undefined"}");
//app.Map("/", () => "Index Page");

//app.Run();

//string HandleRequest(string id, string name)
//{
//    return $"User Id: {id}   User Name: {name}";
//}


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map(
//    "/users/{id}/{name}",
//    (string id, string name) => $"User Id: {id}   User Name: {name}"
//);
//app.Map("/users", () => "Users Page");
//app.Map("/", () => "Index Page");

//app.Run();


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map("/users/{id}", (string id) => $"User Id: {id}");
//app.Map("/users", () => "Users Page");
//app.Map("/", () => "Index Page");

//app.Run();