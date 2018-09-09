using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ProgrammingAssignment.Annotations;
using ProgrammingAssignment.Logging;
using ProgrammingAssignment.Models;

namespace ProgrammingAssignment.ViewModels
{
    public class DrugIncrementerViewModel : ViewModelBase
    {
        private DrugBatch batch;
        private ILogWriter _logWriter;

        public string DrugName => batch.Drug.Name;
        public string DrugCount => batch.Count.ToString();

        public ICommand IncrementCommand => new SimpleCommand(IncrementBatch);

        public DrugIncrementerViewModel()
        {
            batch = new DrugBatch();
        }

        public DrugIncrementerViewModel(Drug drug, ILogWriter logWriter)
        {
            _logWriter = logWriter;
            batch = new DrugBatch(drug);
        }

        private void IncrementBatch()
        {
            LogEntry log = batch.Increment();
            _logWriter.WriteLog(log);
            OnPropertyChanged(nameof(DrugCount));
        }

        public void ResetBatch()
        {
            LogEntry log = batch.Reset();
            _logWriter.WriteLog(log);
            OnPropertyChanged(nameof(DrugCount));
        }
    }
}