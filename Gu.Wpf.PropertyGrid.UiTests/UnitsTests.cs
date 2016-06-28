namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class UnitsTests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "UnitsWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void Explicit()
        {
            var groupBox = this.window.GetByText<GroupBox>("explicit");
            var metresSetting = groupBox.FindSetting("length (m)");
            var metresBox = metresSetting.Get<TextBox>();
            var millimetresSetting = groupBox.FindSetting("length (mm)");
            var millimetresBox = millimetresSetting.Get<TextBox>();

            Assert.AreEqual("1.2345", metresBox.FormattedText());
            Assert.AreEqual("m", metresSetting.Suffix());
            Assert.AreEqual("1234.5", millimetresBox.FormattedText());
            Assert.AreEqual("mm", millimetresSetting.Suffix());
        }

        [Test]
        public void Bound()
        {
            var groupBox = this.window.GetByText<GroupBox>("bound");
            var doubleBox = groupBox.FindSetting("double").Get<TextBox>();
            var lengthBox = groupBox.FindSetting("length").Get<TextBox>();
            var digitsBox = groupBox.FindSetting("digits").Get<TextBox>();

            Assert.AreEqual("0.000", doubleBox.FormattedText());
            Assert.AreEqual("12.346", lengthBox.FormattedText());

            digitsBox.Text = "2";
            groupBox.GetByText<Button>("lose focus").Click();

            Assert.AreEqual("0.00", doubleBox.FormattedText());
            Assert.AreEqual("12.35", lengthBox.FormattedText());
        }
    }
}