namespace Gu.Wpf.PropertyGrid.Demo
{
    using System;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Func<object, bool> condition;
        public RelayCommand(Action<object> action, Func<object, bool> condition)
        {
            this.action = action;
            this.condition = condition ?? (_ => true);
        }

        public RelayCommand(Action<object> action)
        {
            this.action = action;
            this.condition = _ => true;
        }

        /// <summary>
        /// http://stackoverflow.com/a/2588145/1069200
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.condition(parameter);
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}