namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using Gu.Units;

    public interface IQuantityFormatter
    {
        string Format(IQuantity quantity);
    }
}