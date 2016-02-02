namespace Gu.Wpf.PropertyGrid.Demo
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Gu.Units;

    using JetBrains.Annotations;

    public class DummySettings : INotifyPropertyChanged
    {
        private Length lengthValue = Length.FromMillimetres(12.3456);
        private LengthUnit currentLengthUnit = LengthUnit.Centimetres;
        private StringComparison currentStringComparison;

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
            get { return this.currentStringComparison; }
            set
            {
                if (value == this.currentStringComparison)
                {
                    return;
                }
                this.currentStringComparison = value;
                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
