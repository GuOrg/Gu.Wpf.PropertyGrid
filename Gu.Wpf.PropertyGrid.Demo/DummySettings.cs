namespace Gu.Wpf.PropertyGrid.Demo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Gu.Units;

    using JetBrains.Annotations;

    public class DummySettings : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private int intValue;
        private int? nullableIntValue;
        private double doubleValue;
        private double? nullableDoubleValue;
        private Length lengthValue = Length.FromMillimetres(12.3456);
        private LengthUnit currentLengthUnit = LengthUnit.Centimetres;
        private StringComparison currentStringComparison;
        private Speed speedValue;
        private Length? nullableLengthValue;
        private string stringValue;
        private bool boolValue;
        private bool hasErrors;

        private CultureInfo currentCulture;

        public DummySettings()
        {
            this.currentCulture = this.Cultures[0];
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

        public string StringValue
        {
            get { return this.stringValue; }
            set
            {
                if (value == this.stringValue)
                {
                    return;
                }
                this.stringValue = value;
                this.OnPropertyChanged();
            }
        }

        public bool BoolValue
        {
            get { return this.boolValue; }
            set
            {
                if (value == this.boolValue)
                {
                    return;
                }
                this.boolValue = value;
                this.OnPropertyChanged();
            }
        }

        public int IntValue
        {
            get { return this.intValue; }
            set
            {
                if (value == this.intValue)
                {
                    return;
                }
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

        public IEnumerable GetErrors(string propertyName)
        {
            if (!this.hasErrors)
            {
                return Enumerable.Empty<string>();
            }

            if (propertyName != nameof(this.HasErrors) && propertyName != nameof(this.StringValue))
            {
                return Enumerable.Empty<string>();
            }

            return new[] { $"{propertyName} has {nameof(INotifyDataErrorInfo)} error" };
        }

        public IReadOnlyList<CultureInfo> Cultures { get; } = new[] { CultureInfo.GetCultureInfo("sv-se"), CultureInfo.GetCultureInfo("en-us"), };

        public CultureInfo CurrentCulture
        {
            get
            {
                return this.currentCulture;
            }
            set
            {
                if (Equals(value, this.currentCulture)) return;
                this.currentCulture = value;
                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(this.StringValue)));
        }
    }
}
