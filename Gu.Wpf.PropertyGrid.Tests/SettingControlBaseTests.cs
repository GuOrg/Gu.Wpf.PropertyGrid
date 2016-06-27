namespace Gu.Wpf.PropertyGrid.Tests
{
    using System.Threading;

    using NUnit.Framework;

    [Apartment(ApartmentState.STA)]
    public class SettingControlBaseTests
    {
        [Test]
        public void IsDirty()
        {
            var control = new StringSettingControl();
            Assert.Null(control.IsDirty);

            control.Value = "1";
            Assert.Null(control.IsDirty);

            control.OldValue = "2";
            Assert.True(control.IsDirty);

            control.OldValue = "1";
            Assert.False(control.IsDirty);

            control.Value = "3";
            Assert.True(control.IsDirty);

            control.OldValue = "3";
            Assert.False(control.IsDirty);
        }
    }
}
