﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PiratesBay.Commands
{
    class AddNewPersonCommand: ICommand
    {
        private Func<bool> canExecuteFunc;
        private Action execute;

        public AddNewPersonCommand(Func<bool> canExecute, Action execute)
        {
            canExecuteFunc = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object param)
        {
            var result =  canExecuteFunc();
            return result;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter = null)
        {
            if (canExecuteFunc()) 
            {
                execute();
            }
        }
    }
}
