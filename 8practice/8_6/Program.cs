using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

app.UseAuthentication();

app.MapGet("/login", async (HttpContext context) =>
{
    var claims = new List<Claim>
    {
        new Claim (ClaimTypes.Name, "Tom"),
        new Claim ("languages", "English"),
        new Claim ("languages", "German"),
        new Claim ("languages", "Spanish")
    };
    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect("/");
});
app.Map("/", (HttpContext context) =>
{
    var username = context.User.FindFirst(ClaimTypes.Name);
    var languages = context.User.FindAll("languages");
    // объединяем список claims в строку
    var languagesToString = "";
    foreach (var l in languages)
        languagesToString = $"{languagesToString} {l.Value}";
    return $"Name: {username?.Value}\nLanguages: {languagesToString}";
});
app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return "Данные удалены";
});

app.Run();


//using Microsoft.AspNetCore.Authentication.Cookies;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authentication;

//var builder = WebApplication.CreateBuilder();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie();

//var app = builder.Build();

//app.UseAuthentication();
//// Добавление возраста
//app.MapGet("/addage", async (HttpContext context) =>
//{
//    if (context.User.Identity is ClaimsIdentity claimsIdentity)
//    {
//        claimsIdentity.AddClaim(new Claim("age", "37"));
//        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//        await context.SignInAsync(claimsPrincipal);
//    }
//    return Results.Redirect("/");
//});
//// удаление телефона
//app.MapGet("/removephone", async (HttpContext context) =>
//{
//    if (context.User.Identity is ClaimsIdentity claimsIdentity)
//    {
//        var phoneClaim = claimsIdentity.FindFirst(ClaimTypes.MobilePhone);
//        // если claim успешно удален
//        if (claimsIdentity.TryRemoveClaim(phoneClaim))
//        {
//            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//            await context.SignInAsync(claimsPrincipal);
//        }
//    }
//    return Results.Redirect("/");
//});
//app.MapGet("/login", async (HttpContext context) =>
//{
//    var username = "Tom";
//    var company = "Microsoft";
//    var phone = "+12345678901";

//    var claims = new List<Claim>
//    {
//        new Claim (ClaimTypes.Name, username),
//        new Claim ("company", company),
//        new Claim(ClaimTypes.MobilePhone,phone)
//    };
//    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//    await context.SignInAsync(claimsPrincipal);
//    return Results.Redirect("/");
//});
//app.Map("/", (HttpContext context) =>
//{
//    var username = context.User.FindFirst(ClaimTypes.Name);
//    var phone = context.User.FindFirst(ClaimTypes.MobilePhone);
//    var company = context.User.FindFirst("company");
//    var age = context.User.FindFirst("age");
//    return $"Name: {username?.Value}\nPhone: {phone?.Value}\n" +
//    $"Company: {company?.Value}\nAge: {age?.Value}";
//});
//app.MapGet("/logout", async (HttpContext context) =>
//{
//    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//    return "Данные удалены";
//});

//app.Run();


//using Microsoft.AspNetCore.Authentication.Cookies;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authentication;

//var builder = WebApplication.CreateBuilder();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie();

//var app = builder.Build();

//app.UseAuthentication();

//app.MapGet("/login", async (HttpContext context) =>
//{
//    var username = "Tom";
//    var company = "Microsoft";
//    var phone = "+12345678901";

//    var claims = new List<Claim>
//    {
//        new Claim (ClaimTypes.Name, username),
//        new Claim ("company", company),
//        new Claim(ClaimTypes.MobilePhone,phone)
//    };
//    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//    await context.SignInAsync(claimsPrincipal);
//    return Results.Redirect("/");
//});
//app.Map("/", (HttpContext context) =>
//{
//    // аналогично var username = context.User.Identity.Name
//    var username = context.User.FindFirst(ClaimTypes.Name);
//    var phone = context.User.FindFirst(ClaimTypes.MobilePhone);
//    var company = context.User.FindFirst("company");
//    return $"Name: {username?.Value}\nPhone: {phone?.Value}\nCompany: {company?.Value}";
//});
//app.MapGet("/logout", async (HttpContext context) =>
//{
//    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//    return "Данные удалены";
//});

//app.Run();


//using Microsoft.AspNetCore.Authentication.Cookies;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authentication;

//var builder = WebApplication.CreateBuilder();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie();

//var app = builder.Build();

//app.UseAuthentication();

//app.MapGet("/login/{username}", async (string username, HttpContext context) =>
//{
//    var claims = new List<Claim> { new(ClaimTypes.Name, username) };
//    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
//    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//    await context.SignInAsync(claimsPrincipal);
//    return $"Установлено имя {username}";
//});
//app.Map("/", (HttpContext context) =>
//{
//    var user = context.User.Identity;
//    if (user is not null && user.IsAuthenticated)
//        return $"UserName: {user.Name}";
//    else return "Пользователь не аутентифицирован.";
//});
//app.MapGet("/logout", async (HttpContext context) =>
//{
//    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//    return "Данные удалены";
//});

//app.Run();