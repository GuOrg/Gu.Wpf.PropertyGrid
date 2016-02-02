namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Security;
    using System.Windows.Controls;

    public class GridCellConverter : TypeConverter
    {
        private static readonly char[] SeparatorChars = { ',', ' ' };

        public override bool CanConvertFrom(
            ITypeDescriptorContext typeDescriptorContext,
            Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override bool CanConvertTo(
            ITypeDescriptorContext typeDescriptorContext,
            Type destinationType)
        {
            return false;
        }

        public override object ConvertFrom(
            ITypeDescriptorContext typeDescriptorContext,
            CultureInfo cultureInfo,
            object source)
        {
            var text = source as string;
            if (text != null)
            {
                var strings = text.Split(SeparatorChars, StringSplitOptions.RemoveEmptyEntries);
                if (strings.Length != 2)
                {
                    var message = $"Could not parse {text} to a grid cell. Expected two ints";
                    throw new FormatException(message);
                }

                return new GridCell(int.Parse(strings[0]), int.Parse(strings[1]));
            }

            return base.ConvertFrom(typeDescriptorContext, cultureInfo, source);
        }

        [SecurityCritical]
        public override object ConvertTo(
            ITypeDescriptorContext typeDescriptorContext,
            CultureInfo cultureInfo,
            object value,
            Type destinationType)
        {
            throw new NotSupportedException();
        }
    }
}