namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Security;

    public class ColumnDefinitionsConverter : TypeConverter
    {
        /// <inheritdoc />
        public override bool CanConvertFrom(
            ITypeDescriptorContext typeDescriptorContext,
            Type sourceType)
        {
            return sourceType == typeof(string);
        }

        /// <inheritdoc />
        public override bool CanConvertTo(
            ITypeDescriptorContext typeDescriptorContext,
            Type destinationType)
        {
            return false;
        }

        /// <inheritdoc />
        public override object ConvertFrom(
            ITypeDescriptorContext typeDescriptorContext,
            CultureInfo cultureInfo,
            object source)
        {
            if (source is string text)
            {
                var lengths = GridLengthsParser.Parse(typeDescriptorContext, cultureInfo, text);
                var columnDefinitions = lengths.Select(gl => new System.Windows.Controls.ColumnDefinition { Width = gl });
                return new ColumnDefinitions(columnDefinitions);
            }

            return base.ConvertFrom(typeDescriptorContext, cultureInfo, source);
        }

        /// <inheritdoc />
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
