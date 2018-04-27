using DXApplication4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DXApplication4.Commands
{
    /// <summary>
    /// 논리그룹 셋팅 커맨드
    /// </summary>
    public class SetLogicalGroupCommand : ICommand
    {
        public SetLogicalGroupCommand()
        {
        }

        public event EventHandler CanExecuteChanged
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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OnSetLogicalGroupCommandExecuted();
        }

        private void OnSetLogicalGroupCommandExecuted()
        {
            MessageBox.Show("OnSetLogicalGroupCommandExecuted");
        }
    }
}
