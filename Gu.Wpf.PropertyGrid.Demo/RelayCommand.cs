namespace Gu.Wpf.PropertyGrid.Demo
{
    using System;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Func<object, bool> condition;

        public RelayCommand(Action<object> action, Func<object, bool> condition = null)
        {
            this.action = action;
            this.condition = condition ?? (_ => true);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
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