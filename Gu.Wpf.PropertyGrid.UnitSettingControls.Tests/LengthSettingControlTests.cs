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

        [WpfFact]
        public void UnitUpdatesValueWhenMaxAndMinAreNull()
        {
            var control = new LengthSettingControl { Value = Length.FromCentimetres(1.2) };
            Assert.Equal("mm", control.Suffix);
            Assert.Equal(Length.FromMillimetres(12), control.Value);
            Assert.Equal(12, control.ScalarValue);
            Assert.Equal(null, control.ScalarMinValue);
            Assert.Equal(null, control.ScalarMaxValue);

            control.Unit = LengthUnit.Centimetres;
            Assert.Equal("cm", control.Suffix);
            Assert.Equal(Length.FromMillimetres(12), control.Value);
            Assert.Equal(1.2, control.ScalarValue);
            Assert.Equal(null, control.ScalarMinValue);
            Assert.Equal(null, control.ScalarMaxValue);
        }

        [WpfFact]
        public void UnitUpdatesValueWhenMaxAndMinHaveValues()
        {
            var control = new LengthSettingControl
            {
                Value = Length.FromCentimetres(1.2),
                MinValue = Length.FromCentimetres(-5),
                MaxValue = Length.FromCentimetres(5),
            };
            Assert.Equal("mm", control.Suffix);
            Assert.Equal(Length.FromMillimetres(12), control.Value);
            Assert.Equal(12, control.ScalarValue);
            Assert.Equal(-50, control.ScalarMinValue);
            Assert.Equal(50, control.ScalarMaxValue);

            control.Unit = LengthUnit.Centimetres;
            Assert.Equal("cm", control.Suffix);
            Assert.Equal(Length.FromMillimetres(12), control.Value);
            Assert.Equal(1.2, control.ScalarValue);
            Assert.Equal(-5, control.ScalarMinValue);
            Assert.Equal(5, control.ScalarMaxValue);
        }

        [WpfFact]
        public void ChangeScalarValuesUpdatesQuantityValues()
        {
            var control = new LengthSettingControl
            {
                Value = Length.FromCentimetres(1.2),
                MinValue = Length.FromCentimetres(-5),
                MaxValue = Length.FromCentimetres(5),
            };
            Assert.Equal("mm", control.Suffix);
            Assert.Equal(Length.FromMillimetres(12), control.Value);
            Assert.Equal(12, control.ScalarValue);
            Assert.Equal(-50, control.ScalarMinValue);
            Assert.Equal(50, control.ScalarMaxValue);

            control.ScalarValue = 0.8;
            control.ScalarMinValue = -1.2;
            control.ScalarMaxValue = 2.3;
            Assert.Equal("mm", control.Suffix);
            Assert.Equal(Length.FromMillimetres(0.8), control.Value);
            Assert.Equal(Length.FromMillimetres(-1.2), control.MinValue);
            Assert.Equal(Length.FromMillimetres(2.3), control.MaxValue);
            Assert.Equal(0.8, control.ScalarValue);
            Assert.Equal(-1.2, control.ScalarMinValue);
            Assert.Equal(2.3, control.ScalarMaxValue);

            control.ScalarValue = null;
            control.ScalarMinValue = null;
            control.ScalarMaxValue = null;
            Assert.Equal("mm", control.Suffix);
            Assert.Equal(null, control.Value);
            Assert.Equal(null, control.MinValue);
            Assert.Equal(null, control.MaxValue);
            Assert.Equal(null, control.ScalarValue);
            Assert.Equal(null, control.ScalarMinValue);
            Assert.Equal(null, control.ScalarMaxValue);
        }

        [WpfFact]
        public void ChangeQuantityValuesUpdatesScalarValues()
        {
            var control = new LengthSettingControl
            {
                Value = Length.FromCentimetres(1.2),
                MinValue = Length.FromCentimetres(-5),
                MaxValue = Length.FromCentimetres(5),
            };
            Assert.Equal("mm", control.Suffix);
            Assert.Equal(Length.FromMillimetres(12), control.Value);
            Assert.Equal(Length.FromMillimetres(-50), control.MinValue);
            Assert.Equal(Length.FromMillimetres(50), control.MaxValue);
            Assert.Equal(12, control.ScalarValue);
            Assert.Equal(-50, control.ScalarMinValue);
            Assert.Equal(50, control.ScalarMaxValue);

            control.Value = Length.FromMillimetres(0.8);
            control.MinValue = Length.FromMillimetres(-1.2);
            control.MaxValue = Length.FromMillimetres(2.3);
            Assert.Equal("mm", control.Suffix);
            Assert.Equal(Length.FromMillimetres(0.8), control.Value);
            Assert.Equal(Length.FromMillimetres(-1.2), control.MinValue);
            Assert.Equal(Length.FromMillimetres(2.3), control.MaxValue);
            Assert.Equal(0.8, control.ScalarValue);
            Assert.Equal(-1.2, control.ScalarMinValue);
            Assert.Equal(2.3, control.ScalarMaxValue);

            control.Value = null;
            control.MinValue = null;
            control.MaxValue = null;
            Assert.Equal("mm", control.Suffix);
            Assert.Equal(null, control.Value);
            Assert.Equal(null, control.MinValue);
            Assert.Equal(null, control.MaxValue);
            Assert.Equal(null, control.ScalarValue);
            Assert.Equal(null, control.ScalarMinValue);
            Assert.Equal(null, control.ScalarMaxValue);
        }
    }
}
