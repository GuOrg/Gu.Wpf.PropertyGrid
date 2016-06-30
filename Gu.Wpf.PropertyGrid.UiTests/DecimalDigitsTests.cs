namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class DecimalDigitsTests
    {
        private Application application;
        private Window window;

        private Button loseFocusButton;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "DecimalDigitsWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.loseFocusButton = this.window.GetByText<Button>("lose focus");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void Inherits()
        {
            var groupBox = this.window.GetByText<GroupBox>("attached prop");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }

        [Test]
        public void Explicit()
        {
            var groupBox = this.window.GetByText<GroupBox>("explicit");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }

        [Test]
        public void Bound()
        {
            var groupBox = this.window.GetByText<GroupBox>("bound");
            var doubleBox = groupBox.FindRow("double").Value<TextBox>();
            var lengthBox = groupBox.FindRow("length").Value<TextBox>();
            var digitsBox = groupBox.FindRow("digits").Value<TextBox>();

            Assert.AreEqual("0.000", doubleBox.FormattedText());
            Assert.AreEqual("12.346", lengthBox.FormattedText());

            digitsBox.Text = "2";
            this.loseFocusButton.Click();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }
    }
}