namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System.Diagnostics;

    using NUnit.Framework;

    using TestStack.White;
    using TestStack.White.UIItems.WindowItems;

    public class Tests
    {
        private Application application;
        private Window window;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.application = Application.AttachOrLaunch(Info.ProcessStartInfo);
            this.window = this.application.GetWindow("MainWindow");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }

        [Test]
        public void StartApp()
        {
            Assert.IsNotNull(this.window);
        }
    }
}
