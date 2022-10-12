using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieRankingApplication.MvvmHelpers;
    public class DelegateCommand : ICommand
{
    // Requires testing
    public event EventHandler? CanExecuteChanged  // Need to Properly look into this.
    {
        add
        {
            CommandManager.RequerySuggested += value;
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
        }
    }

    Action<object> _action;
    // Changed from Action _action to this, may need to be changed back
    Func<object, bool> _canExecute;


    public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
    {
        _action = execute;
        _canExecute = canExecute;
    }

    // May require mild rewriting later
    public bool CanExecute(object? parameter)
    {
        if (_canExecute != null)
        {
            return _canExecute(parameter!);
        }
        else
        {
            return false;
        }
    }

    public void Execute(object? parameter)
    {
        _action(parameter!);
    }
}

