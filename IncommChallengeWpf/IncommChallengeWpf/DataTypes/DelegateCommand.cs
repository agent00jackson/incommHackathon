using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IncommChallengeWpf.DataTypes
{
    class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action action;
        public DelegateCommand(Action a)
        {
            action = a;
        }

        public bool CanExecute(object parameter = null)
        {
            return true;
        }

        public void Execute(object parameter = null)
        {
            action.Invoke();
        }
    }
}
