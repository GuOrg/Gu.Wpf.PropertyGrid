namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;

    public class ValueStylesTests : WindowTests
    {
        protected override string WindowName { get; } = "ValueStylesWindow";

        [Test]
        public void UsesStyle()
        {
            Assert.AreEqual("Green", this.Window.FindRow("checkbox").Value<CheckBox>().ItemStatus());
            Assert.AreEqual("Green", this.Window.FindRow("togglebutton").Value<Button>().ItemStatus());
            Assert.AreEqual("Green", this.Window.FindRow("enum").Value<ComboBox>().ItemStatus());
            Assert.AreEqual("Green", this.Window.FindRow("selector").Value<ComboBox>().ItemStatus());
            Assert.AreEqual("Green", this.Window.FindRow("string").Value<TextBox>().ItemStatus());
            Assert.AreEqual("Blue", this.Window.FindRow("double").Value<TextBox>().ItemStatus());
            Assert.AreEqual("Blue", this.Window.FindRow("length").Value<TextBox>().ItemStatus());
        }
    }
}