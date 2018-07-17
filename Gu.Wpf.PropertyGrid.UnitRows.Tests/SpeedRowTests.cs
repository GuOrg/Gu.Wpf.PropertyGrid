namespace Gu.Wpf.PropertyGrid.UnitRows.Tests
{
    using System.Threading;

    using Gu.Units;

    using NUnit.Framework;

    [Apartment(ApartmentState.STA)]
    public class SpeedRowTests
    {
        [Test]
        public void UnitUpdatesUnitText()
        {
            var control = new SpeedRow { Unit = SpeedUnit.MillimetresPerSecond };
            Assert.AreEqual("\u00A0mm/s", control.UnitText);

            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.AreEqual("\u00A0cm/h", control.UnitText);
        }

        [Test]
        public void SymbolFormatUpdatesUnitText()
        {
            var control = new SpeedRow { SymbolFormat = SymbolFormat.FractionSuperScript };
            Assert.AreEqual("\u00A0m/s", control.UnitText);
            control.SymbolFormat = SymbolFormat.SignedHatPowers;
            Assert.AreEqual("\u00A0m*s^-1", control.UnitText);
        }
    }
}
