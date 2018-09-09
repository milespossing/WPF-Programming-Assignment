using System;
using System.IO;
using System.Windows;

namespace ProgrammingAssignment.Logging
{
    public class TextLogReader : ILogReader
    {
        public string Path { get; private set; }

        // Enforcing factory pattern in this namespace
        internal TextLogReader(string path)
        {
            Path = path;
        }

        public string ReadLog()
        {
            try
            {
                return File.ReadAllText(Path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Fatal Error: No Log File found at path \"{Path}\". Application will close now");
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