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

    public class SettingsVm : INotifyPropertyChanged
    {
        public static readonly IReadOnlyList<LengthUnit> LengthUnits = new[] { LengthUnit.Centimetres, LengthUnit.Inches, };

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

        public DummySettings EditableCopy { get; } = new DummySettings();

        public DummySettings LastSaved { get; } = new DummySettings();

        public ICommand SaveCommand { get; }

        public ICommand UndoAllCommand { get; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
