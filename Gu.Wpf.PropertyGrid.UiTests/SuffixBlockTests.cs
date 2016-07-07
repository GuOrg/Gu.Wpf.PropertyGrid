namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;

    public class SuffixBlockTests : WindowTests
    {
        protected override string WindowName { get; } = "SuffixBlockWindow";

        [Test]
        public void SuffixBlockStyle()
        {
            var groupBox = this.Window.GetByText<GroupBox>("suffixblock style");
            Assert.AreEqual("Green", groupBox.Get<Label>(SearchCriteria.ByText("abc")).ItemStatus());
        }

        [Test]
        public void InheritsTextBlockStyle()
        {
            var groupBox = this.Window.GetByText<GroupBox>("inherits textblock style");
            Assert.AreEqual("Blue", groupBox.Get<Label>(SearchCriteria.ByText("abc")).ItemStatus());
        }
    }
}