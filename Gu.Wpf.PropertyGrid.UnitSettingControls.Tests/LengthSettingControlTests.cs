namespace Gu.Wpf.PropertyGrid.UnitSettingControls.Tests
{
    using Gu.Units;
    using Xunit;

    public class LengthSettingControlTests
    {
        [Fact]
        public void UnitUpdatesSuffix()
        {
            var control = new LengthSettingControl();
            Assert.Equal("mm", control.Suffix);
            control.Unit = LengthUnit.Centimetres;
            Assert.Equal("cm", control.Suffix);
        }
    }

    public class SpeedSettingControlTests
    {
        [Fact]
        public void UnitUpdatesSuffix()
        {
            var control = new SpeedSettingControl();
            Assert.Equal("m/s", control.Suffix);
            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.Equal("cm/h", control.Suffix);
        }

        [Fact]
        public void SymbolFormatUpdatesSuffix()
        {
            var control = new SpeedSettingControl();
            Assert.Equal("m/s", control.Suffix);
            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.Equal("cm/h", control.Suffix);
        }
    }
}
