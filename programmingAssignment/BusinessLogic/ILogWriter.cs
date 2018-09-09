using ProgrammingAssignment.Models;

namespace ProgrammingAssignment.Logging
{
    /// <summary>
    /// Log Writer - Creates log file on creation and writes lines to it with date stamps.
    /// </summary>
    public interface ILogWriter
    {
        string Path { get; }
        void WriteLog(LogEntry entry);
        void WriteLine(string line);
    }
}