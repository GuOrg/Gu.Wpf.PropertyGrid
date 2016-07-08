namespace Gu.Wpf.PropertyGrid.UnitRows.Tests
{
    using System.Threading;

    using Gu.Units;

    using NUnit.Framework;

    [Apartment(ApartmentState.STA)]
    public class SpeedRowTests
    {
        [Test]
        public void UnitUpdatesSuffix()
        {
            var control = new SpeedRow();
            Assert.AreEqual("\u00A0m/s", control.Suffix);
            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.AreEqual("\u00A0cm/h", control.Suffix);
        }

        [Test]
        public void SymbolFormatUpdatesSuffix()
        {
            var control = new SpeedRow();
            Assert.AreEqual("\u00A0m/s", control.Suffix);
            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.AreEqual("\u00A0cm/h", control.Suffix);
        }
    }
}