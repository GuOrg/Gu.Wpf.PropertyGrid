namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Windows;
    using Gu.Units;

    public abstract class UnitSettingControl<TQuantity, TUnit> : NumericSettingControl<TQuantity>
        where TQuantity : struct, IComparable<TQuantity>, IQuantity<TUnit>
        where TUnit : IUnit<TQuantity>
    {
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(TUnit),
            typeof(UnitSettingControl<TQuantity, TUnit>),
            new PropertyMetadata(default(TUnit), OnUnitChanged));

        public static readonly DependencyProperty SymbolFormatProperty = UnitSettingControl.SymbolFormatProperty.AddOwner(
            typeof(UnitSettingControl),
            new FrameworkPropertyMetadata(UnitSettingControl.DefaultSymbolFormat, FrameworkPropertyMetadataOptions.Inherits, OnSymbolFormatChanged));

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
            var oldSuffix = GetSuffix((TUnit)e.OldValue, control.SymbolFormat);
            if (Equals(control.Suffix, oldSuffix))
            {
                control.Suffix = GetSuffix((TUnit)e.NewValue, control.SymbolFormat);
            }
        }

        private static void OnSymbolFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (UnitSettingControl<TQuantity, TUnit>)d;
            var oldSuffix = GetSuffix(control.Unit, (SymbolFormat)e.OldValue);
            if (Equals(control.Suffix, oldSuffix))
            {
                control.Suffix = GetSuffix(control.Unit, (SymbolFormat)e.NewValue);
            }
        }

        protected static string GetSuffix(TUnit unit, SymbolFormat symbolFormat)
        {
            return unit.ToString(symbolFormat);
        }
    }
}