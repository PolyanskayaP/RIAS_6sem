namespace pr4_5
{
    public class TimeService
    {
        public TimeService()
        {
            Time = DateTime.Now.ToLongTimeString();
        }
        public string Time { get; }
    }
}
