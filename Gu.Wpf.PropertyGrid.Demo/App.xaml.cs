namespace Gu.Wpf.PropertyGrid.Demo
{
    using System;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args.Length == 1)
            {
                var window = e.Args[0];
                this.StartupUri = new Uri($"UiTestWindows/{window}.xaml", UriKind.Relative);
                //var single = GetType().Assembly.GetTypes().Single(x => x.Name == windowType);
                //var window = (Window)Activator.CreateInstance(single);
                //window.Show();
            }

            base.OnStartup(e);
        }
    }
}
