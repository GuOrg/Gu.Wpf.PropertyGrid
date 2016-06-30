namespace Gu.Wpf.PropertyGrid.Tests
{
    using System;
    using System.Linq;
    using System.Threading;

    using NUnit.Framework;

    [Apartment(ApartmentState.STA)]
    public class EnumRowTests
    {
        [Test]
        public void SettingValueUpdatesEnumValues()
        {
            var control = new EnumRow();
            Assert.Null(control.EnumValues);

            control.Value = StringComparison.CurrentCulture;

            Assert.AreEqual(typeof(StringComparison), control.EnumType);
            var expected = Enum.GetValues(typeof(StringComparison))
                .Cast<IFormattable>()
                .ToArray();
            Assert.AreEqual(expected, control.EnumValues);
        }

        [Test]
        public void SettingEnumTypeUpdatesEnumValues()
        {
            var control = new EnumRow();
            Assert.Null(control.EnumValues);

            control.EnumType = typeof(StringComparison);

            var expected = Enum.GetValues(typeof(StringComparison))
                .Cast<IFormattable>()
                .ToArray();
            Assert.AreEqual(expected, control.EnumValues);
        }
    }
}
