namespace Gu.Wpf.PropertyGrid.NumericRows
{
    using System;

    public interface INumericFormatter
    {
        string Format(IFormattable value);
    }
}