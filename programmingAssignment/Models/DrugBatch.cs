using System.Collections;
using System.Collections.Generic;

namespace ProgrammingAssignment.Models
{
    public class DrugBatch
    {
        public Drug Drug { get; }
        public int Count { get; private set; }

        // This was required in order to have the ViewModels not throw null exceptions at design time. Never used.
        public DrugBatch()
        {
            Drug = new Drug();
        }

        public DrugBatch(Drug drug)
        {
            Drug = drug;
        }

        public LogEntry Increment(int amount = 1)
        {
            // This has to be the most abusive thing I've done so far in this project.
            // I'd be interested to see how you guys implement this behavior. Same for Reset method beneath.
            LogEntry output = new LogEntry();
            output.Drug = Drug;
            output.PreviousCount = Count;
            Count += 1;
            output.NewCount = Count;
            return output;
        }

        // Resets the current drug batch to 0
        public LogEntry Reset()
        {
            LogEntry output = new LogEntry();
            output.Drug = Drug;
            output.PreviousCount = Count;
            Count = 0;
            output.NewCount = Count;
            return output;
        }
    }
}