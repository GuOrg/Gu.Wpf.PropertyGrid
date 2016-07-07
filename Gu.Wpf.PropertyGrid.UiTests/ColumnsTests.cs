namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;
    using TestStack.White.UIItems;

    public class ColumnsTests : WindowTests
    {
        protected override string WindowName { get; } = "ColumnsWindow";

        [Test]
        public void Default()
        {
            var groupBox = this.Window.GetByText<GroupBox>("default");
            var expected = new[] { 6, 12, 7 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void Default_abcd()
        {
            var groupBox = this.Window.GetByText<GroupBox>("default abcd");
            var expected = new[] { 26, 42, 49 };
            var actual = groupBox.FindRow("a").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
            actual = groupBox.FindRow("abcd").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Star_star_star()
        {
            var groupBox = this.Window.GetByText<GroupBox>("* * *");
            var expected = new[] { 33, 33, 33 };
            var actual = groupBox.FindRow("a").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
            actual = groupBox.FindRow("abcd").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Width_15_20_25()
        {
            var groupBox = this.Window.GetByText<GroupBox>("Width 15 20 25");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void Width_15_20_25_abcd()
        {
            var groupBox = this.Window.GetByText<GroupBox>("Width 15 20 25 abcd");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
            CollectionAssert.AreEqual(expected, groupBox.FindRow("abcd").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MinWidth_15_20_25()
        {
            var groupBox = this.Window.GetByText<GroupBox>("MinWidth 15 20 25");
            var expected = new[] { 15, 20, 25 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MinWidth_15_20_25_abcd()
        {
            var groupBox = this.Window.GetByText<GroupBox>("MinWidth 15 20 25 abcd");
            var expected = new[] { 26, 42, 49 };
            var actual = groupBox.FindRow("a").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
            actual = groupBox.FindRow("abcd").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void MaxWidth_15_20_25()
        {
            var groupBox = this.Window.GetByText<GroupBox>("MaxWidth 15 20 25");
            var expected = new[] { 6, 13, 7 };
            CollectionAssert.AreEqual(expected, groupBox.FindRow("a").ColumnsWidths<TextBox>());
        }

        [Test]
        public void MaxWidth_15_20_25_abcd()
        {
            var groupBox = this.Window.GetByText<GroupBox>("MaxWidth 15 20 25 abcd");
            var expected = new[] { 15, 20, 25 };
            var actual = groupBox.FindRow("a").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);

            expected = new[] { 15, 42, 3 }; // this looks strange but the textbox gets clipped here.
            actual = groupBox.FindRow("abcd").ColumnsWidths<TextBox>();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}