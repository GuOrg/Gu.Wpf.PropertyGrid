namespace Gu.Wpf.PropertyGrid.Demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Gu.Units;
    using JetBrains.Annotations;

    public class SettingsVm : INotifyPropertyChanged
    {
        public static IReadOnlyList<LengthUnit> LengthUnits = new[] { LengthUnit.Centimetres, LengthUnit.Inches, };

        private Length lengthValue = Length.FromMillimetres(12.3456);
        private LengthUnit currentLengthUnit = LengthUnits[0];

        public event PropertyChangedEventHandler PropertyChanged;

        public Length LengthValue
        {
            get { return this.lengthValue; }
            set
            {
                if (value.Equals(this.lengthValue))
                {
                    return;
                }

                this.lengthValue = value;
                this.OnPropertyChanged();
            }
        }

        public LengthUnit CurrentLengthUnit
        {
            get { return this.currentLengthUnit; }
            set
            {
                if (value.Equals(this.currentLengthUnit))
                {
                    return;
                }

                this.currentLengthUnit = value;
                this.OnPropertyChanged();
            }
        }

        public StringComparison CurrentStringComparison
        {
            get { throw new System.NotImplementedException(); }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
