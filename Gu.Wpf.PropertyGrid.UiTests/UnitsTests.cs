namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.UIItems.WPFUIItems;

    public class UnitsTests
    {
        private Application application;
        private Window window;

        private Button loseFocusButton;

        private TextBox lengthValueTextBox;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "UnitsWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
            this.loseFocusButton = this.window.GetByText<Button>("lose focus");
            this.lengthValueTextBox = this.window.Get<TextBox>("lengthValueTextBox");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            this.lengthValueTextBox.Text = "0.0123456 m";
            this.loseFocusButton.Click();
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
            //Assert.AreEqual("m", metresSetting.Suffix());
            Assert.AreEqual("12.3456", millimetresBox.Text);
            //Assert.AreEqual("mm", millimetresSetting.Suffix());

            metresBox.Text = "2.4";
            this.loseFocusButton.Click();
            Assert.AreEqual("2400", millimetresBox.Text);
        }

        [Test]
        public void Style()
        {
            var groupBox = this.window.GetByText<GroupBox>("style");
            var settingControl = groupBox.FindSetting("length");
            var textBox = settingControl.Get<TextBox>();

            Assert.AreEqual("12.3456", textBox.Text);
            //Assert.AreEqual("mm", settingControl.Suffix());

            textBox.Text = "2";
            Assert.AreEqual("0.0123456\u00A0m", this.lengthValueTextBox.Text);
            this.loseFocusButton.Click();
            Assert.AreEqual("0.002\u00A0m", this.lengthValueTextBox.Text);
        }

        [Test]
        public void BoundUnit()
        {
            var groupBox = this.window.GetByText<GroupBox>("bound");
            var settingControl = groupBox.FindSetting("length");
            var textBox = settingControl.Get<TextBox>();

            Assert.AreEqual("1.23456", textBox.Text);
            //Assert.AreEqual("cm", settingControl.Suffix());

            groupBox.FindSetting("selector").Get<ComboBox>().Select("m");

            Assert.AreEqual("0.0123456", textBox.Text);
            //Assert.AreEqual("m", settingControl.Suffix());
        }
    }
}