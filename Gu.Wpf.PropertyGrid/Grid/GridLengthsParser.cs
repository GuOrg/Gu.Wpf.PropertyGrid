namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows;

    internal static class GridLengthsParser
    {
        private static readonly GridLengthConverter GridLengthConverter = new GridLengthConverter();
        private static readonly char[] SeparatorChars = { ',', ' ' };

        internal static IEnumerable<GridLength> Parse(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, string text)
        {
            try
            {
                var lengths = text.Split(SeparatorChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => (GridLength)GridLengthConverter.ConvertFrom(typeDescriptorContext, cultureInfo, x));
                return lengths;
            }
            catch (Exception e)
            {
                var message = $"Could not parse grid lengts from {text}.\r\n" +
                              $"Expected a string like '* 20 Auto'\r\n" +
                              $"Valid separators are {{{string.Join(", ", SeparatorChars.Select(x => $"'x'"))}}}";
                throw new FormatException(message, e);
            }
        }

        // http://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/Windows/GridLengthConverter.cs,218
        internal static string ToString(GridLength gl, CultureInfo cultureInfo)
        {
            switch (gl.GridUnitType)
            {
                // for Auto print out "Auto". value is always "1.0"
                case GridUnitType.Auto:
                    return "Auto";

                // Star has one special case when value is "1.0".
                // in this case drop value part and print only "Star"
                case GridUnitType.Star:
                    return IsOne(gl.Value)
                        ? "*"
                        : Convert.ToString(gl.Value, cultureInfo) + "*";

                // for Pixel print out the numeric value. "px" can be omitted.
                default:
                    return Convert.ToString(gl.Value, cultureInfo);
            }
        }

        // http://referencesource.microsoft.com/#WindowsBase/Shared/MS/Internal/DoubleUtil.cs,8e95e6558bdb123d
        private static bool IsOne(double value)
        {
            const double DblEpsilon = 2.2204460492503131e-016;
            return Math.Abs(value - 1.0) < 10.0 * DblEpsilon;
        }
    }
}