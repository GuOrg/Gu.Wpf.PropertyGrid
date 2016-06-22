namespace Gu.Wpf.PropertyGrid.UnitSettingControls.Tests
{
    using System.Threading;

    using Gu.Units;

    using NUnit.Framework;

    [Apartment(ApartmentState.STA)]
    public class SpeedSettingControlTests
    {
        [Test]
        public void UnitUpdatesSuffix()
        {
            var control = new SpeedSettingControl();
            Assert.AreEqual("m/s", control.Suffix);
            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.AreEqual("cm/h", control.Suffix);
        }

        [Test]
        public void SymbolFormatUpdatesSuffix()
        {
            var control = new SpeedSettingControl();
            Assert.AreEqual("m/s", control.Suffix);
            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.AreEqual("cm/h", control.Suffix);
        }
    }
}