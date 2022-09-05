namespace MyMovies.Api.Loggger
{
    public class EventLogger : LogBase
    {
        public override void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now} - {message}");
        }
    }
}
