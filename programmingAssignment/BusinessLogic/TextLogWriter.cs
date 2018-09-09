using System;
using System.IO;
using System.Windows;
using ProgrammingAssignment.Models;

namespace ProgrammingAssignment.Logging
{
    /// <summary>
    /// Logs to a text document
    /// </summary>
    class TextLogWriter : ILogWriter
    {
        public string Path { get; private set; }

        // Enforcing factory pattern in this namespace
        internal TextLogWriter()
        {
            Path = $"Log {DateTime.Now:MM-dd-yy hhmm t}";
            makeFile();
            WriteWithTime("START");
        }

        // Makes the file. If an instance of the file already exists, say if the application were run twice
        // consecutively within a minute, it would append the number 2 to the name, 3 if it's already been created
        // twice and so on.
        private void makeFile()
        {
            string path = Path;
            int i = 2;
            while (File.Exists(path + ".txt"))
            {
                path = Path + $" {i}";
                i++;
            }
            Path = path + ".txt";
            File.Create(Path).Close();
        }

        /// <summary>
        /// Writes a log entry directly from the MakeLine() method of the LogEntry Class
        /// </summary>
        /// <param name="entry"></param>
        public void WriteLog(LogEntry entry)
        {
            WriteWithTime(entry.ToString());
        }

        /// <summary>
        /// Writes a timestamped line to the log
        /// </summary>
        /// <param name="line"></param>
        public void WriteLine(string line)
        {
            WriteWithTime(line);
        }

        // Writes logs with timestamps
        private void WriteWithTime(string line)
        {
            // I had to throw this part in as File.AppendAllText actually recreates a file in the absence of one, which doesn't really
            // capture the spirit of what we're doing here.
            if (!File.Exists(Path))
            {
                MessageBox.Show($"Fatal Error: No Log File found at path \"{Path}\". Application will close now");
                throw new DirectoryNotFoundException();
            }
            try
            {
                File.AppendAllText(Path, $"{DateTime.Now:G} {line} \r\n");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"No Log File found at path \"{Path}\". Could it have been deleted?");
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Fatal Error: Log File is readonly. Application will close now.");
                throw;
            }
        }
    }
}