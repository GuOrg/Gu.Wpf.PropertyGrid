namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class MultiplyConverter : MarkupExtension, IValueConverter
    {
        public MultiplyConverter(double factor)
        {
            this.Factor = factor;
        }

        [ConstructorArgument("factor")]
        public double Factor { get; set; } = 1.0;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Byte:
                    return this.Factor * (Byte)value;
                case TypeCode.Int16:
                    return this.Factor * (Int16)value;
                case TypeCode.UInt16:
                    return this.Factor * (UInt16)value;
                case TypeCode.Int32:
                    return this.Factor * (Int32)value;
                case TypeCode.UInt32:
                    return this.Factor * (UInt32)value;
                case TypeCode.Int64:
                    return this.Factor * (Int64)value;
                case TypeCode.UInt64:
                    return this.Factor * (UInt64)value;
                case TypeCode.Single:
                    return this.Factor * (Single)value;
                case TypeCode.Double:
                    return this.Factor * (double)value;
                case TypeCode.Decimal:
                    return (decimal)(this.Factor * (double)value);
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.DBNull:
                case TypeCode.Boolean:
                case TypeCode.Char:
                case TypeCode.SByte:
                case TypeCode.DateTime:
                case TypeCode.String:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (value is TimeSpan)
            {
                return TimeSpan.FromTicks((long)(this.Factor * ((TimeSpan)value).Ticks));
            }

            throw new ArgumentOutOfRangeException($"Could not figure out how to multiply {value.GetType()}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
