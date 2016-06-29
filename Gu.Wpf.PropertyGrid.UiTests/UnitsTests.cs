namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
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

            Assert.AreEqual("0.0123456", metresBox.Text);
            Assert.AreEqual("m", metresSetting.Suffix());
            Assert.AreEqual("12.3456", millimetresBox.Text);
            Assert.AreEqual("mm", millimetresSetting.Suffix());

            metresBox.Text = "2.4";
            Assert.AreEqual("2400", millimetresBox.Text);
        }

        [Test]
        public void Style()
        {
            var groupBox = this.window.GetByText<GroupBox>("style");
            var settingControl = groupBox.FindSetting("length");
            var textBox = settingControl.Get<TextBox>();

            Assert.AreEqual("12.3456", textBox.Text);
            Assert.AreEqual("mm", settingControl.Suffix());
        }

        [Test]
        public void Bound()
        {
            var groupBox = this.window.GetByText<GroupBox>("bound");
            var settingControl = groupBox.FindSetting("length");
            var textBox = settingControl.Get<TextBox>();

            Assert.AreEqual("1.23456", textBox.Text);
            Assert.AreEqual("cm", settingControl.Suffix());

            groupBox.FindSetting("selector").Get<ComboBox>().Select("m");
            groupBox.GetByText<Button>("lose focus").Click();

            Assert.AreEqual("0.0123456", textBox.Text);
            Assert.AreEqual("m", settingControl.Suffix());
        }
    }
}