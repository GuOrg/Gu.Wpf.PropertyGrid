namespace Gu.Wpf.PropertyGrid.UnitSettingControls.Tests
{
    using Gu.Units;
    using xunit.wpf;
    using Xunit;

    public class LengthSettingControlTests
    {
        [WpfFact]
        public void UnitUpdatesSuffix()
        {
            var control = new LengthSettingControl();
            Assert.Equal("mm", control.Suffix);
            control.Unit = LengthUnit.Centimetres;
            Assert.Equal("cm", control.Suffix);
        }
    }
}
