using System;

namespace ProgrammingAssignment.Models
{
    public class LogEntry
    {
        // This used to include the LogDate, but I decided to make the logger authoritative on log date.
        public Drug Drug;
        public int PreviousCount;
        public int NewCount;

        public LogEntry()
        {
            
        }

        // Easy initializer
        public LogEntry(Drug drug, int previousCount, int newCount)
        {
            Drug = drug;
            PreviousCount = previousCount;
            NewCount = newCount;
        }

        // Returns the log-ready string representation of the object
        public override string ToString()
        {
            return $"{Drug.Name} {PreviousCount} {NewCount}";
        }
    }
}