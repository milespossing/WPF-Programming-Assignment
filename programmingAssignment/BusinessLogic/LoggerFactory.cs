namespace ProgrammingAssignment.Logging
{
    /// <summary>
    /// Creates Logging objects
    /// </summary>
    public class LoggerFactory
    {
        public static ILogWriter MakeTextLogger()
        {
            return new TextLogWriter();
        }

        public static ILogReader MakeTextReader(string path)
        {
            return new TextLogReader(path);
        }
    }
}