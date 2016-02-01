namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using Gu.Units;

    public abstract class UnitSettingControl<TQuantity, TUnit> : NumericSettingControl<TQuantity>, IQuantityScalarConverter
        where TQuantity : struct, IComparable<TQuantity>, IQuantity<TUnit>
        where TUnit : IUnit<TQuantity>
    {
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(TUnit),
            typeof(UnitSettingControl<TQuantity, TUnit>),
            new PropertyMetadata(default(TUnit), OnUnitChanged));

        public static readonly DependencyProperty SymbolFormatProperty = UnitSettingControl.SymbolFormatProperty.AddOwner(
            typeof(UnitSettingControl<TQuantity, TUnit>),
            new FrameworkPropertyMetadata(UnitSettingControl.DefaultSymbolFormat, FrameworkPropertyMetadataOptions.Inherits, OnSymbolFormatChanged));

        internal event RoutedEventHandler UnitChanged
        {
            add { this.AddHandler(UnitSettingControl.UnitChangedEvent, value); }
            remove { this.RemoveHandler(UnitSettingControl.UnitChangedEvent, value); }
        }

        public TUnit Unit
        {
            get { return (TUnit)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        public SymbolFormat SymbolFormat
        {
            get { return (SymbolFormat)this.GetValue(SymbolFormatProperty); }
            set { this.SetValue(SymbolFormatProperty, value); }
        }

        protected static void OnUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (UnitSettingControl<TQuantity, TUnit>)d;
            var oldSuffix = CreateSuffix((TUnit)e.OldValue, control.SymbolFormat);
            if (Equals(control.Suffix, oldSuffix))
            {
                control.Suffix = CreateSuffix((TUnit)e.NewValue, control.SymbolFormat);
            }

            control.RaiseEvent(UnitSettingControl.UnitChangedEventArgs);
        }

        private static void OnSymbolFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (UnitSettingControl<TQuantity, TUnit>)d;
            var oldSuffix = CreateSuffix(control.Unit, (SymbolFormat)e.OldValue);
            if (Equals(control.Suffix, oldSuffix))
            {
                control.Suffix = CreateSuffix(control.Unit, (SymbolFormat)e.NewValue);
            }
        }

        protected static string CreateSuffix(TUnit unit, SymbolFormat symbolFormat)
        {
            return unit.ToString(symbolFormat);
        }

        public double GetScalarValue(IQuantity quantity)
        {
            return this.Unit.GetScalarValue((TQuantity)quantity);
        }

        public IQuantity GetQuantityValue(double value)
        {
            return this.Unit.CreateQuantity(value);
        }
    }
}