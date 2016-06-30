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
            var rootBox = groupBox.FindRow("root").Value<TextBox>();
            var shortBox = groupBox.FindRow("a").Value<TextBox>();
            var longBox = groupBox.FindRow("long header").Value<TextBox>();
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
            var expected = new[] { 64, 96, 86 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("root").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindRow("long header").ColumnsWidths<TextBox>());
        }

        [Test]
        public void ColumnWidthsWhenNestedShorter()
        {
            var groupBox = this.window.GetByText<GroupBox>("nested shorter");
            var expected = new[] { 22, 38, 53 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("root").ColumnsWidths<TextBox>());
            expected[2] = 28;
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
            expected[2] = 28;
            CollectionAssert.AreEqual(expected, groupBox.FindRow("b").ColumnsWidths<TextBox>());
        }
    }
}