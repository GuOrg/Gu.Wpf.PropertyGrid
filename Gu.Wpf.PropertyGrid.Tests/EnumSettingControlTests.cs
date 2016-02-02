namespace Gu.Wpf.PropertyGrid.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using xunit.wpf;

    public class EnumSettingControlTests
    {
        [WpfFact]
        public void SettingValueUpdatesEnumValues()
        {
            var control = new EnumSettingControl();
            Assert.Null(control.EnumValues);

            control.Value = StringComparison.CurrentCulture;

            Assert.Equal(typeof(StringComparison), control.EnumType);
            var expected = Enum.GetValues(typeof(StringComparison))
                .Cast<IFormattable>()
                .ToArray();
            Assert.Equal(expected, control.EnumValues);
        }

        [WpfFact]
        public void SettingEnumTypeUpdatesEnumValues()
        {
            var control = new EnumSettingControl();
            Assert.Null(control.EnumValues);

            control.EnumType = typeof(StringComparison);

            var expected = Enum.GetValues(typeof(StringComparison))
                .Cast<IFormattable>()
                .ToArray();
            Assert.Equal(expected, control.EnumValues);
        }
    }
}
