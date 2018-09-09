namespace ProgrammingAssignment.Logging
{
    // I decided to seperate out the reading and writing portions of the logging system
    /// <summary>
    /// Log reader - get's string from Log File
    /// </summary>
    public interface ILogReader
    {
        string Path { get; }
        string ReadLog();
    }
}