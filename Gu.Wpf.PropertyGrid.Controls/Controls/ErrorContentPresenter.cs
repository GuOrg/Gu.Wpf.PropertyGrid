namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public class ErrorContentPresenter : ContentPresenter
    {
        static ErrorContentPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ErrorContentPresenter), new FrameworkPropertyMetadata(typeof(ErrorContentPresenter)));
        }
    }
}
