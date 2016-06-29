namespace Gu.Wpf.PropertyGrid.UiTests
{
    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;

    public class SuffixBlockTests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var title = "SuffixBlockWindow";
            this.application = Application.AttachOrLaunch(Info.CreateStartInfo(title));
            this.window = this.application.GetWindow(title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void SuffixBlockStyle()
        {
            var groupBox = this.window.GetByText<GroupBox>("suffixblock style");
            Assert.AreEqual("Green", groupBox.Get<Label>(SearchCriteria.ByText("abc")).ItemStatus());
        }

        [Test]
        public void InheritsTextBlockStyle()
        {
            var groupBox = this.window.GetByText<GroupBox>("inherits textblock style");
            Assert.AreEqual("Blue", groupBox.Get<Label>(SearchCriteria.ByText("abc")).ItemStatus());
        }
    }
}