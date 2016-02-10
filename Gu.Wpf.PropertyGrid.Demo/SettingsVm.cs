namespace Gu.Wpf.PropertyGrid.Demo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Gu.ChangeTracking;
    using Gu.Units;
    using JetBrains.Annotations;

    public class SettingsVm : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public static readonly IReadOnlyList<LengthUnit> LengthUnits = new[] { LengthUnit.Centimetres, LengthUnit.Inches, };

        private bool hasErrors;

        public SettingsVm()
        {
            // simulating saving
            this.SaveCommand = new RelayCommand(
                _ => Copy.PropertyValues(this.EditableCopy, this.LastSaved),
                _ => !EqualBy.PropertyValues(this.EditableCopy, this.LastSaved));

            this.UndoAllCommand = new RelayCommand(
                _ => Copy.PropertyValues(this.LastSaved, this.EditableCopy),
                _ => !EqualBy.PropertyValues(this.EditableCopy, this.LastSaved));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors
        {
            get
            {
                return this.hasErrors;
            }
            set
            {
                if (value == this.hasErrors)
                {
                    return;
                }
                this.hasErrors = value;
                this.OnPropertyChanged();
                this.OnErrorsChanged();
            }
        }

        public DummySettings EditableCopy { get; } = new DummySettings();

        public DummySettings LastSaved { get; } = new DummySettings();

        public ICommand SaveCommand { get; }

        public ICommand UndoAllCommand { get; }

        public IEnumerable GetErrors(string propertyName)
        {
            return this.hasErrors ? new[] { $"{nameof(INotifyDataErrorInfo)} error" } : Enumerable.Empty<string>();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
