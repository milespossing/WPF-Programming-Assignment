using System;
using System.Windows.Input;

namespace ProgrammingAssignment.ViewModels
{
    delegate void Subroutine();

    // Used to make Command Binding just a bit easier
    class SimpleCommand : ICommand
    {
        private Subroutine _method;

        public SimpleCommand(Subroutine method)
        {
            _method = method;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _method.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}