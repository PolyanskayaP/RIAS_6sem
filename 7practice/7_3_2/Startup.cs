namespace _7_3_2
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Rewrite;
    using Microsoft.Extensions.Hosting;

    namespace UrlRewritingApp
    {
        public class Startup
        {
            public void Configure(IApplicationBuilder app, IHostEnvironment env)
            {
                app.UseDeveloperExceptionPage();

                var options = new RewriteOptions()
                        .AddIISUrlRewrite(env.ContentRootFileProvider, "urlrewrite.xml");
                app.UseRewriter(options);

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync("Hello World!");
                    });
                    endpoints.MapGet("/home/products", async context =>
                    {
                        await context.Response.WriteAsync($"Values:  id = {context.Request.Query["id"]} " +
                                $"name = {context.Request.Query["name"]}");
                    });
                });
            }
            //public void Configure(IApplicationBuilder app, IHostEnvironment env)
            //{
            //    app.UseDeveloperExceptionPage();

            //    var options = new RewriteOptions()
            //        .AddIISUrlRewrite(env.ContentRootFileProvider, "urlrewrite.xml");
            //    app.UseRewriter(options);

            //    app.UseRouting();

            //    app.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapGet("/", async context =>
            //        {
            //            await context.Response.WriteAsync("Hello World!");
            //        });
            //        endpoints.MapGet("/home", async context =>
            //        {
            //            await context.Response.WriteAsync("Home Page!");
            //        });
            //        endpoints.MapGet("/home/index", async context =>
            //        {
            //            await context.Response.WriteAsync("Home Index Page!");
            //        });
            //    });
            //}
        }
    }
}
