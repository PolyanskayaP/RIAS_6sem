namespace pr4_5
{
    public class TimerMiddleware
    {
        RequestDelegate next;
        TimeService timeService;

        public TimerMiddleware(RequestDelegate next, TimeService timeService)
        {
            this.next = next;
            this.timeService = timeService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/time")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
