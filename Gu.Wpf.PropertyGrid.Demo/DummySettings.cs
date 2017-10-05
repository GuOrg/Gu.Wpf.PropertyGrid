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
        private string stringValue = string.Empty;
        private bool boolValue;
        private bool hasErrors;
        private CultureInfo currentCulture;
        private Length? lengthMin;
        private Length? lengthMax;

        public DummySettings()
        {
            this.currentCulture = this.Cultures[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors
        {
            get => this.hasErrors;
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
            get => this.stringValue;
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
            get => this.boolValue;
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
            get => this.intValue;
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
            get => this.nullableIntValue;
            set
            {
                if (value == this.nullableIntValue) return;
                this.nullableIntValue = value;
                this.OnPropertyChanged();
            }
        }

        public double DoubleValue
        {
            get => this.doubleValue;
            set
            {
                if (value.Equals(this.doubleValue)) return;
                this.doubleValue = value;
                this.OnPropertyChanged();
            }
        }

        public double? NullableDoubleValue
        {
            get => this.nullableDoubleValue;
            set
            {
                if (value.Equals(this.nullableDoubleValue)) return;
                this.nullableDoubleValue = value;
                this.OnPropertyChanged();
            }
        }

        public Length LengthValue
        {
            get => this.lengthValue;
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

        public Length? LengthMin
        {
            get => this.lengthMin;
            set
            {
                if (value.Equals(this.lengthMin)) return;
                this.lengthMin = value;
                this.OnPropertyChanged();
            }
        }

        public Length? LengthMax
        {
            get => this.lengthMax;
            set
            {
                if (value.Equals(this.lengthMax)) return;
                this.lengthMax = value;
                this.OnPropertyChanged();
            }
        }

        public Length? NullableLengthValue
        {
            get => this.nullableLengthValue;
            set
            {
                if (value.Equals(this.nullableLengthValue)) return;
                this.nullableLengthValue = value;
                this.OnPropertyChanged();
            }
        }

        public Speed SpeedValue
        {
            get => this.speedValue;
            set
            {
                if (value.Equals(this.speedValue)) return;
                this.speedValue = value;
                this.OnPropertyChanged();
            }
        }

        public LengthUnit CurrentLengthUnit
        {
            get => this.currentLengthUnit;
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
            get => this.currentStringComparison;
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
            get => this.currentCulture;
            set
            {
                if (Equals(value, this.currentCulture)) return;
                this.currentCulture = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(this.StringValue)));
        }

        public void Reset()
        {
            this.intValue = 0;
            this.nullableIntValue = null;
            this.doubleValue = 0;
            this.nullableDoubleValue = null;
            this.lengthValue = Length.FromMillimetres(12.3456);
            this.currentLengthUnit = LengthUnit.Centimetres;
            this.currentStringComparison = default(StringComparison);
            this.speedValue = default(Speed);
            this.nullableLengthValue = null;
            this.stringValue = string.Empty;
            this.boolValue = false;
            this.hasErrors = false;
            this.currentCulture = null;
            this.lengthMin = null;
            this.lengthMax = null;
            this.OnPropertyChanged(string.Empty);
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(string.Empty));
        }
    }
}
