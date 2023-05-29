using System.Text;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");
app.Map("/contact", () => "Contacts Page");

app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var sb = new StringBuilder();
    var endpoints = endpointSources.SelectMany(es => es.Endpoints);
    foreach (var endpoint in endpoints)
    {
        sb.AppendLine(endpoint.DisplayName);

        // ������� �������� ����� ��� RouteEndpoint
        if (endpoint is RouteEndpoint routeEndpoint)
        {
            sb.AppendLine(routeEndpoint.RoutePattern.RawText);
        }

        // ��������� ����������
        // ������ �������������
        // var routeNameMetadata = endpoint.Metadata.OfType<Microsoft.AspNetCore.Routing.RouteNameMetadata>().FirstOrDefault();
        // var routeName = routeNameMetadata?.RouteName;
        // ������ http - �������������� ���� ��������
        //var httpMethodsMetadata = endpoint.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault();
        //var httpMethods = httpMethodsMetadata?.HttpMethods; // [GET, POST, ...]
    }
    return sb.ToString();
});

app.Run();

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map("/", IndexHandler);
//app.Map("/user", UserHandler);


//app.Run();

//string IndexHandler()
//{
//    return "Index Page";
//}
//Person UserHandler()
//{
//    return new Person("Tom", 37);
//}
//record class Person(string Name, int Age);


//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map("/", () => "Index Page");
//app.Map("/about", () => "About Page");
//app.Map("/contact", () => "Contacts Page");

//app.Run();

