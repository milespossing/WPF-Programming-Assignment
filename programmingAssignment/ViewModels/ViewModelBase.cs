using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProgrammingAssignment.Annotations;

namespace ProgrammingAssignment.ViewModels
{
    // Used to include the OnPropertyChanged Method (as well as event) in ViewModel Classes
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}