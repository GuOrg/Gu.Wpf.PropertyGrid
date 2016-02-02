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
        private int intValue;
        private int? nullableIntValue;
        private double doubleValue;
        private double? nullableDoubleValue;
        private Speed speedValue;
        private Length? nullableLengthValue;

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

        public Length? NullableLengthValue
        {
            get { return this.nullableLengthValue; }
            set
            {
                if (value.Equals(this.nullableLengthValue)) return;
                this.nullableLengthValue = value;
                this.OnPropertyChanged();
            }
        }

        public Speed SpeedValue
        {
            get { return this.speedValue; }
            set
            {
                if (value.Equals(this.speedValue)) return;
                this.speedValue = value;
                this.OnPropertyChanged();
            }
        }

        public int IntValue
        {
            get { return this.intValue; }
            set
            {
                if (value == this.intValue) return;
                this.intValue = value;
                this.OnPropertyChanged();
            }
        }

        public int? NullableIntValue
        {
            get { return this.nullableIntValue; }
            set
            {
                if (value == this.nullableIntValue) return;
                this.nullableIntValue = value;
                this.OnPropertyChanged();
            }
        }

        public double DoubleValue
        {
            get { return this.doubleValue; }
            set
            {
                if (value.Equals(this.doubleValue)) return;
                this.doubleValue = value;
                this.OnPropertyChanged();
            }
        }

        public double? NullableDoubleValue
        {
            get { return this.nullableDoubleValue; }
            set
            {
                if (value.Equals(this.nullableDoubleValue)) return;
                this.nullableDoubleValue = value;
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
