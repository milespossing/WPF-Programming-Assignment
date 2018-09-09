using System.Windows.Input;
using ProgrammingAssignment.Logging;

namespace ProgrammingAssignment.ViewModels
{
    public class LogViewerViewModel : ViewModelBase
    {
        public string Log { get; private set; }

        private ILogReader _logReader;

        public LogViewerViewModel()
        {

        }

        public LogViewerViewModel(ILogReader logReader)
        {
            _logReader = logReader;
            Log = _logReader.ReadLog();
        }
    }
}