using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    if (request.Path == "/api/user")
    {
        var responseText = "Некорректные данные";   // содержание сообщения по умолчанию

        if (request.HasJsonContentType())
        {
            // определяем параметры сериализации/десериализации
            var jsonoptions = new JsonSerializerOptions();
            // добавляем конвертер кода json в объект типа Person
            jsonoptions.Converters.Add(new PersonConverter());
            // десериализуем данные с помощью конвертера PersonConverter
            var person = await request.ReadFromJsonAsync<Person>(jsonoptions);
            if (person != null)
                responseText = $"Name: {person.Name}  Age: {person.Age}";
        }
        await response.WriteAsJsonAsync(new { text = responseText });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

public record Person(string Name, int Age);
public class PersonConverter : JsonConverter<Person>
{
    public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var personName = "Undefined";
        var personAge = 0;
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                switch (propertyName?.ToLower())
                {
                    // если свойство age и оно содержит число
                    case "age" when reader.TokenType == JsonTokenType.Number:
                        personAge = reader.GetInt32();  // считываем число из json
                        break;
                    // если свойство age и оно содержит строку
                    case "age" when reader.TokenType == JsonTokenType.String:
                        string? stringValue = reader.GetString();
                        // пытаемся конвертировать строку в число
                        if (int.TryParse(stringValue, out int value))
                        {
                            personAge = value;
                        }
                        break;
                    case "name":    // если свойство Name/name
                        string? name = reader.GetString();
                        if (name != null)
                            personName = name;
                        break;
                }
            }
        }
        return new Person(personName, personAge);
    }
    // сериализуем объект Person в json
    public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("name", person.Name);
        writer.WriteNumber("age", person.Age);

        writer.WriteEndObject();
    }
}

/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    if (request.Path == "/api/user")
    {
        var message = "Некорректные данные";   // содержание сообщения по умолчанию
        try
        {
            // пытаемся получить данные json
            var person = await request.ReadFromJsonAsync<Person>();
            if (person != null) // если данные сконвертированы в Person
                message = $"Name: {person.Name}  Age: {person.Age}";
        }
        catch { }
        // отправляем пользователю данные
        await response.WriteAsJsonAsync(new { text = message });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

public record Person(string Name, int Age);
*/
/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    Person tom = new("Polya", 20);
    await context.Response.WriteAsJsonAsync(tom);
});

app.Run();

public record Person(string Name, int Age);
*/
//////////////////
/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    if (context.Request.Path == "/old")
    {
        context.Response.Redirect("https://www.google.com/search?q=metanit.com");
    }
    else if (context.Request.Path == "/new")
    {
        await context.Response.WriteAsync("New Page");
    }
    else
    {
        await context.Response.WriteAsync("Main Page");
    }
});

app.Run();
*/
/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    // если обращение идет по адресу "/postuser", получаем данные формы
    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        string age = form["age"];
        string[] languages = form["languages"];
        // создаем из массива languages одну строку
        string langList = "";
        foreach (var lang in languages)
        {
            langList += $" {lang}";
        }
        await context.Response.WriteAsync($"<div><p>Name: {name}</p>" +
            $"<p>Age: {age}</p>" +
            $"<div>Languages:{langList}</div></div>");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }
});

app.Run();
*/

/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    // если обращение идет по адресу "/postuser", получаем данные формы
    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        string age = form["age"];
        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }
});

app.Run();
*/
////////////////////////
/*
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    var fileinfo = fileProvider.GetFileInfo("kryptoyozh.png");

    context.Response.Headers.ContentDisposition = "attachment; filename=my_forest2.jpg";
    await context.Response.SendFileAsync(fileinfo);
});

app.Run();
*/
/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.Headers.ContentDisposition = "attachment; filename=kryptoyozh.png";
    await context.Response.SendFileAsync("kryptoyozh.png");
});

app.Run();
*/
/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var path = context.Request.Path;
    var fullPath = $"html/{path}";
    var response = context.Response;

    response.ContentType = "text/html; charset=utf-8";
    if (File.Exists(fullPath))
    {
        await response.SendFileAsync(fullPath);
    }
    else
    {
        response.StatusCode = 404;
        await response.WriteAsync("<h2>Not Found</h2>");
    }
});

app.Run();
*/

/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.Run();
*/
/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) => await context.Response.SendFileAsync("C:\\!Полина\\Творчество\\криптоёж.png"));

app.Run();
*/
//////////////////
/*var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    string name = context.Request.Query["name"];
    string age = context.Request.Query["age"];
    await context.Response.WriteAsync($"{name} - {age}");
});

app.Run();
*/

/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
    stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
    foreach (var param in context.Request.Query)
    {
        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());
});
*/

//app.Run();

/*
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
        $"<p>QueryString: {context.Request.QueryString}</p>");
});

app.Run();
*/
/*
app.Run(async(context) =>
{
    var path = context.Request.Path;
    var now = DateTime.Now;
    var response = context.Response;

    if (path == "/date")
        await response.WriteAsync($"Date: {now.ToShortDateString()}");
    else if (path == "/time")
        await response.WriteAsync($"Time: {now.ToShortTimeString()}");
    else
        await response.WriteAsync("Hello METANIT.COM");    
});
*/

//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));


//app.MapGet("/", () => "Hello World!");
//app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));
//app.Run();

/*
 app.Run(async (context) =>
{
    var acceptHeaderValue = context.Request.Headers.Accept;  //Headers["accept"]; 
    await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
});
 */

/*
app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<table>");

    foreach (var header in context.Request.Headers)
    {
        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());
});
*/

/*
 app.Run(async (context) =>
{
    var response = context.Response;
    response.ContentType = "text/html; charset-utf-8";
    await response.WriteAsync("<h2>Hello Metanit.com</h2><h3>Welcome to ASP.NET Core</h3>");
});
 */

/*
app.Run(async (context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Resourse Not Found"); 
});
 */

/*
app.Run(async (context) =>
{
    var response = context.Response;
    response.Headers.ContentLanguage = "ru-Ru";
    response.Headers.ContentType = "text/plain; charset=utf-8"; //можно было responce.ContentType 
    response.Headers.Append("secret-id", "256"); //добавление кастомного заголовка
    await context.Response.WriteAsync("Hello Metanit.com");
});
 */

/*
 app.Run(async (context) =>
{
    x = x * 2; // 2*2=4
    await context.Response.WriteAsync($"Result: {x}");
});
 */