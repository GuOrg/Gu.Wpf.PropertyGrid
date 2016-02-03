namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public class InfoPresenter : ContentPresenter
    {
        static InfoPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoPresenter), new FrameworkPropertyMetadata(typeof(InfoPresenter)));
        }
    }
}
