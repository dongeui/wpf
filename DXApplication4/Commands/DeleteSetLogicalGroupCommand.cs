﻿using DXApplication4.ViewModels;
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
    /// 논리그룹에 저장된 조직 삭제 커맨드
    /// </summary>
    public class DeleteSetLogicalGroupCommand : ICommand
    {
        public DeleteSetLogicalGroupCommand()
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
            OnDeleteSetLogicalGroupCommandExecuted();
        }

        private void OnDeleteSetLogicalGroupCommandExecuted()
        {
            MessageBox.Show("OnDeleteSetLogicalGroupCommandExecuted");
        }
    }
}
