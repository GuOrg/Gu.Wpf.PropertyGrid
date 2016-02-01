namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Globalization;
    using System.Security;
    using System.Windows;

    public class QuantityBindingExtensionConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        [SecurityCritical]
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                var quantityBinding = value as QuantityBindingExtension;

                if (quantityBinding == null)
                {
                    throw new ArgumentException($"{nameof(value)} must be of type {typeof(QuantityBindingExtension)}", nameof(value));
                }

                var constructorInfo = typeof(QuantityBindingExtension).GetConstructor(new Type[] { typeof(string) });
                return new InstanceDescriptor(constructorInfo, new object[] { quantityBinding.Property });
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}