namespace Gu.Wpf.PropertyGrid.Demo
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Gu.State;
    using Gu.Units;

    public class SettingsVm : INotifyPropertyChanged
    {
        public static readonly IReadOnlyList<LengthUnit> LengthUnits = new[] { LengthUnit.Centimetres, LengthUnit.Inches, LengthUnit.Metres, LengthUnit.Millimetres };

        private static readonly PropertiesSettings PropertiesSettings = PropertiesSettings.Build()
                                                                                          .AddImmutableType<CultureInfo>()
                                                                                          .IgnoreProperty<DummySettings>(nameof(DummySettings.Cultures))
                                                                                          .CreateSettings();

        private bool viewHasErrors;

        public SettingsVm()
        {
            // simulating saving
            this.SaveCommand = new RelayCommand(
                _ => Copy.PropertyValues(this.EditableCopy, this.LastSaved, PropertiesSettings),
                _ => !this.ViewHasErrors && !EqualBy.PropertyValues(this.EditableCopy, this.LastSaved, PropertiesSettings));

            this.UndoAllCommand = new RelayCommand(
                _ => Copy.PropertyValues(this.LastSaved, this.EditableCopy, PropertiesSettings),
                _ => !EqualBy.PropertyValues(this.EditableCopy, this.LastSaved, PropertiesSettings));

            this.ResetCommand = new RelayCommand(_ => this.EditableCopy.Reset());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DummySettings EditableCopy { get; } = new DummySettings();

        public DummySettings LastSaved { get; } = new DummySettings();

        public ICommand SaveCommand { get; }

        public ICommand ResetCommand { get; }

        public ICommand UndoAllCommand { get; }

        public bool ViewHasErrors
        {
            get => this.viewHasErrors;
            set
            {
                if (value == this.viewHasErrors)
                {
                    return;
                }

                this.viewHasErrors = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
