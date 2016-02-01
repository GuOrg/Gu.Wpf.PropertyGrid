namespace Gu.Wpf.PropertyGrid
{
    using Gu.Units;

    public interface IQuantityScalarConverter
    {
        double GetScalarValue(IQuantity quantity);

        IQuantity GetQuantityValue(double value);
    }
}