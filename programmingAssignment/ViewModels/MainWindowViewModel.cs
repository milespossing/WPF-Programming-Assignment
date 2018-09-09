using System;
using System.Windows.Input;
using ProgrammingAssignment.Logging;
using ProgrammingAssignment.Models;
using ProgrammingAssignment.Views;

namespace ProgrammingAssignment.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public DrugIncrementerViewModel LeftIncrementer { get; }
        public DrugIncrementerViewModel CenterIncrementer { get; }
        public DrugIncrementerViewModel RightIncrementer { get; }

        public ICommand ResetAllCommand => new SimpleCommand(ResetAll);
        public ICommand LogViewerCommand => new SimpleCommand(ShowLogViewer);

        private ILogWriter _logWriter;

        public MainWindowViewModel()
        {
            _logWriter = LoggerFactory.MakeTextLogger();
            LeftIncrementer = new DrugIncrementerViewModel(new Drug(Properties.Settings.Default.Drug1), _logWriter);
            CenterIncrementer = new DrugIncrementerViewModel(new Drug(Properties.Settings.Default.Drug2), _logWriter);
            RightIncrementer = new DrugIncrementerViewModel(new Drug(Properties.Settings.Default.Drug3), _logWriter);
        }

        private void ResetAll()
        {
            _logWriter.WriteLine("RESET");
            LeftIncrementer.ResetBatch();
            CenterIncrementer.ResetBatch();
            RightIncrementer.ResetBatch();
        }

        private void ShowLogViewer()
        {
            ILogReader reader = LoggerFactory.MakeTextReader(_logWriter.Path);
            LogViewerViewModel vm = new LogViewerViewModel(reader);
            LogViewer viewer = new LogViewer();
            viewer.DataContext = vm;
            viewer.ShowDialog();
        }
    }
}