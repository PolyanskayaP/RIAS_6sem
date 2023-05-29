var builder = WebApplication.CreateBuilder();
builder.Services.AddRouting(options =>
                options.ConstraintMap.Add("invalidnames", typeof(InvalidNamesConstraint)));
var app = builder.Build();

app.Map("/users/{name:invalidnames}", (string name) => $"Name: {name}");
app.Map("/", () => "Index Page");

app.Run();

public class InvalidNamesConstraint : IRouteConstraint
{
    string[] names = new[] { "Tom", "Sam", "Bob" };
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
        RouteValueDictionary values, RouteDirection routeDirection)
    {
        return !names.Contains(values[routeKey]?.ToString());
    }
}


//var builder = WebApplication.CreateBuilder();
//// проецируем класс SecretCodeConstraint на inline-ограничение secretcode
//builder.Services.Configure<RouteOptions>(options =>
//                options.ConstraintMap.Add("secretcode", typeof(SecretCodeConstraint)));

//// альтернативное добавление класса ограничения
//// builder.Services.AddRouting(options => options.ConstraintMap.Add("secretcode", typeof(SecretConstraint)));

//var app = builder.Build();

//app.Map(
//    "/users/{name}/{token:secretcode(123466)}/",
//    (string name, int token) => $"Name: {name} \nToken: {token}"
//);
//app.Map("/", () => "Index Page");

//app.Run();

//public class SecretCodeConstraint : IRouteConstraint
//{
//    string secretCode;    // допустимый код
//    public SecretCodeConstraint(string secretCode)
//    {
//        this.secretCode = secretCode;
//    }

//    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
//    {
//        return values[routeKey]?.ToString() == secretCode;
//    }
//}