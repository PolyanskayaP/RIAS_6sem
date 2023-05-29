namespace pr4_6
{
    public class TimerMiddleware
    {
        public TimerMiddleware(RequestDelegate next) { }

        public async Task Invoke(HttpContext context, TimeService timeService)
        {
            await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
        }
    }
}
