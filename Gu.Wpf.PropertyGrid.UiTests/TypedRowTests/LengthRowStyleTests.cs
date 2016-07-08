namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;
    using TestStack.White.UIItems;

    public class LengthRowStyleTests : WindowTests
    {
        protected override string WindowName { get; } = "LengthRowStyleWindow";

        [Test]
        public void CorrectValuesAndSuffixes()
        {
            var defaultRow = this.Window.FindRow("default");
            Assert.AreEqual("\u00A0mm", defaultRow.Suffix().Text);
            Assert.AreEqual("12.3456", defaultRow.Value<TextBox>().Text);

            var cmRow = this.Window.FindRow("explicit cm");
            Assert.AreEqual("\u00A0cm", cmRow.Suffix().Text);
            Assert.AreEqual("1.23456", cmRow.Value<TextBox>().Text);
        }
    }
}