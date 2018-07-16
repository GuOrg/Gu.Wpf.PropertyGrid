namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Security;
    using System.Windows.Controls;

    /// <inheritdoc />
    public class RowDefinitionsConverter : TypeConverter
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
            ////return destinationType == typeof(InstanceDescriptor) ||
            ////       destinationType == typeof(string);
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
                var rowDefinitions = lengths.Select(gl => new RowDefinition { Height = gl });
                return new RowDefinitions(rowDefinitions);
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
