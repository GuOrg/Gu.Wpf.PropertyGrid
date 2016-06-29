namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.WindowsAPI;

    public class NestedTests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "NestedWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void CyclesFocus()
        {
            var groupBox = this.window.GetByText<GroupBox>("nested longer");
            var rootBox = groupBox.FindSetting("root").Value<TextBox>();
            var shortBox = groupBox.FindSetting("a").Value<TextBox>();
            var longBox = groupBox.FindSetting("long header").Value<TextBox>();
            rootBox.Focus();
            Assert.True(rootBox.IsFocussed);
            Assert.False(shortBox.IsFocussed);
            Assert.False(longBox.IsFocussed);

            this.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.False(rootBox.IsFocussed);
            Assert.True(shortBox.IsFocussed);
            Assert.False(longBox.IsFocussed);

            this.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.False(rootBox.IsFocussed);
            Assert.False(shortBox.IsFocussed);
            Assert.True(longBox.IsFocussed);

            this.window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Assert.True(rootBox.IsFocussed);
            Assert.False(shortBox.IsFocussed);
            Assert.False(longBox.IsFocussed);
        }

        [Test]
        public void ColumnWidthsWhenNestedLonger()
        {
            var groupBox = this.window.GetByText<GroupBox>("nested longer");
            var expected = new[] { 64, 61, 55 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("root").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("long header").ColumnsWidths<TextBox>());
        }

        [Test]
        public void ColumnWidthsWhenNestedShorter()
        {
            var groupBox = this.window.GetByText<GroupBox>("nested shorter");
            var expected = new[] { 26, 32, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("root").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindSetting("b").ColumnsWidths<TextBox>());
        }
    }
}