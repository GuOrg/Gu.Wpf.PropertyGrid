namespace Gu.Wpf.PropertyGrid.UnitSettingControls.Tests
{
    using Gu.Units;
    using xunit.wpf;
    using Xunit;

    public class SpeedSettingControlTests
    {
        [WpfFact]
        public void UnitUpdatesSuffix()
        {
            var control = new SpeedSettingControl();
            Assert.Equal("m/s", control.Suffix);
            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.Equal("cm/h", control.Suffix);
        }

        [WpfFact]
        public void SymbolFormatUpdatesSuffix()
        {
            var control = new SpeedSettingControl();
            Assert.Equal("m/s", control.Suffix);
            control.Unit = SpeedUnit.CentimetresPerHour;
            Assert.Equal("cm/h", control.Suffix);
        }
    }
}