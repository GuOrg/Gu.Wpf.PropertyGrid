namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;
    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class ColumnsTests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "ColumnsWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void Default()
        {
            var groupBox = this.window.GetByText<GroupBox>("default");
            var expected = new[] { 26, 32, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("abcd").ColumnsWidths<TextBox>());
        }

        [Test]
        public void Width_15_20_25()
        {
            var groupBox = this.window.GetByText<GroupBox>("Width 15 20 25");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void Width_15_20_25_abcd()
        {
            var groupBox = this.window.GetByText<GroupBox>("Width 15 20 25 abcd");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("abcd").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MinWidth_15_20_25()
        {
            var groupBox = this.window.GetByText<GroupBox>("MinWidth 15 20 25");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MinWidth_15_20_25_abcd()
        {
            var groupBox = this.window.GetByText<GroupBox>("MinWidth 15 20 25 abcd");
            var expected = new[] { 26, 32, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("abcd").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MaxWidth_15_20_25()
        {
            var groupBox = this.window.GetByText<GroupBox>("MaxWidth 15 20 25");
            var expected = new[] { 6, 13, 7 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MaxWidth_15_20_25_abcd()
        {
            var groupBox = this.window.GetByText<GroupBox>("MaxWidth 15 20 25 abcd");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("abcd").ColumnsWidths<TextBox>());
        }
    }
}